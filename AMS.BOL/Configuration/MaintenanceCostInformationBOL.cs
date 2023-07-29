using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class MaintenanceCostInformationBOL
    {
        public int AutoID { get; set; }
        public string CostTitle { get; set; }                                                                                 
        public DateTime? Date { get; set; }
        public string DateBind { get; set; }
        //public string Month { get; set; }
        //public string Year { get; set; }
        public string TotalAmount { get; set; }
        public string Remarks { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string ChangedBy { get; set; }
        public DateTime? ChangedDateTime { get; set; }


    }
}
