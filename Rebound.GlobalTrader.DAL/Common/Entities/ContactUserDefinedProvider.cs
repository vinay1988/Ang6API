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
	
	public abstract class ContactUserDefinedProvider : DataAccess {
		static private ContactUserDefinedProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ContactUserDefinedProvider Instance {
			get {
				if (_instance == null) _instance = (ContactUserDefinedProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ContactUserDefineds.ProviderType));
				return _instance;
			}
		}
		public ContactUserDefinedProvider() {
			this.ConnectionString = Globals.Settings.ContactUserDefineds.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_ContactUserDefined]
		/// </summary>
		public abstract bool Delete(System.Int32? contactNo, System.Int32? rowNo);
		/// <summary>
		/// DeleteForContact
		/// Calls [usp_delete_ContactUserDefined_for_Contact]
		/// </summary>
		public abstract bool DeleteForContact(System.Int32? contactNo);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_ContactUserDefined]
		/// </summary>
		public abstract Int32 Insert(System.Int32? contactNo, System.Int32? rowNo, System.String userDefinedHeading, System.String userDefinedValue, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_ContactUserDefined]
		/// </summary>
		public abstract ContactUserDefinedDetails Get(System.Int32? contactNo, System.Int32? rowNo);
		/// <summary>
		/// GetListForContact
		/// Calls [usp_selectAll_ContactUserDefined_for_Contact]
		/// </summary>
		public abstract List<ContactUserDefinedDetails> GetListForContact(System.Int32? contactNo);
		/// <summary>
		/// Update
		/// Calls [usp_update_ContactUserDefined]
		/// </summary>
		public abstract bool Update(System.Int32? contactNo, System.Int32? rowNo, System.String userDefinedHeading, System.String userDefinedValue, System.Boolean? inactive, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new ContactUserDefinedDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ContactUserDefinedDetails GetContactUserDefinedFromReader(DbDataReader reader) {
			ContactUserDefinedDetails contactUserDefined = new ContactUserDefinedDetails();
			if (reader.HasRows) {
				contactUserDefined.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [Table]
				contactUserDefined.RowNo = GetReaderValue_Int32(reader, "RowNo", 0); //From: [Table]
				contactUserDefined.UserDefinedHeading = GetReaderValue_String(reader, "UserDefinedHeading", ""); //From: [Table]
				contactUserDefined.UserDefinedValue = GetReaderValue_String(reader, "UserDefinedValue", ""); //From: [Table]
				contactUserDefined.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				contactUserDefined.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				contactUserDefined.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
			}
			return contactUserDefined;
		}
	
		/// <summary>
		/// Returns a collection of ContactUserDefinedDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ContactUserDefinedDetails> GetContactUserDefinedCollectionFromReader(DbDataReader reader) {
			List<ContactUserDefinedDetails> contactUserDefineds = new List<ContactUserDefinedDetails>();
			while (reader.Read()) contactUserDefineds.Add(GetContactUserDefinedFromReader(reader));
			return contactUserDefineds;
		}
		
		
	}
}