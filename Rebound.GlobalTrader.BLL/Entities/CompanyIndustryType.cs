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
		public partial class CompanyIndustryType : BizObject {
		
		#region Properties

		protected static DAL.CompanyIndustryTypeElement Settings {
			get { return Globals.Settings.CompanyIndustryTypes; }
		}

		/// <summary>
		/// CompanyIndustryTypeId
		/// </summary>
		public System.Int32 CompanyIndustryTypeId { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32? CompanyNo { get; set; }		
		/// <summary>
		/// IndustryTypeNo
		/// </summary>
		public System.Int32? IndustryTypeNo { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// DeleteAllForCompany
		/// Calls [usp_delete_CompanyIndustryType_All_For_Company]
		/// </summary>
		public static bool DeleteAllForCompany(System.Int32? companyId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CompanyIndustryType.DeleteAllForCompany(companyId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CompanyIndustryType]
		/// </summary>
		public static Int32 Insert(System.Int32? companyNo, System.Int32? industryTypeNo) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CompanyIndustryType.Insert(companyNo, industryTypeNo);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_CompanyIndustryType]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.CompanyIndustryType.Insert(CompanyNo, IndustryTypeNo);
		}
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_CompanyIndustryType_for_Company]
		/// </summary>
		public static List<CompanyIndustryType> GetListForCompany(System.Int32? companyId) {
			List<CompanyIndustryTypeDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CompanyIndustryType.GetListForCompany(companyId);
			if (lstDetails == null) {
				return new List<CompanyIndustryType>();
			} else {
				List<CompanyIndustryType> lst = new List<CompanyIndustryType>();
				foreach (CompanyIndustryTypeDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CompanyIndustryType obj = new Rebound.GlobalTrader.BLL.CompanyIndustryType();
					obj.IndustryTypeNo = objDetails.IndustryTypeNo;
					obj.Name = objDetails.Name;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static CompanyIndustryType PopulateFromDBDetailsObject(CompanyIndustryTypeDetails obj) {
            CompanyIndustryType objNew = new CompanyIndustryType();
			objNew.CompanyIndustryTypeId = obj.CompanyIndustryTypeId;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.IndustryTypeNo = obj.IndustryTypeNo;
			objNew.Name = obj.Name;
            return objNew;
        }
		
		#endregion
		
	}
}