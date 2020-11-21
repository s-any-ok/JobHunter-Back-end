using System;

namespace JobUa.Data.Models
{
    public class Vacancy
    {
        public Guid VacancyID { get; private set; }
        public Guid CompanyID { get; set; }
        public string Objective { get; set; }
        public string Information { get; set; }
        public string Experience { get; set; }
        public string Employment { get; set; }
        public decimal Salary { get; set; }
        public string Adress { get; set; }
        public string ContactPhoneNumber { get; set; }
        public DateTime RegistrationData { get; set; }
        public int TimeAfterRegistration()
        {
            var today = DateTime.Today;
            int hours = today.Hour - RegistrationData.Hour;
            return hours;
        }
        public string WageLevel()
        {
            decimal averageWage = 500; //$
            if (Salary < averageWage)
            {
                return "Low wage";
            }
            else if (Salary > averageWage)
            {
                return "High wage";
            }
            else {
                return "Average wage";
            }

        }
        public bool IsValInformation(string InputInfo)
        {
            int minLen = 20;
            int maxLen = 500;
            return InputInfo.Length > minLen && InputInfo.Length < maxLen;
        }
        public decimal SalaryInUAH()
        {
            const decimal conversionRate = 28.3m;
            return Salary * conversionRate;
        }
        public string getRegDateString() {
            string[] RegDateArr = RegistrationData.ToString().Split(' ')[0].Split('.');
            (RegDateArr[0], RegDateArr[1]) = (RegDateArr[1], RegDateArr[0]);
            string strDate = string.Join("-", RegDateArr);
            return strDate;
        }

    }
}


//static public List<Vacancy> Vacancies = new List<Vacancy>();
//private Guid _companyID;
//public Company Company
//{
//    get { return Company.Companies.Where(c => c._companyID == _companyID).FirstOrDefault(); }
//    set { _companyID = value._companyID; }
//}
//public List<SaveVacancy> SaveVacancies
//{
//    get { return SaveVacancy.SaveVacancies.Where(sv => sv.Vacancy == this).ToList(); }
//}
//public List<Employee> Employees
//{
//    get { return SaveVacancy.SaveVacancies.Where(sv => sv.Vacancy == this).Select(sv => sv.Employee).ToList(); }
//}
//public Guid _vacancyID { get; private set; }