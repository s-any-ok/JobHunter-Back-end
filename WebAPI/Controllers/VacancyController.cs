using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using JobUa.Data.Models;


namespace WebAPI.Controllers
{
    public class VacancyController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.Vacancies";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public HttpResponseMessage Get(Guid id)
        {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.Vacancies where VacancyID = '" + id + @"'";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Vacancy vac)
        {
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
                                                            PhoneNumber,
                                                            RegistrationData) 
                                                            Values 
                                                            ('" + vac.CompanyID + @"',
                                                             '" + vac.Objective + @"',
                                                             '" + vac.Information + @"',
                                                             '" + vac.Experience + @"',
                                                             '" + vac.Employment + @"',
                                                             '" + vac.Salary + @"',
                                                             '" + vac.Adress + @"',
                                                             '" + vac.PhoneNumber + @"',
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
        public string Put(Vacancy vac)
        {
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
                                                            PhoneNumber =   '" + vac.PhoneNumber + @"'
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
        public string Delete(Guid? id)
        {
            
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from dbo.Vacancies where VacancyID = '" + id + @"'";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Vacancy Successfully";
            }
            catch (Exception)
            {
                return "Failed to delete Vacancy";
            }

        }
    }
}
