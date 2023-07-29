using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    VisitorInformationBLL
    {
       public VisitorInformationDAL VisitorInformationDAL { get; set; }

       public VisitorInformationBLL()
		{
            VisitorInformationDAL = new VisitorInformationDAL();
		}

       public int VisitorInformation_Add(VisitorInformationBOL _VisitorInformation)
       {
           try
           {
               return VisitorInformationDAL.Add(_VisitorInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int VisitorInformation_Update(VisitorInformationBOL _VisitorInformation)
       {
           try
           {
               return VisitorInformationDAL.Update(_VisitorInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int VisitorInformation_Delete(VisitorInformationBOL _VisitorInformation)
       {
           try
           {
               return VisitorInformationDAL.Delete(_VisitorInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public VisitorInformationBOL VisitorInformation_GetById(VisitorInformationBOL _VisitorInformation)
       {
           try
           {
               return VisitorInformationDAL.VisitorInformation_GetById(_VisitorInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


       public int VisitorInformation_PresenceUpdate(VisitorInformationBOL _VisitorInformation)
       {
           try
           {
               return VisitorInformationDAL.VisitorInformation_PresenceUpdate(_VisitorInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int VisitorInformation_AbsenceUpdate(VisitorInformationBOL _VisitorInformation)
       {
           try
           {
               return VisitorInformationDAL.VisitorInformation_AbsenceUpdate(_VisitorInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       } 
       public DataTable VisitorInformation_GetDataForGV()
       {
           try
           {
               return VisitorInformationDAL.VisitorInformation_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }

    }
}
