using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace JobUa.Data.DAO.DataBase
{
    public class DBSaveVacancy : ISaveVacancy
    {
        public DataTable getAll() {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.SaveVacancies";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return table;
        }

        public DataTable getByEmpGuid(Guid guid) {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.SaveVacancies where EmployeeID = '" + guid + @"'";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return table;
        }
        
        public string saveNewVacancy(Guid VacancyID, Guid EmployeeID, DateTime SaveData) {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into dbo.SaveVacancies (
                                                                VacancyID,
                                                                EmployeeID,
                                                                SaveData
                                                                ) 
                                                                Values 
                                                                ('" + VacancyID + @"',
                                                                 '" + EmployeeID + @"',
                                                                 '" + SaveData + @"')";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Saved Vacancy Successfully";
            }
            catch (Exception)
            {
                return "Failed to save Vacancy";
            }
        }

        public string deleteSaveVacBySaveGuid(Guid? guid) {
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from dbo.SaveVacancies where SaveID = '" + guid + @"'";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted saved vacancy successfully";
            }
            catch (Exception)
            {
                return "Failed to delete saved vacancy";
            }
        }
    }
}
