using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace JobUa.Data.DAO.DataBase
{
    public class DBSaveEmployee : ISaveEmployee
    {
        public DataTable getAll() {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.SaveEmployees";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return table;
        }

        public DataTable getByCmpGuid(Guid cmpId) {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.SaveEmployees where CompanyID = '" + cmpId + @"'";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return table;
        }

        public string saveNewEmployee(Guid CompanyID, Guid EmployeeID, DateTime SaveData) {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into dbo.SaveEmployees (
                                                                CompanyID,
                                                                EmployeeID,
                                                                SaveData
                                                                ) 
                                                                Values 
                                                                ('" + CompanyID + @"',
                                                                 '" + EmployeeID + @"',
                                                                 '" + SaveData + @"')";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Saved Employee Successfully";
            }
            catch (Exception)
            {
                return "Failed to save Employee";
            }
        }

        public string deleteSaveEmpBySaveGuid(Guid? guid) {
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from dbo.SaveEmployees where SaveID = '" + guid + @"'";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted saved employee successfully";
            }
            catch (Exception)
            {
                return "Failed to delete saved employee";
            }
        }
    }
}
