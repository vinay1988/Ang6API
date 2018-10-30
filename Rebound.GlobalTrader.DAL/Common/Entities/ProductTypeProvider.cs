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
	
	public abstract class ProductTypeProvider : DataAccess {
		static private ProductTypeProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ProductTypeProvider Instance {
			get {
				if (_instance == null) _instance = (ProductTypeProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ProductTypes.ProviderType));
				return _instance;
			}
		}
		public ProductTypeProvider() {
			this.ConnectionString = Globals.Settings.ProductTypes.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Insert
		/// Calls [usp_insert_ProductType]
		/// </summary>
		public abstract Int32 Insert(System.String name);
		/// <summary>
		/// Get
		/// Calls [usp_select_ProductType]
		/// </summary>
		public abstract ProductTypeDetails Get(System.Int32? productTypeId);
		/// <summary>
		/// Update
		/// Calls [usp_update_ProductType]
		/// </summary>
		public abstract bool Update(System.String name, System.Int32? productTypeId);

		#endregion
				
		/// <summary>
		/// Returns a new ProductTypeDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ProductTypeDetails GetProductTypeFromReader(DbDataReader reader) {
			ProductTypeDetails productType = new ProductTypeDetails();
			if (reader.HasRows) {
				productType.ProductTypeId = GetReaderValue_Int32(reader, "ProductTypeId", 0); //From: [Table]
				productType.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
			}
			return productType;
		}
	
		/// <summary>
		/// Returns a collection of ProductTypeDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ProductTypeDetails> GetProductTypeCollectionFromReader(DbDataReader reader) {
			List<ProductTypeDetails> productTypes = new List<ProductTypeDetails>();
			while (reader.Read()) productTypes.Add(GetProductTypeFromReader(reader));
			return productTypes;
		}
		
		
	}
}