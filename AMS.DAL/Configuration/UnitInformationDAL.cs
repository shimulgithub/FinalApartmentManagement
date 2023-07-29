using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class UnitInformationDAL
    {

        public UnitInformationDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, UnitInformationBOL _UnitInformation)
        {
            _UnitInformation.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            _UnitInformation.UnitName = Convert.ToString(oDbDataReader["UnitName"]);
            _UnitInformation.FloorID = Convert.ToString(oDbDataReader["FloorID"]);
        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }
        public int Add(UnitInformationBOL _UnitInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_UnitInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@UnitName", DbType.String, _UnitInformation.UnitName);
                AddParameter(oDbCommand, "@FloorID", DbType.String, _UnitInformation.FloorID);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _UnitInformation.CreateBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(UnitInformationBOL _UnitInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_UnitInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _UnitInformation.AutoID);
                AddParameter(oDbCommand, "@UnitName", DbType.String, _UnitInformation.UnitName);
                AddParameter(oDbCommand, "@FloorID", DbType.String, _UnitInformation.FloorID);
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

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_UnitInformationList", CommandType.StoredProcedure);
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
        public int Delete(UnitInformationBOL _UnitInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_UnitInformation_DeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _UnitInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UnitInformationBOL GetById(UnitInformationBOL _UnitInformation)
        {
            try
            {
                UnitInformationBOL BuildingInformation = new UnitInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_UnitInformationListByID", CommandType.StoredProcedure);
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
