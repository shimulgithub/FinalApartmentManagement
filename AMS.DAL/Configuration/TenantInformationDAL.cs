using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
  public  class TenantInformationDAL
    {

        public TenantInformationDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, TenantInformationBOL oTenantInformation)
        {
            oTenantInformation.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oTenantInformation.TenantName = Convert.ToString(oDbDataReader["TenantName"]);
            oTenantInformation.TenantFatherName = Convert.ToString(oDbDataReader["TenantFatherName"]);
           // oTenantInformation.TenantDOB = Convert.ToDateTime(oDbDataReader["TenantDOB"]);
            oTenantInformation.TenantDOBBind = Convert.ToString(oDbDataReader["TenantDOB"]);
            oTenantInformation.TenantMaritalStatus = Convert.ToInt32(oDbDataReader["TenantMaritalStatus"]);
            oTenantInformation.TenantPermanentAddress = Convert.ToString(oDbDataReader["TenantPermanentAddress"]);
           // oTenantInformation.TenantImage = Convert.ToString(oDbDataReader["TenantImage"]);
            oTenantInformation.Religion = Convert.ToInt32(oDbDataReader["Religion"]);
            oTenantInformation.AdvancRent = Convert.ToInt32(oDbDataReader["AdvancRent"]);
            oTenantInformation.TenantContactNo = Convert.ToString(oDbDataReader["TenantContactNo"]);
            oTenantInformation.TenantNID = Convert.ToString(oDbDataReader["TenantNID"]);
            oTenantInformation.Email = Convert.ToString(oDbDataReader["Email"]);
            oTenantInformation.PresentAddress = Convert.ToString(oDbDataReader["PresentAddress"]);
            oTenantInformation.FloorNo = Convert.ToInt32(oDbDataReader["FloorNo"]);
            oTenantInformation.RentPerMonth = Convert.ToInt32(oDbDataReader["RentPerMonth"]);
            oTenantInformation.TenantOccupation = Convert.ToString(oDbDataReader["TenantOccupation"]);
            oTenantInformation.TenantEducation = Convert.ToString(oDbDataReader["TenantEducation"]);
            oTenantInformation.EmargencyContactPerson = Convert.ToString(oDbDataReader["EmargencyContactPerson"]);
            oTenantInformation.EmargencyContactPersonNo = Convert.ToString(oDbDataReader["EmargencyContactPersonNo"]);
            oTenantInformation.OccupationAddress = Convert.ToString(oDbDataReader["OccupationAddress"]);
            oTenantInformation.UnitNo = Convert.ToInt32(oDbDataReader["UnitNo"]);
            oTenantInformation.IssueDateBind = Convert.ToString(oDbDataReader["IssueDate"]);

            
            oTenantInformation.HouseWorkerName = Convert.ToString(oDbDataReader["HouseWorkerName"]);
            oTenantInformation.HouseWorkerContactNo = Convert.ToString(oDbDataReader["HouseWorkerContactNo"]);
            oTenantInformation.HouseWorkerNID = Convert.ToString(oDbDataReader["HouseWorkerNID"]);
            oTenantInformation.HoseWorkerAddress = Convert.ToString(oDbDataReader["HoseWorkerAddress"]);
            oTenantInformation.DriverName = Convert.ToString(oDbDataReader["DriverName"]);
            oTenantInformation.DriverContactNo = Convert.ToString(oDbDataReader["DriverContactNo"]);
            oTenantInformation.DriverNID = Convert.ToString(oDbDataReader["DriverNID"]);
            oTenantInformation.DriverAddress = Convert.ToString(oDbDataReader["DriverAddress"]);
            oTenantInformation.PreviousHouseName = Convert.ToString(oDbDataReader["PreviousHouseName"]);
            oTenantInformation.PreviousHouseOwnerAddress = Convert.ToString(oDbDataReader["PreviousHouseOwnerAddress"]);
            oTenantInformation.PreviousHouseOwnerNo = Convert.ToString(oDbDataReader["PreviousHouseOwnerNo"]);
            oTenantInformation.IsActive = Convert.ToBoolean(oDbDataReader["IsActive"]);
        }

        private static void BuildEntityleaveDetails(DbDataReader oDbDataReader, TenantInformationBOL oTenantInformation)
        {
            //oTenantInformation.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            //oTenantInformation.LeaveMasterAutoId = Convert.ToInt32(oDbDataReader["LeaveMasterAutoId"]);
            //oTenantInformation.AsssignmentRef = Convert.ToString(oDbDataReader["AsssignmentRef"]);
            //oTenantInformation.AllowancesStartDateBind = Convert.ToString(oDbDataReader["StartDate"]);
            //oTenantInformation.StartTime = Convert.ToString(oDbDataReader["StartTime"]);
            //oTenantInformation.AllowancesEndDateBind = Convert.ToString(oDbDataReader["EndDate"]);
            //oTenantInformation.EndTime = Convert.ToString(oDbDataReader["EndTime"]);
            //oTenantInformation.Taken = Convert.ToString(oDbDataReader["Taken"]);
            //oTenantInformation.Remaining = Convert.ToString(oDbDataReader["Remaining"]);
            //oTenantInformation.CommentsTypeID = Convert.ToString(oDbDataReader["CommentTypeID"]);
            //oTenantInformation.Comments = Convert.ToString(oDbDataReader["Detail_Comments"]);


        }

        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(TenantInformationBOL oTenantInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_TenantInformationInsertRow", CommandType.StoredProcedure);
                //AddParameter(oDbCommand, "@AutoID", DbType.String, oTenantInformation.AutoID);
                AddParameter(oDbCommand, "@TenantName", DbType.String, oTenantInformation.TenantName);
                AddParameter(oDbCommand, "@TenantFatherName", DbType.String, oTenantInformation.TenantFatherName);
                AddParameter(oDbCommand, "@TenantDOB", DbType.String, oTenantInformation.TenantDOB);
                AddParameter(oDbCommand, "@TenantMaritalStatus", DbType.String, oTenantInformation.TenantMaritalStatus);
                AddParameter(oDbCommand, "@TenantPermanentAddress", DbType.String, oTenantInformation.TenantPermanentAddress);
               // AddParameter(oDbCommand, "@TenantImage", DbType.String, oTenantInformation.TenantImage);

                AddParameter(oDbCommand, "@Religion", DbType.String, oTenantInformation.Religion);
                AddParameter(oDbCommand, "@AdvancRent", DbType.String, oTenantInformation.AdvancRent);
                AddParameter(oDbCommand, "@TenantContactNo", DbType.String, oTenantInformation.TenantContactNo);
                AddParameter(oDbCommand, "@TenantNID", DbType.String, oTenantInformation.TenantNID);
                AddParameter(oDbCommand, "@Email", DbType.String, oTenantInformation.Email);
                AddParameter(oDbCommand, "@PresentAddress", DbType.String, oTenantInformation.PresentAddress);
                AddParameter(oDbCommand, "@FloorNo", DbType.String, oTenantInformation.FloorNo);
                AddParameter(oDbCommand, "@RentPerMonth", DbType.String, oTenantInformation.RentPerMonth);
                AddParameter(oDbCommand, "@TenantOccupation", DbType.String, oTenantInformation.TenantOccupation);
                AddParameter(oDbCommand, "@TenantEducation", DbType.String, oTenantInformation.TenantEducation);
                AddParameter(oDbCommand, "@EmargencyContactPerson", DbType.String, oTenantInformation.EmargencyContactPerson);
                AddParameter(oDbCommand, "@EmargencyContactPersonNo", DbType.String, oTenantInformation.EmargencyContactPersonNo);
                AddParameter(oDbCommand, "@OccupationAddress", DbType.String, oTenantInformation.OccupationAddress);
                AddParameter(oDbCommand, "@UnitNo", DbType.String, oTenantInformation.UnitNo);
                AddParameter(oDbCommand, "@IssueDate", DbType.String, oTenantInformation.IssueDate);
                AddParameter(oDbCommand, "@HouseWorkerName", DbType.String, oTenantInformation.HouseWorkerName);
                AddParameter(oDbCommand, "@HouseWorkerContactNo", DbType.String, oTenantInformation.HouseWorkerContactNo);
                AddParameter(oDbCommand, "@HouseWorkerNID", DbType.String, oTenantInformation.HouseWorkerNID);
                AddParameter(oDbCommand, "@HoseWorkerAddress", DbType.String, oTenantInformation.HoseWorkerAddress);
                AddParameter(oDbCommand, "@DriverName", DbType.String, oTenantInformation.DriverName);
                AddParameter(oDbCommand, "@DriverContactNo", DbType.String, oTenantInformation.DriverContactNo);
                AddParameter(oDbCommand, "@DriverNID", DbType.String, oTenantInformation.DriverNID);
                AddParameter(oDbCommand, "@DriverAddress", DbType.String, oTenantInformation.DriverAddress);
                AddParameter(oDbCommand, "@PreviousHouseName", DbType.String, oTenantInformation.PreviousHouseName);
                AddParameter(oDbCommand, "@PreviousHouseOwnerAddress", DbType.String, oTenantInformation.PreviousHouseOwnerAddress);
                AddParameter(oDbCommand, "@PreviousHouseOwnerNo", DbType.String, oTenantInformation.PreviousHouseOwnerNo);
               

                if (oTenantInformation.IsActive.HasValue)
                { AddParameter(oDbCommand, "@IsActive", DbType.Boolean, oTenantInformation.IsActive); }
                else { AddParameter(oDbCommand, "@IsActive", DbType.Boolean, DBNull.Value); }
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(TenantInformationBOL oTenantInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_TenantInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, oTenantInformation.AutoID);
                AddParameter(oDbCommand, "@TenantName", DbType.String, oTenantInformation.TenantName);
                AddParameter(oDbCommand, "@TenantFatherName", DbType.String, oTenantInformation.TenantFatherName);
                AddParameter(oDbCommand, "@TenantDOB", DbType.String, oTenantInformation.TenantDOB);
                AddParameter(oDbCommand, "@TenantMaritalStatus", DbType.Int32, oTenantInformation.TenantMaritalStatus);
                AddParameter(oDbCommand, "@TenantPermanentAddress", DbType.String, oTenantInformation.TenantPermanentAddress);
                // AddParameter(oDbCommand, "@TenantImage", DbType.String, oTenantInformation.TenantImage);

                AddParameter(oDbCommand, "@Religion", DbType.String, oTenantInformation.Religion);
                AddParameter(oDbCommand, "@AdvancRent", DbType.String, oTenantInformation.AdvancRent);
                AddParameter(oDbCommand, "@TenantContactNo", DbType.String, oTenantInformation.TenantContactNo);
                AddParameter(oDbCommand, "@TenantNID", DbType.String, oTenantInformation.TenantNID);
                AddParameter(oDbCommand, "@Email", DbType.String, oTenantInformation.Email);
                AddParameter(oDbCommand, "@PresentAddress", DbType.String, oTenantInformation.PresentAddress);
                AddParameter(oDbCommand, "@FloorNo", DbType.Int32, oTenantInformation.FloorNo);
                AddParameter(oDbCommand, "@RentPerMonth", DbType.String, oTenantInformation.RentPerMonth);
                AddParameter(oDbCommand, "@TenantOccupation", DbType.String, oTenantInformation.TenantOccupation);
                AddParameter(oDbCommand, "@TenantEducation", DbType.String, oTenantInformation.TenantEducation);
                AddParameter(oDbCommand, "@EmargencyContactPerson", DbType.String, oTenantInformation.EmargencyContactPerson);
                AddParameter(oDbCommand, "@EmargencyContactPersonNo", DbType.String, oTenantInformation.EmargencyContactPersonNo);
                AddParameter(oDbCommand, "@OccupationAddress", DbType.String, oTenantInformation.OccupationAddress);
                AddParameter(oDbCommand, "@UnitNo", DbType.String, oTenantInformation.UnitNo);
                AddParameter(oDbCommand, "@IssueDate", DbType.String, oTenantInformation.IssueDate);
                AddParameter(oDbCommand, "@HouseWorkerName", DbType.String, oTenantInformation.HouseWorkerName);
                AddParameter(oDbCommand, "@HouseWorkerContactNo", DbType.String, oTenantInformation.HouseWorkerContactNo);
                AddParameter(oDbCommand, "@HouseWorkerNID", DbType.String, oTenantInformation.HouseWorkerNID);
                AddParameter(oDbCommand, "@HoseWorkerAddress", DbType.String, oTenantInformation.HoseWorkerAddress);
                AddParameter(oDbCommand, "@DriverName", DbType.String, oTenantInformation.DriverName);
                AddParameter(oDbCommand, "@DriverContactNo", DbType.String, oTenantInformation.DriverContactNo);
                AddParameter(oDbCommand, "@DriverNID", DbType.String, oTenantInformation.DriverNID);
                AddParameter(oDbCommand, "@DriverAddress", DbType.String, oTenantInformation.DriverAddress);
                AddParameter(oDbCommand, "@PreviousHouseName", DbType.String, oTenantInformation.PreviousHouseName);
                AddParameter(oDbCommand, "@PreviousHouseOwnerAddress", DbType.String, oTenantInformation.PreviousHouseOwnerAddress);
                AddParameter(oDbCommand, "@PreviousHouseOwnerNo", DbType.String, oTenantInformation.PreviousHouseOwnerNo);


                if (oTenantInformation.IsActive.HasValue)
                { AddParameter(oDbCommand, "@IsActive", DbType.Boolean, oTenantInformation.IsActive); }
                else { AddParameter(oDbCommand, "@IsActive", DbType.Boolean, DBNull.Value); }
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Add_Audit(TenantInformationBOL oTenantInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TBoTenantInformationAuditInsertRow", CommandType.StoredProcedure);
                //AddParameter(oDbCommand, "@AssignmentRef", DbType.String, oTenantInformation.AssignmentRef);
                //AddParameter(oDbCommand, "@LeaveYear", DbType.String, oTenantInformation.LeaveYear);
                //AddParameter(oDbCommand, "@LeaveType", DbType.String, oTenantInformation.LeaveType);
                //AddParameter(oDbCommand, "@AllowancesStartDate", DbType.Date, oTenantInformation.AllowancesStartDate);
                //AddParameter(oDbCommand, "@AllowancesEndDate", DbType.Date, oTenantInformation.AllowancesEndDate);
                //AddParameter(oDbCommand, "@Allowances", DbType.String, oTenantInformation.Allowances);
                //AddParameter(oDbCommand, "@CreateBy", DbType.String, oTenantInformation.CreateBy);
                //AddParameter(oDbCommand, "@Units", DbType.String, oTenantInformation.Units);
                //AddParameter(oDbCommand, "@Comments", DbType.String, oTenantInformation.Comments);
                //AddParameter(oDbCommand, "@UserId", DbType.String, oTenantInformation.UserId);
                //AddParameter(oDbCommand, "@PageId", DbType.String, oTenantInformation.PageId);
                //AddParameter(oDbCommand, "@Re_Id", DbType.String, oTenantInformation.Ref_Id);
                //AddParameter(oDbCommand, "@TranStatus", DbType.String, oTenantInformation.TranStatus);
                //AddParameter(oDbCommand, "@ChangedBy", DbType.String, oTenantInformation.ChangedBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public int LeaveEntryAdd(TenantInformationBOL oTenantInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TBoTenantInformationDetailsInsertRow", CommandType.StoredProcedure);

                //AddParameter(oDbCommand, "@AsssignmentRef", DbType.String, oTenantInformation.AssignmentRef);
                //AddParameter(oDbCommand, "@LeaveMasterAutoId", DbType.Int32, oTenantInformation.LeaveMasterAutoId);
                //AddParameter(oDbCommand, "@StartDate", DbType.Date, oTenantInformation.StartDate);
                //AddParameter(oDbCommand, "@StartTime", DbType.String, oTenantInformation.StartTime);
                //AddParameter(oDbCommand, "@EndDate", DbType.Date, oTenantInformation.EndDate);
                //AddParameter(oDbCommand, "@EndTime", DbType.String, oTenantInformation.EndTime);
                //AddParameter(oDbCommand, "@Taken", DbType.String, oTenantInformation.Taken);
                //AddParameter(oDbCommand, "@CreateBy", DbType.String, oTenantInformation.CreateBy);
                //AddParameter(oDbCommand, "@CommentTypeID", DbType.String, oTenantInformation.CommentsTypeID);
                //AddParameter(oDbCommand, "@Comments", DbType.String, oTenantInformation.Comments);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int LeaveEntryAdd_Audit(TenantInformationBOL oTenantInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TBoTenantInformationDetailsAuditInsertRow", CommandType.StoredProcedure);

                //AddParameter(oDbCommand, "@AsssignmentRef", DbType.String, oTenantInformation.AssignmentRef);
                //AddParameter(oDbCommand, "@LeaveMasterAutoId", DbType.Int32, oTenantInformation.LeaveMasterAutoId);
                //AddParameter(oDbCommand, "@StartDate", DbType.Date, oTenantInformation.StartDate);
                //AddParameter(oDbCommand, "@StartTime", DbType.String, oTenantInformation.StartTime);
                //AddParameter(oDbCommand, "@EndDate", DbType.Date, oTenantInformation.EndDate);
                //AddParameter(oDbCommand, "@EndTime", DbType.String, oTenantInformation.EndTime);
                //AddParameter(oDbCommand, "@Taken", DbType.String, oTenantInformation.Taken);
                //AddParameter(oDbCommand, "@CreateBy", DbType.String, oTenantInformation.CreateBy);
                //AddParameter(oDbCommand, "@CommentTypeID", DbType.String, oTenantInformation.CommentsTypeID);
                //AddParameter(oDbCommand, "@Comments", DbType.String, oTenantInformation.Comments);
                //AddParameter(oDbCommand, "@UserId", DbType.String, oTenantInformation.UserId);
                //AddParameter(oDbCommand, "@PageId", DbType.String, oTenantInformation.PageId);
                //AddParameter(oDbCommand, "@Re_Id", DbType.String, oTenantInformation.Ref_Id);
                //AddParameter(oDbCommand, "@TranStatus", DbType.String, oTenantInformation.TranStatus);
                //AddParameter(oDbCommand, "@ChangedBy", DbType.String, oTenantInformation.ChangedBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int LeaveDetailsUpdate(TenantInformationBOL oTenantInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TBoTenantInformationDetailsUpdateRow", CommandType.StoredProcedure);
                //AddParameter(oDbCommand, "@AutoID", DbType.String, oTenantInformation.AutoID);
                //AddParameter(oDbCommand, "@AsssignmentRef", DbType.String, oTenantInformation.AssignmentRef);
                //AddParameter(oDbCommand, "@LeaveMasterAutoId", DbType.Int32, oTenantInformation.LeaveMasterAutoId);
                //AddParameter(oDbCommand, "@StartDate", DbType.Date, oTenantInformation.StartDate);
                //AddParameter(oDbCommand, "@StartTime", DbType.String, oTenantInformation.StartTime);
                //AddParameter(oDbCommand, "@EndDate", DbType.Date, oTenantInformation.EndDate);
                //AddParameter(oDbCommand, "@EndTime", DbType.String, oTenantInformation.EndTime);
                //AddParameter(oDbCommand, "@Taken", DbType.String, oTenantInformation.Taken);
                //AddParameter(oDbCommand, "@ChangedBy", DbType.String, oTenantInformation.ChangedBy);
                //AddParameter(oDbCommand, "@CommentTypeID", DbType.String, oTenantInformation.CommentsTypeID);
                //AddParameter(oDbCommand, "@Comments", DbType.String, oTenantInformation.Comments);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int Delete(TenantInformationBOL _TenantInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_TenantInformation_DeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _TenantInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable TenantInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_TenantInformationList", CommandType.StoredProcedure);
                //oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@AssignmentRef", DbType.String, AssignmentRef));
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dtUser.Load(oDbDataReader);
                oDbDataReader.Close();
                return dtUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                dtUser.Dispose();
                oDbDataReader.Dispose();
            }
        }



        public TenantInformationBOL TenantInformation_GetById(TenantInformationBOL oTenantInformation)
        {
            try
            {
                TenantInformationBOL oLeaveType = new TenantInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_TenantInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, oTenantInformation.AutoID);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oLeaveType);
                }
                oDbDataReader.Close();
                return oLeaveType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable LeaveHolidaysDetailList_GetDataForGV(string LeaveCode, string AssignmentRef)
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TBoTenantInformationDetailsList", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LeaveCode", DbType.String, LeaveCode));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@AsssignmentRef", DbType.String, AssignmentRef));
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dtUser.Load(oDbDataReader);
                oDbDataReader.Close();
                return dtUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                dtUser.Dispose();
                oDbDataReader.Dispose();
            }
        }

        public TenantInformationBOL LeaveHolidaysDetails_GetById(TenantInformationBOL oTenantInformation)
        {
            try
            {
                TenantInformationBOL oLeaveType = new TenantInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TBoTenantInformationListDetailsByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, oTenantInformation.AutoID);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntityleaveDetails(oDbDataReader, oLeaveType);
                }
                oDbDataReader.Close();
                return oLeaveType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public int LeaveDetailsDelete(TenantInformationBOL _LeaveHoliday)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TBoTenantInformationDetailsDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _LeaveHoliday.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
