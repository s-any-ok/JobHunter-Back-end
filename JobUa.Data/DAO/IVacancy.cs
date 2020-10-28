using JobUa.Data.DAO.DataBase;
using JobUa.Data.Models;
using System;

namespace JobUa.Data.DAO
{
    public interface IVacancy : IBase
    {
        Vacancy getVacObjByGuid(Guid guid);
        string saveVacancy(Vacancy vac);
        string updateVacancy(Vacancy vac);
    }
}
