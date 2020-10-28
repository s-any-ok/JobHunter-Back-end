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
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        IEmployee DB = new DBEmployee();
        public HttpResponseMessage Get()
        {
            DataTable table = DB.getAll("dbo.Employees");
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [Route("{guid}")]
        public HttpResponseMessage Get(Guid guid)
        {
            DataTable table = DB.getObjByGuid(guid, "EmployeeID", "dbo.Employees");
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [Route("{guid}")]
        public string Delete(Guid guid)
        {
            return DB.deleteObjByGuid(guid, "EmployeeID", "dbo.Employees");
        }
        public string Post(Employee emp)
        {
            return DB.saveEmployee(emp);
        }
        public string Put(Employee emp)
        {
            return DB.updateEmployee(emp);
        }
    }
}
