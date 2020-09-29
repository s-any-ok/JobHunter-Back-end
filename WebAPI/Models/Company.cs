using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class Company : User
    {
        public Guid CompanyID { get; private set; }
        public string CompanyName { get; set; }
        public string Information { get; set; }
        public string CompanySite { get; set; }
        public bool IsVip { get; set; }
        public List<string> Partners { get; set; }
        public List<string> Vacancies { get; set; }
        public DateTime RegistrationData { get; set; }

        public int TimeAfterRegistration()
        {
            var today = DateTime.Today;
            int age = today.Year - RegistrationData.Year;
            return age;
        }
        public bool IsValInformation(string InputInfo)
        {
            int minLen = 100;
            int maxLen = 500;
            if (InputInfo.Length > minLen && InputInfo.Length < maxLen)
            {
                return true;
            }
            return true;
        }
        public int AmountOfVacancies()
        {
            return Vacancies.Count;
        }
        public void AddVacancy(string Vacancy)
        {
            Vacancies.Add(Vacancy);
        }
        public int AmountOfPartenrs()
        {
            return Partners.Count;
        }
        public void AddPartners(string Partner)
        {
            Partners.Add(Partner);
        }
    }
}