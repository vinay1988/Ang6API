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
	
	public abstract class ServiceProvider : DataAccess {
		static private ServiceProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ServiceProvider Instance {
			get {
				if (_instance == null) _instance = (ServiceProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Services.ProviderType));
				return _instance;
			}
		}
		public ServiceProvider() {
			this.ConnectionString = Globals.Settings.Services.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// AutoSearch
		/// Calls [usp_autosearch_Service]
		/// </summary>
		public abstract List<ServiceDetails> AutoSearch(System.Int32? clientId, System.String nameSearch);
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_Service_for_Client]
		/// </summary>
		public abstract Int32 CountForClient(System.Int32? clientId);
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_Service]
		/// </summary>
		public abstract List<ServiceDetails> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String serviceName, System.String serviceDescription, System.Int32? lotNo);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Service]
		/// </summary>
		public abstract bool Delete(System.Int32? serviceId);
		/// <summary>
		/// DeleteUnallocatedForLot
		/// Calls [usp_delete_Service_Unallocated_for_Lot]
		/// </summary>
		public abstract bool DeleteUnallocatedForLot(System.Int32? lotNo);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Service]
		/// </summary>
		public abstract Int32 Insert(System.Int32? clientNo, System.String serviceName, System.String serviceDescription, System.Double? price, System.Double? cost, System.String notes, System.Int32? lotNo, System.Int32? updatedBy);
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_Service]
		/// </summary>
		public abstract List<ServiceDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String serviceName, System.String serviceDescription, System.Int32? lotNo);
		/// <summary>
		/// Get
		/// Calls [usp_select_Service]
		/// </summary>
		public abstract ServiceDetails Get(System.Int32? serviceId);
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_Service_for_Page]
		/// </summary>
		public abstract ServiceDetails GetForPage(System.Int32? serviceId);
		/// <summary>
		/// GetListForLot
		/// Calls [usp_selectAll_Service_for_Lot]
		/// </summary>
		public abstract List<ServiceDetails> GetListForLot(System.Int32? lotId);
		/// <summary>
		/// Update
		/// Calls [usp_update_Service]
		/// </summary>
		public abstract bool Update(System.Int32? serviceId, System.Int32? clientNo, System.String serviceName, System.String serviceDescription, System.Double? price, System.Double? cost, System.String notes, System.Int32? lotNo, System.Boolean? inactive, System.Int32? updatedBy);
		/// <summary>
		/// UpdateMakeInactive
		/// Calls [usp_update_Service_MakeInactive]
		/// </summary>
		public abstract bool UpdateMakeInactive(System.Int32? serviceId, System.Int32? updatedBy);
		/// <summary>
		/// UpdateTransferLot
		/// Calls [usp_update_Service_Transfer_Lot]
		/// </summary>
		public abstract bool UpdateTransferLot(System.Int32? oldNotNo, System.Int32? newLotNo);

		#endregion
				
		/// <summary>
		/// Returns a new ServiceDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ServiceDetails GetServiceFromReader(DbDataReader reader) {
			ServiceDetails service = new ServiceDetails();
			if (reader.HasRows) {
				service.ServiceId = GetReaderValue_Int32(reader, "ServiceId", 0); //From: [Table]
				service.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				service.ServiceName = GetReaderValue_String(reader, "ServiceName", ""); //From: [Table]
				service.ServiceDescription = GetReaderValue_String(reader, "ServiceDescription", ""); //From: [Table]
				service.Price = GetReaderValue_NullableDouble(reader, "Price", null); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				service.Cost = GetReaderValue_NullableDouble(reader, "Cost", null); //From: [usp_selectAll_Login_Top_Salespersons]
				service.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				service.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null); //From: [Table]
				service.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				service.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				service.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				service.LotName = GetReaderValue_String(reader, "LotName", ""); //From: [usp_select_GoodsInLine]
				service.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_list_Activity_by_Client_with_filter]
				service.Allocations = GetReaderValue_NullableInt32(reader, "Allocations", null); //From: [usp_select_Service]
			}
			return service;
		}
	
		/// <summary>
		/// Returns a collection of ServiceDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ServiceDetails> GetServiceCollectionFromReader(DbDataReader reader) {
			List<ServiceDetails> services = new List<ServiceDetails>();
			while (reader.Read()) services.Add(GetServiceFromReader(reader));
			return services;
		}
		
		
	}
}