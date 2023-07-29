using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    MeetingInformationDAL
    {
        public MeetingInformationDAL()
		{
			DbProviderHelper.GetConnection();
		}
      
        private static void BuildEntity(DbDataReader oDbDataReader, MeetingInformationBOL oMeetingInformationBOL)
		{
            oMeetingInformationBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oMeetingInformationBOL.Title = Convert.ToString(oDbDataReader["Title"]);
            oMeetingInformationBOL.Description = Convert.ToString(oDbDataReader["Description"]);
            oMeetingInformationBOL.DateBind = Convert.ToString(oDbDataReader["Date"]);
       
		}
      
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(MeetingInformationBOL _MeetingInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_MeetingInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@Title", DbType.String, _MeetingInformation.Title);
                AddParameter(oDbCommand, "@Description", DbType.String, _MeetingInformation.Description);
                AddParameter(oDbCommand, "@Date", DbType.DateTime, _MeetingInformation.Date);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _MeetingInformation.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(MeetingInformationBOL _MeetingInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_MeetingInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _MeetingInformation.AutoID);
                AddParameter(oDbCommand, "@Title", DbType.String, _MeetingInformation.Title);
                AddParameter(oDbCommand, "@Description", DbType.String, _MeetingInformation.Description);
                AddParameter(oDbCommand, "@Date", DbType.DateTime, _MeetingInformation.Date);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _MeetingInformation.ChangedBy);
                
           

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(MeetingInformationBOL _MeetingInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_MeetingInformationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _MeetingInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable MeetingInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_MeetingInformationList", CommandType.StoredProcedure);
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

        public MeetingInformationBOL MeetingInformation_GetById(MeetingInformationBOL _MeetingInformation)
        {
            try
            {
                MeetingInformationBOL oDutyType = new MeetingInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_MeetingInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _MeetingInformation.AutoID);
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
