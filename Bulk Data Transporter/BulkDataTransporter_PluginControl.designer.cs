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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip_searchBox = new System.Windows.Forms.ToolStripTextBox();
            this.listBoxTables = new Com.AiricLenz.XTB.Components.SortableCheckList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox_log = new System.Windows.Forms.RichTextBox();
            this.label_Log = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 45);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelSeparator);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxTables);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.label_Log);
            this.splitContainer1.Panel2MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(1494, 752);
            this.splitContainer1.SplitterDistance = 650;
            this.splitContainer1.TabIndex = 6;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // panelSeparator
            // 
            this.panelSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelSeparator.Location = new System.Drawing.Point(0, 28);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(668, 2);
            this.panelSeparator.TabIndex = 9;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_searchBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(650, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStrip_searchBox
            // 
            this.toolStrip_searchBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStrip_searchBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip_searchBox.ForeColor = System.Drawing.Color.Gray;
            this.toolStrip_searchBox.Name = "toolStrip_searchBox";
            this.toolStrip_searchBox.Size = new System.Drawing.Size(200, 25);
            this.toolStrip_searchBox.Text = "Search";
            this.toolStrip_searchBox.Enter += new System.EventHandler(this.toolStrip_searchBox_Enter);
            this.toolStrip_searchBox.Leave += new System.EventHandler(this.toolStrip_searchBox_Leave);
            this.toolStrip_searchBox.TextChanged += new System.EventHandler(this.toolStrip_searchBox_TextChanged);
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
            this.listBoxTables.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTables.IsCheckable = false;
            this.listBoxTables.IsSortable = true;
            this.listBoxTables.ItemHeigth = 24;
            this.listBoxTables.Location = new System.Drawing.Point(3, 35);
            this.listBoxTables.Name = "listBoxTables";
            this.listBoxTables.ShowScrollBar = true;
            this.listBoxTables.ShowTooltips = true;
            this.listBoxTables.Size = new System.Drawing.Size(644, 712);
            this.listBoxTables.SortingColumnIndex = -1;
            this.listBoxTables.SortingColumnOrder = System.Windows.Forms.SortOrder.None;
            this.listBoxTables.TabIndex = 7;
            this.listBoxTables.Text = "sortableCheckList1";
            this.listBoxTables.SelectedIndexChanged += new System.EventHandler(this.listTables_SelectedIndexChanged);
            this.listBoxTables.ItemChecked += new System.EventHandler(this.listboxTables_ItemCheck);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.richTextBox_log);
            this.panel1.Location = new System.Drawing.Point(15, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 591);
            this.panel1.TabIndex = 28;
            // 
            // richTextBox_log
            // 
            this.richTextBox_log.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox_log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_log.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_log.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_log.Name = "richTextBox_log";
            this.richTextBox_log.ReadOnly = true;
            this.richTextBox_log.Size = new System.Drawing.Size(793, 589);
            this.richTextBox_log.TabIndex = 27;
            this.richTextBox_log.Text = "";
            // 
            // label_Log
            // 
            this.label_Log.AutoSize = true;
            this.label_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Log.Location = new System.Drawing.Point(12, 137);
            this.label_Log.Name = "label_Log";
            this.label_Log.Size = new System.Drawing.Size(30, 16);
            this.label_Log.TabIndex = 7;
            this.label_Log.Text = "Log";
            // 
            // BulkDataTransporter_PluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripMenu);
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "BulkDataTransporter_PluginControl";
            this.Size = new System.Drawing.Size(1500, 800);
            this.Load += new System.EventHandler(this.OnPluginControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label_Log;
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
		private SortableCheckList listBoxTables;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.Panel panelSeparator;
		private System.Windows.Forms.ToolStripButton button_Settings;
		private System.Windows.Forms.ToolStripButton button_manageConnections;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RichTextBox richTextBox_log;
		private System.Windows.Forms.ToolStripTextBox toolStrip_searchBox;
	}
}
