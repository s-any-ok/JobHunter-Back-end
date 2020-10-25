using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobUa.Data.Models.Relations
{
    public class SaveEmployee
    {
        public Guid SaveID { get; private set; }
        public Company Company { get; set; }
        public Employee Employee { get; set; }
        public DateTime SaveData { get; set; }
    }
}
