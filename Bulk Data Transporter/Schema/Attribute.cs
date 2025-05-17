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
		[JsonProperty]
		public string LogicalName { get; set; } = string.Empty;
		[JsonProperty]
		public string DisplayName { get; set; } = string.Empty;
		[JsonProperty]
		public string TypeName { get; set; } = string.Empty;
		[JsonProperty]
		public bool IsChecked { get; set; } = false;


		[JsonIgnore]
		public Bitmap TypeImage { get; set; } = null;

	}
}
