/*
Marker     Changed by      Date         Remarks
[001]      Vinay           18/06/2012   This need to implement the NPR Report
[002]      Vinay           10/07/2012   This need for Rebound- Invoice bulk Emailer
[003]      Vinay           18/12/2012   Add Stock Info nuggets
[004]      Vinay           04/02/2014   CR:- Add AS9120 Requirement in GT application
[005]      Suhail          12/04/2018    changes MSL text to drop down list
[005]      Abhinav        06/04/2018   [REB-10310]: CHG-146739: Built in function to notifi users when GT is updated when they login
 *  
*/
using System;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;



// 30 January 2008 17:03
namespace Rebound.GlobalTrader.DAL {

    #region Main Class

    public class GlobalTraderDALSection : ConfigurationSection {

        [ConfigurationProperty("defaultConnectionStringName", DefaultValue = "LocalSqlServer")]
        public string DefaultConnectionStringName {
            get { return (string)base["defaultConnectionStringName"]; }
            set { base["defaultConnectionStringName"] = value; }
        }

        [ConfigurationProperty("mediaConnectionStringName", DefaultValue = "MediaSqlServer")]
        public string MediaConnectionStringName {
            get { return (string)base["mediaConnectionStringName"]; }
            set { base["mediaConnectionStringName"] = value; }
        }

        [ConfigurationProperty("GTConnectionStringName", DefaultValue = "GTSqlServer")]
        public string GTConnectionStringName
        {
            get { return (string)base["GTConnectionStringName"]; }
            set { base["GTConnectionStringName"] = value; }
        }

        [ConfigurationProperty("databaseSettings")]
        public DatabaseSettingsElement DatabaseSettings {
            get { return (DatabaseSettingsElement)base["databaseSettings"]; }
        }

        [ConfigurationProperty("defaultCacheDuration", DefaultValue = "900")]
        public int DefaultCacheDuration {
            get { return (int)base["defaultCacheDuration"]; }
            set { base["defaultCacheDuration"] = value; }
        }

        [ConfigurationProperty("activity", IsRequired = true)]
        public ActivityElement Activitys {
            get { return (ActivityElement)base["activity"]; }
        }

        [ConfigurationProperty("address", IsRequired = true)]
        public AddressElement Addresss {
            get { return (AddressElement)base["address"]; }
        }

        [ConfigurationProperty("companyAddressType", IsRequired = true)]
        public CompanyAddressTypeElement CompanyAddressTypes {
            get { return (CompanyAddressTypeElement)base["companyAddressType"]; }
        }

        [ConfigurationProperty("allocation", IsRequired = true)]
        public AllocationElement Allocations {
            get { return (AllocationElement)base["allocation"]; }
        }

        [ConfigurationProperty("alternatePart", IsRequired = true)]
        public AlternatePartElement AlternateParts {
            get { return (AlternatePartElement)base["alternatePart"]; }
        }

        [ConfigurationProperty("audit", IsRequired = true)]
        public AuditElement Audits {
            get { return (AuditElement)base["audit"]; }
        }

        [ConfigurationProperty("backOrder", IsRequired = true)]
        public BackOrderElement BackOrders {
            get { return (BackOrderElement)base["backOrder"]; }
        }

        [ConfigurationProperty("client", IsRequired = true)]
        public ClientElement Clients {
            get { return (ClientElement)base["client"]; }
        }

        [ConfigurationProperty("communicationLog", IsRequired = true)]
        public CommunicationLogElement CommunicationLogs {
            get { return (CommunicationLogElement)base["communicationLog"]; }
        }

        [ConfigurationProperty("communicationLogType", IsRequired = true)]
        public CommunicationLogTypeElement CommunicationLogTypes {
            get { return (CommunicationLogTypeElement)base["communicationLogType"]; }
        }

        [ConfigurationProperty("company", IsRequired = true)]
        public CompanyElement Companys {
            get { return (CompanyElement)base["company"]; }
        }

        [ConfigurationProperty("companyAddress", IsRequired = true)]
        public CompanyAddressElement CompanyAddresss {
            get { return (CompanyAddressElement)base["companyAddress"]; }
        }

        [ConfigurationProperty("companyIndustryType", IsRequired = true)]
        public CompanyIndustryTypeElement CompanyIndustryTypes {
            get { return (CompanyIndustryTypeElement)base["companyIndustryType"]; }
        }

        [ConfigurationProperty("companyType", IsRequired = true)]
        public CompanyTypeElement CompanyTypes {
            get { return (CompanyTypeElement)base["companyType"]; }
        }

        [ConfigurationProperty("contact", IsRequired = true)]
        public ContactElement Contacts {
            get { return (ContactElement)base["contact"]; }
        }

        [ConfigurationProperty("contactSupplement", IsRequired = true)]
        public ContactSupplementElement ContactSupplements {
            get { return (ContactSupplementElement)base["contactSupplement"]; }
        }

        [ConfigurationProperty("contactUserDefined", IsRequired = true)]
        public ContactUserDefinedElement ContactUserDefineds {
            get { return (ContactUserDefinedElement)base["contactUserDefined"]; }
        }

        [ConfigurationProperty("countingMethod", IsRequired = true)]
        public CountingMethodElement CountingMethods {
            get { return (CountingMethodElement)base["countingMethod"]; }
        }

        [ConfigurationProperty("country", IsRequired = true)]
        public CountryElement Countrys {
            get { return (CountryElement)base["country"]; }
        }

        [ConfigurationProperty("credit", IsRequired = true)]
        public CreditElement Credits {
            get { return (CreditElement)base["credit"]; }
        }

        [ConfigurationProperty("creditLine", IsRequired = true)]
        public CreditLineElement CreditLines {
            get { return (CreditLineElement)base["creditLine"]; }
        }

        [ConfigurationProperty("currency", IsRequired = true)]
        public CurrencyElement Currencys {
            get { return (CurrencyElement)base["currency"]; }
        }

        [ConfigurationProperty("currencyRate", IsRequired = true)]
        public CurrencyRateElement CurrencyRates {
            get { return (CurrencyRateElement)base["currencyRate"]; }
        }

        [ConfigurationProperty("customerRequirement", IsRequired = true)]
        public CustomerRequirementElement CustomerRequirements {
            get { return (CustomerRequirementElement)base["customerRequirement"]; }
        }

        [ConfigurationProperty("customerRma", IsRequired = true)]
        public CustomerRmaElement CustomerRmas {
            get { return (CustomerRmaElement)base["customerRma"]; }
        }

        [ConfigurationProperty("customerRmaLine", IsRequired = true)]
        public CustomerRmaLineElement CustomerRmaLines {
            get { return (CustomerRmaLineElement)base["customerRmaLine"]; }
        }

