using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using Com.AiricLenz.XTB.Components;
using Com.AiricLenz.XTB.Plugin.Helpers;
using Com.AiricLenz.XTB.Plugin.Schema;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;
using XrmToolBox.Extensibility;
using Schema = Com.AiricLenz.XTB.Plugin.Schema;

// ============================================================================
// ============================================================================
namespace Com.AiricLenz.XTB.Plugin
{

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
		
		private ConnectionManager _connectionManager = null;
		private Logger _logger = null;
		private bool _isSearchTablesEmpty = true;
		private bool _isSearchAttributesEmpty = true;

		private List<Table> _tables = new List<Table>();

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
			if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
				return;

			InitializeComponent();

			richTextBox_log.Text = string.Empty;

			_logger = new Logger(richTextBox_log);
			_logger.Indent = ColorIndent + "|" + ColorEndTag + "   ";

			ParentChanged += MyPlugin_ParentChanged;

			Schema.Table.SetFilterImage(
				Properties.Resources.isFiltered);

			Schema.Table.SetMetadataImage(
				Properties.Resources.metadata_18px);

			Schema.Table.SetCreateImages(
				Properties.Resources.create_enabled_18px,
				Properties.Resources.create_disabled_18px);

			Schema.Table.SetUpdateImages(
				Properties.Resources.update_enabled_18px,
				Properties.Resources.update_disabled_18px);

			Schema.Table.SetDeleteImages(
				Properties.Resources.delete_enabled_18px,
				Properties.Resources.delete_disabled_18px);

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
			LoadTables();
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

				LoadTables();

