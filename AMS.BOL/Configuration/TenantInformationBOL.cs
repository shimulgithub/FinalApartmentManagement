using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    public   class TenantInformationBOL
    {
        public int? AutoID { get; set; }
        public string TenantName { get; set; }
        public string TenantFatherName { get; set; }
        public DateTime TenantDOB { get; set; }
        public string TenantDOBBind { get; set; }
        public int   ?   TenantMaritalStatus { get; set; }
        public string TenantPermanentAddress { get; set; }
        //public string TenantImage { get; set; }
        public int    Religion { get; set; }
        public int    AdvancRent { get; set; }
        public string TenantContactNo { get; set; }
        public string TenantNID { get; set; }
        public string Email { get; set; }
        public string PresentAddress { get; set; }
        public int    FloorNo { get; set; }
        public int    RentPerMonth { get; set; }
        public string TenantOccupation { get; set; }
        public string TenantEducation { get; set; }
        public string EmargencyContactPerson { get; set; }
        public string EmargencyContactPersonNo { get; set; }
        public string OccupationAddress { get; set; }
        public int    UnitNo { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssueDateBind { get; set; }
        public string HouseWorkerName { get; set; }
        public string HouseWorkerContactNo { get; set; }
        public string HouseWorkerNID { get; set; }
        public string HoseWorkerAddress { get; set; }
        public string DriverName { get; set; }
        public string DriverContactNo { get; set; }
        public string DriverNID { get; set; }
        public string DriverAddress { get; set; }
        public string PreviousHouseName { get; set; }
        public string PreviousHouseOwnerAddress { get; set; }
        public string PreviousHouseOwnerNo { get; set; }
        public bool? IsActive { get; set; }
    }
}
