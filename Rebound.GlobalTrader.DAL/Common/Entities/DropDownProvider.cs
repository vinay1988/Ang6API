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
	
	public abstract class DropDownProvider : DataAccess {
		static private DropDownProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public DropDownProvider Instance {
			get {
				if (_instance == null) _instance = (DropDownProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.DropDowns.ProviderType));
				return _instance;
			}
		}
		public DropDownProvider() {
			this.ConnectionString = Globals.Settings.DropDowns.ConnectionString;
		}

		#region Method Registrations
		

		#endregion
				
		/// <summary>
		/// Returns a new DropDownDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual DropDownDetails GetDropDownFromReader(DbDataReader reader) {
			DropDownDetails dropDown = new DropDownDetails();
			if (reader.HasRows) {
				dropDown.DropDownId = GetReaderValue_Int32(reader, "DropDownId", 0); //From: [Table]
				dropDown.ShortName = GetReaderValue_String(reader, "ShortName", ""); //From: [Table]
				dropDown.Description = GetReaderValue_String(reader, "Description", ""); //From: [Table]
			}
			return dropDown;
		}
	
		/// <summary>
		/// Returns a collection of DropDownDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<DropDownDetails> GetDropDownCollectionFromReader(DbDataReader reader) {
			List<DropDownDetails> dropDowns = new List<DropDownDetails>();
			while (reader.Read()) dropDowns.Add(GetDropDownFromReader(reader));
			return dropDowns;
		}
		
		
	}
}