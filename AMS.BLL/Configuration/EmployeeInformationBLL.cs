using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    EmployeeInformationBLL
    {
       public EmployeeInformationDAL EmployeeInformationDAL { get; set; }

       public EmployeeInformationBLL()
		{
            EmployeeInformationDAL = new EmployeeInformationDAL();
		}

       public int EmployeeInformation_Add(EmployeeInformationBOL _EmployeeInformation)
       {
           try
           {
               return EmployeeInformationDAL.Add(_EmployeeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int EmployeeInformation_Update(EmployeeInformationBOL _EmployeeInformation)
       {
           try
           {
               return EmployeeInformationDAL.Update(_EmployeeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int EmployeeInformation_Delete(EmployeeInformationBOL _EmployeeInformation)
       {
           try
           {
               return EmployeeInformationDAL.Delete(_EmployeeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public EmployeeInformationBOL EmployeeInformation_GetById(EmployeeInformationBOL _EmployeeInformation)
       {
           try
           {
               return EmployeeInformationDAL.EmployeeInformation_GetById(_EmployeeInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable EmployeeInformation_GetDataForGV()
       {
           try
           {
               return EmployeeInformationDAL.EmployeeInformation_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }

    }
}
