using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
   public class    MeetingInformationBLL
    {
       public MeetingInformationDAL MeetingInformationDAL { get; set; }

       public MeetingInformationBLL()
		{
            MeetingInformationDAL = new MeetingInformationDAL();
		}

       public int MeetingInformation_Add(MeetingInformationBOL _MeetingInformation)
       {
           try
           {
               return MeetingInformationDAL.Add(_MeetingInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int MeetingInformation_Update(MeetingInformationBOL _MeetingInformation)
       {
           try
           {
               return MeetingInformationDAL.Update(_MeetingInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public int MeetingInformation_Delete(MeetingInformationBOL _MeetingInformation)
       {
           try
           {
               return MeetingInformationDAL.Delete(_MeetingInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public MeetingInformationBOL MeetingInformation_GetById(MeetingInformationBOL _MeetingInformation)
       {
           try
           {
               return MeetingInformationDAL.MeetingInformation_GetById(_MeetingInformation);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable MeetingInformation_GetDataForGV()
       {
           try
           {
               return MeetingInformationDAL.MeetingInformation_GetDataForGV();
           }
           catch
           {
               return null;
           }
       }

    }
}
