using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    BillDepositInformationBLL
    {
       public BillDepositInformationDAL BillDepositInformationDAL { get; set; }

       public BillDepositInformationBLL()
		{
            BillDepositInformationDAL = new BillDepositInformationDAL();
		}

       public int BillDepositInformation_Add(BillDepositInformationBOL _BillDepositInformation)
       {
           try
           {
               return BillDepositInformationDAL.Add(_BillDepositInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int BillDepositInformation_Update(BillDepositInformationBOL _BillDepositInformation)
       {
           try
           {
               return BillDepositInformationDAL.Update(_BillDepositInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int BillDepositInformation_Delete(BillDepositInformationBOL _BillDepositInformation)
       {
           try
           {
               return BillDepositInformationDAL.Delete(_BillDepositInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public BillDepositInformationBOL BillDepositInformation_GetById(BillDepositInformationBOL _BillDepositInformation)
       {
           try
           {
               return BillDepositInformationDAL.BillDepositInformation_GetById(_BillDepositInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable BillDepositInformation_GetDataForGV()
       {
           try
           {
               return BillDepositInformationDAL.BillDepositInformation_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }

    }
}
