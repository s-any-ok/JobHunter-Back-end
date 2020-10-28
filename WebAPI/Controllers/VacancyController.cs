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
            DataTable table = DB.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [Route("{guid}")]
        public HttpResponseMessage GetByGuid(Guid guid)
        {
            DataTable table = DB.getVacByGuid(guid);
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Vacancy vac)
        {
            return DB.saveVacancy(vac);
        }
        public string Put(Vacancy vac)
        {
            return DB.updateVacancy(vac);
        }
        [Route("{guid}")]
        public string Delete(Guid guid)
        {
            return DB.deleteVacByGuid(guid);
        }
    }
}
