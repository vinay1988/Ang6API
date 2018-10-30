using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Rebound.GlobalTrader.DAL {
	
	public class StockImageDetails {
		
		#region Constructors
		
		public StockImageDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// StockImageId (from Table)
		/// </summary>
		public System.Int32 StockImageId { get; set; }
		/// <summary>
		/// StockNo (from Table)
		/// </summary>
		public System.Int32 StockNo { get; set; }
		/// <summary>
		/// Caption (from Table)
		/// </summary>
		public System.String Caption { get; set; }
		/// <summary>
		/// ThumbnailImage (from Table)
		/// </summary>
		public System.Byte[] ThumbnailImage { get; set; }
		/// <summary>
		/// ThumbnailImageContentType (from Table)
		/// </summary>
		public System.String ThumbnailImageContentType { get; set; }
		/// <summary>
		/// MediumImage (from Table)
		/// </summary>
		public System.Byte[] MediumImage { get; set; }
		/// <summary>
		/// MediumImageContentType (from Table)
		/// </summary>
		public System.String MediumImageContentType { get; set; }
		/// <summary>
		/// FullsizeImage (from Table)
		/// </summary>
		public System.Byte[] FullsizeImage { get; set; }
		/// <summary>
		/// FullsizeImageContentType (from Table)
		/// </summary>
		public System.String FullsizeImageContentType { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime? DLUP { get; set; }
        /// <summary>
        /// ImageName
        /// </summary>
        public System.String ImageName { get; set; }
        /// <summary>
        /// UpdatedByName
        /// </summary>
        public System.String UpdatedByName { get; set; }
        /// <summary>
        /// ImageDocumentRefNo (from Table)
        /// </summary>
        public System.Int32 ImageDocumentRefNo { get; set; }
		#endregion

	}
}