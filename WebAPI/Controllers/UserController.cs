using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using JobUa.Data.Models;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Linq;
using System.Collections.Generic;

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
                string query = @"insert into dbo.Users      (ChildID,
                                                            isCompany,
                                                            UserName,
                                                            UserLogin,
                                                            UserPassword,
                                                            SecretWord,
                                                            Email,
                                                            PhoneNumber,
                                                            RegistrationData) 
                                                            Values 
                                                            ('" + user.ChildID + @"',
                                                             '" + user.isCompany + @"',
                                                             '" + user.UserName + @"',
                                                             '" + user.Login + @"',
                                                             '" + user.Password + @"',
                                                             '" + user.SecretWord + @"',
                                                             '" + user.Email + @"',
                                                             '" + user.PhoneNumber + @"',
                                                             '" + user.RegistrationData + @"')";

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

        [HttpPost]
        [Route("api/user/login")]
        public HttpResponseMessage Login(User user) {

            DataTable table = new DataTable();
            string query = @"Select UserID, ChildID, IsCompany from dbo.Users where UserLogin = '" + user.Login + @"' and UserPassword = '" + user.Password + @"'";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            var id = table.Rows[0][0];
            var childId = table.Rows[0][1];
            var isCompany = table.Rows[0][2];

           if (table.Rows.Count != 0)
            {
                var resp = new HttpResponseMessage();

                var vals = new NameValueCollection(); // using System.Collections.Specialized
                vals["Id"] = id.ToString();
                vals["ChildID"] = childId.ToString();
                vals["IsCompany"] = isCompany.ToString();
                var cookie = new CookieHeaderValue("user", vals);


                cookie.Expires = DateTimeOffset.Now.AddHours(1);
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";

                resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
                return resp;
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
 
        }
        [HttpGet]
        [Route("api/user/auth")]
        public IHttpActionResult Auth()
        {
            CookieHeaderValue cookie = Request.Headers.GetCookies("user").FirstOrDefault();
            if (cookie != null)
            {
                CookieState cookieState = cookie["user"];
                Dictionary<string, string> table = new Dictionary<string, string>(3);
                table.Add("Id", cookieState["Id"]);
                table.Add("ChildID", cookieState["ChildID"]);
                table.Add("IsCompany", cookieState["IsCompany"]);
                return Ok(table);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("api/user/logout/{id}")]
        public HttpResponseMessage Logout(string id)
        {
            var resp = new HttpResponseMessage();

            var vals = new NameValueCollection();
            vals["Id"] = null;
            vals["ChildID"] = null;
            vals["IsCompany"] = null;

            var cookie = new CookieHeaderValue("user", vals);

            cookie.Expires = DateTimeOffset.Now.AddHours(1);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";

            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return resp;
        }
    }
}
