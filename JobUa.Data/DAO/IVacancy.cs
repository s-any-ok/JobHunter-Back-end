using JobUa.Data.Models;
using System;
using System.Data;

namespace JobUa.Data.DAO
{
    public interface IVacancy
    {
        DataTable getAll();
        DataTable getVacByGuid(Guid guid);
        Vacancy getVacObjByGuid(Guid guid);
        string saveVacancy(Vacancy vac);
        string updateVacancy(Vacancy vac);
        string deleteVacByGuid(Guid guid);
    }
}
