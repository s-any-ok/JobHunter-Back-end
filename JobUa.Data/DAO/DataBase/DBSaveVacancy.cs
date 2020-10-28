using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace JobUa.Data.DAO.DataBase
{
    public class DBSaveVacancy : DBBase, ISaveVacancy
    {   
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
                return "Saved Vacancy to saved Vacancies Successfully";
            }
            catch (Exception)
            {
                return "Failed to save Vacancy to saved Vacancies";
            }
        }
    }
}
