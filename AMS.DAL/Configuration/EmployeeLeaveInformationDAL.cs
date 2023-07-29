using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    EmployeeLeaveInformationDAL
    {
        public EmployeeLeaveInformationDAL()
		{
			DbProviderHelper.GetConnection();
		}
      
        private static void BuildEntity(DbDataReader oDbDataReader, EmployeeLeaveInformationBOL oEmployeeLeaveInformationBOL)
		{
            oEmployeeLeaveInformationBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oEmployeeLeaveInformationBOL.EmployeeID = Convert.ToString(oDbDataReader["EmployeeID"]);
            oEmployeeLeaveInformationBOL.DesignationID = Convert.ToString(oDbDataReader["DesignationID"]);
            oEmployeeLeaveInformationBOL.LeaveTypeID = Convert.ToString(oDbDataReader["LeaveTypeID"]);
            oEmployeeLeaveInformationBOL.LeaveStartDateBind = Convert.ToString(oDbDataReader["LeaveStartDate"]);
            oEmployeeLeaveInformationBOL.LeaveEndDateBind = Convert.ToString(oDbDataReader["LeaveEndDate"]);
            oEmployeeLeaveInformationBOL.LeaveStartTime = Convert.ToString(oDbDataReader["LeaveStartTime"]);
            oEmployeeLeaveInformationBOL.LeaveEndTime = Convert.ToString(oDbDataReader["LeaveEndTime"]);		

				 
		}
      
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(EmployeeLeaveInformationBOL _EmployeeLeaveInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeLeaveInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@EmployeeID", DbType.String, _EmployeeLeaveInformation.EmployeeID);
                AddParameter(oDbCommand, "@DesignationID", DbType.String, _EmployeeLeaveInformation.DesignationID);
                AddParameter(oDbCommand, "@LeaveTypeID", DbType.String, _EmployeeLeaveInformation.LeaveTypeID);
                AddParameter(oDbCommand, "@LeaveStartDate", DbType.DateTime, _EmployeeLeaveInformation.LeaveStartDate);
                AddParameter(oDbCommand, "@LeaveEndDate", DbType.DateTime, _EmployeeLeaveInformation.LeaveEndDate);
                AddParameter(oDbCommand, "@LeaveStartTime", DbType.String, _EmployeeLeaveInformation.LeaveStartTime);
                AddParameter(oDbCommand, "@LeaveEndTime", DbType.String, _EmployeeLeaveInformation.LeaveEndTime);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _EmployeeLeaveInformation.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(EmployeeLeaveInformationBOL _EmployeeLeaveInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeLeaveInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeLeaveInformation.AutoID);
                AddParameter(oDbCommand, "@EmployeeID", DbType.String, _EmployeeLeaveInformation.EmployeeID);
                AddParameter(oDbCommand, "@DesignationID", DbType.String, _EmployeeLeaveInformation.DesignationID);
                AddParameter(oDbCommand, "@LeaveTypeID", DbType.String, _EmployeeLeaveInformation.LeaveTypeID);
                AddParameter(oDbCommand, "@LeaveStartDate", DbType.DateTime, _EmployeeLeaveInformation.LeaveStartDate);
                AddParameter(oDbCommand, "@LeaveEndDate", DbType.DateTime, _EmployeeLeaveInformation.LeaveEndDate);
                AddParameter(oDbCommand, "@LeaveStartTime", DbType.String, _EmployeeLeaveInformation.LeaveStartTime);
                AddParameter(oDbCommand, "@LeaveEndTime", DbType.String, _EmployeeLeaveInformation.LeaveEndTime);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _EmployeeLeaveInformation.ChangedBy);
                
           

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateForCancel(EmployeeLeaveInformationBOL _EmployeeLeaveInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeLeaveInformationUpdateRowForCancel", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeLeaveInformation.AutoID);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _EmployeeLeaveInformation.ChangedBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateByParam(EmployeeLeaveInformationBOL _EmployeeLeaveInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeLeaveInformationUpdateRowByParam", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeLeaveInformation.AutoID);
                AddParameter(oDbCommand, "@LeaveStartDate", DbType.DateTime, _EmployeeLeaveInformation.LeaveStartDate);
                AddParameter(oDbCommand, "@LeaveEndDate", DbType.DateTime, _EmployeeLeaveInformation.LeaveEndDate);
                AddParameter(oDbCommand, "@LeaveStartTime", DbType.String, _EmployeeLeaveInformation.LeaveStartTime);
                AddParameter(oDbCommand, "@LeaveEndTime", DbType.String, _EmployeeLeaveInformation.LeaveEndTime);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _EmployeeLeaveInformation.ChangedBy);



                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(EmployeeLeaveInformationBOL _EmployeeLeaveInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeLeaveInformationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeLeaveInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable EmployeeLeaveInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeLeaveInformationList", CommandType.StoredProcedure);
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

        public EmployeeLeaveInformationBOL EmployeeLeaveInformation_GetById(EmployeeLeaveInformationBOL _EmployeeLeaveInformation)
        {
            try
            {
                EmployeeLeaveInformationBOL oLeaveType = new EmployeeLeaveInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeLeaveInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeLeaveInformation.AutoID);
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


    }
}
