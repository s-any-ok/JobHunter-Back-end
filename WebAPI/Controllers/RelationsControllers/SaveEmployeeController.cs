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
    public class SaveEmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.SaveEmployees";

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
        [Route("api/SaveEmployee/{cmpId}")]
        public HttpResponseMessage Get(Guid cmpId)
        {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.SaveEmployees where CompanyID = '" + cmpId + @"'";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(SaveEmployee semp)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into dbo.SaveEmployees (
                                                                CompanyID,
                                                                EmployeeID,
                                                                SaveData
                                                                ) 
                                                                Values 
                                                                ('" + semp.CompanyID + @"',
                                                                 '" + semp.EmployeeID + @"',
                                                                 '" + semp.SaveData + @"')";

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
        [HttpDelete]
        [Route("api/SaveEmployee/{saveId}")]
        public string Delete(Guid? saveId)
        {
            
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from dbo.SaveEmployees where SaveID = '" + saveId + @"'";

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
