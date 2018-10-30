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
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class StockImageProvider : DataAccess {
		static private StockImageProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public StockImageProvider Instance {
			get {
				if (_instance == null) _instance = (StockImageProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.StockImages.ProviderType));
				return _instance;
			}
		}
		public StockImageProvider() {
			this.ConnectionString = Globals.Settings.StockImages.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountForStock
		/// Calls [usp_count_StockImage_ForStock]
		/// </summary>
		public abstract Int32 CountForStock(System.Int32? stockNo);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_StockImage]
		/// </summary>
		public abstract bool Delete(System.Int32? stockImageNo);
        //[001] code start
        /// <summary>
        /// Delete
        /// Calls [usp_delete_StockImage]
        /// </summary>
        public abstract bool DeleteSAN(System.Int32? stockImageNo);
        //[001] code end
		/// <summary>
		/// DeleteForStock
		/// Calls [usp_delete_StockImage_for_Stock]
		/// </summary>
		public abstract bool DeleteForStock(System.Int32? stockNo);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_StockImage]
		/// </summary>
		public abstract Int32 Insert(System.Int32? stockNo, System.String caption, System.String thumbnailImageContentType, System.String mediumImageContentType, System.Byte[] fullsizeImage, System.String fullsizeImageContentType, System.Int32? updatedBy);
        //[001] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_StockImageForSAN]
        /// </summary>
        public abstract Int32 Insert(System.Int32? stockNo, System.String caption, System.String stockImageName, System.Int32? updatedBy);
        //[001] code end
		/// <summary>
		/// InsertCopyFromStockToStock
		/// Calls [usp_insert_StockImage_CopyFromStockToStock]
		/// </summary>
		public abstract Int32 InsertCopyFromStockToStock(System.Int32? oldStockNo, System.Int32? newStockNo, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_StockImage]
		/// </summary>
		public abstract StockImageDetails Get(System.Int32? stockImageId);
		/// <summary>
		/// GetFullSizeImage
		/// Calls [usp_select_StockImage_FullSizeImage]
		/// </summary>
		public abstract StockImageDetails GetFullSizeImage(System.Int32? stockImageId);
		/// <summary>
		/// GetMediumImage
		/// Calls [usp_select_StockImage_MediumImage]
		/// </summary>
		public abstract StockImageDetails GetMediumImage(System.Int32? stockImageId);
		/// <summary>
		/// GetThumbnailImage
		/// Calls [usp_select_StockImage_ThumbnailImage]
		/// </summary>
		public abstract StockImageDetails GetThumbnailImage(System.Int32? stockImageId);
		/// <summary>
		/// GetListForStock
		/// Calls [usp_selectAll_StockImage_for_Stock]
		/// </summary>
		public abstract List<StockImageDetails> GetListForStock(System.Int32? stockId);
        //[001] code start
        /// <summary>
        /// GetListForStock
        /// Calls [usp_selectAll_StockImage_for_Stock]
        /// </summary>
        public abstract List<StockImageDetails> GetListForStockSAN(System.Int32? stockId);
        //[001] code end
		/// <summary>
		/// Update
		/// Calls [usp_update_StockImage]
		/// </summary>
		public abstract bool Update(System.Int32? stockImageId, System.Int32? stockNo, System.String caption, System.Int32? updatedBy);
        //[001] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_SourcingImage]
        /// </summary>
        public abstract Int32 InsertSourcing(System.Int32? sourcingNo, System.String caption, System.String stockImageName, System.Int32? updatedBy);
        /// <summary>
        /// Delete
        /// Calls [usp_delete_SourcingImage]
        /// </summary>
        public abstract bool DeleteSourcing(System.Int32? sourcingImageNo);
		#endregion
				
		/// <summary>
		/// Returns a new StockImageDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual StockImageDetails GetStockImageFromReader(DbDataReader reader) {
			StockImageDetails stockImage = new StockImageDetails();
			if (reader.HasRows) {
				stockImage.StockImageId = GetReaderValue_Int32(reader, "StockImageId", 0); //From: [Table]
				stockImage.StockNo = GetReaderValue_Int32(reader, "StockNo", 0); //From: [Table]
				stockImage.Caption = GetReaderValue_String(reader, "Caption", ""); //From: [Table]
				stockImage.ThumbnailImage = GetReaderValue_ByteArray(reader, "ThumbnailImage", null); //From: [Table]
				stockImage.ThumbnailImageContentType = GetReaderValue_String(reader, "ThumbnailImageContentType", ""); //From: [Table]
				stockImage.MediumImage = GetReaderValue_ByteArray(reader, "MediumImage", null); //From: [Table]
				stockImage.MediumImageContentType = GetReaderValue_String(reader, "MediumImageContentType", ""); //From: [Table]
				stockImage.FullsizeImage = GetReaderValue_ByteArray(reader, "FullsizeImage", null); //From: [Table]
				stockImage.FullsizeImageContentType = GetReaderValue_String(reader, "FullsizeImageContentType", ""); //From: [Table]
				stockImage.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				stockImage.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null); //From: [Table]
			}
			return stockImage;
		}
	
		/// <summary>
		/// Returns a collection of StockImageDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<StockImageDetails> GetStockImageCollectionFromReader(DbDataReader reader) {
			List<StockImageDetails> stockImages = new List<StockImageDetails>();
			while (reader.Read()) stockImages.Add(GetStockImageFromReader(reader));
			return stockImages;
		}
		
		
	}
}