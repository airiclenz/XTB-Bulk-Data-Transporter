using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Com.AiricLenz.Extentions;
using Com.AiricLenz.XTB.Components;
using Com.AiricLenz.XTB.Plugin.Helpers;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;
using XrmToolBox.Extensibility;


// ============================================================================
// ============================================================================
// ============================================================================
namespace Com.AiricLenz.XTB.Plugin
{

	// ============================================================================
	// ============================================================================
	// ============================================================================
	public partial class BulkDataTransporter_PluginControl : MultipleConnectionsPluginControlBase
	{

		// ##################################################
		// ##################################################
		
		#region Variables and Properties

		private bool isDebugMode = false;

		private Settings _settings;
		private bool _codeUpdate = false;
		private bool _codeUpdateSplitter = false;
		private Guid _currentConnectionGuid;

		private ConnectionManager _connectionManager = null;
		private Logger _logger = null;
		private bool _isSearchTablesEmpty = true;
		private bool _isSearchAttributesEmpty = true;

		private object origin;
		private object target;

		private const string ColorError = "<color=#770000>";
		private const string ColorSolution = "<color=#000077>";
		private const string ColorFile = "<color=#777700>";
		private const string ColorIndent = "<color=#DDDDDD>";
		private const string ColorGreen = "<color=#227700>";
		private const string ColorConnection = "<color=#337799>";
		private const string ColorTeeth = "<color=#CCCCCE>";
		private const string ColorEndTag = "</color>";

		private const string dateTimeFormat = "yyyy-MM-dd HH:mm:ss";


		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		public List<ConnectionDetail> TargetConnections
		{
			get
			{
				return AdditionalConnectionDetails.ToList();
			}
		}

		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		private bool CodeUpdate
		{
			get
			{
				return _codeUpdate;
			}

			set
			{
				_codeUpdate = value;
			}
		}

		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		private bool CodeUpdateSplitter
		{
			get
			{
				return _codeUpdateSplitter;
			}

			set
			{
				_codeUpdateSplitter = value;
			}
		}


		#endregion


		// ##################################################
		// ##################################################
		
		#region Plugin Events


		// ============================================================================
		public BulkDataTransporter_PluginControl()
		{
			InitializeComponent();

			richTextBox_log.Text = string.Empty;

			_logger = new Logger(richTextBox_log);
			_logger.Indent = ColorIndent + "|" + ColorEndTag + "   ";

			ParentChanged += MyPlugin_ParentChanged;

			UpdateColumns();
		}



		// ============================================================================
		private void OnPluginControl_Load(
			object sender,
			EventArgs e)
		{

			// Loads or creates the settings for the plugin
			if (!SettingsManager.Instance.TryLoad(GetType(), out _settings))
			{
				_settings = new Settings();
				CodeUpdate = false;

				SaveSettings();

				LogWarning("Settings not found => a new settings file has been created!");
			}
			else
			{
				LogInfo("Settings found and loaded");

				CodeUpdate = true;
				CodeUpdateSplitter = true;

				listBoxTables.ShowTooltips = _settings.ShowToolTips;

				CodeUpdate = false;
			}

			button_loadMetadata.Enabled = Service != null;
			button_manageConnections.Visible = TargetConnections?.Count > 0;


			UpdateAllConnectionTimeouts();
			LoadMetadata();
		}


		// ============================================================================
		private void MyPlugin_ParentChanged(object sender, EventArgs e)
		{
			if (this.Parent != null)
			{
				if (this.IsHandleCreated)
				{
					this.BeginInvoke((MethodInvoker) delegate
					{
						CodeUpdate = true;
						splitContainer1.SplitterDistance = _settings.SplitContainerPosition;
						splitContainer1.Update();  // Forces immediate UI update
						splitContainer1.Refresh(); // Ensures repaint
						Application.DoEvents();    // Processes pending UI messages
						CodeUpdate = false;
						CodeUpdateSplitter = false;
						LogDebug($"After ParentChanged: {splitContainer1.SplitterDistance}");
					});
				}
				else
				{
					this.HandleCreated += MyPlugin_HandleCreated;
				}
			}
		}

		// ============================================================================
		private void MyPlugin_HandleCreated(object sender, EventArgs e)
		{
			this.HandleCreated -= MyPlugin_HandleCreated; // Unsubscribe to avoid multiple calls
			this.BeginInvoke((MethodInvoker) delegate
			{
				CodeUpdate = true;
				splitContainer1.SplitterDistance = _settings.SplitContainerPosition;
				splitContainer1.Update();  // Forces immediate UI update
				splitContainer1.Refresh(); // Ensures repaint
				Application.DoEvents();    // Processes pending UI messages
				CodeUpdate = false;
				CodeUpdateSplitter = false;

				LogDebug($"After HandleCreated: {splitContainer1.SplitterDistance}");
			});
		}

