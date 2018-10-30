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
using System.Data.Common;
using System.Web.Caching;
using System.Diagnostics;

namespace Rebound.GlobalTrader.DAL {
	public abstract class DataAccess {

		private string _connectionString = "";
		protected string ConnectionString {
			get { return _connectionString; }
			set { _connectionString = value; }
		}

		private string _mediaConnectionString = "";
		protected string MediaConnectionString {
			get { return _mediaConnectionString; }
			set { _mediaConnectionString = value; }
		}

        private string _gtConnectionString = "";
        protected string GTConnectionString
        {
            get { return _gtConnectionString; }
            set { _gtConnectionString = value; }
        }

		private bool _enableCaching = true;
		protected bool EnableCaching {
			get { return _enableCaching; }
			set { _enableCaching = value; }
		}

		private int _cacheDuration = 0;
		protected int CacheDuration {
			get { return _cacheDuration; }
			set { _cacheDuration = value; }
		}
		protected Cache Cache {
			get { return HttpContext.Current.Cache; }
		}
		protected int ExecuteNonQuery(DbCommand cmd) {
			return cmd.ExecuteNonQuery();
		}
		protected DbDataReader ExecuteReader(DbCommand cmd) {
			return ExecuteReader(cmd, CommandBehavior.SingleResult);
		}
		protected DbDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior) {
			return cmd.ExecuteReader(behavior);
		}
		protected object ExecuteScalar(DbCommand cmd) {
			return cmd.ExecuteScalar();
		}
		/// <summary>
		/// Helper routine to log SqlException details to the Application event log
		/// </summary>
		protected void LogException(SqlException sqlex) {
			try {
				EventLog el = new EventLog();
				el.Source = "Rebound Global:Trader";
				string strMessage;
				strMessage = "SQL Exception Number : " + sqlex.Number + "(" + sqlex.Message + ") has occurred";
				foreach (SqlError sqle in sqlex.Errors) {
					strMessage += "\nMessage: " + sqle.Message +
											 " Number: " + sqle.Number +
											 " Procedure: " + sqle.Procedure +
											 " Server: " + sqle.Server +
											 " Source: " + sqle.Source +
											 " State: " + sqle.State +
											 " Severity: " + sqle.Class +
											 " LineNumber: " + sqle.LineNumber;
				}
				el.WriteEntry(strMessage);
			} catch { }
		}

		protected object GetReaderValue(DbDataReader reader, string strColumn, object objValueIfNull) {
			int intOrdinal = 0;
			try { intOrdinal = reader.GetOrdinal(strColumn); } catch (IndexOutOfRangeException) { intOrdinal = 0; }
			if (intOrdinal >= 0) {
				return DBNull.Value.Equals(reader[intOrdinal]) ? objValueIfNull : reader.GetValue(intOrdinal);
			} else {
				return objValueIfNull;
			}
		}

		protected String GetReaderValue_String(DbDataReader reader, string strColumn, string strValueIfNull) {
			return GetReaderValue(reader, strColumn, strValueIfNull).ToString();
		}

		protected Byte GetReaderValue_String(DbDataReader reader, string strColumn, Byte bytValueIfNull) {
			return Convert.ToByte(GetReaderValue(reader, strColumn, bytValueIfNull));
		}

		protected Byte GetReaderValue_Byte(DbDataReader reader, string strColumn, Byte bytValueIfNull) {
			return (Byte)(GetReaderValue(reader, strColumn, bytValueIfNull));
		}

		protected Byte? GetReaderValue_NullableByte(DbDataReader reader, string strColumn, Byte? bytValueIfNull) {
			return (Byte?)(GetReaderValue(reader, strColumn, bytValueIfNull));
		}

		protected Int16 GetReaderValue_Int16(DbDataReader reader, string strColumn, Int16 intValueIfNull) {
			return Convert.ToInt16(GetReaderValue(reader, strColumn, intValueIfNull));
		}

		protected Int16? GetReaderValue_NullableInt16(DbDataReader reader, string strColumn, Int16? intValueIfNull) {
			return (Int16?)(GetReaderValue(reader, strColumn, intValueIfNull));
		}

		protected Int32 GetReaderValue_Int32(DbDataReader reader, string strColumn, Int32 intValueIfNull) {
			return Convert.ToInt32(GetReaderValue(reader, strColumn, intValueIfNull));
		}

		protected Int32? GetReaderValue_NullableInt32(DbDataReader reader, string strColumn, Int32? intValueIfNull) {
			return (Int32?)(GetReaderValue(reader, strColumn, intValueIfNull));
		}

		protected Int64 GetReaderValue_Int64(DbDataReader reader, string strColumn, Int64 intValueIfNull) {
			return Convert.ToInt64(GetReaderValue(reader, strColumn, intValueIfNull));
		}

		protected Int64? GetReaderValue_NullableInt64(DbDataReader reader, string strColumn, Int64? intValueIfNull) {
			return (Int64?)(GetReaderValue(reader, strColumn, intValueIfNull));
		}

		protected DateTime GetReaderValue_DateTime(DbDataReader reader, string strColumn, DateTime dtmValueIfNull) {
			return Convert.ToDateTime(GetReaderValue(reader, strColumn, dtmValueIfNull));
		}

		protected DateTime? GetReaderValue_NullableDateTime(DbDataReader reader, string strColumn, DateTime? dtmValueIfNull) {
			return (DateTime?)(GetReaderValue(reader, strColumn, dtmValueIfNull));
		}

		protected Boolean GetReaderValue_Boolean(DbDataReader reader, string strColumn, Boolean blnValueIfNull) {
			return Convert.ToBoolean(GetReaderValue(reader, strColumn, blnValueIfNull));
		}

		protected Boolean? GetReaderValue_NullableBoolean(DbDataReader reader, string strColumn, Boolean? blnValueIfNull) {
			return (Boolean?)(GetReaderValue(reader, strColumn, blnValueIfNull));
		}

		protected Double GetReaderValue_Double(DbDataReader reader, string strColumn, Double dblValueIfNull) {
			return Convert.ToDouble(GetReaderValue(reader, strColumn, dblValueIfNull));
		}

		protected Double? GetReaderValue_NullableDouble(DbDataReader reader, string strColumn, Double? dblValueIfNull) {
			return (Double?)(GetReaderValue(reader, strColumn, dblValueIfNull));
		}

		protected Byte[] GetReaderValue_ByteArray(DbDataReader reader, string strColumn, object objValueIfNull) {
			return (Byte[])(GetReaderValue(reader, strColumn, objValueIfNull));
		}

        protected Decimal? GetReaderValue_NullableDecimal(DbDataReader reader, string strColumn, Decimal? dblValueIfNull)
        {
            return (Decimal?)(GetReaderValue(reader, strColumn, dblValueIfNull));
        }
	}
}
