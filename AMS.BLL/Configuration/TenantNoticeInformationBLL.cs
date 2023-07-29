using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    TenantNoticeInformationBLL
    {
       public TenantNoticeInformationDAL TenantNoticeInformationDAL { get; set; }

       public TenantNoticeInformationBLL()
		{
            TenantNoticeInformationDAL = new TenantNoticeInformationDAL();
		}

       public int TenantNoticeInformation_Add(TenantNoticeInformationBOL _TenantNoticeInformation)
       {
           try
           {
               return TenantNoticeInformationDAL.Add(_TenantNoticeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int TenantNoticeInformation_Update(TenantNoticeInformationBOL _TenantNoticeInformation)
       {
           try
           {
               return TenantNoticeInformationDAL.Update(_TenantNoticeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int TenantNoticeInformation_Delete(TenantNoticeInformationBOL _TenantNoticeInformation)
       {
           try
           {
               return TenantNoticeInformationDAL.Delete(_TenantNoticeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public TenantNoticeInformationBOL TenantNoticeInformation_GetById(TenantNoticeInformationBOL _TenantNoticeInformation)
       {
           try
           {
               return TenantNoticeInformationDAL.TenantNoticeInformation_GetById(_TenantNoticeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable TenantNoticeInformation_GetDataForGV()
       {
           try
           {
               return TenantNoticeInformationDAL.TenantNoticeInformation_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }

    }
}
