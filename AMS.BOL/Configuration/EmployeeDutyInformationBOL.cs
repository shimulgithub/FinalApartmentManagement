using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class EmployeeDutyInformationBOL
    {
        public int AutoID { get; set; }
        public string EmployeeID { get; set; }
        public string DesignationID { get; set; }
        public DateTime? DutyStartDate { get; set; }
        public string DutyStartDateBind { get; set; }
        public DateTime? DutyEndDate { get; set; }
        public string DutyEndDateBind { get; set; }
        public string DutyStartTime { get; set; }
        public string DutyEndTime { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string ChangedBy { get; set; }
        public DateTime? ChangedDateTime { get; set; }

      //  public string Image { get; set; }

    }
}
