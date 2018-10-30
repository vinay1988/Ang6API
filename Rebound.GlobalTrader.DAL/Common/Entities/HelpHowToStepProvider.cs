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
	
	public abstract class HelpHowToStepProvider : DataAccess {
		static private HelpHowToStepProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public HelpHowToStepProvider Instance {
			get {
				if (_instance == null) _instance = (HelpHowToStepProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.HelpHowToSteps.ProviderType));
				return _instance;
			}
		}
		public HelpHowToStepProvider() {
			this.ConnectionString = Globals.Settings.HelpHowToSteps.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_HelpHowToStep]
		/// </summary>
		public abstract List<HelpHowToStepDetails> GetList(System.Int32? helpHowToNo);

		#endregion
				
		/// <summary>
		/// Returns a new HelpHowToStepDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual HelpHowToStepDetails GetHelpHowToStepFromReader(DbDataReader reader) {
			HelpHowToStepDetails helpHowToStep = new HelpHowToStepDetails();
			if (reader.HasRows) {
				helpHowToStep.HelpHowToStepId = GetReaderValue_Int32(reader, "HelpHowToStepId", 0); //From: [Table]
				helpHowToStep.HelpHowToNo = GetReaderValue_Int32(reader, "HelpHowToNo", 0); //From: [Table]
				helpHowToStep.HTMLText = GetReaderValue_String(reader, "HTMLText", ""); //From: [Table]
			}
			return helpHowToStep;
		}
	
		/// <summary>
		/// Returns a collection of HelpHowToStepDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<HelpHowToStepDetails> GetHelpHowToStepCollectionFromReader(DbDataReader reader) {
			List<HelpHowToStepDetails> helpHowToSteps = new List<HelpHowToStepDetails>();
			while (reader.Read()) helpHowToSteps.Add(GetHelpHowToStepFromReader(reader));
			return helpHowToSteps;
		}
		
		
	}
}