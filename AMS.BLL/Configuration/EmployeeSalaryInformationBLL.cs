using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    EmployeeSalaryInformationBLL
    {
       public EmployeeSalaryInformationDAL EmployeeSalaryInformationDAL { get; set; }

       public EmployeeSalaryInformationBLL()
		{
            EmployeeSalaryInformationDAL = new EmployeeSalaryInformationDAL();
		}

       public int EmployeeSalaryInformation_Add(EmployeeSalaryInformationBOL _EmployeeSalaryInformation)
       {
           try
           {
               return EmployeeSalaryInformationDAL.Add(_EmployeeSalaryInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int EmployeeSalaryInformation_Update(EmployeeSalaryInformationBOL _EmployeeSalaryInformation)
       {
           try
           {
               return EmployeeSalaryInformationDAL.Update(_EmployeeSalaryInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int EmployeeSalaryInformation_Delete(EmployeeSalaryInformationBOL _EmployeeSalaryInformation)
       {
           try
           {
               return EmployeeSalaryInformationDAL.Delete(_EmployeeSalaryInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public EmployeeSalaryInformationBOL EmployeeSalaryInformation_GetById(EmployeeSalaryInformationBOL _EmployeeSalaryInformation)
       {
           try
           {
               return EmployeeSalaryInformationDAL.EmployeeSalaryInformation_GetById(_EmployeeSalaryInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable EmployeeSalaryInformation_GetDataForGV()
       {
           try
           {
               return EmployeeSalaryInformationDAL.EmployeeSalaryInformation_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }

    }
}
