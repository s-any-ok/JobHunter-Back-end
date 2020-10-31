using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using JobUa.Data.DAO.DataBase;
using JobUa.Data.DAO;

namespace WebAPI.Controllers
{
    public class SaveEmployeeController : ApiController
    {
        public ISaveEmployee DB = new DBSaveEmployee();
        public HttpResponseMessage Get()
        {
            DataTable table = DB.GetAll("dbo.SaveEmployees");
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [HttpGet]
        [Route("api/SaveEmployee/{cmpId}")]
        public HttpResponseMessage Get(Guid cmpId)
        {
            DataTable table = DB.GetObjByGuid(cmpId, "CompanyID", "dbo.SaveEmployees");
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [HttpDelete]
        [Route("api/SaveEmployee/{saveId}")]
        public string Delete(Guid saveId)
        {
            string result = DB.DeleteObjByGuid(saveId, "SaveID", "dbo.SaveEmployees");
            return result;
        }
        [HttpPost, MultiPostParameters]
        public string Post(Guid CompanyID, Guid EmployeeID, DateTime SaveData)
        {
            string result = DB.SaveNewEmployee(CompanyID, EmployeeID, SaveData);
            return result;

        }
    }
}
