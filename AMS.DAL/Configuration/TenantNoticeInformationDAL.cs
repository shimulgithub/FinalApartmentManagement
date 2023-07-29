using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    TenantNoticeInformationDAL
    {
        public TenantNoticeInformationDAL()
		{
			DbProviderHelper.GetConnection();
		}
      
        private static void BuildEntity(DbDataReader oDbDataReader, TenantNoticeInformationBOL oTenantNoticeInformationBOL)
		{
            oTenantNoticeInformationBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oTenantNoticeInformationBOL.Title = Convert.ToString(oDbDataReader["Title"]);
            oTenantNoticeInformationBOL.Description = Convert.ToString(oDbDataReader["Description"]);
            oTenantNoticeInformationBOL.DateBind = Convert.ToString(oDbDataReader["Date"]);
		}
      
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(TenantNoticeInformationBOL _TenantNoticeInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_TenantNoticeInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@AutoID", DbType.String, _TenantNoticeInformation.AutoID);
                AddParameter(oDbCommand, "@Date", DbType.String, _TenantNoticeInformation.Date);
                AddParameter(oDbCommand, "@Title", DbType.String, _TenantNoticeInformation.Title);
                AddParameter(oDbCommand, "@Description", DbType.String, _TenantNoticeInformation.Description);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _TenantNoticeInformation.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(TenantNoticeInformationBOL _TenantNoticeInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_TenantNoticeInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _TenantNoticeInformation.AutoID);
                AddParameter(oDbCommand, "@Date", DbType.String, _TenantNoticeInformation.Date);
                AddParameter(oDbCommand, "@Title", DbType.String, _TenantNoticeInformation.Title);
                AddParameter(oDbCommand, "@Description", DbType.String, _TenantNoticeInformation.Description);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _TenantNoticeInformation.ChangedBy);
                
           

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(TenantNoticeInformationBOL _TenantNoticeInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_TenantNoticeInformationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _TenantNoticeInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable TenantNoticeInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_TenantNoticeInformationList", CommandType.StoredProcedure);
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

        public TenantNoticeInformationBOL TenantNoticeInformation_GetById(TenantNoticeInformationBOL _TenantNoticeInformation)
        {
            try
            {
                TenantNoticeInformationBOL oLeaveType = new TenantNoticeInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_TenantNoticeInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _TenantNoticeInformation.AutoID);
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
