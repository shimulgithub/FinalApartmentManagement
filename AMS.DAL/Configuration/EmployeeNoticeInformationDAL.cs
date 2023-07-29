using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    EmployeeNoticeInformationDAL
    {
        public EmployeeNoticeInformationDAL()
		{
			DbProviderHelper.GetConnection();
		}
      
        private static void BuildEntity(DbDataReader oDbDataReader, EmployeeNoticeInformationBOL oEmployeeNoticeInformationBOL)
		{
            oEmployeeNoticeInformationBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oEmployeeNoticeInformationBOL.Title = Convert.ToString(oDbDataReader["Title"]);
            oEmployeeNoticeInformationBOL.Description = Convert.ToString(oDbDataReader["Description"]);
            oEmployeeNoticeInformationBOL.DateBind = Convert.ToString(oDbDataReader["Date"]);
		}
      
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(EmployeeNoticeInformationBOL _EmployeeNoticeInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeNoticeInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeNoticeInformation.AutoID);
                AddParameter(oDbCommand, "@Date", DbType.String, _EmployeeNoticeInformation.Date);
                AddParameter(oDbCommand, "@Title", DbType.String, _EmployeeNoticeInformation.Title);
                AddParameter(oDbCommand, "@Description", DbType.String, _EmployeeNoticeInformation.Description);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _EmployeeNoticeInformation.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(EmployeeNoticeInformationBOL _EmployeeNoticeInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeNoticeInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeNoticeInformation.AutoID);
                AddParameter(oDbCommand, "@Date", DbType.String, _EmployeeNoticeInformation.Date);
                AddParameter(oDbCommand, "@Title", DbType.String, _EmployeeNoticeInformation.Title);
                AddParameter(oDbCommand, "@Description", DbType.String, _EmployeeNoticeInformation.Description);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _EmployeeNoticeInformation.ChangedBy);
                
           

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(EmployeeNoticeInformationBOL _EmployeeNoticeInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeNoticeInformationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeNoticeInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable EmployeeNoticeInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeNoticeInformationList", CommandType.StoredProcedure);
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

        public EmployeeNoticeInformationBOL EmployeeNoticeInformation_GetById(EmployeeNoticeInformationBOL _EmployeeNoticeInformation)
        {
            try
            {
                EmployeeNoticeInformationBOL oLeaveType = new EmployeeNoticeInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeNoticeInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeNoticeInformation.AutoID);
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
