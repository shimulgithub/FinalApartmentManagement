using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    RentCollectionInformationBLL
    {
       public RentCollectionInformationDAL RentCollectionInformationDAL { get; set; }

       public RentCollectionInformationBLL()
		{
            RentCollectionInformationDAL = new RentCollectionInformationDAL();
		}

       public int RentCollectionInformation_Add(RentCollectionInformationBOL _RentCollectionInformation)
       {
           try
           {
               return RentCollectionInformationDAL.Add(_RentCollectionInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int RentCollectionInformation_Update(RentCollectionInformationBOL _RentCollectionInformation)
       {
           try
           {
               return RentCollectionInformationDAL.Update(_RentCollectionInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int RentCollectionInformation_Delete(RentCollectionInformationBOL _RentCollectionInformation)
       {
           try
           {
               return RentCollectionInformationDAL.Delete(_RentCollectionInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public RentCollectionInformationBOL RentCollectionInformation_GetById(RentCollectionInformationBOL _RentCollectionInformation)
       {
           try
           {
               return RentCollectionInformationDAL.RentCollectionInformation_GetById(_RentCollectionInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable RentCollectionInformation_GetDataForGV()
       {
           try
           {
               return RentCollectionInformationDAL.RentCollectionInformation_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }

    }
}