        [ConfigurationProperty("customerRmaLineAllocation", IsRequired = true)]
        public CustomerRmaLineAllocationElement CustomerRmaLineAllocations {
            get { return (CustomerRmaLineAllocationElement)base["customerRmaLineAllocation"]; }
        }

		[ConfigurationProperty("debit", IsRequired = true)]
		public DebitElement Debits {
			get { return (DebitElement)base["debit"]; }
		}

		[ConfigurationProperty("dataListNuggetState", IsRequired = true)]
		public DataListNuggetStateElement DataListNuggetStates {
			get { return (DataListNuggetStateElement)base["dataListNuggetState"]; }
		}

        [ConfigurationProperty("debitLine", IsRequired = true)]
        public DebitLineElement DebitLines {
            get { return (DebitLineElement)base["debitLine"]; }
        }

        [ConfigurationProperty("division", IsRequired = true)]
        public DivisionElement Divisions {
            get { return (DivisionElement)base["division"]; }
        }

        [ConfigurationProperty("dropDown", IsRequired = true)]
        public DropDownElement DropDowns {
            get { return (DropDownElement)base["dropDown"]; }
        }

        [ConfigurationProperty("dutyRate", IsRequired = true)]
        public DutyRateElement DutyRates {
            get { return (DutyRateElement)base["dutyRate"]; }
        }

        [ConfigurationProperty("excess", IsRequired = true)]
        public ExcessElement Excesss {
            get { return (ExcessElement)base["excess"]; }
        }

        [ConfigurationProperty("feedback", IsRequired = true)]
        public FeedbackElement Feedbacks {
            get { return (FeedbackElement)base["feedback"]; }
        }

        [ConfigurationProperty("globalCountryList", IsRequired = true)]
        public GlobalCountryListElement GlobalCountryLists {
            get { return (GlobalCountryListElement)base["globalCountryList"]; }
        }

        [ConfigurationProperty("globalCurrencyList", IsRequired = true)]
        public GlobalCurrencyListElement GlobalCurrencyLists {
            get { return (GlobalCurrencyListElement)base["globalCurrencyList"]; }
        }

        [ConfigurationProperty("goodsIn", IsRequired = true)]
        public GoodsInElement GoodsIns {
            get { return (GoodsInElement)base["goodsIn"]; }
        }

        [ConfigurationProperty("goodsInLine", IsRequired = true)]
        public GoodsInLineElement GoodsInLines {
            get { return (GoodsInLineElement)base["goodsInLine"]; }
        }

        [ConfigurationProperty("helpFaq", IsRequired = true)]
        public HelpFaqElement HelpFaqs {
            get { return (HelpFaqElement)base["helpFaq"]; }
        }

        [ConfigurationProperty("helpGlossary", IsRequired = true)]
        public HelpGlossaryElement HelpGlossarys {
            get { return (HelpGlossaryElement)base["helpGlossary"]; }
        }

        [ConfigurationProperty("helpGroup", IsRequired = true)]
        public HelpGroupElement HelpGroups {
            get { return (HelpGroupElement)base["helpGroup"]; }
        }

        [ConfigurationProperty("helpHowTo", IsRequired = true)]
        public HelpHowToElement HelpHowTos {
            get { return (HelpHowToElement)base["helpHowTo"]; }
        }

        [ConfigurationProperty("helpHowToStep", IsRequired = true)]
        public HelpHowToStepElement HelpHowToSteps {
            get { return (HelpHowToStepElement)base["helpHowToStep"]; }
        }

        [ConfigurationProperty("history", IsRequired = true)]
        public HistoryElement Historys {
            get { return (HistoryElement)base["history"]; }
        }

        [ConfigurationProperty("incoterm", IsRequired = true)]
        public IncotermElement Incoterms {
            get { return (IncotermElement)base["incoterm"]; }
        }

        [ConfigurationProperty("industryType", IsRequired = true)]
        public IndustryTypeElement IndustryTypes {
            get { return (IndustryTypeElement)base["industryType"]; }
        }

        [ConfigurationProperty("invoice", IsRequired = true)]
        public InvoiceElement Invoices {
            get { return (InvoiceElement)base["invoice"]; }
        }

        [ConfigurationProperty("invoiceLine", IsRequired = true)]
        public InvoiceLineElement InvoiceLines {
            get { return (InvoiceLineElement)base["invoiceLine"]; }
        }


   

        [ConfigurationProperty("invoiceLineAllocation", IsRequired = true)]
        public InvoiceLineAllocationElement InvoiceLineAllocations {
            get { return (InvoiceLineAllocationElement)base["invoiceLineAllocation"]; }
        }
        [ConfigurationProperty("internalPurchaseOrder", IsRequired = true)]
        public InternalPurchaseOrderElement InternalPurchaseOrders
        {
            get { return (InternalPurchaseOrderElement)base["internalPurchaseOrder"]; }
        }

        [ConfigurationProperty("internalPurchaseOrderLine", IsRequired = true)]
        public InternalPurchaseOrderLineElement InternalPurchaseOrderLines
        {
            get { return (InternalPurchaseOrderLineElement)base["internalPurchaseOrderLine"]; }
        }

        [ConfigurationProperty("internalPurchaseOrderStatus", IsRequired = true)]
        public InternalPurchaseOrderStatusElement InternalPurchaseOrderStatuss
        {
            get { return (InternalPurchaseOrderStatusElement)base["internalPurchaseOrderStatus"]; }
        }

        [ConfigurationProperty("login", IsRequired = true)]
        public LoginElement Logins {
            get { return (LoginElement)base["login"]; }
        }

        [ConfigurationProperty("loginPreference", IsRequired = true)]
        public LoginPreferenceElement LoginPreferences {
            get { return (LoginPreferenceElement)base["loginPreference"]; }
        }

        [ConfigurationProperty("lot", IsRequired = true)]
        public LotElement Lots {
            get { return (LotElement)base["lot"]; }
        }
        [ConfigurationProperty("BOM", IsRequired = true)]
        public BOMElement BOM
        {
            get { return (Rebound.GlobalTrader.DAL.BOMElement)base["BOM"]; }
        }
        [ConfigurationProperty("mailGroup", IsRequired = true)]
        public MailGroupElement MailGroups {
            get { return (MailGroupElement)base["mailGroup"]; }
        }

        [ConfigurationProperty("mailGroupMember", IsRequired = true)]
        public MailGroupMemberElement MailGroupMembers {
            get { return (MailGroupMemberElement)base["mailGroupMember"]; }
        }

        [ConfigurationProperty("mailMessage", IsRequired = true)]
        public MailMessageElement MailMessages {
            get { return (MailMessageElement)base["mailMessage"]; }
        }

