using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    EmployeeLeaveInformationBLL
    {
       public EmployeeLeaveInformationDAL EmployeeLeaveInformationDAL { get; set; }

       public EmployeeLeaveInformationBLL()
		{
            EmployeeLeaveInformationDAL = new EmployeeLeaveInformationDAL();
		}

       public int EmployeeLeaveInformation_Add(EmployeeLeaveInformationBOL _EmployeeLeaveInformation)
       {
           try
           {
               return EmployeeLeaveInformationDAL.Add(_EmployeeLeaveInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int EmployeeLeaveInformation_Update(EmployeeLeaveInformationBOL _EmployeeLeaveInformation)
       {
           try
           {
               return EmployeeLeaveInformationDAL.Update(_EmployeeLeaveInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int EmployeeLeaveInformation_UpdateByParam(EmployeeLeaveInformationBOL _EmployeeLeaveInformation)
       {
           try
           {
               return EmployeeLeaveInformationDAL.UpdateByParam(_EmployeeLeaveInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int EmployeeLeaveInformation_UpdateForCancel(EmployeeLeaveInformationBOL _EmployeeLeaveInformation)
       {
           try
           {
               return EmployeeLeaveInformationDAL.UpdateForCancel(_EmployeeLeaveInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int EmployeeLeaveInformation_Delete(EmployeeLeaveInformationBOL _EmployeeLeaveInformation)
       {
           try
           {
               return EmployeeLeaveInformationDAL.Delete(_EmployeeLeaveInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public EmployeeLeaveInformationBOL EmployeeLeaveInformation_GetById(EmployeeLeaveInformationBOL _EmployeeLeaveInformation)
       {
           try
           {
               return EmployeeLeaveInformationDAL.EmployeeLeaveInformation_GetById(_EmployeeLeaveInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable EmployeeLeaveInformation_GetDataForGV()
       {
           try
           {
               return EmployeeLeaveInformationDAL.EmployeeLeaveInformation_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }

    }
}
