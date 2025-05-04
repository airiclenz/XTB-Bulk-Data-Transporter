using System;
using System.Collections.Generic;
using System.Windows.Forms;


// ============================================================================
// ============================================================================
// ============================================================================
namespace Com.AiricLenz.XTB.Plugin
{

	// ============================================================================
	// ============================================================================
	// ============================================================================
	/// <summary>
	/// This class can help you to store settings for your plugin
	/// </summary>
	/// <remarks>
	/// This class must be XML serializable
	/// </remarks>
	public class Settings
	{

		private int _connectionTimeoutInMinutes = 120;


		public string LastUsedOrganizationWebappUrl
		{
			get; set;
		}
		
		public bool ShowLogicalTableNames
		{
			get; set;
		}

		public bool ShowFriendlyTableNames
		{
			get; set;
		}

		public bool ShowToolTips
		{
			get; set;
		}

		public int SortingColumnIndex
		{
			get; set;
		}

		public SortOrder SortingColumnOrder
		{
			get; set;
		} 


		public int SplitContainerPosition
		{
			get; set;
		} = 500;

		public int ConnectionTimeoutInMinutes
		{
			get
			{
				return _connectionTimeoutInMinutes;
			}
			set
			{
				if (_connectionTimeoutInMinutes < 2)
				{
					_connectionTimeoutInMinutes = 2;
				}
				else if (_connectionTimeoutInMinutes > 600)
				{
					_connectionTimeoutInMinutes = 600;
				}
				else
				{
					_connectionTimeoutInMinutes = value;
				}
			}
		}



		// ============================================================================
		public Settings()
		{
			LastUsedOrganizationWebappUrl = string.Empty;

			ShowLogicalTableNames = true;
			ShowFriendlyTableNames = true;
			ShowToolTips = true;

			SortingColumnIndex = 0;
			SortingColumnOrder = SortOrder.Ascending;
		}


	}
}