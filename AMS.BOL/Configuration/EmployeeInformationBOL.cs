using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class EmployeeInformationBOL
    {
        public int AutoID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string NIDNo { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string JoiningDateBind { get; set; }
        public string Designation { get; set; }
        public int SalaryPerMonth { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public Boolean? IsActive { get; set; }

      //  public string Image { get; set; }

    }
}
