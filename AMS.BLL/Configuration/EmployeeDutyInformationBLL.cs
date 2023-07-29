using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    EmployeeDutyInformationBLL
    {
       public EmployeeDutyInformationDAL EmployeeDutyInformationDAL { get; set; }

       public EmployeeDutyInformationBLL()
		{
            EmployeeDutyInformationDAL = new EmployeeDutyInformationDAL();
		}

       public int EmployeeDutyInformation_Add(EmployeeDutyInformationBOL _EmployeeDutyInformation)
       {
           try
           {
               return EmployeeDutyInformationDAL.Add(_EmployeeDutyInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int EmployeeDutyInformation_Update(EmployeeDutyInformationBOL _EmployeeDutyInformation)
       {
           try
           {
               return EmployeeDutyInformationDAL.Update(_EmployeeDutyInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int EmployeeDutyInformation_Delete(EmployeeDutyInformationBOL _EmployeeDutyInformation)
       {
           try
           {
               return EmployeeDutyInformationDAL.Delete(_EmployeeDutyInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public EmployeeDutyInformationBOL EmployeeDutyInformation_GetById(EmployeeDutyInformationBOL _EmployeeDutyInformation)
       {
           try
           {
               return EmployeeDutyInformationDAL.EmployeeDutyInformation_GetById(_EmployeeDutyInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable EmployeeDutyInformation_GetDataForGV()
       {
           try
           {
               return EmployeeDutyInformationDAL.EmployeeDutyInformation_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }

    }
}
