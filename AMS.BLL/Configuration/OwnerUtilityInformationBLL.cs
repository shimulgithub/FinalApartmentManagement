using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    OwnerUtilityInformationBLL
    {
       public OwnerUtilityInformationDAL OwnerUtilityInformationDAL { get; set; }

       public OwnerUtilityInformationBLL()
		{
            OwnerUtilityInformationDAL = new OwnerUtilityInformationDAL();
		}

       public int OwnerUtilityInformation_Add(OwnerUtilityInformationBOL _OwnerUtilityInformation)
       {
           try
           {
               return OwnerUtilityInformationDAL.Add(_OwnerUtilityInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int OwnerUtilityInformation_Update(OwnerUtilityInformationBOL _OwnerUtilityInformation)
       {
           try
           {
               return OwnerUtilityInformationDAL.Update(_OwnerUtilityInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int OwnerUtilityInformation_Delete(OwnerUtilityInformationBOL _OwnerUtilityInformation)
       {
           try
           {
               return OwnerUtilityInformationDAL.Delete(_OwnerUtilityInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public OwnerUtilityInformationBOL OwnerUtilityInformation_GetById(OwnerUtilityInformationBOL _OwnerUtilityInformation)
       {
           try
           {
               return OwnerUtilityInformationDAL.OwnerUtilityInformation_GetById(_OwnerUtilityInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable OwnerUtilityInformation_GetDataForGV()
       {
           try
           {
               return OwnerUtilityInformationDAL.OwnerUtilityInformation_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }

    }
}
