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
		public partial class ReportParameter : BizObject {
		
		#region Properties

		protected static DAL.ReportParameterElement Settings {
			get { return Globals.Settings.ReportParameters; }
		}

		/// <summary>
		/// ReportParameterId
		/// </summary>
		public System.Int32 ReportParameterId { get; set; }		
		/// <summary>
		/// ReportNo
		/// </summary>
		public System.Int32? ReportNo { get; set; }		
		/// <summary>
		/// ParameterName
		/// </summary>
		public System.String ParameterName { get; set; }		
		/// <summary>
		/// Description
		/// </summary>
		public System.String Description { get; set; }		
		/// <summary>
		/// ReportParameterTypeNo
		/// </summary>
		public System.Int32? ReportParameterTypeNo { get; set; }		
		/// <summary>
		/// DropDownNo
		/// </summary>
		public System.Int32? DropDownNo { get; set; }		
		/// <summary>
		/// SortOrder
		/// </summary>
		public System.Int32? SortOrder { get; set; }		
		/// <summary>
		/// ComboAutoSearchNo
		/// </summary>
		public System.Int32? ComboAutoSearchNo { get; set; }		
		/// <summary>
		/// Optional
		/// </summary>
		public System.Boolean Optional { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// GetListForReport
		/// Calls [usp_selectAll_ReportParameter_for_Report]
		/// </summary>
		public static List<ReportParameter> GetListForReport(System.Int32? reportNo) {
			List<ReportParameterDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ReportParameter.GetListForReport(reportNo);
			if (lstDetails == null) {
				return new List<ReportParameter>();
			} else {
				List<ReportParameter> lst = new List<ReportParameter>();
				foreach (ReportParameterDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.ReportParameter obj = new Rebound.GlobalTrader.BLL.ReportParameter();
					obj.ReportParameterId = objDetails.ReportParameterId;
					obj.ReportNo = objDetails.ReportNo;
					obj.ParameterName = objDetails.ParameterName;
					obj.Description = objDetails.Description;
					obj.ReportParameterTypeNo = objDetails.ReportParameterTypeNo;
					obj.DropDownNo = objDetails.DropDownNo;
					obj.SortOrder = objDetails.SortOrder;
					obj.ComboAutoSearchNo = objDetails.ComboAutoSearchNo;
					obj.Optional = objDetails.Optional;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static ReportParameter PopulateFromDBDetailsObject(ReportParameterDetails obj) {
            ReportParameter objNew = new ReportParameter();
			objNew.ReportParameterId = obj.ReportParameterId;
			objNew.ReportNo = obj.ReportNo;
			objNew.ParameterName = obj.ParameterName;
			objNew.Description = obj.Description;
			objNew.ReportParameterTypeNo = obj.ReportParameterTypeNo;
			objNew.DropDownNo = obj.DropDownNo;
			objNew.SortOrder = obj.SortOrder;
			objNew.ComboAutoSearchNo = obj.ComboAutoSearchNo;
			objNew.Optional = obj.Optional;
            return objNew;
        }
		
		#endregion
		
	}
}