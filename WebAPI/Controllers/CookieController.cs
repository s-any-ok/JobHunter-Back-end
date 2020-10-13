using JobUa.Data.Models;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;


namespace WebAPI.Controllers
{
    public class CookieController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var resp = new HttpResponseMessage();

            var vals = new NameValueCollection(); // using System.Collections.Specialized
            vals["uid"] = "1";
            vals["login"] = "sss";
            vals["password"] = "wdwd";
            var cookie = new CookieHeaderValue("person", vals);

           
            cookie.Expires = DateTimeOffset.Now.AddDays(1);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";

            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return resp;

        }
        public HttpResponseMessage Post(User user)
        {
            var resp = new HttpResponseMessage();

            var vals = new NameValueCollection(); // using System.Collections.Specialized
            vals["uid"] = "1";
            vals["login"] = user.Login;
            vals["password"] = user.Password;
            var cookie = new CookieHeaderValue("person", vals);


            cookie.Expires = DateTimeOffset.Now.AddDays(1);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";

            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return resp;

        }
       /* public async Task<IHttpActionResult> Post(string login, string password)
        {
            
            var cookie = new CookieHeaderValue("myCookie", login);
            
            var resp = new HttpResponseMessage();
            resp.StatusCode = HttpStatusCode.OK;
            resp.Headers.AddCookies(new[] { cookie });
            return ResponseMessage(resp);
        }*/
        public HttpResponseMessage DeleteCookie(string id)
        {
            var resp = new HttpResponseMessage();

            var vals = new NameValueCollection(); // using System.Collections.Specialized
            vals["uid"] = id;
            vals["login"] = null;
            vals["password"] = null;
            var cookie = new CookieHeaderValue("person", vals);

            cookie.Expires = DateTimeOffset.Now.AddHours(1);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";

            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return resp;

        }
        
    }
}
