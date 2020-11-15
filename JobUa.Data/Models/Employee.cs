using JobUa.Data.Models.Relations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobUa.Data.Models
{
    public class Employee : User
    {
        
        public Guid EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Education { get; set; }
        public string AdditionalEducation { get; set; }
        public string Objective { get; set; }
        public string Experience { get; set; }
        public string Skills { get; set; }
        public DateTime Birthday { get; set; }
        public string Adress { get; set; }
        public byte[] PhotoData { get; set; }


        public override bool isCorrectUserName(string userName) => Char.IsLower(userName, 0);
        public int Age()
        {
            var today = DateTime.Today;
            int age = today.Year - Birthday.Year;
            return age;
        }
        
    }
    public enum Gender {Male, Female, Custom }
}




//static public List<Employee> Employees = new List<Employee>();
//public List<SaveVacancy> SaveVacancies
//{
//    get { return SaveVacancy.SaveVacancies.Where(sv => sv.Employee == this).ToList(); }
//}
//public List<Vacancy> Vacancies
//{
//    get { return SaveVacancy.SaveVacancies.Where(sv => sv.Employee == this).Select(sv => sv.Vacancy).ToList(); }
//}
//public Guid _employeeID { get; private set; }