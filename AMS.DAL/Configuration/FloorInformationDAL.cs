using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class FloorInformationDAL
    {

        public FloorInformationDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, FloorInformationBOL _UnitInformation)
        {
            _UnitInformation.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            _UnitInformation.FloorName = Convert.ToString(oDbDataReader["FloorName"]);
           
        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }
        public int Add(FloorInformationBOL _UnitInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_FloorInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@FloorName", DbType.String, _UnitInformation.FloorName);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _UnitInformation.CreateBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(FloorInformationBOL _UnitInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_FloorInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _UnitInformation.AutoID);
                AddParameter(oDbCommand, "@FloorName", DbType.String, _UnitInformation.FloorName);
    
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _UnitInformation.ChangedBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_FloorInformationList", CommandType.StoredProcedure);
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
        public int Delete(FloorInformationBOL _UnitInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_FloorInformation_DeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _UnitInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FloorInformationBOL GetById(FloorInformationBOL _UnitInformation)
        {
            try
            {
                FloorInformationBOL BuildingInformation = new FloorInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_FloorInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _UnitInformation.AutoID);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, BuildingInformation);
                }
                oDbDataReader.Close();
                return BuildingInformation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
