using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace JobUa.Data.DAO.DataBase
{
    public class DBSaveEmployee : DBBase, ISaveEmployee
    {
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
                return "Save Employee to saved Employees Successfully";
            }
            catch (Exception)
            {
                return "Failed to save Employee to saved Employees";
            }
        }
    }
}