				button_loadMetadata.Enabled = Service != null;
			}

			base.UpdateConnection(newService, detail, actionName, parameter);
		}


		// ============================================================================
		protected override void ConnectionDetailsUpdated(
			NotifyCollectionChangedEventArgs e)
		{
			button_manageConnections.Visible = TargetConnections?.Count > 0;


			LoadTables();

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
			LoadTables();
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
				toolStripTables_buttonFilter.Enabled = false;
				listBoxAttributes.Items.Clear();
				listBoxAttributes.Refresh();
			}
			else
			{
				toolStripTables_buttonFilter.Enabled = true;
				UpdateMetadataForSelectedTable();
			}
				
			UpdateCUDButtonStatuses();
			
		}


		// ============================================================================
		private void toolStripTables_buttonShowChecked_Click(object sender, EventArgs e)
		{
			listBoxTables.ShowOnlyCheckedItems = !listBoxTables.ShowOnlyCheckedItems;

			if (listBoxTables.ShowOnlyCheckedItems)
			{
				toolStripTables_buttonShowChecked.Image = Properties.Resources.show_selected_16px;
				toolStripTables_buttonShowChecked.ToolTipText =
					"Showing only checked items";
			}
			else
			{
				toolStripTables_buttonShowChecked.Image = Properties.Resources.show_all_16px;
				toolStripTables_buttonShowChecked.ToolTipText =
					"Showing all items";
			}
		}

		// ============================================================================
		private void toolStripAttributes_buttonShowChecked_Click(object sender, EventArgs e)
		{
			listBoxAttributes.ShowOnlyCheckedItems = !listBoxAttributes.ShowOnlyCheckedItems;

			if (listBoxAttributes.ShowOnlyCheckedItems)
			{
				toolStripAttributes_buttonShowChecked.Image = Properties.Resources.show_selected_16px;
				toolStripAttributes_buttonShowChecked.ToolTipText =
					"Showing only checked items";
			}
			else
			{
				toolStripAttributes_buttonShowChecked.Image = Properties.Resources.show_all_16px;
				toolStripAttributes_buttonShowChecked.ToolTipText =
					"Showing all items";
			}
		}

		// ============================================================================
		private void toolStripTables_buttonCheckAll_Click(object sender, EventArgs e)
		{
			listBoxTables.CheckAllItems();
		}

		// ============================================================================
		private void toolStripTables_buttonInvertCheck_Click(object sender, EventArgs e)
		{
			listBoxTables.InvertCheckOfAllItems();
		}

		// ============================================================================
		private void toolStripTables_buttonUncheck_Click(object sender, EventArgs e)
		{
			listBoxTables.UnCheckAllItems();
		}

		// ================================================================================
		private void toolStripAttributes_buttonCheckAll_Click(object sender, EventArgs e)
		{
			listBoxAttributes.CheckAllItems();
		}

		// ================================================================================
		private void toolStripAttributes_buttonInvertCheck_Click(object sender, EventArgs e)
		{
			listBoxAttributes.InvertCheckOfAllItems();
		}

		// ================================================================================
		private void toolStripAttributes_buttonUncheck_Click(object sender, EventArgs e)
		{
			listBoxAttributes.UnCheckAllItems();
		}

		// ================================================================================
		private void toolStripTables_buttonFilter_Click(object sender, EventArgs e)
		{
			if (listBoxTables.SelectedItem == null)
			{
				return;
			}

			var table = listBoxTables.SelectedItem as Table;
			table.FetchXmlFilter = "<fetchXml />";

			listBoxTables.Refresh();
		}


		// ================================================================================
		private void toolStripTables_buttonCreate_Click(object sender, EventArgs e)
		{
			if (listBoxTables.SelectedItem == null)
			{
				return;
			}

			var table = listBoxTables.SelectedItem as Table;

			table.IsCreate = !table.IsCreate;
			UpdateCUDButtonStatuses();
			listBoxTables.Refresh();
		}

		// ================================================================================
		private void toolStripTables_buttonUpdate_Click(object sender, EventArgs e)
		{
			if (listBoxTables.SelectedItem == null)
			{
				return;
			}

			var table = listBoxTables.SelectedItem as Table;

			table.IsUpdate = !table.IsUpdate;
			UpdateCUDButtonStatuses();
			listBoxTables.Refresh();
		}

		// ================================================================================
		private void toolStripTables_buttonDelete_Click(object sender, EventArgs e)
		{
			if (listBoxTables.SelectedItem == null)
			{
				return;
			}

			var table = listBoxTables.SelectedItem as Table;

			table.IsDelete = !table.IsDelete;
			UpdateCUDButtonStatuses();
			listBoxTables.Refresh();
		}


		// ================================================================================
		private void listBoxAttributes_ItemChecked(object sender, ItemEventArgs args)
		{
		
			if (listBoxTables.SelectedIndex == -1)
			{
				return;
			}

			var table = listBoxTables.SelectedItem as Table;

			// ----------------------------------
			// we can update the current attribute in the table
			if (args != ItemEventArgs.Empty)
			{
				var attribute =
					args.Item.ItemObject as Schema.Attribute;

				var foundAttribute =
					table.Attributes.FirstOrDefault(
						a => object.ReferenceEquals(a, attribute));

				foundAttribute.IsChecked = args.Item.IsChecked;
				return;
			}

			// ----------------------------------
			// update all attributes in the currently selected table
			foreach (var item in listBoxAttributes.Items)
			{
				var currentAttribute =
					item.ItemObject as Schema.Attribute;
				
				if (currentAttribute == null)
				{
					continue;
				}

				var foundAttribute =
					table.Attributes.FirstOrDefault(
						a => object.ReferenceEquals(a, currentAttribute));
				
				if (foundAttribute == null)
				{
					continue;
				}

				foundAttribute.IsChecked = item.IsChecked;
			}
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
		private void LoadTables()
		{
			if (Service == null)
			{
				return;
			}

			WorkAsync(new WorkAsyncInfo
			{
				Message = "Loading Tables...",
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

					listBoxTables.Items.Clear();

					foreach (var entityMetadata in result.EntityMetadata)
					{
						var newTable =
							new Schema.Table
							{
								LogicalName = entityMetadata.LogicalName,
								DisplayName = entityMetadata.DisplayName?.UserLocalizedLabel?.Label ?? entityMetadata.LogicalName,
								IsSelected = false,
								Attributes = new List<Schema.Attribute>()
							};

						var newItem =
							new SortableCheckItem(
								newTable);

						listBoxTables.Items.Add(newItem);
					}

					SaveSettings(cleanUpNonExistingSolutions: true);

					UpdateColumns();
					SetExecuteButtonState();
					listBoxTables.Filter = null;
				}
			});

		}




		// ================================================================================
		public void UpdateMetadataForSelectedTable(
			bool forceLoad = false)
		{
			var tableIndex = listBoxTables.SelectedIndex;

			if (tableIndex < 0 ||
				tableIndex >= listBoxTables.FilteredItems.Count)
			{
				return;
			}

			var table =
				listBoxTables.FilteredItems[tableIndex].ItemObject as Table;

			if (table == null)
			{
				return;
			}

			if (table.Attributes.Count > 0 &&
				!forceLoad)
			{
				listBoxAttributes.Items.Clear();

				foreach (var attribute in table.Attributes)
				{
					var newItem =
						new SortableCheckItem(
							attribute);

					newItem.IsChecked = attribute.IsChecked;

					listBoxAttributes.Items.Add(newItem);
				}

				listBoxAttributes.CheckAllItems();
				listBoxAttributes.Refresh();

				return;
			}

			WorkAsync(new WorkAsyncInfo
			{
				Message = "Loading Table Metadata...",
				Work = (worker, args) =>
				{
					RetrieveEntityResponse result = null;

					var request = new RetrieveEntityRequest
					{
						LogicalName = table.LogicalName,
						EntityFilters = EntityFilters.Attributes,
						RetrieveAsIfPublished = true
					};
					try
					{
						result = (RetrieveEntityResponse) Service.Execute(request);
						args.Result = result?.EntityMetadata;
					}
					catch (Exception)
					{
						args.Result = null;
					}
				},
				PostWorkCallBack = (args) =>
				{
					if (args == null ||
						args.Error != null)
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
					((Table) listBoxTables.SelectedItem).Attributes.Clear();

					foreach (var attribute in result.Attributes)
					{
						var newAttribute =
							new Schema.Attribute
							{
								LogicalName = attribute.LogicalName,
								DisplayName = attribute.DisplayName?.UserLocalizedLabel?.Label ?? attribute.LogicalName,
								TypeName = attribute.AttributeType.ToString(),
							};

						((Table) listBoxTables.SelectedItem).Attributes.Add(newAttribute);

						var newItem =
							new SortableCheckItem(
								newAttribute);

						listBoxAttributes.Items.Add(newItem);
					}

					listBoxAttributes.CheckAllItems();
					listBoxAttributes.Refresh();
					listBoxTables.Refresh();
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
					PropertyName = "DisplayName",
					TooltipText = "The human readable friendly-name of the table.",
					Width = (_settings.ShowLogicalTableNames ? "50%" : "100%"),
					Enabled = _settings.ShowFriendlyTableNames,
					IsSortable = true,
				};

			var colLogicalName =
				new ColumnDefinition
				{
					Header = "Logical Name",
					PropertyName = "LogicalName",
					TooltipText = "The logical-name of the table.",
					Width = (_settings.ShowFriendlyTableNames ? "45%" : "100%"),
					Enabled = _settings.ShowLogicalTableNames,
					IsSortable = true,
				};

			var colFilter =
				new ColumnDefinition
				{
					Header = "",
					PropertyName = "FilterImage",
					TooltipText = "Shows if a filter is present or not",
					Width = "40 px",
					MarginLeft = 0,
					Enabled = true,
					IsSortable = true,
				};

			var colIsCreate =
				new ColumnDefinition
				{
					Header = "",
					PropertyName = "CreateImage",
					TooltipText = "Shows if missing records are supposed to be created in the target environment",
					Width = "20 px",
					MarginLeft = 0,
					Enabled = true,
					IsSortable = true,
				};

			var colIsUpdate =
				new ColumnDefinition
				{
					Header = "",
					PropertyName = "UpdateImage",
					TooltipText = "Shows if existing records are supposed to be updated in the target environment",
					Width = "20 px",
					MarginLeft = 0,
					Enabled = true,
					IsSortable = true,
				};

			var colIsDelete =
				new ColumnDefinition
				{
					Header = "",
					PropertyName = "DeleteImage",
					TooltipText = "Shows if existing records that are missing in the source environment are supposed to be deleted in the target environment",
					Width = "30 px",
					MarginLeft = 0,
					Enabled = true,
					IsSortable = true,
				};

			var colMetadata =
				new ColumnDefinition
				{
					Header = "",
					PropertyName = "MetadataImage",
					TooltipText = "Shows if the metadata for this table has been loaded",
					Width = "20px",
					MarginLeft = 2,
					Enabled = true,
					IsSortable = true,
				};


			CodeUpdate = true;

			listBoxTables.Columns =
				new List<ColumnDefinition>
				{
					colFriendlyName,
					colLogicalName,	
					colFilter,
					colIsCreate,
					colIsUpdate,
					colIsDelete,
					colMetadata,
				};


			listBoxTables.SortingColumnIndex = _settings.SortingColumnIndex;
			listBoxTables.SortingColumnOrder = _settings.SortingColumnOrder;

			CodeUpdate = false;
		}


		// ============================================================================
		private void UpdateCUDButtonStatuses()
		{
			if (listBoxTables.SelectedItem == null)
			{
				toolStripTables_buttonCreate.Enabled = false;
				toolStripTables_buttonUpdate.Enabled = false;
				toolStripTables_buttonDelete.Enabled = false;
				toolStripTables_buttonCreate.Image = Properties.Resources.create_disabled_16px;
				toolStripTables_buttonUpdate.Image = Properties.Resources.update_disabled_16px;
				toolStripTables_buttonDelete.Image = Properties.Resources.delete_disabled_16px;

				return;
			}

			var table = listBoxTables.SelectedItem as Table;

			toolStripTables_buttonCreate.Enabled = true;
			toolStripTables_buttonUpdate.Enabled = true;
			toolStripTables_buttonDelete.Enabled = true;

			toolStripTables_buttonCreate.Image =
				table.IsCreate ?
				Properties.Resources.create_enabled_16px :
				Properties.Resources.create_disabled_16px;

			toolStripTables_buttonUpdate.Image =
				table.IsUpdate ?
				Properties.Resources.update_enabled_16px :
				Properties.Resources.update_disabled_16px;

			toolStripTables_buttonDelete.Image =
				table.IsDelete ?
				Properties.Resources.delete_enabled_16px :
				Properties.Resources.delete_disabled_16px;
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






		#endregion

		
	}


}