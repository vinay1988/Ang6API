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
	
	public abstract class HelpHowToProvider : DataAccess {
		static private HelpHowToProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public HelpHowToProvider Instance {
			get {
				if (_instance == null) _instance = (HelpHowToProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.HelpHowTos.ProviderType));
				return _instance;
			}
		}
		public HelpHowToProvider() {
			this.ConnectionString = Globals.Settings.HelpHowTos.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_HelpHowTo]
		/// </summary>
		public abstract List<HelpHowToDetails> GetList();
		/// <summary>
		/// GetListForGroup
		/// Calls [usp_selectAll_HelpHowTo_for_Group]
		/// </summary>
		public abstract List<HelpHowToDetails> GetListForGroup(System.Int32? helpGroupNo);

		#endregion
				
		/// <summary>
		/// Returns a new HelpHowToDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual HelpHowToDetails GetHelpHowToFromReader(DbDataReader reader) {
			HelpHowToDetails helpHowTo = new HelpHowToDetails();
			if (reader.HasRows) {
				helpHowTo.HelpHowToId = GetReaderValue_Int32(reader, "HelpHowToId", 0); //From: [Table]
				helpHowTo.HelpGroupNo = GetReaderValue_Int32(reader, "HelpGroupNo", 0); //From: [Table]
				helpHowTo.Title = GetReaderValue_String(reader, "Title", ""); //From: [Table]
				helpHowTo.ImageName = GetReaderValue_String(reader, "ImageName", ""); //From: [Table]
				helpHowTo.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null); //From: [Table]
			}
			return helpHowTo;
		}
	
		/// <summary>
		/// Returns a collection of HelpHowToDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<HelpHowToDetails> GetHelpHowToCollectionFromReader(DbDataReader reader) {
			List<HelpHowToDetails> helpHowTos = new List<HelpHowToDetails>();
			while (reader.Read()) helpHowTos.Add(GetHelpHowToFromReader(reader));
			return helpHowTos;
		}
		
		
	}
}