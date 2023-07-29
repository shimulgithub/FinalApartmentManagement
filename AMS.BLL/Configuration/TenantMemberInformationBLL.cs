using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
    public class TenantMemberInformationBLL
    {
        public TenantMemberInformationDAL TenantMemberInformationDAL { get; set; }

        public TenantMemberInformationBLL()
        {
            TenantMemberInformationDAL = new TenantMemberInformationDAL();
        }


        public int TenantMemberInformation_Add(TenantMemberInformationBOL _TenantMemberInformation)
        {
            try
            {
                return TenantMemberInformationDAL.Add(_TenantMemberInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int TenantMemberInformation_Update(TenantMemberInformationBOL _TenantMemberInformation)
        {
            try
            {
                return TenantMemberInformationDAL.Update(_TenantMemberInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable TenantMemberInformation_GetDataForGV(string TenantID)
        {
            try
            {
                return TenantMemberInformationDAL.GetDataForGV(TenantID);
            }
            catch
            {
                return null;
            }
        }

        public int TenantMemberInformation_Delete(TenantMemberInformationBOL _TenantMemberInformation)
        {
            try
            {
                return TenantMemberInformationDAL.Delete(_TenantMemberInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TenantMemberInformationBOL TenantMemberInformation_GetById(TenantMemberInformationBOL _TenantMemberInformation)
        {
            try
            {
                return TenantMemberInformationDAL.GetById(_TenantMemberInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
  
    }
}
