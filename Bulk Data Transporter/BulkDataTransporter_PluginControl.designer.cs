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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Configuration = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip_Tables = new System.Windows.Forms.ToolStrip();
            this.toolStripTables_SearchBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip_Attributes = new System.Windows.Forms.ToolStrip();
            this.toolStripAttributes_SearchBox = new System.Windows.Forms.ToolStripTextBox();
            this.tabPage_Log = new System.Windows.Forms.TabPage();
            this.richTextBox_log = new System.Windows.Forms.RichTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTables_buttonClearFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripTables_buttonShowChecked = new System.Windows.Forms.ToolStripButton();
            this.toolStripTables_buttonCheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripTables_buttonInvertCheck = new System.Windows.Forms.ToolStripButton();
            this.toolStripTables_buttonUncheck = new System.Windows.Forms.ToolStripButton();
            this.toolStripTables_buttonFilter = new System.Windows.Forms.ToolStripButton();
            this.listBoxTables = new Com.AiricLenz.XTB.Components.SortableCheckList();
            this.toolStripAttributes_buttonClearFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripAttributes_buttonShowChecked = new System.Windows.Forms.ToolStripButton();
            this.toolStripAttributes_buttonCheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripAttributes_buttonInvertCheck = new System.Windows.Forms.ToolStripButton();
            this.toolStripAttributes_buttonUncheck = new System.Windows.Forms.ToolStripButton();
            this.listBoxAttributes = new Com.AiricLenz.XTB.Components.SortableCheckList();
            this.button_loadMetadata = new System.Windows.Forms.ToolStripButton();
            this.button_addAdditionalConnection = new System.Windows.Forms.ToolStripButton();
            this.button_manageConnections = new System.Windows.Forms.ToolStripButton();
            this.button_Export = new System.Windows.Forms.ToolStripButton();
            this.button_Settings = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.toolStripMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Configuration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip_Tables.SuspendLayout();
            this.toolStrip_Attributes.SuspendLayout();
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
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
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip_Tables);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxTables);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip_Attributes);
            this.splitContainer1.Panel2.Controls.Add(this.listBoxAttributes);
            this.splitContainer1.Panel2MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(1486, 726);
            this.splitContainer1.SplitterDistance = 646;
            this.splitContainer1.TabIndex = 7;
            // 
            // toolStrip_Tables
            // 
            this.toolStrip_Tables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip_Tables.AutoSize = false;
            this.toolStrip_Tables.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_Tables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTables_SearchBox,
            this.toolStripTables_buttonClearFilter,
            this.toolStripTables_buttonShowChecked,
            this.toolStripSeparator3,
            this.toolStripTables_buttonCheckAll,
            this.toolStripTables_buttonInvertCheck,
            this.toolStripTables_buttonUncheck,
            this.toolStripSeparator5,
            this.toolStripTables_buttonFilter});
            this.toolStrip_Tables.Location = new System.Drawing.Point(3, 74);
            this.toolStrip_Tables.Name = "toolStrip_Tables";
            this.toolStrip_Tables.Size = new System.Drawing.Size(640, 25);
            this.toolStrip_Tables.TabIndex = 8;
            this.toolStrip_Tables.Text = "toolStrip1";
            // 
            // toolStripTables_SearchBox
            // 
            this.toolStripTables_SearchBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTables_SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTables_SearchBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTables_SearchBox.ForeColor = System.Drawing.Color.Gray;
            this.toolStripTables_SearchBox.Name = "toolStripTables_SearchBox";
            this.toolStripTables_SearchBox.Size = new System.Drawing.Size(250, 25);
            this.toolStripTables_SearchBox.Text = "Search";
            this.toolStripTables_SearchBox.Enter += new System.EventHandler(this.toolStripTables_searchBox_Enter);
            this.toolStripTables_SearchBox.Leave += new System.EventHandler(this.toolStripTables_searchBox_Leave);
            this.toolStripTables_SearchBox.TextChanged += new System.EventHandler(this.toolStripTables_searchBox_TextChanged);
            // 
            // toolStrip_Attributes
            // 
            this.toolStrip_Attributes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip_Attributes.AutoSize = false;
            this.toolStrip_Attributes.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_Attributes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAttributes_SearchBox,
            this.toolStripAttributes_buttonClearFilter,
            this.toolStripAttributes_buttonShowChecked,
            this.toolStripSeparator4,
            this.toolStripAttributes_buttonCheckAll,
            this.toolStripAttributes_buttonInvertCheck,
            this.toolStripAttributes_buttonUncheck});
            this.toolStrip_Attributes.Location = new System.Drawing.Point(3, 74);
            this.toolStrip_Attributes.Name = "toolStrip_Attributes";
            this.toolStrip_Attributes.Size = new System.Drawing.Size(830, 25);
            this.toolStrip_Attributes.TabIndex = 9;
            this.toolStrip_Attributes.Text = "Clear filter";
            this.toolTip1.SetToolTip(this.toolStrip_Attributes, "Clear filter");
            // 
            // toolStripAttributes_SearchBox
            // 
            this.toolStripAttributes_SearchBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripAttributes_SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripAttributes_SearchBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripAttributes_SearchBox.ForeColor = System.Drawing.Color.Gray;
            this.toolStripAttributes_SearchBox.Name = "toolStripAttributes_SearchBox";
            this.toolStripAttributes_SearchBox.Size = new System.Drawing.Size(250, 25);
            this.toolStripAttributes_SearchBox.Text = "Search";
            this.toolStripAttributes_SearchBox.Enter += new System.EventHandler(this.toolStripAttributes_searchBox_Enter);
            this.toolStripAttributes_SearchBox.Leave += new System.EventHandler(this.toolStripAttributes_searchBox_Leave);
            this.toolStripAttributes_SearchBox.TextChanged += new System.EventHandler(this.toolStripAttributes_searchBox_TextChanged);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(20, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(20, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.AutoSize = false;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(20, 25);
            // 
            // toolStripTables_buttonClearFilter
            // 
            this.toolStripTables_buttonClearFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTables_buttonClearFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTables_buttonClearFilter.Image = global::Com.AiricLenz.XTB.Plugin.Properties.Resources.delete_32px;
            this.toolStripTables_buttonClearFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTables_buttonClearFilter.Name = "toolStripTables_buttonClearFilter";
            this.toolStripTables_buttonClearFilter.Size = new System.Drawing.Size(23, 22);
            this.toolStripTables_buttonClearFilter.Text = "Clear filter";
            this.toolStripTables_buttonClearFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripTables_buttonClearFilter.Visible = false;
            this.toolStripTables_buttonClearFilter.Click += new System.EventHandler(this.toolStripTables_buttonClearFilter_Click);
            // 
            // toolStripTables_buttonShowChecked
            // 
            this.toolStripTables_buttonShowChecked.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTables_buttonShowChecked.Image = global::Com.AiricLenz.XTB.Plugin.Properties.Resources.show_all_16px;
            this.toolStripTables_buttonShowChecked.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTables_buttonShowChecked.Name = "toolStripTables_buttonShowChecked";
            this.toolStripTables_buttonShowChecked.Size = new System.Drawing.Size(23, 22);
            this.toolStripTables_buttonShowChecked.Text = "Showing all items";
            this.toolStripTables_buttonShowChecked.ToolTipText = "Showing all items";
            this.toolStripTables_buttonShowChecked.Click += new System.EventHandler(this.toolStripTables_buttonShowChecked_Click);
            // 
            // toolStripTables_buttonCheckAll
            // 
            this.toolStripTables_buttonCheckAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTables_buttonCheckAll.Image = global::Com.AiricLenz.XTB.Plugin.Properties.Resources.checked_16px;
            this.toolStripTables_buttonCheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTables_buttonCheckAll.Name = "toolStripTables_buttonCheckAll";
            this.toolStripTables_buttonCheckAll.Size = new System.Drawing.Size(23, 22);
            this.toolStripTables_buttonCheckAll.Text = "toolStripButton1";
            this.toolStripTables_buttonCheckAll.ToolTipText = "Check all items";
            this.toolStripTables_buttonCheckAll.Click += new System.EventHandler(this.toolStripTables_buttonCheckAll_Click);
            // 
            // toolStripTables_buttonInvertCheck
            // 
            this.toolStripTables_buttonInvertCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTables_buttonInvertCheck.Image = global::Com.AiricLenz.XTB.Plugin.Properties.Resources.invert_check_16px;
            this.toolStripTables_buttonInvertCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTables_buttonInvertCheck.Name = "toolStripTables_buttonInvertCheck";
            this.toolStripTables_buttonInvertCheck.Size = new System.Drawing.Size(23, 22);
            this.toolStripTables_buttonInvertCheck.Text = "toolStripButton1";
            this.toolStripTables_buttonInvertCheck.ToolTipText = "Invert check of all items";
            this.toolStripTables_buttonInvertCheck.Click += new System.EventHandler(this.toolStripTables_buttonInvertCheck_Click);
            // 
            // toolStripTables_buttonUncheck
            // 
            this.toolStripTables_buttonUncheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTables_buttonUncheck.Image = global::Com.AiricLenz.XTB.Plugin.Properties.Resources.unchecked_16px;
            this.toolStripTables_buttonUncheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTables_buttonUncheck.Name = "toolStripTables_buttonUncheck";
            this.toolStripTables_buttonUncheck.Size = new System.Drawing.Size(23, 22);
            this.toolStripTables_buttonUncheck.Text = "toolStripButton1";
            this.toolStripTables_buttonUncheck.ToolTipText = "Un-Check all items";
            this.toolStripTables_buttonUncheck.Click += new System.EventHandler(this.toolStripTables_buttonUncheck_Click);
            // 
            // toolStripTables_buttonFilter
            // 
            this.toolStripTables_buttonFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTables_buttonFilter.Image = global::Com.AiricLenz.XTB.Plugin.Properties.Resources.filter_16px;
            this.toolStripTables_buttonFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTables_buttonFilter.Name = "toolStripTables_buttonFilter";
            this.toolStripTables_buttonFilter.Size = new System.Drawing.Size(23, 22);
            this.toolStripTables_buttonFilter.Text = "Add / Edit Filter";
            this.toolStripTables_buttonFilter.ToolTipText = "Add / Edit Filter";
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
            this.listBoxTables.CheckBoxRadius = 11;
            this.listBoxTables.CheckBoxSize = 16;
            this.listBoxTables.ColorChecked = System.Drawing.Color.MediumSlateBlue;
            this.listBoxTables.ColorUnchecked = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.listBoxTables.ColumnsJson = "[]";
            this.listBoxTables.DragBurgerLineThickness = 1.5F;
            this.listBoxTables.DragBurgerSize = 11;
            this.listBoxTables.Filter = null;
            this.listBoxTables.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTables.IsBoldWhenChecked = false;
            this.listBoxTables.IsCheckable = true;
            this.listBoxTables.IsSortable = false;
            this.listBoxTables.ItemHeigth = 22;
            this.listBoxTables.Location = new System.Drawing.Point(3, 102);
            this.listBoxTables.Name = "listBoxTables";
            this.listBoxTables.ShowOnlyCheckedItems = false;
            this.listBoxTables.ShowScrollBar = true;
            this.listBoxTables.ShowTooltips = true;
            this.listBoxTables.Size = new System.Drawing.Size(640, 619);
            this.listBoxTables.SortingColumnIndex = -1;
            this.listBoxTables.SortingColumnOrder = System.Windows.Forms.SortOrder.None;
            this.listBoxTables.TabIndex = 7;
            this.listBoxTables.Text = "sortableCheckList1";
            this.listBoxTables.SelectedIndexChanged += new System.EventHandler(this.listBoxTables_SelectedIndexChanged);
            // 
            // toolStripAttributes_buttonClearFilter
            // 
            this.toolStripAttributes_buttonClearFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripAttributes_buttonClearFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAttributes_buttonClearFilter.Image = global::Com.AiricLenz.XTB.Plugin.Properties.Resources.delete_32px;
            this.toolStripAttributes_buttonClearFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAttributes_buttonClearFilter.Name = "toolStripAttributes_buttonClearFilter";
            this.toolStripAttributes_buttonClearFilter.Size = new System.Drawing.Size(23, 22);
            this.toolStripAttributes_buttonClearFilter.Text = "toolStripButton1";
            this.toolStripAttributes_buttonClearFilter.Visible = false;
            this.toolStripAttributes_buttonClearFilter.Click += new System.EventHandler(this.toolStripAttributes_buttonClearFilter_Click);
            // 
            // toolStripAttributes_buttonShowChecked
            // 
            this.toolStripAttributes_buttonShowChecked.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAttributes_buttonShowChecked.Image = global::Com.AiricLenz.XTB.Plugin.Properties.Resources.show_all_16px;
            this.toolStripAttributes_buttonShowChecked.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAttributes_buttonShowChecked.Name = "toolStripAttributes_buttonShowChecked";
            this.toolStripAttributes_buttonShowChecked.Size = new System.Drawing.Size(23, 22);
            this.toolStripAttributes_buttonShowChecked.Text = "toolStripButton1";
            this.toolStripAttributes_buttonShowChecked.ToolTipText = "Showing all items";
            this.toolStripAttributes_buttonShowChecked.Click += new System.EventHandler(this.toolStripAttributes_buttonShowChecked_Click);
            // 
            // toolStripAttributes_buttonCheckAll
            // 
            this.toolStripAttributes_buttonCheckAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAttributes_buttonCheckAll.Image = global::Com.AiricLenz.XTB.Plugin.Properties.Resources.checked_16px;
            this.toolStripAttributes_buttonCheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAttributes_buttonCheckAll.Name = "toolStripAttributes_buttonCheckAll";
            this.toolStripAttributes_buttonCheckAll.Size = new System.Drawing.Size(23, 22);
            this.toolStripAttributes_buttonCheckAll.Text = "toolStripButton1";
            this.toolStripAttributes_buttonCheckAll.ToolTipText = "Check all items";
            this.toolStripAttributes_buttonCheckAll.Click += new System.EventHandler(this.toolStripAttributes_buttonCheckAll_Click);
            // 
            // toolStripAttributes_buttonInvertCheck
            // 
            this.toolStripAttributes_buttonInvertCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAttributes_buttonInvertCheck.Image = global::Com.AiricLenz.XTB.Plugin.Properties.Resources.invert_check_16px;
            this.toolStripAttributes_buttonInvertCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAttributes_buttonInvertCheck.Name = "toolStripAttributes_buttonInvertCheck";
            this.toolStripAttributes_buttonInvertCheck.Size = new System.Drawing.Size(23, 22);
            this.toolStripAttributes_buttonInvertCheck.Text = "toolStripButton1";
            this.toolStripAttributes_buttonInvertCheck.ToolTipText = "Invert check of all items";
            this.toolStripAttributes_buttonInvertCheck.Click += new System.EventHandler(this.toolStripAttributes_buttonInvertCheck_Click);
            // 
            // toolStripAttributes_buttonUncheck
            // 
            this.toolStripAttributes_buttonUncheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAttributes_buttonUncheck.Image = global::Com.AiricLenz.XTB.Plugin.Properties.Resources.unchecked_16px;
            this.toolStripAttributes_buttonUncheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAttributes_buttonUncheck.Name = "toolStripAttributes_buttonUncheck";
            this.toolStripAttributes_buttonUncheck.Size = new System.Drawing.Size(23, 22);
            this.toolStripAttributes_buttonUncheck.Text = "toolStripButton1";
            this.toolStripAttributes_buttonUncheck.ToolTipText = "Uncheck all items";
            this.toolStripAttributes_buttonUncheck.Click += new System.EventHandler(this.toolStripAttributes_buttonUncheck_Click);
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
            this.listBoxAttributes.CheckBoxRadius = 11;
            this.listBoxAttributes.CheckBoxSize = 16;
            this.listBoxAttributes.ColorChecked = System.Drawing.Color.MediumSlateBlue;
            this.listBoxAttributes.ColorUnchecked = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.listBoxAttributes.ColumnsJson = resources.GetString("listBoxAttributes.ColumnsJson");
            this.listBoxAttributes.DragBurgerLineThickness = 1.5F;
            this.listBoxAttributes.DragBurgerSize = 11;
            this.listBoxAttributes.Filter = null;
            this.listBoxAttributes.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAttributes.IsBoldWhenChecked = false;
            this.listBoxAttributes.IsCheckable = true;
            this.listBoxAttributes.IsSortable = false;
            this.listBoxAttributes.ItemHeigth = 22;
            this.listBoxAttributes.Location = new System.Drawing.Point(3, 102);
            this.listBoxAttributes.Name = "listBoxAttributes";
            this.listBoxAttributes.ShowOnlyCheckedItems = false;
            this.listBoxAttributes.ShowScrollBar = true;
            this.listBoxAttributes.ShowTooltips = true;
            this.listBoxAttributes.Size = new System.Drawing.Size(830, 619);
            this.listBoxAttributes.SortingColumnIndex = 0;
            this.listBoxAttributes.SortingColumnOrder = System.Windows.Forms.SortOrder.Ascending;
            this.listBoxAttributes.TabIndex = 8;
            this.listBoxAttributes.Text = "sortableCheckList1";
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
            this.toolStrip_Tables.ResumeLayout(false);
            this.toolStrip_Tables.PerformLayout();
            this.toolStrip_Attributes.ResumeLayout(false);
            this.toolStrip_Attributes.PerformLayout();
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
		private System.Windows.Forms.ToolStrip toolStrip_Tables;
		private System.Windows.Forms.ToolStripTextBox toolStripTables_SearchBox;
		private System.Windows.Forms.ToolStripButton toolStripTables_buttonClearFilter;
		private SortableCheckList listBoxTables;
		private System.Windows.Forms.RichTextBox richTextBox_log;
		private SortableCheckList listBoxAttributes;
		private System.Windows.Forms.ToolStrip toolStrip_Attributes;
		private System.Windows.Forms.ToolStripTextBox toolStripAttributes_SearchBox;
		private System.Windows.Forms.ToolStripButton toolStripAttributes_buttonClearFilter;
		private System.Windows.Forms.ToolStripButton toolStripTables_buttonShowChecked;
		private System.Windows.Forms.ToolStripButton toolStripAttributes_buttonShowChecked;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton toolStripTables_buttonCheckAll;
		private System.Windows.Forms.ToolStripButton toolStripTables_buttonUncheck;
		private System.Windows.Forms.ToolStripButton toolStripTables_buttonInvertCheck;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton toolStripAttributes_buttonCheckAll;
		private System.Windows.Forms.ToolStripButton toolStripAttributes_buttonInvertCheck;
		private System.Windows.Forms.ToolStripButton toolStripAttributes_buttonUncheck;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton toolStripTables_buttonFilter;
	}
}
