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
	
	public abstract class HelpFaqProvider : DataAccess {
		static private HelpFaqProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public HelpFaqProvider Instance {
			get {
				if (_instance == null) _instance = (HelpFaqProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.HelpFaqs.ProviderType));
				return _instance;
			}
		}
		public HelpFaqProvider() {
			this.ConnectionString = Globals.Settings.HelpFaqs.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Get
		/// Calls [usp_select_HelpFAQ]
		/// </summary>
		public abstract HelpFaqDetails Get(System.Int32? helpFaqId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_HelpFAQ]
		/// </summary>
		public abstract List<HelpFaqDetails> GetList();
		/// <summary>
		/// GetListForGroup
		/// Calls [usp_selectAll_HelpFAQ_for_Group]
		/// </summary>
		public abstract List<HelpFaqDetails> GetListForGroup(System.Int32? helpGroupNo);

		#endregion
				
		/// <summary>
		/// Returns a new HelpFaqDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual HelpFaqDetails GetHelpFaqFromReader(DbDataReader reader) {
			HelpFaqDetails helpFaq = new HelpFaqDetails();
			if (reader.HasRows) {
				helpFaq.HelpFAQId = GetReaderValue_Int32(reader, "HelpFAQId", 0); //From: [Table]
				helpFaq.HelpGroupNo = GetReaderValue_Int32(reader, "HelpGroupNo", 0); //From: [Table]
				helpFaq.Question = GetReaderValue_String(reader, "Question", ""); //From: [Table]
				helpFaq.Answer = GetReaderValue_String(reader, "Answer", ""); //From: [Table]
				helpFaq.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null); //From: [Table]
			}
			return helpFaq;
		}
	
		/// <summary>
		/// Returns a collection of HelpFaqDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<HelpFaqDetails> GetHelpFaqCollectionFromReader(DbDataReader reader) {
			List<HelpFaqDetails> helpFaqs = new List<HelpFaqDetails>();
			while (reader.Read()) helpFaqs.Add(GetHelpFaqFromReader(reader));
			return helpFaqs;
		}
		
		
	}
}