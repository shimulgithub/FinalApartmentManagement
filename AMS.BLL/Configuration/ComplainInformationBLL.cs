using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    ComplainInformationBLL
    {
       public ComplainInformationDAL ComplainInformationDAL { get; set; }

       public ComplainInformationBLL()
		{
            ComplainInformationDAL = new ComplainInformationDAL();
		}

       public int ComplainInformation_Add(ComplainInformationBOL _ComplainInformation)
       {
           try
           {
               return ComplainInformationDAL.Add(_ComplainInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int ComplainInformation_Update(ComplainInformationBOL _ComplainInformation)
       {
           try
           {
               return ComplainInformationDAL.Update(_ComplainInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int ComplainInformation_Delete(ComplainInformationBOL _ComplainInformation)
       {
           try
           {
               return ComplainInformationDAL.Delete(_ComplainInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public ComplainInformationBOL ComplainInformation_GetById(ComplainInformationBOL _ComplainInformation)
       {
           try
           {
               return ComplainInformationDAL.ComplainInformation_GetById(_ComplainInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable ComplainInformation_GetDataForGV()
       {
           try
           {
               return ComplainInformationDAL.ComplainInformation_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }

    }
}
