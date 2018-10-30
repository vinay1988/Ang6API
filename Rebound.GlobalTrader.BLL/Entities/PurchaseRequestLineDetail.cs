using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rebound.GlobalTrader.DAL.Common.Entities;

namespace Rebound.GlobalTrader.BLL
{
    public class PurchaseRequestLineDetail : BizObject
    {

        #region Constructor
        protected static DAL.PurchaseRequestLineDetailElement Settings
        {
            get { return Globals.Settings.PurchaseRequestLineDetails; }
        }
        #endregion
        #region Properties
        public int? PurchaseRequestLineDetailId { get; set; }
        public int? PurchaseRequestLineNo { get; set; }
        public int? CompanyNo { get; set; }
        public string CompanyName { get; set; }
        public double? Price { get; set; }
        public System.String SPQ { get; set; }
        public System.String LeadTime { get; set; }
        public System.String RoHSStatus { get; set; }
        public System.String FactorySealed { get; set; }
        public System.String MSL { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DLUP { get; set; }

        public string ManufacturerName { get; set; }
        public string DateCode { get; set; }
        public string PackageType { get; set; }
        public string ProductType { get; set; }
        public string MOQ { get; set; }
        public string TotalQSA { get; set; }
        public string LTB { get; set; }
        public string Notes { get; set; }
        public System.Int32? CurrencyNo { get; set; }
        public System.Int32? GlobalCurrencyNo { get; set; }
        public string CurrencyCode { get; set; }
        public System.Int32? MSLLevelNo { get; set; }




        #endregion
        /// <summary>
        /// Calls [usp_selectAll_PurchaseRequestLineDetail]
        /// </summary>
        public static List<BLL.PurchaseRequestLineDetail> GetListLines(System.Int32? poQuoteId)
        {
            List<PurchaseRequestLineDetailDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.PurchaseRequestLineDetail.GetListLines(poQuoteId);
            if (lstDetails == null)
            {
                return new List<PurchaseRequestLineDetail>();
            }
            else
            {
                List<BLL.PurchaseRequestLineDetail> lst = new List<BLL.PurchaseRequestLineDetail>();
                foreach (var objDetails in lstDetails)
                {
                    BLL.PurchaseRequestLineDetail obj = new BLL.PurchaseRequestLineDetail();
                    obj.PurchaseRequestLineDetailId = objDetails.PurchaseRequestLineDetailId;
                    obj.PurchaseRequestLineNo = objDetails.PurchaseRequestLineNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.Price = objDetails.Price;
                    obj.SPQ = objDetails.SPQ;
                    obj.LeadTime = objDetails.LeadTime;
                    obj.RoHSStatus = objDetails.RoHSStatus;
                    obj.FactorySealed = objDetails.FactorySealed;
                    obj.MSL = objDetails.MSL;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.DateCode = objDetails.DateCode;
                    obj.PackageType = objDetails.PackageType;
                    obj.ProductType = objDetails.ProductType;
                    obj.MOQ = objDetails.MOQ;
                    obj.TotalQSA = objDetails.TotalQSA;
                    obj.LTB = objDetails.LTB;
                    obj.Notes = objDetails.Notes;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.GlobalCurrencyNo = objDetails.GlobalCurrencyNo;
                    obj.MSLLevelNo = objDetails.MSLLevelNo;


                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// Calls [usp_insert_PurchaseRequestLineDetail]
        /// </summary>
        public static Int32 Insert(int? purchaseRequestLineNo, int? supplier, double? price, string spq, string leadTime, string rohsS, string factorySealed, string msl, string manufacturerName,string dateCode,string packageType,string productType,string mOQ,string totalQSA,string lTB,string notes,int? updatedBy,System.Int32? currencyNo,System.Int32? mslLevelNo)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.PurchaseRequestLineDetail.Insert(purchaseRequestLineNo, supplier, price, spq, leadTime, rohsS, factorySealed, msl, manufacturerName, dateCode, packageType, productType, mOQ, totalQSA, lTB, notes, updatedBy, currencyNo, mslLevelNo);
            return objReturn;
        }

        /// <summary>
        /// Calls [usp_delete_PurchaseRequestLineDetail]
        /// </summary>
        public static bool Delete(System.Int32? purchaseRequestLineDetailId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.PurchaseRequestLineDetail.Delete(purchaseRequestLineDetailId);
        }

        /// <summary>
        /// Calls [usp_update_PurchaseRequestLineDetail]
        /// </summary>
        public static bool Update(System.Int32? purchaseRequestLineDetailId, int? purchaseRequestLineNo, int? CompanyNo, double? Price, string spq, string leadTime, string rohs, string factorySealed, string msl, string manufacturerName, string dateCode, string packageType, string productType, string mOQ, string totalQSA, string lTB, string notes, int? updatedBy, System.Int32? currencyNo,System.Int32? mslLevelNo) 
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.PurchaseRequestLineDetail.Update(purchaseRequestLineDetailId, purchaseRequestLineNo, CompanyNo, Price, spq, leadTime, rohs, factorySealed, msl, manufacturerName, dateCode, packageType, productType, mOQ, totalQSA, lTB, notes, updatedBy, currencyNo, mslLevelNo);
        }

        /// <summary>
        /// Calls [usp_delete_PurchaseRequestLineDetail]
        /// </summary>
        public static PurchaseRequestLineDetail Get(System.Int32? purchaseRequestLineDetailId)
        {
            var objDetails = Rebound.GlobalTrader.DAL.SiteProvider.PurchaseRequestLineDetail.Get(purchaseRequestLineDetailId);
            BLL.PurchaseRequestLineDetail obj = new BLL.PurchaseRequestLineDetail();
            obj.PurchaseRequestLineDetailId = objDetails.PurchaseRequestLineDetailId;
            obj.PurchaseRequestLineNo = objDetails.PurchaseRequestLineNo;
            obj.CompanyNo = objDetails.CompanyNo;
            obj.CompanyName = objDetails.CompanyName;
            obj.Price = objDetails.Price;
            obj.SPQ = objDetails.SPQ;
            obj.LeadTime = objDetails.LeadTime;
            obj.RoHSStatus = objDetails.RoHSStatus;
            obj.FactorySealed = objDetails.FactorySealed;
            obj.MSL = objDetails.MSL;
            obj.UpdatedBy = objDetails.UpdatedBy;
            obj.DLUP = objDetails.DLUP;
            return obj;
        }
    }
}
