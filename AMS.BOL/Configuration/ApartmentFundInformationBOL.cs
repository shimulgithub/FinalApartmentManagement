using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class ApartmentFundInformationBOL
    {
        public int AutoID { get; set; }
        public string OwnerID { get; set; }
        public string DesignationID { get; set; }
        public string ReferenceID { get; set; }
        public string TotalAmount { get; set; }
        public string Purpose { get; set; }
        public DateTime? Date { get; set; }
        public string DateBind { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string ChangedBy { get; set; }
        public DateTime? ChangedDateTime { get; set; }

      //  public string Image { get; set; }

    }
}
