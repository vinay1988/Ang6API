/*
Marker     Changed by      Date         Remarks
[001]      Vinay           18/06/2012   This need to implement the NPR Report
[002]      Vinay           10/07/2012   This need for Rebound- Invoice bulk Emailer
[003]      Vinay           19/12/2012   Add Stock Info nuggets
[004]      Vinay           04/02/2014   CR:- Add AS9120 Requirement in GT application
[005]      Suhail          12/04/2018    changes MSL text to drop down list
[006]       Abhinav        06/04/2018   [REB-10310]: CHG-146739: Built in function to notifi users when GT is updated when they login
*/
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;



// 30 January 2008 17:00
namespace Rebound.GlobalTrader.DAL {
    public static class SiteProvider {
        public static ActivityProvider Activity { get { return ActivityProvider.Instance; } }
        public static AddressProvider Address { get { return AddressProvider.Instance; } }
        public static CompanyAddressTypeProvider CompanyAddressType { get { return CompanyAddressTypeProvider.Instance; } }
        public static AllocationProvider Allocation { get { return AllocationProvider.Instance; } }
        public static AlternatePartProvider AlternatePart { get { return AlternatePartProvider.Instance; } }
        public static AuditProvider Audit { get { return AuditProvider.Instance; } }
        public static BackOrderProvider BackOrder { get { return BackOrderProvider.Instance; } }
        public static ClientProvider Client { get { return ClientProvider.Instance; } }
        public static CommunicationLogProvider CommunicationLog { get { return CommunicationLogProvider.Instance; } }
        public static CommunicationLogTypeProvider CommunicationLogType { get { return CommunicationLogTypeProvider.Instance; } }
        public static CompanyProvider Company { get { return CompanyProvider.Instance; } }
        public static CompanyAddressProvider CompanyAddress { get { return CompanyAddressProvider.Instance; } }
        public static CompanyIndustryTypeProvider CompanyIndustryType { get { return CompanyIndustryTypeProvider.Instance; } }
        public static CompanyTypeProvider CompanyType { get { return CompanyTypeProvider.Instance; } }
        public static ContactProvider Contact { get { return ContactProvider.Instance; } }
        public static ContactSupplementProvider ContactSupplement { get { return ContactSupplementProvider.Instance; } }
        public static ContactUserDefinedProvider ContactUserDefined { get { return ContactUserDefinedProvider.Instance; } }
        public static CountingMethodProvider CountingMethod { get { return CountingMethodProvider.Instance; } }
        public static CountryProvider Country { get { return CountryProvider.Instance; } }
        public static CreditProvider Credit { get { return CreditProvider.Instance; } }
        public static CreditLineProvider CreditLine { get { return CreditLineProvider.Instance; } }
        public static CurrencyProvider Currency { get { return CurrencyProvider.Instance; } }
        public static CurrencyRateProvider CurrencyRate { get { return CurrencyRateProvider.Instance; } }
        public static CustomerRequirementProvider CustomerRequirement { get { return CustomerRequirementProvider.Instance; } }
        public static CustomerRmaProvider CustomerRma { get { return CustomerRmaProvider.Instance; } }
        public static CustomerRmaLineProvider CustomerRmaLine { get { return CustomerRmaLineProvider.Instance; } }
        public static CustomerRmaLineAllocationProvider CustomerRmaLineAllocation { get { return CustomerRmaLineAllocationProvider.Instance; } }
		public static DataListNuggetStateProvider DataListNuggetState { get { return DataListNuggetStateProvider.Instance; } }
		public static DebitProvider Debit { get { return DebitProvider.Instance; } }
        public static DebitLineProvider DebitLine { get { return DebitLineProvider.Instance; } }
        public static DivisionProvider Division { get { return DivisionProvider.Instance; } }
        public static DropDownProvider DropDown { get { return DropDownProvider.Instance; } }
        public static DutyRateProvider DutyRate { get { return DutyRateProvider.Instance; } }
        public static ExcessProvider Excess { get { return ExcessProvider.Instance; } }
        public static FeedbackProvider Feedback { get { return FeedbackProvider.Instance; } }
        public static GlobalCountryListProvider GlobalCountryList { get { return GlobalCountryListProvider.Instance; } }
        public static GlobalCurrencyListProvider GlobalCurrencyList { get { return GlobalCurrencyListProvider.Instance; } }
        public static GoodsInProvider GoodsIn { get { return GoodsInProvider.Instance; } }
        public static GoodsInLineProvider GoodsInLine { get { return GoodsInLineProvider.Instance; } }
        public static HelpFaqProvider HelpFaq { get { return HelpFaqProvider.Instance; } }
        public static HelpGlossaryProvider HelpGlossary { get { return HelpGlossaryProvider.Instance; } }
        public static HelpGroupProvider HelpGroup { get { return HelpGroupProvider.Instance; } }
        public static HelpHowToProvider HelpHowTo { get { return HelpHowToProvider.Instance; } }
        public static HelpHowToStepProvider HelpHowToStep { get { return HelpHowToStepProvider.Instance; } }
        public static HistoryProvider History { get { return HistoryProvider.Instance; } }
        public static IncotermProvider Incoterm { get { return IncotermProvider.Instance; } }
        public static IndustryTypeProvider IndustryType { get { return IndustryTypeProvider.Instance; } }
        public static InvoiceProvider Invoice { get { return InvoiceProvider.Instance; } }
        public static InvoiceLineProvider InvoiceLine { get { return InvoiceLineProvider.Instance; } }
        public static InvoiceLineAllocationProvider InvoiceLineAllocation { get { return InvoiceLineAllocationProvider.Instance; } }