        [ConfigurationProperty("MailMessageFolder", IsRequired = true)]
        public MailMessageFolderElement MailMessageFolders {
            get { return (MailMessageFolderElement)base["MailMessageFolder"]; }
        }

        [ConfigurationProperty("manufacturer", IsRequired = true)]
        public ManufacturerElement Manufacturers {
            get { return (ManufacturerElement)base["manufacturer"]; }
        }

        [ConfigurationProperty("manufacturerLink", IsRequired = true)]
        public ManufacturerLinkElement ManufacturerLinks {
            get { return (ManufacturerLinkElement)base["manufacturerLink"]; }
        }

        [ConfigurationProperty("maritalStatus", IsRequired = true)]
        public MaritalStatusElement MaritalStatuss {
            get { return (MaritalStatusElement)base["maritalStatus"]; }
        }

        [ConfigurationProperty("offer", IsRequired = true)]
        public OfferElement Offers {
            get { return (OfferElement)base["offer"]; }
        }

        [ConfigurationProperty("offerStatus", IsRequired = true)]
        public OfferStatusElement OfferStatuss {
            get { return (OfferStatusElement)base["offerStatus"]; }
        }

        [ConfigurationProperty("package", IsRequired = true)]
        public PackageElement Packages {
            get { return (PackageElement)base["package"]; }
        }

        [ConfigurationProperty("part", IsRequired = true)]
        public PartElement Parts {
            get { return (PartElement)base["part"]; }
        }

        [ConfigurationProperty("partSearch", IsRequired = true)]
        public PartSearchElement PartSearchs {
            get { return (PartSearchElement)base["partSearch"]; }
        }

        [ConfigurationProperty("product", IsRequired = true)]
        public ProductElement Products {
            get { return (ProductElement)base["product"]; }
        }

        [ConfigurationProperty("productType", IsRequired = true)]
        public ProductTypeElement ProductTypes {
            get { return (ProductTypeElement)base["productType"]; }
        }

        [ConfigurationProperty("purchaseOrder", IsRequired = true)]
        public PurchaseOrderElement PurchaseOrders {
            get { return (PurchaseOrderElement)base["purchaseOrder"]; }
        }

        [ConfigurationProperty("purchaseOrderLine", IsRequired = true)]
        public PurchaseOrderLineElement PurchaseOrderLines {
            get { return (PurchaseOrderLineElement)base["purchaseOrderLine"]; }
        }

        [ConfigurationProperty("purchaseOrderStatus", IsRequired = true)]
        public PurchaseOrderStatusElement PurchaseOrderStatuss {
            get { return (PurchaseOrderStatusElement)base["purchaseOrderStatus"]; }
        }


        [ConfigurationProperty("quote", IsRequired = true)]
        public QuoteElement Quotes {
            get { return (QuoteElement)base["quote"]; }
        }

        [ConfigurationProperty("quoteLine", IsRequired = true)]
        public QuoteLineElement QuoteLines {
            get { return (QuoteLineElement)base["quoteLine"]; }
        }
        [ConfigurationProperty("purchaseRequestLineDetail", IsRequired = true)]
        public PurchaseRequestLineDetailElement PurchaseRequestLineDetails   
        {
            get { return (PurchaseRequestLineDetailElement)base["purchaseRequestLineDetail"]; }
        }
        [ConfigurationProperty("quoteStatus", IsRequired = true)]
        public QuoteStatusElement QuoteStatuss {
            get { return (QuoteStatusElement)base["quoteStatus"]; }
        }

        [ConfigurationProperty("reason", IsRequired = true)]
        public ReasonElement Reasons {
            get { return (ReasonElement)base["reason"]; }
        }

        [ConfigurationProperty("recentlyViewed", IsRequired = true)]
        public RecentlyViewedElement RecentlyVieweds {
            get { return (RecentlyViewedElement)base["recentlyViewed"]; }
        }

        [ConfigurationProperty("report", IsRequired = true)]
        public ReportElement Reports {
            get { return (ReportElement)base["report"]; }
        }

        [ConfigurationProperty("reportCategory", IsRequired = true)]
        public ReportCategoryElement ReportCategorys {
            get { return (ReportCategoryElement)base["reportCategory"]; }
        }

        [ConfigurationProperty("reportCategoryGroup", IsRequired = true)]
        public ReportCategoryGroupElement ReportCategoryGroups {
            get { return (ReportCategoryGroupElement)base["reportCategoryGroup"]; }
        }

        [ConfigurationProperty("ReportColumn", IsRequired = true)]
        public ReportColumnElement ReportColumns {
            get { return (ReportColumnElement)base["ReportColumn"]; }
        }

        [ConfigurationProperty("ReportColumnFormat", IsRequired = true)]
        public ReportColumnFormatElement ReportColumnFormats {
            get { return (ReportColumnFormatElement)base["ReportColumnFormat"]; }
        }

        [ConfigurationProperty("reportParameter", IsRequired = true)]
        public ReportParameterElement ReportParameters {
            get { return (ReportParameterElement)base["reportParameter"]; }
        }

        [ConfigurationProperty("reportParameterType", IsRequired = true)]
        public ReportParameterTypeElement ReportParameterTypes {
            get { return (ReportParameterTypeElement)base["reportParameterType"]; }
        }

        [ConfigurationProperty("rohsStatus", IsRequired = true)]
        public RohsStatusElement RohsStatuss {
            get { return (RohsStatusElement)base["rohsStatus"]; }
        }

        [ConfigurationProperty("saleCommission", IsRequired = true)]
        public SaleCommissionElement SaleCommissions {
            get { return (SaleCommissionElement)base["saleCommission"]; }
        }

        [ConfigurationProperty("salesOrder", IsRequired = true)]
        public SalesOrderElement SalesOrders {
            get { return (SalesOrderElement)base["salesOrder"]; }
        }

        [ConfigurationProperty("salesOrderLine", IsRequired = true)]
        public SalesOrderLineElement SalesOrderLines {
            get { return (SalesOrderLineElement)base["salesOrderLine"]; }
        }

        [ConfigurationProperty("salesOrderStatus", IsRequired = true)]
        public SalesOrderStatusElement SalesOrderStatuss {
            get { return (SalesOrderStatusElement)base["salesOrderStatus"]; }
        }

        [ConfigurationProperty("saleType", IsRequired = true)]
        public SaleTypeElement SaleTypes {
            get { return (SaleTypeElement)base["saleType"]; }
        }

        [ConfigurationProperty("securityFunction", IsRequired = true)]
        public SecurityFunctionElement SecurityFunctions {
            get { return (SecurityFunctionElement)base["securityFunction"]; }
        }

