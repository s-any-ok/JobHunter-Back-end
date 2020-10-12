using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobUa.Data.Models.Relations
{
    public class RespondToEmployee
    {
        public Guid RespondID { get; private set; }
        public Guid CompanyID { get; set; }
        public Guid EmployeeID { get; set; }
        public DateTime RespondData { get; set; }
    }
}
