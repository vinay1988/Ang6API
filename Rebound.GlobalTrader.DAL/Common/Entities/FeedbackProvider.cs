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
	
	public abstract class FeedbackProvider : DataAccess {
		static private FeedbackProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public FeedbackProvider Instance {
			get {
				if (_instance == null) _instance = (FeedbackProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Feedbacks.ProviderType));
				return _instance;
			}
		}
		public FeedbackProvider() {
			this.ConnectionString = Globals.Settings.Feedbacks.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Feedback]
		/// </summary>
		public abstract Int32 Insert(System.Int32? loginNo, System.String feedbackText);

		#endregion
				
		/// <summary>
		/// Returns a new FeedbackDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual FeedbackDetails GetFeedbackFromReader(DbDataReader reader) {
			FeedbackDetails feedback = new FeedbackDetails();
			if (reader.HasRows) {
				feedback.FeedbackId = GetReaderValue_Int32(reader, "FeedbackId", 0); //From: [Table]
				feedback.LoginNo = GetReaderValue_Int32(reader, "LoginNo", 0); //From: [Table]
				feedback.FeedbackText = GetReaderValue_String(reader, "FeedbackText", ""); //From: [Table]
				feedback.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				feedback.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null); //From: [Table]
			}
			return feedback;
		}
	
		/// <summary>
		/// Returns a collection of FeedbackDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<FeedbackDetails> GetFeedbackCollectionFromReader(DbDataReader reader) {
			List<FeedbackDetails> feedbacks = new List<FeedbackDetails>();
			while (reader.Read()) feedbacks.Add(GetFeedbackFromReader(reader));
			return feedbacks;
		}
		
		
	}
}