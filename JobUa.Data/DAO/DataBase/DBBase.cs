using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JobUa.Data.DAO.DataBase
{
    public class DBBase: IBase
    {
        public DataTable getAll(string dbName)
        {
            DataTable table = new DataTable();
            string query = @"Select * from " + dbName;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return table;
        }
        public DataTable getObjByGuid(Guid guId, string idField, string dbName)
        {
            DataTable table = new DataTable();
            string query = @"Select * from " + dbName +  " where " +  idField  + " = '" + guId + @"'";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return table;
        }

        public string deleteObjByGuid(Guid guid, string idField, string dbName)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from " + dbName + " where " + idField + " = '" + guid + @"'";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted object from " + dbName + " Successfully";
            }
            catch (Exception)
            {
                return "Failed to delete object from " + dbName;
            }
        }
    }
}
