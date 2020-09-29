using System;
using System.Device.Location;


namespace WebAPI.Models
{
    public class Vacancy
    {
        public Guid VacancyID { get; private set; }
        public string VacancyName { get; set; }
        public Guid CompanyID { get; set; }
        public string Information { get; set; }
        public string ContactNumber { get; set; }
        public decimal Salary { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
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
            if (InputInfo.Length > minLen && InputInfo.Length < maxLen)
            {
                return true;
            }
            return true;
        }
        public decimal SalaryInUAH()
        {
            const decimal conversionRate = 28.3m;
            return Salary * conversionRate;
        }
        public double distance(double userLatitude, double userLongitude) 
        {
            var startCoord = new GeoCoordinate(Latitude, Longitude);
            var endCoord = new GeoCoordinate(userLatitude, userLongitude);

            return startCoord.GetDistanceTo(endCoord);
        }
    }
}