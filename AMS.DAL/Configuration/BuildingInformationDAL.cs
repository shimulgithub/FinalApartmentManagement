using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class BuildingInformationDAL
    {

        public BuildingInformationDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, BuildingInformationBOL _BuildingInformation)
        {
            _BuildingInformation.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            _BuildingInformation.BuildingName = Convert.ToString(oDbDataReader["BuildingName"]);
            _BuildingInformation.OwnerName = Convert.ToString(oDbDataReader["OwnerName"]);
            _BuildingInformation.Email = Convert.ToString(oDbDataReader["Email"]);
            _BuildingInformation.ContactNo = Convert.ToString(oDbDataReader["ContactNo"]);
            _BuildingInformation.SecGaurdNo = Convert.ToString(oDbDataReader["SecGaurdNo"]);
            _BuildingInformation.SecretaryNo = Convert.ToString(oDbDataReader["SecretaryNo"]);
            _BuildingInformation.Address = Convert.ToString(oDbDataReader["Address"]);
            _BuildingInformation.Year = Convert.ToString(oDbDataReader["Year"]);
            _BuildingInformation.RajukReference = Convert.ToString(oDbDataReader["RajukReference"]);
            //_BuildingInformation.BuildingImage = Convert.ToByte(oDbDataReader["BuildingImage"]);
            //_BuildingInformation.BuildingRules = Convert.ToByte(oDbDataReader["BuildingRules"]);
            _BuildingInformation.CompanyName = Convert.ToString(oDbDataReader["CompanyName"]);
            _BuildingInformation.CompanyPhoneNo = Convert.ToString(oDbDataReader["CompanyPhoneNo"]);
            _BuildingInformation.CompanyAddress = Convert.ToString(oDbDataReader["CompanyAddress"]);
        }
     
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(BuildingInformationBOL _BuildingInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_BuildingInformationInsertRow", CommandType.StoredProcedure);
        
                AddParameter(oDbCommand, "@BuildingName", DbType.String, _BuildingInformation.BuildingName);
                AddParameter(oDbCommand, "@OwnerName", DbType.String, _BuildingInformation.OwnerName);
                AddParameter(oDbCommand, "@SecGaurdNo", DbType.String, _BuildingInformation.SecGaurdNo);
                AddParameter(oDbCommand, "@SecretaryNo", DbType.String, _BuildingInformation.SecretaryNo);
                AddParameter(oDbCommand, "@Address", DbType.String, _BuildingInformation.Address);
                AddParameter(oDbCommand, "@RajukReference", DbType.String, _BuildingInformation.RajukReference);
                AddParameter(oDbCommand, "@Year", DbType.String, _BuildingInformation.Year);
                AddParameter(oDbCommand, "@Email", DbType.String, _BuildingInformation.Email);
                AddParameter(oDbCommand, "@ContactNo", DbType.String, _BuildingInformation.ContactNo);
                AddParameter(oDbCommand, "@CompanyName", DbType.String, _BuildingInformation.CompanyName);
                AddParameter(oDbCommand, "@CompanyAddress", DbType.String, _BuildingInformation.CompanyAddress);
                AddParameter(oDbCommand, "@CompanyPhoneNo", DbType.String, _BuildingInformation.CompanyPhoneNo);
                //AddParameter(oDbCommand, "@BuildingImage", DbType.Byte, _BuildingInformation.BuildingImage);
                //AddParameter(oDbCommand, "@BuildingRules", DbType.Byte, _BuildingInformation.BuildingRules);
                AddParameter(oDbCommand, "@CreatedBy", DbType.String, _BuildingInformation.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(BuildingInformationBOL _BuildingInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_BuildingInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _BuildingInformation.AutoID);
                AddParameter(oDbCommand, "@BuildingName", DbType.String, _BuildingInformation.BuildingName);
                AddParameter(oDbCommand, "@OwnerName", DbType.String, _BuildingInformation.OwnerName);
                AddParameter(oDbCommand, "@SecGaurdNo", DbType.String, _BuildingInformation.SecGaurdNo);
                AddParameter(oDbCommand, "@SecretaryNo", DbType.String, _BuildingInformation.SecretaryNo);
                AddParameter(oDbCommand, "@Address", DbType.String, _BuildingInformation.Address);
                AddParameter(oDbCommand, "@RajukReference", DbType.String, _BuildingInformation.RajukReference);
                AddParameter(oDbCommand, "@Year", DbType.String, _BuildingInformation.Year);
                AddParameter(oDbCommand, "@Email", DbType.String, _BuildingInformation.Email);
                AddParameter(oDbCommand, "@ContactNo", DbType.String, _BuildingInformation.ContactNo);
                AddParameter(oDbCommand, "@CompanyName", DbType.String, _BuildingInformation.CompanyName);
                AddParameter(oDbCommand, "@CompanyAddress", DbType.String, _BuildingInformation.CompanyAddress);
                AddParameter(oDbCommand, "@CompanyPhoneNo", DbType.String, _BuildingInformation.CompanyPhoneNo);
                //AddParameter(oDbCommand, "@BuildingImage", DbType.Byte, _BuildingInformation.BuildingImage);
                //AddParameter(oDbCommand, "@BuildingRules", DbType.Byte, _BuildingInformation.BuildingRules);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _BuildingInformation.CreateBy);

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

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_BuildingInformationList", CommandType.StoredProcedure);
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

        public int Delete(BuildingInformationBOL _BuildingInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_BuildingInformation_DeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _BuildingInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetById(BuildingInformationBOL _BuildingInformation)
        {
           

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand("SP_TB_AMS_BuildingInformationListByID", CommandType.StoredProcedure);

                AddParameter(command, "@AutoID", DbType.String, _BuildingInformation.AutoID);

                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }
    }
}
