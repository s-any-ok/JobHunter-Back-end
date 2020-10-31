using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobUa.Data.DAO.DataBase;
using JobUa.Data.DAO;
using System.Data;

namespace WebAPI.Controllers
{
    public class SaveVacancyController : ApiController
    {
        public ISaveVacancy DB = new DBSaveVacancy();
        public HttpResponseMessage Get()
        {
            DataTable table = DB.GetAll("dbo.SaveVacancies");
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [HttpGet]
        [Route("api/SaveVacancy/{empId}")]
        public HttpResponseMessage Get(Guid empId)
        {
            DataTable table = DB.GetObjByGuid(empId, "EmployeeID", "dbo.SaveVacancies");
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [HttpDelete]
        [Route("api/SaveVacancy/{saveId}")]
        public string Delete(Guid saveId)
        {
            return DB.DeleteObjByGuid(saveId, "SaveID", "dbo.SaveVacancies");
        }
        [HttpPost, MultiPostParameters]
        public string Post(Guid VacancyID, Guid EmployeeID, DateTime SaveData)
        { 
            return DB.SaveNewVacancy(VacancyID, EmployeeID, SaveData);
        }
        
    }
}







