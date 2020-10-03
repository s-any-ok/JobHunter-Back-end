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
    public class CompanyController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.Companies";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

                return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Company comp)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into dbo.Companies (UserName,
                                                            CompanyName,
                                                            Information,
                                                            CompanySite,
                                                            Mail,
                                                            ContactNumber,
                                                            SecretWord,
                                                            RegistrationData)  
                                                            Values 
                                                            ('" + comp.UserName + @"',
                                                             '" + comp.CompanyName + @"',
                                                             '" + comp.Information + @"',
                                                             '" + comp.CompanySite + @"',
                                                             '" + comp.Mail + @"',
                                                             '" + comp.ContactNumber + @"',
                                                             '" + comp.SecretWord + @"',
                                                             '" + comp.RegistrationData + @"')";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Company Successfully";
            }
            catch (Exception)
            {
                return "Failed to add Company";
            }

        }
        public string Put(Company comp)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update dbo.Companies set 
                                                            CompanyName = '" + comp.CompanyName + @"',
                                                            Information = '" + comp.Information + @"',
                                                            Mail = '" + comp.Mail + @"',
                                                            CompanySite = '" + comp.CompanySite + @"',
                                                            ContactNumber = '" + comp.ContactNumber + @"'
                                                            where
                                                            CompanyID = '" + comp.CompanyID + @"'";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Company Successfully";
            }
            catch (Exception)
            {
                return "Failed to update Company";
            }

        }
        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from dbo.Companies where  CompanyID = " + id;
                                                            
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Company Successfully";
            }
            catch (Exception)
            {
                return "Failed to delete Company";
            }

        }


    }
}