        public static LoginProvider Login { get { return LoginProvider.Instance; } }
        public static LoginPreferenceProvider LoginPreference { get { return LoginPreferenceProvider.Instance; } }
        public static LotProvider Lot { get { return LotProvider.Instance; } }
        public static MailGroupProvider MailGroup { get { return MailGroupProvider.Instance; } }
        public static MailGroupMemberProvider MailGroupMember { get { return MailGroupMemberProvider.Instance; } }
        public static MailMessageProvider MailMessage { get { return MailMessageProvider.Instance; } }
        public static MailMessageFolderProvider MailMessageFolder { get { return MailMessageFolderProvider.Instance; } }
        public static ManufacturerProvider Manufacturer { get { return ManufacturerProvider.Instance; } }
        public static ManufacturerLinkProvider ManufacturerLink { get { return ManufacturerLinkProvider.Instance; } }
        public static MaritalStatusProvider MaritalStatus { get { return MaritalStatusProvider.Instance; } }
        public static OfferProvider Offer { get { return OfferProvider.Instance; } }
        public static OfferStatusProvider OfferStatus { get { return OfferStatusProvider.Instance; } }
        public static PackageProvider Package { get { return PackageProvider.Instance; } }
        public static PartProvider Part { get { return PartProvider.Instance; } }
        public static PartSearchProvider PartSearch { get { return PartSearchProvider.Instance; } }
        public static ProductProvider Product { get { return ProductProvider.Instance; } }
        public static ProductTypeProvider ProductType { get { return ProductTypeProvider.Instance; } }
        public static PurchaseOrderProvider PurchaseOrder { get { return PurchaseOrderProvider.Instance; } }
        public static PurchaseOrderLineProvider PurchaseOrderLine { get { return PurchaseOrderLineProvider.Instance; } }
        //public static InternalPurchaseOrderLineProvider InternalPurchaseOrderLine { get { return InternalPurchaseOrderLineProvider.Instance; } }
        public static PurchaseOrderStatusProvider PurchaseOrderStatus { get { return PurchaseOrderStatusProvider.Instance; } }
        public static QuoteProvider Quote { get { return QuoteProvider.Instance; } }
        public static QuoteLineProvider QuoteLine { get { return QuoteLineProvider.Instance; } }
        public static QuoteStatusProvider QuoteStatus { get { return QuoteStatusProvider.Instance; } }
        public static ReasonProvider Reason { get { return ReasonProvider.Instance; } }
        public static RecentlyViewedProvider RecentlyViewed { get { return RecentlyViewedProvider.Instance; } }
        public static ReportProvider Report { get { return ReportProvider.Instance; } }
        public static ReportCategoryProvider ReportCategory { get { return ReportCategoryProvider.Instance; } }
        public static ReportCategoryGroupProvider ReportCategoryGroup { get { return ReportCategoryGroupProvider.Instance; } }
        public static ReportColumnProvider ReportColumn { get { return ReportColumnProvider.Instance; } }
        public static ReportColumnFormatProvider ReportColumnFormat { get { return ReportColumnFormatProvider.Instance; } }
        public static ReportParameterProvider ReportParameter { get { return ReportParameterProvider.Instance; } }
        public static ReportParameterTypeProvider ReportParameterType { get { return ReportParameterTypeProvider.Instance; } }
        public static RohsStatusProvider RohsStatus { get { return RohsStatusProvider.Instance; } }
        public static SaleCommissionProvider SaleCommission { get { return SaleCommissionProvider.Instance; } }
        public static SalesOrderProvider SalesOrder { get { return SalesOrderProvider.Instance; } }
        public static SalesOrderLineProvider SalesOrderLine { get { return SalesOrderLineProvider.Instance; } }
        public static SalesOrderStatusProvider SalesOrderStatus { get { return SalesOrderStatusProvider.Instance; } }
        public static SaleTypeProvider SaleType { get { return SaleTypeProvider.Instance; } }
        public static SecurityFunctionProvider SecurityFunction { get { return SecurityFunctionProvider.Instance; } }
        public static SecurityGroupProvider SecurityGroup { get { return SecurityGroupProvider.Instance; } }
        public static SecurityGroupLoginProvider SecurityGroupLogin { get { return SecurityGroupLoginProvider.Instance; } }
        public static SecurityGroupSecurityFunctionPermissionProvider SecurityGroupSecurityFunctionPermission { get { return SecurityGroupSecurityFunctionPermissionProvider.Instance; } }
        public static SequencerProvider Sequencer { get { return SequencerProvider.Instance; } }
        public static ServiceProvider Service { get { return ServiceProvider.Instance; } }
        public static SessionProvider Session { get { return SessionProvider.Instance; } }
        public static SettingProvider Setting { get { return SettingProvider.Instance; } }
        public static SettingItemProvider SettingItem { get { return SettingItemProvider.Instance; } }
        public static ShipViaProvider ShipVia { get { return ShipViaProvider.Instance; } }
        public static SitePageProvider SitePage { get { return SitePageProvider.Instance; } }
        public static SiteSectionProvider SiteSection { get { return SiteSectionProvider.Instance; } }
        public static SourcingLinkProvider SourcingLink { get { return SourcingLinkProvider.Instance; } }
        public static SourcingResultProvider SourcingResult { get { return SourcingResultProvider.Instance; } }
        public static StockProvider Stock { get { return StockProvider.Instance; } }
        public static StockImageProvider StockImage { get { return StockImageProvider.Instance; } }
        public static StockLogProvider StockLog { get { return StockLogProvider.Instance; } }
        public static StockLogReasonProvider StockLogReason { get { return StockLogReasonProvider.Instance; } }
        public static StockLogTypeProvider StockLogType { get { return StockLogTypeProvider.Instance; } }
        public static SupplierRmaProvider SupplierRma { get { return SupplierRmaProvider.Instance; } }
        public static SupplierRmaLineProvider SupplierRmaLine { get { return SupplierRmaLineProvider.Instance; } }
        public static SystemDocumentFooterProvider SystemDocumentFooter { get { return SystemDocumentFooterProvider.Instance; } }
        public static TaskStatusProvider TaskStatus { get { return TaskStatusProvider.Instance; } }
        public static TaxProvider Tax { get { return TaxProvider.Instance; } }
        public static TaxRateProvider TaxRate { get { return TaxRateProvider.Instance; } }
        public static GlobalTaxProvider GlobalTax { get { return GlobalTaxProvider.Instance; } }
        public static GlobalTaxRateProvider GlobalTaxRate { get { return GlobalTaxRateProvider.Instance; } }
        public static TeamProvider Team { get { return TeamProvider.Instance; } }
        public static TermsProvider Terms { get { return TermsProvider.Instance; } }
        public static ToDoProvider ToDo { get { return ToDoProvider.Instance; } }
        public static UsageProvider Usage { get { return UsageProvider.Instance; } }
        public static UserAuditProvider UserAudit { get { return UserAuditProvider.Instance; } }
        public static WarehouseProvider Warehouse { get { return WarehouseProvider.Instance; } }

