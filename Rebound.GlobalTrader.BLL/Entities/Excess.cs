//Marker     Changed by      Date         Remarks  
//[001]      Vinay           15/10/2012   Display supplier type in stock grid
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
		public partial class Excess : BizObject {
		
		#region Properties

		protected static DAL.ExcessElement Settings {
			get { return Globals.Settings.Excesss; }
		}

		/// <summary>
		/// ExcessId
		/// </summary>
		public System.Int32 ExcessId { get; set; }		
		/// <summary>
		/// ExcessName
		/// </summary>
		public System.String ExcessName { get; set; }		
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
		/// CurrencyNo
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }		
		/// <summary>
		/// OriginalEntryDate
		/// </summary>
		public System.DateTime? OriginalEntryDate { get; set; }		
		/// <summary>
		/// Salesman
		/// </summary>
		public System.Int32? Salesman { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32 CompanyNo { get; set; }		
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
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		
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
		/// SupplierName
		/// </summary>
		public System.String SupplierName { get; set; }		
		/// <summary>
		/// SupplierEmail
		/// </summary>
		public System.String SupplierEmail { get; set; }		
		/// <summary>
		/// ManufacturerCode
		/// </summary>
		public System.String ManufacturerCode { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
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
        //[001] code start

        public System.String ClientCode { get; set; }

        public System.String MSL { get; set; }
        public System.String SPQ { get; set; }
        public System.String LeadTime { get; set; }
        public System.String RoHSStatus { get; set; }
        public System.String FactorySealed { get; set; }
        //public System.Int32 IPOBOMNo { get; set; }
        public System.String SupplierTotalQSA { get; set; }
        public System.String SupplierMOQ { get; set; }
        public System.String SupplierLTB { get; set; }
        public System.String ProductDescription { get; set; }
        public System.Int32? MSLLevelNo { get; set; }

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Excess]
		/// </summary>
		public static bool Delete(System.Int32? excessId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Excess.Delete(excessId);
		}
		/// <summary>
		/// Insert
        /// Calls [usp_insert_ExcessNew]
		/// </summary>
        public static Int32 Insert(System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? companyNo, System.String companyName, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Int32? clientNo, System.Int32? offerStatusNo, bool? isPoHub)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Excess.Insert(part, manufacturerNo, dateCode, productNo, packageNo, quantity, price, currencyNo, originalEntryDate, salesman, companyNo, companyName, rohs, notes, updatedBy, clientNo, offerStatusNo, isPoHub);
			return objReturn;
		}

        /// <summary>
        /// Insert
        /// Calls [usp_insert_ExcessNew]
        /// </summary>
        public static Int32 IPOBOMInsert(System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? companyNo, System.String companyName, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Int32? clientNo, System.Int32? offerStatusNo, bool? isPoHub, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.String msl, System.String spq, System.String leadTime, System.String factorySealed, System.String rohsStatus,System.Int32? mslLevel)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Excess.IPOBOMInsert(part, manufacturerNo, dateCode, productNo, packageNo, quantity, price, currencyNo, originalEntryDate, salesman, companyNo, companyName, rohs, notes, updatedBy, clientNo, offerStatusNo, isPoHub, supplierTotalQSA, supplierMOQ, supplierLTB, msl, spq, leadTime, factorySealed, rohsStatus, mslLevel);
            return objReturn;
        }
		/// <summary>
        /// Insert
        /// Calls [usp_insert_ExcessClone]
        /// </summary>
        public static Int32 CloneTrustedAddToReq(System.Int32 trustedId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? companyNo, System.String companyName, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Int32? clientNo, System.Int32? offerStatusNo, bool? isPoHub, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.String msl, System.String spq, System.String leadTime, System.String factorySealed, System.String rohsStatus, System.Int32? customerRequirementNo,System.Int32? mslLevelNo)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Excess.CloneTrustedAddToReq(trustedId, part, manufacturerNo, dateCode, productNo, packageNo, quantity, price, currencyNo, originalEntryDate, salesman, companyNo, companyName, rohs, notes, updatedBy, clientNo, offerStatusNo, isPoHub, supplierTotalQSA, supplierMOQ, supplierLTB, msl, spq, leadTime, factorySealed, rohsStatus, customerRequirementNo, mslLevelNo);
            return objReturn;
        }

		/// <summary>
		/// Insert (without parameters)
        /// Calls [usp_insert_ExcessNew]
		/// </summary>
		public Int32 Insert() {
            return Rebound.GlobalTrader.DAL.SiteProvider.Excess.Insert(Part, ManufacturerNo, DateCode, ProductNo, PackageNo, Quantity, Price, CurrencyNo, OriginalEntryDate, Salesman, CompanyNo, CompanyName, ROHS, Notes, UpdatedBy, ClientNo, OfferStatusNo, null);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Excess]
		/// </summary>
		public static Excess Get(System.Int32? excessId,bool? isPoHub) {
            Rebound.GlobalTrader.DAL.ExcessDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Excess.Get(excessId, isPoHub);
			if (objDetails == null) {
				return null;
			} else {
				Excess obj = new Excess();
				obj.ExcessId = objDetails.ExcessId;
				obj.ExcessName = objDetails.ExcessName;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.DateCode = objDetails.DateCode;
				obj.ProductNo = objDetails.ProductNo;
				obj.PackageNo = objDetails.PackageNo;
				obj.Quantity = objDetails.Quantity;
				obj.Price = objDetails.Price;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.OriginalEntryDate = objDetails.OriginalEntryDate;
				obj.Salesman = objDetails.Salesman;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.ROHS = objDetails.ROHS;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.OfferStatusNo = objDetails.OfferStatusNo;
				obj.OfferStatusChangeDate = objDetails.OfferStatusChangeDate;
				obj.OfferStatusChangeLoginNo = objDetails.OfferStatusChangeLoginNo;
				obj.Notes = objDetails.Notes;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ProductName = objDetails.ProductName;
				obj.PackageName = objDetails.PackageName;
				obj.CompanyName = objDetails.CompanyName;
                obj.SPQ =objDetails.SPQ;
                obj.LeadTime = objDetails.LeadTime;
                obj.RoHSStatus =objDetails.RoHSStatus;
                obj.FactorySealed =objDetails.FactorySealed;
                obj.MSL =objDetails.MSL;
                obj.SupplierMOQ =objDetails.SupplierMOQ;
                obj.SupplierTotalQSA =objDetails.SupplierTotalQSA;
                obj.SupplierLTB =objDetails.SupplierLTB;
                obj.ProductDescription = objDetails.ProductDescription;
                obj.ProductInactive = objDetails.ProductInactive;
                obj.MSLLevelNo = objDetails.MSLLevelNo;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// Source
		/// Calls [usp_source_Excess]
		/// </summary>
        public static List<Excess> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? maxDate, out DateTime? outDate, System.Boolean? blnReferesh, bool IsServerLocal,System.Boolean? isPohub)
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
            List<ExcessDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Excess.Source(clientId, partSearch, index, StartDate, EndDate, out outDate, IsServerLocal,isPohub);
			if (lstDetails == null) {
				return new List<Excess>();
			} else {
				List<Excess> lst = new List<Excess>();
				foreach (ExcessDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Excess obj = new Rebound.GlobalTrader.BLL.Excess();
					obj.ExcessId = objDetails.ExcessId;
					obj.ExcessName = objDetails.ExcessName;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.DateCode = objDetails.DateCode;
					obj.ProductNo = objDetails.ProductNo;
					obj.PackageNo = objDetails.PackageNo;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.OriginalEntryDate = objDetails.OriginalEntryDate;
					obj.Salesman = objDetails.Salesman;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.ROHS = objDetails.ROHS;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.OfferStatusNo = objDetails.OfferStatusNo;
					obj.OfferStatusChangeDate = objDetails.OfferStatusChangeDate;
					obj.OfferStatusChangeLoginNo = objDetails.OfferStatusChangeLoginNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.SupplierName = objDetails.SupplierName;
					obj.SupplierEmail = objDetails.SupplierEmail;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.ProductName = objDetails.ProductName;
					obj.CurrencyCode = objDetails.CurrencyCode;
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
        /// Source
        /// Calls [usp_ipobom_source_Excess]
        /// </summary>
        public static List<Excess> IPOBOMSource(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? maxDate, out DateTime? outDate, System.Boolean? blnReferesh, bool IsServerLocal, System.Boolean? isPohub)
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
            List<ExcessDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Excess.IPOBOMSource(clientId, partSearch, index, StartDate, EndDate, out outDate, IsServerLocal, isPohub);
            if (lstDetails == null)
            {
                return new List<Excess>();
            }
            else
            {
                List<Excess> lst = new List<Excess>();
                foreach (ExcessDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Excess obj = new Rebound.GlobalTrader.BLL.Excess();
                    obj.ExcessId = objDetails.ExcessId;
                    obj.ExcessName = objDetails.ExcessName;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.OriginalEntryDate = objDetails.OriginalEntryDate;
                    obj.Salesman = objDetails.Salesman;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.ROHS = objDetails.ROHS;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.OfferStatusNo = objDetails.OfferStatusNo;
                    obj.OfferStatusChangeDate = objDetails.OfferStatusChangeDate;
                    obj.OfferStatusChangeLoginNo = objDetails.OfferStatusChangeLoginNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.SupplierName = objDetails.SupplierName;
                    obj.SupplierEmail = objDetails.SupplierEmail;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.ProductName = objDetails.ProductName;
                    obj.CurrencyCode = objDetails.CurrencyCode;
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

                    obj.MSL = objDetails.MSL;
                    obj.SPQ = objDetails.SPQ;
                    obj.LeadTime = objDetails.LeadTime;
                    obj.RoHSStatus = objDetails.RoHSStatus;
                    obj.FactorySealed = objDetails.FactorySealed;
                   // obj.IPOBOMNo = objDetails.IPOBOMNo;
                    obj.SupplierTotalQSA = objDetails.SupplierTotalQSA;
                    obj.SupplierLTB = objDetails.SupplierLTB;
                    obj.SupplierMOQ = objDetails.SupplierMOQ;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

		/// <summary>
		/// Update
		/// Calls [usp_update_Excess]
		/// </summary>
        public static bool Update(System.Int32? excessId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? offerStatusNo, System.Int32? companyNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, bool? isPoHub)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Excess.Update(excessId, part, manufacturerNo, dateCode, productNo, packageNo, quantity, price, currencyNo, offerStatusNo, companyNo, rohs, notes, updatedBy, isPoHub);
		}

        /// <summary>
        /// Update
        /// Calls [usp_update_Excess]
        /// </summary>
        public static bool IPOBOMUpdate(System.Int32? excessId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? offerStatusNo, System.Int32? companyNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, bool? isPoHub, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.String MSL, System.String SPQ, System.String leadTime, System.String factorySealed, System.String rohsStatus,System.Int32? mslLevelNo)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Excess.IPOBOMUpdate(excessId, part, manufacturerNo, dateCode, productNo, packageNo, quantity, price, currencyNo, offerStatusNo, companyNo, rohs, notes, updatedBy, isPoHub, supplierTotalQSA, supplierMOQ, supplierLTB, MSL, SPQ, leadTime, factorySealed, rohsStatus,mslLevelNo);
        }
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Excess]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.Excess.Update(ExcessId, Part, ManufacturerNo, DateCode, ProductNo, PackageNo, Quantity, Price, CurrencyNo, OfferStatusNo, CompanyNo, ROHS, Notes, UpdatedBy, null);
		}
		/// <summary>
		/// UpdateForSourcing
		/// Calls [usp_update_Excess_for_sourcing]
		/// </summary>
		public static bool UpdateForSourcing(System.Int32? excessId, System.Int32? quantity, System.Double? price, System.String notes, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Excess.UpdateForSourcing(excessId, quantity, price, notes, updatedBy);
		}
		/// <summary>
		/// UpdateOfferStatus
		/// Calls [usp_update_Excess_OfferStatus]
		/// </summary>
		public static bool UpdateOfferStatus(System.Int32? excessNo, System.Int32? offerStatusNo, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Excess.UpdateOfferStatus(excessNo, offerStatusNo, updatedBy);
		}

        private static Excess PopulateFromDBDetailsObject(ExcessDetails obj) {
            Excess objNew = new Excess();
			objNew.ExcessId = obj.ExcessId;
			objNew.ExcessName = obj.ExcessName;
			objNew.FullPart = obj.FullPart;
			objNew.Part = obj.Part;
			objNew.ManufacturerNo = obj.ManufacturerNo;
			objNew.DateCode = obj.DateCode;
			objNew.ProductNo = obj.ProductNo;
			objNew.PackageNo = obj.PackageNo;
			objNew.Quantity = obj.Quantity;
			objNew.Price = obj.Price;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.OriginalEntryDate = obj.OriginalEntryDate;
			objNew.Salesman = obj.Salesman;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.ROHS = obj.ROHS;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.OfferStatusNo = obj.OfferStatusNo;
			objNew.OfferStatusChangeDate = obj.OfferStatusChangeDate;
			objNew.OfferStatusChangeLoginNo = obj.OfferStatusChangeLoginNo;
			objNew.CompanyName = obj.CompanyName;
			objNew.Notes = obj.Notes;
			objNew.ManufacturerName = obj.ManufacturerName;
			objNew.ProductName = obj.ProductName;
			objNew.PackageName = obj.PackageName;
			objNew.ClientNo = obj.ClientNo;
			objNew.SupplierName = obj.SupplierName;
			objNew.SupplierEmail = obj.SupplierEmail;
			objNew.ManufacturerCode = obj.ManufacturerCode;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.SalesmanName = obj.SalesmanName;
			objNew.OfferStatusChangeEmployeeName = obj.OfferStatusChangeEmployeeName;
			objNew.ClientName = obj.ClientName;
			objNew.ClientDataVisibleToOthers = obj.ClientDataVisibleToOthers;
            return objNew;
        }
		
		#endregion
		
	}
}