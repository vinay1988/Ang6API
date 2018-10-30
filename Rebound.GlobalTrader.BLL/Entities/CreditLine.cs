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

namespace Rebound.GlobalTrader.BLL
{
    public partial class CreditLine : BizObject
    {

        #region Properties

        protected static DAL.CreditLineElement Settings
        {
            get { return Globals.Settings.CreditLines; }
        }

        /// <summary>
        /// CreditLineId
        /// </summary>
        public System.Int32 CreditLineId { get; set; }
        /// <summary>
        /// FullPart
        /// </summary>
        public System.String FullPart { get; set; }
        /// <summary>
        /// Part
        /// </summary>
        public System.String Part { get; set; }
        /// <summary>
        /// ManufacturerNo
        /// </summary>
        public System.Int32? ManufacturerNo { get; set; }
        /// <summary>
        /// DateCode
        /// </summary>
        public System.String DateCode { get; set; }
        /// <summary>
        /// PackageNo
        /// </summary>
        public System.Int32? PackageNo { get; set; }
        /// <summary>
        /// ProductNo
        /// </summary>
        public System.Int32? ProductNo { get; set; }
        /// <summary>
        /// CreditNo
        /// </summary>
        public System.Int32 CreditNo { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        public System.Int32 Quantity { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public System.Double Price { get; set; }
        /// <summary>
        /// Taxable
        /// </summary>
        public System.Boolean Taxable { get; set; }
        /// <summary>
        /// CustomerPart
        /// </summary>
        public System.String CustomerPart { get; set; }
        /// <summary>
        /// LandedCost
        /// </summary>
        public System.Double? LandedCost { get; set; }
        /// <summary>
        /// InvoiceLineNo
        /// </summary>
        public System.Int32? InvoiceLineNo { get; set; }
        /// <summary>
        /// CustomerRMALineNo
        /// </summary>
        public System.Int32? CustomerRMALineNo { get; set; }
        /// <summary>
        /// ROHS
        /// </summary>
        public System.Byte? ROHS { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// StockNo
        /// </summary>
        public System.Int32? StockNo { get; set; }
        /// <summary>
        /// ServiceNo
        /// </summary>
        public System.Int32? ServiceNo { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public System.String Notes { get; set; }
        /// <summary>
        /// FullCustomerPart
        /// </summary>
        public System.String FullCustomerPart { get; set; }
        /// <summary>
        /// CreditId
        /// </summary>
        public System.Int32 CreditId { get; set; }
        /// <summary>
        /// CreditNumber
        /// </summary>
        public System.Int32 CreditNumber { get; set; }
        /// <summary>
        /// CreditDate
        /// </summary>
        public System.DateTime CreditDate { get; set; }
        /// <summary>
        /// CompanyName
        /// </summary>
        public System.String CompanyName { get; set; }
        /// <summary>
        /// CompanyNo
        /// </summary>
        public System.Int32 CompanyNo { get; set; }
        /// <summary>
        /// CustomerRMANumber
        /// </summary>
        public System.Int32 CustomerRMANumber { get; set; }
        /// <summary>
        /// CustomerRMANo
        /// </summary>
        public System.Int32? CustomerRMANo { get; set; }
        /// <summary>
        /// CustomerPO
        /// </summary>
        public System.String CustomerPO { get; set; }
        /// <summary>
        /// InvoiceNumber
        /// </summary>
        public System.Int32 InvoiceNumber { get; set; }
        /// <summary>
        /// InvoiceNo
        /// </summary>
        public System.Int32? InvoiceNo { get; set; }
        /// <summary>
        /// ContactName
        /// </summary>
        public System.String ContactName { get; set; }
        /// <summary>
        /// ContactNo
        /// </summary>
        public System.Int32 ContactNo { get; set; }
        /// <summary>
        /// ManufacturerCode
        /// </summary>
        public System.String ManufacturerCode { get; set; }
        /// <summary>
        /// RowNum
        /// </summary>
        public System.Int64? RowNum { get; set; }
        /// <summary>
        /// RowCnt
        /// </summary>
        public System.Int32? RowCnt { get; set; }
        /// <summary>
        /// LineNotes
        /// </summary>
        public System.String LineNotes { get; set; }
        /// <summary>
        /// ManufacturerName
        /// </summary>
        public System.String ManufacturerName { get; set; }
        /// <summary>
        /// PackageName
        /// </summary>
        public System.String PackageName { get; set; }
        /// <summary>
        /// PackageDescription
        /// </summary>
        public System.String PackageDescription { get; set; }
        /// <summary>
        /// ProductName
        /// </summary>
        public System.String ProductName { get; set; }
        /// <summary>
        /// ProductDescription
        /// </summary>
        public System.String ProductDescription { get; set; }
        /// <summary>
        /// CurrencyNo
        /// </summary>
        public System.Int32 CurrencyNo { get; set; }
        /// <summary>
        /// CurrencyCode
        /// </summary>
        public System.String CurrencyCode { get; set; }
        /// <summary>
        /// RaiserName
        /// </summary>
        public System.String RaiserName { get; set; }
        /// <summary>
        /// SalesmanName
        /// </summary>
        public System.String SalesmanName { get; set; }
        /// <summary>
        /// TeamNo
        /// </summary>
        public System.Int32? TeamNo { get; set; }
        /// <summary>
        /// DivisionName
        /// </summary>
        public System.String DivisionName { get; set; }
        /// <summary>
        /// ReferenceDate
        /// </summary>
        public System.DateTime ReferenceDate { get; set; }
        public System.Int32 Ipo { get; set; }
        public System.String CreditLineID { get; set; }

        public System.Int32 ParentCreditLineId { get; set; }

        public System.Int32? ClientInvoiceLineId { get; set; }
        public System.Int32 ParentCreditLineNo { get; set; }
        public System.Int32? ClientInvoiceNumber { get; set; }
        public System.Int32? ClientInvoiceNo { get; set; }
        public System.String DutyCode { get; set; }       
        #endregion

        #region Methods

        /// <summary>
        /// CountForClient
        /// Calls [usp_count_CreditLine_for_Client]
        /// </summary>
        public static Int32 CountForClient(System.Int32? clientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CreditLine.CountForClient(clientId);
        }		/// <summary>
        /// DataListNugget
        /// Calls [usp_datalistnugget_CreditLine]
        /// </summary>
        public static List<CreditLine> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String creditNotesSearch, System.String customerPoSearch, System.Int32? creditNoLo, System.Int32? creditNoHi, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.DateTime? creditDateFrom, System.DateTime? creditDateTo, System.Boolean? PohubOnly, System.Int32? ClientInvoiceNoLo, System.Int32? ClientInvoiceNoHi,System.Boolean? blnHubCredit)
        {
            List<CreditLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CreditLine.DataListNugget(clientId, teamId, divisionId, loginId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesmanSearch, creditNotesSearch, customerPoSearch, creditNoLo, creditNoHi, invoiceNoLo, invoiceNoHi, customerRmaNoLo, customerRmaNoHi, creditDateFrom, creditDateTo, PohubOnly, ClientInvoiceNoLo, ClientInvoiceNoHi, blnHubCredit);
            if (lstDetails == null)
            {
                return new List<CreditLine>();
            }
            else
            {
                List<CreditLine> lst = new List<CreditLine>();
                foreach (CreditLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CreditLine obj = new Rebound.GlobalTrader.BLL.CreditLine();
                    obj.CreditId = objDetails.CreditId;
                    obj.CreditNumber = objDetails.CreditNumber;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.CreditDate = objDetails.CreditDate;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                    obj.CustomerRMANo = objDetails.CustomerRMANo;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.InvoiceNumber = objDetails.InvoiceNumber;
                    obj.InvoiceNo = objDetails.InvoiceNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.ClientInvoiceNumber = objDetails.ClientInvoiceNumber;
                    obj.ClientInvoiceNo = objDetails.ClientInvoiceNo;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Delete
        /// Calls [usp_delete_CreditLine]
        /// </summary>
        public static bool Delete(System.Int32? creditLineId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CreditLine.Delete(creditLineId);
        }
        /// <summary>
        /// Insert
        /// Calls [usp_insert_CreditLine]
        /// </summary>
        public static Int32 Insert(System.Int32? creditNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? productNo, System.Int32? quantity, System.Double? price, System.Boolean? taxable, System.String customerPart, System.Double? landedCost, System.Int32? invoiceLineNo, System.Int32? customerRmaLineNo, System.Int32? stockNo, System.Int32? serviceNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Int32? ClientInvoiceLineId, out int creditId, out int creditNumber)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CreditLine.Insert(creditNo, part, manufacturerNo, dateCode, packageNo, productNo, quantity, price, taxable, customerPart, landedCost, invoiceLineNo, customerRmaLineNo, stockNo, serviceNo, rohs, notes, updatedBy, ClientInvoiceLineId, out creditId, out creditNumber);
            return objReturn;
        }
        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_CreditLine]
        /// </summary>
        public Int32 Insert()
        {
            int creditId = 0;
            int creditNumber = 0;
            int creditLineId = Rebound.GlobalTrader.DAL.SiteProvider.CreditLine.Insert(CreditNo, Part, ManufacturerNo, DateCode, PackageNo, ProductNo, Quantity, Price, Taxable, CustomerPart, LandedCost, InvoiceLineNo, CustomerRMALineNo, StockNo, ServiceNo, ROHS, Notes, UpdatedBy, ClientInvoiceLineId, out creditId, out creditNumber);
            this.CreditId = creditId;
            this.CreditNumber = creditNumber;
            return creditLineId;
        }
        /// <summary>
        /// Insert
        /// Calls [usp_insert_CreditLine]
        /// </summary>
        public static Int32 CreditNoteToPOHUB(System.String CreditLineID, System.Int32? UpdatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CreditLine.CreditNoteToPOHUB(CreditLineID, UpdatedBy);
            return objReturn;
        }
        public Int32 CreditNoteToPOHUB()
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CreditLine.CreditNoteToPOHUB(CreditLineID, UpdatedBy);
            return objReturn;
        }
        /// <summary>
        /// Get
        /// Calls [usp_select_CreditLine]
        /// </summary>
        public static CreditLine Get(System.Int32? creditLineId)
        {
            Rebound.GlobalTrader.DAL.CreditLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CreditLine.Get(creditLineId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                CreditLine obj = new CreditLine();
                obj.CreditLineId = objDetails.CreditLineId;
                obj.FullPart = objDetails.FullPart;
                obj.Part = objDetails.Part;
                obj.ManufacturerNo = objDetails.ManufacturerNo;
                obj.DateCode = objDetails.DateCode;
                obj.PackageNo = objDetails.PackageNo;
                obj.ProductNo = objDetails.ProductNo;
                obj.CreditNo = objDetails.CreditNo;
                obj.Quantity = objDetails.Quantity;
                obj.Price = objDetails.Price;
                obj.Taxable = objDetails.Taxable;
                obj.CustomerPart = objDetails.CustomerPart;
                obj.LandedCost = objDetails.LandedCost;
                obj.InvoiceLineNo = objDetails.InvoiceLineNo;
                obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
                obj.ROHS = objDetails.ROHS;
                obj.StockNo = objDetails.StockNo;
                obj.ServiceNo = objDetails.ServiceNo;
                obj.LineNotes = objDetails.LineNotes;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.ManufacturerName = objDetails.ManufacturerName;
                obj.ManufacturerCode = objDetails.ManufacturerCode;
                obj.PackageName = objDetails.PackageName;
                obj.PackageDescription = objDetails.PackageDescription;
                obj.ProductName = objDetails.ProductName;
                obj.ProductDescription = objDetails.ProductDescription;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CompanyName = objDetails.CompanyName;
                obj.ContactName = objDetails.ContactName;
                obj.RaiserName = objDetails.RaiserName;
                obj.SalesmanName = objDetails.SalesmanName;
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionName = objDetails.DivisionName;
                obj.InvoiceNumber = objDetails.InvoiceNumber;
                obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                obj.CreditDate = objDetails.CreditDate;
                obj.ReferenceDate = objDetails.ReferenceDate;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetListForCredit
        /// Calls [usp_selectAll_CreditLine_for_Credit]
        /// </summary>
        public static List<CreditLine> GetListForCredit(System.Int32? creditId)
        {
            List<CreditLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CreditLine.GetListForCredit(creditId);
            if (lstDetails == null)
            {
                return new List<CreditLine>();
            }
            else
            {
                List<CreditLine> lst = new List<CreditLine>();
                foreach (CreditLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CreditLine obj = new Rebound.GlobalTrader.BLL.CreditLine();
                    obj.CreditLineId = objDetails.CreditLineId;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.CreditNo = objDetails.CreditNo;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.Taxable = objDetails.Taxable;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.InvoiceLineNo = objDetails.InvoiceLineNo;
                    obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
                    obj.ROHS = objDetails.ROHS;
                    obj.StockNo = objDetails.StockNo;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.LineNotes = objDetails.LineNotes;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ContactName = objDetails.ContactName;
                    obj.RaiserName = objDetails.RaiserName;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.DivisionName = objDetails.DivisionName;
                    obj.InvoiceNumber = objDetails.InvoiceNumber;
                    obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                    obj.CreditDate = objDetails.CreditDate;
                    obj.ReferenceDate = objDetails.ReferenceDate;
                    obj.Ipo = objDetails.Ipo;
                    obj.ParentCreditLineId = objDetails.ParentCreditLineId;
                    obj.ClientInvoiceLineId = objDetails.ClientInvoiceLineId;
                    obj.ParentCreditLineNo = objDetails.ParentCreditLineNo;
                    obj.DutyCode = objDetails.DutyCode;                   
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Update
        /// Calls [usp_update_CreditLine]
        /// </summary>
        public static bool Update(System.Int32? creditLineId, System.Int32? quantity, System.Double? price, System.String part, System.String customerPart, System.Double? landedCost, System.String notes, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CreditLine.Update(creditLineId, quantity, price, part, customerPart, landedCost, notes, updatedBy);
        }
        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_CreditLine]
        /// </summary>
        public bool Update()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CreditLine.Update(CreditLineId, Quantity, Price, Part, CustomerPart, LandedCost, Notes, UpdatedBy);
        }

        private static CreditLine PopulateFromDBDetailsObject(CreditLineDetails obj)
        {
            CreditLine objNew = new CreditLine();
            objNew.CreditLineId = obj.CreditLineId;
            objNew.FullPart = obj.FullPart;
            objNew.Part = obj.Part;
            objNew.ManufacturerNo = obj.ManufacturerNo;
            objNew.DateCode = obj.DateCode;
            objNew.PackageNo = obj.PackageNo;
            objNew.ProductNo = obj.ProductNo;
            objNew.CreditNo = obj.CreditNo;
            objNew.Quantity = obj.Quantity;
            objNew.Price = obj.Price;
            objNew.Taxable = obj.Taxable;
            objNew.CustomerPart = obj.CustomerPart;
            objNew.LandedCost = obj.LandedCost;
            objNew.InvoiceLineNo = obj.InvoiceLineNo;
            objNew.CustomerRMALineNo = obj.CustomerRMALineNo;
            objNew.ROHS = obj.ROHS;
            objNew.UpdatedBy = obj.UpdatedBy;
            objNew.DLUP = obj.DLUP;
            objNew.StockNo = obj.StockNo;
            objNew.ServiceNo = obj.ServiceNo;
            objNew.Notes = obj.Notes;
            objNew.FullCustomerPart = obj.FullCustomerPart;
            objNew.CreditId = obj.CreditId;
            objNew.CreditNumber = obj.CreditNumber;
            objNew.CreditDate = obj.CreditDate;
            objNew.CompanyName = obj.CompanyName;
            objNew.CompanyNo = obj.CompanyNo;
            objNew.CustomerRMANumber = obj.CustomerRMANumber;
            objNew.CustomerRMANo = obj.CustomerRMANo;
            objNew.CustomerPO = obj.CustomerPO;
            objNew.InvoiceNumber = obj.InvoiceNumber;
            objNew.InvoiceNo = obj.InvoiceNo;
            objNew.ContactName = obj.ContactName;
            objNew.ContactNo = obj.ContactNo;
            objNew.ManufacturerCode = obj.ManufacturerCode;
            objNew.RowNum = obj.RowNum;
            objNew.RowCnt = obj.RowCnt;
            objNew.LineNotes = obj.LineNotes;
            objNew.ManufacturerName = obj.ManufacturerName;
            objNew.PackageName = obj.PackageName;
            objNew.PackageDescription = obj.PackageDescription;
            objNew.ProductName = obj.ProductName;
            objNew.ProductDescription = obj.ProductDescription;
            objNew.CurrencyNo = obj.CurrencyNo;
            objNew.CurrencyCode = obj.CurrencyCode;
            objNew.RaiserName = obj.RaiserName;
            objNew.SalesmanName = obj.SalesmanName;
            objNew.TeamNo = obj.TeamNo;
            objNew.DivisionName = obj.DivisionName;
            objNew.ReferenceDate = obj.ReferenceDate;
            return objNew;
        }

        #endregion

    }
}