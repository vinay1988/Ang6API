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
    public class SqlMSLLevelProvider : MSLLevelProvider
    {
        /// <summary>
        /// DropDown 
        /// Calls [usp_dropdown_MSLLevel]
        /// </summary>
        public override List<MSLLevelDetails> DropDown()
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_MSLLevel", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
                List<MSLLevelDetails> lst = new List<MSLLevelDetails>();
				while (reader.Read()) {
                    MSLLevelDetails obj = new MSLLevelDetails();
                    obj.MSLLevelId = GetReaderValue_Int32(reader, "MSLLevelId", 0);
                    obj.MSLLevels = GetReaderValue_String(reader, "MSLLevel", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MSL Levels", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}		
		
	}
}