//Marker     Changed by      Date         Remarks
//[001]      Vinay           31/07/2012   Add enable/disable link in incoterms
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
	
	public abstract class IncotermProvider : DataAccess {
		static private IncotermProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public IncotermProvider Instance {
			get {
				if (_instance == null) _instance = (IncotermProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Incoterms.ProviderType));
				return _instance;
			}
		}
		public IncotermProvider() {
			this.ConnectionString = Globals.Settings.Incoterms.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Incoterm]
		/// </summary>
		public abstract bool Delete(System.Int32? incotermId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_Incoterm]
		/// </summary>
		public abstract List<IncotermDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Incoterm]
		/// </summary>
		public abstract Int32 Insert(System.String code, System.String name);
		/// <summary>
		/// Get
		/// Calls [usp_select_Incoterm]
		/// </summary>
		public abstract IncotermDetails Get(System.Int32? incotermId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_Incoterm]
		/// </summary>
		public abstract List<IncotermDetails> GetList();
        //[001] code start
		/// <summary>
		/// Update
		/// Calls [usp_update_Incoterm]
		/// </summary>
		public abstract bool Update(System.Int32? incotermId, System.String code, System.String name,System.Boolean Active);
        //[001] code end
		#endregion
				
		/// <summary>
		/// Returns a new IncotermDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual IncotermDetails GetIncotermFromReader(DbDataReader reader) {
			IncotermDetails incoterm = new IncotermDetails();
			if (reader.HasRows) {
				incoterm.IncotermId = GetReaderValue_Int32(reader, "IncotermId", 0); //From: [Table]
				incoterm.Code = GetReaderValue_String(reader, "Code", ""); //From: [Table]
				incoterm.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
			}
			return incoterm;
		}
	
		/// <summary>
		/// Returns a collection of IncotermDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<IncotermDetails> GetIncotermCollectionFromReader(DbDataReader reader) {
			List<IncotermDetails> incoterms = new List<IncotermDetails>();
			while (reader.Read()) incoterms.Add(GetIncotermFromReader(reader));
			return incoterms;
		}
		
		
	}
}