		// ============================================================================
		/// <summary>
		/// This occurs when the plugin is closing.
		/// </summary>
		/// <param name="info"></param>
		public override void ClosingPlugin(PluginCloseInfo info)
		{
			base.ClosingPlugin(info);
			SaveSettings();
		}

		// ============================================================================
		/// <summary>
		/// This event occurs when the plugin is closed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MyPluginControl_OnCloseTool(
			object sender,
			EventArgs e)
		{
			// Before leaving, save the settings
			SaveSettings(cleanUpNonExistingSolutions: true);
		}


		// ============================================================================
		/// <summary>
		/// This event occurs when the connection has been updated in XrmToolBox
		/// </summary>
		public override void UpdateConnection(
			IOrganizationService newService,
			ConnectionDetail detail,
			string actionName,
			object parameter)
		{
			if (actionName != "AdditionalOrganization")
			{
				_currentConnectionGuid = detail.ConnectionId.Value;

				if (_settings != null &&
					detail != null)
				{
					_settings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
					LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);

					// Set the timeout for the connection
					if (detail != null)
					{
						UpdateConnectionTimout(
							ref detail,
							_settings.ConnectionTimeoutInMinutes);
					}
				}

				LoadMetadata();

				button_loadMetadata.Enabled = Service != null;
			}

