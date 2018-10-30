//Marker     Changed by      Date         Remarks    
//[001]      Vinay           16/10/2012   Display supplier type in stock grid  
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
		public partial class History : BizObject {
		
		#region Properties

		protected static DAL.HistoryElement Settings {
			get { return Globals.Settings.Historys; }
		}

		/// <summary>
		/// HistoryId
		/// </summary>
		public System.Int32 HistoryId { get; set; }		
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
		/// ProductNo
		/// </summary>
		public System.Int32? ProductNo { get; set; }		
		/// <summary>
		/// PackageNo
		/// </summary>
		public System.Int32? PackageNo { get; set; }		
		/// <summary>
		/// Quantity
		/// </summary>
		public System.Int32 Quantity { get; set; }		
		/// <summary>
		/// Price
		/// </summary>
		public System.Double Price { get; set; }		
		/// <summary>
		/// OriginalEntryDate
		/// </summary>
		public System.DateTime? OriginalEntryDate { get; set; }		
		/// <summary>
		/// Salesman
		/// </summary>
		public System.Int32? Salesman { get; set; }		
		/// <summary>
		/// SupplierNo
		/// </summary>
		public System.Int32? SupplierNo { get; set; }		
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }		
		/// <summary>
		/// ROHS
		/// </summary>
		public System.Byte? ROHS { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// OfferStatusNo
		/// </summary>
		public System.Int32? OfferStatusNo { get; set; }		
		/// <summary>
		/// OfferStatusChangeDate
		/// </summary>
		public System.DateTime? OfferStatusChangeDate { get; set; }		
		/// <summary>
		/// OfferStatusChangeLoginNo
		/// </summary>
		public System.Int32? OfferStatusChangeLoginNo { get; set; }		
		/// <summary>
		/// SupplierName
		/// </summary>
		public System.String SupplierName { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// ManufacturerName
		/// </summary>
		public System.String ManufacturerName { get; set; }		
		/// <summary>
		/// ProductName
		/// </summary>
		public System.String ProductName { get; set; }		
		/// <summary>
		/// PackageName
		/// </summary>
		public System.String PackageName { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32? ClientNo { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
		/// <summary>
		/// ManufacturerCode
		/// </summary>
		public System.String ManufacturerCode { get; set; }		
		/// <summary>
		/// SupplierEmail
		/// </summary>
		public System.String SupplierEmail { get; set; }		
		/// <summary>
		/// SalesmanName
		/// </summary>
		public System.String SalesmanName { get; set; }		
		/// <summary>
		/// OfferStatusChangeEmployeeName
		/// </summary>
		public System.String OfferStatusChangeEmployeeName { get; set; }		
		/// <summary>
		/// ClientName
		/// </summary>
		public System.String ClientName { get; set; }		
		/// <summary>
		/// ClientDataVisibleToOthers
		/// </summary>
		public System.Boolean? ClientDataVisibleToOthers { get; set; }	

	    //[001] code start
        /// <summary>
        /// SupplierType
        /// </summary>
        public System.String SupplierType { get; set; }
        //[001] code end
        public System.String ClientCode { get; set; }
        public System.String ProductDescription { get; set; }
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_History]
		/// </summary>
		public static bool Delete(System.Int32? historyNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.History.Delete(historyNo);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_History]
		/// </summary>
		public static Int32 Insert(System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? offerStatusNo, System.DateTime? offerStatusChangeDate, System.Int32? offerStatusChangeLoginNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.History.Insert(part, manufacturerNo, dateCode, productNo, packageNo, quantity, price, currencyNo, originalEntryDate, salesman, offerStatusNo, offerStatusChangeDate, offerStatusChangeLoginNo, supplierNo, rohs, notes, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_History]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.History.Insert(Part, ManufacturerNo, DateCode, ProductNo, PackageNo, Quantity, Price, CurrencyNo, OriginalEntryDate, Salesman, OfferStatusNo, OfferStatusChangeDate, OfferStatusChangeLoginNo, SupplierNo, ROHS, Notes, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_History]
		/// </summary>
		public static History Get(System.Int32? historyNo) {
			Rebound.GlobalTrader.DAL.HistoryDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.History.Get(historyNo);
			if (objDetails == null) {
				return null;
			} else {
				History obj = new History();
				obj.HistoryId = objDetails.HistoryId;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.DateCode = objDetails.DateCode;
				obj.ProductNo = objDetails.ProductNo;
				obj.PackageNo = objDetails.PackageNo;
				obj.Quantity = objDetails.Quantity;
				obj.Price = objDetails.Price;
				obj.OriginalEntryDate = objDetails.OriginalEntryDate;
				obj.Salesman = objDetails.Salesman;
				obj.SupplierNo = objDetails.SupplierNo;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.ROHS = objDetails.ROHS;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.OfferStatusNo = objDetails.OfferStatusNo;
				obj.OfferStatusChangeDate = objDetails.OfferStatusChangeDate;
				obj.OfferStatusChangeLoginNo = objDetails.OfferStatusChangeLoginNo;
				obj.SupplierName = objDetails.SupplierName;
				obj.Notes = objDetails.Notes;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ProductName = objDetails.ProductName;
				obj.PackageName = objDetails.PackageName;
				obj.ClientNo = objDetails.ClientNo;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.SupplierName = objDetails.SupplierName;
                obj.ProductDescription = objDetails.ProductDescription;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// Source
		/// Calls [usp_source_History]
		/// </summary>
        public static List<History> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? maxDate, out DateTime? outDate, System.Boolean? blnReferesh, bool IsServerLocal,bool? isPoHub)
        {
            DateTime? StartDate = null;
            DateTime? EndDate = null;
            if (index == 2 && maxDate.HasValue)
            {
                StartDate = (!blnReferesh.Value) ? maxDate.Value.AddMonths(-6) : maxDate.Value.AddMonths(-12);
                EndDate = maxDate.Value;
            }
            else if (index == 3 && maxDate.HasValue)
            {
                StartDate = DateTime.Parse("1900-01-01 00:00:00.000");
                EndDate = maxDate.Value;
            }
            List<HistoryDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.History.Source(clientId, partSearch, index, StartDate, EndDate, out outDate, IsServerLocal,isPoHub);
			if (lstDetails == null) {
				return new List<History>();
			} else {
				List<History> lst = new List<History>();
				foreach (HistoryDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.History obj = new Rebound.GlobalTrader.BLL.History();
					obj.HistoryId = objDetails.HistoryId;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.DateCode = objDetails.DateCode;
					obj.ProductNo = objDetails.ProductNo;
					obj.PackageNo = objDetails.PackageNo;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.OriginalEntryDate = objDetails.OriginalEntryDate;
					obj.Salesman = objDetails.Salesman;
					obj.SupplierNo = objDetails.SupplierNo;
					obj.SupplierName = objDetails.SupplierName;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.ROHS = objDetails.ROHS;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.OfferStatusNo = objDetails.OfferStatusNo;
					obj.OfferStatusChangeDate = objDetails.OfferStatusChangeDate;
					obj.OfferStatusChangeLoginNo = objDetails.OfferStatusChangeLoginNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.SupplierName = objDetails.SupplierName;
					obj.SupplierEmail = objDetails.SupplierEmail;
					obj.ProductName = objDetails.ProductName;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.OfferStatusChangeEmployeeName = objDetails.OfferStatusChangeEmployeeName;
					obj.PackageName = objDetails.PackageName;
					obj.Notes = objDetails.Notes;
					obj.ClientNo = objDetails.ClientNo;
					obj.ClientName = objDetails.ClientName;
					obj.ClientDataVisibleToOthers = objDetails.ClientDataVisibleToOthers;
                    //[001] code start
                    obj.SupplierType = objDetails.SupplierType;
                    //[001] code end
                    obj.ClientCode = objDetails.ClientCode;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_History]
		/// </summary>
		public static bool Update(System.Int32? historyId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.History.Update(historyId, part, manufacturerNo, dateCode, productNo, packageNo, quantity, price, currencyNo, offerStatusNo, supplierNo, rohs, notes, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_History]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.History.Update(HistoryId, Part, ManufacturerNo, DateCode, ProductNo, PackageNo, Quantity, Price, CurrencyNo, OfferStatusNo, SupplierNo, ROHS, Notes, UpdatedBy);
		}
		/// <summary>
		/// UpdateForSourcing
		/// Calls [usp_update_History_for_sourcing]
		/// </summary>
		public static bool UpdateForSourcing(System.Int32? historyNo, System.Int32? quantity, System.Double? price, System.String notes, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.History.UpdateForSourcing(historyNo, quantity, price, notes, updatedBy);
		}
		/// <summary>
		/// UpdateOfferStatus
		/// Calls [usp_update_History_OfferStatus]
		/// </summary>
		public static bool UpdateOfferStatus(System.Int32? historyNo, System.Int32? offerStatusNo, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.History.UpdateOfferStatus(historyNo, offerStatusNo, updatedBy);
		}

        private static History PopulateFromDBDetailsObject(HistoryDetails obj) {
            History objNew = new History();
			objNew.HistoryId = obj.HistoryId;
			objNew.FullPart = obj.FullPart;
			objNew.Part = obj.Part;
			objNew.ManufacturerNo = obj.ManufacturerNo;
			objNew.DateCode = obj.DateCode;
			objNew.ProductNo = obj.ProductNo;
			objNew.PackageNo = obj.PackageNo;
			objNew.Quantity = obj.Quantity;
			objNew.Price = obj.Price;
			objNew.OriginalEntryDate = obj.OriginalEntryDate;
			objNew.Salesman = obj.Salesman;
			objNew.SupplierNo = obj.SupplierNo;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.ROHS = obj.ROHS;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.OfferStatusNo = obj.OfferStatusNo;
			objNew.OfferStatusChangeDate = obj.OfferStatusChangeDate;
			objNew.OfferStatusChangeLoginNo = obj.OfferStatusChangeLoginNo;
			objNew.SupplierName = obj.SupplierName;
			objNew.Notes = obj.Notes;
			objNew.ManufacturerName = obj.ManufacturerName;
			objNew.ProductName = obj.ProductName;
			objNew.PackageName = obj.PackageName;
			objNew.ClientNo = obj.ClientNo;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.ManufacturerCode = obj.ManufacturerCode;
			objNew.SupplierEmail = obj.SupplierEmail;
			objNew.SalesmanName = obj.SalesmanName;
			objNew.OfferStatusChangeEmployeeName = obj.OfferStatusChangeEmployeeName;
			objNew.ClientName = obj.ClientName;
			objNew.ClientDataVisibleToOthers = obj.ClientDataVisibleToOthers;
            return objNew;
        }
		
		#endregion
		
	}
}