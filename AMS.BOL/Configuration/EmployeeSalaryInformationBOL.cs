using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class EmployeeSalaryInformationBOL
    {
        public int AutoID { get; set; }
        public string EmployeeID { get; set; }
        public string DesignationID { get; set; }
        public string SalaryMonthName { get; set; }
        public string Year { get; set; }
        public string SalaryAmount { get; set; }
        public DateTime? IssueDate { get; set; }
        public string IssueDateBind { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string ChangedBy { get; set; }
        public DateTime? ChangedDateTime { get; set; }

      //  public string Image { get; set; }

    }
}
