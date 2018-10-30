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
		public partial class Activity : BizObject {
		
		#region Properties

		protected static DAL.ActivityElement Settings {
			get { return Globals.Settings.Activitys; }
		}

		/// <summary>
		/// ActivityId
		/// </summary>
		public System.Int32 ActivityId { get; set; }		
		/// <summary>
		/// TableName
		/// </summary>
		public System.String TableName { get; set; }		
		/// <summary>
		/// KeyNo
		/// </summary>
		public System.Int32 KeyNo { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32? ClientNo { get; set; }		
		/// <summary>
		/// RowId
		/// </summary>
		public System.Int32 RowId { get; set; }		
		/// <summary>
		/// RowNumber
		/// </summary>
		public System.Int32 RowNumber { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32 CompanyNo { get; set; }		
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
		/// <summary>
		/// PartName
		/// </summary>
		public System.String PartName { get; set; }		
		/// <summary>
		/// RowValue
		/// </summary>
		public System.Double? RowValue { get; set; }		
		/// <summary>
		/// RowDate
		/// </summary>
		public System.DateTime RowDate { get; set; }		
		/// <summary>
		/// ContactName
		/// </summary>
		public System.String ContactName { get; set; }		
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }		
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// ListByClientWithFilter
		/// Calls [usp_list_Activity_by_Client_with_filter]
		/// </summary>
		public static List<Activity> ListByClientWithFilter(System.Int32? clientId, System.Int32? pageIndex, System.Int32? pageSize, System.String tableSearch, System.String contactSearch, System.String cmSearch, System.String employeeSearch) {
			List<ActivityDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Activity.ListByClientWithFilter(clientId, pageIndex, pageSize, tableSearch, contactSearch, cmSearch, employeeSearch);
			if (lstDetails == null) {
				return new List<Activity>();
			} else {
				List<Activity> lst = new List<Activity>();
				foreach (ActivityDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Activity obj = new Rebound.GlobalTrader.BLL.Activity();
					obj.RowId = objDetails.RowId;
					obj.RowNumber = objDetails.RowNumber;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.PartName = objDetails.PartName;
					obj.RowValue = objDetails.RowValue;
					obj.TableName = objDetails.TableName;
					obj.RowDate = objDetails.RowDate;
					obj.ContactName = objDetails.ContactName;
					obj.RowCnt = objDetails.RowCnt;
					obj.RowNum = objDetails.RowNum;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// ListByLoginWithFilter
		/// Calls [usp_list_Activity_by_Login_with_filter]
		/// </summary>
		public static List<Activity> ListByLoginWithFilter(System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.String tableSearch, System.String contactSearch, System.String cmSearch, System.String employeeSearch) {
			List<ActivityDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Activity.ListByLoginWithFilter(loginId, pageIndex, pageSize, tableSearch, contactSearch, cmSearch, employeeSearch);
			if (lstDetails == null) {
				return new List<Activity>();
			} else {
				List<Activity> lst = new List<Activity>();
				foreach (ActivityDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Activity obj = new Rebound.GlobalTrader.BLL.Activity();
					obj.RowId = objDetails.RowId;
					obj.RowNumber = objDetails.RowNumber;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.PartName = objDetails.PartName;
					obj.RowValue = objDetails.RowValue;
					obj.TableName = objDetails.TableName;
					obj.RowDate = objDetails.RowDate;
					obj.ContactName = objDetails.ContactName;
					obj.RowCnt = objDetails.RowCnt;
					obj.RowNum = objDetails.RowNum;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static Activity PopulateFromDBDetailsObject(ActivityDetails obj) {
            Activity objNew = new Activity();
			objNew.ActivityId = obj.ActivityId;
			objNew.TableName = obj.TableName;
			objNew.KeyNo = obj.KeyNo;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.ClientNo = obj.ClientNo;
			objNew.RowId = obj.RowId;
			objNew.RowNumber = obj.RowNumber;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.CompanyName = obj.CompanyName;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.PartName = obj.PartName;
			objNew.RowValue = obj.RowValue;
			objNew.RowDate = obj.RowDate;
			objNew.ContactName = obj.ContactName;
			objNew.RowCnt = obj.RowCnt;
			objNew.RowNum = obj.RowNum;
            return objNew;
        }
		
		#endregion
		
	}
}