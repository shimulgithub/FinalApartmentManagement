using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class BillDepositInformationBOL
    {
          public int AutoID { get; set; }
          public string BillTypeID { get; set; }
          public string BankID { get; set; }
          public string MonthName { get; set; }
          public string Year { get; set; }
          public string ReferencNo { get; set; }
          public DateTime  BillDate { get; set; }
          public string BillDateBind { get; set; }
          public string TotalAmt { get; set; }
          public string Remarks { get; set; }
          public string CreateBy { get; set; }
          public DateTime? CreatedDateTime { get; set; }
          public string ChangedBy { get; set; }
          public DateTime? ChangedDateTime { get; set; }

      //  public string Image { get; set; }

    }
}
