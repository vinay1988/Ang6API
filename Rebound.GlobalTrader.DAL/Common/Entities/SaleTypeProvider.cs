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
	
	public abstract class SaleTypeProvider : DataAccess {
		static private SaleTypeProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SaleTypeProvider Instance {
			get {
				if (_instance == null) _instance = (SaleTypeProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SaleTypes.ProviderType));
				return _instance;
			}
		}
		public SaleTypeProvider() {
			this.ConnectionString = Globals.Settings.SaleTypes.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_SaleType]
		/// </summary>
		public abstract bool Delete(System.Int32? saleTypeId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SaleType]
		/// </summary>
		public abstract Int32 Insert(System.String name);
		/// <summary>
		/// Get
		/// Calls [usp_select_SaleType]
		/// </summary>
		public abstract SaleTypeDetails Get(System.Int32? saleTypeId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_SaleType]
		/// </summary>
		public abstract List<SaleTypeDetails> GetList();
		/// <summary>
		/// Update
		/// Calls [usp_update_SaleType]
		/// </summary>
		public abstract bool Update(System.String name, System.Int32? saleTypeId);

		#endregion
				
		/// <summary>
		/// Returns a new SaleTypeDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SaleTypeDetails GetSaleTypeFromReader(DbDataReader reader) {
			SaleTypeDetails saleType = new SaleTypeDetails();
			if (reader.HasRows) {
				saleType.SaleTypeId = GetReaderValue_Int32(reader, "SaleTypeId", 0); //From: [Table]
				saleType.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
			}
			return saleType;
		}
	
		/// <summary>
		/// Returns a collection of SaleTypeDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SaleTypeDetails> GetSaleTypeCollectionFromReader(DbDataReader reader) {
			List<SaleTypeDetails> saleTypes = new List<SaleTypeDetails>();
			while (reader.Read()) saleTypes.Add(GetSaleTypeFromReader(reader));
			return saleTypes;
		}
		
		
	}
}