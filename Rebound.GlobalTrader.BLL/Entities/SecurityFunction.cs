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
		public partial class SecurityFunction : BizObject {
		
		#region Properties

		protected static DAL.SecurityFunctionElement Settings {
			get { return Globals.Settings.SecurityFunctions; }
		}

		/// <summary>
		/// SecurityFunctionId
		/// </summary>
		public System.Int32 SecurityFunctionId { get; set; }		
		/// <summary>
		/// FunctionName
		/// </summary>
		public System.String FunctionName { get; set; }		
		/// <summary>
		/// Description
		/// </summary>
		public System.String Description { get; set; }		
		/// <summary>
		/// SitePageNo
		/// </summary>
		public System.Int32? SitePageNo { get; set; }		
		/// <summary>
		/// SiteSectionNo
		/// </summary>
		public System.Int32? SiteSectionNo { get; set; }		
		/// <summary>
		/// ReportNo
		/// </summary>
		public System.Int32? ReportNo { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// InitiallyProhibitedForNewLogins
		/// </summary>
		public System.Boolean InitiallyProhibitedForNewLogins { get; set; }		
		/// <summary>
		/// DisplaySortOrder
		/// </summary>
		public System.Int32? DisplaySortOrder { get; set; }		
		/// <summary>
		/// IsAllowed
		/// </summary>
		public System.Boolean? IsAllowed { get; set; }		
		/// <summary>
		/// ReportId
		/// </summary>
		public System.Int32 ReportId { get; set; }		
		/// <summary>
		/// ReportName
		/// </summary>
		public System.String ReportName { get; set; }		
		/// <summary>
		/// ReportCategoryName
		/// </summary>
		public System.String ReportCategoryName { get; set; }		
		/// <summary>
		/// ReportCategoryGroupName
		/// </summary>
		public System.String ReportCategoryGroupName { get; set; }		
		/// <summary>
		/// SiteSectionName
		/// </summary>
		public System.String SiteSectionName { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Get
		/// Calls [usp_select_SecurityFunction]
		/// </summary>
		public static SecurityFunction Get(System.Int32? securityFunctionNo) {
			Rebound.GlobalTrader.DAL.SecurityFunctionDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.Get(securityFunctionNo);
			if (objDetails == null) {
				return null;
			} else {
				SecurityFunction obj = new SecurityFunction();
				obj.SecurityFunctionId = objDetails.SecurityFunctionId;
				obj.FunctionName = objDetails.FunctionName;
				obj.Description = objDetails.Description;
				obj.SitePageNo = objDetails.SitePageNo;
				obj.SiteSectionNo = objDetails.SiteSectionNo;
				obj.ReportNo = objDetails.ReportNo;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.InitiallyProhibitedForNewLogins = objDetails.InitiallyProhibitedForNewLogins;
				obj.DisplaySortOrder = objDetails.DisplaySortOrder;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetBySitePage
		/// Calls [usp_select_SecurityFunction_by_SitePage]
		/// </summary>
		public static SecurityFunction GetBySitePage(System.Int32? sitePageNo) {
			Rebound.GlobalTrader.DAL.SecurityFunctionDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetBySitePage(sitePageNo);
			if (objDetails == null) {
				return null;
			} else {
				SecurityFunction obj = new SecurityFunction();
				obj.SecurityFunctionId = objDetails.SecurityFunctionId;
				obj.FunctionName = objDetails.FunctionName;
				obj.Description = objDetails.Description;
				obj.SitePageNo = objDetails.SitePageNo;
				obj.SiteSectionNo = objDetails.SiteSectionNo;
				obj.ReportNo = objDetails.ReportNo;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.InitiallyProhibitedForNewLogins = objDetails.InitiallyProhibitedForNewLogins;
				obj.DisplaySortOrder = objDetails.DisplaySortOrder;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetPermissionByLogin
		/// Calls [usp_select_SecurityFunction_Permission_by_Login]
		/// </summary>
		public static SecurityFunction GetPermissionByLogin(System.Int32? securityFunctionNo, System.Int32? loginNo) {
			Rebound.GlobalTrader.DAL.SecurityFunctionDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetPermissionByLogin(securityFunctionNo, loginNo);
			if (objDetails == null) {
				return null;
			} else {
				SecurityFunction obj = new SecurityFunction();
				obj.IsAllowed = objDetails.IsAllowed;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetReportPermissionForLogin
		/// Calls [usp_select_SecurityFunction_Report_Permission_for_Login]
		/// </summary>
		public static SecurityFunction GetReportPermissionForLogin(System.Int32? loginNo, System.Int32? reportNo) {
			Rebound.GlobalTrader.DAL.SecurityFunctionDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetReportPermissionForLogin(loginNo, reportNo);
			if (objDetails == null) {
				return null;
			} else {
				SecurityFunction obj = new SecurityFunction();
				obj.IsAllowed = objDetails.IsAllowed;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_SecurityFunction]
		/// </summary>
		public static List<SecurityFunction> GetList() {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetList();
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.FunctionName = objDetails.FunctionName;
					obj.Description = objDetails.Description;
					obj.SitePageNo = objDetails.SitePageNo;
					obj.SiteSectionNo = objDetails.SiteSectionNo;
					obj.ReportNo = objDetails.ReportNo;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.InitiallyProhibitedForNewLogins = objDetails.InitiallyProhibitedForNewLogins;
					obj.DisplaySortOrder = objDetails.DisplaySortOrder;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListBySitePage
		/// Calls [usp_selectAll_SecurityFunction_by_SitePage]
		/// </summary>
		public static List<SecurityFunction> GetListBySitePage(System.Int32? sitePageNo) {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListBySitePage(sitePageNo);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.FunctionName = objDetails.FunctionName;
					obj.SitePageNo = objDetails.SitePageNo;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListGeneral
		/// Calls [usp_selectAll_SecurityFunction_General]
		/// </summary>
		public static List<SecurityFunction> GetListGeneral() {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListGeneral();
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.FunctionName = objDetails.FunctionName;
					obj.Description = objDetails.Description;
					obj.SitePageNo = objDetails.SitePageNo;
					obj.SiteSectionNo = objDetails.SiteSectionNo;
					obj.ReportNo = objDetails.ReportNo;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.InitiallyProhibitedForNewLogins = objDetails.InitiallyProhibitedForNewLogins;
					obj.DisplaySortOrder = objDetails.DisplaySortOrder;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListGeneralPermissionsByLogin
		/// Calls [usp_selectAll_SecurityFunction_General_Permissions_by_Login]
		/// </summary>
		public static List<SecurityFunction> GetListGeneralPermissionsByLogin(System.Int32? loginNo) {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListGeneralPermissionsByLogin(loginNo);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.IsAllowed = objDetails.IsAllowed;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListGeneralPermissionsBySecurityGroup
		/// Calls [usp_selectAll_SecurityFunction_General_Permissions_by_SecurityGroup]
		/// </summary>
		public static List<SecurityFunction> GetListGeneralPermissionsBySecurityGroup(System.Int32? securityGroupId) {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListGeneralPermissionsBySecurityGroup(securityGroupId);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.IsAllowed = objDetails.IsAllowed;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListPage
		/// Calls [usp_selectAll_SecurityFunction_Page]
		/// </summary>
		public static List<SecurityFunction> GetListPage() {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListPage();
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.FunctionName = objDetails.FunctionName;
					obj.SitePageNo = objDetails.SitePageNo;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListPageBySiteSection
		/// Calls [usp_selectAll_SecurityFunction_Page_by_SiteSection]
		/// </summary>
		public static List<SecurityFunction> GetListPageBySiteSection(System.Int32? siteSectionNo) {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListPageBySiteSection(siteSectionNo);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.FunctionName = objDetails.FunctionName;
					obj.SitePageNo = objDetails.SitePageNo;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListPagePermissionsByPage
		/// Calls [usp_selectAll_SecurityFunction_Page_Permissions_by_Page]
		/// </summary>
		public static List<SecurityFunction> GetListPagePermissionsByPage(System.Int32? pageId) {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListPagePermissionsByPage(pageId);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.IsAllowed = objDetails.IsAllowed;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListPagePermissionsByPageAndLogin
		/// Calls [usp_selectAll_SecurityFunction_Page_Permissions_by_Page_and_Login]
		/// </summary>
        public static List<SecurityFunction> GetListPagePermissionsByPageAndLogin(System.Int32? sitePageNo, System.Int32? loginNo, System.Boolean? dataHasOtherClient)
        {
            List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListPagePermissionsByPageAndLogin(sitePageNo, loginNo, dataHasOtherClient);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.IsAllowed = objDetails.IsAllowed;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListPagePermissionsBySecurityGroup
		/// Calls [usp_selectAll_SecurityFunction_Page_Permissions_by_SecurityGroup]
		/// </summary>
		public static List<SecurityFunction> GetListPagePermissionsBySecurityGroup(System.Int32? securityGroupId) {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListPagePermissionsBySecurityGroup(securityGroupId);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.IsAllowed = objDetails.IsAllowed;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListPagePermissionsBySecurityGroupAndPage
		/// Calls [usp_selectAll_SecurityFunction_Page_Permissions_by_SecurityGroup_and_Page]
		/// </summary>
		public static List<SecurityFunction> GetListPagePermissionsBySecurityGroupAndPage(System.Int32? securityGroupNo, System.Int32? pageId) {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListPagePermissionsBySecurityGroupAndPage(securityGroupNo, pageId);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.IsAllowed = objDetails.IsAllowed;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListPermissionsByLoginAndReport
		/// Calls [usp_selectAll_SecurityFunction_Permissions_by_Login_and_Report]
		/// </summary>
		public static List<SecurityFunction> GetListPermissionsByLoginAndReport(System.Int32? loginNo, System.Int32? reportNo) {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListPermissionsByLoginAndReport(loginNo, reportNo);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.IsAllowed = objDetails.IsAllowed;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListPermissionsByLoginAndSitePage
		/// Calls [usp_selectAll_SecurityFunction_Permissions_by_Login_and_SitePage]
		/// </summary>
		public static List<SecurityFunction> GetListPermissionsByLoginAndSitePage(System.Int32? loginNo, System.Int32? sitePageNo) {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListPermissionsByLoginAndSitePage(loginNo, sitePageNo);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.IsAllowed = objDetails.IsAllowed;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListPermissionsByLoginAndSiteSection
		/// Calls [usp_selectAll_SecurityFunction_Permissions_by_Login_and_SiteSection]
		/// </summary>
		public static List<SecurityFunction> GetListPermissionsByLoginAndSiteSection(System.Int32? loginNo, System.Int32? siteSectionNo,System.Boolean? isDataOtherClient) {
            List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListPermissionsByLoginAndSiteSection(loginNo, siteSectionNo, isDataOtherClient);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.IsAllowed = objDetails.IsAllowed;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListReport
		/// Calls [usp_selectAll_SecurityFunction_Report]
		/// </summary>
		public static List<SecurityFunction> GetListReport() {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListReport();
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.FunctionName = objDetails.FunctionName;
					obj.ReportId = objDetails.ReportId;
					obj.ReportName = objDetails.ReportName;
					obj.ReportCategoryName = objDetails.ReportCategoryName;
					obj.ReportCategoryGroupName = objDetails.ReportCategoryGroupName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListReportPermissionsByLogin
		/// Calls [usp_selectAll_SecurityFunction_Report_Permissions_by_Login]
		/// </summary>
		public static List<SecurityFunction> GetListReportPermissionsByLogin(System.Int32? loginNo) {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListReportPermissionsByLogin(loginNo);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.IsAllowed = objDetails.IsAllowed;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListReportPermissionsBySecurityGroup
		/// Calls [usp_selectAll_SecurityFunction_Report_Permissions_by_SecurityGroup]
		/// </summary>
		public static List<SecurityFunction> GetListReportPermissionsBySecurityGroup(System.Int32? securityGroupId) {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListReportPermissionsBySecurityGroup(securityGroupId);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.IsAllowed = objDetails.IsAllowed;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListSection
		/// Calls [usp_selectAll_SecurityFunction_Section]
		/// </summary>
		public static List<SecurityFunction> GetListSection(System.Int32? sectionNo) {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListSection(sectionNo);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.FunctionName = objDetails.FunctionName;
					obj.SiteSectionNo = objDetails.SiteSectionNo;
					obj.SiteSectionName = objDetails.SiteSectionName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListSectionPermissionsByLogin
		/// Calls [usp_selectAll_SecurityFunction_Section_Permissions_by_Login]
		/// </summary>
		public static List<SecurityFunction> GetListSectionPermissionsByLogin(System.Int32? loginNo) {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListSectionPermissionsByLogin(loginNo);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.IsAllowed = objDetails.IsAllowed;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListSectionPermissionsBySecurityGroup
		/// Calls [usp_selectAll_SecurityFunction_Section_Permissions_by_SecurityGroup]
		/// </summary>
		public static List<SecurityFunction> GetListSectionPermissionsBySecurityGroup(System.Int32? securityGroupId) {
			List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListSectionPermissionsBySecurityGroup(securityGroupId);
			if (lstDetails == null) {
				return new List<SecurityFunction>();
			} else {
				List<SecurityFunction> lst = new List<SecurityFunction>();
				foreach (SecurityFunctionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
					obj.SecurityFunctionId = objDetails.SecurityFunctionId;
					obj.IsAllowed = objDetails.IsAllowed;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        /// <summary>
        /// CheckAdminPermissionsByLogin
        /// Calls [usp_check_admin_Permissions_by_Login]
        /// </summary>
        public static SecurityFunction CheckAdminPermissionsByLogin(System.Int32? loginNo)
        {
            Rebound.GlobalTrader.DAL.SecurityFunctionDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.CheckAdminPermissionsByLogin(loginNo);
            if (objDetails == null)
            {
                return new SecurityFunction();
            }
            else
            {
                SecurityFunction obj = new SecurityFunction();
                //obj.SecurityFunctionId = objDetails.SecurityFunctionId;
                obj.IsAllowed = objDetails.IsAllowed;
                objDetails = null;
                return obj;
            }
        }

        /// <summary>
        /// GetListGeneralPermissionsByGlobalSecurityGroup
        /// Calls [usp_selectAll_GlobalSecurityFunction_General_Permissions_by_SecurityGroup]
        /// </summary>
        public static List<SecurityFunction> GetListGeneralPermissionsByGlobalSecurityGroup(System.Int32? securityGroupId)
        {
            List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListGeneralPermissionsByGlobalSecurityGroup(securityGroupId);
            if (lstDetails == null)
            {
                return new List<SecurityFunction>();
            }
            else
            {
                List<SecurityFunction> lst = new List<SecurityFunction>();
                foreach (SecurityFunctionDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
                    obj.SecurityFunctionId = objDetails.SecurityFunctionId;
                    obj.IsAllowed = objDetails.IsAllowed;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// GetListSectionPermissionsByGlobalSecurityGroup
        /// Calls [usp_selectAll_SecurityFunction_Section_Permissions_by_GlobalSecurityGroup]
        /// </summary>
        public static List<SecurityFunction> GetListSectionPermissionsByGlobalSecurityGroup(System.Int32? securityGroupId)
        {
            List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListSectionPermissionsByGlobalSecurityGroup(securityGroupId);
            if (lstDetails == null)
            {
                return new List<SecurityFunction>();
            }
            else
            {
                List<SecurityFunction> lst = new List<SecurityFunction>();
                foreach (SecurityFunctionDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
                    obj.SecurityFunctionId = objDetails.SecurityFunctionId;
                    obj.IsAllowed = objDetails.IsAllowed;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// GetListPagePermissionsByGlobalSecurityGroupAndPage
        /// Calls [usp_selectAll_SecurityFunction_Page_Permissions_by_GlobalSecurityGroup_and_Page]
        /// </summary>
        public static List<SecurityFunction> GetListPagePermissionsByGlobalSecurityGroupAndPage(System.Int32? securityGroupNo, System.Int32? pageId)
        {
            List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetListPagePermissionsByGlobalSecurityGroupAndPage(securityGroupNo, pageId);
            if (lstDetails == null)
            {
                return new List<SecurityFunction>();
            }
            else
            {
                List<SecurityFunction> lst = new List<SecurityFunction>();
                foreach (SecurityFunctionDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
                    obj.SecurityFunctionId = objDetails.SecurityFunctionId;
                    obj.IsAllowed = objDetails.IsAllowed;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }


        /// <summary>
        /// GetListBySitePage
        /// Calls [usp_selectAll_GlobalSecurityFunction_by_SitePage]
        /// </summary>
        public static List<SecurityFunction> GetGlobalListBySitePage(System.Int32? sitePageNo)
        {
            List<SecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityFunction.GetGlobalListBySitePage(sitePageNo);
            if (lstDetails == null)
            {
                return new List<SecurityFunction>();
            }
            else
            {
                List<SecurityFunction> lst = new List<SecurityFunction>();
                foreach (SecurityFunctionDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SecurityFunction obj = new Rebound.GlobalTrader.BLL.SecurityFunction();
                    obj.SecurityFunctionId = objDetails.SecurityFunctionId;
                    obj.FunctionName = objDetails.FunctionName;
                    obj.SitePageNo = objDetails.SitePageNo;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        private static SecurityFunction PopulateFromDBDetailsObject(SecurityFunctionDetails obj) {
            SecurityFunction objNew = new SecurityFunction();
			objNew.SecurityFunctionId = obj.SecurityFunctionId;
			objNew.FunctionName = obj.FunctionName;
			objNew.Description = obj.Description;
			objNew.SitePageNo = obj.SitePageNo;
			objNew.SiteSectionNo = obj.SiteSectionNo;
			objNew.ReportNo = obj.ReportNo;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.InitiallyProhibitedForNewLogins = obj.InitiallyProhibitedForNewLogins;
			objNew.DisplaySortOrder = obj.DisplaySortOrder;
			objNew.IsAllowed = obj.IsAllowed;
			objNew.ReportId = obj.ReportId;
			objNew.ReportName = obj.ReportName;
			objNew.ReportCategoryName = obj.ReportCategoryName;
			objNew.ReportCategoryGroupName = obj.ReportCategoryGroupName;
			objNew.SiteSectionName = obj.SiteSectionName;
            return objNew;
        }


		
		#endregion
		
	}
}