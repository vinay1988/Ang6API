//Marker     changed by      date         Remarks
//[001]      Aashu          12/06/2018    Added supplier warranty field
//[002]      Umendra Gupta  30/08/2018    Add ClientCode and ReceivedBy field
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Rebound.GlobalTrader.DAL {

    public class BOMDetails
    {

        #region Constructors

        public BOMDetails() { }

        #endregion

        #region Properties

        /// <summary>
        /// BOMId (from Table)
        /// </summary>
        public System.Int32 BOMId { get; set; }
        /// <summary>
        /// ClientNo (from Table)
        /// </summary>
        public System.Int32 ClientNo { get; set; }
        /// <summary>
        /// BOMName (from usp_select_GoodsInLine)
        /// </summary>
        public System.String BOMName { get; set; }
        /// <summary>
        /// Cost (from usp_selectAll_Login_Top_Salespersons)
        /// </summary>
        //public System.Double? Cost { get; set; }
        /// <summary>
        /// CurrencyNo (from usp_selectAll_Allocation_for_CustomerRMALine)
        /// </summary>
        //public System.Int32? CurrencyNo { get; set; }
        /// <summary>
        /// OnHold (from Table)
        /// </summary>
        //public System.Boolean OnHold { get; set; }
        /// <summary>
        /// Consignment (from Table)
        /// </summary>
        //public System.Boolean Consignment { get; set; }
        /// <summary>
        /// Notes (from usp_select_Address_DefaultBilling_for_Company)
        /// </summary>
        public System.String Notes { get; set; }
        /// <summary>
        /// BOMCode (from Table)
        /// </summary>
        public System.String BOMCode { get; set; }
        /// <summary>
        /// Inactive (from Table)
        /// </summary>
        public System.Boolean Inactive { get; set; }
        /// <summary>
        /// UpdatedBy (from Table)
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP (from Table)
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// CurrencyCode (from usp_list_Activity_by_Client_with_filter)
        /// </summary>
        //public System.String CurrencyCode { get; set; }
        /// <summary>
        /// StockCount (from usp_datalistnugget_Lot)
        /// </summary>
        //public System.Int32? StockCount { get; set; }
        /// <summary>
        /// RowNum (from usp_list_Activity_by_Client_with_filter)
        /// </summary>
        public System.Int64? RowNum { get; set; }
        /// <summary>
        /// RowCnt (from usp_list_Activity_by_Client_with_filter)
        /// </summary>
        public System.Int32? RowCnt { get; set; }
        /// <summary> 
        /// Company No
        /// </summary>
        public System.Int32? CompanyNo { get; set; }
        /// <summary>
        ///CompanyName
        ///</summary>
        public System.String CompanyName { get; set; }

        /// <summary> 
        /// Contact No
        /// </summary>
        public System.Int32? ContactNo { get; set; }
        /// <summary>
        ///ContactName
        ///</summary>
        public System.String ContactName { get; set; }
        /// <summary>
        ///BOM Status
        ///</summary>
        public System.String BOMStatus { get; set; }
        public System.Int32? UpdateRequirement { get; set; }
        public System.Int32? RequestToPOHubBy { get; set; }
        public System.DateTime? DateRequestToPOHub { get; set; }
        public System.Int32? ReleaseBy { get; set; }
        public System.DateTime? DateRelease { get; set; }
        public System.Int32? BomCount { get; set; }
        public System.String CurrencyCode { get; set; }
        public int? StatusValue { get; set; }
        public System.Int32? CurrencyNo { get; set; }
        public System.String Currency_Code { get; set; }
        public string ClientName { get; set; }
        public string CurrentSupplier { get; set; }
        public System.DateTime? QuoteRequired { get; set; }
        public string UpdatedByList { get; set; }
        public double TotalBomLinePrice { get; set; }
        public int POCurrencyNo { get; set; }
        public System.Int32? AllItemHasSourcing { get; set; }
        public System.Boolean? AS9120 { get; set; }
        public string Releasedby { get; set; }
        public string Requestedby { get; set; }
        public string AssignedUser { get; set; }
        public int NoBidCount { get; set; }
        public System.String DivisionName { get; set; }

        public System.Int32? UpdateByPH { get; set; }
        public System.String ValidationMessage { get; set; }
        public System.Boolean IsReqInValid { get; set; }
        public System.Int32? Contact2Id { get; set; }
        public System.String Contact2Name { get; set; }
        /// <summary>
        ///SupplierWarranty
        ///</summary>
        public System.Int32? SupplierWarranty { get; set; }
        public System.String ClientCode { get; set; }//[002]
        public System.String ReceivedBy { get; set; }//[002]
        public System.String SalesmanName { get; set; }
       #endregion

    }
}
