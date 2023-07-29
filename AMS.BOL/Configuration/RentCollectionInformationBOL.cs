using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.BOL.Configuration
{
    [Serializable()]
    public class RentCollectionInformationBOL
    {
          public int AutoID { get; set; }
          public string FloorID { get; set; }
          public string UnitName { get; set; }
          public string MonthName { get; set; }
          public string Year { get; set; }
          public string ReferecneNo { get; set; }
          public string IssueDateBind { get; set; }
          public DateTime  IssueDate { get; set; }
          public string RenterID { get; set; }
          public string TenantName { get; set; }
          public string Rent { get; set; }
          public string WaterBill { get; set; }
          public string GasBill { get; set; }
          public string ElectricBill { get; set; }
          public string SecurityBill { get; set; }
          public string UtilityBill { get; set; }
          public string OtherBill { get; set; }
          public string TotalBill { get; set; }
          public string BillStatus { get; set; }
          public string DueDateBind { get; set; }
          public DateTime  DueDate { get; set; }
          public string Purpose { get; set; }
          public string CreateBy { get; set; }
          public DateTime? CreatedDateTime { get; set; }
          public string ChangedBy { get; set; }
          public DateTime? ChangedDateTime { get; set; }

      //  public string Image { get; set; }

    }
}
