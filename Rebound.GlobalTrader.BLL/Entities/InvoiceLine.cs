//Marker     Changed by      Date         Remarks
//[001]      Vinay           14/09/2012   Add airwaybill search
//[002]      Abhinav         11/03/2014   ESMS#:- 103 Add another field to for in InvoiceLine as 'Ship ASAP'.
//[003]      Vinay           20/11/2014   Transfer SO serial no to invoice
//[004]     Shashi Keshar   16/12/2015      Batch Reference added to COF
//[005]     Aashu Singh     18/06/2018      [REB-12150]: Traceable, Trusted, Non-preferred - to be printed on the package slip
//[006]     Aashu Singh     10/07/2018      [REB-12593]: Show contract number under notes column.
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
    public partial class InvoiceLine : BizObject
    {

		#region Properties

        protected static DAL.InvoiceLineElement Settings
        {
			get { return Globals.Settings.InvoiceLines; }
		}

		/// <summary>
		/// InvoiceLineId
		/// </summary>
		public System.Int32 InvoiceLineId { get; set; }
		/// <summary>
		/// InvoiceNo
		/// </summary>
		public System.Int32 InvoiceNo { get; set; }
		/// <summary>
		/// SalesOrderLineNo
		/// </summary>
		public System.Int32? SalesOrderLineNo { get; set; }
		/// <summary>
		/// ShippedBy
		/// </summary>
		public System.Int32? ShippedBy { get; set; }
		/// <summary>
		/// ShippedDate
		/// </summary>
		public System.DateTime? ShippedDate { get; set; }
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// CustomerPart
		/// </summary>
		public System.String CustomerPart { get; set; }
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// FullPart
		/// </summary>
		public System.String FullPart { get; set; }
		/// <summary>
		/// Part
		/// </summary>
		public System.String Part { get; set; }
		/// <summary>
		/// DateCode
		/// </summary>
		public System.String DateCode { get; set; }
		/// <summary>
		/// ROHS
		/// </summary>
		public System.Byte? ROHS { get; set; }
		/// <summary>
		/// ManufacturerNo
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }
		/// <summary>
		/// PackageNo
		/// </summary>
		public System.Int32? PackageNo { get; set; }
		/// <summary>
		/// ProductNo
		/// </summary>
		public System.Int32? ProductNo { get; set; }
		/// <summary>
		/// Taxable
		/// </summary>
		public System.String Taxable { get; set; }
		/// <summary>
		/// Quantity
		/// </summary>
		public System.Int32? Quantity { get; set; }
		/// <summary>
		/// Price
		/// </summary>
		public System.Double? Price { get; set; }
		/// <summary>
		/// DatePromised
		/// </summary>
		public System.DateTime? DatePromised { get; set; }
		/// <summary>
		/// RequiredDate
		/// </summary>
		public System.DateTime? RequiredDate { get; set; }
		/// <summary>
		/// SalesOrderNo
		/// </summary>
		public System.Int32? SalesOrderNo { get; set; }
		/// <summary>
		/// ServiceNo
		/// </summary>
		public System.Int32? ServiceNo { get; set; }
		/// <summary>
		/// StockNo
		/// </summary>
		public System.Int32? StockNo { get; set; }
		/// <summary>
		/// Instructions
		/// </summary>
		public System.String Instructions { get; set; }
		/// <summary>
		/// Inactive
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// FullCustomerPart
		/// </summary>
		public System.String FullCustomerPart { get; set; }
		/// <summary>
		/// InvoiceId
		/// </summary>
		public System.Int32 InvoiceId { get; set; }
		/// <summary>
		/// InvoiceNumber
		/// </summary>
		public System.Int32 InvoiceNumber { get; set; }
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// InvoiceDate
		/// </summary>
		public System.DateTime InvoiceDate { get; set; }
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32? CompanyNo { get; set; }
		/// <summary>
		/// CustomerPO
		/// </summary>
		public System.String CustomerPO { get; set; }
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// SalesOrderNumber
		/// </summary>
		public System.Int32? SalesOrderNumber { get; set; }
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// DateOrdered
		/// </summary>
		public System.DateTime? DateOrdered { get; set; }
		/// <summary>
		/// SupplierRMANo
		/// </summary>
		public System.Int32? SupplierRMANo { get; set; }
		/// <summary>
		/// SupplierRMANumber
		/// </summary>
		public System.Int32? SupplierRMANumber { get; set; }
		/// <summary>
		/// SupplierRMALineNo
		/// </summary>
		public System.Int32? SupplierRMALineNo { get; set; }
		/// <summary>
		/// SupplierRMADate
		/// </summary>
		public System.DateTime? SupplierRMADate { get; set; }
		/// <summary>
		/// Salesman
		/// </summary>
		public System.Int32? Salesman { get; set; }
		/// <summary>
		/// SalesmanName
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// DivisionNo
		/// </summary>
		public System.Int32? DivisionNo { get; set; }
		/// <summary>
		/// TeamNo
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// ContactNo
		/// </summary>
		public System.Int32? ContactNo { get; set; }
		/// <summary>
		/// ContactName
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }
		/// <summary>
		/// CurrencyDescription
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// ProductName
		/// </summary>
		public System.String ProductName { get; set; }
		/// <summary>
		/// ProductDescription
		/// </summary>
		public System.String ProductDescription { get; set; }
		/// <summary>
		/// ProductDutyCode
		/// </summary>
		public System.String ProductDutyCode { get; set; }
		/// <summary>
		/// PackageName
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// PackageDescription
		/// </summary>
		public System.String PackageDescription { get; set; }
		/// <summary>
		/// ManufacturerName
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// ManufacturerCode
		/// </summary>
		public System.String ManufacturerCode { get; set; }
		/// <summary>
		/// InvoicePaid
		/// </summary>
		public System.Boolean InvoicePaid { get; set; }
		/// <summary>
		/// QuantityShipped
		/// </summary>
		public System.Int32 QuantityShipped { get; set; }
		/// <summary>
		/// LandedCost
		/// </summary>
		public System.Double? LandedCost { get; set; }
		/// <summary>
		/// LineSource
		/// </summary>
		public System.String LineSource { get; set; }
		/// <summary>
		/// QuantityOrdered
		/// </summary>
		public System.Int32 QuantityOrdered { get; set; }
		/// <summary>
		/// ShippedByName
		/// </summary>
		public System.String ShippedByName { get; set; }
		/// <summary>
		/// LineNotes
		/// </summary>
		public System.String LineNotes { get; set; }
		/// <summary>
		/// CountryOfManufactureName
		/// </summary>
		public System.String CountryOfManufactureName { get; set; }
        //[002] start
        /// <summary>
        /// ShipASAP
        /// </summary>
        public System.Boolean ShipASAP { get; set; }	

        //[002] end

        //[003] code start
        /// <summary>
        /// SOSerialNo
        /// </summary>
        public System.Int16? SOSerialNo { get; set; }
        //[003] code start
        
        //[004] code start here
        /// <summary>
        /// BatchReference
        /// </summary>
     public System.String BatchReference { get; set; }
        //[004] Code End Here

     public System.String ClientName { get; set; }
     public System.Double? ProductDutyRate { get; set; }
        public System.String SerialLineNos { get; set; }
         public System.String MSLLevel { get; set; }
        //[005] start
        /// <summary>
        /// AS9120
        /// </summary>
        public System.Boolean? AS9120 { get; set; }
        public System.Boolean? IsProdHazardous { get; set; }
        public System.Boolean? PrintHazardous { get; set; }

        /// ProductSource
        /// </summary>
        public System.Byte? ProductSource { get; set; }
        //[005] end
        //[006] start
        public System.String ContractNo { get; set; }
        //[006] end
		#endregion

		#region Methods
        //[001] code start
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_InvoiceLine]
		/// </summary>
        public static List<InvoiceLine> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includePaid, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? invoiceDateFrom, System.DateTime? invoiceDateTo, System.Boolean? recentOnly, System.String airWayBill, Boolean IsGlobalLogin, System.Int32? clientSearchId)
        {
            List<InvoiceLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLine.DataListNugget(clientId, teamId, divisionId, loginId, pageIndex, pageSize, orderBy, sortDir, partSearch, contactSearch, cmSearch, salesmanSearch, customerPoSearch, includePaid, invoiceNoLo, invoiceNoHi, salesOrderNoLo, salesOrderNoHi, invoiceDateFrom, invoiceDateTo, recentOnly, airWayBill, IsGlobalLogin, clientSearchId);
            if (lstDetails == null)
            {
				return new List<InvoiceLine>();
            }
            else
            {
				List<InvoiceLine> lst = new List<InvoiceLine>();
                foreach (InvoiceLineDetails objDetails in lstDetails)
                {
					Rebound.GlobalTrader.BLL.InvoiceLine obj = new Rebound.GlobalTrader.BLL.InvoiceLine();
					obj.InvoiceId = objDetails.InvoiceId;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.Part = objDetails.Part;
					obj.Price = objDetails.Price;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.Quantity = objDetails.Quantity;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.CompanyName = objDetails.CompanyName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CustomerPO = objDetails.CustomerPO;
					obj.ROHS = objDetails.ROHS;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
                    obj.ClientName = objDetails.ClientName;
                    obj.ClientNo = objDetails.ClientNo;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
        //[001] code end
		/// <summary>
		/// Delete
		/// Calls [usp_delete_InvoiceLine]
		/// </summary>
        /// Ref:68 Stock log Error
        public static bool Delete(System.Int32? invoiceLineId, System.Int32? updatedBy)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLine.Delete(invoiceLineId, updatedBy);
		}
		      /// <summary>
		/// InsertByShippingSOLine
		/// Calls [usp_insert_InvoiceLine_by_Shipping_SO_Line]
		/// </summary>
		//[002] start
        public static Int32 InsertByShippingSOLine(System.Int32? invoiceNo, System.Int32? salesOrderLineNo, System.Int32? allocationNo, System.Int32? quantityShipped, System.Int32? shippedBy, System.DateTime? shippedDate, System.Int32? updatedBy, System.String fullPart, System.String part, System.String dateCode, System.Byte? rohs, System.Int32? manufacturerNo, System.Int32? packageNo, System.Int32? productNo, System.String taxable, System.Int32? quantity, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.Int32? salesOrderNo, System.Int32? serviceNo, System.Int32? stockNo, System.String instructions, System.String customerPart, System.String notes, System.Boolean shipASAP)
        {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLine.InsertByShippingSOLine(invoiceNo, salesOrderLineNo, allocationNo, quantityShipped, shippedBy, shippedDate, updatedBy, fullPart, part, dateCode, rohs, manufacturerNo, packageNo, productNo, taxable, quantity, price, datePromised, requiredDate, salesOrderNo, serviceNo, stockNo, instructions, customerPart, notes, shipASAP);
			return objReturn;
            //[002] end
		}
		/// <summary>
		/// InsertByShippingSRMALine
		/// Calls [usp_insert_InvoiceLine_by_Shipping_SRMALine]
		/// </summary>
        public static Int32 InsertByShippingSRMALine(System.Int32? invoiceNo, System.Int32? srmaLineNo, System.Int32? allocationNo, System.Int32? quantityShipped, System.Int32? shippedBy, System.DateTime? shippedDate, System.Int32? updatedBy, System.String fullPart, System.String part, System.String dateCode, System.Byte? rohs, System.Int32? manufacturerNo, System.Int32? packageNo, System.Int32? productNo, System.String taxable, System.Int32? quantity, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.Int32? salesOrderNo, System.Int32? serviceNo, System.Int32? stockNo, System.String instructions, System.String customerPart)
        {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLine.InsertByShippingSRMALine(invoiceNo, srmaLineNo, allocationNo, quantityShipped, shippedBy, shippedDate, updatedBy, fullPart, part, dateCode, rohs, manufacturerNo, packageNo, productNo, taxable, quantity, price, datePromised, requiredDate, salesOrderNo, serviceNo, stockNo, instructions, customerPart);
			return objReturn;
		}
		/// <summary>
		/// InsertForManual
		/// Calls [usp_insert_InvoiceLine_for_Manual]
		/// </summary>
        public static Int32 InsertForManual(System.Int32? invoiceNo, System.Int32? salesOrderLineNo, System.Int32? shippedBy, System.DateTime? shippedDate, System.String notes, System.Int32? updatedBy, System.String fullPart, System.String part, System.String dateCode, System.Byte? rohs, System.Int32? manufacturerNo, System.Int32? packageNo, System.Int32? productNo, System.String taxable, System.Int32? quantity, System.Double? cost, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.Int32? salesOrderNo, System.Int32? serviceNo, System.Int32? stockNo, System.String instructions, System.String customerPart, System.Boolean? printHazardous)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLine.InsertForManual(invoiceNo, salesOrderLineNo, shippedBy, shippedDate, notes, updatedBy, fullPart, part, dateCode, rohs, manufacturerNo, packageNo, productNo, taxable, quantity, cost, price, datePromised, requiredDate, salesOrderNo, serviceNo, stockNo, instructions, customerPart, printHazardous);
			return objReturn;
		}
		/// <summary>
		/// InsertForService
		/// Calls [usp_insert_InvoiceLine_for_Service]
		/// </summary>
        public static Int32 InsertForService(System.Int32? invoiceNo, System.Int32? salesOrderLineNo, System.Int32? shippedBy, System.DateTime? shippedDate, System.String notes, System.Int32? updatedBy, System.String fullPart, System.String part, System.String dateCode, System.Byte? rohs, System.Int32? manufacturerNo, System.Int32? packageNo, System.Int32? productNo, System.String taxable, System.Int32? quantity, System.Double? cost, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.Int32? salesOrderNo, System.Int32? serviceNo, System.Int32? stockNo, System.String instructions, System.String customerPart, System.Boolean? printHazardous)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLine.InsertForService(invoiceNo, salesOrderLineNo, shippedBy, shippedDate, notes, updatedBy, fullPart, part, dateCode, rohs, manufacturerNo, packageNo, productNo, taxable, quantity, cost, price, datePromised, requiredDate, salesOrderNo, serviceNo, stockNo, instructions, customerPart, printHazardous);
			return objReturn;
		}
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_InvoiceLine]
		/// </summary>
        public static List<InvoiceLine> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includePaid, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? invoiceDateFrom, System.DateTime? invoiceDateTo)
        {
			List<InvoiceLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLine.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesmanSearch, customerPoSearch, includePaid, invoiceNoLo, invoiceNoHi, salesOrderNoLo, salesOrderNoHi, invoiceDateFrom, invoiceDateTo);
            if (lstDetails == null)
            {
				return new List<InvoiceLine>();
            }
            else
            {
				List<InvoiceLine> lst = new List<InvoiceLine>();
                foreach (InvoiceLineDetails objDetails in lstDetails)
                {
					Rebound.GlobalTrader.BLL.InvoiceLine obj = new Rebound.GlobalTrader.BLL.InvoiceLine();
					obj.InvoiceLineId = objDetails.InvoiceLineId;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.Quantity = objDetails.Quantity;
					obj.Part = objDetails.Part;
					obj.Price = objDetails.Price;
					obj.ROHS = objDetails.ROHS;
					obj.CustomerPO = objDetails.CustomerPO;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_InvoiceLine]
		/// </summary>
        public static InvoiceLine Get(System.Int32? invoiceLineId)
        {
			Rebound.GlobalTrader.DAL.InvoiceLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLine.Get(invoiceLineId);
            if (objDetails == null)
            {
				return null;
            }
            else
            {
				InvoiceLine obj = new InvoiceLine();
				obj.InvoiceNo = objDetails.InvoiceNo;
				obj.InvoiceNumber = objDetails.InvoiceNumber;
				obj.InvoiceLineId = objDetails.InvoiceLineId;
				obj.InvoiceDate = objDetails.InvoiceDate;
				obj.ClientNo = objDetails.ClientNo;
				obj.DateOrdered = objDetails.DateOrdered;
				obj.CustomerPO = objDetails.CustomerPO;
				obj.SalesOrderNo = objDetails.SalesOrderNo;
				obj.SalesOrderNumber = objDetails.SalesOrderNumber;
				obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
				obj.SupplierRMANo = objDetails.SupplierRMANo;
				obj.SupplierRMANumber = objDetails.SupplierRMANumber;
				obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
				obj.SupplierRMADate = objDetails.SupplierRMADate;
				obj.Salesman = objDetails.Salesman;
				obj.SalesmanName = objDetails.SalesmanName;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.TeamNo = objDetails.TeamNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.ContactNo = objDetails.ContactNo;
				obj.ContactName = objDetails.ContactName;
				obj.Price = objDetails.Price;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.ROHS = objDetails.ROHS;
				obj.CustomerPart = objDetails.CustomerPart;
				obj.Quantity = objDetails.Quantity;
				obj.DateCode = objDetails.DateCode;
				obj.DatePromised = objDetails.DatePromised;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.ProductNo = objDetails.ProductNo;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.ProductDutyCode = objDetails.ProductDutyCode;
				obj.PackageNo = objDetails.PackageNo;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.InvoicePaid = objDetails.InvoicePaid;
				obj.QuantityShipped = objDetails.QuantityShipped;
				obj.LandedCost = objDetails.LandedCost;
				obj.LineSource = objDetails.LineSource;
				obj.QuantityOrdered = objDetails.QuantityOrdered;
				obj.Taxable = objDetails.Taxable;
				obj.ShippedBy = objDetails.ShippedBy;
				obj.ShippedByName = objDetails.ShippedByName;
				obj.ShippedDate = objDetails.ShippedDate;
				obj.LineNotes = objDetails.LineNotes;
				obj.Inactive = objDetails.Inactive;
				obj.ServiceNo = objDetails.ServiceNo;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
                //[0002] start
                obj.ShipASAP = objDetails.ShipASAP;
                //[0002] end
                obj.ProductDutyRate = objDetails.ProductDutyRate;
                obj.MSLLevel = objDetails.MSLLevel;
                obj.IsProdHazardous = objDetails.IsProdHazardous;
                obj.PrintHazardous = objDetails.PrintHazardous;
                objDetails = null;
               
				return obj;
			}
		}
		/// <summary>
		/// GetListCandidatesForCustomerRMA
		/// Calls [usp_selectAll_InvoiceLine_candidates_for_CustomerRMA]
		/// </summary>
        public static List<InvoiceLine> GetListCandidatesForCustomerRMA(System.Int32? customerRmaId)
        {
			List<InvoiceLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLine.GetListCandidatesForCustomerRMA(customerRmaId);
            if (lstDetails == null)
            {
				return new List<InvoiceLine>();
            }
            else
            {
				List<InvoiceLine> lst = new List<InvoiceLine>();
                foreach (InvoiceLineDetails objDetails in lstDetails)
                {
					Rebound.GlobalTrader.BLL.InvoiceLine obj = new Rebound.GlobalTrader.BLL.InvoiceLine();
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceLineId = objDetails.InvoiceLineId;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.ClientNo = objDetails.ClientNo;
					obj.DateOrdered = objDetails.DateOrdered;
					obj.CustomerPO = objDetails.CustomerPO;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
					obj.SupplierRMADate = objDetails.SupplierRMADate;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.Price = objDetails.Price;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.Quantity = objDetails.Quantity;
					obj.DateCode = objDetails.DateCode;
					obj.DatePromised = objDetails.DatePromised;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ProductDutyCode = objDetails.ProductDutyCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.InvoicePaid = objDetails.InvoicePaid;
					obj.QuantityShipped = objDetails.QuantityShipped;
					obj.LandedCost = objDetails.LandedCost;
					obj.LineSource = objDetails.LineSource;
					obj.QuantityOrdered = objDetails.QuantityOrdered;
					obj.Taxable = objDetails.Taxable;
					obj.ShippedBy = objDetails.ShippedBy;
					obj.ShippedByName = objDetails.ShippedByName;
					obj.ShippedDate = objDetails.ShippedDate;
					obj.LineNotes = objDetails.LineNotes;
					obj.Inactive = objDetails.Inactive;
					obj.ServiceNo = objDetails.ServiceNo;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForInvoice
		/// Calls [usp_selectAll_InvoiceLine_for_Invoice]
		/// </summary>
        public static List<InvoiceLine> GetListForInvoice(System.Int32? invoiceId)
        {
			List<InvoiceLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLine.GetListForInvoice(invoiceId);
            if (lstDetails == null)
            {
				return new List<InvoiceLine>();
            }
            else
            {
				List<InvoiceLine> lst = new List<InvoiceLine>();
                foreach (InvoiceLineDetails objDetails in lstDetails)
                {
					Rebound.GlobalTrader.BLL.InvoiceLine obj = new Rebound.GlobalTrader.BLL.InvoiceLine();
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceLineId = objDetails.InvoiceLineId;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.ClientNo = objDetails.ClientNo;
					obj.DateOrdered = objDetails.DateOrdered;
					obj.CustomerPO = objDetails.CustomerPO;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
					obj.SupplierRMADate = objDetails.SupplierRMADate;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.Price = objDetails.Price;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.Quantity = objDetails.Quantity;
					obj.DateCode = objDetails.DateCode;
					obj.DatePromised = objDetails.DatePromised;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ProductDutyCode = objDetails.ProductDutyCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.InvoicePaid = objDetails.InvoicePaid;
					obj.QuantityShipped = objDetails.QuantityShipped;
					obj.LandedCost = objDetails.LandedCost;
					obj.LineSource = objDetails.LineSource;
					obj.QuantityOrdered = objDetails.QuantityOrdered;
					obj.Taxable = objDetails.Taxable;
					obj.ShippedBy = objDetails.ShippedBy;
					obj.ShippedByName = objDetails.ShippedByName;
					obj.ShippedDate = objDetails.ShippedDate;
					obj.LineNotes = objDetails.LineNotes;
					obj.Inactive = objDetails.Inactive;
					obj.ServiceNo = objDetails.ServiceNo;
					obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
                    //[003] code start
                    obj.SOSerialNo = objDetails.SOSerialNo;
                    //[003] code end
                    //[004] code start
                    obj.BatchReference = objDetails.BatchReference;
                    //code end
                    obj.SerialLineNos = objDetails.SerialLineNos;
                    obj.MSLLevel = objDetails.MSLLevel;
                    //[005] start
                    obj.AS9120 = objDetails.AS9120;
                    obj.ProductSource = objDetails.ProductSource;
                    //[005] end
                    //[006] start
                    obj.ContractNo = objDetails.ContractNo;
                    //[006] end
                    obj.PrintHazardous = objDetails.PrintHazardous;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForSalesOrder
		/// Calls [usp_selectAll_InvoiceLine_for_SalesOrder]
		/// </summary>
        public static List<InvoiceLine> GetListForSalesOrder(System.Int32? salesOrderId)
        {
			List<InvoiceLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLine.GetListForSalesOrder(salesOrderId);
            if (lstDetails == null)
            {
				return new List<InvoiceLine>();
            }
            else
            {
				List<InvoiceLine> lst = new List<InvoiceLine>();
                foreach (InvoiceLineDetails objDetails in lstDetails)
                {
					Rebound.GlobalTrader.BLL.InvoiceLine obj = new Rebound.GlobalTrader.BLL.InvoiceLine();
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.InvoiceLineId = objDetails.InvoiceLineId;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.Part = objDetails.Part;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.ROHS = objDetails.ROHS;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.DateCode = objDetails.DateCode;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.Price = objDetails.Price;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.ShippedByName = objDetails.ShippedByName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForSalesOrderLine
		/// Calls [usp_selectAll_InvoiceLine_for_SalesOrderLine]
		/// </summary>
        public static List<InvoiceLine> GetListForSalesOrderLine(System.Int32? salesOrderLineId)
        {
			List<InvoiceLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLine.GetListForSalesOrderLine(salesOrderLineId);
            if (lstDetails == null)
            {
				return new List<InvoiceLine>();
            }
            else
            {
				List<InvoiceLine> lst = new List<InvoiceLine>();
                foreach (InvoiceLineDetails objDetails in lstDetails)
                {
					Rebound.GlobalTrader.BLL.InvoiceLine obj = new Rebound.GlobalTrader.BLL.InvoiceLine();
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceLineId = objDetails.InvoiceLineId;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.ClientNo = objDetails.ClientNo;
					obj.DateOrdered = objDetails.DateOrdered;
					obj.CustomerPO = objDetails.CustomerPO;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
					obj.SupplierRMADate = objDetails.SupplierRMADate;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.Price = objDetails.Price;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.Quantity = objDetails.Quantity;
					obj.DateCode = objDetails.DateCode;
					obj.DatePromised = objDetails.DatePromised;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ProductDutyCode = objDetails.ProductDutyCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.InvoicePaid = objDetails.InvoicePaid;
					obj.QuantityShipped = objDetails.QuantityShipped;
					obj.LandedCost = objDetails.LandedCost;
					obj.LineSource = objDetails.LineSource;
					obj.QuantityOrdered = objDetails.QuantityOrdered;
					obj.Taxable = objDetails.Taxable;
					obj.ShippedBy = objDetails.ShippedBy;
					obj.ShippedByName = objDetails.ShippedByName;
					obj.ShippedDate = objDetails.ShippedDate;
					obj.LineNotes = objDetails.LineNotes;
					obj.Inactive = objDetails.Inactive;
					obj.ServiceNo = objDetails.ServiceNo;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListInactiveForInvoice
		/// Calls [usp_selectAll_InvoiceLine_Inactive_for_Invoice]
		/// </summary>
        public static List<InvoiceLine> GetListInactiveForInvoice(System.Int32? invoiceId)
        {
			List<InvoiceLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLine.GetListInactiveForInvoice(invoiceId);
            if (lstDetails == null)
            {
				return new List<InvoiceLine>();
            }
            else
            {
				List<InvoiceLine> lst = new List<InvoiceLine>();
                foreach (InvoiceLineDetails objDetails in lstDetails)
                {
					Rebound.GlobalTrader.BLL.InvoiceLine obj = new Rebound.GlobalTrader.BLL.InvoiceLine();
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceLineId = objDetails.InvoiceLineId;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.ClientNo = objDetails.ClientNo;
					obj.DateOrdered = objDetails.DateOrdered;
					obj.CustomerPO = objDetails.CustomerPO;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
					obj.SupplierRMADate = objDetails.SupplierRMADate;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.Price = objDetails.Price;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.Quantity = objDetails.Quantity;
					obj.DateCode = objDetails.DateCode;
					obj.DatePromised = objDetails.DatePromised;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ProductDutyCode = objDetails.ProductDutyCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.InvoicePaid = objDetails.InvoicePaid;
					obj.QuantityShipped = objDetails.QuantityShipped;
					obj.LandedCost = objDetails.LandedCost;
					obj.LineSource = objDetails.LineSource;
					obj.QuantityOrdered = objDetails.QuantityOrdered;
					obj.Taxable = objDetails.Taxable;
					obj.ShippedBy = objDetails.ShippedBy;
					obj.ShippedByName = objDetails.ShippedByName;
					obj.ShippedDate = objDetails.ShippedDate;
					obj.LineNotes = objDetails.LineNotes;
					obj.Inactive = objDetails.Inactive;
					obj.ServiceNo = objDetails.ServiceNo;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_InvoiceLine]
		/// </summary>
		public static bool Update(System.Int32? invoiceLineId, System.Int32? salesOrderLineNo, System.Int32? shippedBy, System.DateTime? shippedDate, System.String customerPart, System.String notes, System.Int32? updatedBy,System.Boolean? printHazardous) {
            return Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLine.Update(invoiceLineId, salesOrderLineNo, shippedBy, shippedDate, customerPart, notes, updatedBy, printHazardous);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_InvoiceLine]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLine.Update(InvoiceLineId, SalesOrderLineNo, ShippedBy, ShippedDate, CustomerPart, Notes, UpdatedBy, PrintHazardous);
		}

        private static InvoiceLine PopulateFromDBDetailsObject(InvoiceLineDetails obj)
        {
			InvoiceLine objNew = new InvoiceLine();
			objNew.InvoiceLineId = obj.InvoiceLineId;
			objNew.InvoiceNo = obj.InvoiceNo;
			objNew.SalesOrderLineNo = obj.SalesOrderLineNo;
			objNew.ShippedBy = obj.ShippedBy;
			objNew.ShippedDate = obj.ShippedDate;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.CustomerPart = obj.CustomerPart;
			objNew.Notes = obj.Notes;
			objNew.FullPart = obj.FullPart;
			objNew.Part = obj.Part;
			objNew.DateCode = obj.DateCode;
			objNew.ROHS = obj.ROHS;
			objNew.ManufacturerNo = obj.ManufacturerNo;
			objNew.PackageNo = obj.PackageNo;
			objNew.ProductNo = obj.ProductNo;
			objNew.Taxable = obj.Taxable;
			objNew.Quantity = obj.Quantity;
			objNew.Price = obj.Price;
			objNew.DatePromised = obj.DatePromised;
			objNew.RequiredDate = obj.RequiredDate;
			objNew.SalesOrderNo = obj.SalesOrderNo;
			objNew.ServiceNo = obj.ServiceNo;
			objNew.StockNo = obj.StockNo;
			objNew.Instructions = obj.Instructions;
			objNew.Inactive = obj.Inactive;
			objNew.FullCustomerPart = obj.FullCustomerPart;
			objNew.InvoiceId = obj.InvoiceId;
			objNew.InvoiceNumber = obj.InvoiceNumber;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.InvoiceDate = obj.InvoiceDate;
			objNew.CompanyName = obj.CompanyName;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.CustomerPO = obj.CustomerPO;
			objNew.RowNum = obj.RowNum;
			objNew.RowCnt = obj.RowCnt;
			objNew.SalesOrderNumber = obj.SalesOrderNumber;
			objNew.ClientNo = obj.ClientNo;
			objNew.DateOrdered = obj.DateOrdered;
			objNew.SupplierRMANo = obj.SupplierRMANo;
			objNew.SupplierRMANumber = obj.SupplierRMANumber;
			objNew.SupplierRMALineNo = obj.SupplierRMALineNo;
			objNew.SupplierRMADate = obj.SupplierRMADate;
			objNew.Salesman = obj.Salesman;
			objNew.SalesmanName = obj.SalesmanName;
			objNew.DivisionNo = obj.DivisionNo;
			objNew.TeamNo = obj.TeamNo;
			objNew.ContactNo = obj.ContactNo;
			objNew.ContactName = obj.ContactName;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.CurrencyDescription = obj.CurrencyDescription;
			objNew.ProductName = obj.ProductName;
			objNew.ProductDescription = obj.ProductDescription;
			objNew.ProductDutyCode = obj.ProductDutyCode;
			objNew.PackageName = obj.PackageName;
			objNew.PackageDescription = obj.PackageDescription;
			objNew.ManufacturerName = obj.ManufacturerName;
			objNew.ManufacturerCode = obj.ManufacturerCode;
			objNew.InvoicePaid = obj.InvoicePaid;
			objNew.QuantityShipped = obj.QuantityShipped;
			objNew.LandedCost = obj.LandedCost;
			objNew.LineSource = obj.LineSource;
			objNew.QuantityOrdered = obj.QuantityOrdered;
			objNew.ShippedByName = obj.ShippedByName;
			objNew.LineNotes = obj.LineNotes;
			objNew.CountryOfManufactureName = obj.CountryOfManufactureName;
			return objNew;
		}

		#endregion

	}
}