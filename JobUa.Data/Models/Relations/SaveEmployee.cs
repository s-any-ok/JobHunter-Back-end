using JobUa.Data.DAO.DataBase;
using System;

namespace JobUa.Data.Models.Relations
{
    public class SaveEmployee
    {
        private Guid SaveID;
        public DBCompany DBComp;
        public DBEmployee DBEmp;

        public Company Company
        {
            get { return DBComp.getCmpObjByGuid(_CompanyID); }
            set { _CompanyID = value.CompanyID; }

        }
        public Employee Employee
        {
            get { return DBEmp.getEmpObjByGuid(_EmployeeID); }
            set { _EmployeeID = value.EmployeeID; }

        }
        private Guid _CompanyID;
        private Guid _EmployeeID;
        public DateTime SaveData { get; set; }
    }
}