			base.UpdateConnection(newService, detail, actionName, parameter);
		}


		// ============================================================================
		protected override void ConnectionDetailsUpdated(
			NotifyCollectionChangedEventArgs e)
		{
			button_manageConnections.Visible = TargetConnections?.Count > 0;


			LoadMetadata();

			_connectionManager?.UpdateConnections();

			UpdateAllConnectionTimeouts();
		}


		// ============================================================================
		private void UpdateAllConnectionTimeouts()
		{
			// Update the source connection
			if (ConnectionDetail != null)
			{
				var connectionDetail = ConnectionDetail;

				UpdateConnectionTimout(
					ref connectionDetail,
					_settings.ConnectionTimeoutInMinutes);
			}


			// Update the target connections
			for (int i = 0; i < TargetConnections.Count; i++)
			{
				var targetConnection = TargetConnections[i];

				UpdateConnectionTimout(
					ref targetConnection,
					_settings.ConnectionTimeoutInMinutes);
			}
		}


		// ============================================================================
		private void button_loadMetadata_Click(object sender, EventArgs e)
		{
			LoadMetadata();
		}



		// ============================================================================
		private void listTables_SelectedIndexChanged(object sender, EventArgs e)
		{

		}



		// ============================================================================
		private void listboxTables_ItemOrderChanged(object sender, EventArgs e)
		{

		}

		// ============================================================================
		private void button_Export_Click(object sender, EventArgs e)
		{

		}



		// ============================================================================
		private void listboxTables_ItemCheck(object sender, EventArgs e)
		{
			if (CodeUpdate)
			{
				return;
			}

			SetExecuteButtonState();
			SaveSettings();
		}

		// ============================================================================
		private void button_addAdditionalConnection_Click(object sender, EventArgs e)
		{
			AddAdditionalOrganization();
		}

		// ============================================================================
		private void button_Settings_Click(
			object sender,
			EventArgs e)
		{
			SettingsForm settingsForm = new SettingsForm();
			settingsForm.Settings = _settings;
			settingsForm.ShowDialog();
			_settings = settingsForm.Settings;

			SaveSettings();
			UpdateColumns();
			UpdateAllConnectionTimeouts();
		}

		// ============================================================================
		private void button_manageConnections_Click(object sender, EventArgs e)
		{
			_connectionManager = new ConnectionManager(this);
			var dialogResult = _connectionManager.ShowDialog();
			_connectionManager = null;
		}

		// ============================================================================
		private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
		{
			if (_settings == null ||
				CodeUpdate ||
				CodeUpdateSplitter)
			{
				LogDebug($"OnSplitterMoved not executing - settingsNull: {_settings == null}, codeUpdate: {CodeUpdate}, codeUpdateSplitter {CodeUpdateSplitter}");
				return;
			}

			LogDebug("OnSplitterMoved: " + splitContainer1.SplitterDistance);
			_settings.SplitContainerPosition = splitContainer1.SplitterDistance;
			SaveSettings();
		}


		// ============================================================================
		private void toolStripTables_searchBox_Enter(object sender, EventArgs e)
		{
			if (_isSearchTablesEmpty)
			{
				CodeUpdate = true;
				toolStripTables_SearchBox.Text = "";
				CodeUpdate = false;

				toolStripTables_SearchBox.ForeColor = Color.Black;
				toolStripTables_SearchBox.Font =
					new Font(
						toolStripTables_SearchBox.Font,
						FontStyle.Regular);
			}
		}


		// ============================================================================
		private void toolStripTables_searchBox_TextChanged(object sender, EventArgs e)
		{
			if (CodeUpdate)
			{
				return;
			}

			_isSearchTablesEmpty = string.IsNullOrWhiteSpace(toolStripTables_SearchBox.Text);
			toolStripTables_buttonClearFilter.Visible = !_isSearchTablesEmpty;

			if (_isSearchTablesEmpty)
			{
				listBoxTables.Filter = null;
				return;
			}

			var filter =
				new SortableCheckListFilter(
					"LogicalName",
					toolStripTables_SearchBox.Text,
					ConditionOperator.Contains);

			listBoxTables.Filter = filter;

		}


		// ============================================================================
		private void toolStripTables_searchBox_Leave(object sender, EventArgs e)
		{
			_isSearchTablesEmpty = string.IsNullOrWhiteSpace(toolStripTables_SearchBox.Text);
			toolStripTables_buttonClearFilter.Visible = !_isSearchTablesEmpty;

			if (_isSearchTablesEmpty)
			{
				CodeUpdate = true;
				toolStripTables_SearchBox.Text = "Search";
				CodeUpdate = false;

				toolStripTables_SearchBox.ForeColor = Color.Gray;
				toolStripTables_SearchBox.Font =
					new Font(
						toolStripTables_SearchBox.Font,
						FontStyle.Italic);
			}
			else
			{
				toolStripTables_SearchBox.ForeColor = Color.Black;
			}
		}


		// ============================================================================
		private void toolStripTables_buttonClearFilter_Click(object sender, EventArgs e)
		{
			CodeUpdate = true;
			toolStripTables_SearchBox.Text = "Search";
			CodeUpdate = false;

			toolStripTables_buttonClearFilter.Visible = false;
			toolStripTables_SearchBox.ForeColor = Color.Gray;
			toolStripTables_SearchBox.Font =
				new Font(
					toolStripTables_SearchBox.Font,
					FontStyle.Italic);

			_isSearchTablesEmpty = true;
			listBoxTables.Filter = null;
		}


		

		// ============================================================================
		private void toolStripAttributes_searchBox_Enter(object sender, EventArgs e)
		{
			if (_isSearchAttributesEmpty)
			{
				CodeUpdate = true;
				toolStripAttributes_SearchBox.Text = "";
				CodeUpdate = false;

				toolStripAttributes_SearchBox.ForeColor = Color.Black;
				toolStripAttributes_SearchBox.Font =
					new Font(
						toolStripAttributes_SearchBox.Font,
						FontStyle.Regular);
			}
		}


		// ============================================================================
		private void toolStripAttributes_searchBox_TextChanged(object sender, EventArgs e)
		{
			if (CodeUpdate)
			{
				return;
			}

			_isSearchAttributesEmpty = string.IsNullOrWhiteSpace(toolStripAttributes_SearchBox.Text);
			toolStripAttributes_buttonClearFilter.Visible = !_isSearchAttributesEmpty;

			if (_isSearchAttributesEmpty)
			{
				listBoxAttributes.Filter = null;
				return;
			}

			var filter =
				new SortableCheckListFilter(
					"LogicalName",
					toolStripAttributes_SearchBox.Text,
					ConditionOperator.Contains);

			listBoxAttributes.Filter = filter;

		}


		// ============================================================================
		private void toolStripAttributes_searchBox_Leave(object sender, EventArgs e)
		{
			_isSearchAttributesEmpty = string.IsNullOrWhiteSpace(toolStripAttributes_SearchBox.Text);
			toolStripAttributes_buttonClearFilter.Visible = !_isSearchAttributesEmpty;

			if (_isSearchAttributesEmpty)
			{
				CodeUpdate = true;
				toolStripAttributes_SearchBox.Text = "Search";
				CodeUpdate = false;

				toolStripAttributes_SearchBox.ForeColor = Color.Gray;
				toolStripAttributes_SearchBox.Font =
					new Font(
						toolStripAttributes_SearchBox.Font,
						FontStyle.Italic);
			}
			else
			{
				toolStripTables_SearchBox.ForeColor = Color.Black;
			}
		}


		// ============================================================================
		private void toolStripAttributes_buttonClearFilter_Click(object sender, EventArgs e)
		{
			CodeUpdate = true;
			toolStripAttributes_SearchBox.Text = "Search";
			CodeUpdate = false;

			toolStripAttributes_buttonClearFilter.Visible = false;
			toolStripAttributes_SearchBox.ForeColor = Color.Gray;
			toolStripAttributes_SearchBox.Font =
				new Font(
					toolStripAttributes_SearchBox.Font,
					FontStyle.Italic);

			_isSearchAttributesEmpty = true;
			listBoxAttributes.Filter = null;
		}



		// ============================================================================
		private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBoxTables.SelectedItem == null)
			{
				return;
			}

			var tableItem =
				listBoxTables.SelectedItem as EntityMetadata;

			LoadEntityMetadata(
					tableItem.LogicalName);
		}




		#endregion


		// ##################################################
		// ##################################################

		#region Custom Logic


		// ============================================================================
		public void RemoveConnection(
			ConnectionDetail connection)
		{
			RemoveAdditionalOrganization(connection);

			_connectionManager?.UpdateConnections();
		}


		// ============================================================================
		public void AddConnection()
		{
			AddAdditionalOrganization();

			_connectionManager?.UpdateConnections();
		}



		// ============================================================================
		private void LoadMetadata()
		{
			if (Service == null)
			{
				return;
			}

			WorkAsync(new WorkAsyncInfo
			{
				Message = "Loading Metadata...",
				Work = (worker, args) =>
				{
					// LOAD ALL TABLES
					var request = new RetrieveAllEntitiesRequest
					{
						EntityFilters = EntityFilters.Entity,
						RetrieveAsIfPublished = true
					};

					var result = (RetrieveAllEntitiesResponse) Service.Execute(request);

					args.Result = result;
				},
				PostWorkCallBack = (args) =>
				{
					if (args.Error != null)
					{
						MessageBox.Show(
							args.Error.ToString(),
							"Error",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);

						return;
					}

					var result = args.Result as RetrieveAllEntitiesResponse;

					if (result == null)
					{
						return;
					}

					foreach (var entityMetadata in result.EntityMetadata)
					{
						var newItem =
							new SortableCheckItem(
								entityMetadata);

						listBoxTables.Items.Add(newItem);
					}

					SaveSettings(cleanUpNonExistingSolutions: true);

					UpdateColumns();
					SetExecuteButtonState();
					listBoxTables.Filter = null;
				}
			});

		}


		// ============================================================================
		private void SetExecuteButtonState()
		{
			// TODO

		}


		// ============================================================================
		private void SaveSettings(
			[CallerMemberName] string caller = "",
			bool cleanUpNonExistingSolutions = false)
		{
			if (CodeUpdate)
			{
				return;
			}

			// Save
			SettingsManager.Instance.Save(GetType(), _settings);

			LogDebug($"Settings have been saved ({caller}): ({_settings.SplitContainerPosition})");
		}



		// ============================================================================
		/// <summary>
		/// A simplified parser that tries to handle a few basic tokens:
		/// - **bold** text
		/// - *italic* text
		/// - `code` (colored)
		/// - # Heading (rest of line in bold, bigger font)
		/// - <color=#000066>colored</color> text
		/// - Regular text
		/// </summary>
		/// <param name="message"></param>
		private void Log(string message = "")
		{
			if (richTextBox_log.InvokeRequired)
			{
				richTextBox_log.Invoke(new Action(() => _logger.Log(message)));
				richTextBox_log.Invoke(new Action(() => richTextBox_log.SelectionStart = richTextBox_log.Text.Length));
				richTextBox_log.Invoke(new Action(() => richTextBox_log.ScrollToCaret()));
			}
			else
			{
				_logger.Log(message);
				richTextBox_log.SelectionStart = richTextBox_log.Text.Length;
				richTextBox_log.ScrollToCaret();
			}
		}

		// ============================================================================
		private void LogDebug(string message = "")
		{
			// only allow debug messages when compiled as debug
#if DEBUG

			if (!isDebugMode)
			{
				return;
			}

			Log(message);
#endif
		}


		// ============================================================================
		private void LogError(string message)
		{
			message = ColorError + message + ColorEndTag;
			Log(message);
		}

		// ============================================================================
		static string GetDurationString(
			DateTime startTime)
		{
			var duration = DateTime.Now - startTime;

			// Extract components from the TimeSpan
			int hours = duration.Hours;
			int minutes = duration.Minutes;
			double seconds = duration.TotalSeconds % 60;

			// Build the formatted string dynamically
			string result = "";

			if (hours > 0)
			{
				result += $"{hours}h ";
			}

			if (minutes > 0 || hours > 0)
			{
				result += $"{minutes}min ";
			}

			if (seconds >= 1 || (hours == 0 && minutes == 0))
			{
				if (minutes > 0 || hours > 0)
				{
					result += $"{Math.Round(seconds)}sec";
				}
				else
				{
					result += $"{seconds:F1}sec";
					result = result.Replace(",", ".");
				}
			}

			return result.Trim(); // Remove trailing whitespace
		}



		// ============================================================================
		private void UpdateColumns()
		{
			if (_settings == null)
			{
				return;
			}

			var colFriendlyName =
				new ColumnDefinition
				{
					Header = "Table Name",
					PropertyName = "SchemaName",
					TooltipText = "The human readable friendly-name of the table.",
					Width = (_settings.ShowLogicalTableNames ? "60%" : "100%"),
					Enabled = _settings.ShowFriendlyTableNames,
					IsSortable = true,
				};

			var colLogicalName =
				new ColumnDefinition
				{
					Header = "Logical Name",
					PropertyName = "LogicalName",
					TooltipText = "The logical-name of the table.",
					Width = (_settings.ShowFriendlyTableNames ? "40%" : "100%"),
					Enabled = _settings.ShowLogicalTableNames,
					IsSortable = true,
				};



			CodeUpdate = true;

			listBoxTables.Columns =
				new List<ColumnDefinition>
				{
					colFriendlyName,		// 0
					colLogicalName,			// 1
				};


			listBoxTables.SortingColumnIndex = _settings.SortingColumnIndex;
			listBoxTables.SortingColumnOrder = _settings.SortingColumnOrder;

			CodeUpdate = false;

			//listboxTables.Refresh();
		}


		// ============================================================================
		private void UpdateConnectionTimout(
			ref ConnectionDetail detail,
			int timoutInMinutes)
		{
			// update the global timout setting
			detail.Timeout = TimeSpan.FromMinutes(timoutInMinutes);

			// also update the timeout on the service client
			if (detail.ServiceClient != null)
			{
				var serviceClient = detail.ServiceClient;

				UpdateConnectionTimout(
					ref serviceClient,
					timoutInMinutes);
			}
		}


		// ============================================================================
		private void UpdateConnectionTimout(
			ref CrmServiceClient serviceClient,
			int timoutInMinutes)
		{
			if (serviceClient != null)
			{
				// For CrmServiceClient, need to access the underlying client configuration
				if (serviceClient.OrganizationWebProxyClient != null)
				{
					// Set timeout on the WebProxy client
					serviceClient.OrganizationWebProxyClient.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(timoutInMinutes);
					serviceClient.OrganizationWebProxyClient.Endpoint.Binding.SendTimeout = TimeSpan.FromMinutes(timoutInMinutes);
					serviceClient.OrganizationWebProxyClient.Endpoint.Binding.ReceiveTimeout = TimeSpan.FromMinutes(timoutInMinutes);
				}

				// If OrganizationServiceProxy is available (for older auth types)
				if (serviceClient.OrganizationServiceProxy != null)
				{
					serviceClient.OrganizationServiceProxy.Timeout = TimeSpan.FromMinutes(timoutInMinutes);
				}
			}
		}


		// ================================================================================
		public void LoadEntityMetadata(
			string entityLogicalName)
		{

			if (string.IsNullOrWhiteSpace(entityLogicalName))
			{
				return;
			}

			WorkAsync(new WorkAsyncInfo
			{
				Message = "Loading Table Metadata...",
				Work = (worker, args) =>
				{
					var request = new RetrieveEntityRequest
					{
						LogicalName = entityLogicalName,
						EntityFilters = EntityFilters.Attributes,
						RetrieveAsIfPublished = true
					};

					var result = (RetrieveEntityResponse) Service.Execute(request);

					args.Result = result?.EntityMetadata;
				},
				PostWorkCallBack = (args) =>
				{
					if (args.Error != null)
					{
						MessageBox.Show(
							args.Error.ToString(),
							"Error",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);

						return;
					}

					var result = args.Result as EntityMetadata;

					if (result == null)
					{
						return;
					}

					listBoxAttributes.Items.Clear();

					foreach (var attribute in result.Attributes)
					{
						var newItem =
							new SortableCheckItem(
								attribute);

						var a = attribute.DisplayName;

						listBoxAttributes.Items.Add(newItem);
					}

					listBoxAttributes.Filter = null;
					listBoxAttributes.CheckAllItems();
					listBoxAttributes.Refresh();
				}
			});

		}



		#endregion


	}


}