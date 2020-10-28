using JobUa.Data.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JobUa.Data.DAO.DataBase
{
    public class DBVacancy : DBBase, IVacancy
    {
        public Vacancy getVacObjByGuid(Guid vacId)
        {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.Vacancies where VacancyID = '" + vacId + @"'";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            Vacancy vac = new Vacancy();

            //vac.VacancyID = (Guid)table.Rows[0]["VacancyID"];
            //vac.CompanyID = (Guid)table.Rows[0]["CompanyID"];
            vac.Objective = (string)table.Rows[0]["Objective"];
            vac.Information = (string)table.Rows[0]["Information"];
            vac.Experience = (string)table.Rows[0]["Experience"];
            vac.Employment = (string)table.Rows[0]["Employment"];
            vac.Salary = (decimal)table.Rows[0]["Salary"];
            vac.Adress = (string)table.Rows[0]["Adress"];
            vac.ContactPhoneNumber = (string)table.Rows[0]["ContactPhoneNumber"];
            vac.RegistrationData = (DateTime)table.Rows[0]["RegistrationData"];
            return vac;
        }

        public string saveVacancy(Vacancy vac) {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into dbo.Vacancies (CompanyID,
                                                            Objective,
                                                            Information,
                                                            Experience,
                                                            Employment,
                                                            Salary,
                                                            Adress,
                                                            ContactPhoneNumber,
                                                            RegistrationData) 
                                                            Values 
                                                            ('" + vac.CompanyID + @"',
                                                             '" + vac.Objective + @"',
                                                             '" + vac.Information + @"',
                                                             '" + vac.Experience + @"',
                                                             '" + vac.Employment + @"',
                                                             '" + vac.Salary + @"',
                                                             '" + vac.Adress + @"',
                                                             '" + vac.ContactPhoneNumber + @"',
                                                             '" + vac.RegistrationData + @"')";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Vacancy Successfully";
            }
            catch (Exception)
            {
                return "Failed to add Vacancy";
            }
        }

        public string updateVacancy(Vacancy vac) {
            try
            {
                DataTable table = new DataTable();
                string query = @"update dbo.Vacancies set  
                                                            Objective =     '" + vac.Objective + @"',
                                                            Information =   '" + vac.Information + @"',
                                                            Experience =    '" + vac.Experience + @"',
                                                            Employment =    '" + vac.Employment + @"',
                                                            Salary =        '" + vac.Salary + @"',
                                                            Adress =        '" + vac.Adress + @"',
                                                            ContactPhoneNumber =   '" + vac.ContactPhoneNumber + @"'
                                                            where
                                                            VacancyID =     '" + vac.VacancyID + @"'";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Vacancy Successfully";
            }
            catch (Exception)
            {
                return "Failed to update Vacancy";
            }
        }
    }
}
