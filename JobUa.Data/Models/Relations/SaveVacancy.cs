using System;

namespace JobUa.Data.Models.Relations
{
    public class SaveVacancy
    {
        public Guid SaveID { get; private set; }
        public Vacancy Vacancy { get; set; }
        public Employee Employee { get; set; }
        public DateTime SaveData { get; set; }
    }
}
