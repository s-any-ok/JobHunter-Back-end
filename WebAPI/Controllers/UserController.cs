﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobUa.Data.Models;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using JobUa.Data.DAO;
using JobUa.Data.DAO.DataBase;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        public IUser DB = new DBUser();
        public string Post(User user)
        {
            return DB.SaveUser(user);
        }

        [HttpPost, MultiPostParameters]
        [Route("login")]
        public HttpResponseMessage Login(string login, string password) {

            var table = DB.LoginUser(login, password);

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
                vals["Login"] = login;
                vals["Password"] = password;
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
            return Request.CreateResponse(HttpStatusCode.OK, "Incorrect login or password!");
 
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
