using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using JobUa.Data.Models;
using JobUa.Data.DAO.DataBase;
using JobUa.Data.DAO;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/vacancy")]
    public class VacancyController : ApiController
    {
        public IVacancy DB = new DBVacancy();
        public HttpResponseMessage Get()
        {
            DataTable table = DB.getAll("dbo.Vacancies");
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [Route("{guid}")]
        public HttpResponseMessage GetByGuid(Guid guid)
        {
            DataTable table = DB.getObjByGuid(guid, "VacancyID", "dbo.Vacancies");
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [Route("{guid}")]
        public string Delete(Guid guid)
        {
            return DB.deleteObjByGuid(guid, "VacancyID", "dbo.Vacancies");
        }
        public string Post(Vacancy vac)
        {
            return DB.saveVacancy(vac);
        }
        public string Put(Vacancy vac)
        {
            return DB.updateVacancy(vac);
        }
    }
}
