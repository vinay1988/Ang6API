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
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL {
		public partial class ReportColumn : BizObject {
		
		#region Properties

		protected static DAL.ReportColumnElement Settings {
			get { return Globals.Settings.ReportColumns; }
		}

		/// <summary>
		/// ReportColumnId
		/// </summary>
		public System.Int32 ReportColumnId { get; set; }		
		/// <summary>
		/// ReportNo
		/// </summary>
		public System.Int32? ReportNo { get; set; }		
		/// <summary>
		/// TitleResource
		/// </summary>
		public System.String TitleResource { get; set; }		
		/// <summary>
		/// ReportColumnFormatNo
		/// </summary>
		public System.Int32? ReportColumnFormatNo { get; set; }		
		/// <summary>
		/// HasSum
		/// </summary>
		public System.Boolean HasSum { get; set; }		
		/// <summary>
		/// HasCount
		/// </summary>
		public System.Boolean HasCount { get; set; }		
		/// <summary>
		/// HasAverage
		/// </summary>
		public System.Boolean HasAverage { get; set; }		
		/// <summary>
		/// HasPercentageOnSums
		/// </summary>
		public System.Boolean HasPercentageOnSums { get; set; }		
		/// <summary>
		/// PercentageNumeratorColumnIndex
		/// </summary>
		public System.Int32? PercentageNumeratorColumnIndex { get; set; }		
		/// <summary>
		/// PercentageDenominatorColumnIndex
		/// </summary>
		public System.Int32? PercentageDenominatorColumnIndex { get; set; }		
		/// <summary>
		/// SortOrder
		/// </summary>
		public System.Int32? SortOrder { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// GetListForReport
		/// Calls [usp_selectAll_ReportColumn_for_Report]
		/// </summary>
		public static List<ReportColumn> GetListForReport(System.Int32? reportNo) {
			List<ReportColumnDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ReportColumn.GetListForReport(reportNo);
			if (lstDetails == null) {
				return new List<ReportColumn>();
			} else {
				List<ReportColumn> lst = new List<ReportColumn>();
				foreach (ReportColumnDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.ReportColumn obj = new Rebound.GlobalTrader.BLL.ReportColumn();
					obj.ReportColumnId = objDetails.ReportColumnId;
					obj.ReportNo = objDetails.ReportNo;
					obj.TitleResource = objDetails.TitleResource;
					obj.ReportColumnFormatNo = objDetails.ReportColumnFormatNo;
					obj.HasSum = objDetails.HasSum;
					obj.HasCount = objDetails.HasCount;
					obj.HasAverage = objDetails.HasAverage;
					obj.HasPercentageOnSums = objDetails.HasPercentageOnSums;
					obj.PercentageNumeratorColumnIndex = objDetails.PercentageNumeratorColumnIndex;
					obj.PercentageDenominatorColumnIndex = objDetails.PercentageDenominatorColumnIndex;
					obj.SortOrder = objDetails.SortOrder;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static ReportColumn PopulateFromDBDetailsObject(ReportColumnDetails obj) {
            ReportColumn objNew = new ReportColumn();
			objNew.ReportColumnId = obj.ReportColumnId;
			objNew.ReportNo = obj.ReportNo;
			objNew.TitleResource = obj.TitleResource;
			objNew.ReportColumnFormatNo = obj.ReportColumnFormatNo;
			objNew.HasSum = obj.HasSum;
			objNew.HasCount = obj.HasCount;
			objNew.HasAverage = obj.HasAverage;
			objNew.HasPercentageOnSums = obj.HasPercentageOnSums;
			objNew.PercentageNumeratorColumnIndex = obj.PercentageNumeratorColumnIndex;
			objNew.PercentageDenominatorColumnIndex = obj.PercentageDenominatorColumnIndex;
			objNew.SortOrder = obj.SortOrder;
            return objNew;
        }
		
		#endregion
		
	}
}