using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    ApartmentFundInformationBLL
    {
       public ApartmentFundInformationDAL ApartmentFundInformationDAL { get; set; }

       public ApartmentFundInformationBLL()
		{
            ApartmentFundInformationDAL = new ApartmentFundInformationDAL();
		}

       public int ApartmentFundInformation_Add(ApartmentFundInformationBOL _ApartmentFundInformation)
       {
           try
           {
               return ApartmentFundInformationDAL.Add(_ApartmentFundInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int ApartmentFundInformation_Update(ApartmentFundInformationBOL _ApartmentFundInformation)
       {
           try
           {
               return ApartmentFundInformationDAL.Update(_ApartmentFundInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int ApartmentFundInformation_Delete(ApartmentFundInformationBOL _ApartmentFundInformation)
       {
           try
           {
               return ApartmentFundInformationDAL.Delete(_ApartmentFundInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public ApartmentFundInformationBOL ApartmentFundInformation_GetById(ApartmentFundInformationBOL _ApartmentFundInformation)
       {
           try
           {
               return ApartmentFundInformationDAL.ApartmentFundInformation_GetById(_ApartmentFundInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable ApartmentFundInformation_GetDataForGV()
       {
           try
           {
               return ApartmentFundInformationDAL.ApartmentFundInformation_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }

    }
}
