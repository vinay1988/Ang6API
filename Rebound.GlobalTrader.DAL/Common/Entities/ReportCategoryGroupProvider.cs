using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class ReportCategoryGroupProvider : DataAccess {
		static private ReportCategoryGroupProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ReportCategoryGroupProvider Instance {
			get {
				if (_instance == null) _instance = (ReportCategoryGroupProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ReportCategoryGroups.ProviderType));
				return _instance;
			}
		}
		public ReportCategoryGroupProvider() {
			this.ConnectionString = Globals.Settings.ReportCategoryGroups.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_ReportCategoryGroup]
		/// </summary>
		public abstract List<ReportCategoryGroupDetails> GetList();

		#endregion
				
		/// <summary>
		/// Returns a new ReportCategoryGroupDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ReportCategoryGroupDetails GetReportCategoryGroupFromReader(DbDataReader reader) {
			ReportCategoryGroupDetails reportCategoryGroup = new ReportCategoryGroupDetails();
			if (reader.HasRows) {
				reportCategoryGroup.ReportCategoryGroupId = GetReaderValue_Int32(reader, "ReportCategoryGroupId", 0); //From: [Table]
				reportCategoryGroup.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
				reportCategoryGroup.SortOrder = GetReaderValue_String(reader, "SortOrder", ""); //From: [Table]
			}
			return reportCategoryGroup;
		}
	
		/// <summary>
		/// Returns a collection of ReportCategoryGroupDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ReportCategoryGroupDetails> GetReportCategoryGroupCollectionFromReader(DbDataReader reader) {
			List<ReportCategoryGroupDetails> reportCategoryGroups = new List<ReportCategoryGroupDetails>();
			while (reader.Read()) reportCategoryGroups.Add(GetReportCategoryGroupFromReader(reader));
			return reportCategoryGroups;
		}
		
		
	}
}