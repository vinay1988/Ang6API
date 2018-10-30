/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document.
[002]      Aashu Singh     29-Aug-2018  Show so payment attachment
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rebound.GlobalTrader.DAL;

namespace Rebound.GlobalTrader.BLL
{
    public partial class PDFDocument : BizObject
    {
        #region Property
        /// <summary>
        /// DocumentPdfId
        /// </summary>
        public System.Int32 PDFDocumentId { get; set; }
        /// <summary>
        /// DocumentNo
        /// </summary>
        public System.Int32 PDFDocumentRefNo { get; set; }
        /// <summary>
        /// Caption
        /// </summary>
        public System.String Caption { get; set; }
        /// <summary>
        /// PdfFileName
        /// </summary>
        public System.String FileName { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime? DLUP { get; set; }
        //[002] start
        public System.String GeneratedFileName { get; set; }
        //[002] end
        #endregion
    }
}
