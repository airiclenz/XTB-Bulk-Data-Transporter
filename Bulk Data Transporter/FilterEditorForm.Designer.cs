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
            this.filterEditorControl1 = new Com.AiricLenz.XTB.Components.FilterEditorControl();
            this.SuspendLayout();
            // 
            // filterEditorControl1
            // 
            this.filterEditorControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterEditorControl1.AutoScroll = true;
            this.filterEditorControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.filterEditorControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterEditorControl1.Location = new System.Drawing.Point(14, 14);
            this.filterEditorControl1.Margin = new System.Windows.Forms.Padding(5);
            this.filterEditorControl1.Name = "filterEditorControl1";
            this.filterEditorControl1.Padding = new System.Windows.Forms.Padding(5);
            this.filterEditorControl1.Size = new System.Drawing.Size(772, 422);
            this.filterEditorControl1.TabIndex = 0;
            // 
            // FilterEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.filterEditorControl1);
            this.Name = "FilterEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.ResumeLayout(false);

		}

		#endregion

		private Components.FilterEditorControl filterEditorControl1;
	}
}