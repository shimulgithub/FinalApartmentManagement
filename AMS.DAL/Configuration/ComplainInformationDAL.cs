using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    ComplainInformationDAL
    {
        public ComplainInformationDAL()
		{
			DbProviderHelper.GetConnection();
		}
      
        private static void BuildEntity(DbDataReader oDbDataReader, ComplainInformationBOL oComplainInformationBOL)
		{
            oComplainInformationBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oComplainInformationBOL.Title = Convert.ToString(oDbDataReader["Title"]);
            oComplainInformationBOL.Description = Convert.ToString(oDbDataReader["Description"]);
            oComplainInformationBOL.DateBind = Convert.ToString(oDbDataReader["Date"]);
       
		}
      
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(ComplainInformationBOL _ComplainInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_ComplainInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@Title", DbType.String, _ComplainInformation.Title);
                AddParameter(oDbCommand, "@Description", DbType.String, _ComplainInformation.Description);
                AddParameter(oDbCommand, "@Date", DbType.DateTime, _ComplainInformation.Date);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _ComplainInformation.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(ComplainInformationBOL _ComplainInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_ComplainInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _ComplainInformation.AutoID);
                AddParameter(oDbCommand, "@Title", DbType.String, _ComplainInformation.Title);
                AddParameter(oDbCommand, "@Description", DbType.String, _ComplainInformation.Description);
                AddParameter(oDbCommand, "@Date", DbType.DateTime, _ComplainInformation.Date);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _ComplainInformation.ChangedBy);
                
           

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(ComplainInformationBOL _ComplainInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_ComplainInformationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _ComplainInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ComplainInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_ComplainInformationList", CommandType.StoredProcedure);
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

        public ComplainInformationBOL ComplainInformation_GetById(ComplainInformationBOL _ComplainInformation)
        {
            try
            {
                ComplainInformationBOL oDutyType = new ComplainInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_ComplainInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _ComplainInformation.AutoID);
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
