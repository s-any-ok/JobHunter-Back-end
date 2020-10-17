using System;

namespace JobUa.Data.Models.Relations
{
    public class SaveVacancy
    {
        public Guid SaveID { get; private set; }
        public Guid VacancyID { get; set; }
        public Guid EmployeeID { get; set; }
        public DateTime SaveData { get; set; }
    }
}
