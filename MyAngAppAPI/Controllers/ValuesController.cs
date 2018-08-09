using MyAngAppAPI.Models;
using MyAngAppAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//https://www.c-sharpcorner.com/UploadFile/8a67c0/repository-pattern-with-Asp-Net-mvc-with-entity-framework/
namespace MyAngAppAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private ISalesOrderRepository _salesorderRepository;
        
        public ValuesController()
        {
            _salesorderRepository = new SalesOrderRepository(new Models.SalesOrderContext());
        }
        //public ValuesController(ISalesOrderRepository salesOrderRepository)
        //{
        //    _salesorderRepository = salesOrderRepository;
        //}
        // GET api/values

            [Authorize]
        public IEnumerable<SalesOrder> Get()
        {
            var model = _salesorderRepository.GetAllSalesOrder();
            return model.AsEnumerable();
                //string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Authorize]
        public SalesOrder Get(int id)
        {
            var model = _salesorderRepository.GetSalesOrderById(id);
             CurrencyContext db = new CurrencyContext();

            Currency cu = db.Currencies.Find(model.CurrencyNo);
            if (cu != null)
                model.CurrencyDesc = db.Currencies.Find(model.CurrencyNo).CurrencyDescription;
            return model;
        }

        // POST api/values
        //public void Post([FromBody]string value)
        //{
        //}
        [Authorize]
        public SalesOrder Post(SalesOrder addso)
        {
            addso.DateOrdered = DateTime.Now;
            addso.DateAuthorised = DateTime.Now;
            addso.DLUP = DateTime.Now;
            addso.CreateDate = DateTime.Now;
            addso.ClientNo = 101;

            addso.CompanyNo = 2000;
            addso.ContactNo = 8541;
            //addso.CurrencyNo = 1;
            addso.Salesman = 2;
            addso.TermsNo = 9;
            addso.SalesOrderId =  _salesorderRepository.AddSalesOrder(addso);
            return addso;
        }
        // PUT api/values/5
        [Authorize]
        public SalesOrder Put(int id, SalesOrder addso)
        {
            addso.DateOrdered = DateTime.Now;
            addso.DateAuthorised = DateTime.Now;
            addso.DLUP = DateTime.Now;
            addso.CreateDate = DateTime.Now;
            addso.ClientNo = 101;
            addso.CompanyNo = 2000;
            addso.ContactNo = 8541;
            //addso.CurrencyNo = 1;
            addso.Salesman = 2;
            addso.TermsNo = 9;
            _salesorderRepository.UpdateSalesOrder(addso);
            return addso;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
