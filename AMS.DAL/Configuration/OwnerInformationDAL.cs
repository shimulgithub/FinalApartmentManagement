using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class OwnerInformationDAL
    {

        public OwnerInformationDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, OwnerInformationBOL _OwnerInformation)
        {
            _OwnerInformation.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            _OwnerInformation.OwnerName = Convert.ToString(oDbDataReader["OwnerName"]);
            _OwnerInformation.Email = Convert.ToString(oDbDataReader["Email"]);
            _OwnerInformation.ContactNo = Convert.ToString(oDbDataReader["ContactNo"]);
            _OwnerInformation.National_Id_card_No = Convert.ToString(oDbDataReader["National_Id_card_No"]);
            _OwnerInformation.Present_Address = Convert.ToString(oDbDataReader["Present_Address"]);
            _OwnerInformation.Permanent_Address = Convert.ToString(oDbDataReader["Permanent_Address"]);

        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }
        public int Add(OwnerInformationBOL _OwnerInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerInformationInsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@OwnerName", DbType.String, _OwnerInformation.OwnerName);
                AddParameter(oDbCommand, "@Email", DbType.String, _OwnerInformation.Email);
                AddParameter(oDbCommand, "@ContactNo", DbType.String, _OwnerInformation.ContactNo);
                AddParameter(oDbCommand, "@National_Id_card_No", DbType.String, _OwnerInformation.National_Id_card_No);
                AddParameter(oDbCommand, "@Present_Address", DbType.String, _OwnerInformation.Present_Address);
                AddParameter(oDbCommand, "@Permanent_Address", DbType.String, _OwnerInformation.Permanent_Address);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _OwnerInformation.CreateBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));




        
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int OwnerUnitAdd(OwnerInformationBOL _OwnerInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerInformationDetailInsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@OwnerID", DbType.String, _OwnerInformation.AutoID);
                AddParameter(oDbCommand, "@UnitID", DbType.String, _OwnerInformation.UnitId);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(OwnerInformationBOL _OwnerInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerInformationUpdateRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@AutoID", DbType.String, _OwnerInformation.AutoID);
                AddParameter(oDbCommand, "@OwnerName", DbType.String, _OwnerInformation.OwnerName);
                AddParameter(oDbCommand, "@Email", DbType.String, _OwnerInformation.Email);
                AddParameter(oDbCommand, "@ContactNo", DbType.String, _OwnerInformation.ContactNo);
                AddParameter(oDbCommand, "@National_Id_card_No", DbType.String, _OwnerInformation.National_Id_card_No);
                AddParameter(oDbCommand, "@Present_Address", DbType.String, _OwnerInformation.Present_Address);
                AddParameter(oDbCommand, "@Permanent_Address", DbType.String, _OwnerInformation.Permanent_Address);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _OwnerInformation.CreateBy);

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

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerInformationList", CommandType.StoredProcedure);
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
        public int Delete(OwnerInformationBOL _OwnerInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerInformation_DeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _OwnerInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OwnerInformationBOL GetById(OwnerInformationBOL _OwnerInformation)
        {
            try
            {
                OwnerInformationBOL OwnerInformation = new OwnerInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _OwnerInformation.AutoID);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, OwnerInformation);
                }
                oDbDataReader.Close();
                return OwnerInformation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
