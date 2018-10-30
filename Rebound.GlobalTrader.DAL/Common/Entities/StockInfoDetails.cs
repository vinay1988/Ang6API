using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL
{
    public class StockInfoDetails
    {
        #region Constructors

        public StockInfoDetails() { }
		
		#endregion

        #region Properties

        /// <summary>
        /// StockInfoId
        /// </summary>
        public System.Int32 StockInfoId { get; set; }
        /// <summary>
        /// Part
        /// </summary>
        public System.String Part { get; set; }
        /// <summary>
        /// SupplierPart
        /// </summary>
        public System.String SupplierPart { get; set; }
        /// <summary>
        /// ManufacturerNo
        /// </summary>
        public System.Int32? ManufacturerNo { get; set; }
        /// <summary>
        /// DateCode
        /// </summary>
        public System.String DateCode { get; set; }
        /// <summary>
        /// ProductNo
        /// </summary>
        public System.Int32? ProductNo { get; set; }
        /// <summary>
        /// SupplierNo
        /// </summary>
        public System.Int32? SupplierNo { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// SupplierName
        /// </summary>
        public System.String SupplierName { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public System.String Notes { get; set; }
        /// <summary>
        /// ManufacturerName
        /// </summary>
        public System.String ManufacturerName { get; set; }
        /// <summary>
        /// ProductName
        /// </summary>
        public System.String ProductName { get; set; }
        /// <summary>
        /// ClientNo
        /// </summary>
        public System.Int32? ClientNo { get; set; }
        /// <summary>
        /// ManufacturerCode
        /// </summary>
        public System.String ManufacturerCode { get; set; }
        /// <summary>
        /// AlternatePart
        /// </summary>
        public System.String AlternatePart { get; set; }
        /// <summary>
        /// ClientName
        /// </summary>
        public System.String ClientName { get; set; }
        /// <summary>
        /// SupplierRMAId
        /// </summary>
        public System.Int32? SupplierRMAId { get; set; }
        /// <summary>
        /// SupplierRMANumber
        /// </summary>
        public System.Int32? SupplierRMANumber { get; set; }
        /// <summary>
        /// ClientCode
        /// </summary>
        public System.String ClientCode { get; set; }
        /// <summary>
        /// ProductDescription
        /// </summary>
        public System.String ProductDescription { get; set; }
        /// <summary>
        /// 
        #endregion
    }
}