        [ConfigurationProperty("securityGroup", IsRequired = true)]
        public SecurityGroupElement SecurityGroups {
            get { return (SecurityGroupElement)base["securityGroup"]; }
        }

        [ConfigurationProperty("securityGroupLogin", IsRequired = true)]
        public SecurityGroupLoginElement SecurityGroupLogins {
            get { return (SecurityGroupLoginElement)base["securityGroupLogin"]; }
        }

        [ConfigurationProperty("securityGroupSecurityFunctionPermission", IsRequired = true)]
        public SecurityGroupSecurityFunctionPermissionElement SecurityGroupSecurityFunctionPermissions {
            get { return (SecurityGroupSecurityFunctionPermissionElement)base["securityGroupSecurityFunctionPermission"]; }
        }

        [ConfigurationProperty("sequencer", IsRequired = true)]
        public SequencerElement Sequencers {
            get { return (SequencerElement)base["sequencer"]; }
        }

        [ConfigurationProperty("service", IsRequired = true)]
        public ServiceElement Services {
            get { return (ServiceElement)base["service"]; }
        }

        [ConfigurationProperty("session", IsRequired = true)]
        public SessionElement Sessions {
            get { return (SessionElement)base["session"]; }
        }

        [ConfigurationProperty("setting", IsRequired = true)]
        public DAL.SettingElement Settings {
            get { return (DAL.SettingElement)base["setting"]; }
        }

        [ConfigurationProperty("settingItem", IsRequired = true)]
        public SettingItemElement SettingItems {
            get { return (SettingItemElement)base["settingItem"]; }
        }

        [ConfigurationProperty("shipVia", IsRequired = true)]
        public ShipViaElement ShipVias {
            get { return (ShipViaElement)base["shipVia"]; }
        }

        [ConfigurationProperty("sitePage", IsRequired = true)]
        public SitePageElement SitePages {
            get { return (SitePageElement)base["sitePage"]; }
        }

        [ConfigurationProperty("siteSection", IsRequired = true)]
        public SiteSectionElement SiteSections {
            get { return (SiteSectionElement)base["siteSection"]; }
        }

        [ConfigurationProperty("sourcingLink", IsRequired = true)]
        public SourcingLinkElement SourcingLinks {
            get { return (SourcingLinkElement)base["sourcingLink"]; }
        }

        [ConfigurationProperty("sourcingResult", IsRequired = true)]
        public SourcingResultElement SourcingResults {
            get { return (SourcingResultElement)base["sourcingResult"]; }
        }

        [ConfigurationProperty("stock", IsRequired = true)]
        public StockElement Stocks {
            get { return (StockElement)base["stock"]; }
        }

        [ConfigurationProperty("hubsourcingresults", IsRequired = true)]
        public HubSourcingResultsElement HubSourcingResults 
        {
            get { return (HubSourcingResultsElement)base["hubsourcingresults"]; }
        }

        [ConfigurationProperty("stockImage", IsRequired = true)]
        public StockImageElement StockImages {
            get { return (StockImageElement)base["stockImage"]; }
        }

        [ConfigurationProperty("stockLog", IsRequired = true)]
        public StockLogElement StockLogs {
            get { return (StockLogElement)base["stockLog"]; }
        }

        [ConfigurationProperty("stockLogReason", IsRequired = true)]
        public StockLogReasonElement StockLogReasons {
            get { return (StockLogReasonElement)base["stockLogReason"]; }
        }

        [ConfigurationProperty("stockLogType", IsRequired = true)]
        public StockLogTypeElement StockLogTypes {
            get { return (StockLogTypeElement)base["stockLogType"]; }
        }

        [ConfigurationProperty("supplierRma", IsRequired = true)]
        public SupplierRmaElement SupplierRmas {
            get { return (SupplierRmaElement)base["supplierRma"]; }
        }

        [ConfigurationProperty("supplierRmaLine", IsRequired = true)]
        public SupplierRmaLineElement SupplierRmaLines {
            get { return (SupplierRmaLineElement)base["supplierRmaLine"]; }
        }

        [ConfigurationProperty("systemDocumentFooter", IsRequired = true)]
        public SystemDocumentFooterElement SystemDocumentFooters {
            get { return (SystemDocumentFooterElement)base["systemDocumentFooter"]; }
        }

        [ConfigurationProperty("taskStatus", IsRequired = true)]
        public TaskStatusElement TaskStatuss {
            get { return (TaskStatusElement)base["taskStatus"]; }
        }

        [ConfigurationProperty("tax", IsRequired = true)]
        public TaxElement Taxs {
            get { return (TaxElement)base["tax"]; }
        }

        [ConfigurationProperty("taxRate", IsRequired = true)]
        public TaxRateElement TaxRates {
            get { return (TaxRateElement)base["taxRate"]; }
        }

        [ConfigurationProperty("globalTax", IsRequired = true)]
        public GlobalTaxElement GlobalTaxs
        {
            get { return (GlobalTaxElement)base["globalTax"]; }
        }

        [ConfigurationProperty("globalTaxRate", IsRequired = true)]
        public GlobalTaxRateElement GlobalTaxRates
        {
            get { return (GlobalTaxRateElement)base["globalTaxRate"]; }
        }

        [ConfigurationProperty("team", IsRequired = true)]
        public TeamElement Teams {
            get { return (TeamElement)base["team"]; }
        }

        [ConfigurationProperty("terms", IsRequired = true)]
        public TermsElement Termss {
            get { return (TermsElement)base["terms"]; }
        }

        [ConfigurationProperty("toDo", IsRequired = true)]
        public ToDoElement ToDos {
            get { return (ToDoElement)base["toDo"]; }
        }

        [ConfigurationProperty("usage", IsRequired = true)]
        public UsageElement Usages {
            get { return (UsageElement)base["usage"]; }
        }

        [ConfigurationProperty("userAudit", IsRequired = true)]
        public UserAuditElement UserAudits {
            get { return (UserAuditElement)base["userAudit"]; }
        }

        [ConfigurationProperty("warehouse", IsRequired = true)]
        public WarehouseElement Warehouses {
            get { return (WarehouseElement)base["warehouse"]; }
        }
        //[001] code start
        [ConfigurationProperty("ReportNPR", IsRequired = true)]
        public ReportNPRElement ReportNPRs
        {
            get { return (ReportNPRElement)base["ReportNPR"]; }
        }
        //[001] code end
        //[002] code start
        [ConfigurationProperty("EmailComposer", IsRequired = true)]
        public EmailComposerElement EmailComposers
        {
            get { return (EmailComposerElement)base["EmailComposer"]; }
        }
        //[002] code end

