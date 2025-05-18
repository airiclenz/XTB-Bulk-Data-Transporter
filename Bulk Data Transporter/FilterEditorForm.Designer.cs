namespace Com.AiricLenz.XTB.Plugin
{
	partial class FilterEditorForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this._filterEditor = new Com.AiricLenz.XTB.Components.FilterEditorControl();
            this.SuspendLayout();
            // 
            // filterEditor1
            // 
            this._filterEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._filterEditor.Location = new System.Drawing.Point(12, 32);
            this._filterEditor.Name = "filterEditor1";
            this._filterEditor.Size = new System.Drawing.Size(750, 393);
            this._filterEditor.TabIndex = 0;
            this._filterEditor.FilterChanged += new System.EventHandler(this.filterEditor1_FilterChanged);
            // 
            // FilterEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._filterEditor);
            this.Name = "FilterEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.ResumeLayout(false);

		}

		#endregion

		private Components.FilterEditorControl _filterEditor;

	}
}