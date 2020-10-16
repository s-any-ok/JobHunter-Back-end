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
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(Admin admin) {

            DataTable table = new DataTable();
            string query = @"Select * from dbo.Admins where AdminLogin = '" + admin.Login + @"' and AdminPassword = '" + admin.Password + @"'";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

           if (table.Rows.Count != 0)
            {
                var adminID = table.Rows[0][0];
                var adminName = table.Rows[0][1];
                var obligations = table.Rows[0][4];

                var resp = new HttpResponseMessage();

                var vals = new NameValueCollection(); 
                vals["AdminID"] = adminID.ToString();
                vals["AdminName"] = adminName.ToString();
                vals["Obligations"] = obligations.ToString();
                vals["Login"] = admin.Login;
                vals["Password"] = admin.Password;
                var responseObj = new { 
                    resultCode = 0,
                    AdminID = vals["AdminID"],
                    AdminName = vals["AdminName"],
                    Obligations = vals["Obligations"],
                    Login = vals["Login"],
                    Password = vals["Password"]
                };

                resp.Content = new StringContent(JsonConvert.SerializeObject(responseObj),
                                                 System.Text.Encoding.UTF8, "application/json");
                return resp;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Incorrect login or password!");
 
        }
    }
}
