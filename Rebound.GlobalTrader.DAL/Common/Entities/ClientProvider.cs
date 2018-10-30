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
	
	public abstract class ClientProvider : DataAccess {
		static private ClientProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ClientProvider Instance {
			get {
				if (_instance == null) _instance = (ClientProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Clients.ProviderType));
				return _instance;
			}
		}
		public ClientProvider() {
			this.ConnectionString = Globals.Settings.Clients.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Count
		/// Calls [usp_count_Client]
		/// </summary>
		public abstract Int32 Count();
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Client]
		/// </summary>
		public abstract bool Delete(System.Int32? clientId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Client]
		/// </summary>
        public abstract Int32 Insert(System.String clientName, System.Int32? parentClientNo, System.Int32? currencyNo, System.String telephone, System.String fax, System.String email, System.String url, System.String resaleLicense, System.String companyRegistration, System.String documentFontName, System.Int32? documentFontSize, System.Int32? defaultSiteLanguageNo, System.Int32? updatedBy, System.Int32 localCurrencyNo, System.String clientCode);
		/// <summary>
		/// Get
		/// Calls [usp_select_Client]
		/// </summary>
		public abstract ClientDetails Get(System.Int32? clientId);
		/// <summary>
		/// GetLastMonthGP
		/// Calls [usp_select_Client_LastMonth_GP]
		/// </summary>
		public abstract ClientDetails GetLastMonthGP(System.Int32? clientId);
		/// <summary>
		/// GetLastYearGP
		/// Calls [usp_select_Client_LastYear_GP]
		/// </summary>
		public abstract ClientDetails GetLastYearGP(System.Int32? clientId);
		/// <summary>
		/// GetNextMonthGP
		/// Calls [usp_select_Client_NextMonth_GP]
		/// </summary>
		public abstract ClientDetails GetNextMonthGP(System.Int32? clientId);
		/// <summary>
		/// GetThisMonthGP
		/// Calls [usp_select_Client_ThisMonth_GP]
		/// </summary>
		public abstract ClientDetails GetThisMonthGP(System.Int32? clientId);
		/// <summary>
		/// GetThisYearGP
		/// Calls [usp_select_Client_ThisYear_GP]
		/// </summary>
		public abstract ClientDetails GetThisYearGP(System.Int32? clientId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_Client]
		/// </summary>
		public abstract List<ClientDetails> GetList();
		/// <summary>
		/// GetListActive
		/// Calls [usp_selectAll_Client_Active]
		/// </summary>
		public abstract List<ClientDetails> GetListActive();
       
		/// <summary>
		/// Update
		/// Calls [usp_update_Client]
		/// </summary>
		public abstract bool Update(System.Int32? clientId, System.String clientName, System.Int32? parentClientNo, System.Int32? currencyNo, System.String telephone, System.String fax, System.String email, System.String url, System.String resaleLicense, System.String companyRegistration, System.String documentFontName, System.Int32? documentFontSize, System.Boolean? inactive, System.Int32? updatedBy);
		/// <summary>
		/// UpdateDocumentHeaderImage
		/// Calls [usp_update_Client_DocumentHeaderImage]
		/// </summary>
		public abstract bool UpdateDocumentHeaderImage(System.Int32? clientNo, System.Boolean? hasDocumentHeaderImage, System.Int32? updatedBy);
		/// <summary>
		/// UpdateInactive
		/// Calls [usp_update_Client_Inactive]
		/// </summary>
		public abstract bool UpdateInactive(System.Int32? clientId, System.Boolean? inactive, System.Int32? updatedBy);
		/// <summary>
		/// UpdateOwnDataVisibleToOthers
		/// Calls [usp_update_Client_OwnDataVisibleToOthers]
		/// </summary>
		public abstract bool UpdateOwnDataVisibleToOthers(System.Int32? clientNo, System.Boolean? ownDataVisibleToOthers, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new ClientDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ClientDetails GetClientFromReader(DbDataReader reader) {
			ClientDetails client = new ClientDetails();
			if (reader.HasRows) {
				client.ClientId = GetReaderValue_Int32(reader, "ClientId", 0); //From: [Table]
				client.ClientName = GetReaderValue_String(reader, "ClientName", ""); //From: [Table]
				client.ParentClientNo = GetReaderValue_NullableInt32(reader, "ParentClientNo", null); //From: [Table]
				client.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [Table]
				client.Telephone = GetReaderValue_String(reader, "Telephone", ""); //From: [Table]
				client.Fax = GetReaderValue_String(reader, "Fax", ""); //From: [Table]
				client.EMail = GetReaderValue_String(reader, "EMail", ""); //From: [Table]
				client.URL = GetReaderValue_String(reader, "URL", ""); //From: [Table]
				client.ResaleLicense = GetReaderValue_String(reader, "ResaleLicense", ""); //From: [Table]
				client.CompanyRegistration = GetReaderValue_String(reader, "CompanyRegistration", ""); //From: [Table]
				client.DocumentFontName = GetReaderValue_String(reader, "DocumentFontName", ""); //From: [Table]
				client.DocumentFontSize = GetReaderValue_NullableInt32(reader, "DocumentFontSize", null); //From: [Table]
				client.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				client.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				client.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				client.Login = GetReaderValue_String(reader, "Login", ""); //From: [Table]
				client.DefaultSiteLanguageNo = GetReaderValue_Int32(reader, "DefaultSiteLanguageNo", 0); //From: [Table]
				client.HasDocumentHeaderImage = GetReaderValue_Boolean(reader, "HasDocumentHeaderImage", false); //From: [Table]
				client.Header = GetReaderValue_String(reader, "Header", ""); //From: [Table]
				client.OwnDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "OwnDataVisibleToOthers", null); //From: [Table]
				client.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_select_Client]
				client.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_Client]
				client.NumberOfUsers = GetReaderValue_NullableInt32(reader, "NumberOfUsers", null); //From: [usp_select_Client]
				client.OpenShippingCost = GetReaderValue_Double(reader, "OpenShippingCost", 0); //From: [usp_select_Client_LastMonth_GP]
				client.OpenFreightCharge = GetReaderValue_Double(reader, "OpenFreightCharge", 0); //From: [usp_select_Client_LastMonth_GP]
				client.OpenLandedCost = GetReaderValue_Double(reader, "OpenLandedCost", 0); //From: [usp_select_Client_LastMonth_GP]
				client.OpenSalesValue = GetReaderValue_Double(reader, "OpenSalesValue", 0); //From: [usp_select_Client_LastMonth_GP]
				client.ShippedShippingCost = GetReaderValue_Double(reader, "ShippedShippingCost", 0); //From: [usp_select_Client_LastMonth_GP]
				client.ShippedFreightCharge = GetReaderValue_Double(reader, "ShippedFreightCharge", 0); //From: [usp_select_Client_LastMonth_GP]
				client.ShippedLandedCost = GetReaderValue_Double(reader, "ShippedLandedCost", 0); //From: [usp_select_Client_LastMonth_GP]
				client.ShippedSalesValue = GetReaderValue_Double(reader, "ShippedSalesValue", 0); //From: [usp_select_Client_LastMonth_GP]
			}
			return client;
		}
	
		/// <summary>
		/// Returns a collection of ClientDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ClientDetails> GetClientCollectionFromReader(DbDataReader reader) {
			List<ClientDetails> clients = new List<ClientDetails>();
			while (reader.Read()) clients.Add(GetClientFromReader(reader));
			return clients;
		}
		
		
	}
}