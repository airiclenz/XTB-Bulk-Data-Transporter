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

		private static Bitmap _filterImgeToBeUsed = null;
		private static Bitmap _metadataImageToBeUsed = null;
		private static Bitmap _createImage = null;
		private static Bitmap _updateImage = null;
		private static Bitmap _deleteImage = null;
		private static Bitmap _createImageDisabled = null;
		private static Bitmap _updateImageDisabled = null;
		private static Bitmap _deleteImageDisabled = null;



		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		public string LogicalName { get; set; } = string.Empty;
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		public string DisplayName { get; set; } = string.Empty;
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		public string FetchXmlFilter { get; set; } = string.Empty;
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		public Bitmap FilterImage 
		{ 
			get
			{
				if (string.IsNullOrEmpty(FetchXmlFilter))
				{
					return null;
				}

				return _filterImgeToBeUsed;
			} 
		}
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		public bool IsSelected { get; set; } = false;
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		public List<Attribute> Attributes { get; set; } = new List<Attribute>();

		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
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

		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		public bool IsCreate { get; set; } = false;
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		public bool IsUpdate { get; set; } = false;
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		public bool IsDelete { get; set; } = false;
		// ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
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
