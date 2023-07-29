using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    MonthlyServiceChargeBLL
    {
       public MonthlyServiceChargeDAL MonthlyServiceChargeDAL { get; set; }

       public MonthlyServiceChargeBLL()
		{
            MonthlyServiceChargeDAL = new MonthlyServiceChargeDAL();
		}

       public int MonthlyServiceCharge_Add(MonthlyServiceChargeBOL _MonthlyServiceCharge)
       {
           try
           {
               return MonthlyServiceChargeDAL.Add(_MonthlyServiceCharge);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int MonthlyServiceCharge_Update(MonthlyServiceChargeBOL _MonthlyServiceCharge)
       {
           try
           {
               return MonthlyServiceChargeDAL.Update(_MonthlyServiceCharge);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int MonthlyServiceCharge_Delete(MonthlyServiceChargeBOL _MonthlyServiceCharge)
       {
           try
           {
               return MonthlyServiceChargeDAL.Delete(_MonthlyServiceCharge);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public MonthlyServiceChargeBOL MonthlyServiceCharge_GetById(MonthlyServiceChargeBOL _MonthlyServiceCharge)
       {
           try
           {
               return MonthlyServiceChargeDAL.MonthlyServiceCharge_GetById(_MonthlyServiceCharge);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable MonthlyServiceCharge_GetDataForGV()
       {
           try
           {
               return MonthlyServiceChargeDAL.MonthlyServiceCharge_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }
       public DataTable MonthlyServiceCharge_GetDataByReceiptNo(string ReceiptNo)
       {
           try
           {
               return MonthlyServiceChargeDAL.MonthlyServiceCharge_GetDataByReceiptNo(ReceiptNo);
           }
           catch
           {
               return null;
           }
       }

    }
}
