using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    OwnerNoticeInformationDAL
    {
        public OwnerNoticeInformationDAL()
		{
			DbProviderHelper.GetConnection();
		}
      
        private static void BuildEntity(DbDataReader oDbDataReader, OwnerNoticeInformationBOL oOwnerNoticeInformationBOL)
		{
            oOwnerNoticeInformationBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oOwnerNoticeInformationBOL.Title = Convert.ToString(oDbDataReader["Title"]);
            oOwnerNoticeInformationBOL.Description = Convert.ToString(oDbDataReader["Description"]);
            oOwnerNoticeInformationBOL.DateBind = Convert.ToString(oDbDataReader["Date"]);
		}
      
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(OwnerNoticeInformationBOL _OwnerNoticeInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerNoticeInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@AutoID", DbType.String, _OwnerNoticeInformation.AutoID);
                AddParameter(oDbCommand, "@Date", DbType.String, _OwnerNoticeInformation.Date);
                AddParameter(oDbCommand, "@Title", DbType.String, _OwnerNoticeInformation.Title);
                AddParameter(oDbCommand, "@Description", DbType.String, _OwnerNoticeInformation.Description);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _OwnerNoticeInformation.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(OwnerNoticeInformationBOL _OwnerNoticeInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerNoticeInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _OwnerNoticeInformation.AutoID);
                AddParameter(oDbCommand, "@Date", DbType.String, _OwnerNoticeInformation.Date);
                AddParameter(oDbCommand, "@Title", DbType.String, _OwnerNoticeInformation.Title);
                AddParameter(oDbCommand, "@Description", DbType.String, _OwnerNoticeInformation.Description);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _OwnerNoticeInformation.ChangedBy);
                
           

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(OwnerNoticeInformationBOL _OwnerNoticeInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerNoticeInformationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _OwnerNoticeInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable OwnerNoticeInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerNoticeInformationList", CommandType.StoredProcedure);
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

        public OwnerNoticeInformationBOL OwnerNoticeInformation_GetById(OwnerNoticeInformationBOL _OwnerNoticeInformation)
        {
            try
            {
                OwnerNoticeInformationBOL oLeaveType = new OwnerNoticeInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerNoticeInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _OwnerNoticeInformation.AutoID);
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
