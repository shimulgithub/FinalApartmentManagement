using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class FloorInformationBOL
    {


        public int AutoID { get; set; }
        public string FloorName { get; set; }
        public string CreateBy { get; set; }
        public string ChangedBy { get; set; }

    }
}
