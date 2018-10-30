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
	
	public abstract class DivisionProvider : DataAccess {
		static private DivisionProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public DivisionProvider Instance {
			get {
				if (_instance == null) _instance = (DivisionProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Divisions.ProviderType));
				return _instance;
			}
		}
		public DivisionProvider() {
			this.ConnectionString = Globals.Settings.Divisions.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Division]
		/// </summary>
		public abstract bool Delete(System.Int32? divisionId);
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Division_for_Client]
		/// </summary>
		public abstract List<DivisionDetails> DropDownForClient(System.Int32? clientId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Division]
		/// </summary>
		public abstract Int32 Insert(System.Int32? clientNo, System.String divisionName, System.Int32? manager, System.Double? budget, System.String telephone, System.String fax, System.String email, System.String notes, System.String url, System.Int32? addressNo, System.Boolean? inactive, System.Int32? updatedBy,System.Boolean? agency);
		/// <summary>
		/// Get
		/// Calls [usp_select_Division]
		/// </summary>
		public abstract DivisionDetails Get(System.Int32? divisionId);
		/// <summary>
		/// GetHasDocumentHeader
		/// Calls [usp_select_Division_HasDocumentHeader]
		/// </summary>
		public abstract DivisionDetails GetHasDocumentHeader(System.Int32? divisionId);
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Division_for_Client]
		/// </summary>
		public abstract List<DivisionDetails> GetListForClient(System.Int32? clientId);
		/// <summary>
		/// Update
		/// Calls [usp_update_Division]
		/// </summary>
		public abstract bool Update(System.Int32? divisionId, System.Int32? clientNo, System.String divisionName, System.Int32? manager, System.Double? budget, System.String telephone, System.String fax, System.String email, System.String notes, System.String url, System.Int32? addressNo, System.Boolean? inactive, System.Int32? updatedBy,System.Boolean? agency);
		/// <summary>
		/// UpdateAddressNo
		/// Calls [usp_update_Division_AddressNo]
		/// </summary>
		public abstract bool UpdateAddressNo(System.Int32? divisionNo, System.Int32? addressNo, System.Int32? updatedBy);
		/// <summary>
		/// UpdateDocumentHeaderImage
		/// Calls [usp_update_Division_DocumentHeaderImage]
		/// </summary>
		public abstract bool UpdateDocumentHeaderImage(System.Int32? divisionNo, System.Boolean? hasDocumentHeaderImage, System.Int32? updatedBy);
		/// <summary>
		/// UpdateUseCompanyHeaderForInvoice
		/// Calls [usp_update_Division_UseCompanyHeaderForInvoice]
		/// </summary>
		public abstract bool UpdateUseCompanyHeaderForInvoice(System.Int32? divisionId, System.Boolean? useCompanyHeaderForInvoice, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new DivisionDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual DivisionDetails GetDivisionFromReader(DbDataReader reader) {
			DivisionDetails division = new DivisionDetails();
			if (reader.HasRows) {
				division.DivisionId = GetReaderValue_Int32(reader, "DivisionId", 0); //From: [Table]
				division.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				division.DivisionName = GetReaderValue_String(reader, "DivisionName", ""); //From: [usp_select_Credit]
				division.AddressNo = GetReaderValue_NullableInt32(reader, "AddressNo", null); //From: [Table]
				division.Manager = GetReaderValue_NullableInt32(reader, "Manager", null); //From: [Table]
				division.Budget = GetReaderValue_NullableDouble(reader, "Budget", null); //From: [Table]
				division.Telephone = GetReaderValue_String(reader, "Telephone", ""); //From: [Table]
				division.Fax = GetReaderValue_String(reader, "Fax", ""); //From: [Table]
				division.EMail = GetReaderValue_String(reader, "EMail", ""); //From: [Table]
				division.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				division.URL = GetReaderValue_String(reader, "URL", ""); //From: [Table]
				division.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				division.HasDocumentHeaderImage = GetReaderValue_Boolean(reader, "HasDocumentHeaderImage", false); //From: [Table]
				division.UseCompanyHeaderForInvoice = GetReaderValue_Boolean(reader, "UseCompanyHeaderForInvoice", false); //From: [Table]
				division.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				division.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				division.ManagerName = GetReaderValue_String(reader, "ManagerName", ""); //From: [usp_select_Division]
				division.NumberOfMembers = GetReaderValue_NullableInt32(reader, "NumberOfMembers", null); //From: [usp_selectAll_Division_for_Client]
			}
			return division;
		}
	
		/// <summary>
		/// Returns a collection of DivisionDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<DivisionDetails> GetDivisionCollectionFromReader(DbDataReader reader) {
			List<DivisionDetails> divisions = new List<DivisionDetails>();
			while (reader.Read()) divisions.Add(GetDivisionFromReader(reader));
			return divisions;
		}
		
		
	}
}