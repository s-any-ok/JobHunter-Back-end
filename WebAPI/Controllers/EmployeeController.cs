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
        public HttpResponseMessage Get(Guid id)
        {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.Employees where EmployeeID = '" + id + @"'";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
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
                                                            FirstName,
                                                            MiddleName,
                                                            LastName,
                                                            Education,
                                                            AdditionalEducation,
                                                            Gender,
                                                            Objective,
                                                            Experience,
                                                            Skills,
                                                            Adress,
                                                            Birthday) 
                                                            Values 
                                                            ('" + emp.EmployeeID + @"',
                                                             '" + emp.FirstName + @"',
                                                             '" + emp.MiddleName + @"',
                                                             '" + emp.LastName + @"',
                                                             '" + emp.Education + @"',
                                                             '" + emp.AdditionalEducation + @"',
                                                             '" + emp.Gender + @"',
                                                             '" + emp.Objective + @"',
                                                             '" + emp.Experience + @"',
                                                             '" + emp.Skills + @"',
                                                             '" + emp.Adress + @"',
                                                             '" + emp.Birthday + @"')";

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
                                                            FirstName =                 '" + emp.FirstName + @"',
                                                            MiddleName =                '" + emp.MiddleName + @"',
                                                            LastName =                  '" + emp.LastName + @"',
                                                            Education =                 '" + emp.Education + @"',
                                                            AdditionalEducation =       '" + emp.AdditionalEducation + @"',
                                                            Objective =                 '" + emp.Objective + @"',
                                                            Experience =                '" + emp.Experience + @"',
                                                            Skills =                    '" + emp.Skills + @"',
                                                            Adress =                    '" + emp.Adress + @"',
                                                            PhotoData =                 '" + emp.PhotoData + @"'
                                                            where
                                                            EmployeeID =                '" + emp.EmployeeID + @"'";

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
        public string Delete(Guid? id)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from dbo.Employees where EmployeeID = '" + id + @"'";

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
