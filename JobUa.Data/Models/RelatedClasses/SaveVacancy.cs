using JobUa.Data.DAO.DataBase;
using System;

namespace JobUa.Data.Models.Relations
{
    public class SaveVacancy
    {
        private Guid SaveID;
        private DBVacancy DBVac;
        private DBEmployee DBEmp;
        public Vacancy Vacancy
        {
            get { return DBVac.GetVacObjByGuid(_VacancyID); }
            set { _VacancyID = value.VacancyID; }

        }
        public Employee Employee
        {
            get { return DBEmp.GetEmpObjByGuid(_EmployeeID); }
            set { _EmployeeID = value.EmployeeID; }

        }
        
        private Guid _VacancyID;
        private Guid _EmployeeID;
        public DateTime SaveData { get; set; }
    }
}
