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
		public partial class Manufacturer : BizObject {
		
		#region Properties

		protected static DAL.ManufacturerElement Settings {
			get { return Globals.Settings.Manufacturers; }
		}

		/// <summary>
		/// ManufacturerId
		/// </summary>
		public System.Int32 ManufacturerId { get; set; }		
		/// <summary>
		/// ManufacturerName
		/// </summary>
		public System.String ManufacturerName { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// ManufacturerCode
		/// </summary>
		public System.String ManufacturerCode { get; set; }		
		/// <summary>
		/// Inactive
		/// </summary>
		public System.Boolean Inactive { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// URL
		/// </summary>
		public System.String URL { get; set; }		
		/// <summary>
		/// FullName
		/// </summary>
		public System.String FullName { get; set; }		
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }

        /// <summary>
        /// IsPDFAvailable
        /// </summary>
        public System.Boolean IsPDFAvailable { get; set; }
        /// <summary>
        /// ConflictResource
        /// </summary>
        public System.String ConflictResource { get; set; }

		#endregion
		
		#region Methods
		
		/// <summary>
		/// AutoSearch
		/// Calls [usp_autosearch_Manufacturer]
		/// </summary>
		public static List<Manufacturer> AutoSearch(System.String nameSearch,Boolean? showInactive) {
            List<ManufacturerDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.AutoSearch(nameSearch, showInactive);
			if (lstDetails == null) {
				return new List<Manufacturer>();
			} else {
				List<Manufacturer> lst = new List<Manufacturer>();
				foreach (ManufacturerDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Manufacturer obj = new Rebound.GlobalTrader.BLL.Manufacturer();
					obj.ManufacturerId = objDetails.ManufacturerId;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.FullName = objDetails.FullName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Count
		/// Calls [usp_count_Manufacturer]
		/// </summary>
		public static Int32 Count() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.Count();
		}		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_Manufacturer]
		/// </summary>
		public static List<Manufacturer> DataListNugget(System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.String codeSearch) {
			List<ManufacturerDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.DataListNugget(orderBy, sortDir, pageIndex, pageSize, nameSearch, codeSearch);
			if (lstDetails == null) {
				return new List<Manufacturer>();
			} else {
				List<Manufacturer> lst = new List<Manufacturer>();
				foreach (ManufacturerDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Manufacturer obj = new Rebound.GlobalTrader.BLL.Manufacturer();
					obj.ManufacturerId = objDetails.ManufacturerId;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.Inactive = objDetails.Inactive;
					obj.URL = objDetails.URL;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
                    obj.ConflictResource = objDetails.ConflictResource;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Manufacturer]
		/// </summary>
		public static bool Delete(System.Int32? manufacturerId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.Delete(manufacturerId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_Manufacturer]
		/// </summary>
		public static List<Manufacturer> DropDown() {
			List<ManufacturerDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.DropDown();
			if (lstDetails == null) {
				return new List<Manufacturer>();
			} else {
				List<Manufacturer> lst = new List<Manufacturer>();
				foreach (ManufacturerDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Manufacturer obj = new Rebound.GlobalTrader.BLL.Manufacturer();
					obj.ManufacturerId = objDetails.ManufacturerId;
					obj.ManufacturerName = objDetails.ManufacturerName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Manufacturer]
		/// </summary>
		public static Int32 Insert(System.String manufacturerName, System.String notes, System.String manufacturerCode, System.Int32? updatedBy, System.String url) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.Insert(manufacturerName, notes, manufacturerCode, updatedBy, url);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Manufacturer]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.Insert(ManufacturerName, Notes, ManufacturerCode, UpdatedBy, URL);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Manufacturer]
		/// </summary>
		public static Manufacturer Get(System.Int32? manufacturerId) {
			Rebound.GlobalTrader.DAL.ManufacturerDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.Get(manufacturerId);
			if (objDetails == null) {
				return null;
			} else {
				Manufacturer obj = new Manufacturer();
				obj.ManufacturerId = objDetails.ManufacturerId;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.Notes = objDetails.Notes;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.URL = objDetails.URL;
                obj.IsPDFAvailable = objDetails.IsPDFAvailable;
                obj.ConflictResource = objDetails.ConflictResource;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Manufacturer]
		/// </summary>
		public static bool Update(System.Int32? manufacturerId, System.String manufacturerName, System.String notes, System.String manufacturerCode, System.Boolean? inactive, System.Int32? updatedBy, System.String url,System.String conflictResource) {
            return Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.Update(manufacturerId, manufacturerName, notes, manufacturerCode, inactive, updatedBy, url, conflictResource);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Manufacturer]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.Update(ManufacturerId, ManufacturerName, Notes, ManufacturerCode, Inactive, UpdatedBy, URL,ConflictResource);
		}

        private static Manufacturer PopulateFromDBDetailsObject(ManufacturerDetails obj) {
            Manufacturer objNew = new Manufacturer();
			objNew.ManufacturerId = obj.ManufacturerId;
			objNew.ManufacturerName = obj.ManufacturerName;
			objNew.Notes = obj.Notes;
			objNew.ManufacturerCode = obj.ManufacturerCode;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.URL = obj.URL;
			objNew.FullName = obj.FullName;
			objNew.RowNum = obj.RowNum;
			objNew.RowCnt = obj.RowCnt;
            return objNew;
        }

        
        /// <summary>
        /// GetPDFListForManufacturer
        /// Calls [usp_selectAll_PDF_for_Manufacturer]
        /// </summary>
        public static List<PDFDocument> GetPDFListForManufacturer(System.Int32? ManufacturerNo)
        {
            List<PDFDocumentDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.GetPDFListForManufacturer(ManufacturerNo);
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
        /// GetExcelListForManufacturer
        /// Calls [usp_selectAll_Excel_for_Manufacturer]
        /// </summary>
        public static List<PDFDocument> GetExcelListForManufacturer(System.Int32? ManufacturerNo)
        {
            List<PDFDocumentDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.GetExcelListForManufacturer(ManufacturerNo);
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
        /// Calls [usp_insert_ManufacturerPDF]
        /// </summary>
        /// <param name="ManufacturerNo"></param>
        /// <param name="Caption"></param>
        /// <param name="FileName"></param>
        /// <param name="UpdatedBy"></param>
        /// <returns></returns>
        public static Int32 Insert(System.Int32? ManufacturerNo, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.Insert(ManufacturerNo, Caption, FileName, UpdatedBy);
            return objReturn;
        }

        /// <summary>
        /// Calls [usp_insert_ManufacturerExcel]
        /// </summary>
        /// <param name="ManufacturerNo"></param>
        /// <param name="Caption"></param>
        /// <param name="FileName"></param>
        /// <param name="UpdatedBy"></param>
        /// <returns></returns>
        public static Int32 InsertExcel(System.Int32? ManufacturerNo, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.InsertExcel(ManufacturerNo, Caption, FileName, UpdatedBy);
            return objReturn;
        }




        /// <summary>
        /// Calls [usp_delete_ManufacturerPDF]
        /// </summary>
        /// <param name="InvoicePdfId"></param>
        /// <returns></returns>
        public static bool DeleteManufacturerPDF(System.Int32? ManufacturerPdfId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.DeleteManufacturerPDF(ManufacturerPdfId);
        }


        /// <summary>
        /// Calls [usp_delete_ManufacturerExcel]
        /// </summary>
        /// <param name="InvoicePdfId"></param>
        /// <returns></returns>
        public static bool DeleteManufacturerExcel(System.Int32? ManufacturerExcelId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Manufacturer.DeleteManufacturerExcel(ManufacturerExcelId);
        }


		#endregion
		
	}
}