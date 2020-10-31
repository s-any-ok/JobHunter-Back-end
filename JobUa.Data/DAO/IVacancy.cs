using JobUa.Data.DAO.DataBase;
using JobUa.Data.Models;
using System;

namespace JobUa.Data.DAO
{
    public interface IVacancy : IBase
    {
        Vacancy GetVacObjByGuid(Guid guid);
        string SaveVacancy(Vacancy vac);
        string UpdateVacancy(Vacancy vac);
    }
}
