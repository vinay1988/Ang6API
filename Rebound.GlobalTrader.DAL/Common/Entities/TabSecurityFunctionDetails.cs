using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL
{
   public class TabSecurityFunctionDetails
    {
       #region Constructors

       public TabSecurityFunctionDetails() { }
		
		#endregion
       #region Properties

   
       /// <summary>
       /// TabSecurityFunctionId
       /// </summary>
       public System.Int32 TabSecurityFunctionId { get; set; }
       /// <summary>
       /// TabFunctionName
       /// </summary>
       public System.String TabFunctionName { get; set; }
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
       /// MyTab
       /// </summary>
       public System.Boolean? MyTab { get; set; }
       /// <summary>
       /// TeamTab
       /// </summary>
       public System.Boolean? TeamTab { get; set; }
       /// <summary>
       /// DivisionTab
       /// </summary>
       public System.Boolean? DivisionTab { get; set; }
       /// <summary>
       /// CompanyTab
       /// </summary>
       public System.Boolean? CompanyTab { get; set; }
       /// <summary>
       /// SiteSectionName
       /// </summary>
       public System.String SiteSectionName { get; set; }
       /// <summary>
       /// SecurityGroupNo
       /// </summary>
       public System.Int32? SecurityGroupNo { get; set; }
       /// <summary>
       /// TabSecurityGroupSecurityFunctionPermissionId
       /// </summary>
       public System.Int32 TabSecurityGroupSecurityFunctionPermissionId { get; set; }

       #endregion
		
    }
}
