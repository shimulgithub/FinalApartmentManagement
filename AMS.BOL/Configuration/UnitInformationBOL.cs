using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class UnitInformationBOL
    {


        public int AutoID { get; set; }
        public string UnitName { get; set; }
        public string FloorID { get; set; }
        public string CreateBy { get; set; }
        public string ChangedBy { get; set; }

    }
}
