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
	
	public abstract class SaleCommissionProvider : DataAccess {
		static private SaleCommissionProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SaleCommissionProvider Instance {
			get {
				if (_instance == null) _instance = (SaleCommissionProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SaleCommissions.ProviderType));
				return _instance;
			}
		}
		public SaleCommissionProvider() {
			this.ConnectionString = Globals.Settings.SaleCommissions.ConnectionString;
		}

		#region Method Registrations
		

		#endregion
				
		/// <summary>
		/// Returns a new SaleCommissionDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SaleCommissionDetails GetSaleCommissionFromReader(DbDataReader reader) {
			SaleCommissionDetails saleCommission = new SaleCommissionDetails();
			if (reader.HasRows) {
				saleCommission.SaleCommissionId = GetReaderValue_Int32(reader, "SaleCommissionId", 0); //From: [Table]
				saleCommission.SaleTypeNo = GetReaderValue_Int32(reader, "SaleTypeNo", 0); //From: [Table]
				saleCommission.CommissionPercent = GetReaderValue_Double(reader, "CommissionPercent", 0); //From: [Table]
				saleCommission.UpToAmount = GetReaderValue_Double(reader, "UpToAmount", 0); //From: [Table]
				saleCommission.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				saleCommission.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
			}
			return saleCommission;
		}
	
		/// <summary>
		/// Returns a collection of SaleCommissionDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SaleCommissionDetails> GetSaleCommissionCollectionFromReader(DbDataReader reader) {
			List<SaleCommissionDetails> saleCommissions = new List<SaleCommissionDetails>();
			while (reader.Read()) saleCommissions.Add(GetSaleCommissionFromReader(reader));
			return saleCommissions;
		}
		
		
	}
}