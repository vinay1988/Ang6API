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
		public partial class DebitLine : BizObject {
		
		#region Properties

		protected static DAL.DebitLineElement Settings {
			get { return Globals.Settings.DebitLines; }
		}

		/// <summary>
		/// DebitLineId
		/// </summary>
		public System.Int32 DebitLineId { get; set; }		
		/// <summary>
		/// DebitNo
		/// </summary>
		public System.Int32 DebitNo { get; set; }		
		/// <summary>
		/// FullPart
		/// </summary>
		public System.String FullPart { get; set; }		
		/// <summary>
		/// Part
		/// </summary>
		public System.String Part { get; set; }		
		/// <summary>
		/// ManufacturerNo
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }		
		/// <summary>
		/// DateCode
		/// </summary>
		public System.String DateCode { get; set; }		
		/// <summary>
		/// PackageNo
		/// </summary>
		public System.Int32? PackageNo { get; set; }		
		/// <summary>
		/// ProductNo
		/// </summary>
		public System.Int32? ProductNo { get; set; }		
		/// <summary>
		/// Quantity
		/// </summary>
		public System.Int32 Quantity { get; set; }		
		/// <summary>
		/// Price
		/// </summary>
		public System.Double Price { get; set; }		
		/// <summary>
		/// Taxable
		/// </summary>
		public System.Boolean Taxable { get; set; }		
		/// <summary>
		/// SupplierPart
		/// </summary>
		public System.String SupplierPart { get; set; }		
		/// <summary>
		/// LandedCost
		/// </summary>
		public System.Double? LandedCost { get; set; }		
		/// <summary>
		/// PurchaseOrderLineNo
		/// </summary>
		public System.Int32? PurchaseOrderLineNo { get; set; }		
		/// <summary>
		/// SupplierRMALineNo
		/// </summary>
		public System.Int32? SupplierRMALineNo { get; set; }		
		/// <summary>
		/// StockNo
		/// </summary>
		public System.Int32? StockNo { get; set; }		
		/// <summary>
		/// ROHS
		/// </summary>
		public System.Byte ROHS { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// ServiceNo
		/// </summary>
		public System.Int32? ServiceNo { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// FullSupplierPart
		/// </summary>
		public System.String FullSupplierPart { get; set; }		
		/// <summary>
		/// DebitId
		/// </summary>
		public System.Int32 DebitId { get; set; }		
		/// <summary>
		/// DebitNumber
		/// </summary>
		public System.Int32 DebitNumber { get; set; }		
		/// <summary>
		/// DebitDate
		/// </summary>
		public System.DateTime DebitDate { get; set; }		
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32 CompanyNo { get; set; }		
		/// <summary>
		/// SupplierRMANumber
		/// </summary>
		public System.Int32 SupplierRMANumber { get; set; }		
		/// <summary>
		/// SupplierRMANo
		/// </summary>
		public System.Int32? SupplierRMANo { get; set; }		
		/// <summary>
		/// SupplierInvoice
		/// </summary>
		public System.String SupplierInvoice { get; set; }		
		/// <summary>
		/// PurchaseOrderNumber
		/// </summary>
		public System.Int32 PurchaseOrderNumber { get; set; }		
		/// <summary>
		/// PurchaseOrderNo
		/// </summary>
		public System.Int32? PurchaseOrderNo { get; set; }		
		/// <summary>
		/// ContactName
		/// </summary>
		public System.String ContactName { get; set; }		
		/// <summary>
		/// ContactNo
		/// </summary>
		public System.Int32 ContactNo { get; set; }		
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
		/// DivisionNo
		/// </summary>
		public System.Int32 DivisionNo { get; set; }		
		/// <summary>
		/// ManufacturerName
		/// </summary>
		public System.String ManufacturerName { get; set; }		
		/// <summary>
		/// PackageName
		/// </summary>
		public System.String PackageName { get; set; }		
		/// <summary>
		/// PackageDescription
		/// </summary>
		public System.String PackageDescription { get; set; }		
		/// <summary>
		/// ProductName
		/// </summary>
		public System.String ProductName { get; set; }		
		/// <summary>
		/// ProductDescription
		/// </summary>
		public System.String ProductDescription { get; set; }		
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
		/// <summary>
		/// LineNotes
		/// </summary>
		public System.String LineNotes { get; set; }
		/// <summary>
		/// ProductDutyCode
		/// </summary>
		public System.String ProductDutyCode { get; set; }

        public System.Int32? ParentDebitLineNo { get; set; }
        public System.Int32? IPOCompanyNo { get; set; }
        public System.Int32? InternalPurchaseOrderId { get; set; }
        public System.String IPOCompanyName { get; set; }
        /// <summary>
        /// ClientName
        /// </summary>
        public System.String ClientName { get; set; }
        public System.Boolean? IsProdHazardous { get; set; }
        public System.Boolean? PrintHazardous { get; set; }
		#endregion
		
		#region Methods
		
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_DebitLine_for_Client]
		/// </summary>
		public static Int32 CountForClient(System.Int32? clientId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.DebitLine.CountForClient(clientId);
		}		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_DebitLine]
		/// </summary>
        public static List<DebitLine> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.String debitNotesSearch, System.String supplierInvoiceSearch, System.Int32? debitNoLo, System.Int32? debitNoHi, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.DateTime? debitDateFrom, System.DateTime? debitDateTo, System.Boolean? PohubOnly, Boolean IsGlobalLogin, System.Int32? clientSearchId)
        {
			List<DebitLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.DebitLine.DataListNugget(clientId, teamId, divisionId, loginId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, buyerSearch, debitNotesSearch, supplierInvoiceSearch, debitNoLo, debitNoHi, purchaseOrderNoLo, purchaseOrderNoHi, supplierRmaNoLo, supplierRmaNoHi, debitDateFrom, debitDateTo,PohubOnly,IsGlobalLogin,clientSearchId);
			if (lstDetails == null) {
				return new List<DebitLine>();
			} else {
				List<DebitLine> lst = new List<DebitLine>();
				foreach (DebitLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.DebitLine obj = new Rebound.GlobalTrader.BLL.DebitLine();
					obj.DebitId = objDetails.DebitId;
					obj.DebitNumber = objDetails.DebitNumber;
					obj.Part = objDetails.Part;
					obj.DebitDate = objDetails.DebitDate;
					obj.CompanyName = objDetails.CompanyName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.SupplierInvoice = objDetails.SupplierInvoice;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.ContactName = objDetails.ContactName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ROHS = objDetails.ROHS;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
                    obj.IPOCompanyNo = objDetails.IPOCompanyNo;
                    obj.IPOCompanyName = objDetails.IPOCompanyName;
                    obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
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
		/// Calls [usp_delete_DebitLine]
		/// </summary>
		public static bool Delete(System.Int32? debitLineId, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.DebitLine.Delete(debitLineId, updatedBy);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_DebitLine]
		/// </summary>
		public static Int32 Insert(System.Int32? debitNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? productNo, System.Int32? quantity, System.Double? price, System.Boolean? taxable, System.String supplierPart, System.Double? landedCost, System.Int32? purchaseOrderLineNo, System.Int32? supplierRmaLineNo, System.Int32? stockNo, System.Int32? serviceNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, out int debitId, out int debitNumber) {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.DebitLine.Insert(debitNo, part, manufacturerNo, dateCode, packageNo, productNo, quantity, price, taxable, supplierPart, landedCost, purchaseOrderLineNo, supplierRmaLineNo, stockNo, serviceNo, rohs, notes, updatedBy, out debitId, out debitNumber,false);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_DebitLine]
		/// </summary>
		public Int32 Insert() {
            int debitId = 0;
            int debitNumber = 0;
            int debitLineId = Rebound.GlobalTrader.DAL.SiteProvider.DebitLine.Insert(DebitNo, Part, ManufacturerNo, DateCode, PackageNo, ProductNo, Quantity, Price, Taxable, SupplierPart, LandedCost, PurchaseOrderLineNo, SupplierRMALineNo, StockNo, ServiceNo, ROHS, Notes, UpdatedBy, out debitId, out debitNumber,PrintHazardous);
            this.DebitId = debitId;
            this.DebitNumber = debitNumber;
            return debitLineId;
		}
		/// <summary>
		/// InsertByShippingSRMALine
		/// Calls [usp_insert_DebitLine_by_Shipping_SRMALine]
		/// </summary>
		public static Int32 InsertByShippingSRMALine(System.Int32? debitNo, System.Int32? supplierRmaLineId, System.Int32? allocationNo, System.Int32? quantityShipped, System.Int32? shippedBy, System.DateTime? shippedDate, System.Int32? updatedBy,out int debitId, out int debitNumber) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.DebitLine.InsertByShippingSRMALine(debitNo, supplierRmaLineId, allocationNo, quantityShipped, shippedBy, shippedDate, updatedBy,out debitId, out debitNumber);
			return objReturn;
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_DebitLine]
		/// </summary>
		public static DebitLine Get(System.Int32? debitLineId) {
			Rebound.GlobalTrader.DAL.DebitLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.DebitLine.Get(debitLineId);
			if (objDetails == null) {
				return null;
			} else {
				DebitLine obj = new DebitLine();
				obj.DebitLineId = objDetails.DebitLineId;
				obj.DebitNo = objDetails.DebitNo;
				obj.DebitNumber = objDetails.DebitNumber;
				obj.DebitDate = objDetails.DebitDate;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.ROHS = objDetails.ROHS;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.DateCode = objDetails.DateCode;
				obj.PackageNo = objDetails.PackageNo;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.ProductNo = objDetails.ProductNo;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.Quantity = objDetails.Quantity;
				obj.Price = objDetails.Price;
				obj.LandedCost = objDetails.LandedCost;
				obj.Taxable = objDetails.Taxable;
				obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
				obj.SupplierPart = objDetails.SupplierPart;
				obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
				obj.StockNo = objDetails.StockNo;
				obj.ServiceNo = objDetails.ServiceNo;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.LineNotes = objDetails.LineNotes;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
                obj.IsProdHazardous = objDetails.IsProdHazardous;
                obj.PrintHazardous = objDetails.PrintHazardous;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForDebit
		/// Calls [usp_selectAll_DebitLine_for_Debit]
		/// </summary>
		public static List<DebitLine> GetListForDebit(System.Int32? debitId) {
			List<DebitLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.DebitLine.GetListForDebit(debitId);
			if (lstDetails == null) {
				return new List<DebitLine>();
			} else {
				List<DebitLine> lst = new List<DebitLine>();
				foreach (DebitLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.DebitLine obj = new Rebound.GlobalTrader.BLL.DebitLine();
					obj.DebitLineId = objDetails.DebitLineId;
					obj.DebitNo = objDetails.DebitNo;
					obj.DebitNumber = objDetails.DebitNumber;
					obj.DebitDate = objDetails.DebitDate;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.LandedCost = objDetails.LandedCost;
					obj.Taxable = objDetails.Taxable;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
					obj.StockNo = objDetails.StockNo;
					obj.ServiceNo = objDetails.ServiceNo;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.LineNotes = objDetails.LineNotes;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.ProductDutyCode = objDetails.ProductDutyCode;
                    obj.ParentDebitLineNo = objDetails.ParentDebitLineNo;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        /// <summary>
        /// GetListForDebit
        /// Calls [usp_selectAll_DebitLine_for_Debit_Print]
        /// </summary>
        public static List<DebitLine> GetListForDebitPrint(System.Int32? debitId,System.Boolean? IsHUBDebit)
        {
            List<DebitLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.DebitLine.GetListForDebitPrint(debitId, IsHUBDebit);
            if (lstDetails == null)
            {
                return new List<DebitLine>();
            }
            else
            {
                List<DebitLine> lst = new List<DebitLine>();
                foreach (DebitLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.DebitLine obj = new Rebound.GlobalTrader.BLL.DebitLine();
                    obj.DebitLineId = objDetails.DebitLineId;
                    obj.DebitNo = objDetails.DebitNo;
                    obj.DebitNumber = objDetails.DebitNumber;
                    obj.DebitDate = objDetails.DebitDate;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.DateCode = objDetails.DateCode;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.Taxable = objDetails.Taxable;
                    obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
                    obj.SupplierPart = objDetails.SupplierPart;
                    obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
                    obj.StockNo = objDetails.StockNo;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.LineNotes = objDetails.LineNotes;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.ProductDutyCode = objDetails.ProductDutyCode;
                    obj.PrintHazardous = objDetails.PrintHazardous;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
		/// <summary>
		/// GetListForSupplierRMA
		/// Calls [usp_selectAll_DebitLine_for_SupplierRMA]
		/// </summary>
		public static List<DebitLine> GetListForSupplierRMA(System.Int32? supplierRmaId) {
			List<DebitLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.DebitLine.GetListForSupplierRMA(supplierRmaId);
			if (lstDetails == null) {
				return new List<DebitLine>();
			} else {
				List<DebitLine> lst = new List<DebitLine>();
				foreach (DebitLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.DebitLine obj = new Rebound.GlobalTrader.BLL.DebitLine();
					obj.DebitLineId = objDetails.DebitLineId;
					obj.DebitNo = objDetails.DebitNo;
					obj.DebitNumber = objDetails.DebitNumber;
					obj.DebitDate = objDetails.DebitDate;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.LandedCost = objDetails.LandedCost;
					obj.Taxable = objDetails.Taxable;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
					obj.StockNo = objDetails.StockNo;
					obj.ServiceNo = objDetails.ServiceNo;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.LineNotes = objDetails.LineNotes;
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
		/// GetListForSupplierRMALine
		/// Calls [usp_selectAll_DebitLine_for_SupplierRMALine]
		/// </summary>
		public static List<DebitLine> GetListForSupplierRMALine(System.Int32? supplierRmaLineId) {
			List<DebitLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.DebitLine.GetListForSupplierRMALine(supplierRmaLineId);
			if (lstDetails == null) {
				return new List<DebitLine>();
			} else {
				List<DebitLine> lst = new List<DebitLine>();
				foreach (DebitLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.DebitLine obj = new Rebound.GlobalTrader.BLL.DebitLine();
					obj.DebitLineId = objDetails.DebitLineId;
					obj.DebitNo = objDetails.DebitNo;
					obj.DebitNumber = objDetails.DebitNumber;
					obj.DebitDate = objDetails.DebitDate;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.LandedCost = objDetails.LandedCost;
					obj.Taxable = objDetails.Taxable;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
					obj.StockNo = objDetails.StockNo;
					obj.ServiceNo = objDetails.ServiceNo;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.LineNotes = objDetails.LineNotes;
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
		/// Update
		/// Calls [usp_update_DebitLine]
		/// </summary>
		public static bool Update(System.Int32? debitLineId, System.Int32? quantity, System.Double? price, System.String part, System.String supplierPart, System.String notes, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.DebitLine.Update(debitLineId, quantity, price, part, supplierPart, notes, updatedBy,false);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_DebitLine]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.DebitLine.Update(DebitLineId, Quantity, Price, Part, SupplierPart, Notes, UpdatedBy,PrintHazardous);
		}

        private static DebitLine PopulateFromDBDetailsObject(DebitLineDetails obj) {
            DebitLine objNew = new DebitLine();
			objNew.DebitLineId = obj.DebitLineId;
			objNew.DebitNo = obj.DebitNo;
			objNew.FullPart = obj.FullPart;
			objNew.Part = obj.Part;
			objNew.ManufacturerNo = obj.ManufacturerNo;
			objNew.DateCode = obj.DateCode;
			objNew.PackageNo = obj.PackageNo;
			objNew.ProductNo = obj.ProductNo;
			objNew.Quantity = obj.Quantity;
			objNew.Price = obj.Price;
			objNew.Taxable = obj.Taxable;
			objNew.SupplierPart = obj.SupplierPart;
			objNew.LandedCost = obj.LandedCost;
			objNew.PurchaseOrderLineNo = obj.PurchaseOrderLineNo;
			objNew.SupplierRMALineNo = obj.SupplierRMALineNo;
			objNew.StockNo = obj.StockNo;
			objNew.ROHS = obj.ROHS;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.ServiceNo = obj.ServiceNo;
			objNew.Notes = obj.Notes;
			objNew.FullSupplierPart = obj.FullSupplierPart;
			objNew.DebitId = obj.DebitId;
			objNew.DebitNumber = obj.DebitNumber;
			objNew.DebitDate = obj.DebitDate;
			objNew.CompanyName = obj.CompanyName;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.SupplierRMANumber = obj.SupplierRMANumber;
			objNew.SupplierRMANo = obj.SupplierRMANo;
			objNew.SupplierInvoice = obj.SupplierInvoice;
			objNew.PurchaseOrderNumber = obj.PurchaseOrderNumber;
			objNew.PurchaseOrderNo = obj.PurchaseOrderNo;
			objNew.ContactName = obj.ContactName;
			objNew.ContactNo = obj.ContactNo;
			objNew.ManufacturerCode = obj.ManufacturerCode;
			objNew.RowNum = obj.RowNum;
			objNew.RowCnt = obj.RowCnt;
			objNew.DivisionNo = obj.DivisionNo;
			objNew.ManufacturerName = obj.ManufacturerName;
			objNew.PackageName = obj.PackageName;
			objNew.PackageDescription = obj.PackageDescription;
			objNew.ProductName = obj.ProductName;
			objNew.ProductDescription = obj.ProductDescription;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.LineNotes = obj.LineNotes;
            return objNew;
        }
		
		#endregion
		
	}
}