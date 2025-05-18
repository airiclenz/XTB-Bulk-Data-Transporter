using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.AiricLenz.XTB.Components.Filter.Schema;
using Newtonsoft.Json;

// ============================================================================
// ============================================================================
namespace Com.AiricLenz.XTB.Plugin.Schema
{

	// ============================================================================
	// ============================================================================
	internal class Table
	{

		private static Bitmap _filterImgeToBeUsed = null;
		private static Bitmap _metadataImageToBeUsed = null;
		private static Bitmap _createImage = null;
		private static Bitmap _updateImage = null;
		private static Bitmap _deleteImage = null;
		private static Bitmap _createImageDisabled = null;
		private static Bitmap _updateImageDisabled = null;
		private static Bitmap _deleteImageDisabled = null;



		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		[JsonProperty]
		public string LogicalName { get; set; } = string.Empty;
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		[JsonProperty]
		public string DisplayName { get; set; } = string.Empty;
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		[JsonProperty]
		public TableFilter Filter { get; set; } = null;
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		[JsonProperty]
		public bool IsChecked { get; set; } = false;
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		[JsonProperty]
		public List<TableAttribute> Attributes { get; set; } = new List<TableAttribute>();
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		[JsonProperty]
		public bool IsCreate { get; set; } = false;
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		[JsonProperty]
		public bool IsUpdate { get; set; } = false;
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		[JsonProperty]
		public bool IsDelete { get; set; } = false;



		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		[JsonIgnore]
		public Bitmap CreateImage
		{
			get
			{
				if (IsCreate)
				{
					return _createImage;
				}

				return _createImageDisabled;
			}
		}
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		[JsonIgnore]
		public Bitmap UpdateImage
		{
			get
			{
				if (IsUpdate)
				{
					return _updateImage;
				}

				return _updateImageDisabled;
			}
		}
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		[JsonIgnore]
		public Bitmap DeleteImage
		{
			get
			{
				if (IsDelete)
				{
					return _deleteImage;
				}

				return _deleteImageDisabled;
			}
		}
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		[JsonIgnore]
		public Bitmap FilterImage
		{
			get
			{
				if (Filter == null)
				{
					return null;
				}

				return _filterImgeToBeUsed;
			}
		}
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		[JsonIgnore]
		public Bitmap MetadataImage
		{
			get
			{
				if (Attributes == null ||
					Attributes.Count == 0)
				{
					return null;
				}

				return _metadataImageToBeUsed;
			}
		}



		// ============================================================================
		public static void SetFilterImage(Bitmap bitmap)
		{
			_filterImgeToBeUsed = bitmap;
		}

		// ============================================================================
		public static void SetMetadataImage(Bitmap bitmap)
		{
			_metadataImageToBeUsed = bitmap;
		}

		// ============================================================================
		public static void SetCreateImages(
			Bitmap bitmapEnabled,
			Bitmap bitmapDisabled)
		{
			_createImage = bitmapEnabled;
			_createImageDisabled = bitmapDisabled;
		}

		// ============================================================================
		public static void SetUpdateImages(
			Bitmap bitmapEnabled,
			Bitmap bitmapDisabled)
		{
			_updateImage = bitmapEnabled;
			_updateImageDisabled = bitmapDisabled;
		}

		// ============================================================================
		public static void SetDeleteImages(
			Bitmap bitmapEnabled,
			Bitmap bitmapDisabled)
		{
			_deleteImage = bitmapEnabled;
			_deleteImageDisabled = bitmapDisabled;
		}

	}

}
