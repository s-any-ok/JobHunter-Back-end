using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using JobUa.Data.Models;
using JobUa.Data.DAO.DataBase;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/company")]
    public class CompanyController : ApiController
    {
        ICompany DB = new DBCompany();
        public HttpResponseMessage Get()
        {
            DataTable table = DB.getAll("dbo.Companies"); 
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [Route("{guid}")]
        public HttpResponseMessage Get(Guid guid)
        {
            DataTable table = DB.getObjByGuid(guid, "CompanyID", "dbo.Companies");
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [Route("{guid}")]
        public string Delete(Guid guid)
        {
            return DB.deleteObjByGuid(guid, "CompanyID", "dbo.Companies");
        }
        public string Post(Company comp)
        {
            return DB.saveCompany(comp);
        }
        public string Put(Company comp)
        {
            return DB.updateCompany(comp);
        }
    }
}
