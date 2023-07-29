using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class VisitorInformationBOL
    {
          public int AutoID { get; set; }
          public DateTime EntryDate { get; set; }
          public string EntryDateBind { get; set; }
          public string FloorID { get; set; }
          public string UnitID { get; set; }
          public string VisitorTypeID { get; set; }
          public string Name { get; set; }
          public string Mobile { get; set; }
          public string ContactPerson { get; set; }
          public string VisitorAddress { get; set; }
          public string InTime { get; set; }
          public string OutTime { get; set; }
          public string Purpose { get; set; }
          public string CreateBy { get; set; }
          public DateTime? CreatedDateTime { get; set; }
          public string ChangedBy { get; set; }
          public DateTime? ChangedDateTime { get; set; }

      //  public string Image { get; set; }

    }
}
