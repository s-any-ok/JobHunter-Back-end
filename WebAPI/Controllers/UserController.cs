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
    public class UserController : ApiController
    {
        public string Post(User user)
        {
            try
            {
                DataTable table = new DataTable();
                //string query = @"Select EmployeeID, CompanyID from dbo.Vacancies where UserLogin = '" + login + @"' AND UserPassword = '" + password + @"'";
                string query = @"insert into dbo.Users (UserLogin,
                                                            UserPassword,
                                                            isCompany,
                                                            ChildID) 
                                                            Values 
                                                            ('" + user.Login + @"',
                                                             '" + user.Password + @"',
                                                             '" + user.isCompany + @"',
                                                             '" + user.ChildID + @"')";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "You registered Successfully";
            }
            catch (Exception)
            {
                return "Failed to register";
            }

        }
    }
}
