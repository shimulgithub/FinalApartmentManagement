using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    EmployeeNoticeInformationBLL
    {
       public EmployeeNoticeInformationDAL EmployeeNoticeInformationDAL { get; set; }

       public EmployeeNoticeInformationBLL()
		{
            EmployeeNoticeInformationDAL = new EmployeeNoticeInformationDAL();
		}

       public int EmployeeNoticeInformation_Add(EmployeeNoticeInformationBOL _EmployeeNoticeInformation)
       {
           try
           {
               return EmployeeNoticeInformationDAL.Add(_EmployeeNoticeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int EmployeeNoticeInformation_Update(EmployeeNoticeInformationBOL _EmployeeNoticeInformation)
       {
           try
           {
               return EmployeeNoticeInformationDAL.Update(_EmployeeNoticeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int EmployeeNoticeInformation_Delete(EmployeeNoticeInformationBOL _EmployeeNoticeInformation)
       {
           try
           {
               return EmployeeNoticeInformationDAL.Delete(_EmployeeNoticeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public EmployeeNoticeInformationBOL EmployeeNoticeInformation_GetById(EmployeeNoticeInformationBOL _EmployeeNoticeInformation)
       {
           try
           {
               return EmployeeNoticeInformationDAL.EmployeeNoticeInformation_GetById(_EmployeeNoticeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable EmployeeNoticeInformation_GetDataForGV()
       {
           try
           {
               return EmployeeNoticeInformationDAL.EmployeeNoticeInformation_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }

    }
}
