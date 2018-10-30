using Rebound.GlobalTrader.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAngAppAPI.Controllers
{
    public class SalesOrderController : Controller
    {
        // GET: SalesOrder
        public ActionResult Index()
        {
            return View();
        }
        public SalesOrder GetData(int ID)
        {
            SalesOrder so = SalesOrder.Get(ID);
            
            if (so != null)
            {
                return so;
            }
            else
            {
                return new SalesOrder();
            }
        }
        public SalesOrder Add(SalesOrder addso)
        {
            DateTime dtmDateOrdered = (DateTime)addso.DateOrdered;

            //auto authorise?
            DateTime? dtmDateAuthorised = null;
            int? intAuthorisedBy = null;
           

            addso.SalesOrderId = SalesOrder.Insert(
                addso.ClientNo
                , addso.CompanyId
                , addso.ContactNo
                , dtmDateOrdered
                , addso.CurrencyNo
                , addso.SalesMan
                , addso.TermsNo
                , addso.ShipToAddressNo
                , addso.ShipViaNo
                , addso.Account
                , addso.Freight
                , addso.CustomerPO
                , addso.DivisionNo
                , addso.TaxNo
                , addso.ShippingCost
                , addso.Notes
                , addso.Notes
                , addso.Paid
                , null
                , false
                , addso.Salesman2
                , addso.Salesman2Percent
                , addso.IncotermNo
                , intAuthorisedBy
                , dtmDateAuthorised
                , 0
                , addso.AS9120
                );

            return addso;
        }
        public SalesOrder SaveEdit(SalesOrder addso)
        {
            try
            {
                SalesOrder so = SalesOrder.Get(addso.SalesOrderId);
                if (so != null)
                {
                    so.ContactNo = addso.ContactNo;
                    so.DivisionNo = addso.DivisionNo;
                    so.Salesman = addso.Salesman;
                    so.ShipToAddressNo = addso.ShipToAddressNo;
                    so.TermsNo = addso.TermsNo;
                    so.ShipViaNo = addso.ShipViaNo;
                    so.Account = addso.Account;
                    so.CustomerPO = addso.CustomerPO;
                    so.Instructions = addso.Instructions;
                    so.Notes = addso.Notes;
                    so.UpdatedBy = addso.UpdatedBy;
                    so.ShippingCost = addso.ShippingCost;
                    so.Freight = addso.Freight;
                    so.Paid = addso.Paid;
                    so.Salesman2 = addso.Salesman2;
                    so.Salesman2Percent = addso.Salesman2Percent;
                    so.IncotermNo = addso.IncotermNo;
                    //
                    so.TaxNo = addso.TaxNo;
                    //
                    //[002] code start
                    so.AS9120 = addso.AS9120;
                    //[002] code end
                    //[002] code start
                    so.CurrencyNo = addso.CurrencyNo;
                    //[002] code end
                    so.Update();
                    return so;
                }
                else
                {
                    return new SalesOrder();
                }
            }
            catch (Exception e)
            {
                WriteError(e);
                return new SalesOrder();
            }
        }

        private void WriteError(Exception e)
        {
            throw new NotImplementedException();
        }
    }
}