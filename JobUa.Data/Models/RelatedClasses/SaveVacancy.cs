using JobUa.Data.DAO.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;

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









//static public List<SaveVacancy> SaveVacancies = new List<SaveVacancy>();
//private Guid _saveID;
//private Guid _vacancyID;
//public Vacancy Vacancy
//{
//    get { return Vacancy.Vacancies.Where(v => v._vacancyID == _vacancyID).FirstOrDefault(); }
//    set { _vacancyID = value._vacancyID; }
//}
//private Guid _employeeID;
//public Employee Employee
//{
//    get { return Employee.Employees.Where(v => v._employeeID == _employeeID).FirstOrDefault(); }
//    set { _employeeID = value._employeeID; }
//}
//public DateTime SaveData { get; set; }




