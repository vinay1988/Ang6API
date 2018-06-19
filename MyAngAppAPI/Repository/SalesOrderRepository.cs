using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyAngAppAPI.Models;
using System.Data.Entity;

namespace MyAngAppAPI.Repository
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly SalesOrderContext _context;

        public SalesOrderRepository(SalesOrderContext context)
        {
            _context = context;
        }

        public IEnumerable<SalesOrder> GetAllSalesOrder()
        {
            return _context.SalesOrders.ToList();
        }
        public SalesOrder GetSalesOrderById(int salesoderId)
        {
            return _context.SalesOrders.Find(salesoderId);
        }

        public int AddSalesOrder(SalesOrder salesorderEntity)

        {
            int result = -1;

            if (salesorderEntity != null)
            {
                _context.SalesOrders.Add(salesorderEntity);
                _context.SaveChanges();
                result = salesorderEntity.SalesOrderId;
            }
            return result;

        }
        public int UpdateSalesOrder(SalesOrder salesorderEntity)
        {
            int result = -1;

            if (salesorderEntity != null)
            {
                _context.Entry(salesorderEntity).State = EntityState.Modified;
                _context.SaveChanges();
                result = salesorderEntity.SalesOrderId;
            }
            return result;
        }
        public void DeleteSalesOrder(int salesoderId)
        {
            SalesOrder salesOrderEntity = _context.SalesOrders.Find(salesoderId);
            _context.SalesOrders.Remove(salesOrderEntity);
            _context.SaveChanges();

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}