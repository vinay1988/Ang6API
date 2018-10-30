/*

Marker     changed by      date         Remarks

[001]      Abhinav       17/11/20011   ESMS Ref:25 & 34  - Virtual Stock Update & Closeing of line CRMA


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
using System.Collections.Generic;
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL {
	public partial class CustomerRmaLine : BizObject {

		#region Properties

		protected static DAL.CustomerRmaLineElement Settings {
			get { return Globals.Settings.CustomerRmaLines; }
		}

		/// <summary>
		/// CustomerRMALineId
		/// </summary>
		public System.Int32 CustomerRMALineId { get; set; }
		/// <summary>
		/// CustomerRMANo
		/// </summary>
		public System.Int32 CustomerRMANo { get; set; }
		/// <summary>
		/// InvoiceLineNo
		/// </summary>
		public System.Int32 InvoiceLineNo { get; set; }
		/// <summary>
		/// ReturnDate
		/// </summary>
		public System.DateTime? ReturnDate { get; set; }
		/// <summary>
		/// Reason
		/// </summary>
		public System.String Reason { get; set; }

        /// <summary>
        /// Reason1
        /// </summary>
        public System.String Reason1 { get; set; }
        /// <summary>
        /// Reason2
        /// </summary>
        public System.String Reason2 { get; set; }

        /// <summary>
        /// Reason1 Value
        /// </summary>
        public System.String Reason1Val { get; set; }

        /// <summary>
        /// Reason2 Value
        /// </summary>
        public System.String Reason2Val { get; set; }
		/// <summary>
		/// Quantity
		/// </summary>
		public System.Int32? Quantity { get; set; }
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// CustomerRMAId
		/// </summary>
		public System.Int32 CustomerRMAId { get; set; }
		/// <summary>
		/// CustomerRMANumber
		/// </summary>
		public System.Int32 CustomerRMANumber { get; set; }
		/// <summary>
		/// CustomerRMADate
		/// </summary>
		public System.DateTime CustomerRMADate { get; set; }
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// InvoiceNumber
		/// </summary>
		public System.Int32 InvoiceNumber { get; set; }
		/// <summary>
		/// InvoiceNo
		/// </summary>
		public System.Int32? InvoiceNo { get; set; }
		/// <summary>
		/// ROHS
		/// </summary>
		public System.Byte ROHS { get; set; }
		/// <summary>
		/// Part
		/// </summary>
		public System.String Part { get; set; }
		/// <summary>
		/// ContactName
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// ContactNo
		/// </summary>
		public System.Int32? ContactNo { get; set; }
		/// <summary>
		/// ManufacturerNo
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }
		/// <summary>
		/// ManufacturerCode
		/// </summary>
		public System.String ManufacturerCode { get; set; }
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// QuantityReceived
		/// </summary>
		public System.Int32? QuantityReceived { get; set; }
		/// <summary>
		/// SalesmanName
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// InvoiceDate
		/// </summary>
		public System.DateTime InvoiceDate { get; set; }
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
		/// <summary>
		/// Salesman
		/// </summary>
		public System.Int32 Salesman { get; set; }
		/// <summary>
		/// DivisionNo
		/// </summary>
		public System.Int32? DivisionNo { get; set; }
		/// <summary>
		/// TeamNo
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// QuantityAllocated
		/// </summary>
		public System.Int32? QuantityAllocated { get; set; }
		/// <summary>
		/// ProductNo
		/// </summary>
		public System.Int32? ProductNo { get; set; }
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
		/// FullPart
		/// </summary>
		public System.String FullPart { get; set; }
		/// <summary>
		/// CustomerPart
		/// </summary>
		public System.String CustomerPart { get; set; }
		/// <summary>
		/// ManufacturerName
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// PackageNo
		/// </summary>
		public System.Int32? PackageNo { get; set; }
		/// <summary>
		/// DateCode
		/// </summary>
		public System.String DateCode { get; set; }
		/// <summary>
		/// PackageName
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// PackageDescription
		/// </summary>
		public System.String PackageDescription { get; set; }
		/// <summary>
		/// Price
		/// </summary>
		public System.Double? Price { get; set; }
		/// <summary>
		/// LandedCost
		/// </summary>
		public System.Double? LandedCost { get; set; }
		/// <summary>
		/// LineNotes
		/// </summary>
		public System.String LineNotes { get; set; }
		/// <summary>
		/// InvoiceLineAllocationId
		/// </summary>
		public System.Int32 InvoiceLineAllocationId { get; set; }
        
        public System.Boolean Closed { get; set; }
        /// <summary>        
        /// Shipped Quantity (from usp_select_CustomerRMA)
        /// </summary>
        public System.Int32? QuantityShipped { get; set; }
        /// <summary>
        /// CRMA Quantity (from usp_select_CustomerRMA)
        /// </summary>
        public System.Int32? QuantityCRMA { get; set; }

        /// <summary>
        /// Available Qty for CRMA to add(from usp_GetQty_CustomerRMALine_for_CustomerRMA)
        /// </summary>
        public System.Int32? QuantityAvailable { get; set; }        

        /// <summary>
        /// Stock Id from tbStock
        /// </summary>
        public System.Int32? StockNo { get; set; }
        /// <summary>
        /// CreditIds
        /// </summary>
        public System.String CreditIds { get; set; }
        /// <summary>
        /// CreditNumbers
        /// </summary>
        public System.String CreditNumbers { get; set; }

        /// <summary>
        /// Root Cause
        /// </summary>
        public System.String RootCause { get; set; }

        public System.Int32? ParentCustomerRMALineNo { get; set; }
        public System.String ClientName { get; set; }

        public System.Boolean Avoidable { get; set; }
        public System.Boolean? IsProdHazardous { get; set; }
        public System.Boolean? PrintHazardous { get; set; }
		#endregion

		#region Methods

		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_CustomerRMALine]
		/// </summary>
        public static List<CustomerRmaLine> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String crmaNotesSearch, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.DateTime? customerRmaDateFrom, System.DateTime? customerRmaDateTo, System.Boolean? includeReceived, System.Boolean? recentOnly, System.Boolean? PohubOnly, System.Int32? clientSearch, Boolean IsGlobalLogin)
        {
			List<CustomerRmaLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.DataListNugget(clientId, teamId, divisionId, loginId, pageIndex, pageSize, orderBy, sortDir, partSearch, contactSearch, cmSearch, salesmanSearch, crmaNotesSearch, invoiceNoLo, invoiceNoHi, customerRmaNoLo, customerRmaNoHi, customerRmaDateFrom, customerRmaDateTo, includeReceived, recentOnly,PohubOnly, clientSearch,  IsGlobalLogin);
			if (lstDetails == null) {
				return new List<CustomerRmaLine>();
			} else {
				List<CustomerRmaLine> lst = new List<CustomerRmaLine>();
				foreach (CustomerRmaLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CustomerRmaLine obj = new Rebound.GlobalTrader.BLL.CustomerRmaLine();
					obj.CustomerRMAId = objDetails.CustomerRMAId;
					obj.CustomerRMANumber = objDetails.CustomerRMANumber;
					obj.CustomerRMADate = objDetails.CustomerRMADate;
					obj.CompanyName = objDetails.CompanyName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.ROHS = objDetails.ROHS;
					obj.Part = objDetails.Part;
					obj.Quantity = objDetails.Quantity;
					obj.ContactName = objDetails.ContactName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
                    obj.ClientNo=objDetails.ClientNo;
                    obj.ClientName=objDetails.ClientName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// DataListNuggetReadyToReceive
		/// Calls [usp_datalistnugget_CustomerRMALine_ReadyToReceive]
		/// </summary>
        public static List<CustomerRmaLine> DataListNuggetReadyToReceive(System.Int32? clientId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String crmaNotesSearch, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.DateTime? customerRmaDateFrom, System.DateTime? customerRmaDateTo, System.Int32? clientSearch, Boolean IsGlobalLogin)
        {
			List<CustomerRmaLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.DataListNuggetReadyToReceive(clientId, pageIndex, pageSize, orderBy, sortDir, partSearch, contactSearch, cmSearch, salesmanSearch, crmaNotesSearch, invoiceNoLo, invoiceNoHi, customerRmaNoLo, customerRmaNoHi, customerRmaDateFrom, customerRmaDateTo,  clientSearch,  IsGlobalLogin);
			if (lstDetails == null) {
				return new List<CustomerRmaLine>();
			} else {
				List<CustomerRmaLine> lst = new List<CustomerRmaLine>();
				foreach (CustomerRmaLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CustomerRmaLine obj = new Rebound.GlobalTrader.BLL.CustomerRmaLine();
					obj.CustomerRMAId = objDetails.CustomerRMAId;
					obj.CustomerRMANumber = objDetails.CustomerRMANumber;
					obj.CustomerRMADate = objDetails.CustomerRMADate;
					obj.CompanyName = objDetails.CompanyName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.Quantity = objDetails.Quantity;
					obj.QuantityReceived = objDetails.QuantityReceived;
					obj.ROHS = objDetails.ROHS;
					obj.Part = objDetails.Part;
					obj.ContactName = objDetails.ContactName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.ClientName = objDetails.ClientName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Delete
		/// Calls [usp_delete_CustomerRMALine]
		/// </summary>
		public static bool Delete(System.Int32? customerRmaLineId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.Delete(customerRmaLineId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CustomerRMALine]
		/// </summary>
        public static Int32 Insert(System.Int32? customerRmaNo, System.Int32? invoiceLineNo, System.DateTime? returnDate, System.String reason, System.String reason1, System.String reason2, System.Int32? quantity, System.String notes, System.String rootCause, System.Int32? updatedBy, out int customerRMAId, out int customerRMANumber, System.Int32? stockNo, System.Boolean? avoidable, System.Boolean? printHazardous)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.Insert(customerRmaNo, invoiceLineNo, returnDate, reason, reason1, reason2, quantity, notes, rootCause, updatedBy, out  customerRMAId, out customerRMANumber, stockNo, avoidable, printHazardous);
			return objReturn;
		}

        /// <summary>
        /// Close
        /// Calls [usp_UpdateClose_CustomerRMALine]
        /// </summary>
        public static bool UpdateClose(System.Int32? customerRmaLineId,System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.UpdateClose(customerRmaLineId, updatedBy);
        }

		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_CustomerRMALine]
		/// </summary>
		public Int32 Insert() {
            int customerRMAId =0;
            int customerRMANumber = 0;
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.Insert(CustomerRMANo, InvoiceLineNo, ReturnDate, Reason, Reason1, Reason2, Quantity, Notes, RootCause, UpdatedBy, out  customerRMAId, out customerRMANumber, null , Avoidable,false);
		}
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_CustomerRMALine]
		/// </summary>
		public static List<CustomerRmaLine> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesman, System.String crmaNotesSearch, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.DateTime? customerRmaDateFrom, System.DateTime? customerRmaDateTo) {
			List<CustomerRmaLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesman, crmaNotesSearch, invoiceNoLo, invoiceNoHi, customerRmaNoLo, customerRmaNoHi, customerRmaDateFrom, customerRmaDateTo);
			if (lstDetails == null) {
				return new List<CustomerRmaLine>();
			} else {
				List<CustomerRmaLine> lst = new List<CustomerRmaLine>();
				foreach (CustomerRmaLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CustomerRmaLine obj = new Rebound.GlobalTrader.BLL.CustomerRmaLine();
					obj.CustomerRMAId = objDetails.CustomerRMAId;
					obj.CustomerRMALineId = objDetails.CustomerRMALineId;
					obj.CustomerRMANumber = objDetails.CustomerRMANumber;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.CustomerRMADate = objDetails.CustomerRMADate;
					obj.Quantity = objDetails.Quantity;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
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
		/// Calls [usp_select_CustomerRMALine]
		/// </summary>
		public static CustomerRmaLine Get(System.Int32? customerRmaLineId) {
			Rebound.GlobalTrader.DAL.CustomerRmaLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.Get(customerRmaLineId);
			if (objDetails == null) {
				return null;
			} else {
				CustomerRmaLine obj = new CustomerRmaLine();
				obj.CustomerRMAId = objDetails.CustomerRMAId;
				obj.CustomerRMANumber = objDetails.CustomerRMANumber;
				obj.CustomerRMALineId = objDetails.CustomerRMALineId;
				obj.CustomerRMADate = objDetails.CustomerRMADate;
				obj.ReturnDate = objDetails.ReturnDate;
				obj.ClientNo = objDetails.ClientNo;
				obj.Notes = objDetails.Notes;
				obj.Reason = objDetails.Reason;
				obj.InvoiceNumber = objDetails.InvoiceNumber;
				obj.InvoiceDate = objDetails.InvoiceDate;
				obj.InvoiceNo = objDetails.InvoiceNo;
				obj.InvoiceLineNo = objDetails.InvoiceLineNo;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.Salesman = objDetails.Salesman;
				obj.SalesmanName = objDetails.SalesmanName;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.TeamNo = objDetails.TeamNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.ContactNo = objDetails.ContactNo;
				obj.ContactName = objDetails.ContactName;
				obj.Quantity = objDetails.Quantity;
				obj.QuantityReceived = objDetails.QuantityReceived;
				obj.QuantityAllocated = objDetails.QuantityAllocated;
				obj.ProductNo = objDetails.ProductNo;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.ProductDutyCode = objDetails.ProductDutyCode;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.CustomerPart = objDetails.CustomerPart;
				obj.ROHS = objDetails.ROHS;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.PackageNo = objDetails.PackageNo;
				obj.DateCode = objDetails.DateCode;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.Price = objDetails.Price;
				obj.LandedCost = objDetails.LandedCost;
				obj.LineNotes = objDetails.LineNotes;
                obj.StockNo = objDetails.StockNo;
                obj.CreditIds = objDetails.CreditIds;
                obj.CreditNumbers = objDetails.CreditNumbers;
                obj.Reason1 = objDetails.Reason1;
                obj.Reason2 = objDetails.Reason2;
                obj.Reason1Val = objDetails.Reason1Val;
                obj.Reason2Val = objDetails.Reason2Val;
                obj.RootCause = objDetails.RootCause;
                obj.Avoidable = objDetails.Avoidable;
                obj.IsProdHazardous = objDetails.IsProdHazardous;
                obj.PrintHazardous = objDetails.PrintHazardous;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForReceiving
		/// Calls [usp_select_CustomerRMALine_for_Receiving]
		/// </summary>
		public static CustomerRmaLine GetForReceiving(System.Int32? customerRmaLineNo) {
			Rebound.GlobalTrader.DAL.CustomerRmaLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.GetForReceiving(customerRmaLineNo);
			if (objDetails == null) {
				return null;
			} else {
				CustomerRmaLine obj = new CustomerRmaLine();
				obj.CustomerRMAId = objDetails.CustomerRMAId;
				obj.CustomerRMANumber = objDetails.CustomerRMANumber;
				obj.CustomerRMALineId = objDetails.CustomerRMALineId;
				obj.CustomerRMADate = objDetails.CustomerRMADate;
				obj.ReturnDate = objDetails.ReturnDate;
				obj.ClientNo = objDetails.ClientNo;
				obj.Notes = objDetails.Notes;
				obj.Reason = objDetails.Reason;
				obj.InvoiceNumber = objDetails.InvoiceNumber;
				obj.InvoiceDate = objDetails.InvoiceDate;
				obj.InvoiceNo = objDetails.InvoiceNo;
				obj.InvoiceLineNo = objDetails.InvoiceLineNo;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.Salesman = objDetails.Salesman;
				obj.SalesmanName = objDetails.SalesmanName;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.TeamNo = objDetails.TeamNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.ContactNo = objDetails.ContactNo;
				obj.ContactName = objDetails.ContactName;
				obj.Quantity = objDetails.Quantity;
				obj.QuantityReceived = objDetails.QuantityReceived;
				obj.QuantityAllocated = objDetails.QuantityAllocated;
				obj.ProductNo = objDetails.ProductNo;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.ProductDutyCode = objDetails.ProductDutyCode;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.CustomerPart = objDetails.CustomerPart;
				obj.ROHS = objDetails.ROHS;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.PackageNo = objDetails.PackageNo;
				obj.DateCode = objDetails.DateCode;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.Price = objDetails.Price;
				obj.LandedCost = objDetails.LandedCost;
				obj.LineNotes = objDetails.LineNotes;
				obj.InvoiceLineAllocationId = objDetails.InvoiceLineAllocationId;
				obj.QuantityAllocated = objDetails.QuantityAllocated;
                obj.Reason1 = objDetails.Reason1;
                obj.Reason2 = objDetails.Reason2;
                obj.Reason1Val = objDetails.Reason1Val;
                obj.Reason2Val = objDetails.Reason2Val;
                obj.RootCause = objDetails.RootCause;
				objDetails = null;
				return obj;
			}
		}
        // [001] code start
		/// <summary>
		/// GetListForCustomerRMA
		/// Calls [usp_selectAll_CustomerRMALine_for_CustomerRMA]
		/// </summary>
		public static List<CustomerRmaLine> GetListForCustomerRMA(System.Int32? customerRmaId) {
			List<CustomerRmaLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.GetListForCustomerRMA(customerRmaId);
			if (lstDetails == null) {
				return new List<CustomerRmaLine>();
			} else {
				List<CustomerRmaLine> lst = new List<CustomerRmaLine>();
				foreach (CustomerRmaLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CustomerRmaLine obj = new Rebound.GlobalTrader.BLL.CustomerRmaLine();
					obj.CustomerRMAId = objDetails.CustomerRMAId;
					obj.CustomerRMANumber = objDetails.CustomerRMANumber;
					obj.CustomerRMALineId = objDetails.CustomerRMALineId;
					obj.CustomerRMADate = objDetails.CustomerRMADate;
					obj.ReturnDate = objDetails.ReturnDate;
					obj.ClientNo = objDetails.ClientNo;
					obj.Notes = objDetails.Notes;
					obj.Reason = objDetails.Reason;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.InvoiceLineNo = objDetails.InvoiceLineNo;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.Quantity = objDetails.Quantity;
					obj.QuantityReceived = objDetails.QuantityReceived;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ProductDutyCode = objDetails.ProductDutyCode;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.ROHS = objDetails.ROHS;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.DateCode = objDetails.DateCode;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.Price = objDetails.Price;
					obj.LandedCost = objDetails.LandedCost;
					obj.LineNotes = objDetails.LineNotes;
                    // [001] code start
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.Closed = objDetails.Closed;
                    // [001] code end
                    obj.Reason2 = objDetails.Reason2;
                    obj.RootCause = objDetails.RootCause;
                    obj.ParentCustomerRMALineNo = objDetails.ParentCustomerRMALineNo;
                    obj.PrintHazardous = objDetails.PrintHazardous;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        /// <summary>
        /// GetQtyForCustomerRMA
        /// Calls [usp_GetQty_CustomerRMALine_for_CustomerRMA]
        /// </summary>
        public static CustomerRmaLine GetQtyForCustomerRMA(System.Int32? customerRMALineId, System.Int32? invoiceLineID)
        {
            CustomerRmaLineDetails lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.GetQtyForCustomerRMA(customerRMALineId,invoiceLineID);
            if (lstDetails == null)
            {
                return new CustomerRmaLine();
            }
            else
            {                
                Rebound.GlobalTrader.BLL.CustomerRmaLine obj = new Rebound.GlobalTrader.BLL.CustomerRmaLine();
                obj.QuantityAvailable = lstDetails.QuantityAvailable;
                obj.QuantityShipped = lstDetails.QuantityShipped;
                obj.QuantityReceived = lstDetails.QuantityReceived;
                obj.QuantityCRMA = lstDetails.QuantityCRMA;
                obj.InvoiceLineNo = lstDetails.InvoiceLineNo;
                return obj;
            }
        }
       
        /// <summary>
        /// GetListForCustomerRMA for all Open lines
        /// Calls [usp_selectAll_CRMALine_open_for_CustomerCRMA]
        /// </summary>
        public static List<CustomerRmaLine> GetListOpenForCRMA(System.Int32? customerRmaId)
        {
            List<CustomerRmaLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.GetListOpenForCRMA(customerRmaId);
            if (lstDetails == null)
            {
                return new List<CustomerRmaLine>();
            }
            else
            {
                List<CustomerRmaLine> lst = new List<CustomerRmaLine>();
                foreach (CustomerRmaLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CustomerRmaLine obj = new Rebound.GlobalTrader.BLL.CustomerRmaLine();
                    obj.CustomerRMAId = objDetails.CustomerRMAId;
                    obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                    obj.CustomerRMALineId = objDetails.CustomerRMALineId;
                    obj.CustomerRMADate = objDetails.CustomerRMADate;
                    obj.ReturnDate = objDetails.ReturnDate;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.Notes = objDetails.Notes;
                    obj.Reason = objDetails.Reason;
                    obj.InvoiceNumber = objDetails.InvoiceNumber;
                    obj.InvoiceDate = objDetails.InvoiceDate;
                    obj.InvoiceNo = objDetails.InvoiceNo;
                    obj.InvoiceLineNo = objDetails.InvoiceLineNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.Quantity = objDetails.Quantity;
                    obj.QuantityReceived = objDetails.QuantityReceived;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.ProductDutyCode = objDetails.ProductDutyCode;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.ROHS = objDetails.ROHS;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.Price = objDetails.Price;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.LineNotes = objDetails.LineNotes;
                    obj.Closed = objDetails.Closed;
                    obj.Reason1 = objDetails.Reason1;
                    obj.Reason2 = objDetails.Reason2;
                    obj.RootCause = objDetails.RootCause;
                   lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// GetListForCustomerRMA for all closed lines
        /// Calls [usp_selectAll_CRMALine_close_for_CustomerCRMA]
        /// </summary>
        public static List<CustomerRmaLine> GetListClosedForCRMA(System.Int32? customerRmaId)
        {
            List<CustomerRmaLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.GetListClosedForCRMA(customerRmaId);
            if (lstDetails == null)
            {
                return new List<CustomerRmaLine>();
            }
            else
            {
                List<CustomerRmaLine> lst = new List<CustomerRmaLine>();
                foreach (CustomerRmaLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CustomerRmaLine obj = new Rebound.GlobalTrader.BLL.CustomerRmaLine();
                    obj.CustomerRMAId = objDetails.CustomerRMAId;
                    obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                    obj.CustomerRMALineId = objDetails.CustomerRMALineId;
                    obj.CustomerRMADate = objDetails.CustomerRMADate;
                    obj.ReturnDate = objDetails.ReturnDate;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.Notes = objDetails.Notes;
                    obj.Reason = objDetails.Reason;
                    obj.InvoiceNumber = objDetails.InvoiceNumber;
                    obj.InvoiceDate = objDetails.InvoiceDate;
                    obj.InvoiceNo = objDetails.InvoiceNo;
                    obj.InvoiceLineNo = objDetails.InvoiceLineNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.Quantity = objDetails.Quantity;
                    obj.QuantityReceived = objDetails.QuantityReceived;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.ProductDutyCode = objDetails.ProductDutyCode;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.ROHS = objDetails.ROHS;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.Price = objDetails.Price;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.LineNotes = objDetails.LineNotes;
                    obj.Closed = objDetails.Closed;
                    obj.Reason1 = objDetails.Reason1;
                    obj.Reason2 = objDetails.Reason2;
                    obj.RootCause = objDetails.RootCause;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        // [001] code end
        /// <summary>
		/// GetListForReceiving
		/// Calls [usp_selectAll_CustomerRMALine_for_Receiving]
		/// </summary>
		public static List<CustomerRmaLine> GetListForReceiving(System.Int32? customerRmaNo) {
			List<CustomerRmaLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.GetListForReceiving(customerRmaNo);
			if (lstDetails == null) {
				return new List<CustomerRmaLine>();
			} else {
				List<CustomerRmaLine> lst = new List<CustomerRmaLine>();
				foreach (CustomerRmaLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CustomerRmaLine obj = new Rebound.GlobalTrader.BLL.CustomerRmaLine();
					obj.CustomerRMAId = objDetails.CustomerRMAId;
					obj.CustomerRMANumber = objDetails.CustomerRMANumber;
					obj.CustomerRMALineId = objDetails.CustomerRMALineId;
					obj.CustomerRMADate = objDetails.CustomerRMADate;
					obj.ReturnDate = objDetails.ReturnDate;
					obj.ClientNo = objDetails.ClientNo;
					obj.Notes = objDetails.Notes;
					obj.Reason = objDetails.Reason;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.InvoiceLineNo = objDetails.InvoiceLineNo;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.Quantity = objDetails.Quantity;
					obj.QuantityReceived = objDetails.QuantityReceived;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ProductDutyCode = objDetails.ProductDutyCode;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.ROHS = objDetails.ROHS;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.DateCode = objDetails.DateCode;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.Price = objDetails.Price;
					obj.LandedCost = objDetails.LandedCost;
					obj.LineNotes = objDetails.LineNotes;
					obj.InvoiceLineAllocationId = objDetails.InvoiceLineAllocationId;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// Update
		/// Calls [usp_update_CustomerRMALine]
		/// </summary>
        public static bool Update(System.Int32? customerRmaLineId, System.Int32? quantity, System.String reason, System.String reason1, System.String notes, System.String rootCause, System.String reason2, System.Int32? updatedBy, System.Boolean? avoidable, System.Boolean? printHazardous)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.Update(customerRmaLineId, quantity, reason, reason1, notes, rootCause, reason2, updatedBy, avoidable, printHazardous);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_CustomerRMALine]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLine.Update(CustomerRMALineId, Quantity, Reason, Reason1, Reason2, Notes, RootCause, UpdatedBy, Avoidable, PrintHazardous);
		}

		private static CustomerRmaLine PopulateFromDBDetailsObject(CustomerRmaLineDetails obj) {
			CustomerRmaLine objNew = new CustomerRmaLine();
			objNew.CustomerRMALineId = obj.CustomerRMALineId;
			objNew.CustomerRMANo = obj.CustomerRMANo;
			objNew.InvoiceLineNo = obj.InvoiceLineNo;
			objNew.ReturnDate = obj.ReturnDate;
			objNew.Reason = obj.Reason;
			objNew.Quantity = obj.Quantity;
			objNew.Notes = obj.Notes;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.CustomerRMAId = obj.CustomerRMAId;
			objNew.CustomerRMANumber = obj.CustomerRMANumber;
			objNew.CustomerRMADate = obj.CustomerRMADate;
			objNew.CompanyName = obj.CompanyName;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.InvoiceNumber = obj.InvoiceNumber;
			objNew.InvoiceNo = obj.InvoiceNo;
			objNew.ROHS = obj.ROHS;
			objNew.Part = obj.Part;
			objNew.ContactName = obj.ContactName;
			objNew.ContactNo = obj.ContactNo;
			objNew.ManufacturerNo = obj.ManufacturerNo;
			objNew.ManufacturerCode = obj.ManufacturerCode;
			objNew.RowNum = obj.RowNum;
			objNew.RowCnt = obj.RowCnt;
			objNew.QuantityReceived = obj.QuantityReceived;
			objNew.SalesmanName = obj.SalesmanName;
			objNew.ClientNo = obj.ClientNo;
			objNew.InvoiceDate = obj.InvoiceDate;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.Salesman = obj.Salesman;
			objNew.DivisionNo = obj.DivisionNo;
			objNew.TeamNo = obj.TeamNo;
			objNew.QuantityAllocated = obj.QuantityAllocated;
			objNew.ProductNo = obj.ProductNo;
			objNew.ProductName = obj.ProductName;
			objNew.ProductDescription = obj.ProductDescription;
			objNew.ProductDutyCode = obj.ProductDutyCode;
			objNew.FullPart = obj.FullPart;
			objNew.CustomerPart = obj.CustomerPart;
			objNew.ManufacturerName = obj.ManufacturerName;
			objNew.PackageNo = obj.PackageNo;
			objNew.DateCode = obj.DateCode;
			objNew.PackageName = obj.PackageName;
			objNew.PackageDescription = obj.PackageDescription;
			objNew.Price = obj.Price;
			objNew.LandedCost = obj.LandedCost;
			objNew.LineNotes = obj.LineNotes;
			objNew.InvoiceLineAllocationId = obj.InvoiceLineAllocationId;
			return objNew;
		}

		#endregion

	}
}