using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ============================================================================
// ============================================================================
namespace Com.AiricLenz.XTB.Plugin.Schema
{

	// ============================================================================
	// ============================================================================
	internal class Table
	{

		public string LogicalName { get; set; } = string.Empty;
		public string DisplayName { get; set; } = string.Empty;
		public string FetchXmlFilter { get; set; } = string.Empty;
		public Bitmap FilterImage { get; } = null;
		public bool IsSelected { get; set; } = false;	

		public List<Attribute> Attributes { get; set; } = new List<Attribute>();

	}
}
