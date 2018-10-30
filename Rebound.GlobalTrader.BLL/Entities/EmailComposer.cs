using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.BLL
{
    public class EmailComposer : BizObject
    {
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

        #region Methods
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="clientNo"></param>
        /// <param name="subject"></param>
        /// <param name="EmailBody"></param>
        /// <returns></returns>
        public static Int32 Insert(System.Int32? clientNo, System.String subject, System.String EmailBody)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.EmailComposer.Insert(clientNo, subject, EmailBody);
            return objReturn;
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="clientNo"></param>
        /// <param name="subject"></param>
        /// <param name="EmailBody"></param>
        /// <returns></returns>
        public static bool Update(System.Int32? clientNo, System.String subject, System.String EmailBody)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.EmailComposer.Update(clientNo, subject, EmailBody);
        }
        /// <summary>
        /// <param name="ClientNo"></param>
        /// <returns></returns>
        public static EmailComposer GetEmailComposerByClientNo(System.Int32? ClientNo)
        {
            Rebound.GlobalTrader.DAL.EmailComposerDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.EmailComposer.GetEmailComposerByClientNo(ClientNo);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                EmailComposer obj = new EmailComposer();
                obj.EmailComposerId = objDetails.EmailComposerId;
                obj.ClientNo = objDetails.ClientNo;
                obj.Subject = objDetails.Subject;
                obj.EmailBody = objDetails.EmailBody;
                objDetails = null;
                return obj;
            }
        }
        #endregion
    }
}
