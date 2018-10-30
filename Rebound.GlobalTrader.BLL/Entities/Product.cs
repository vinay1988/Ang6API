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
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL {
		public partial class Product : BizObject {
		
		#region Properties

		protected static DAL.ProductElement Settings {
			get { return Globals.Settings.Products; }
		}

		/// <summary>
		/// ProductId
		/// </summary>
		public System.Int32 ProductId { get; set; }		
		/// <summary>
		/// ProductName
		/// </summary>
		public System.String ProductName { get; set; }		
		/// <summary>
		/// ProductDescription
		/// </summary>
		public System.String ProductDescription { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// Inactive
		/// </summary>
		public System.Boolean Inactive { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// DutyCode
		/// </summary>
		public System.String DutyCode { get; set; }		
		/// <summary>
		/// LandedCost
		/// </summary>
		public System.Double? LandedCost { get; set; }		
		/// <summary>
		/// CurrentDutyRate
		/// </summary>
		public System.Double? CurrentDutyRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.String ClientName { get; set; }

        /// <summary>
        /// ProductId
        /// </summary>
        public System.Int32 GlobalProductNameId { get; set; }
        /// <summary>
        /// ProductName
        /// </summary>
        public System.String GlobalProductName { get; set; }
        /// <summary>
        /// Hazarders
        /// </summary>
        public System.Boolean? Hazarders { get; set; }
		#endregion
		
		#region Methods

        public static List<Product> AutoSearch(System.String nameSearch, System.Int32? clientId)
        {
            List<ProductDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Product.AutoSearch(nameSearch, clientId);
            if (lstDetails == null)
            {
                return new List<Product>();
            }
            else
            {
                List<Product> lst = new List<Product>();
                foreach (ProductDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Product obj = new Rebound.GlobalTrader.BLL.Product();
                    obj.ProductId = objDetails.ProductId;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.Hazarders = objDetails.Hazarders;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

		/// <summary>
		/// Delete
		/// Calls [usp_delete_Product]
		/// </summary>
		public static bool Delete(System.Int32? productId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Product.Delete(productId);
		}
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Product_for_Client]
		/// </summary>
		public static List<Product> DropDownForClient(System.Int32? clientId) {
			List<ProductDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Product.DropDownForClient(clientId);
			if (lstDetails == null) {
				return new List<Product>();
			} else {
				List<Product> lst = new List<Product>();
				foreach (ProductDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Product obj = new Rebound.GlobalTrader.BLL.Product();
					obj.ProductId = objDetails.ProductId;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Product]
		/// </summary>
		public static Int32 Insert(System.String productName, System.String productDescription, System.Int32? clientNo, System.String dutyCode, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Product.Insert(productName, productDescription, clientNo, dutyCode, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Product]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Product.Insert(ProductName, ProductDescription, ClientNo, DutyCode, UpdatedBy);
		}
        /// <summary>
        /// Insert
        /// Calls [usp_insert_GlobalProduct]
        /// </summary>
        ///  // Adding parameter GlobalProductNameNo to Add record with respective ProductNameId selected (Suhail )
        public static Int32 GlobalInsert(System.String productName, System.String productDescription, System.Int32? clientNo, System.String dutyCode, System.Int32? updatedBy, System.Int32? GlobalProductNameNo, System.Double? dutyRateValue, System.Boolean? hazarders)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Product.GlobalInsert(productName, productDescription, clientNo, dutyCode, updatedBy, GlobalProductNameNo, dutyRateValue, hazarders);
            return objReturn;
        }
        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_GlobalProduct]
        /// </summary>
        public Int32 GlobalInsert()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Product.GlobalInsert(ProductName, ProductDescription, ClientNo, DutyCode, UpdatedBy, GlobalProductNameId, CurrentDutyRate, Hazarders);
        }
		/// <summary>
		/// Get
		/// Calls [usp_select_Product]
		/// </summary>
		public static Product Get(System.Int32? productId) {
			Rebound.GlobalTrader.DAL.ProductDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Product.Get(productId);
			if (objDetails == null) {
				return null;
			} else {
				Product obj = new Product();
				obj.ProductId = objDetails.ProductId;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.ClientNo = objDetails.ClientNo;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.DutyCode = objDetails.DutyCode;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetLandedCostCalculation
		/// Calls [usp_select_Product_LandedCostCalculation]
		/// </summary>
		public static Product GetLandedCostCalculation(System.Int32? quantity, System.DateTime? datePoint, System.Int32? currencyNo, System.Double? cost, System.Double? shippingCost, System.Boolean? applyDuty, System.Int32? productNo) {
			Rebound.GlobalTrader.DAL.ProductDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Product.GetLandedCostCalculation(quantity, datePoint, currencyNo, cost, shippingCost, applyDuty, productNo);
			if (objDetails == null) {
				return null;
			} else {
				Product obj = new Product();
				obj.LandedCost = objDetails.LandedCost;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Product_for_Client]
		/// </summary>
		public static List<Product> GetListForClient(System.Int32? clientId) {
			List<ProductDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Product.GetListForClient(clientId);
			if (lstDetails == null) {
				return new List<Product>();
			} else {
				List<Product> lst = new List<Product>();
				foreach (ProductDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Product obj = new Rebound.GlobalTrader.BLL.Product();
					obj.ProductId = objDetails.ProductId;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ClientNo = objDetails.ClientNo;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.DutyCode = objDetails.DutyCode;
					obj.CurrentDutyRate = objDetails.CurrentDutyRate;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        /// <summary>
        /// 
        /// Calls [usp_selectAll_Product_for_Global]
        /// </summary>
        public static List<Product> GetProductList(System.Int32? GlobalProductId)
        {
            List<ProductDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Product.GetProductList(GlobalProductId);
            if (lstDetails == null)
            {
                return new List<Product>();
            }
            else
            {
                List<Product> lst = new List<Product>();
                foreach (ProductDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Product obj = new Rebound.GlobalTrader.BLL.Product();
                    obj.ProductId = objDetails.ProductId;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.Inactive = objDetails.Inactive;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.DutyCode = objDetails.DutyCode;
                    obj.CurrentDutyRate = objDetails.CurrentDutyRate;
                    obj.ClientName = objDetails.ClientName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// GetList
        /// Calls [usp_selectAll_GlobalProduct]
        /// </summary>
        /// // Adding parameterProductNameId to get record on basis of selected ProductNameId from Global product name (Suhail )
        public static List<Product> GetListGlobalProduct(System.Int32? GlobalProductNameId)
        {
            List<ProductDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Product.GetListGlobalProduct(GlobalProductNameId);
            if (lstDetails == null)
            {
                return new List<Product>();
            }
            else
            {
                List<Product> lst = new List<Product>();
                foreach (ProductDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Product obj = new Rebound.GlobalTrader.BLL.Product();
                    obj.ProductId = objDetails.ProductId;
                  //  obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.Inactive = objDetails.Inactive;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.DutyCode = objDetails.DutyCode;
                    obj.CurrentDutyRate = objDetails.CurrentDutyRate;
                    obj.Hazarders = objDetails.Hazarders;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

     
            /// <summary>
		/// Update
		/// Calls [usp_update_Product]
		/// </summary>
		public static bool Update(System.Int32? productId, System.String productName, System.String productDescription, System.Int32? clientNo, System.String dutyCode, System.Boolean? inactive, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Product.Update(productId, productName, productDescription, clientNo, dutyCode, inactive, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Product]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Product.Update(ProductId, ProductName, ProductDescription, ClientNo, DutyCode, Inactive, UpdatedBy);
		}

        /// Update
        /// Calls [usp_update_GlobalProduct]
        /// </summary>
        public static bool GlobalUpdate(System.Int32? productId, System.String productName, System.String productDescription, System.Int32? clientNo, System.String dutyCode, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? hazarders)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Product.GlobalUpdate(productId, productName, productDescription, clientNo, dutyCode, inactive, updatedBy, hazarders);
        }

        /// <summary>
        /// Update Globally Duty Rate
        /// Calls [usp_update_Product_Globally]
        /// </summary>
        public static bool UpdateProductGlobally(System.Int32? productId, System.Boolean? inactive, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Product.UpdateProductGlobally(productId, inactive, updatedBy);
        } 

        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_GlobalProduct]
        /// </summary>
        public bool GlobalUpdate()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Product.GlobalUpdate(ProductId, ProductName, ProductDescription, ClientNo, DutyCode, Inactive, UpdatedBy,Hazarders);
        }
        private static Product PopulateFromDBDetailsObject(ProductDetails obj) {
            Product objNew = new Product();
			objNew.ProductId = obj.ProductId;
			objNew.ProductName = obj.ProductName;
			objNew.ProductDescription = obj.ProductDescription;
			objNew.ClientNo = obj.ClientNo;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.DutyCode = obj.DutyCode;
			objNew.LandedCost = obj.LandedCost;
			objNew.CurrentDutyRate = obj.CurrentDutyRate;
            return objNew;
        }

        /// <summary>
        /// GetList
        /// Calls [usp_selectAll_GlobalProductName]
        /// </summary>
        public static List<Product> GetListGlobalProductName()
        {
            List<ProductDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Product.GetListGlobalProductName();
            if (lstDetails == null)
            {
                return new List<Product>();
            }
            else
            {
                List<Product> lst = new List<Product>();
                foreach (ProductDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Product obj = new Rebound.GlobalTrader.BLL.Product();
                    obj.GlobalProductNameId = objDetails.GlobalProductNameId;
                    obj.GlobalProductName = objDetails.GlobalProductName;
                    obj.Inactive = objDetails.Inactive;  
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// Insert
        /// Calls [usp_insert_GlobalProductName]
        /// </summary>
        public static bool GlobalNameInsert(System.String productName, System.Int32? updatedBy)
        {
            bool objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Product.GlobalNameInsert(productName, updatedBy);
            return objReturn;
        }

        /// Update
        /// Calls [usp_update_GlobalProductName]
        /// </summary>
        public static bool GlobalUpdateName(System.Int32? productId, System.String productName, System.Boolean? inactive, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Product.GlobalUpdateName(productId, productName, inactive, updatedBy);
        }
		
		#endregion
		
	}
}