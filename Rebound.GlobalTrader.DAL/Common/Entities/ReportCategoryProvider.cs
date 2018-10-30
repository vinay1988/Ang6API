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
	
	public abstract class ReportCategoryProvider : DataAccess {
		static private ReportCategoryProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ReportCategoryProvider Instance {
			get {
				if (_instance == null) _instance = (ReportCategoryProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ReportCategorys.ProviderType));
				return _instance;
			}
		}
		public ReportCategoryProvider() {
			this.ConnectionString = Globals.Settings.ReportCategorys.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_ReportCategory]
		/// </summary>
		public abstract List<ReportCategoryDetails> GetList();
		/// <summary>
		/// GetListForGroup
		/// Calls [usp_selectAll_ReportCategory_for_Group]
		/// </summary>
		public abstract List<ReportCategoryDetails> GetListForGroup(System.Int32? reportCategoryGroupNo);

		#endregion
				
		/// <summary>
		/// Returns a new ReportCategoryDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ReportCategoryDetails GetReportCategoryFromReader(DbDataReader reader) {
			ReportCategoryDetails reportCategory = new ReportCategoryDetails();
			if (reader.HasRows) {
				reportCategory.ReportCategoryId = GetReaderValue_Int32(reader, "ReportCategoryId", 0); //From: [Table]
				reportCategory.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
				reportCategory.ReportCategoryGroupNo = GetReaderValue_NullableInt32(reader, "ReportCategoryGroupNo", null); //From: [usp_select_Report]
				reportCategory.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null); //From: [Table]
			}
			return reportCategory;
		}
	
		/// <summary>
		/// Returns a collection of ReportCategoryDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ReportCategoryDetails> GetReportCategoryCollectionFromReader(DbDataReader reader) {
			List<ReportCategoryDetails> reportCategorys = new List<ReportCategoryDetails>();
			while (reader.Read()) reportCategorys.Add(GetReportCategoryFromReader(reader));
			return reportCategorys;
		}
		
		
	}
}