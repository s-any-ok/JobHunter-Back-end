using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data;
using JobUa.Data.Models.Relations;
using JobUa.Data.DAO.DataBase;
using JobUa.Data.DAO;

namespace WebAPI.Controllers
{
    public class SaveEmployeeController : ApiController
    {
        public ISaveEmployee DB = new DBSaveEmployee();
        public HttpResponseMessage Get()
        {
            DataTable table = DB.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [HttpGet]
        [Route("api/SaveEmployee/{cmpId}")]
        public HttpResponseMessage Get(Guid cmpId)
        {
            DataTable table = DB.getByCmpGuid(cmpId);
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [HttpPost, MultiPostParameters]
        public string Post(Guid CompanyID, Guid EmployeeID, DateTime SaveData)
        {
            string result = DB.saveNewEmployee(CompanyID, EmployeeID, SaveData);
            return result;

        }
        [HttpDelete]
        [Route("api/SaveEmployee/{saveId}")]
        public string Delete(Guid? saveId)
        {
            string result = DB.deleteSaveEmpBySaveGuid(saveId);
            return result;
        }
    }
}
