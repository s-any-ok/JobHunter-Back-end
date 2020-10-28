using JobUa.Data.DAO.DataBase;
using System;

namespace JobUa.Data.Models.Relations
{
    public class RespondToVacancy
    {
        private Guid RespondID;
        private DBVacancy DBVac;
        private DBEmployee DBEmp;
        public Vacancy Vacancy
        {
            get { return DBVac.getVacObjByGuid(_VacancyID); }
            set { _VacancyID = value.VacancyID; }

        }
        public Employee Employee
        {
            get { return DBEmp.getEmpObjByGuid(_EmployeeID); }
            set { _EmployeeID = value.EmployeeID; }

        }

        private Guid _VacancyID;
        private Guid _EmployeeID;
        public DateTime RespondData { get; set; }
    }
}
