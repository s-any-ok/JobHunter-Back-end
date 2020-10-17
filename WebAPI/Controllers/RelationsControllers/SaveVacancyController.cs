using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using JobUa.Data.Models.Relations;

namespace WebAPI.Controllers
{
    public class SaveVacancyController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.SaveVacancies";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [HttpGet]
        [Route("api/SaveVacancy/{empId}")]
        public HttpResponseMessage Get(Guid empId)
        {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.SaveVacancies where EmployeeID = '" + empId + @"'";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(SaveVacancy svac)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into dbo.SaveVacancies (
                                                                VacancyID,
                                                                EmployeeID,
                                                                SaveData
                                                                ) 
                                                                Values 
                                                                ('" + svac.VacancyID + @"',
                                                                 '" + svac.EmployeeID + @"',
                                                                 '" + svac.SaveData + @"')";

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
        [HttpDelete]
        [Route("api/SaveVacancy/{saveId}")]
        public string Delete(Guid? saveId)
        {
            
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from dbo.SaveVacancies where SaveID = '" + saveId + @"'";

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
