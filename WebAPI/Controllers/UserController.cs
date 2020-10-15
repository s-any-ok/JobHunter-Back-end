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
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        public string Post(User user)
        {
            try
            {
                DataTable table = new DataTable();
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
        [Route("login")]
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

           if (table.Rows.Count != 0)
            {
                var id = table.Rows[0][0];
                var childId = table.Rows[0][1];
                var isCompany = (bool)table.Rows[0][2] ? 1 : 0;

                var resp = new HttpResponseMessage();

                var vals = new NameValueCollection(); 
                vals["Id"] = id.ToString();
                vals["ChildID"] = childId.ToString();
                vals["IsCompany"] = isCompany.ToString();
                vals["Login"] = user.Login;
                vals["Password"] = user.Password;
                var cookie = new CookieHeaderValue("user", vals);

                cookie.Expires = DateTimeOffset.Now.AddHours(1);
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";

                resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
                var responseObj = new { 
                    resultCode = 0,
                    Id = vals["Id"], ChildID = vals["ChildID"], IsCompany = vals["IsCompany"]
                };

                resp.Content = new StringContent(JsonConvert.SerializeObject(responseObj),
                                                 System.Text.Encoding.UTF8, "application/json");
                return resp;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "User did not be found!");
 
        }
        [HttpGet]
        [Route("auth")]
        public IHttpActionResult Auth()
        {
            CookieHeaderValue cookie = Request.Headers.GetCookies("user").FirstOrDefault();
            if (cookie != null  &&  cookie["user"]["Id"] != null)
            {
                CookieState cookieState = cookie["user"];
                Dictionary<string, object> table = new Dictionary<string, object>(6);
                table.Add("resultCode", 0);
                table.Add("Id", cookieState["Id"]);
                table.Add("ChildID", cookieState["ChildID"]);
                table.Add("IsCompany", cookieState["IsCompany"]);
                table.Add("Login", cookieState["Login"]);
                table.Add("Password", cookieState["Password"]);
                return Ok(table);
            }
            return Ok("You are not authorized");
        }
        [HttpDelete]
        [Route("logout")]
        public HttpResponseMessage Logout()
        {
            var resp = new HttpResponseMessage();

            var vals = new NameValueCollection();
            var cookie = new CookieHeaderValue("user", vals);

            cookie.Expires = DateTimeOffset.Now.AddHours(1);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";

            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return resp;
        }
    }
}
