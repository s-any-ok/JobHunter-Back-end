using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace JobUa.Data.Models
{
    public class User
    {
        public Guid UserID { get; private set; }
        public Guid ChildID { get; set; }
        public bool isCompany { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string SecretWord { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        public DateTime RegistrationData { get; set; }

        public bool IsValPassword(string inputPassword) {
            int minLen = 8;
            int maxLen = 30;
            return inputPassword.Length > minLen && inputPassword.Length < maxLen;
        }
        public bool IsValEmail(string InputEmail)
        {
            if (string.IsNullOrEmpty(InputEmail))
                return false;
            else
            {
                var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                return regex.IsMatch(InputEmail) && !InputEmail.EndsWith(".");
            }
        }
        public bool IsValSecretWord(string InputSecretWord)
        {
            int minLen = 3;
            int maxLen = 30;
            return InputSecretWord.Length > minLen && InputSecretWord.Length < maxLen;
        }
        public bool IsCorrectPassword(string InputPassword) => InputPassword == UserPassword;
        public bool IsCorrectSecretWord(string InputSecretWord) => InputSecretWord == SecretWord;
       
    }
}