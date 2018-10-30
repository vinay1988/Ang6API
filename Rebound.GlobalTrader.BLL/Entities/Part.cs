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
		public partial class Part : BizObject {
		
		#region Properties

		protected static DAL.PartElement Settings {
			get { return Globals.Settings.Parts; }
		}

		/// <summary>
		/// PartId
		/// </summary>
		public System.Int32 PartId { get; set; }		
		/// <summary>
		/// FullPart
		/// </summary>
		public System.String FullPart { get; set; }		
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
		/// MinimumQuantity
		/// </summary>
		public System.Int32? MinimumQuantity { get; set; }		
		/// <summary>
		/// ReOrderQuantity
		/// </summary>
		public System.Int32? ReOrderQuantity { get; set; }		
		/// <summary>
		/// LeadTime
		/// </summary>
		public System.Int32? LeadTime { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// ResalePrice
		/// </summary>
		public System.Double? ResalePrice { get; set; }		
		/// <summary>
		/// ROHSCompliant
		/// </summary>
		public System.Boolean ROHSCompliant { get; set; }		
		/// <summary>
		/// MasterPart
		/// </summary>
		public System.Boolean? MasterPart { get; set; }		
		/// <summary>
		/// GoldenPart
		/// </summary>
		public System.Boolean? GoldenPart { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// PartTitle
		/// </summary>
		public System.String PartTitle { get; set; }		
		/// <summary>
		/// PartName
		/// </summary>
		public System.String PartName { get; set; }

      
        public System.String PartNameWithManufacture { get; set; }
       

        public System.String Productname { get; set; }
        public System.String DateCode { get; set; }
        public System.String Packagename { get; set; }
        public System.Int32 ROHSNo { get; set; }
        public System.String ManufacturerName { get; set; }
        public System.String DateCodeOriginal { get; set; }
        public System.String ProductDescription { get; set; }
		#endregion
		
		#region Methods
		
		/// <summary>
		/// AutoSearch
		/// Calls [usp_autosearch_Part]
		/// </summary>
		public static List<Part> AutoSearch(System.Int32? clientId, System.String partSearch) {
			List<PartDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Part.AutoSearch(clientId, partSearch);
			if (lstDetails == null) {
				return new List<Part>();
			} else {
				List<Part> lst = new List<Part>();
				foreach (PartDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Part obj = new Rebound.GlobalTrader.BLL.Part();
					obj.PartName = objDetails.PartName;
                 
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}


        /// <summary>
        /// AutoSearch
        /// Calls [usp_PartSearch_GRID]
        /// </summary>
        public static List<Part> CustReqPartsGRID(System.Int32? clientId, System.String partSearch)
        {
            List<PartDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Part.CustReqPartsGRID(clientId, partSearch);
            if (lstDetails == null)
            {
                return new List<Part>();
            }
            else
            {
                List<Part> lst = new List<Part>();
                foreach (PartDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Part obj = new Rebound.GlobalTrader.BLL.Part();
                    obj.PartName = objDetails.PartName;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.PartNameWithManufacture = objDetails.PartNameWithManufacture;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.Productname = objDetails.Productname;
                    obj.Packagename = objDetails.Packagename;
                    obj.DateCode = objDetails.DateCode;
                    obj.DateCodeOriginal = objDetails.DateCodeOriginal;
                    obj.ROHSNo = objDetails.ROHSNo;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.ProductInactive = objDetails.ProductInactive;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// AutoSearch
        /// Calls [usp_autosearch_Part_New]
        /// </summary>
        public static List<Part> CustReqPartSearch(System.Int32? clientId, System.String partSearch)
        {
            List<PartDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Part.CustReqPartSearch(clientId, partSearch);
            if (lstDetails == null)
            {
                return new List<Part>();
            }
            else
            {
                List<Part> lst = new List<Part>();
                foreach (PartDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Part obj = new Rebound.GlobalTrader.BLL.Part();
                    obj.PartName = objDetails.PartName;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.PartNameWithManufacture = objDetails.PartNameWithManufacture;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Customer Requirements Fill data by Part Search
        /// Calls [usp_autosearch_CustReqPart]
        /// </summary>
        public static List<Part> CustReqPart(System.Int32? clientId, System.String partSearch, System.String ids, System.String DateCode)
        {
            List<PartDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Part.CustReqPart(clientId, partSearch, ids,DateCode);
            if (lstDetails == null)
            {
                return new List<Part>();
            }
            else
            {
                List<Part> lst = new List<Part>();
                foreach (PartDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Part obj = new Rebound.GlobalTrader.BLL.Part();
                    obj.PartName = objDetails.PartName;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.PartNameWithManufacture = objDetails.PartNameWithManufacture;

                    obj.Productname = objDetails.Productname;
                    obj.Packagename = objDetails.Packagename;
                    obj.DateCode = objDetails.DateCode;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ROHSNo = objDetails.ROHSNo;


                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Part]
		/// </summary>
		public static Int32 Insert(System.String fullPart, System.Int32? manufacturerNo, System.Int32? packageNo, System.Int32? productNo, System.Int32? minimumQuantity, System.Int32? reOrderQuantity, System.Int32? leadTime, System.Int32? clientNo, System.Double? resalePrice, System.String partTitle, System.Boolean? masterPart, System.Boolean? goldenPart, System.Boolean? rohsCompliant, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Part.Insert(fullPart, manufacturerNo, packageNo, productNo, minimumQuantity, reOrderQuantity, leadTime, clientNo, resalePrice, partTitle, masterPart, goldenPart, rohsCompliant, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Part]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Part.Insert(FullPart, ManufacturerNo, PackageNo, ProductNo, MinimumQuantity, ReOrderQuantity, LeadTime, ClientNo, ResalePrice, PartTitle, MasterPart, GoldenPart, ROHSCompliant, UpdatedBy);
		}

        private static Part PopulateFromDBDetailsObject(PartDetails obj) {
            Part objNew = new Part();
			objNew.PartId = obj.PartId;
			objNew.FullPart = obj.FullPart;
			objNew.ManufacturerNo = obj.ManufacturerNo;
			objNew.PackageNo = obj.PackageNo;
			objNew.ProductNo = obj.ProductNo;
			objNew.MinimumQuantity = obj.MinimumQuantity;
			objNew.ReOrderQuantity = obj.ReOrderQuantity;
			objNew.LeadTime = obj.LeadTime;
			objNew.ClientNo = obj.ClientNo;
			objNew.ResalePrice = obj.ResalePrice;
			objNew.ROHSCompliant = obj.ROHSCompliant;
			objNew.MasterPart = obj.MasterPart;
			objNew.GoldenPart = obj.GoldenPart;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.PartTitle = obj.PartTitle;
			objNew.PartName = obj.PartName;
            return objNew;
        }
		
		#endregion
		
	}
}