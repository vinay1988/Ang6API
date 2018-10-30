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
	
	public abstract class ProductProvider : DataAccess {
		static private ProductProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ProductProvider Instance {
			get {
				if (_instance == null) _instance = (ProductProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Products.ProviderType));
				return _instance;
			}
		}
		public ProductProvider() {
			this.ConnectionString = Globals.Settings.Products.ConnectionString;
		}

		#region Method Registrations
        /// <summary>
        /// AutoSearch
        /// Calls [usp_autosearch_Product]
        /// </summary>
        public abstract List<ProductDetails> AutoSearch(System.String nameSearch, System.Int32? clientId);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Product]
		/// </summary>
		public abstract bool Delete(System.Int32? productId);
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Product_for_Client]
		/// </summary>
		public abstract List<ProductDetails> DropDownForClient(System.Int32? clientId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Product]
		/// </summary>
		public abstract Int32 Insert(System.String productName, System.String productDescription, System.Int32? clientNo, System.String dutyCode, System.Int32? updatedBy);

        /// <summary>
        /// Insert
        /// Calls [usp_insert_GlobalProduct]
        /// </summary>
        ///  // Adding parameter GlobalProductNameNo to Add record with respective ProductNameId selected (Suhail )
        public abstract Int32 GlobalInsert(System.String productName, System.String productDescription, System.Int32? clientNo, System.String dutyCode, System.Int32? updatedBy, System.Int32? GlobalProductNameNo, System.Double? dutyRateValue, System.Boolean? hazarders);


        /// <summary>
		/// Get
		/// Calls [usp_select_Product]
		/// </summary>
		public abstract ProductDetails Get(System.Int32? productId);
		/// <summary>
		/// GetLandedCostCalculation
		/// Calls [usp_select_Product_LandedCostCalculation]
		/// </summary>
		public abstract ProductDetails GetLandedCostCalculation(System.Int32? quantity, System.DateTime? datePoint, System.Int32? currencyNo, System.Double? cost, System.Double? shippingCost, System.Boolean? applyDuty, System.Int32? productNo);
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Product_for_Client]
		/// </summary>
		public abstract List<ProductDetails> GetListForClient(System.Int32? clientId);

        /// <summary>
        /// usp_selectAll_Product_for_Global
        /// </summary>
        /// <param name="GlobalProductId"></param>
        /// <returns></returns>
        public abstract List<ProductDetails> GetProductList(System.Int32? GlobalProductId);
        /// <summary>
        /// GetListForClient
        /// Calls [usp_selectAll_GlobalProduct]
        /// </summary>
        /// // Adding parameterProductNameId to get record on basis of selected ProductNameId from Global product name (Suhail )
        public abstract List<ProductDetails> GetListGlobalProduct(System.Int32? GlobalProductNameId);

		/// <summary>
		/// Update
		/// Calls [usp_update_Product]
		/// </summary>
		public abstract bool Update(System.Int32? productId, System.String productName, System.String productDescription, System.Int32? clientNo, System.String dutyCode, System.Boolean? inactive, System.Int32? updatedBy);

        /// <summary>
        /// Update
        /// Calls [usp_update_GlobalProduct]
        /// </summary>
        public abstract bool GlobalUpdate(System.Int32? productId, System.String productName, System.String productDescription, System.Int32? clientNo, System.String dutyCode, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? hazarders);
       
        /// <summary>
        /// Update
        /// Calls [usp_update_Product_Globally]
        /// </summary>
        public abstract bool UpdateProductGlobally(System.Int32? productId, System.Boolean? inactive, System.Int32? updatedBy);

        /// <summary>
        /// AutoSearch by Client and Global Product
        /// Calls [usp_autosearch_Product_By_GlobalProduct_Client]
        /// </summary>
        public abstract List<ProductDetails> ProductByGlobalAndClient(System.String nameSearch, System.Int32? clientId, System.Int32? globalProductNo);

		#endregion
				
		/// <summary>
		/// Returns a new ProductDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ProductDetails GetProductFromReader(DbDataReader reader) {
			ProductDetails product = new ProductDetails();
			if (reader.HasRows) {
				product.ProductId = GetReaderValue_Int32(reader, "ProductId", 0); //From: [Table]
				product.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [usp_selectAll_Allocation]
				product.ProductDescription = GetReaderValue_String(reader, "ProductDescription", ""); //From: [usp_selectAll_Allocation]
				product.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				product.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				product.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				product.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				product.DutyCode = GetReaderValue_String(reader, "DutyCode", ""); //From: [Table]
				product.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null); //From: [usp_selectAll_Allocation]
				product.CurrentDutyRate = GetReaderValue_NullableDouble(reader, "CurrentDutyRate", null); //From: [usp_selectAll_Product_for_Client]
			}
			return product;
		}
	
		/// <summary>
		/// Returns a collection of ProductDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ProductDetails> GetProductCollectionFromReader(DbDataReader reader) {
			List<ProductDetails> products = new List<ProductDetails>();
			while (reader.Read()) products.Add(GetProductFromReader(reader));
			return products;
		}

        /// <summary>
        /// GetListForClient
        /// Calls [usp_selectAll_GlobalProductName]
        /// </summary>
        public abstract List<ProductDetails> GetListGlobalProductName();

        /// <summary>
        /// Insert
        /// Calls [usp_insert_GlobalProductName]
        /// </summary>
        public abstract bool GlobalNameInsert(System.String productName, System.Int32? updatedBy);


        /// <summary>
        /// Update
        /// Calls [usp_update_GlobalProductName]
        /// </summary>
        public abstract bool GlobalUpdateName(System.Int32? productId, System.String productName,System.Boolean? inactive, System.Int32? updatedBy);
       
	}
}