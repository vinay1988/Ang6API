/**********************************************************************************************
Marker     changed by      date         Remarks

[001]      Abhinav       02/09/20011   ESMS Ref:12 - Add new field "Company Registration No" 
[002]      Vinay           07/05/2012   This need to upload pdf document for company section
[003]      Vinay           03/07/2013   CR:- Supplier Invoice
[004]      Abhinav        02/17/2014   ESMS Ref:100 - Add new field to Compnay Form
[005]      Abhinav        02/21/2014   ESMS Ref: -  Add new field to Compnay Form  for Traceability required
[006]      Vinay          24/03/2014     ESMS Ref:106 -  Add new field(EARI Member and EARI Reported) to Compnay Form  
[008]      Vinay          13/05/2014     ESMS Ref:157 -  Need a provision to have a Review date for ‘Certification Status & Date field 
[009]      Shashi Keshar  21/01/2016     Need to add Insurance File No and Insured Amount 
[010]      Aashu          07/06/2018    Added supplier warranty field
* **********************************************************************************************/

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
	
	public class CompanyDetails {
		
		#region Constructors
		
		public CompanyDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// CompanyId (from Table)
		/// </summary>
		public System.Int32 CompanyId { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// CompanyName (from Table)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// DateCreated (from Table)
		/// </summary>
		public System.DateTime DateCreated { get; set; }
		/// <summary>
		/// CustomerCode (from Table)
		/// </summary>
		public System.String CustomerCode { get; set; }
		/// <summary>
		/// Salesman (from Table)
		/// </summary>
		public System.Int32? Salesman { get; set; }
		/// <summary>
		/// TeamNo (from Table)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// Telephone (from Table)
		/// </summary>
		public System.String Telephone { get; set; }
		/// <summary>
		/// Telephone800 (from Table)
		/// </summary>
		public System.String Telephone800 { get; set; }
		/// <summary>
		/// Fax (from Table)
		/// </summary>
		public System.String Fax { get; set; }
		/// <summary>
		/// RFax (from Table)
		/// </summary>
		public System.String RFax { get; set; }
		/// <summary>
		/// EMail (from Table)
		/// </summary>
		public System.String EMail { get; set; }
		/// <summary>
		/// URL (from Table)
		/// </summary>
		public System.String URL { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// Tax (from Table)
		/// </summary>
		public System.String Tax { get; set; }
		/// <summary>
		/// TypeNo (from Table)
		/// </summary>
		public System.Int32? TypeNo { get; set; }
		/// <summary>
		/// SOApproved (from Table)
		/// </summary>
		public System.Boolean? SOApproved { get; set; }
		/// <summary>
		/// SORating (from Table)
		/// </summary>
		public System.Int32? SORating { get; set; }
		/// <summary>
		/// SOTermsNo (from Table)
		/// </summary>
		public System.Int32? SOTermsNo { get; set; }
		/// <summary>
		/// SOCurrencyNo (from Table)
		/// </summary>
		public System.Int32? SOCurrencyNo { get; set; }
		/// <summary>
		/// SOTaxNo (from Table)
		/// </summary>
		public System.Int32? SOTaxNo { get; set; }
		/// <summary>
		/// DefaultSOContactNo (from Table)
		/// </summary>
		public System.Int32? DefaultSOContactNo { get; set; }
		/// <summary>
		/// DefaultSalesShipViaNo (from Table)
		/// </summary>
		public System.Int32? DefaultSalesShipViaNo { get; set; }
		/// <summary>
		/// DefaultSalesShipViaAccount (from Table)
		/// </summary>
		public System.String DefaultSalesShipViaAccount { get; set; }
		/// <summary>
		/// POApproved (from Table)
		/// </summary>
		public System.Boolean? POApproved { get; set; }
		/// <summary>
		/// PORating (from Table)
		/// </summary>
		public System.Int32? PORating { get; set; }
		/// <summary>
		/// POTermsNo (from Table)
		/// </summary>
		public System.Int32? POTermsNo { get; set; }
		/// <summary>
		/// POCurrencyNo (from Table)
		/// </summary>
		public System.Int32? POCurrencyNo { get; set; }
		/// <summary>
		/// POTaxNo (from Table)
		/// </summary>
		public System.Int32? POTaxNo { get; set; }
		/// <summary>
		/// DefaultPOContactNo (from Table)
		/// </summary>
		public System.Int32? DefaultPOContactNo { get; set; }
		/// <summary>
		/// DefaultPurchaseShipViaNo (from Table)
		/// </summary>
		public System.Int32? DefaultPurchaseShipViaNo { get; set; }
		/// <summary>
		/// DefaultPurchaseShipViaAccount (from Table)
		/// </summary>
		public System.String DefaultPurchaseShipViaAccount { get; set; }
		/// <summary>
		/// OnStop (from Table)
		/// </summary>
		public System.Boolean? OnStop { get; set; }
		/// <summary>
		/// CreditLimit (from Table)
		/// </summary>
		public System.Double? CreditLimit { get; set; }
		/// <summary>
		/// CurrentMonth (from Table)
		/// </summary>
		public System.Double? CurrentMonth { get; set; }
		/// <summary>
		/// Days30 (from Table)
		/// </summary>
		public System.Double? Days30 { get; set; }
		/// <summary>
		/// Days60 (from Table)
		/// </summary>
		public System.Double? Days60 { get; set; }
		/// <summary>
		/// Days90 (from Table)
		/// </summary>
		public System.Double? Days90 { get; set; }
		/// <summary>
		/// Days120 (from Table)
		/// </summary>
		public System.Double? Days120 { get; set; }
		/// <summary>
		/// ShippingCharge (from Table)
		/// </summary>
		public System.Boolean? ShippingCharge { get; set; }
		/// <summary>
		/// ExportData (from Table)
		/// </summary>
		public System.Boolean? ExportData { get; set; }
		/// <summary>
		/// ImportantNotes (from Table)
		/// </summary>
		public System.String ImportantNotes { get; set; }
		/// <summary>
		/// ParentCompanyNo (from Table)
		/// </summary>
		public System.Int32? ParentCompanyNo { get; set; }
		/// <summary>
		/// ManufacturerNo (from Table)
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }
		/// <summary>
		/// Inactive (from Table)
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// AutoImportDate (from Table)
		/// </summary>
		public System.DateTime? AutoImportDate { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// Balance (from Table)
		/// </summary>
		public System.Double? Balance { get; set; }
		/// <summary>
		/// FullName (from Table)
		/// </summary>
		public System.String FullName { get; set; }
		/// <summary>
		/// SupplierCode (from Table)
		/// </summary>
		public System.String SupplierCode { get; set; }
		/// <summary>
		/// CompanyType (from usp_datalistnugget_Company)
		/// </summary>
		public System.String CompanyType { get; set; }
		/// <summary>
		/// City (from usp_datalistnugget_Company)
		/// </summary>
		public System.String City { get; set; }
		/// <summary>
		/// Country (from usp_datalistnugget_Company)
		/// </summary>
		public System.String Country { get; set; }
		/// <summary>
		/// SalesmanName (from usp_datalistnugget_Company)
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// DaysSinceContact (from usp_datalistnugget_Company)
		/// </summary>
		public System.Int32? DaysSinceContact { get; set; }
		/// <summary>
		/// TermsName (from usp_datalistnugget_Company)
		/// </summary>
		public System.String TermsName { get; set; }
		/// <summary>
		/// RowNum (from usp_datalistnugget_Company)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_datalistnugget_Company)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// TeamName (from usp_select_Company)
		/// </summary>
		public System.String TeamName { get; set; }
		/// <summary>
		/// SOTermsName (from usp_select_Company)
		/// </summary>
		public System.String SOTermsName { get; set; }
		/// <summary>
		/// SOCurrencyCode (from usp_select_Company)
		/// </summary>
		public System.String SOCurrencyCode { get; set; }
		/// <summary>
		/// SOCurrencyDescription (from usp_select_Company)
		/// </summary>
		public System.String SOCurrencyDescription { get; set; }
		/// <summary>
		/// SOCurrencySymbol (from usp_select_Company)
		/// </summary>
		public System.String SOCurrencySymbol { get; set; }
		/// <summary>
		/// DefaultSOContactName (from usp_select_Company)
		/// </summary>
		public System.String DefaultSOContactName { get; set; }
		/// <summary>
		/// SOTaxName (from usp_select_Company)
		/// </summary>
		public System.String SOTaxName { get; set; }
		/// <summary>
		/// DefaultSalesShipViaName (from usp_select_Company)
		/// </summary>
		public System.String DefaultSalesShipViaName { get; set; }
		/// <summary>
		/// DefaultSalesShippingCost (from usp_select_Company)
		/// </summary>
		public System.Double DefaultSalesShippingCost { get; set; }
		/// <summary>
		/// DefaultSalesFreightCharge (from usp_select_Company)
		/// </summary>
		public System.Double DefaultSalesFreightCharge { get; set; }
		/// <summary>
		/// POTermsName (from usp_select_Company)
		/// </summary>
		public System.String POTermsName { get; set; }
		/// <summary>
		/// POCurrencyCode (from usp_select_Company)
		/// </summary>
		public System.String POCurrencyCode { get; set; }
		/// <summary>
		/// POCurrencyDescription (from usp_select_Company)
		/// </summary>
		public System.String POCurrencyDescription { get; set; }
		/// <summary>
		/// POCurrencySymbol (from usp_select_Company)
		/// </summary>
		public System.String POCurrencySymbol { get; set; }
		/// <summary>
		/// DefaultPOContactName (from usp_select_Company)
		/// </summary>
		public System.String DefaultPOContactName { get; set; }
		/// <summary>
		/// POTaxName (from usp_select_Company)
		/// </summary>
		public System.String POTaxName { get; set; }
		/// <summary>
		/// DefaultPurchaseShipViaName (from usp_select_Company)
		/// </summary>
		public System.String DefaultPurchaseShipViaName { get; set; }
		/// <summary>
		/// DefaultPurchaseShippingCost (from usp_select_Company)
		/// </summary>
		public System.Double DefaultPurchaseShippingCost { get; set; }
		/// <summary>
		/// DefaultPurchaseFreightCharge (from usp_select_Company)
		/// </summary>
		public System.Double DefaultPurchaseFreightCharge { get; set; }
		/// <summary>
		/// ParentCompanyName (from usp_select_Company)
		/// </summary>
		public System.String ParentCompanyName { get; set; }
		/// <summary>
		/// FirstContactNo (from usp_select_Company)
		/// </summary>
		public System.Int32? FirstContactNo { get; set; }
		/// <summary>
		/// ExchangeRate (from usp_select_Company_PurchaseInfo)
		/// </summary>
		public System.Double? ExchangeRate { get; set; }
		/// <summary>
		/// PurchaseOrderValueLastYear (from usp_summarise_Company_LastYear_PurchaseOrderValue)
		/// </summary>
		public System.Double? PurchaseOrderValueLastYear { get; set; }
		/// <summary>
		/// PurchaseOrderValueLastYearInBase (from usp_summarise_Company_LastYear_PurchaseOrderValue)
		/// </summary>
		public System.Double? PurchaseOrderValueLastYearInBase { get; set; }
		/// <summary>
		/// SalesOrderValueLastYear (from usp_summarise_Company_LastYear_SalesOrderValue)
		/// </summary>
		public System.Double? SalesOrderValueLastYear { get; set; }
		/// <summary>
		/// SalesOrderValueLastYearInBase (from usp_summarise_Company_LastYear_SalesOrderValue)
		/// </summary>
		public System.Double? SalesOrderValueLastYearInBase { get; set; }
		/// <summary>
		/// PurchaseOrderValueYTD (from usp_summarise_Company_ThisYear_PurchaseOrderValue)
		/// </summary>
		public System.Double? PurchaseOrderValueYTD { get; set; }
		/// <summary>
		/// PurchaseOrderValueYTDInBase (from usp_summarise_Company_ThisYear_PurchaseOrderValue)
		/// </summary>
		public System.Double? PurchaseOrderValueYTDInBase { get; set; }
		/// <summary>
		/// SalesOrderValueYTD (from usp_summarise_Company_ThisYear_SalesOrderValue)
		/// </summary>
		public System.Double? SalesOrderValueYTD { get; set; }
		/// <summary>
		/// SalesOrderValueYTDInBase (from usp_summarise_Company_ThisYear_SalesOrderValue)
		/// </summary>
		public System.Double? SalesOrderValueYTDInBase { get; set; }
        // [001] code start
        /// <summary>
        /// Company Registration No
        /// </summary>             
        /// (from usp_select_Company_MainInfo)
        public System.String CompanyRegNo { get; set; }
        // [001] code end
        /// <summary>
        /// Zip Code (from tbAddress)
        /// </summary>
        public System.String Zipcode { get; set; }

        // [002] code start
        /// <summary>
        /// IsPDFAvailable
        /// </summary>
        public System.Boolean? IsPDFAvailable { get; set; }
        // [002] code end
        public System.Int32 DivisionNo { get; set; }
        //[003] code start
        /// <summary>
        /// GlobalCurrencyNo
        /// </summary>
        public System.Int32 GlobalCurrencyNo { get; set; }
        /// <summary>
        /// GlobalCurrencyCode
        /// </summary>
        public System.String GlobalCurrencyCode { get; set; }
        //[003] code end
        //[004] code start
        /// certificateNotes
        /// </summary>
        public System.String certificateNotes { get; set; }

        /// qualityNotes
        /// </summary>
        public System.String qualityNotes { get; set; }
        //[004] code end

        //[005] code end
        /// IsTraceability
        /// </summary>
        public System.Boolean? IsTraceability { get; set; }
        //[005] code end\

        //[006] code start
        /// <summary>
        /// EARIMember
        /// </summary>
        public System.Boolean? ERAIMember { get; set; }
        /// <summary>
        /// EARIReported
        /// </summary>
        public System.Boolean? ERAIReported { get; set; }
        //[006] code end
        //[007] code start
        /// <summary>
        /// DefaultPOShipCountryNo
        /// </summary>
        public System.Int32? DefaultPOShipCountryNo { get; set; }
        /// <summary>
        /// DefaultPOShipCountry
        /// </summary>
        public System.String DefaultPOShipCountry { get; set; }
        //[007] code end

        //[008] code start
        /// <summary>
        /// ReviewDate
        /// </summary>
        public System.DateTime? ReviewDate { get; set; }
        //[008] code end

        /// <summary>
        /// Sales and Purhcage infromation approved (from Table)
        /// </summary>
        public System.DateTime? SOApprovedDate { get; set; }

        /// <summary>
        /// Sales and Purchage information approved By 
        /// </summary>
        public System.Int32? SOApprovedBy { get; set; }

        /// <summary>
        /// Sales and Purhcage infromation approved (from Table)
        /// </summary>
        public System.DateTime? POApprovedDate { get; set; }
        /// <summary>
        /// Sales and Purchage information approved By 
        /// </summary>
        public System.Int32? POApprovedBy { get; set; }
        /// <summary>
        /// SupplierOnStop
        /// </summary>
        public System.Boolean? SupplierOnStop { get; set; }

        //[009] Start Here

        /// <summary>
        /// Insurance File No  (from Table)
        /// </summary>
        public System.String InsuranceFileNo { get; set; }

        /// <summary>
        /// Insured Amount  (from Table)
        /// </summary>
        public System.Double? InsuredAmount { get; set; }
        //[009] End Here

        /// <summary>
        /// UPLiftPrice (from Table)
        /// </summary>
        public System.Double? UPLiftPrice { get; set; }
        /// <summary>
        /// IsTraceability
        /// </summary>
        public System.Boolean? IsPoHub { get; set; }
        public System.Int32? TaxByAddrssNo { get; set; }

        public System.String StopStatus { get; set; }
        public System.DateTime? LastReviewDate { get; set; }
        public System.DateTime? PreviousReviewDate { get; set; }

        public System.String NotesToInvoice { get; set; }

        public System.Double? SalesCost { get; set; }
        public System.Double? SalesResale { get; set; }
        public System.Double? SalesGrossProfit { get; set; }
        public System.Double? Margin { get; set; }
        public System.Double? ESTShippingCost { get; set; }
        public System.Int32? SalesAccountInDays { get; set; }
        /// <summary>
        /// SalesTurnover
        /// </summary>
        public System.Double? SalesTurnover { get; set; }
        public System.Boolean? NonPreferredCompany { get; set; }

        /// CreditLimit2 (from Table)
        /// </summary>
        public System.Double? ActualCreditLimit { get; set; }
        //[010] start
        /// <summary>
        /// SupplierWarranty
        /// </summary>
        public System.Int32? SupplierWarranty { get; set; }
        //[010] end
        /// <summary>
        /// Days1 (from Table)
        /// </summary>
        public System.Double? Days1 { get; set; }
		#endregion

	}
}
