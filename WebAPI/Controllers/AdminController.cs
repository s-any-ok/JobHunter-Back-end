using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Specialized;
using Newtonsoft.Json;
using JobUa.Data.DAO.DataBase;
using JobUa.Data.DAO;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        IAdmin DB = new DBAdmin();
        [HttpPost, MultiPostParameters]
        [Route("login")]
        public HttpResponseMessage Login(string login, string password) 
        {
            var table = DB.LoginAdmin(login, password);

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
                vals["Login"] = login;
                vals["Password"] = password;
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
