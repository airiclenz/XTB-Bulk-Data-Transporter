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
			get => _filterEditor.Filter;
			set => _filterEditor.Filter = value;
		}


		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		public List<TableAttribute> Attributes
		{
			get => _filterEditor.Attributes;
			set => _filterEditor.Attributes = value;
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
