using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Com.AiricLenz.XTB.Components.Filter.Schema;


// ============================================================================
// ============================================================================
namespace Com.AiricLenz.XTB.Plugin
{

	// ============================================================================
	// ============================================================================
	public partial class FilterEditorForm : Form
	{

		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		public TableFilter Filter
		{
			get => filterEditorControl1.Filter;
			set => filterEditorControl1.Filter = value;
		}


		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		public List<TableAttribute> Attributes
		{
			get => filterEditorControl1.Attributes;
			set => filterEditorControl1.Attributes = value;
		}


		// ============================================================================
		public FilterEditorForm()
		{
			InitializeComponent();
		}


		// ============================================================================
		private void filterEditor1_FilterChanged(
			object sender, 
			EventArgs e)
		{
			// nothing
		}

	}
}
