using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class ComplainInformationBOL
    {
          public int AutoID { get; set; }
          public string Title { get; set; }
          public string Description { get; set; }
          public DateTime Date { get; set; }
          public string DateBind { get; set; }
          public string CreateBy { get; set; }
          public DateTime? CreatedDateTime { get; set; }
          public string ChangedBy { get; set; }
          public DateTime? ChangedDateTime { get; set; }

      //  public string Image { get; set; }

    }
}
