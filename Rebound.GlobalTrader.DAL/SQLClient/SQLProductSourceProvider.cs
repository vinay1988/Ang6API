using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.Caching;
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL.SqlClient {
    public class SqlProductSourceProvider : ProductSourceProvider
    {
        /// <summary>
        /// DropDown 
        /// Calls [usp_dropdown_ProductSource]
        /// </summary>
        public override List<ProductSourceDetails> DropDown()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_ProductSource", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ProductSourceDetails> lst = new List<ProductSourceDetails>();
                while (reader.Read())
                {
                    ProductSourceDetails obj = new ProductSourceDetails();
                    obj.ProductSourceId = GetReaderValue_Int32(reader, "ProductSourceId", 0);
                    obj.Name = GetReaderValue_String(reader, "Name", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Porduct Source", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

    }
}