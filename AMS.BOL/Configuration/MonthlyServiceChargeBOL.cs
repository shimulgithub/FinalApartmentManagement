using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class MonthlyServiceChargeBOL
    {
        public int ? AutoID { get; set; }
        public string OrganizationName { get; set; }
        public string ChargeName { get; set; }
        public string ReceiptNo { get; set; }
        public string OldReceiptNo { get; set; }
        public string FlatNo { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public DateTime? Date { get; set; }
        public string DateBind { get; set; }
        public double TotalAmount { get; set; }
        public string ChargeListName { get; set; }
        public double ChargeAmount { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string ChangedBy { get; set; }
        public DateTime? ChangedDateTime { get; set; }


    }
}
