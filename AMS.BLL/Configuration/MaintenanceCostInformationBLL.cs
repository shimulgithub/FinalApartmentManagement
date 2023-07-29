using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    MaintenanceCostInformationBLL
    {
       public MaintenanceCostInformationDAL MaintenanceCostInformationDAL { get; set; }

       public MaintenanceCostInformationBLL()
		{
            MaintenanceCostInformationDAL = new MaintenanceCostInformationDAL();
		}

       public int MaintenanceCostInformation_Add(MaintenanceCostInformationBOL _MaintenanceCostInformation)
       {
           try
           {
               return MaintenanceCostInformationDAL.Add(_MaintenanceCostInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int MaintenanceCostInformation_Update(MaintenanceCostInformationBOL _MaintenanceCostInformation)
       {
           try
           {
               return MaintenanceCostInformationDAL.Update(_MaintenanceCostInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int MaintenanceCostInformation_Delete(MaintenanceCostInformationBOL _MaintenanceCostInformation)
       {
           try
           {
               return MaintenanceCostInformationDAL.Delete(_MaintenanceCostInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public MaintenanceCostInformationBOL MaintenanceCostInformation_GetById(MaintenanceCostInformationBOL _MaintenanceCostInformation)
       {
           try
           {
               return MaintenanceCostInformationDAL.MaintenanceCostInformation_GetById(_MaintenanceCostInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable MaintenanceCostInformation_GetDataForGV()
       {
           try
           {
               return MaintenanceCostInformationDAL.MaintenanceCostInformation_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }

    }
}