        //[003] code start
        [ConfigurationProperty("StockInfo", IsRequired = true)]
        public StockInfoElement StockInfos
        {
            get { return (StockInfoElement)base["StockInfo"]; }
        }
        //[003] code start
        [ConfigurationProperty("TabSecurityFunction", IsRequired = true)]
        public TabSecurityFunctionElement TabSecurityFunctions
        {
            get { return (TabSecurityFunctionElement)base["TabSecurityFunction"]; }
        }

        [ConfigurationProperty("supplierInvoice", IsRequired = true)]
        public SupplierInvoiceElement SupplierInvoices
        {
            get { return (SupplierInvoiceElement)base["supplierInvoice"]; }
        }

        [ConfigurationProperty("supplierInvoiceLine", IsRequired = true)]
        public SupplierInvoiceLineElement SupplierInvoiceLines
        {
            get { return (SupplierInvoiceLineElement)base["supplierInvoiceLine"]; }
        }

        [ConfigurationProperty("clientInvoice", IsRequired = true)]
        public ClientInvoiceElement ClientInvoices
        {
            get { return (ClientInvoiceElement)base["clientInvoice"]; }
        }

        [ConfigurationProperty("printer", IsRequired = true)]
        public PrinterElement Printer
        {
            get { return (PrinterElement)base["printer"]; }
        }
        //[004] code start
        [ConfigurationProperty("productSource", IsRequired = true)]
        public ProductSourceElement ProductSources
        {
            get { return (ProductSourceElement)base["productSource"]; }
        }
        //[004] code end

        [ConfigurationProperty("certificateCategory", IsRequired = true)]
        public CertificateCategoryElement CertificateCategorys
        {
            get { return (CertificateCategoryElement)base["certificateCategory"]; }
        }

        [ConfigurationProperty("certificate", IsRequired = true)]
        public CertificateElement Certificates
        {
            get { return (CertificateElement)base["certificate"]; }
        }
        [ConfigurationProperty("labelPath", IsRequired = true)]
        public LabelPathElement LabelPath
        {
            get { return (LabelPathElement)base["labelPath"]; }
        }

        [ConfigurationProperty("EPR", IsRequired = true)]
        public EPRElement EPR
        {
            get { return (EPRElement)base["EPR"]; }
        }


        [ConfigurationProperty("eightDCode", IsRequired = true)]
        public EightDCodeElement EightDCodes
        {
            get { return (EightDCodeElement)base["eightDCode"]; }
        }

        [ConfigurationProperty("poquote", IsRequired = true)]
        public PurchaseQuoteElement POQuotes
        {
            get { return (PurchaseQuoteElement)base["poquote"]; }
        }
        [ConfigurationProperty("poquoteLine", IsRequired = true)]

        public POQuoteLineElement POQuoteLines
        {
            get { return (POQuoteLineElement)base["poquoteLine"]; }
        }
        [ConfigurationProperty("CSVExportLog", IsRequired = true)]
        public CSVExportLogElement CSVExportLog
        {
            get { return (Rebound.GlobalTrader.DAL.CSVExportLogElement)base["CSVExportLog"]; }
        }       

        [ConfigurationProperty("clientInvoiceLine", IsRequired = true)]
        public ClientInvoiceLineElement ClientInvoiceLines
        {
            get { return (ClientInvoiceLineElement)base["clientInvoiceLine"]; }
        }

        [ConfigurationProperty("invoiceSetting", IsRequired = true)]
        public InvoiceSettingElement InvoiceSetting 
        {
            get { return (InvoiceSettingElement)base["invoiceSetting"]; }
        }
        //[005] code start
        [ConfigurationProperty("mslLevel", IsRequired = true)]
        public MSLLevelElement MSLLevels
        {
            get { return (MSLLevelElement)base["mslLevel"]; }
        }
        //[005] code end
        //[006] start code
        [ConfigurationProperty("gtupdate", IsRequired = true)]
        public GTUpdateElement GTUpdates
        {
            get { return (GTUpdateElement)base["gtupdate"]; }
    }
        //[006] end code
    }

    #endregion


