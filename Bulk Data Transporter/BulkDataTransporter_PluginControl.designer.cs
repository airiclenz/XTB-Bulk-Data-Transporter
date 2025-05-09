using Com.AiricLenz.XTB.Components;


namespace Com.AiricLenz.XTB.Plugin
{
    partial class BulkDataTransporter_PluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BulkDataTransporter_PluginControl));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.button_loadMetadata = new System.Windows.Forms.ToolStripButton();
            this.button_addAdditionalConnection = new System.Windows.Forms.ToolStripButton();
            this.button_manageConnections = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.button_Export = new System.Windows.Forms.ToolStripButton();
            this.button_Settings = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Configuration = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip_searchBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip_buttonClearFilter = new System.Windows.Forms.ToolStripButton();
            this.listBoxTables = new Com.AiricLenz.XTB.Components.SortableCheckList();
            this.listBoxAttributes = new Com.AiricLenz.XTB.Components.SortableCheckList();
            this.tabPage_Log = new System.Windows.Forms.TabPage();
            this.richTextBox_log = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.toolStripMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Configuration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage_Log.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Solution files (*.zip)|*.zip|All files (*.*)|*.*\"";
            this.saveFileDialog1.FilterIndex = 0;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.AutoSize = false;
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.button_loadMetadata,
            this.tssSeparator1,
            this.button_addAdditionalConnection,
            this.button_manageConnections,
            this.toolStripSeparator2,
            this.button_Export,
            this.toolStripSeparator1,
            this.button_Settings});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1500, 42);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // button_loadMetadata
            // 
            this.button_loadMetadata.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_loadMetadata.Image = ((System.Drawing.Image)(resources.GetObject("button_loadMetadata.Image")));
            this.button_loadMetadata.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_loadMetadata.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.button_loadMetadata.Name = "button_loadMetadata";
            this.button_loadMetadata.Size = new System.Drawing.Size(141, 39);
            this.button_loadMetadata.Text = "  Load Metadata";
            this.button_loadMetadata.ToolTipText = "Load all unmanaged solutions from the environment...";
            this.button_loadMetadata.Click += new System.EventHandler(this.button_loadMetadata_Click);
            // 
            // button_addAdditionalConnection
            // 
            this.button_addAdditionalConnection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addAdditionalConnection.Image = ((System.Drawing.Image)(resources.GetObject("button_addAdditionalConnection.Image")));
            this.button_addAdditionalConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_addAdditionalConnection.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this.button_addAdditionalConnection.Name = "button_addAdditionalConnection";
            this.button_addAdditionalConnection.Size = new System.Drawing.Size(182, 39);
            this.button_addAdditionalConnection.Text = " Add Target Connection";
            this.button_addAdditionalConnection.ToolTipText = "  Connect to Target";
            this.button_addAdditionalConnection.Click += new System.EventHandler(this.button_addAdditionalConnection_Click);
            // 
            // button_manageConnections
            // 
            this.button_manageConnections.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_manageConnections.Image = global::Com.AiricLenz.XTB.Plugin.Properties.Resources.connections_32px;
            this.button_manageConnections.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_manageConnections.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this.button_manageConnections.Name = "button_manageConnections";
            this.button_manageConnections.Size = new System.Drawing.Size(171, 39);
            this.button_manageConnections.Text = " Manage Connections";
            this.button_manageConnections.ToolTipText = "Manage all connected target environments";
            this.button_manageConnections.Click += new System.EventHandler(this.button_manageConnections_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
            // 
            // button_Export
            // 
            this.button_Export.Enabled = false;
            this.button_Export.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Export.Image = ((System.Drawing.Image)(resources.GetObject("button_Export.Image")));
            this.button_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_Export.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(99, 39);
            this.button_Export.Text = " Execute ";
            this.button_Export.ToolTipText = "Export the Solutions";
            this.button_Export.Click += new System.EventHandler(this.button_Export_Click);
            // 
            // button_Settings
            // 
            this.button_Settings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.button_Settings.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Settings.Image = ((System.Drawing.Image)(resources.GetObject("button_Settings.Image")));
            this.button_Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_Settings.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this.button_Settings.Name = "button_Settings";
            this.button_Settings.Size = new System.Drawing.Size(102, 39);
            this.button_Settings.Text = " Settings";
            this.button_Settings.Click += new System.EventHandler(this.button_Settings_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Configuration);
            this.tabControl1.Controls.Add(this.tabPage_Log);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1500, 758);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage_Configuration
            // 
            this.tabPage_Configuration.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_Configuration.Controls.Add(this.splitContainer1);
            this.tabPage_Configuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage_Configuration.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Configuration.Name = "tabPage_Configuration";
            this.tabPage_Configuration.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Configuration.Size = new System.Drawing.Size(1492, 732);
            this.tabPage_Configuration.TabIndex = 0;
            this.tabPage_Configuration.Text = " Configuration ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxTables);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBoxAttributes);
            this.splitContainer1.Panel2MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(1486, 726);
            this.splitContainer1.SplitterDistance = 646;
            this.splitContainer1.TabIndex = 7;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_searchBox,
            this.toolStrip_buttonClearFilter});
            this.toolStrip1.Location = new System.Drawing.Point(3, 74);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(640, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStrip_searchBox
            // 
            this.toolStrip_searchBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStrip_searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_searchBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip_searchBox.ForeColor = System.Drawing.Color.Gray;
            this.toolStrip_searchBox.Name = "toolStrip_searchBox";
            this.toolStrip_searchBox.Size = new System.Drawing.Size(250, 25);
            this.toolStrip_searchBox.Text = "Search";
            this.toolStrip_searchBox.Enter += new System.EventHandler(this.toolStrip_searchBox_Enter);
            this.toolStrip_searchBox.Leave += new System.EventHandler(this.toolStrip_searchBox_Leave);
            this.toolStrip_searchBox.TextChanged += new System.EventHandler(this.toolStrip_searchBox_TextChanged);
            // 
            // toolStrip_buttonClearFilter
            // 
            this.toolStrip_buttonClearFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStrip_buttonClearFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStrip_buttonClearFilter.Image = global::Com.AiricLenz.XTB.Plugin.Properties.Resources.delete_32px;
            this.toolStrip_buttonClearFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_buttonClearFilter.Name = "toolStrip_buttonClearFilter";
            this.toolStrip_buttonClearFilter.Size = new System.Drawing.Size(23, 22);
            this.toolStrip_buttonClearFilter.Text = "toolStripButton1";
            this.toolStrip_buttonClearFilter.Visible = false;
            this.toolStrip_buttonClearFilter.Click += new System.EventHandler(this.toolStrip_buttonClearFilter_Click);
            // 
            // listBoxTables
            // 
            this.listBoxTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTables.BackColor = System.Drawing.SystemColors.Window;
            this.listBoxTables.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listBoxTables.BackgroundImage")));
            this.listBoxTables.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.listBoxTables.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.listBoxTables.BorderThickness = 1F;
            this.listBoxTables.CheckBoxMargin = 4;
            this.listBoxTables.CheckBoxRadius = 18;
            this.listBoxTables.CheckBoxSize = 18;
            this.listBoxTables.ColorChecked = System.Drawing.Color.MediumSlateBlue;
            this.listBoxTables.ColorUnchecked = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.listBoxTables.ColumnsJson = "[]";
            this.listBoxTables.DragBurgerLineThickness = 1.5F;
            this.listBoxTables.DragBurgerSize = 11;
            this.listBoxTables.Filter = null;
            this.listBoxTables.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTables.IsCheckable = false;
            this.listBoxTables.IsSortable = false;
            this.listBoxTables.ItemHeigth = 22;
            this.listBoxTables.Location = new System.Drawing.Point(3, 102);
            this.listBoxTables.Name = "listBoxTables";
            this.listBoxTables.ShowScrollBar = true;
            this.listBoxTables.ShowTooltips = true;
            this.listBoxTables.Size = new System.Drawing.Size(640, 619);
            this.listBoxTables.SortingColumnIndex = -1;
            this.listBoxTables.SortingColumnOrder = System.Windows.Forms.SortOrder.None;
            this.listBoxTables.TabIndex = 7;
            this.listBoxTables.Text = "sortableCheckList1";
            this.listBoxTables.SelectedIndexChanged += new System.EventHandler(this.listBoxTables_SelectedIndexChanged);
            // 
            // listBoxAttributes
            // 
            this.listBoxAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxAttributes.BackColor = System.Drawing.SystemColors.Window;
            this.listBoxAttributes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listBoxAttributes.BackgroundImage")));
            this.listBoxAttributes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.listBoxAttributes.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.listBoxAttributes.BorderThickness = 1F;
            this.listBoxAttributes.CheckBoxMargin = 4;
            this.listBoxAttributes.CheckBoxRadius = 18;
            this.listBoxAttributes.CheckBoxSize = 18;
            this.listBoxAttributes.ColorChecked = System.Drawing.Color.MediumSlateBlue;
            this.listBoxAttributes.ColorUnchecked = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.listBoxAttributes.ColumnsJson = resources.GetString("listBoxAttributes.ColumnsJson");
            this.listBoxAttributes.DragBurgerLineThickness = 1.5F;
            this.listBoxAttributes.DragBurgerSize = 11;
            this.listBoxAttributes.Filter = null;
            this.listBoxAttributes.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAttributes.IsCheckable = true;
            this.listBoxAttributes.IsSortable = false;
            this.listBoxAttributes.ItemHeigth = 22;
            this.listBoxAttributes.Location = new System.Drawing.Point(3, 102);
            this.listBoxAttributes.Name = "listBoxAttributes";
            this.listBoxAttributes.ShowScrollBar = true;
            this.listBoxAttributes.ShowTooltips = true;
            this.listBoxAttributes.Size = new System.Drawing.Size(830, 619);
            this.listBoxAttributes.SortingColumnIndex = 0;
            this.listBoxAttributes.SortingColumnOrder = System.Windows.Forms.SortOrder.Ascending;
            this.listBoxAttributes.TabIndex = 8;
            this.listBoxAttributes.Text = "sortableCheckList1";
            // 
            // tabPage_Log
            // 
            this.tabPage_Log.Controls.Add(this.richTextBox_log);
            this.tabPage_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage_Log.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Log.Name = "tabPage_Log";
            this.tabPage_Log.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Log.Size = new System.Drawing.Size(1492, 732);
            this.tabPage_Log.TabIndex = 1;
            this.tabPage_Log.Text = " Log ";
            this.tabPage_Log.UseVisualStyleBackColor = true;
            // 
            // richTextBox_log
            // 
            this.richTextBox_log.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox_log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_log.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_log.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_log.Name = "richTextBox_log";
            this.richTextBox_log.ReadOnly = true;
            this.richTextBox_log.Size = new System.Drawing.Size(1486, 726);
            this.richTextBox_log.TabIndex = 28;
            this.richTextBox_log.Text = "";
            // 
            // BulkDataTransporter_PluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStripMenu);
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "BulkDataTransporter_PluginControl";
            this.Size = new System.Drawing.Size(1500, 800);
            this.Load += new System.EventHandler(this.OnPluginControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Configuration.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage_Log.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton button_loadMetadata;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ToolStripButton button_Export;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ToolStripButton button_addAdditionalConnection;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton button_Settings;
		private System.Windows.Forms.ToolStripButton button_manageConnections;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage_Configuration;
		private System.Windows.Forms.TabPage tabPage_Log;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripTextBox toolStrip_searchBox;
		private System.Windows.Forms.ToolStripButton toolStrip_buttonClearFilter;
		private SortableCheckList listBoxTables;
		private System.Windows.Forms.RichTextBox richTextBox_log;
		private SortableCheckList listBoxAttributes;
	}
}
