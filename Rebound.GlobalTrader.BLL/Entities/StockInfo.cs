/*
Marker     changed by      date         Remarks
[001]      Vinay           09/01/2013   Add more icon for all nuggets
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rebound.GlobalTrader.DAL;

namespace Rebound.GlobalTrader.BLL
{
    public partial class StockInfo : BizObject
    {
        #region Properties

        protected static DAL.StockInfoElement Settings
        {
            get { return Globals.Settings.StockInfos; }
        }

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
        /// ClientCode
        /// </summary>
        public System.String ClientCode { get; set; }
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
        public System.String ProductDescription { get; set; }
        #endregion

        #region Method

        /// <summary>
        /// Insert
        /// Calls [usp_insert_StockInfo]
        /// </summary>
        public static Int32 Insert(System.String part, System.String supplierPart, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo,System.Int32? supplierNo,System.String notes,System.String alternatePart,System.Int32? clientNo, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.StockInfo.Insert(part,supplierPart,  manufacturerNo, dateCode,  productNo, supplierNo, notes, alternatePart, clientNo,updatedBy);
            return objReturn;
        }
        /// <summary>
        /// Update
        /// Calls [usp_update_StockInfo]
        /// </summary>
        public static bool Update(System.Int32? stockInfoId, System.String part, System.String supplierPart, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? supplierNo, System.String notes, System.String alternatePart, System.Int32? clientNo, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.StockInfo.Update(stockInfoId, part, supplierPart, manufacturerNo, dateCode, productNo, supplierNo, notes, alternatePart, clientNo, updatedBy);
        }
        /// <summary>
        /// usp_ValidateAlternatePart
        /// </summary>
        /// <param name="alternatePart"></param>
        /// <returns></returns>
        public static bool ValidateAlternatePart(System.String alternatePart, System.Int32? stockInfoId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.StockInfo.ValidateAlternatePart(alternatePart, stockInfoId);
        }
        //[005] code start
        /// <summary>
        /// Source
        /// Calls [usp_source_StockInfo]
        /// </summary>
        public static List<StockInfo> Source(System.Int32? clientId, System.String partSearch, bool IsServerLocal)
        {
            List<StockInfoDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.StockInfo.Source(clientId, partSearch, IsServerLocal);
            if (lstDetails == null)
            {
                return new List<StockInfo>();
            }
            else
            {
                List<StockInfo> lst = new List<StockInfo>();
                foreach (StockInfoDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.StockInfo obj = new Rebound.GlobalTrader.BLL.StockInfo();
                    obj.StockInfoId = objDetails.StockInfoId;
                    obj.Part = objDetails.Part;
                    obj.AlternatePart = objDetails.AlternatePart;
                    obj.Notes = objDetails.Notes;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.DateCode = objDetails.DateCode;
                    obj.SupplierNo = objDetails.SupplierNo;
                    obj.SupplierName = objDetails.SupplierName;
                    obj.SupplierPart = objDetails.SupplierPart;
                    obj.SupplierPart = objDetails.SupplierPart;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.ClientName = objDetails.ClientName;
                    obj.ClientCode = objDetails.ClientCode; 
                    obj.DLUP = objDetails.DLUP;
                    obj.SupplierRMAId = objDetails.SupplierRMAId;
                    obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        //[005] code end
        /// <summary>
        /// Calls [usp_select_StockInfo]
        /// </summary>
        /// <param name="stockInfoId"></param>
        /// <returns></returns>
        public static StockInfo Get(System.Int32? stockInfoId)
        {
            Rebound.GlobalTrader.DAL.StockInfoDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.StockInfo.Get(stockInfoId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Rebound.GlobalTrader.BLL.StockInfo obj = new Rebound.GlobalTrader.BLL.StockInfo();
                obj.StockInfoId = objDetails.StockInfoId;
                obj.Part = objDetails.Part;
                obj.AlternatePart = objDetails.AlternatePart;
                obj.Notes = objDetails.Notes;
                obj.ManufacturerCode = objDetails.ManufacturerCode;
                obj.ManufacturerNo = objDetails.ManufacturerNo;
                obj.ProductNo = objDetails.ProductNo;
                obj.DateCode = objDetails.DateCode;
                obj.SupplierNo = objDetails.SupplierNo;
                obj.SupplierName = objDetails.SupplierName;
                obj.SupplierPart = objDetails.SupplierPart;
                obj.ProductDescription = objDetails.ProductDescription;

                objDetails = null;
                return obj;
            }
        }
        #endregion
    }
}