        //[001] code start
        public static ReportNPRProvider ReportNPR { get { return ReportNPRProvider.Instance; } }
        //[001] code end

        //[002] code start
        public static EmailComposerProvider EmailComposer { get { return EmailComposerProvider.Instance; } }
        //[002] code end

        //[003] code start
        public static StockInfoProvider StockInfo { get { return StockInfoProvider.Instance; } }
        //[003] code end
        public static TabSecurityFunctionProvider TabSecurityFunction { get { return TabSecurityFunctionProvider.Instance; } }
        public static SupplierInvoiceProvider SupplierInvoice { get { return SupplierInvoiceProvider.Instance; } }
        public static SupplierInvoiceLineProvider SupplierInvoiceLine { get { return SupplierInvoiceLineProvider.Instance; } }
        public static PrinterProvider Printer { get { return PrinterProvider.Instance; } }
        //[004] code start
        public static ProductSourceProvider ProductSource { get { return ProductSourceProvider.Instance; } }
        //[004] code end
        public static CertificateCategoryProvider CertificateCategory { get { return CertificateCategoryProvider.Instance; } }
        public static CertificateProvider Certificate { get { return CertificateProvider.Instance; } }
        public static LabelPathProvider LabelPath { get { return LabelPathProvider.Instance; } }
        public static EPRProvider EPRProvider { get { return EPRProvider.Instance; } }
        public static InvoiceSettingProvider InvoiceSetting  { get { return InvoiceSettingProvider.Instance; } }
        public static EightDCodeProvider EightDCode { get { return EightDCodeProvider.Instance; } } 
        public static POQuoteProvider POQuote { get { return POQuoteProvider.Instance; } }
        public static POQuoteLineProvider POQuoteLine { get { return POQuoteLineProvider.Instance; } }
        public static PurchaseRequestLineDetailProvider PurchaseRequestLineDetail { get { return PurchaseRequestLineDetailProvider.Instance; } } 
        
        public static BOMProvider BOM { get { return BOMProvider.Instance; } }
        public static InternalPurchaseOrderProvider InternalPurchaseOrder { get { return InternalPurchaseOrderProvider.Instance; } }
        public static InternalPurchaseOrderLineProvider InternalPurchaseOrderLine { get { return InternalPurchaseOrderLineProvider.Instance; } }
        public static InternalPurchaseOrderStatusProvider InternalPurchaseOrderStatus { get { return InternalPurchaseOrderStatusProvider.Instance; } }
        public static CSVExportLogProvider CSVExportLog { get { return CSVExportLogProvider.Instance; } }
        public static ClientInvoiceProvider ClientInvoice { get { return ClientInvoiceProvider.Instance; } }
        public static ClientInvoiceLineProvider ClientInvoiceLine { get { return ClientInvoiceLineProvider.Instance; } }
        //[005] code start
        public static MSLLevelProvider MSLLevel { get { return MSLLevelProvider.Instance; } }
        //[005] code end
       // [006] start code
        public static GTUpdateProvider GTUpdate { get { return GTUpdateProvider.Instance; } }
      //  [006] end code
    }
}
