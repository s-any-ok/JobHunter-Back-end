using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
