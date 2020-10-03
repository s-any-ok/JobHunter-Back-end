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
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.Employees";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Employee emp)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into  dbo.Employees (EmployeeID,
                                                            UserName,
                                                            Surname,
                                                            FirstName,
                                                            Patronymic,
                                                            Education,
                                                            Gender,
                                                            Birthday,
                                                            Mail,
                                                            ContactNumber,
                                                            SecretWord,
                                                            RegistrationData) 
                                                            Values 
                                                            ('" + emp.EmployeeID + @"',
                                                             '" + emp.UserName + @"',
                                                             '" + emp.Surname + @"',
                                                             '" + emp.FirstName + @"',
                                                             '" + emp.Patronymic + @"',
                                                             '" + emp.Education + @"',
                                                             '" + emp.Gender + @"',
                                                             '" + emp.Birthday + @"',
                                                             '" + emp.Mail + @"',
                                                             '" + emp.ContactNumber + @"',
                                                             '" + emp.SecretWord + @"',
                                                             '" + emp.RegistrationData + @"')";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                
                return "Added Employee Successfully";
                
            }
            catch (Exception)
            {
                return "Failed to add Employee";
            }

        }
        public string Put(Employee emp)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update  dbo.Employees set 
                                                            Surname = '" + emp.Surname + @"',
                                                            FirstName = '" + emp.FirstName + @"',
                                                            Patronymic = '" + emp.Patronymic + @"',
                                                            Education = '" + emp.Education + @"',
                                                            ContactNumber = '" + emp.ContactNumber + @"'
                                                            where
                                                            EmployeeID = '" + emp.EmployeeID + @"'";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Employee Successfully";
            }
            catch (Exception)
            {
                return "Failed to update Employee";
            }

        }
        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from dbo.Employees where EmployeeID = " + id;

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Employee Successfully";
            }
            catch (Exception)
            {
                return "Failed to delete Employee";
            }

        }


    }
}
