using System;
using System.Text.RegularExpressions;


namespace JobUa.Data.Models
{
    public class User
    {
        private Guid UserID;
        public Guid ChildID { get; set; }
        public bool isCompany { get; set; }
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string SecretWord { get; set; }
        public string Email { get; set; }
        public string ContactPhoneNumber { get; set; }
        public DateTime RegistrationData { get; set; }

        public virtual bool isCorrectUserName(string userName) => Char.IsUpper(userName, 0);
 
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
        public bool IsCorrectPassword(string InputPassword) => InputPassword == Password;
        public bool IsCorrectSecretWord(string InputSecretWord) => InputSecretWord == SecretWord;

        public string getRegDateString()
        {
            string[] RegDateArr = RegistrationData.ToString().Split(' ')[0].Split('.');
            (RegDateArr[0], RegDateArr[1]) = (RegDateArr[1], RegDateArr[0]);
            string strDate = string.Join("-", RegDateArr);
            return strDate;
        }

    }
}