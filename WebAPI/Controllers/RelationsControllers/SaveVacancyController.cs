using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using JobUa.Data.Models.Relations;
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
        public string Post(SaveVacancy svac)
        {
            string result = DB.saveNewVacancy(svac);
            return result;

        }
        [HttpDelete]
        [Route("api/SaveVacancy/{saveId}")]
        public string Delete(Guid? saveId)
        {
            string result = DB.deleteSaveVacBySaveGuid(saveId);
            return result;
        }
    }
}







