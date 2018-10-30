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
	
	public abstract class SequencerProvider : DataAccess {
		static private SequencerProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SequencerProvider Instance {
			get {
				if (_instance == null) _instance = (SequencerProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Sequencers.ProviderType));
				return _instance;
			}
		}
		public SequencerProvider() {
			this.ConnectionString = Globals.Settings.Sequencers.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Sequencer]
		/// </summary>
		public abstract Int32 Insert(System.Int32? systemDocumentNo, System.Int32? clientNo, System.Int32? nextNumber, System.Int32? updatedBy);
		/// <summary>
		/// InsertDefaults
		/// Calls [usp_insert_Sequencer_Defaults]
		/// </summary>
		public abstract Int32 InsertDefaults(System.Int32? clientNo, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_Sequencer]
		/// </summary>
		public abstract SequencerDetails Get(System.Int32? systemDocumentNo, System.Int32? clientId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_Sequencer]
		/// </summary>
		public abstract List<SequencerDetails> GetList();
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Sequencer_for_Client]
		/// </summary>
		public abstract List<SequencerDetails> GetListForClient(System.Int32? clientId);
		/// <summary>
		/// Update
		/// Calls [usp_update_Sequencer]
		/// </summary>
		public abstract bool Update(System.Int32? systemDocumentNo, System.Int32? clientNo, System.Int32? nextNumber, System.Int32? updatedBy);
		/// <summary>
		/// UpdateNextNumber
		/// Calls [usp_update_Sequencer_NextNumber]
		/// </summary>
		public abstract bool UpdateNextNumber(System.Int32? clientNo, System.Int32? systemDocumentNo, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new SequencerDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SequencerDetails GetSequencerFromReader(DbDataReader reader) {
			SequencerDetails sequencer = new SequencerDetails();
			if (reader.HasRows) {
				sequencer.SystemDocumentNo = GetReaderValue_Int32(reader, "SystemDocumentNo", 0); //From: [Table]
				sequencer.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				sequencer.NextNumber = GetReaderValue_Int32(reader, "NextNumber", 0); //From: [Table]
				sequencer.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				sequencer.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				sequencer.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
			}
			return sequencer;
		}
	
		/// <summary>
		/// Returns a collection of SequencerDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SequencerDetails> GetSequencerCollectionFromReader(DbDataReader reader) {
			List<SequencerDetails> sequencers = new List<SequencerDetails>();
			while (reader.Read()) sequencers.Add(GetSequencerFromReader(reader));
			return sequencers;
		}
		
		
	}
}