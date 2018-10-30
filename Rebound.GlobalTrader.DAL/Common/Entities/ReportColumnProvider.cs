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
	
	public abstract class ReportColumnProvider : DataAccess {
		static private ReportColumnProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ReportColumnProvider Instance {
			get {
				if (_instance == null) _instance = (ReportColumnProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ReportColumns.ProviderType));
				return _instance;
			}
		}
		public ReportColumnProvider() {
			this.ConnectionString = Globals.Settings.ReportColumns.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// GetListForReport
		/// Calls [usp_selectAll_ReportColumn_for_Report]
		/// </summary>
		public abstract List<ReportColumnDetails> GetListForReport(System.Int32? reportNo);

		#endregion
				
		/// <summary>
		/// Returns a new ReportColumnDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ReportColumnDetails GetReportColumnFromReader(DbDataReader reader) {
			ReportColumnDetails reportColumn = new ReportColumnDetails();
			if (reader.HasRows) {
				reportColumn.ReportColumnId = GetReaderValue_Int32(reader, "ReportColumnId", 0); //From: [Table]
				reportColumn.ReportNo = GetReaderValue_NullableInt32(reader, "ReportNo", null); //From: [Table]
				reportColumn.TitleResource = GetReaderValue_String(reader, "TitleResource", ""); //From: [Table]
				reportColumn.ReportColumnFormatNo = GetReaderValue_NullableInt32(reader, "ReportColumnFormatNo", null); //From: [Table]
				reportColumn.HasSum = GetReaderValue_Boolean(reader, "HasSum", false); //From: [Table]
				reportColumn.HasCount = GetReaderValue_Boolean(reader, "HasCount", false); //From: [Table]
				reportColumn.HasAverage = GetReaderValue_Boolean(reader, "HasAverage", false); //From: [Table]
				reportColumn.HasPercentageOnSums = GetReaderValue_Boolean(reader, "HasPercentageOnSums", false); //From: [Table]
				reportColumn.PercentageNumeratorColumnIndex = GetReaderValue_NullableInt32(reader, "PercentageNumeratorColumnIndex", null); //From: [Table]
				reportColumn.PercentageDenominatorColumnIndex = GetReaderValue_NullableInt32(reader, "PercentageDenominatorColumnIndex", null); //From: [Table]
				reportColumn.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null); //From: [Table]
			}
			return reportColumn;
		}
	
		/// <summary>
		/// Returns a collection of ReportColumnDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ReportColumnDetails> GetReportColumnCollectionFromReader(DbDataReader reader) {
			List<ReportColumnDetails> reportColumns = new List<ReportColumnDetails>();
			while (reader.Read()) reportColumns.Add(GetReportColumnFromReader(reader));
			return reportColumns;
		}
		
		
	}
}