using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    EmployeeDutyInformationDAL
    {
        public EmployeeDutyInformationDAL()
		{
			DbProviderHelper.GetConnection();
		}
      
        private static void BuildEntity(DbDataReader oDbDataReader, EmployeeDutyInformationBOL oEmployeeDutyInformationBOL)
		{
            oEmployeeDutyInformationBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oEmployeeDutyInformationBOL.EmployeeID = Convert.ToString(oDbDataReader["EmployeeID"]);
            oEmployeeDutyInformationBOL.DesignationID = Convert.ToString(oDbDataReader["DesignationID"]);
            oEmployeeDutyInformationBOL.DutyStartDateBind = Convert.ToString(oDbDataReader["DutyStartDate"]);
            oEmployeeDutyInformationBOL.DutyEndDateBind = Convert.ToString(oDbDataReader["DutyEndDate"]);
            oEmployeeDutyInformationBOL.DutyStartTime = Convert.ToString(oDbDataReader["DutyStartTime"]);
            oEmployeeDutyInformationBOL.DutyEndTime = Convert.ToString(oDbDataReader["DutyEndTime"]);
		}
      
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(EmployeeDutyInformationBOL _EmployeeDutyInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeDutyInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@EmployeeID", DbType.String, _EmployeeDutyInformation.EmployeeID);
                AddParameter(oDbCommand, "@DesignationID", DbType.String, _EmployeeDutyInformation.DesignationID);
                AddParameter(oDbCommand, "@DutyStartDate", DbType.DateTime, _EmployeeDutyInformation.DutyStartDate);
                AddParameter(oDbCommand, "@DutyEndDate", DbType.DateTime, _EmployeeDutyInformation.DutyEndDate);
                AddParameter(oDbCommand, "@DutyStartTime", DbType.String, _EmployeeDutyInformation.DutyStartTime);
                AddParameter(oDbCommand, "@DutyEndTime", DbType.String, _EmployeeDutyInformation.DutyEndTime);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _EmployeeDutyInformation.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(EmployeeDutyInformationBOL _EmployeeDutyInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeDutyInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeDutyInformation.AutoID);
                AddParameter(oDbCommand, "@EmployeeID", DbType.String, _EmployeeDutyInformation.EmployeeID);
                AddParameter(oDbCommand, "@DesignationID", DbType.String, _EmployeeDutyInformation.DesignationID);
                AddParameter(oDbCommand, "@DutyStartDate", DbType.DateTime, _EmployeeDutyInformation.DutyStartDate);
                AddParameter(oDbCommand, "@DutyEndDate", DbType.DateTime, _EmployeeDutyInformation.DutyEndDate);
                AddParameter(oDbCommand, "@DutyStartTime", DbType.String, _EmployeeDutyInformation.DutyStartTime);
                AddParameter(oDbCommand, "@DutyEndTime", DbType.String, _EmployeeDutyInformation.DutyEndTime);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _EmployeeDutyInformation.ChangedBy);
                
           

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(EmployeeDutyInformationBOL _EmployeeDutyInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeDutyInformationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeDutyInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable EmployeeDutyInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeDutyInformationList", CommandType.StoredProcedure);
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

        public EmployeeDutyInformationBOL EmployeeDutyInformation_GetById(EmployeeDutyInformationBOL _EmployeeDutyInformation)
        {
            try
            {
                EmployeeDutyInformationBOL oDutyType = new EmployeeDutyInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeDutyInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeDutyInformation.AutoID);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oDutyType);
                }
                oDbDataReader.Close();
                return oDutyType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
