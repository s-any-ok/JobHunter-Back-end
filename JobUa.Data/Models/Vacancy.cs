using System;
using System.Device.Location;


namespace JobUa.Data.Models
{
    public class Vacancy
    {
        public Guid VacancyID { get; set; }
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

        public Guid getId() => VacancyID;
        
    }
}