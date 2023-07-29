using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class TenantMemberInformationDAL
    {

        public TenantMemberInformationDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, TenantMemberInformationBOL _TenantMemberInformation)
        {
            _TenantMemberInformation.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            _TenantMemberInformation.TenantID = Convert.ToString(oDbDataReader["TenantID"]);
            _TenantMemberInformation.Name = Convert.ToString(oDbDataReader["Name"]);

            _TenantMemberInformation.Contact = Convert.ToString(oDbDataReader["Contact"]);
            _TenantMemberInformation.Age = Convert.ToString(oDbDataReader["Age"]);
            _TenantMemberInformation.Occupation = Convert.ToString(oDbDataReader["Occupation"]);
            _TenantMemberInformation.Relation = Convert.ToString(oDbDataReader["Relation"]);
            //_TenantMemberInformation.Images = Getbytes(oDbDataReader["Images"]);

        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }
        public int Add(TenantMemberInformationBOL _TenantMemberInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_TenantMemberInformationInsertRow", CommandType.StoredProcedure);

               // AddParameter(oDbCommand, "@AutoID", DbType.String, _TenantMemberInformation.AutoID);
                AddParameter(oDbCommand, "@Name", DbType.String, _TenantMemberInformation.Name);
                AddParameter(oDbCommand, "@Contact", DbType.String, _TenantMemberInformation.Contact);
                AddParameter(oDbCommand, "@Age", DbType.String, _TenantMemberInformation.Age);
                AddParameter(oDbCommand, "@Occupation", DbType.String, _TenantMemberInformation.Occupation);
                AddParameter(oDbCommand, "@Relation", DbType.String, _TenantMemberInformation.Relation);
                AddParameter(oDbCommand, "@TenantID", DbType.String, _TenantMemberInformation.TenantID);
                //AddParameter(oDbCommand, "@Images", DbType.Binary, _TenantMemberInformation.Images);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));





            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(TenantMemberInformationBOL _TenantMemberInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_TenantMemberInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _TenantMemberInformation.AutoID);
                AddParameter(oDbCommand, "@Name", DbType.String, _TenantMemberInformation.Name);
                AddParameter(oDbCommand, "@Contact", DbType.String, _TenantMemberInformation.Contact);
                AddParameter(oDbCommand, "@Age", DbType.String, _TenantMemberInformation.Age);
                AddParameter(oDbCommand, "@Occupation", DbType.String, _TenantMemberInformation.Occupation);
                AddParameter(oDbCommand, "@Relation", DbType.String, _TenantMemberInformation.Relation);
           
                

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDataForGV(string TenantID)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand("SP_TB_AMS_TenantMemberInformationListByTenantID", CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@TenantID", DbType.String, TenantID));
                
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
        public int Delete(TenantMemberInformationBOL _TenantMemberInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_TenantMemberInformation_DeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _TenantMemberInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TenantMemberInformationBOL GetById(TenantMemberInformationBOL _TenantMemberInformation)
        {
            try
            {
                TenantMemberInformationBOL MemberInformation = new TenantMemberInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_TenantMemberInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _TenantMemberInformation.AutoID);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, MemberInformation);
                }
                oDbDataReader.Close();
                return MemberInformation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
