//Marker    changed by      date           Remarks
//[001]      Vinay           12/08/2014     ESMS  Ticket Number: 	201
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
	
	public abstract class LotProvider : DataAccess {
		static private LotProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public LotProvider Instance {
			get {
				if (_instance == null) _instance = (LotProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Lots.ProviderType));
				return _instance;
			}
		}
		public LotProvider() {
			this.ConnectionString = Globals.Settings.Lots.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_Lot_for_Client]
		/// </summary>
		public abstract Int32 CountForClient(System.Int32? clientId);
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_Lot]
		/// </summary>
		public abstract List<LotDetails> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String lotCode, System.String lotName);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Lot]
		/// </summary>
		public abstract bool Delete(System.Int32? lotId);
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Lot_for_Client]
		/// </summary>
		public abstract List<LotDetails> DropDownForClient(System.Int32? clientId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Lot]
		/// </summary>
		public abstract Int32 Insert(System.Int32? clientNo, System.String lotName, System.Double? cost, System.Int32? currencyNo, System.Boolean? onHold, System.Boolean? consignment, System.String notes, System.String lotCode, System.Int32? updatedBy, System.Int32? LockForCustomerNo);
		/// <summary>
		/// Get
		/// Calls [usp_select_Lot]
		/// </summary>
		public abstract LotDetails Get(System.Int32? lotId);
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_Lot_for_Page]
		/// </summary>
		public abstract LotDetails GetForPage(System.Int32? lotId);
		/// <summary>
		/// Update
		/// Calls [usp_update_Lot]
		/// </summary>
        public abstract bool Update(System.Int32? lotId, System.Int32? clientNo, System.String lotName, System.Double? cost, System.Int32? currencyNo, System.Boolean? onHold, System.Boolean? consignment, System.String notes, System.String lotCode, System.Boolean? inactive, System.Int32? updatedBy, System.Int32? LockForCustomerNo);
		/// <summary>
		/// UpdateDelete
		/// Calls [usp_update_Lot_Delete]
		/// </summary>
		public abstract bool UpdateDelete(System.Int32? lotId, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new LotDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual LotDetails GetLotFromReader(DbDataReader reader) {
			LotDetails lot = new LotDetails();
			if (reader.HasRows) {
				lot.LotId = GetReaderValue_Int32(reader, "LotId", 0); //From: [Table]
				lot.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				lot.LotName = GetReaderValue_String(reader, "LotName", ""); //From: [usp_select_GoodsInLine]
				lot.Cost = GetReaderValue_NullableDouble(reader, "Cost", null); //From: [usp_selectAll_Login_Top_Salespersons]
				lot.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				lot.OnHold = GetReaderValue_Boolean(reader, "OnHold", false); //From: [Table]
				lot.Consignment = GetReaderValue_Boolean(reader, "Consignment", false); //From: [Table]
				lot.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				lot.LotCode = GetReaderValue_String(reader, "LotCode", ""); //From: [Table]
				lot.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				lot.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				lot.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				lot.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_list_Activity_by_Client_with_filter]
				lot.StockCount = GetReaderValue_NullableInt32(reader, "StockCount", null); //From: [usp_datalistnugget_Lot]
				lot.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_list_Activity_by_Client_with_filter]
				lot.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_Client]
			}
			return lot;
		}
	
		/// <summary>
		/// Returns a collection of LotDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<LotDetails> GetLotCollectionFromReader(DbDataReader reader) {
			List<LotDetails> lots = new List<LotDetails>();
			while (reader.Read()) lots.Add(GetLotFromReader(reader));
			return lots;
		}
        //[001] code start
        /// <summary>
        /// AutoSearch
        /// Calls [usp_autosearch_Lot]
        /// </summary>
        public abstract List<LotDetails> AutoSearch(System.Int32? clientId, System.String nameSearch);

        //[001] code end
		
		
	}
}