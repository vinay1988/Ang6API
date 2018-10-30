using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL
{
    public class EmailComposerDetails
    {
        #region Constructors

        public EmailComposerDetails()
        {
            //To:Do Consructor logic here
        }
        #endregion
        #region Properties
        /// <summary>
        /// EmailComposerId
        /// </summary>
        public System.Int32 EmailComposerId { get; set; }
        /// <summary>
        /// Subject
        /// </summary>
        public System.String Subject { get; set; }
        /// <summary>
        /// EmailBody
        /// </summary>
        public System.String EmailBody { get; set; }
        /// <summary>
        /// ClientId
        /// </summary>
        public System.Int32 ClientNo { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime? DLUP { get; set; }

        #endregion
    }
}
