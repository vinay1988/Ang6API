/**********************************************************************************************
Marker     changed by      date         Remarks
[001]      Abhinav       02/09/20011   ESMS Ref:12 - Add new field "Company Registration No" 
[002]      Vinay           07/05/2012   This need to upload pdf document for company section
[003]      Vinay           09/10/2012   Degete Ref:#26#  - Add two more columns contact to identify Default Purchase ledger and Default Sales ledger
[004]      Vinay           03/07/2013   CR:- Supplier Invoice
[005]      Abhinav        02/17/2014   ESMS Ref:100 - Add new field to Compnay Form
[006]      Abhinav        02/21/2014   ESMS Ref: -  Add new field to Compnay Form  for Traceability required
[007]      Vinay          24/03/2014     ESMS Ref:106 -  Add new field(EARI Member and EARI Reported) to Compnay Form 
[008]      Vinay          25/03/2014     ESMS Ref:107 -  Add provision to Default Shipping from Country 
[009]      Vinay          13/05/2014     ESMS Ref:157 -  Need a provision to have a Review date for ‘Certification Status & Date field 
[011]      Shashi Keshar  21/01/2016      Need to add Insurance File No and Insured Amount 
[0012]      Shashi Keshar  14/10/2016     Combobox  POApproveSuppliers 
[013]      Suhail          02/05/2018   Added Credit Limit2  
[014]      Aashu          06/06/2018    Added supplier warranty
[015]      Aashu          13-Sep-2018    [REB-12820]:Provision to add Global Security on Contact Section
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
using System.Collections.Generic;
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL
{
    public partial class Company : BizObject
    {

        #region Properties

        protected static DAL.CompanyElement Settings
        {
            get { return Globals.Settings.Companys; }
        }

        /// <summary>
        /// CompanyId
        /// </summary>
        public System.Int32 CompanyId { get; set; }
        /// <summary>
        /// ClientNo
        /// </summary>
        public System.Int32 ClientNo { get; set; }
        /// <summary>
        /// CompanyName
        /// </summary>
        public System.String CompanyName { get; set; }
        /// <summary>
        /// DateCreated
        /// </summary>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// CustomerCode
        /// </summary>
        public System.String CustomerCode { get; set; }
        /// <summary>
        /// Salesman
        /// </summary>
        public System.Int32? Salesman { get; set; }
        /// <summary>
        /// TeamNo
        /// </summary>
        public System.Int32? TeamNo { get; set; }
        /// <summary>
        /// Telephone
        /// </summary>
        public System.String Telephone { get; set; }
        /// <summary>
        /// Telephone800
        /// </summary>
        public System.String Telephone800 { get; set; }
        /// <summary>
        /// Fax
        /// </summary>
        public System.String Fax { get; set; }
        /// <summary>
        /// RFax
        /// </summary>
        public System.String RFax { get; set; }
        /// <summary>
        /// EMail
        /// </summary>
        public System.String EMail { get; set; }
        /// <summary>
        /// URL
        /// </summary>
        public System.String URL { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public System.String Notes { get; set; }
        /// <summary>
        /// Tax
        /// </summary>
        public System.String Tax { get; set; }
        /// <summary>
        /// TypeNo
        /// </summary>
        public System.Int32? TypeNo { get; set; }
        /// <summary>
        /// SOApproved
        /// </summary>
        public System.Boolean? SOApproved { get; set; }
        /// <summary>
        /// SORating
        /// </summary>
        public System.Int32? SORating { get; set; }
        /// <summary>
        /// SOTermsNo
        /// </summary>
        public System.Int32? SOTermsNo { get; set; }
        /// <summary>
        /// SOCurrencyNo
        /// </summary>
        public System.Int32? SOCurrencyNo { get; set; }
        /// <summary>
        /// SOTaxNo
        /// </summary>
        public System.Int32? SOTaxNo { get; set; }
        /// <summary>
        /// DefaultSOContactNo
        /// </summary>
        public System.Int32? DefaultSOContactNo { get; set; }
        /// <summary>
        /// DefaultSalesShipViaNo
        /// </summary>
        public System.Int32? DefaultSalesShipViaNo { get; set; }
        /// <summary>
        /// DefaultSalesShipViaAccount
        /// </summary>
        public System.String DefaultSalesShipViaAccount { get; set; }
        /// <summary>
        /// POApproved
        /// </summary>
        public System.Boolean? POApproved { get; set; }
        /// <summary>
        /// PORating
        /// </summary>
        public System.Int32? PORating { get; set; }
        /// <summary>
        /// POTermsNo
        /// </summary>
        public System.Int32? POTermsNo { get; set; }
        /// <summary>
        /// POCurrencyNo
        /// </summary>
        public System.Int32? POCurrencyNo { get; set; }
        /// <summary>
        /// POTaxNo
        /// </summary>
        public System.Int32? POTaxNo { get; set; }
        /// <summary>
        /// DefaultPOContactNo
        /// </summary>
        public System.Int32? DefaultPOContactNo { get; set; }
        /// <summary>
        /// DefaultPurchaseShipViaNo
        /// </summary>
        public System.Int32? DefaultPurchaseShipViaNo { get; set; }
        /// <summary>
        /// DefaultPurchaseShipViaAccount
        /// </summary>
        public System.String DefaultPurchaseShipViaAccount { get; set; }
        /// <summary>
        /// OnStop
        /// </summary>
        public System.Boolean? OnStop { get; set; }
        /// <summary>
        /// CreditLimit
        /// </summary>
        public System.Double? CreditLimit { get; set; }
        /// <summary>
        /// CurrentMonth
        /// </summary>
        public System.Double? CurrentMonth { get; set; }
        /// <summary>
        /// Days30
        /// </summary>
        public System.Double? Days30 { get; set; }
        /// <summary>
        /// Days60
        /// </summary>
        public System.Double? Days60 { get; set; }
        /// <summary>
        /// Days90
        /// </summary>
        public System.Double? Days90 { get; set; }
        /// <summary>
        /// Days120
        /// </summary>
        public System.Double? Days120 { get; set; }
        /// <summary>
        /// ShippingCharge
        /// </summary>
        public System.Boolean? ShippingCharge { get; set; }
        /// <summary>
        /// ExportData
        /// </summary>
        public System.Boolean? ExportData { get; set; }
        /// <summary>
        /// ImportantNotes
        /// </summary>
        public System.String ImportantNotes { get; set; }
        /// <summary>
        /// ParentCompanyNo
        /// </summary>
        public System.Int32? ParentCompanyNo { get; set; }
        /// <summary>
        /// ManufacturerNo
        /// </summary>
        public System.Int32? ManufacturerNo { get; set; }
        /// <summary>
        /// Inactive
        /// </summary>
        public System.Boolean Inactive { get; set; }
        /// <summary>
        /// AutoImportDate
        /// </summary>
        public System.DateTime? AutoImportDate { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// Balance
        /// </summary>
        public System.Double? Balance { get; set; }
        /// <summary>
        /// FullName
        /// </summary>
        public System.String FullName { get; set; }
        /// <summary>
        /// SupplierCode
        /// </summary>
        public System.String SupplierCode { get; set; }
        /// <summary>
        /// CompanyType
        /// </summary>
        public System.String CompanyType { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public System.String City { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        public System.String Country { get; set; }
        /// <summary>
        /// SalesmanName
        /// </summary>
        public System.String SalesmanName { get; set; }
        /// <summary>
        /// DaysSinceContact
        /// </summary>
        public System.Int32? DaysSinceContact { get; set; }
        /// <summary>
        /// TermsName
        /// </summary>
        public System.String TermsName { get; set; }
        /// <summary>
        /// RowNum
        /// </summary>
        public System.Int64? RowNum { get; set; }
        /// <summary>
        /// RowCnt
        /// </summary>
        public System.Int32? RowCnt { get; set; }
        /// <summary>
        /// TeamName
        /// </summary>
        public System.String TeamName { get; set; }
        /// <summary>
        /// SOTermsName
        /// </summary>
        public System.String SOTermsName { get; set; }
        /// <summary>
        /// SOCurrencyCode
        /// </summary>
        public System.String SOCurrencyCode { get; set; }
        /// <summary>
        /// SOCurrencyDescription
        /// </summary>
        public System.String SOCurrencyDescription { get; set; }
        /// <summary>
        /// SOCurrencySymbol
        /// </summary>
        public System.String SOCurrencySymbol { get; set; }
        /// <summary>
        /// DefaultSOContactName
        /// </summary>
        public System.String DefaultSOContactName { get; set; }
        /// <summary>
        /// SOTaxName
        /// </summary>
        public System.String SOTaxName { get; set; }
        /// <summary>
        /// DefaultSalesShipViaName
        /// </summary>
        public System.String DefaultSalesShipViaName { get; set; }
        /// <summary>
        /// DefaultSalesShippingCost
        /// </summary>
        public System.Double DefaultSalesShippingCost { get; set; }
        /// <summary>
        /// DefaultSalesFreightCharge
        /// </summary>
        public System.Double DefaultSalesFreightCharge { get; set; }
        /// <summary>
        /// POTermsName
        /// </summary>
        public System.String POTermsName { get; set; }
        /// <summary>
        /// POCurrencyCode
        /// </summary>
        public System.String POCurrencyCode { get; set; }
        /// <summary>
        /// POCurrencyDescription
        /// </summary>
        public System.String POCurrencyDescription { get; set; }
        /// <summary>
        /// POCurrencySymbol
        /// </summary>
        public System.String POCurrencySymbol { get; set; }
        /// <summary>
        /// DefaultPOContactName
        /// </summary>
        public System.String DefaultPOContactName { get; set; }
        /// <summary>
        /// POTaxName
        /// </summary>
        public System.String POTaxName { get; set; }
        /// <summary>
        /// DefaultPurchaseShipViaName
        /// </summary>
        public System.String DefaultPurchaseShipViaName { get; set; }
        /// <summary>
        /// DefaultPurchaseShippingCost
        /// </summary>
        public System.Double DefaultPurchaseShippingCost { get; set; }
        /// <summary>
        /// DefaultPurchaseFreightCharge
        /// </summary>
        public System.Double DefaultPurchaseFreightCharge { get; set; }
        /// <summary>
        /// ParentCompanyName
        /// </summary>
        public System.String ParentCompanyName { get; set; }
        /// <summary>
        /// FirstContactNo
        /// </summary>
        public System.Int32? FirstContactNo { get; set; }
        /// <summary>
        /// ExchangeRate
        /// </summary>
        public System.Double? ExchangeRate { get; set; }
        /// <summary>
        /// PurchaseOrderValueLastYear
        /// </summary>
        public System.Double? PurchaseOrderValueLastYear { get; set; }
        /// <summary>
        /// PurchaseOrderValueLastYearInBase
        /// </summary>
        public System.Double? PurchaseOrderValueLastYearInBase { get; set; }
        /// <summary>
        /// SalesOrderValueLastYear
        /// </summary>
        public System.Double? SalesOrderValueLastYear { get; set; }
        /// <summary>
        /// SalesOrderValueLastYearInBase
        /// </summary>
        public System.Double? SalesOrderValueLastYearInBase { get; set; }
        /// <summary>
        /// PurchaseOrderValueYTD
        /// </summary>
        public System.Double? PurchaseOrderValueYTD { get; set; }
        /// <summary>
        /// PurchaseOrderValueYTDInBase
        /// </summary>
        public System.Double? PurchaseOrderValueYTDInBase { get; set; }
        /// <summary>
        /// SalesOrderValueYTD
        /// </summary>
        public System.Double? SalesOrderValueYTD { get; set; }
        /// <summary>
        /// SalesOrderValueYTDInBase
        /// </summary>
        public System.Double? SalesOrderValueYTDInBase { get; set; }
        //[001] code start
        /// <summary>
        /// Company Registration No
        /// </summary>                    
        public System.String CompanyRegNo { get; set; }
        //[001] code end
        /// <summary>
        /// Address ID
        /// </summary>
        public System.Int32 intAddressID { get; set; }

        // [002] code start
        /// <summary>
        /// IsPDFAvailable
        /// </summary>
        public System.Boolean? IsPDFAvailable { get; set; }
        // [002] code end
        public System.Int32 DivisionNo { get; set; }
        //[004] code start
        /// <summary>
        /// GlobalCurrencyNo
        /// </summary>
        public System.Int32 GlobalCurrencyNo { get; set; }
        /// <summary>
        /// GlobalCurrencyCode
        /// </summary>
        public System.String GlobalCurrencyCode { get; set; }
        //[004] code end
        //[005] code start
        /// certificateNotes
        /// </summary>
        public System.String certificateNotes { get; set; }

        /// qualityNotes
        /// </summary>
        public System.String qualityNotes { get; set; }
        //[006] code end
        /// IsTraceability
        /// </summary>
        public System.Boolean? IsTraceability { get; set; }
        //[006] code end

        //[007] code start
        /// <summary>
        /// EARIMember
        /// </summary>
        public System.Boolean? ERAIMember { get; set; }
        /// <summary>
        /// EARIReported
        /// </summary>
        public System.Boolean? ERAIReported { get; set; }
        //[008] code start
        /// <summary>
        /// DefaultPOShipCountryNo
        /// </summary>
        public System.Int32? DefaultPOShipCountryNo { get; set; }
        /// <summary>
        /// DefaultPOShipCountry
        /// </summary>
        public System.String DefaultPOShipCountry { get; set; }
        //[008] code end

        //[009] code start
        /// <summary>
        /// ReviewDate
        /// </summary>
        public System.DateTime? ReviewDate { get; set; }
        //[009] code end

        //[010] Code start
        /// <summary>
        /// Sales and Purhcage infromation approved (from Table)
        /// </summary>
        public System.DateTime? SOApprovedDate { get; set; }
        /// <summary>
        /// Sales and Purchage information approved By 
        /// </summary>
        public System.Int32? SOApprovedBy { get; set; }

        public System.DateTime? POApprovedDate { get; set; }

        public System.Int32? POApprovedBy { get; set; }
        //[010] Code End
        /// <summary>
        /// SupplierOnStop
        /// </summary>
        public System.Boolean? SupplierOnStop { get; set; }
        /// <summary>
        /// UPLiftPrice
        /// </summary>
        public System.Double? UPLiftPrice { get; set; }
        ///<summary>
        /// IsPoHub
        /// </summary>
        public System.Boolean? IsPoHub { get; set; }
        public System.Int32? TaxByAddrssNo { get; set; }
        public System.String StopStatus { get; set; }
        //[011] Code start
        /// <summary>
        /// CompanyName
        /// </summary>
        public System.String InsuranceFileNo { get; set; }
        /// <summary>
        /// CreditLimit
        /// </summary>
        public System.Double? InsuredAmount { get; set; }

        //[011] Code End

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
        //[014] start
        /// <summary>
        /// SupplierWarranty
        /// </summary>
        public System.Int32? SupplierWarranty { get; set; }
        //[014] end
        /// <summary>
        /// Days1 (from Table)
        /// </summary>
        public System.Double? Days1 { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// AutoSearch
        /// Calls [usp_autosearch_Company]
        /// </summary>
        public static List<Company> AutoSearch(System.Int32? clientId, System.String nameSearch)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.AutoSearch(clientId, nameSearch);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyId = objDetails.CompanyId;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.FullName = objDetails.FullName;
                   // obj.EMail = objDetails.EMail;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// AutoSearch
        /// Calls [usp_autosearch_SaleCompany]
        /// </summary>
        public static List<Company> AutoSearchSale(System.Int32? clientId, System.String nameSearch)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.AutoSearchSale(clientId, nameSearch);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyId = objDetails.CompanyId;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.FullName = objDetails.FullName;
                    // obj.EMail = objDetails.EMail;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// AutoSearchForCustomers
        /// Calls [usp_autosearch_Company_for_Customers]
        /// </summary>
        public static List<Company> AutoSearchForCustomers(System.Int32? clientId, System.String nameSearch)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.AutoSearchForCustomers(clientId, nameSearch);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyId = objDetails.CompanyId;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.FullName = objDetails.FullName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// AutoSearchForProspects
        /// Calls [usp_autosearch_Company_for_Prospects]
        /// </summary>
        public static List<Company> AutoSearchForProspects(System.Int32? clientId, System.String nameSearch)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.AutoSearchForProspects(clientId, nameSearch);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyId = objDetails.CompanyId;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.FullName = objDetails.FullName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// AutoSearchForSuppliers
        /// Calls [usp_autosearch_Company_for_Suppliers]
        /// </summary>
        public static List<Company> AutoSearchForSuppliers(System.Int32? clientId, System.String nameSearch)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.AutoSearchForSuppliers(clientId, nameSearch);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyId = objDetails.CompanyId;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.FullName = objDetails.FullName;
                    obj.EMail = objDetails.EMail;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        //[012] Start Here
        /// <summary>
        /// AutoSearchForPOApproveSuppliers
        /// Calls [usp_autosearch_Company_for_POApproveSuppliers]
        /// </summary>
        public static List<Company> AutoSearchForPOApproveSuppliers(System.Int32? clientId, System.String nameSearch)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.AutoSearchForPOApproveSuppliers(clientId, nameSearch);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyId = objDetails.CompanyId;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.FullName = objDetails.FullName;
                    obj.EMail = objDetails.EMail;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        //[012] End Here
        /// <summary>
        /// AutoSearchForAllSuppliers
        /// Calls [usp_autosearch_Company_for_AllSuppliers]
        /// </summary>
        public static List<Company> AutoSearchForAllSuppliers(System.Int32? clientId, System.String nameSearch)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.AutoSearchForAllSuppliers(clientId, nameSearch);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyId = objDetails.CompanyId;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.FullName = objDetails.FullName;
                    obj.EMail = objDetails.EMail;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// CountAsCustomersByClient
        /// Calls [usp_count_Company_as_Customers_by_Client]
        /// </summary>
        public static Int32 CountAsCustomersByClient(System.Int32? clientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.CountAsCustomersByClient(clientId);
        }		/// <summary>
        /// CountAsProspectsByClient
        /// Calls [usp_count_Company_as_Prospects_by_Client]
        /// </summary>
        public static Int32 CountAsProspectsByClient(System.Int32? clientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.CountAsProspectsByClient(clientId);
        }		/// <summary>
        /// CountAsSuppliersByClient
        /// Calls [usp_count_Company_as_Suppliers_by_Client]
        /// </summary>
        public static Int32 CountAsSuppliersByClient(System.Int32? clientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.CountAsSuppliersByClient(clientId);
        }		/// <summary>
        /// CountByClient
        /// Calls [usp_count_Company_by_Client]
        /// </summary>
        public static Int32 CountByClient(System.Int32? clientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.CountByClient(clientId);
        }		/// <summary>
        /// DataListNugget
        /// Calls [usp_datalistnugget_Company]
        /// </summary>
        public static List<Company> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.String typeSearch, System.String citySearch, System.String countrySearch, System.Int32? salesmanSearch, System.Int32? customerRatingLo, System.Int32? customerRatingHi, System.Int32? supplierRatingLo, System.Int32? supplierRatingHi, System.String customerCode, System.String telNo, System.String Zipcode)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.DataListNugget(clientId, teamId, divisionId, loginId, orderBy, sortDir, pageIndex, pageSize, nameSearch, typeSearch, citySearch, countrySearch, salesmanSearch, customerRatingLo, customerRatingHi, supplierRatingLo, supplierRatingHi, customerCode, telNo, Zipcode);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyId = objDetails.CompanyId;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.Telephone = objDetails.Telephone;
                    obj.CompanyType = objDetails.CompanyType;
                    obj.City = objDetails.City;
                    obj.Country = objDetails.Country;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DaysSinceContact = objDetails.DaysSinceContact;
                    obj.OnStop = objDetails.OnStop;
                    obj.TermsName = objDetails.TermsName;
                    obj.CustomerCode = objDetails.CustomerCode;
                    obj.SupplierCode = objDetails.SupplierCode;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.SalesGrossProfit = objDetails.SalesGrossProfit;
                    obj.SalesTurnover = objDetails.SalesTurnover;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// DataListNuggetAsCustomers
        /// Calls [usp_datalistnugget_Company_as_Customers]
        /// </summary>
        public static List<Company> DataListNuggetAsCustomers(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.String typeSearch, System.String citySearch, System.String countrySearch, System.Int32? salesmanSearch, System.Int32? customerRatingLo, System.Int32? customerRatingHi, System.Int32? supplierRatingLo, System.Int32? supplierRatingHi, System.String customerCode, System.String telNo, System.String Zipcode)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.DataListNuggetAsCustomers(clientId, teamId, divisionId, loginId, orderBy, sortDir, pageIndex, pageSize, nameSearch, typeSearch, citySearch, countrySearch, salesmanSearch, customerRatingLo, customerRatingHi, supplierRatingLo, supplierRatingHi, customerCode, telNo, Zipcode);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyId = objDetails.CompanyId;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.Telephone = objDetails.Telephone;
                    obj.CompanyType = objDetails.CompanyType;
                    obj.City = objDetails.City;
                    obj.Country = objDetails.Country;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DaysSinceContact = objDetails.DaysSinceContact;
                    obj.OnStop = objDetails.OnStop;
                    obj.TermsName = objDetails.TermsName;
                    obj.CustomerCode = objDetails.CustomerCode;
                    obj.SupplierCode = objDetails.SupplierCode;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.SalesGrossProfit = objDetails.SalesGrossProfit;
                    obj.SalesTurnover = objDetails.SalesTurnover;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// DataListNuggetAsProspects
        /// Calls [usp_datalistnugget_Company_as_Prospects]
        /// </summary>
        public static List<Company> DataListNuggetAsProspects(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.String typeSearch, System.String citySearch, System.String countrySearch, System.Int32? salesmanSearch, System.Int32? customerRatingLo, System.Int32? customerRatingHi, System.Int32? supplierRatingLo, System.Int32? supplierRatingHi, System.String customerCode, System.String telNo, System.String Zipcode)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.DataListNuggetAsProspects(clientId, teamId, divisionId, loginId, orderBy, sortDir, pageIndex, pageSize, nameSearch, typeSearch, citySearch, countrySearch, salesmanSearch, customerRatingLo, customerRatingHi, supplierRatingLo, supplierRatingHi, customerCode, telNo, Zipcode);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyId = objDetails.CompanyId;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.Telephone = objDetails.Telephone;
                    obj.CompanyType = objDetails.CompanyType;
                    obj.City = objDetails.City;
                    obj.Country = objDetails.Country;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DaysSinceContact = objDetails.DaysSinceContact;
                    obj.OnStop = objDetails.OnStop;
                    obj.TermsName = objDetails.TermsName;
                    obj.CustomerCode = objDetails.CustomerCode;
                    obj.SupplierCode = objDetails.SupplierCode;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.SalesGrossProfit = objDetails.SalesGrossProfit;
                    obj.SalesTurnover = objDetails.SalesTurnover;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// DataListNuggetAsSuppliers
        /// Calls [usp_datalistnugget_Company_as_Suppliers]
        /// </summary>
        public static List<Company> DataListNuggetAsSuppliers(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.String typeSearch, System.String citySearch, System.String countrySearch, System.Int32? salesmanSearch, System.Int32? customerRatingLo, System.Int32? customerRatingHi, System.Int32? supplierRatingLo, System.Int32? supplierRatingHi, System.String customerCode, System.String telNo, System.String Zipcode)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.DataListNuggetAsSuppliers(clientId, teamId, divisionId, loginId, orderBy, sortDir, pageIndex, pageSize, nameSearch, typeSearch, citySearch, countrySearch, salesmanSearch, customerRatingLo, customerRatingHi, supplierRatingLo, supplierRatingHi, customerCode, telNo, Zipcode);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyId = objDetails.CompanyId;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.Telephone = objDetails.Telephone;
                    obj.CompanyType = objDetails.CompanyType;
                    obj.City = objDetails.City;
                    obj.Country = objDetails.Country;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DaysSinceContact = objDetails.DaysSinceContact;
                    obj.OnStop = objDetails.OnStop;
                    obj.TermsName = objDetails.TermsName;
                    obj.CustomerCode = objDetails.CustomerCode;
                    obj.SupplierCode = objDetails.SupplierCode;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.SalesGrossProfit = objDetails.SalesGrossProfit;
                    obj.SalesTurnover = objDetails.SalesTurnover;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Delete
        /// Calls [usp_delete_Company]
        /// </summary>
        public static bool Delete(System.Int32? companyId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.Delete(companyId);
        }
        /// <summary>
        /// DropDownForClient
        /// Calls [usp_dropdown_Company_for_Client]
        /// </summary>
        public static List<Company> DropDownForClient(System.Int32? clientId)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.DropDownForClient(clientId);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyId = objDetails.CompanyId;
                    obj.CompanyName = objDetails.CompanyName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        public static List<Company> DropDownForClientNPR(System.Int32? goodsinLineNo)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.DropDownForClientNPR(goodsinLineNo);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyId = objDetails.CompanyId;
                    obj.CompanyName = objDetails.CompanyName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Insert
        /// Calls [usp_insert_Company]
        /// </summary>
        /// [001],[005] code start
        /// 
        public static Int32 Insert(System.Int32? clientNo, System.String companyName, System.DateTime? dateCreated, System.String customerCode, System.Int32? salesman, System.Int32? teamNo, System.String telephone, System.String telephone800, System.String fax, System.String rfax, System.String email, System.String url, System.String notes, System.String tax, System.Int32? typeNo, System.Int32? manufacturerNo, System.Boolean? soApproved, System.Int32? soRating, System.Int32? soTermsNo, System.Int32? soCurrencyNo, System.Int32? soTaxNo, System.Int32? defaultSoContactNo, System.Int32? defaultSalesShipViaNo, System.String defaultSalesShipViaAccount, System.Boolean? poApproved, System.Int32? poRating, System.Int32? poTermsNo, System.Int32? poCurrencyNo, System.Int32? poTaxNo, System.Int32? defaultPoContactNo, System.Int32? defaultPurchaseShipViaNo, System.String defaultPurchaseShipViaAccount, System.Boolean? onStop, System.Double? creditLimit, System.Double? currentMonth, System.Double? days30, System.Double? days60, System.Double? days90, System.Double? days120, System.Boolean? shippingCharge, System.Boolean? exportData, System.String importantNotes, System.Int32? parentCompanyNo, System.Int32? updatedBy, System.String CompanyRegNo, System.String certificateNotes, System.String qualityNotes)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Company.Insert(clientNo, companyName, dateCreated, customerCode, salesman, teamNo, telephone, telephone800, fax, rfax, email, url, notes, tax, typeNo, manufacturerNo, soApproved, soRating, soTermsNo, soCurrencyNo, soTaxNo, defaultSoContactNo, defaultSalesShipViaNo, defaultSalesShipViaAccount, poApproved, poRating, poTermsNo, poCurrencyNo, poTaxNo, defaultPoContactNo, defaultPurchaseShipViaNo, defaultPurchaseShipViaAccount, onStop, creditLimit, currentMonth, days30, days60, days90, days120, shippingCharge, exportData, importantNotes, parentCompanyNo, updatedBy, CompanyRegNo, certificateNotes,qualityNotes);
            return objReturn;
        }
        /// [001],[005] code end
        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_Company]
        /// </summary>
        public Int32 Insert()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.Insert(ClientNo, CompanyName, DateCreated, CustomerCode, Salesman, TeamNo, Telephone, Telephone800, Fax, RFax, EMail, URL, Notes, Tax, TypeNo, ManufacturerNo, SOApproved, SORating, SOTermsNo, SOCurrencyNo, SOTaxNo, DefaultSOContactNo, DefaultSalesShipViaNo, DefaultSalesShipViaAccount, POApproved, PORating, POTermsNo, POCurrencyNo, POTaxNo, DefaultPOContactNo, DefaultPurchaseShipViaNo, DefaultPurchaseShipViaAccount, OnStop, CreditLimit, CurrentMonth, Days30, Days60, Days90, Days120, ShippingCharge, ExportData, ImportantNotes, ParentCompanyNo, UpdatedBy);
        }
        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_Company]
        /// </summary>
        public static List<Company> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.Boolean? poApproved, System.Boolean? soApproved, System.Boolean? includeOnStop, System.Boolean? excludeSupplierOnStop,System.Int32? poNoLo,System.Int32? poNoHi)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, nameSearch, poApproved, soApproved, includeOnStop, excludeSupplierOnStop, poNoLo, poNoHi);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyId = objDetails.CompanyId;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.CompanyType = objDetails.CompanyType;
                    obj.City = objDetails.City;
                    obj.Country = objDetails.Country;
                    obj.Telephone = objDetails.Telephone;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DaysSinceContact = objDetails.DaysSinceContact;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    //[004] code start
                    obj.SupplierCode = objDetails.SupplierCode;
                    //[004] code end
                    obj.IsTraceability = objDetails.IsTraceability;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Get
        /// Calls [usp_select_Company]
        /// </summary>
        public static Company Get(System.Int32? companyId)
        {
            Rebound.GlobalTrader.DAL.CompanyDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.Get(companyId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Company obj = new Company();
                obj.CompanyId = objDetails.CompanyId;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyName = objDetails.CompanyName;
                obj.CustomerCode = objDetails.CustomerCode;
                obj.DateCreated = objDetails.DateCreated;
                obj.Salesman = objDetails.Salesman;
                obj.SalesmanName = objDetails.SalesmanName;
                obj.TeamNo = objDetails.TeamNo;
                obj.TeamName = objDetails.TeamName;
                obj.Telephone = objDetails.Telephone;
                obj.Telephone800 = objDetails.Telephone800;
                obj.Fax = objDetails.Fax;
                obj.RFax = objDetails.RFax;
                obj.EMail = objDetails.EMail;
                obj.URL = objDetails.URL;
                obj.Notes = objDetails.Notes;
                obj.Tax = objDetails.Tax;
                obj.TypeNo = objDetails.TypeNo;
                obj.CompanyType = objDetails.CompanyType;
                obj.ManufacturerNo = objDetails.ManufacturerNo;
                obj.SOApproved = objDetails.SOApproved;
                obj.SORating = objDetails.SORating;
                obj.SOTermsNo = objDetails.SOTermsNo;
                obj.SOTermsName = objDetails.SOTermsName;
                obj.SOCurrencyNo = objDetails.SOCurrencyNo;
                obj.SOCurrencyCode = objDetails.SOCurrencyCode;
                obj.SOCurrencyDescription = objDetails.SOCurrencyDescription;
                obj.SOCurrencySymbol = objDetails.SOCurrencySymbol;
                obj.DefaultSOContactNo = objDetails.DefaultSOContactNo;
                obj.DefaultSOContactName = objDetails.DefaultSOContactName;
                obj.SOTaxNo = objDetails.SOTaxNo;
                obj.SOTaxName = objDetails.SOTaxName;
                obj.DefaultSalesShipViaNo = objDetails.DefaultSalesShipViaNo;
                obj.DefaultSalesShipViaName = objDetails.DefaultSalesShipViaName;
                obj.DefaultSalesShippingCost = objDetails.DefaultSalesShippingCost;
                obj.DefaultSalesFreightCharge = objDetails.DefaultSalesFreightCharge;
                obj.DefaultSalesShipViaAccount = objDetails.DefaultSalesShipViaAccount;
                obj.POApproved = objDetails.POApproved;
                obj.PORating = objDetails.PORating;
                obj.POTermsNo = objDetails.POTermsNo;
                obj.POTermsName = objDetails.POTermsName;
                obj.POCurrencyNo = objDetails.POCurrencyNo;
                obj.POCurrencyCode = objDetails.POCurrencyCode;
                obj.POCurrencyDescription = objDetails.POCurrencyDescription;
                obj.POCurrencySymbol = objDetails.POCurrencySymbol;
                obj.DefaultPOContactNo = objDetails.DefaultPOContactNo;
                obj.DefaultPOContactName = objDetails.DefaultPOContactName;
                obj.POTaxNo = objDetails.POTaxNo;
                obj.POTaxName = objDetails.POTaxName;
                obj.DefaultPurchaseShipViaNo = objDetails.DefaultPurchaseShipViaNo;
                obj.DefaultPurchaseShipViaName = objDetails.DefaultPurchaseShipViaName;
                obj.DefaultPurchaseShippingCost = objDetails.DefaultPurchaseShippingCost;
                obj.DefaultPurchaseFreightCharge = objDetails.DefaultPurchaseFreightCharge;
                obj.DefaultPurchaseShipViaAccount = objDetails.DefaultPurchaseShipViaAccount;
                obj.OnStop = objDetails.OnStop;
                obj.CreditLimit = objDetails.CreditLimit;
                obj.CurrentMonth = objDetails.CurrentMonth;
                obj.Days30 = objDetails.Days30;
                obj.Days60 = objDetails.Days60;
                obj.Days90 = objDetails.Days90;
                obj.Days120 = objDetails.Days120;
                obj.ShippingCharge = objDetails.ShippingCharge;
                obj.ExportData = objDetails.ExportData;
                obj.Balance = objDetails.Balance;
                obj.ImportantNotes = objDetails.ImportantNotes;
                obj.ParentCompanyNo = objDetails.ParentCompanyNo;
                obj.ParentCompanyName = objDetails.ParentCompanyName;
                obj.Inactive = objDetails.Inactive;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.FirstContactNo = objDetails.FirstContactNo;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetDefaultPurchasingInfo
        /// Calls [usp_select_Company_DefaultPurchasingInfo]
        /// </summary>
        public static Company GetDefaultPurchasingInfo(System.Int32? companyId)
        {
            Rebound.GlobalTrader.DAL.CompanyDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.GetDefaultPurchasingInfo(companyId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Company obj = new Company();
                obj.CompanyId = objDetails.CompanyId;
                obj.DefaultPurchaseShipViaNo = objDetails.DefaultPurchaseShipViaNo;
                obj.DefaultPurchaseShipViaName = objDetails.DefaultPurchaseShipViaName;
                obj.DefaultPurchaseShippingCost = objDetails.DefaultPurchaseShippingCost;
                obj.DefaultPurchaseFreightCharge = objDetails.DefaultPurchaseFreightCharge;
                obj.DefaultPurchaseShipViaAccount = objDetails.DefaultPurchaseShipViaAccount;
                obj.POCurrencyNo = objDetails.POCurrencyNo;
                obj.POCurrencyCode = objDetails.POCurrencyCode;
                obj.POCurrencyDescription = objDetails.POCurrencyDescription;
                obj.POTaxNo = objDetails.POTaxNo;
                obj.POTaxName = objDetails.POTaxName;
                obj.POTermsNo = objDetails.POTermsNo;
                obj.POTermsName = objDetails.POTermsName;
                obj.DefaultPOContactNo = objDetails.DefaultPOContactNo;
                obj.DefaultPOContactName = objDetails.DefaultPOContactName;
                obj.GlobalCurrencyNo = objDetails.GlobalCurrencyNo;
                obj.UPLiftPrice = objDetails.UPLiftPrice;
                obj.ESTShippingCost = objDetails.ESTShippingCost;
                //[014] start
                obj.NonPreferredCompany = objDetails.NonPreferredCompany;
                obj.SupplierWarranty = objDetails.SupplierWarranty;
                //[014] end
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetDefaultSalesInfo
        /// Calls [usp_select_Company_DefaultSalesInfo]
        /// </summary>
        public static Company GetDefaultSalesInfo(System.Int32? companyId)
        {
            Rebound.GlobalTrader.DAL.CompanyDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.GetDefaultSalesInfo(companyId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Company obj = new Company();
                obj.CompanyId = objDetails.CompanyId;
                obj.DefaultSalesShipViaNo = objDetails.DefaultSalesShipViaNo;
                obj.DefaultSalesShipViaName = objDetails.DefaultSalesShipViaName;
                obj.DefaultSalesShippingCost = objDetails.DefaultSalesShippingCost;
                obj.DefaultSalesFreightCharge = objDetails.DefaultSalesFreightCharge;
                obj.DefaultSalesShipViaAccount = objDetails.DefaultSalesShipViaAccount;
                obj.SOCurrencyNo = objDetails.SOCurrencyNo;
                obj.SOCurrencyCode = objDetails.SOCurrencyCode;
                obj.SOCurrencyDescription = objDetails.SOCurrencyDescription;
                obj.SOTaxNo = objDetails.SOTaxNo;
                obj.SOTaxName = objDetails.SOTaxName;
                obj.SOTermsNo = objDetails.SOTermsNo;
                obj.SOTermsName = objDetails.SOTermsName;
                obj.DefaultSOContactNo = objDetails.DefaultSOContactNo;
                obj.DefaultSOContactName = objDetails.DefaultSOContactName;
                obj.ShippingCharge = objDetails.ShippingCharge;
                obj.IsTraceability = objDetails.IsTraceability;
                obj.GlobalCurrencyNo = objDetails.GlobalCurrencyNo;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForPage
        /// Calls [usp_select_Company_for_Page]
        /// </summary>
        public static Company GetForPage(System.Int32? companyId)
        {
            Rebound.GlobalTrader.DAL.CompanyDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.GetForPage(companyId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Company obj = new Company();
                obj.CompanyId = objDetails.CompanyId;
                obj.Inactive = objDetails.Inactive;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyName = objDetails.CompanyName;
                obj.POApproved = objDetails.POApproved;
                obj.SOApproved = objDetails.SOApproved;
                obj.OnStop = objDetails.OnStop;
                obj.ParentCompanyNo = objDetails.ParentCompanyNo;
                obj.ParentCompanyName = objDetails.ParentCompanyName;
                obj.SORating = objDetails.SORating;
                obj.PORating = objDetails.PORating;
                obj.CompanyType = objDetails.CompanyType;
                obj.ImportantNotes = objDetails.ImportantNotes;
                // [002] code start
                obj.IsPDFAvailable = objDetails.IsPDFAvailable;
                // [002] code end
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.Salesman = objDetails.Salesman;
                obj.InsuranceFileNo = objDetails.InsuranceFileNo;
                obj.InsuredAmount = objDetails.InsuredAmount;
                obj.StopStatus = objDetails.StopStatus;
                obj.IsPoHub = objDetails.IsPoHub;
                obj.NonPreferredCompany = objDetails.NonPreferredCompany;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetMainInfo
        /// Calls [usp_select_Company_MainInfo]
        /// </summary>
        public static Company GetMainInfo(System.Int32? companyId) {
			Rebound.GlobalTrader.DAL.CompanyDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.GetMainInfo(companyId);
			if (objDetails == null) {
				return null;
			} else {
				Company obj = new Company();
				obj.CompanyId = objDetails.CompanyId;
				obj.CompanyName = objDetails.CompanyName;
				obj.ParentCompanyNo = objDetails.ParentCompanyNo;
				obj.ParentCompanyName = objDetails.ParentCompanyName;
				obj.Telephone = objDetails.Telephone;
				obj.Telephone800 = objDetails.Telephone800;
				obj.Fax = objDetails.Fax;
				obj.EMail = objDetails.EMail;
				obj.URL = objDetails.URL;
				obj.TypeNo = objDetails.TypeNo;
				obj.CompanyType = objDetails.CompanyType;
				obj.Tax = objDetails.Tax;
                // [001] code start
                obj.CompanyRegNo = objDetails.CompanyRegNo;
                // [001] code end
				obj.Notes = objDetails.Notes;
				obj.ImportantNotes = objDetails.ImportantNotes;
				obj.OnStop = objDetails.OnStop;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.Salesman = objDetails.Salesman;
				obj.SalesmanName = objDetails.SalesmanName;
                // [005] code start
                obj.certificateNotes = objDetails.certificateNotes;
                obj.qualityNotes = objDetails.qualityNotes;
                // [005] code start
                // [006] code start
                obj.IsTraceability = objDetails.IsTraceability;
                // [006] code end

                //[007] code start
                obj.ERAIMember = objDetails.ERAIMember;
                obj.ERAIReported = objDetails.ERAIReported;
                //[007] code end;
                
                //[009] code start
                obj.ReviewDate = objDetails.ReviewDate;
                //[009] code end
                obj.UPLiftPrice = objDetails.UPLiftPrice;
                obj.IsPoHub = objDetails.IsPoHub;

                obj.LastReviewDate = objDetails.LastReviewDate;
                obj.PreviousReviewDate = objDetails.PreviousReviewDate;
                obj.SalesAccountInDays = objDetails.SalesAccountInDays;

                //[014] start
                obj.SupplierWarranty = objDetails.SupplierWarranty;
                //[014] end
                //[015] start
                obj.ClientNo = objDetails.ClientNo;
                //[015] end
				objDetails = null;
				return obj;
			}
		}
        /// <summary>
        /// GetPurchaseInfo
        /// Calls [usp_select_Company_PurchaseInfo]
        /// </summary>
        public static Company GetPurchaseInfo(System.Int32? companyId)
        {
            Rebound.GlobalTrader.DAL.CompanyDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.GetPurchaseInfo(companyId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Company obj = new Company();
                obj.CompanyId = objDetails.CompanyId;
                obj.POApproved = objDetails.POApproved;
                obj.SupplierCode = objDetails.SupplierCode;
                obj.POCurrencyNo = objDetails.POCurrencyNo;
                obj.POCurrencyCode = objDetails.POCurrencyCode;
                obj.POCurrencyDescription = objDetails.POCurrencyDescription;
                obj.DefaultPOContactNo = objDetails.DefaultPOContactNo;
                obj.DefaultPOContactName = objDetails.DefaultPOContactName;
                obj.POTermsNo = objDetails.POTermsNo;
                obj.POTermsName = objDetails.POTermsName;
                obj.POTaxNo = objDetails.POTaxNo;
                obj.POTaxName = objDetails.POTaxName;
                obj.DefaultPurchaseShipViaNo = objDetails.DefaultPurchaseShipViaNo;
                obj.DefaultPurchaseShipViaName = objDetails.DefaultPurchaseShipViaName;
                obj.DefaultPurchaseFreightCharge = objDetails.DefaultPurchaseFreightCharge;
                obj.DefaultPurchaseShippingCost = objDetails.DefaultPurchaseShippingCost;
                obj.DefaultPurchaseShipViaAccount = objDetails.DefaultPurchaseShipViaAccount;
                obj.PORating = objDetails.PORating;
                obj.DLUP = objDetails.DLUP;
                obj.ExchangeRate = objDetails.ExchangeRate;
                //[004] code start
                obj.GlobalCurrencyNo = objDetails.GlobalCurrencyNo;
                obj.GlobalCurrencyCode = objDetails.GlobalCurrencyCode;
                //[004] code end
                obj.ERAIReported = objDetails.ERAIReported;
                //[008] code start
                obj.DefaultPOShipCountryNo = objDetails.DefaultPOShipCountryNo;
                obj.DefaultPOShipCountry = objDetails.DefaultPOShipCountry;
                //[008] code end
                obj.CompanyName = objDetails.CompanyName;
                //[009] code start
                obj.POApprovedBy = objDetails.POApprovedBy;
                obj.POApprovedDate = objDetails.POApprovedDate;
                //[009] code end
                obj.SupplierOnStop = objDetails.SupplierOnStop;
                obj.TaxByAddrssNo = objDetails.TaxByAddrssNo;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetSalesInfo
        /// Calls [usp_select_Company_SalesInfo]
        /// </summary>
        public static Company GetSalesInfo(System.Int32? companyId)
        {
            Rebound.GlobalTrader.DAL.CompanyDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.GetSalesInfo(companyId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Company obj = new Company();
                obj.CompanyId = objDetails.CompanyId;
                obj.Salesman = objDetails.Salesman;
                obj.SalesmanName = objDetails.SalesmanName;
                obj.SOApproved = objDetails.SOApproved;
                obj.SOCurrencyNo = objDetails.SOCurrencyNo;
                obj.SOCurrencyCode = objDetails.SOCurrencyCode;
                obj.SOCurrencyDescription = objDetails.SOCurrencyDescription;
                obj.CustomerCode = objDetails.CustomerCode;
                obj.SORating = objDetails.SORating;
                obj.OnStop = objDetails.OnStop;
                obj.SOTaxNo = objDetails.SOTaxNo;
                obj.SOTaxName = objDetails.SOTaxName;
                obj.SOTermsNo = objDetails.SOTermsNo;
                obj.SOTermsName = objDetails.SOTermsName;
                obj.ShippingCharge = objDetails.ShippingCharge;
                obj.DefaultSalesShipViaNo = objDetails.DefaultSalesShipViaNo;
                obj.DefaultSalesShipViaName = objDetails.DefaultSalesShipViaName;
                obj.DefaultSalesShippingCost = objDetails.DefaultSalesShippingCost;
                obj.DefaultSalesFreightCharge = objDetails.DefaultSalesFreightCharge;
                obj.DefaultSalesShipViaAccount = objDetails.DefaultSalesShipViaAccount;
                obj.CreditLimit = objDetails.CreditLimit;
                obj.CurrentMonth = objDetails.CurrentMonth;
                obj.Balance = objDetails.Balance;
                obj.Days30 = objDetails.Days30;
                obj.Days60 = objDetails.Days60;
                obj.Days90 = objDetails.Days90;
                obj.Days120 = objDetails.Days120;
                obj.DefaultSOContactNo = objDetails.DefaultSOContactNo;
                obj.DefaultSOContactName = objDetails.DefaultSOContactName;
                obj.DLUP = objDetails.DLUP;
                obj.ExchangeRate = objDetails.ExchangeRate;
                obj.CompanyName = objDetails.CompanyName;

                obj.SOApprovedBy = objDetails.SOApprovedBy;
                obj.SOApprovedDate = objDetails.SOApprovedDate;
                obj.IsTraceability = objDetails.IsTraceability;
                //[011] Start Here
                obj.InsuranceFileNo = objDetails.InsuranceFileNo;
                obj.InsuredAmount = objDetails.InsuredAmount;
                //[011] End Here
                obj.StopStatus = objDetails.StopStatus;
                obj.GlobalCurrencyNo = objDetails.GlobalCurrencyNo;
                obj.NotesToInvoice = objDetails.NotesToInvoice;
               // [013] Code Start
                obj.ActualCreditLimit = objDetails.ActualCreditLimit;
                //[013] Code End
                obj.Days1 = objDetails.Days1;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetListByManufacturer
        /// Calls [usp_selectAll_Company_by_Manufacturer]
        /// </summary>
        public static List<Company> GetListByManufacturer(System.Int32? manufacturerNo)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.GetListByManufacturer(manufacturerNo);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyId = objDetails.CompanyId;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.DateCreated = objDetails.DateCreated;
                    obj.CustomerCode = objDetails.CustomerCode;
                    obj.Salesman = objDetails.Salesman;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.Telephone = objDetails.Telephone;
                    obj.Telephone800 = objDetails.Telephone800;
                    obj.Fax = objDetails.Fax;
                    obj.RFax = objDetails.RFax;
                    obj.EMail = objDetails.EMail;
                    obj.URL = objDetails.URL;
                    obj.Notes = objDetails.Notes;
                    obj.Tax = objDetails.Tax;
                    obj.TypeNo = objDetails.TypeNo;
                    obj.SOApproved = objDetails.SOApproved;
                    obj.SORating = objDetails.SORating;
                    obj.SOTermsNo = objDetails.SOTermsNo;
                    obj.SOCurrencyNo = objDetails.SOCurrencyNo;
                    obj.SOTaxNo = objDetails.SOTaxNo;
                    obj.DefaultSOContactNo = objDetails.DefaultSOContactNo;
                    obj.DefaultSalesShipViaNo = objDetails.DefaultSalesShipViaNo;
                    obj.DefaultSalesShipViaAccount = objDetails.DefaultSalesShipViaAccount;
                    obj.POApproved = objDetails.POApproved;
                    obj.PORating = objDetails.PORating;
                    obj.POTermsNo = objDetails.POTermsNo;
                    obj.POCurrencyNo = objDetails.POCurrencyNo;
                    obj.POTaxNo = objDetails.POTaxNo;
                    obj.DefaultPOContactNo = objDetails.DefaultPOContactNo;
                    obj.DefaultPurchaseShipViaNo = objDetails.DefaultPurchaseShipViaNo;
                    obj.DefaultPurchaseShipViaAccount = objDetails.DefaultPurchaseShipViaAccount;
                    obj.OnStop = objDetails.OnStop;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.CurrentMonth = objDetails.CurrentMonth;
                    obj.Days30 = objDetails.Days30;
                    obj.Days60 = objDetails.Days60;
                    obj.Days90 = objDetails.Days90;
                    obj.Days120 = objDetails.Days120;
                    obj.ShippingCharge = objDetails.ShippingCharge;
                    obj.ExportData = objDetails.ExportData;
                    obj.ImportantNotes = objDetails.ImportantNotes;
                    obj.ParentCompanyNo = objDetails.ParentCompanyNo;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.Inactive = objDetails.Inactive;
                    obj.AutoImportDate = objDetails.AutoImportDate;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.Balance = objDetails.Balance;
                    obj.FullName = objDetails.FullName;
                    obj.SupplierCode = objDetails.SupplierCode;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListOnstopForClient
        /// Calls [usp_selectAll_Company_onstop_for_Client]
        /// </summary>
        public static List<Company> GetListOnstopForClient(System.Int32? clientId, System.Int32? topToSelect)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.GetListOnstopForClient(clientId, topToSelect);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyName = objDetails.CompanyName;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Balance = objDetails.Balance;
                    obj.Salesman = objDetails.Salesman;
                    obj.CompanyId = objDetails.CompanyId;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListOnstopForLogin
        /// Calls [usp_selectAll_Company_onstop_for_Login]
        /// </summary>
        public static List<Company> GetListOnstopForLogin(System.Int32? loginId, System.Int32? topToSelect)
        {
            List<CompanyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.GetListOnstopForLogin(loginId, topToSelect);
            if (lstDetails == null)
            {
                return new List<Company>();
            }
            else
            {
                List<Company> lst = new List<Company>();
                foreach (CompanyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Company obj = new Rebound.GlobalTrader.BLL.Company();
                    obj.CompanyName = objDetails.CompanyName;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Balance = objDetails.Balance;
                    obj.Salesman = objDetails.Salesman;
                    obj.CompanyId = objDetails.CompanyId;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// SummariseLastYearPurchaseOrderValue
        /// Calls [usp_summarise_Company_LastYear_PurchaseOrderValue]
        /// </summary>
        public static Company SummariseLastYearPurchaseOrderValue(System.Int32? companyId)
        {
            Rebound.GlobalTrader.DAL.CompanyDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.SummariseLastYearPurchaseOrderValue(companyId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Company obj = new Company();
                obj.PurchaseOrderValueLastYear = objDetails.PurchaseOrderValueLastYear;
                obj.PurchaseOrderValueLastYearInBase = objDetails.PurchaseOrderValueLastYearInBase;
                obj.POCurrencyCode = objDetails.POCurrencyCode;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// SummariseLastYearSalesOrderValue
        /// Calls [usp_summarise_Company_LastYear_SalesOrderValue]
        /// </summary>
        public static Company SummariseLastYearSalesOrderValue(System.Int32? companyId)
        {
            Rebound.GlobalTrader.DAL.CompanyDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.SummariseLastYearSalesOrderValue(companyId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Company obj = new Company();
                obj.SalesOrderValueLastYear = objDetails.SalesOrderValueLastYear;
                obj.SalesOrderValueLastYearInBase = objDetails.SalesOrderValueLastYearInBase;
                obj.SOCurrencyCode = objDetails.SOCurrencyCode;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// SummariseThisYearPurchaseOrderValue
        /// Calls [usp_summarise_Company_ThisYear_PurchaseOrderValue]
        /// </summary>
        public static Company SummariseThisYearPurchaseOrderValue(System.Int32? companyId)
        {
            Rebound.GlobalTrader.DAL.CompanyDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.SummariseThisYearPurchaseOrderValue(companyId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Company obj = new Company();
                obj.PurchaseOrderValueYTD = objDetails.PurchaseOrderValueYTD;
                obj.PurchaseOrderValueYTDInBase = objDetails.PurchaseOrderValueYTDInBase;
                obj.POCurrencyCode = objDetails.POCurrencyCode;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// SummariseThisYearSalesOrderValue
        /// Calls [usp_summarise_Company_ThisYear_SalesOrderValue]
        /// </summary>
        public static Company SummariseThisYearSalesOrderValue(System.Int32? companyId)
        {
            Rebound.GlobalTrader.DAL.CompanyDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.SummariseThisYearSalesOrderValue(companyId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Company obj = new Company();
                obj.SalesOrderValueYTD = objDetails.SalesOrderValueYTD;
                obj.SalesOrderValueYTDInBase = objDetails.SalesOrderValueYTDInBase;
                obj.SOCurrencyCode = objDetails.SOCurrencyCode;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// UpdateDefaultPOContact
        /// Calls [usp_update_Company_DefaultPOContact]
        /// </summary>
        public static bool UpdateDefaultPOContact(System.Int32? companyId, System.Int32? defaultPoContactNo, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.UpdateDefaultPOContact(companyId, defaultPoContactNo, updatedBy);
        }
        //[003] code start
        /// <summary>
        /// UpdateDefaultPOLedgerContact
        /// Calls [usp_update_Company_DefaultPOLedgerContact]
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="defaultPoContactNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public static bool UpdateDefaultPOLedgerContact(System.Int32? companyId, System.Int32? defaultPoContactNo, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.UpdateDefaultPOLedgerContact(companyId, defaultPoContactNo, updatedBy);
        }
        /// <summary>
        /// UpdateDefaultSOLedgerContact
        /// Calls [usp_update_Company_DefaultSOLedgerContact]
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="defaultSoContactNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public static bool UpdateDefaultSOLedgerContact(System.Int32? companyId, System.Int32? defaultSoContactNo, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.UpdateDefaultSOLedgerContact(companyId, defaultSoContactNo, updatedBy);
        }
        //[003] code end
        /// <summary>
        /// UpdateDefaultSOContact
        /// Calls [usp_update_Company_DefaultSOContact]
        /// </summary>
        public static bool UpdateDefaultSOContact(System.Int32? companyId, System.Int32? defaultSoContactNo, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.UpdateDefaultSOContact(companyId, defaultSoContactNo, updatedBy);
        }
        /// <summary>
        /// UpdateMainInfo
        /// Calls [usp_update_Company_MainInfo]
        /// </summary>
        //[005],[006],[007],[014] start
        public static bool UpdateMainInfo(System.Int32? companyId, System.String companyName, System.Int32? parentCompanyNo, System.Int32? salesman, System.String telephone, System.String telephone800, System.String fax, System.String email, System.String url, System.Int32? typeNo, System.String tax, System.String notes, System.String importantNotes, System.Int32? updatedBy, System.String CompanyRegNo, System.String certificateNotes, System.String qualityNotes, System.Boolean IsTraceability, System.Boolean? eraiMember, System.Boolean? eraiReported, System.DateTime? reviewDate, System.Double? upLiftPrice, System.Int32? SupplierWarranty)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.UpdateMainInfo(companyId, companyName, parentCompanyNo, salesman, telephone, telephone800, fax, email, url, typeNo, tax, notes, importantNotes, updatedBy, CompanyRegNo, certificateNotes, qualityNotes, IsTraceability, eraiMember, eraiReported, reviewDate, upLiftPrice, SupplierWarranty);
        }
        //[005],[006],[007] end
        /// <summary>
        /// UpdateManufacturerNo
        /// Calls [usp_update_Company_ManufacturerNo]
        /// </summary>
        public static bool UpdateManufacturerNo(System.Int32? companyId, System.Int32? manufacturerNo, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.UpdateManufacturerNo(companyId, manufacturerNo, updatedBy);
        }
        //[008] code start
        /// <summary>
        /// UpdatePurchaseInfo
        /// Calls [usp_update_Company_PurchaseInfo]
        /// </summary>
        public static bool UpdatePurchaseInfo(System.Int32? companyId, System.String supplierCode, System.Boolean? poApproved, System.Int32? poRating, System.Int32? poTermsNo, System.Int32? poCurrencyNo, System.Int32? poTaxNo, System.Int32? defaultPoContactNo, System.String defaultPurchaseShipViaAccount, System.Int32? defaultPurchaseShipViaNo, System.Int32? updatedBy,System.Int32? defaultPOShipCountryNo,System.Boolean? onSupplierStop)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.UpdatePurchaseInfo(companyId, supplierCode, poApproved, poRating, poTermsNo, poCurrencyNo, poTaxNo, defaultPoContactNo, defaultPurchaseShipViaAccount, defaultPurchaseShipViaNo, updatedBy, defaultPOShipCountryNo,onSupplierStop);
        }
        //[008] code end
        /// <summary>
        /// UpdateSalesInfo
        /// Calls [usp_update_Company_SalesInfo]
        /// </summary>
        public static bool UpdateSalesInfo(System.Int32? companyId, System.String customerCode, System.Int32? salesman, System.Boolean? soApproved, System.Int32? soRating, System.Int32? soTermsNo, System.Int32? soCurrencyNo, System.Int32? soTaxNo, System.Int32? defaultSoContactNo, System.Int32? defaultSalesShipViaNo, System.String defaultSalesShipViaAccount, System.Boolean? onStop, System.Boolean? shippingCharge, System.Double? creditLimit, System.String insuranceFileNo, System.Double? insuredAmount, System.Int32? updatedBy, System.String StopStatus, System.String NotesToInvoice, System.Double? actualCreditLimit)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.UpdateSalesInfo(companyId, customerCode, salesman, soApproved, soRating, soTermsNo, soCurrencyNo, soTaxNo, defaultSoContactNo, defaultSalesShipViaNo, defaultSalesShipViaAccount, onStop, shippingCharge, creditLimit, insuranceFileNo, insuredAmount, updatedBy, StopStatus, NotesToInvoice, actualCreditLimit);
        }
        /// <summary>
        /// UpdateTransferAccounts
        /// Calls [usp_update_Company_TransferAccounts]
        /// </summary>
        public static bool UpdateTransferAccounts(System.Int32? oldLoginNo, System.Int32? newLoginNo, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.UpdateTransferAccounts(oldLoginNo, newLoginNo, updatedBy);
        }

        private static Company PopulateFromDBDetailsObject(CompanyDetails obj)
        {
            Company objNew = new Company();
            objNew.CompanyId = obj.CompanyId;
            objNew.ClientNo = obj.ClientNo;
            objNew.CompanyName = obj.CompanyName;
            objNew.DateCreated = obj.DateCreated;
            objNew.CustomerCode = obj.CustomerCode;
            objNew.Salesman = obj.Salesman;
            objNew.TeamNo = obj.TeamNo;
            objNew.Telephone = obj.Telephone;
            objNew.Telephone800 = obj.Telephone800;
            objNew.Fax = obj.Fax;
            objNew.RFax = obj.RFax;
            objNew.EMail = obj.EMail;
            objNew.URL = obj.URL;
            objNew.Notes = obj.Notes;
            objNew.Tax = obj.Tax;
            objNew.TypeNo = obj.TypeNo;
            objNew.SOApproved = obj.SOApproved;
            objNew.SORating = obj.SORating;
            objNew.SOTermsNo = obj.SOTermsNo;
            objNew.SOCurrencyNo = obj.SOCurrencyNo;
            objNew.SOTaxNo = obj.SOTaxNo;
            objNew.DefaultSOContactNo = obj.DefaultSOContactNo;
            objNew.DefaultSalesShipViaNo = obj.DefaultSalesShipViaNo;
            objNew.DefaultSalesShipViaAccount = obj.DefaultSalesShipViaAccount;
            objNew.POApproved = obj.POApproved;
            objNew.PORating = obj.PORating;
            objNew.POTermsNo = obj.POTermsNo;
            objNew.POCurrencyNo = obj.POCurrencyNo;
            objNew.POTaxNo = obj.POTaxNo;
            objNew.DefaultPOContactNo = obj.DefaultPOContactNo;
            objNew.DefaultPurchaseShipViaNo = obj.DefaultPurchaseShipViaNo;
            objNew.DefaultPurchaseShipViaAccount = obj.DefaultPurchaseShipViaAccount;
            objNew.OnStop = obj.OnStop;
            objNew.CreditLimit = obj.CreditLimit;
            objNew.CurrentMonth = obj.CurrentMonth;
            objNew.Days30 = obj.Days30;
            objNew.Days60 = obj.Days60;
            objNew.Days90 = obj.Days90;
            objNew.Days120 = obj.Days120;
            objNew.ShippingCharge = obj.ShippingCharge;
            objNew.ExportData = obj.ExportData;
            objNew.ImportantNotes = obj.ImportantNotes;
            objNew.ParentCompanyNo = obj.ParentCompanyNo;
            objNew.ManufacturerNo = obj.ManufacturerNo;
            objNew.Inactive = obj.Inactive;
            objNew.AutoImportDate = obj.AutoImportDate;
            objNew.UpdatedBy = obj.UpdatedBy;
            objNew.DLUP = obj.DLUP;
            objNew.Balance = obj.Balance;
            objNew.FullName = obj.FullName;
            objNew.SupplierCode = obj.SupplierCode;
            objNew.CompanyType = obj.CompanyType;
            objNew.City = obj.City;
            objNew.Country = obj.Country;
            objNew.SalesmanName = obj.SalesmanName;
            objNew.DaysSinceContact = obj.DaysSinceContact;
            objNew.TermsName = obj.TermsName;
            objNew.RowNum = obj.RowNum;
            objNew.RowCnt = obj.RowCnt;
            objNew.TeamName = obj.TeamName;
            objNew.SOTermsName = obj.SOTermsName;
            objNew.SOCurrencyCode = obj.SOCurrencyCode;
            objNew.SOCurrencyDescription = obj.SOCurrencyDescription;
            objNew.SOCurrencySymbol = obj.SOCurrencySymbol;
            objNew.DefaultSOContactName = obj.DefaultSOContactName;
            objNew.SOTaxName = obj.SOTaxName;
            objNew.DefaultSalesShipViaName = obj.DefaultSalesShipViaName;
            objNew.DefaultSalesShippingCost = obj.DefaultSalesShippingCost;
            objNew.DefaultSalesFreightCharge = obj.DefaultSalesFreightCharge;
            objNew.POTermsName = obj.POTermsName;
            objNew.POCurrencyCode = obj.POCurrencyCode;
            objNew.POCurrencyDescription = obj.POCurrencyDescription;
            objNew.POCurrencySymbol = obj.POCurrencySymbol;
            objNew.DefaultPOContactName = obj.DefaultPOContactName;
            objNew.POTaxName = obj.POTaxName;
            objNew.DefaultPurchaseShipViaName = obj.DefaultPurchaseShipViaName;
            objNew.DefaultPurchaseShippingCost = obj.DefaultPurchaseShippingCost;
            objNew.DefaultPurchaseFreightCharge = obj.DefaultPurchaseFreightCharge;
            objNew.ParentCompanyName = obj.ParentCompanyName;
            objNew.FirstContactNo = obj.FirstContactNo;
            objNew.ExchangeRate = obj.ExchangeRate;
            objNew.PurchaseOrderValueLastYear = obj.PurchaseOrderValueLastYear;
            objNew.PurchaseOrderValueLastYearInBase = obj.PurchaseOrderValueLastYearInBase;
            objNew.SalesOrderValueLastYear = obj.SalesOrderValueLastYear;
            objNew.SalesOrderValueLastYearInBase = obj.SalesOrderValueLastYearInBase;
            objNew.PurchaseOrderValueYTD = obj.PurchaseOrderValueYTD;
            objNew.PurchaseOrderValueYTDInBase = obj.PurchaseOrderValueYTDInBase;
            objNew.SalesOrderValueYTD = obj.SalesOrderValueYTD;
            objNew.SalesOrderValueYTDInBase = obj.SalesOrderValueYTDInBase;
            return objNew;
        }

        // [002] code start
        /// <summary>
        /// GetPDFListForCompany
        /// Calls [usp_selectAll_PDF_for_Company]
        /// </summary>
        public static List<PDFDocument> GetPDFListForCompany(System.Int32? CompanyId)
        {
            List<PDFDocumentDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.GetPDFListForCompany(CompanyId);
            if (lstDetails == null)
            {
                return new List<PDFDocument>();
            }
            else
            {
                List<PDFDocument> lst = new List<PDFDocument>();
                foreach (PDFDocumentDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.PDFDocument obj = new Rebound.GlobalTrader.BLL.PDFDocument();
                    obj.PDFDocumentId = objDetails.PDFDocumentId;
                    obj.PDFDocumentRefNo = objDetails.PDFDocumentRefNo;
                    obj.Caption = objDetails.Caption;
                    obj.FileName = objDetails.FileName;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Insert
        /// Calls [usp_insert_CompanyPDF]
        /// </summary>
        public static Int32 Insert(System.Int32? CompanyId, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Company.Insert(CompanyId, Caption, FileName, UpdatedBy);
            return objReturn;
        }
        /// Delete
        /// Calls [usp_delete_CompanyPDF]
        /// </summary>
        public static bool DeleteCompanyPDF(System.Int32? CompanyPdfId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Company.DeleteCompanyPDF(CompanyPdfId);
        }


        /// <summary>
        /// SummariseThisYearandLastYearSalesValue
        /// Calls [usp_summarise_Company_ThisYear_LastYear_SalesValue]
        /// </summary>
        public static Company SummariseThisYearandLastYearSalesValue(System.Int32? companyId,System.Boolean? blnThisYear)
        {
            Rebound.GlobalTrader.DAL.CompanyDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Company.SummariseThisYearandLastYearSalesValue(companyId, blnThisYear);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Company obj = new Company();
                obj.SalesCost = objDetails.SalesCost;
                obj.SalesResale = objDetails.SalesResale;
                obj.SalesGrossProfit = objDetails.SalesGrossProfit;
                obj.Margin = objDetails.Margin;
                objDetails = null;
                return obj;
            }
        }
        #endregion

    }
}
