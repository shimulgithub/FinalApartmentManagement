using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class OwnerInformationBOL
    {

        public int AutoID { get; set; }
        public string OwnerName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string National_Id_card_No { get; set; }
        public string Present_Address { get; set; }
        public string Permanent_Address { get; set; }
        public int  UnitId { get; set; }
        public string CreateBy { get; set; }
        public string ChangedBy { get; set; }

    }
}
