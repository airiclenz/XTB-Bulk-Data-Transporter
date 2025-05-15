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
	internal class Attribute
	{
		public string LogicalName { get; set; } = string.Empty;
		public string DisplayName { get; set; } = string.Empty;
		public string TypeName { get; set; } = string.Empty;
		public Bitmap TypeImage { get; } = null;
		public bool IsChecked { get; set; } = false;

	}
}
