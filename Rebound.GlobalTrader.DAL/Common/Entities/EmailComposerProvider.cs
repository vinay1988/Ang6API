using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL
{
    public abstract class EmailComposerProvider : DataAccess
    {
        static private EmailComposerProvider _instance = null;
          /// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public EmailComposerProvider Instance {
			get {
                if (_instance == null) _instance = (EmailComposerProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.EmailComposers.ProviderType));
				return _instance;
			}
		}
        public EmailComposerProvider()
        {
			this.ConnectionString = Globals.Settings.EmailComposers.ConnectionString;
        }
        #region Method Registrations
        /// <summary>
        /// usp_insert_EmailComposer
        /// </summary>
        /// <param name="clientNo"></param>
        /// <param name="subject"></param>
        /// <param name="EmailBody"></param>
        /// <returns></returns>
        public abstract Int32 Insert(System.Int32? clientNo, System.String subject, System.String EmailBody);
        /// <summary>
        /// usp_update_EmailComposer
        /// </summary>
        /// <param name="clientNo"></param>
        /// <param name="subject"></param>
        /// <param name="EmailBody"></param>
        /// <returns></returns>
        public abstract bool Update(System.Int32? clientNo, System.String subject, System.String EmailBody);
        /// <summary>
        /// usp_select_EmailComposerByClientNo
        /// </summary>
        /// <param name="ClientNo"></param>
        /// <returns></returns>
        public abstract EmailComposerDetails GetEmailComposerByClientNo(System.Int32? ClientNo);
        #endregion
    }
}
