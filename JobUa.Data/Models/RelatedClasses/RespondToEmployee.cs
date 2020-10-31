using JobUa.Data.DAO.DataBase;
using System;

namespace JobUa.Data.Models.Relations
{
    public class RespondToEmployee
    {
        public Guid RespondID { get; private set; }
        private DBCompany DBComp;
        private DBEmployee DBEmp;
        public Company Company
        {
            get { return DBComp.GetCmpObjByGuid(_CompanyID); }
            set { _CompanyID = value.CompanyID; }

        }
        public Employee Employee
        {
            get { return DBEmp.GetEmpObjByGuid(_EmployeeID); }
            set { _EmployeeID = value.EmployeeID; }

        }
        private Guid _CompanyID;
        private Guid _EmployeeID;
        public DateTime RespondData { get; set; }
    }
}