    public class DatabaseSettingsElement : ConfigurationElement {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName {
            get { return (string)base["connectionStringName"]; }
            set { base["connectionStringName"] = value; }
        }
        public string ConnectionString {
            get {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ? Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return WebConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
            }
        }
        [ConfigurationProperty("mediaConnectionStringName")]
        public string MediaConnectionStringName {
            get { return (string)base["mediaConnectionStringName"]; }
            set { base["mediaConnectionStringName"] = value; }
        }
        public string MediaConnectionString {
            get {
                string connStringName = (string.IsNullOrEmpty(this.MediaConnectionStringName) ? Globals.Settings.MediaConnectionStringName : this.MediaConnectionStringName);
                return WebConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
            }
        }
        [ConfigurationProperty("GTConnectionStringName")]
        public string GTConnectionStringName
        {
            get { return (string)base["GTConnectionStringName"]; }
            set { base["GTConnectionStringName"] = value; }
        }
        public string GTConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.GTConnectionStringName) ? Globals.Settings.GTConnectionStringName : this.GTConnectionStringName);
                return WebConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
            }
        }
        [ConfigurationProperty("databaseType", DefaultValue = "Sql")]
        public string DatabaseTypeString {
            get { return (string)base["databaseType"]; }
        }
        public DatabaseTypeList DatabaseType {
            get {
                DatabaseTypeList enm = DatabaseTypeList.SQLServer;
                switch (DatabaseTypeString.ToUpper()) {
                    case "SQL": enm = DatabaseTypeList.SQLServer; break;
                }
                return enm;
            }
        }
        public enum DatabaseTypeList {
            SQLServer
        }
    }

    public class EntityElement : ConfigurationElement {
        private string _strEntityBaseName;
        public string EntityBaseName {
            get { return _strEntityBaseName; }
            set { _strEntityBaseName = value; }
        }
        public string ConnectionString {
            get { return Globals.Settings.DatabaseSettings.ConnectionString; }
        }
        public string MediaConnectionString {
            get { return Globals.Settings.DatabaseSettings.MediaConnectionString; }
        }
        public string GTConnectionString
        {
            get { return Globals.Settings.DatabaseSettings.GTConnectionString; }
        }
        public string ProviderType {
            get { return String.Format("Rebound.GlobalTrader.DAL.{0}Client.{0}{1}Provider", Globals.Settings.DatabaseSettings.DatabaseTypeString, _strEntityBaseName); }
        }
    }

    #region Entity Elements

	public class ActivityElement : EntityElement { protected override void Init() { this.EntityBaseName = "Activity"; base.Init(); } }
	public class AddressElement : EntityElement { protected override void Init() { this.EntityBaseName = "Address"; base.Init(); } }
    public class CompanyAddressTypeElement : EntityElement { protected override void Init() { this.EntityBaseName = "CompanyAddressType"; base.Init(); } }
    public class AllocationElement : EntityElement { protected override void Init() { this.EntityBaseName = "Allocation"; base.Init(); } }
    public class AlternatePartElement : EntityElement { protected override void Init() { this.EntityBaseName = "AlternatePart"; base.Init(); } }
    public class AuditElement : EntityElement { protected override void Init() { this.EntityBaseName = "Audit"; base.Init(); } }
    public class BackOrderElement : EntityElement { protected override void Init() { this.EntityBaseName = "BackOrder"; base.Init(); } }
    public class ClientElement : EntityElement { protected override void Init() { this.EntityBaseName = "Client"; base.Init(); } }
    public class CommunicationLogElement : EntityElement { protected override void Init() { this.EntityBaseName = "CommunicationLog"; base.Init(); } }
    public class CommunicationLogTypeElement : EntityElement { protected override void Init() { this.EntityBaseName = "CommunicationLogType"; base.Init(); } }
    public class CompanyElement : EntityElement { protected override void Init() { this.EntityBaseName = "Company"; base.Init(); } }
    public class CompanyAddressElement : EntityElement { protected override void Init() { this.EntityBaseName = "CompanyAddress"; base.Init(); } }
    public class CompanyIndustryTypeElement : EntityElement { protected override void Init() { this.EntityBaseName = "CompanyIndustryType"; base.Init(); } }
    public class CompanyTypeElement : EntityElement { protected override void Init() { this.EntityBaseName = "CompanyType"; base.Init(); } }
    public class ContactElement : EntityElement { protected override void Init() { this.EntityBaseName = "Contact"; base.Init(); } }
    public class ContactSupplementElement : EntityElement { protected override void Init() { this.EntityBaseName = "ContactSupplement"; base.Init(); } }
    public class ContactUserDefinedElement : EntityElement { protected override void Init() { this.EntityBaseName = "ContactUserDefined"; base.Init(); } }
    public class CountingMethodElement : EntityElement { protected override void Init() { this.EntityBaseName = "CountingMethod"; base.Init(); } }
    public class CountryElement : EntityElement { protected override void Init() { this.EntityBaseName = "Country"; base.Init(); } }
    public class CreditElement : EntityElement { protected override void Init() { this.EntityBaseName = "Credit"; base.Init(); } }
    public class CreditLineElement : EntityElement { protected override void Init() { this.EntityBaseName = "CreditLine"; base.Init(); } }
    public class CurrencyElement : EntityElement { protected override void Init() { this.EntityBaseName = "Currency"; base.Init(); } }
    public class CurrencyRateElement : EntityElement { protected override void Init() { this.EntityBaseName = "CurrencyRate"; base.Init(); } }
    public class CustomerRequirementElement : EntityElement { protected override void Init() { this.EntityBaseName = "CustomerRequirement"; base.Init(); } }
    public class CustomerRmaElement : EntityElement { protected override void Init() { this.EntityBaseName = "CustomerRma"; base.Init(); } }
    public class CustomerRmaLineElement : EntityElement { protected override void Init() { this.EntityBaseName = "CustomerRmaLine"; base.Init(); } }
    public class CustomerRmaLineAllocationElement : EntityElement { protected override void Init() { this.EntityBaseName = "CustomerRmaLineAllocation"; base.Init(); } }
	public class DataListNuggetStateElement : EntityElement { protected override void Init() { this.EntityBaseName = "DataListNuggetState"; base.Init(); } }
    public class DebitElement : EntityElement { protected override void Init() { this.EntityBaseName = "Debit"; base.Init(); } }
    public class DebitLineElement : EntityElement { protected override void Init() { this.EntityBaseName = "DebitLine"; base.Init(); } }
    public class DivisionElement : EntityElement { protected override void Init() { this.EntityBaseName = "Division"; base.Init(); } }
    public class DropDownElement : EntityElement { protected override void Init() { this.EntityBaseName = "DropDown"; base.Init(); } }
    public class DutyRateElement : EntityElement { protected override void Init() { this.EntityBaseName = "DutyRate"; base.Init(); } }
    public class ExcessElement : EntityElement { protected override void Init() { this.EntityBaseName = "Excess"; base.Init(); } }
    public class FeedbackElement : EntityElement { protected override void Init() { this.EntityBaseName = "Feedback"; base.Init(); } }
    public class GlobalCountryListElement : EntityElement { protected override void Init() { this.EntityBaseName = "GlobalCountryList"; base.Init(); } }
    public class GlobalCurrencyListElement : EntityElement { protected override void Init() { this.EntityBaseName = "GlobalCurrencyList"; base.Init(); } }
    public class GoodsInElement : EntityElement { protected override void Init() { this.EntityBaseName = "GoodsIn"; base.Init(); } }
    public class GoodsInLineElement : EntityElement { protected override void Init() { this.EntityBaseName = "GoodsInLine"; base.Init(); } }
    public class HelpFaqElement : EntityElement { protected override void Init() { this.EntityBaseName = "HelpFaq"; base.Init(); } }
    public class HelpGlossaryElement : EntityElement { protected override void Init() { this.EntityBaseName = "HelpGlossary"; base.Init(); } }
    public class HelpGroupElement : EntityElement { protected override void Init() { this.EntityBaseName = "HelpGroup"; base.Init(); } }
    public class HelpHowToElement : EntityElement { protected override void Init() { this.EntityBaseName = "HelpHowTo"; base.Init(); } }
    public class HelpHowToStepElement : EntityElement { protected override void Init() { this.EntityBaseName = "HelpHowToStep"; base.Init(); } }
    public class HistoryElement : EntityElement { protected override void Init() { this.EntityBaseName = "History"; base.Init(); } }
    public class IncotermElement : EntityElement { protected override void Init() { this.EntityBaseName = "Incoterm"; base.Init(); } }
    public class IndustryTypeElement : EntityElement { protected override void Init() { this.EntityBaseName = "IndustryType"; base.Init(); } }
    public class InvoiceElement : EntityElement { protected override void Init() { this.EntityBaseName = "Invoice"; base.Init(); } }
    public class InvoiceLineElement : EntityElement { protected override void Init() { this.EntityBaseName = "InvoiceLine"; base.Init(); } }
    public class InvoiceLineAllocationElement : EntityElement { protected override void Init() { this.EntityBaseName = "InvoiceLineAllocation"; base.Init(); } }
    public class InternalPurchaseOrderElement : EntityElement { protected override void Init() { this.EntityBaseName = "InternalPurchaseOrder"; base.Init(); } }
    
    public class InternalPurchaseOrderStatusElement : EntityElement { protected override void Init() { this.EntityBaseName = "InternalPurchaseOrderStatus"; base.Init(); } }
    public class LoginElement : EntityElement { protected override void Init() { this.EntityBaseName = "Login"; base.Init(); } }
    public class LoginPreferenceElement : EntityElement { protected override void Init() { this.EntityBaseName = "LoginPreference"; base.Init(); } }
    public class LotElement : EntityElement { protected override void Init() { this.EntityBaseName = "Lot"; base.Init(); } }
    public class MailGroupElement : EntityElement { protected override void Init() { this.EntityBaseName = "MailGroup"; base.Init(); } }
    public class MailGroupMemberElement : EntityElement { protected override void Init() { this.EntityBaseName = "MailGroupMember"; base.Init(); } }
    public class MailMessageElement : EntityElement { protected override void Init() { this.EntityBaseName = "MailMessage"; base.Init(); } }
    public class MailMessageFolderElement : EntityElement { protected override void Init() { this.EntityBaseName = "MailMessageFolder"; base.Init(); } }
    public class ManufacturerElement : EntityElement { protected override void Init() { this.EntityBaseName = "Manufacturer"; base.Init(); } }
    public class ManufacturerLinkElement : EntityElement { protected override void Init() { this.EntityBaseName = "ManufacturerLink"; base.Init(); } }
    public class MaritalStatusElement : EntityElement { protected override void Init() { this.EntityBaseName = "MaritalStatus"; base.Init(); } }
    public class OfferElement : EntityElement { protected override void Init() { this.EntityBaseName = "Offer"; base.Init(); } }
    public class OfferStatusElement : EntityElement { protected override void Init() { this.EntityBaseName = "OfferStatus"; base.Init(); } }
    public class PackageElement : EntityElement { protected override void Init() { this.EntityBaseName = "Package"; base.Init(); } }
    public class PartElement : EntityElement { protected override void Init() { this.EntityBaseName = "Part"; base.Init(); } }
    public class PartSearchElement : EntityElement { protected override void Init() { this.EntityBaseName = "PartSearch"; base.Init(); } }
    public class ProductElement : EntityElement { protected override void Init() { this.EntityBaseName = "Product"; base.Init(); } }
    public class ProductTypeElement : EntityElement { protected override void Init() { this.EntityBaseName = "ProductType"; base.Init(); } }
    public class PurchaseOrderElement : EntityElement { protected override void Init() { this.EntityBaseName = "PurchaseOrder"; base.Init(); } }
    public class PurchaseOrderLineElement : EntityElement { protected override void Init() { this.EntityBaseName = "PurchaseOrderLine"; base.Init(); } }
    public class PurchaseOrderStatusElement : EntityElement { protected override void Init() { this.EntityBaseName = "PurchaseOrderStatus"; base.Init(); } }
    public class QuoteElement : EntityElement { protected override void Init() { this.EntityBaseName = "Quote"; base.Init(); } }
    public class QuoteLineElement : EntityElement { protected override void Init() { this.EntityBaseName = "QuoteLine"; base.Init(); } }
    public class PurchaseRequestLineDetailElement : EntityElement { protected override void Init() { this.EntityBaseName = "PurchaseRequestLineDetail"; base.Init(); } }
    public class QuoteStatusElement : EntityElement { protected override void Init() { this.EntityBaseName = "QuoteStatus"; base.Init(); } }
    public class ReasonElement : EntityElement { protected override void Init() { this.EntityBaseName = "Reason"; base.Init(); } }
    public class RecentlyViewedElement : EntityElement { protected override void Init() { this.EntityBaseName = "RecentlyViewed"; base.Init(); } }
    public class ReportElement : EntityElement { protected override void Init() { this.EntityBaseName = "Report"; base.Init(); } }
    public class ReportCategoryElement : EntityElement { protected override void Init() { this.EntityBaseName = "ReportCategory"; base.Init(); } }
    public class ReportCategoryGroupElement : EntityElement { protected override void Init() { this.EntityBaseName = "ReportCategoryGroup"; base.Init(); } }
    public class ReportColumnElement : EntityElement { protected override void Init() { this.EntityBaseName = "ReportColumn"; base.Init(); } }
    public class ReportColumnFormatElement : EntityElement { protected override void Init() { this.EntityBaseName = "ReportColumnFormat"; base.Init(); } }
    public class ReportParameterElement : EntityElement { protected override void Init() { this.EntityBaseName = "ReportParameter"; base.Init(); } }
    public class ReportParameterTypeElement : EntityElement { protected override void Init() { this.EntityBaseName = "ReportParameterType"; base.Init(); } }
    public class RohsStatusElement : EntityElement { protected override void Init() { this.EntityBaseName = "RohsStatus"; base.Init(); } }
    public class SaleCommissionElement : EntityElement { protected override void Init() { this.EntityBaseName = "SaleCommission"; base.Init(); } }
    public class SalesOrderElement : EntityElement { protected override void Init() { this.EntityBaseName = "SalesOrder"; base.Init(); } }
    public class SalesOrderLineElement : EntityElement { protected override void Init() { this.EntityBaseName = "SalesOrderLine"; base.Init(); } }
    public class SalesOrderStatusElement : EntityElement { protected override void Init() { this.EntityBaseName = "SalesOrderStatus"; base.Init(); } }
    public class SaleTypeElement : EntityElement { protected override void Init() { this.EntityBaseName = "SaleType"; base.Init(); } }
    public class SecurityFunctionElement : EntityElement { protected override void Init() { this.EntityBaseName = "SecurityFunction"; base.Init(); } }
    public class SecurityGroupElement : EntityElement { protected override void Init() { this.EntityBaseName = "SecurityGroup"; base.Init(); } }
    public class SecurityGroupLoginElement : EntityElement { protected override void Init() { this.EntityBaseName = "SecurityGroupLogin"; base.Init(); } }
    public class SecurityGroupSecurityFunctionPermissionElement : EntityElement { protected override void Init() { this.EntityBaseName = "SecurityGroupSecurityFunctionPermission"; base.Init(); } }
    public class SequencerElement : EntityElement { protected override void Init() { this.EntityBaseName = "Sequencer"; base.Init(); } }
    public class ServiceElement : EntityElement { protected override void Init() { this.EntityBaseName = "Service"; base.Init(); } }
    public class SessionElement : EntityElement { protected override void Init() { this.EntityBaseName = "Session"; base.Init(); } }
    public class SettingElement : EntityElement { protected override void Init() { this.EntityBaseName = "Setting"; base.Init(); } }
    public class SettingItemElement : EntityElement { protected override void Init() { this.EntityBaseName = "SettingItem"; base.Init(); } }
    public class ShipViaElement : EntityElement { protected override void Init() { this.EntityBaseName = "ShipVia"; base.Init(); } }
    public class SitePageElement : EntityElement { protected override void Init() { this.EntityBaseName = "SitePage"; base.Init(); } }
    public class SiteSectionElement : EntityElement { protected override void Init() { this.EntityBaseName = "SiteSection"; base.Init(); } }
    public class SourcingLinkElement : EntityElement { protected override void Init() { this.EntityBaseName = "SourcingLink"; base.Init(); } }
    public class SourcingResultElement : EntityElement { protected override void Init() { this.EntityBaseName = "SourcingResult"; base.Init(); } }
    public class StockElement : EntityElement { protected override void Init() { this.EntityBaseName = "Stock"; base.Init(); } }
    public class HubSourcingResultsElement  : EntityElement { protected override void Init() { this.EntityBaseName = "HubSourcingResults"; base.Init(); } }
    public class StockImageElement : EntityElement { protected override void Init() { this.EntityBaseName = "StockImage"; base.Init(); } }
    public class StockLogElement : EntityElement { protected override void Init() { this.EntityBaseName = "StockLog"; base.Init(); } }
    public class StockLogReasonElement : EntityElement { protected override void Init() { this.EntityBaseName = "StockLogReason"; base.Init(); } }
    public class StockLogTypeElement : EntityElement { protected override void Init() { this.EntityBaseName = "StockLogType"; base.Init(); } }
    public class SupplierRmaElement : EntityElement { protected override void Init() { this.EntityBaseName = "SupplierRma"; base.Init(); } }
    public class SupplierRmaLineElement : EntityElement { protected override void Init() { this.EntityBaseName = "SupplierRmaLine"; base.Init(); } }
    public class SystemDocumentFooterElement : EntityElement { protected override void Init() { this.EntityBaseName = "SystemDocumentFooter"; base.Init(); } }
    public class TaskStatusElement : EntityElement { protected override void Init() { this.EntityBaseName = "TaskStatus"; base.Init(); } }
    public class TaxElement : EntityElement { protected override void Init() { this.EntityBaseName = "Tax"; base.Init(); } }
    public class TaxRateElement : EntityElement { protected override void Init() { this.EntityBaseName = "TaxRate"; base.Init(); } }
    public class GlobalTaxElement : EntityElement { protected override void Init() { this.EntityBaseName = "GlobalTax"; base.Init(); } }
    public class GlobalTaxRateElement : EntityElement { protected override void Init() { this.EntityBaseName = "GlobalTaxRate"; base.Init(); } }
    public class TeamElement : EntityElement { protected override void Init() { this.EntityBaseName = "Team"; base.Init(); } }
    public class TermsElement : EntityElement { protected override void Init() { this.EntityBaseName = "Terms"; base.Init(); } }
    public class ToDoElement : EntityElement { protected override void Init() { this.EntityBaseName = "ToDo"; base.Init(); } }
    public class UsageElement : EntityElement { protected override void Init() { this.EntityBaseName = "Usage"; base.Init(); } }
    public class UserAuditElement : EntityElement { protected override void Init() { this.EntityBaseName = "UserAudit"; base.Init(); } }
    public class WarehouseElement : EntityElement { protected override void Init() { this.EntityBaseName = "Warehouse"; base.Init(); } }
    //[001] code start
    public class ReportNPRElement : EntityElement { protected override void Init() { this.EntityBaseName = "ReportNPR"; base.Init(); } }
    //[001] code end
    //[002] code start
    public class EmailComposerElement : EntityElement { protected override void Init() { this.EntityBaseName = "EmailComposer"; base.Init(); } }
    //[002] code end

    //[003] code start
    public class StockInfoElement : EntityElement { protected override void Init() { this.EntityBaseName = "StockInfo"; base.Init(); } }
    //[003] code end
    public class TabSecurityFunctionElement : EntityElement { protected override void Init() { this.EntityBaseName = "TabSecurityFunction"; base.Init(); } }
    public class SupplierInvoiceElement : EntityElement { protected override void Init() { this.EntityBaseName = "SupplierInvoice"; base.Init(); } }
    public class SupplierInvoiceLineElement : EntityElement { protected override void Init() { this.EntityBaseName = "SupplierInvoiceLine"; base.Init(); } }
    public class PrinterElement : EntityElement { protected override void Init() { this.EntityBaseName = "Printer"; base.Init(); } }
    //[004] code start
    public class ProductSourceElement : EntityElement { protected override void Init() { this.EntityBaseName = "ProductSource"; base.Init(); } }
    //[004] code end
    public class CertificateCategoryElement : EntityElement { protected override void Init() { this.EntityBaseName = "CertificateCategory"; base.Init(); } }
    public class CertificateElement : EntityElement { protected override void Init() { this.EntityBaseName = "Certificate"; base.Init(); } }
    public class LabelPathElement : EntityElement { protected override void Init() { this.EntityBaseName = "LabelPath"; base.Init(); } }
    public class EPRElement : EntityElement { protected override void Init() { this.EntityBaseName = "EPR"; base.Init(); } }

    public class EightDCodeElement : EntityElement { protected override void Init() { this.EntityBaseName = "EightDCode"; base.Init(); } }
    public class BOMElement : EntityElement { protected override void Init() { this.EntityBaseName = "BOM"; base.Init(); } }
    public class PurchaseQuoteElement : EntityElement { protected override void Init() { this.EntityBaseName = "POQuote"; base.Init(); } }
    public class POQuoteLineElement : EntityElement { protected override void Init() { this.EntityBaseName = "POQuoteLine"; base.Init(); } }

    public class InternalPurchaseOrderLineElement : EntityElement { protected override void Init() { this.EntityBaseName = "InternalPurchaseOrderLine"; base.Init(); } }
    public class CSVExportLogElement : EntityElement { protected override void Init() { this.EntityBaseName = "CSVExportLog"; base.Init(); } }
    public class ClientInvoiceElement : EntityElement { protected override void Init() { this.EntityBaseName = "ClientInvoice"; base.Init(); } }
    public class ClientInvoiceLineElement : EntityElement { protected override void Init() { this.EntityBaseName = "ClientInvoiceLine"; base.Init(); } }
    public class InvoiceSettingElement : EntityElement { protected override void Init() { this.EntityBaseName = "InvoiceSetting"; base.Init(); } }
    //[005] code start
    public class MSLLevelElement : EntityElement { protected override void Init() { this.EntityBaseName = "MSLLevel"; base.Init(); } }
    //[005] code end
    //[006] start code
    public class GTUpdateElement : EntityElement { protected override void Init() { this.EntityBaseName = "GTUpdate"; base.Init(); } }
    //[006] end code
    #endregion

}
