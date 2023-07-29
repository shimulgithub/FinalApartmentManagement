using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;
using AMS.DAL.Configuration;

namespace AMS.BLL.Configuration
{
    public class TenantInformationBLL
    {
        public TenantInformationDAL TenantInformationDAL { get; set; }
        public TenantInformationBLL()
        {
            TenantInformationDAL = new TenantInformationDAL();
        }

        public int TenantInformation_Add(TenantInformationBOL _TenantInformation)
        {
            try
            {
                return TenantInformationDAL.Add(_TenantInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int LeaveHolidays_Add_Audit(TenantInformationBOL _LeaveHolidays)
        {
            try
            {
                return TenantInformationDAL.Add_Audit(_LeaveHolidays);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int LeaveHolidaysLeaveEntry_Add(TenantInformationBOL _LeaveHolidays)
        {
            try
            {
                return TenantInformationDAL.LeaveEntryAdd(_LeaveHolidays);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int LeaveHolidaysLeaveEntry_Add_Audit(TenantInformationBOL _LeaveHolidays)
        {
            try
            {
                return TenantInformationDAL.LeaveEntryAdd_Audit(_LeaveHolidays);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int TenantInformation_Update(TenantInformationBOL _TenantInformationBOL)
        {
            try
            {
                return TenantInformationDAL.Update(_TenantInformationBOL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int TenantInformation_Delete(TenantInformationBOL _TenantInformationBOL)
        {
            try
            {
                return TenantInformationDAL.Delete(_TenantInformationBOL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TenantInformationBOL TenantInformation_GetById(TenantInformationBOL _TenantInformationBOL)
        {
            try
            {
                return TenantInformationDAL.TenantInformation_GetById(_TenantInformationBOL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable TenantInformation__GetDataForGV()
        {
            try
            {
                return TenantInformationDAL.TenantInformation_GetDataForGV();
            }
            catch
            {
                return null;
            }
        }
        public DataTable LeaveHolidaysDetailslist__GetDataForGV(string LeaveCode, string AssignmentRef)
        {
            try
            {
                return TenantInformationDAL.LeaveHolidaysDetailList_GetDataForGV(LeaveCode, AssignmentRef);
            }
            catch
            {
                return null;
            }
        }
        public TenantInformationBOL LeaveHolidaysDetails_GetById(TenantInformationBOL _TenantInformationBOL)
        {
            try
            {
                return TenantInformationDAL.LeaveHolidaysDetails_GetById(_TenantInformationBOL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int LeaveHolidaysDetails_Update(TenantInformationBOL _TenantInformationBOL)
        {
            try
            {
                return TenantInformationDAL.LeaveDetailsUpdate(_TenantInformationBOL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int LeaveHolidaysDetails_Delete(TenantInformationBOL _TenantInformationBOL)
        {
            try
            {
                return TenantInformationDAL.LeaveDetailsDelete(_TenantInformationBOL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
