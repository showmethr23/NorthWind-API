using NorthWind_API.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace NorthWind_API.Datalayer
{
    public class DataAccess
    {
        static string connStr = ConnectionStringHelper.CONNSTR;
        public static DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
