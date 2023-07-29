using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    OwnerNoticeInformationBLL
    {
       public OwnerNoticeInformationDAL OwnerNoticeInformationDAL { get; set; }

       public OwnerNoticeInformationBLL()
		{
            OwnerNoticeInformationDAL = new OwnerNoticeInformationDAL();
		}

       public int OwnerNoticeInformation_Add(OwnerNoticeInformationBOL _OwnerNoticeInformation)
       {
           try
           {
               return OwnerNoticeInformationDAL.Add(_OwnerNoticeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int OwnerNoticeInformation_Update(OwnerNoticeInformationBOL _OwnerNoticeInformation)
       {
           try
           {
               return OwnerNoticeInformationDAL.Update(_OwnerNoticeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int OwnerNoticeInformation_Delete(OwnerNoticeInformationBOL _OwnerNoticeInformation)
       {
           try
           {
               return OwnerNoticeInformationDAL.Delete(_OwnerNoticeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public OwnerNoticeInformationBOL OwnerNoticeInformation_GetById(OwnerNoticeInformationBOL _OwnerNoticeInformation)
       {
           try
           {
               return OwnerNoticeInformationDAL.OwnerNoticeInformation_GetById(_OwnerNoticeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable OwnerNoticeInformation_GetDataForGV()
       {
           try
           {
               return OwnerNoticeInformationDAL.OwnerNoticeInformation_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }

    }
}
