using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class EmployeeLeaveInformationBOL
    {
        public int AutoID { get; set; }
        public string EmployeeID { get; set; }
        public string DesignationID { get; set; }
        public string LeaveTypeID { get; set; }
        public DateTime? LeaveStartDate { get; set; }
        public string LeaveStartDateBind { get; set; }
        public DateTime? LeaveEndDate { get; set; }
        public string LeaveEndDateBind { get; set; }
        public string LeaveStartTime { get; set; }
        public string LeaveEndTime { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string ChangedBy { get; set; }
        public DateTime? ChangedDateTime { get; set; }

      //  public string Image { get; set; }

    }
}
