using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;


// ============================================================================
// ============================================================================
// ============================================================================
namespace Com.AiricLenz.XTB.Plugin
{

	// ============================================================================
	// ============================================================================
	// ============================================================================
	// ============================================================================
	// Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
	// To generate Base64 string for Images below, you can use https://www.base64-image.de/
	[Export(typeof(IXrmToolBoxPlugin)),
		ExportMetadata("Name", "Bulk Data Transporter"),
		ExportMetadata("Description", "This tool helps to define complex migration jobs to transport data from one environment to one or multiple target environments."),
		// Please specify the base64 content of a 32x32 pixels image
		ExportMetadata(
			"SmallImageBase64",
			"iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAFxGlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4KPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iWE1QIENvcmUgNS41LjAiPgogPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4KICA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIgogICAgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIgogICAgeG1sbnM6cGhvdG9zaG9wPSJodHRwOi8vbnMuYWRvYmUuY29tL3Bob3Rvc2hvcC8xLjAvIgogICAgeG1sbnM6ZGM9Imh0dHA6Ly9wdXJsLm9yZy9kYy9lbGVtZW50cy8xLjEvIgogICAgeG1sbnM6ZXhpZj0iaHR0cDovL25zLmFkb2JlLmNvbS9leGlmLzEuMC8iCiAgICB4bWxuczp0aWZmPSJodHRwOi8vbnMuYWRvYmUuY29tL3RpZmYvMS4wLyIKICAgIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIgogICAgeG1sbnM6c3RFdnQ9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZUV2ZW50IyIKICAgeG1wOkNyZWF0ZURhdGU9IjIwMjUtMDUtMDJUMTY6MDg6NDArMDI6MDAiCiAgIHhtcDpNb2RpZnlEYXRlPSIyMDI1LTA1LTA0VDE5OjQ1OjUwKzAyOjAwIgogICB4bXA6TWV0YWRhdGFEYXRlPSIyMDI1LTA1LTA0VDE5OjQ1OjUwKzAyOjAwIgogICBwaG90b3Nob3A6RGF0ZUNyZWF0ZWQ9IjIwMjUtMDUtMDJUMTY6MDg6NDArMDI6MDAiCiAgIHBob3Rvc2hvcDpDb2xvck1vZGU9IjMiCiAgIHBob3Rvc2hvcDpJQ0NQcm9maWxlPSJzUkdCIElFQzYxOTY2LTIu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"),
		// Please specify the base64 content of a 80x80 pixels image
		ExportMetadata(
			"BigImageBase64",
			"iVBORw0KGgoAAAANSUhEUgAAAFAAAABQCAYAAACOEfKtAAAFxGlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4KPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iWE1QIENvcmUgNS41LjAiPgogPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4KICA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIgogICAgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIgogICAgeG1sbnM6cGhvdG9zaG9wPSJodHRwOi8vbnMuYWRvYmUuY29tL3Bob3Rvc2hvcC8xLjAvIgogICAgeG1sbnM6ZGM9Imh0dHA6Ly9wdXJsLm9yZy9kYy9lbGVtZW50cy8xLjEvIgogICAgeG1sbnM6ZXhpZj0iaHR0cDovL25zLmFkb2JlLmNvbS9leGlmLzEuMC8iCiAgICB4bWxuczp0aWZmPSJodHRwOi8vbnMuYWRvYmUuY29tL3RpZmYvMS4wLyIKICAgIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIgogICAgeG1sbnM6c3RFdnQ9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZUV2ZW50IyIKICAgeG1wOkNyZWF0ZURhdGU9IjIwMjUtMDUtMDJUMTY6MDg6NDArMDI6MDAiCiAgIHhtcDpNb2RpZnlEYXRlPSIyMDI1LTA1LTA0VDE5OjQ2OjA3KzAyOjAwIgogICB4bXA6TWV0YWRhdGFEYXRlPSIyMDI1LTA1LTA0VDE5OjQ2OjA3KzAyOjAwIgogICBwaG90b3Nob3A6RGF0ZUNyZWF0ZWQ9IjIwMjUtMDUtMDJUMTY6MDg6NDArMDI6MDAiCiAgIHBob3Rvc2hvcDpDb2xvck1vZGU9IjMiCiAgIHBob3Rvc2hvcDpJQ0NQcm9maWxlPSJzUkdCIElFQzYxOTY2LTIu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"),
		ExportMetadata("BackgroundColor", "Lavender"),
		ExportMetadata("PrimaryFontColor", "Black"),
		ExportMetadata("SecondaryFontColor", "Gray")]
	public class BulkDataTransporter_Plugin : PluginBase
	{

		// ============================================================================
		public override IXrmToolBoxPluginControl GetControl()
		{
			return new BulkDataTransporter_PluginControl();
		}


		// ============================================================================
		/// <summary>
		/// Constructor 
		/// </summary>
		public BulkDataTransporter_Plugin()
		{
			// If you have external assemblies that you need to load, uncomment the following to 
			// hook into the event that will fire when an Assembly fails to resolve
			// AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
		}


		// ============================================================================
		/// <summary>
		/// Event fired by CLR when an assembly reference fails to load
		/// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
		/// For example, a folder named Sample.XrmToolBox.MyPlugin 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
		{
			Assembly loadAssembly = null;
			Assembly currAssembly = Assembly.GetExecutingAssembly();

			// base name of the assembly that failed to resolve
			var argName = args.Name.Substring(0, args.Name.IndexOf(","));

			// check to see if the failing assembly is one that we reference.
			List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
			var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

			// if the current unresolved assembly is referenced by our plugin, attempt to load
			if (refAssembly != null)
			{
				// load from the path to this plugin assembly, not host executable
				string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
				string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
				dir = Path.Combine(dir, folder);

				var assmbPath = Path.Combine(dir, $"{argName}.dll");

				if (File.Exists(assmbPath))
				{
					loadAssembly = Assembly.LoadFrom(assmbPath);
				}
				else
				{
					throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
				}
			}

			return loadAssembly;
		}
	}
}