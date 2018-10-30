//Marker     Changed by      Date         Remarks
//[001]      Vinay           06/3/2014     CR:- Image Utility 
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
		public partial class StockImage : BizObject {
		
		#region Properties

		protected static DAL.StockImageElement Settings {
			get { return Globals.Settings.StockImages; }
		}

		/// <summary>
		/// StockImageId
		/// </summary>
		public System.Int32 StockImageId { get; set; }		
		/// <summary>
		/// StockNo
		/// </summary>
		public System.Int32 StockNo { get; set; }		
		/// <summary>
		/// Caption
		/// </summary>
		public System.String Caption { get; set; }		
		/// <summary>
		/// ThumbnailImage
		/// </summary>
		public System.Byte[] ThumbnailImage { get; set; }		
		/// <summary>
		/// ThumbnailImageContentType
		/// </summary>
		public System.String ThumbnailImageContentType { get; set; }		
		/// <summary>
		/// MediumImage
		/// </summary>
		public System.Byte[] MediumImage { get; set; }		
		/// <summary>
		/// MediumImageContentType
		/// </summary>
		public System.String MediumImageContentType { get; set; }		
		/// <summary>
		/// FullsizeImage
		/// </summary>
		public System.Byte[] FullsizeImage { get; set; }		
		/// <summary>
		/// FullsizeImageContentType
		/// </summary>
		public System.String FullsizeImageContentType { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime? DLUP { get; set; }
        /// <summary>
        /// ImageName
        /// </summary>
        public System.String ImageName { get; set; }
        public System.String By { get; set; }
        /// <summary>
        /// ImageDocumentRefNo (from Table)
        /// </summary>
        public System.Int32 ImageDocumentRefNo { get; set; }
		#endregion
		
		#region Methods
		
		/// <summary>
		/// CountForStock
		/// Calls [usp_count_StockImage_ForStock]
		/// </summary>
		public static Int32 CountForStock(System.Int32? stockNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockImage.CountForStock(stockNo);
		}		/// <summary>
		/// Delete
		/// Calls [usp_delete_StockImage]
		/// </summary>
		public static bool Delete(System.Int32? stockImageNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockImage.Delete(stockImageNo);
		}
        //[001] code start
        /// Delete
        /// Calls [usp_delete_StockImage]
        /// </summary>
        public static bool DeleteSAN(System.Int32? stockImageNo)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.StockImage.DeleteSAN(stockImageNo);
        }
        //[001] code end
		/// <summary>
		/// DeleteForStock
		/// Calls [usp_delete_StockImage_for_Stock]
		/// </summary>
		public static bool DeleteForStock(System.Int32? stockNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockImage.DeleteForStock(stockNo);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_StockImage]
		/// </summary>
		public static Int32 Insert(System.Int32? stockNo, System.String caption, System.String thumbnailImageContentType, System.String mediumImageContentType, System.Byte[] fullsizeImage, System.String fullsizeImageContentType, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.StockImage.Insert(stockNo, caption, thumbnailImageContentType, mediumImageContentType, fullsizeImage, fullsizeImageContentType, updatedBy);
			return objReturn;
		}
        //[001] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_StockImageForSAN]
        /// </summary>
        public static Int32 Insert(System.Int32? stockNo, System.String caption, System.String stockImageName, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.StockImage.Insert(stockNo, caption, stockImageName, updatedBy);
            return objReturn;
        }
        //[001] code end
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_StockImage]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockImage.Insert(StockNo, Caption, ThumbnailImageContentType, MediumImageContentType, FullsizeImage, FullsizeImageContentType, UpdatedBy);
		}
		/// <summary>
		/// InsertCopyFromStockToStock
		/// Calls [usp_insert_StockImage_CopyFromStockToStock]
		/// </summary>
		public static Int32 InsertCopyFromStockToStock(System.Int32? oldStockNo, System.Int32? newStockNo, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.StockImage.InsertCopyFromStockToStock(oldStockNo, newStockNo, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_StockImage]
		/// </summary>
		public static StockImage Get(System.Int32? stockImageId) {
			Rebound.GlobalTrader.DAL.StockImageDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.StockImage.Get(stockImageId);
			if (objDetails == null) {
				return null;
			} else {
				StockImage obj = new StockImage();
				obj.StockImageId = objDetails.StockImageId;
				obj.StockNo = objDetails.StockNo;
				obj.Caption = objDetails.Caption;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetFullSizeImage
		/// Calls [usp_select_StockImage_FullSizeImage]
		/// </summary>
		public static StockImage GetFullSizeImage(System.Int32? stockImageId) {
			Rebound.GlobalTrader.DAL.StockImageDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.StockImage.GetFullSizeImage(stockImageId);
			if (objDetails == null) {
				return null;
			} else {
				StockImage obj = new StockImage();
				obj.StockImageId = objDetails.StockImageId;
				obj.StockNo = objDetails.StockNo;
				obj.FullsizeImage = objDetails.FullsizeImage;
				obj.FullsizeImageContentType = objDetails.FullsizeImageContentType;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetMediumImage
		/// Calls [usp_select_StockImage_MediumImage]
		/// </summary>
		public static StockImage GetMediumImage(System.Int32? stockImageId) {
			Rebound.GlobalTrader.DAL.StockImageDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.StockImage.GetMediumImage(stockImageId);
			if (objDetails == null) {
				return null;
			} else {
				StockImage obj = new StockImage();
				obj.StockImageId = objDetails.StockImageId;
				obj.StockNo = objDetails.StockNo;
				obj.MediumImage = objDetails.MediumImage;
				obj.MediumImageContentType = objDetails.MediumImageContentType;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetThumbnailImage
		/// Calls [usp_select_StockImage_ThumbnailImage]
		/// </summary>
		public static StockImage GetThumbnailImage(System.Int32? stockImageId) {
			Rebound.GlobalTrader.DAL.StockImageDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.StockImage.GetThumbnailImage(stockImageId);
			if (objDetails == null) {
				return null;
			} else {
				StockImage obj = new StockImage();
				obj.StockImageId = objDetails.StockImageId;
				obj.StockNo = objDetails.StockNo;
				obj.ThumbnailImage = objDetails.ThumbnailImage;
				obj.ThumbnailImageContentType = objDetails.ThumbnailImageContentType;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForStock
		/// Calls [usp_selectAll_StockImage_for_Stock]
		/// </summary>
		public static List<StockImage> GetListForStock(System.Int32? stockId) {
			List<StockImageDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.StockImage.GetListForStock(stockId);
			if (lstDetails == null) {
				return new List<StockImage>();
			} else {
				List<StockImage> lst = new List<StockImage>();
				foreach (StockImageDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.StockImage obj = new Rebound.GlobalTrader.BLL.StockImage();
					obj.StockImageId = objDetails.StockImageId;
					obj.StockNo = objDetails.StockNo;
					obj.Caption = objDetails.Caption;
                    obj.ImageName = objDetails.ImageName;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
        //[001] code start
        /// <summary>
        /// GetListForStock
        /// Calls [usp_selectAll_StockImage_for_Stock]
        /// </summary>
        public static List<StockImage> GetListForStockSAN(System.Int32? stockId)
        {
            List<StockImageDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.StockImage.GetListForStockSAN(stockId);
            if (lstDetails == null)
            {
                return new List<StockImage>();
            }
            else
            {
                List<StockImage> lst = new List<StockImage>();
                foreach (StockImageDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.StockImage obj = new Rebound.GlobalTrader.BLL.StockImage();
                    obj.StockImageId = objDetails.StockImageId;
                    obj.StockNo = objDetails.StockNo;
                    obj.Caption = objDetails.Caption;
                    obj.ImageName = objDetails.ImageName;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        //[001] code end
		/// <summary>
		/// Update
		/// Calls [usp_update_StockImage]
		/// </summary>
		public static bool Update(System.Int32? stockImageId, System.Int32? stockNo, System.String caption, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockImage.Update(stockImageId, stockNo, caption, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_StockImage]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockImage.Update(StockImageId, StockNo, Caption, UpdatedBy);
		}

        //[001] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_SourcingImage]
        /// </summary>
        public static Int32 InsertSourcing(System.Int32? sourcingNo, System.String caption, System.String stockImageName, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.StockImage.InsertSourcing(sourcingNo, caption, stockImageName, updatedBy);
            return objReturn;
        }

        //[001] code start
        /// Delete
        /// Calls [usp_delete_SourcingImage]
        /// </summary>
        public static bool DeleteSourcing(System.Int32? sourcingImageNo)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.StockImage.DeleteSourcing(sourcingImageNo);
        }

        private static StockImage PopulateFromDBDetailsObject(StockImageDetails obj) {
            StockImage objNew = new StockImage();
			objNew.StockImageId = obj.StockImageId;
			objNew.StockNo = obj.StockNo;
			objNew.Caption = obj.Caption;
			objNew.ThumbnailImage = obj.ThumbnailImage;
			objNew.ThumbnailImageContentType = obj.ThumbnailImageContentType;
			objNew.MediumImage = obj.MediumImage;
			objNew.MediumImageContentType = obj.MediumImageContentType;
			objNew.FullsizeImage = obj.FullsizeImage;
			objNew.FullsizeImageContentType = obj.FullsizeImageContentType;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}