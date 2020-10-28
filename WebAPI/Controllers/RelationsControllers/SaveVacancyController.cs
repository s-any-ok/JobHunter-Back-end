using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using JobUa.Data.Models.Relations;
using JobUa.Data.DAO.DataBase;
using JobUa.Data.DAO;
using System.Data;
using Newtonsoft.Json.Linq;


namespace WebAPI.Controllers
{
    public class SaveVacancyController : ApiController
    {
        public ISaveVacancy DB = new DBSaveVacancy();
        public HttpResponseMessage Get()
        {
            DataTable table = DB.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [HttpGet]
        [Route("api/SaveVacancy/{empId}")]
        public HttpResponseMessage Get(Guid empId)
        {
            DataTable table = DB.getByEmpGuid(empId);
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        [HttpPost, MultiPostParameters]
        public string Post(Guid VacancyID, Guid EmployeeID, DateTime SaveData)
        {
            
            return DB.saveNewVacancy(VacancyID, EmployeeID, SaveData);
        }
        [HttpDelete]
        [Route("api/SaveVacancy/{saveId}")]
        public string Delete(Guid? saveId)
        {
            return DB.deleteSaveVacBySaveGuid(saveId);
        }
    }
}







