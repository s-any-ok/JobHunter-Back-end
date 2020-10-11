using System;
using System.Collections.Generic;

namespace JobUa.Data.Models
{
    public class Company : User
    {
        public Guid CompanyID { get; private set; }
        public string TIN { get; set; } // ІПН
        public string Name { get; set; }
        public string Information { get; set; }
        public BusinessType BusinessType { get; set; }
        public bool IsVip { get; set; }
        public string Link { get; set; }
        public byte[] ImageData { get; set; }
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
            return InputInfo.Length > minLen && InputInfo.Length < maxLen;
        }
      
    }
    public enum BusinessType { 
        Financial, Product, Social, 
        Education, Security, Retailers, 
        Services, Agriculture, Transportation,
        RealEstate, Advertising, Manufacturing,
        Mining, Utilities  
    }
}