using MyAngAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngAppAPI.Repository
{
    interface ISalesOrderRepository : IDisposable
    {
        IEnumerable<SalesOrder> GetAllSalesOrder();
        SalesOrder GetSalesOrderById(int salesoderId);
        int AddSalesOrder(SalesOrder salesorderEntity);
        int UpdateSalesOrder(SalesOrder salesorderEntity);
        void DeleteSalesOrder(int salesoderId);
    }
}
