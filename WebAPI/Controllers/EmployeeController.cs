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
            DataTable table = DB.GetAll("dbo.Employees");
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [Route("{guid}")]
        public HttpResponseMessage Get(Guid guid)
        {
            DataTable table = DB.GetObjByGuid(guid, "EmployeeID", "dbo.Employees");
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [Route("{guid}")]
        public string Delete(Guid guid)
        {
            return DB.DeleteObjByGuid(guid, "EmployeeID", "dbo.Employees");
        }
        public string Post(Employee emp)
        {
            return DB.SaveEmployee(emp);
        }
        public string Put(Employee emp)
        {
            return DB.UpdateEmployee(emp);
        }
    }
}
