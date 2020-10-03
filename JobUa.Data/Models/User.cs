using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace JobUa.Data.Models
{
    public class User
    {
        public Guid UserID { get; private set; }
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string SecretWord { get; set; }
        public string Mail { get; set; }
        public string ContactNumber { get; set; }

        public bool IsValPassword(string inputPassword) {
            int minLen = 8;
            int maxLen = 30;
            if (inputPassword.Length > minLen && inputPassword.Length < maxLen) {
                return true;
            }
            return true;
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
            if (InputSecretWord.Length > minLen && InputSecretWord.Length < maxLen)
            {
                return true;
            }
            return true;
        }
        public bool IsCorrectPassword(string InputPassword)
        {
            if (InputPassword == Password) {
                return true;
            }
            return false;
        }
        public bool IsCorrectSecretWord(string InputSecretWord)
        {
            if (InputSecretWord == SecretWord)
            {
                return true;
            }
            return false;
        }
    }
}