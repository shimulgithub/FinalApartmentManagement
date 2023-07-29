using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    ApartmentFundInformationDAL
    {
        public ApartmentFundInformationDAL()
		{
			DbProviderHelper.GetConnection();
		}
      
        private static void BuildEntity(DbDataReader oDbDataReader, ApartmentFundInformationBOL oApartmentFundInformationBOL)
		{
            oApartmentFundInformationBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oApartmentFundInformationBOL.OwnerID = Convert.ToString(oDbDataReader["OwnerID"]);
            oApartmentFundInformationBOL.DesignationID = Convert.ToString(oDbDataReader["DesignationID"]);
            oApartmentFundInformationBOL.ReferenceID = Convert.ToString(oDbDataReader["ReferenceID"]);
            oApartmentFundInformationBOL.Date = Convert.ToDateTime(oDbDataReader["Date"]);
            oApartmentFundInformationBOL.DateBind = Convert.ToString(oDbDataReader["Date"]);
            oApartmentFundInformationBOL.TotalAmount = Convert.ToString(oDbDataReader["TotalAmount"]);
            oApartmentFundInformationBOL.Purpose = Convert.ToString(oDbDataReader["Purpose"]);

		}
      
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(ApartmentFundInformationBOL _ApartmentFundInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_ApartmentFundInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@OwnerID", DbType.String, _ApartmentFundInformation.OwnerID);
                AddParameter(oDbCommand, "@DesignationID", DbType.String, _ApartmentFundInformation.DesignationID);
                AddParameter(oDbCommand, "@ReferenceID", DbType.String, _ApartmentFundInformation.ReferenceID);
                AddParameter(oDbCommand, "@Date", DbType.DateTime, _ApartmentFundInformation.Date);
                AddParameter(oDbCommand, "@TotalAmount", DbType.String, _ApartmentFundInformation.TotalAmount);
                AddParameter(oDbCommand, "@Purpose", DbType.String, _ApartmentFundInformation.Purpose);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _ApartmentFundInformation.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(ApartmentFundInformationBOL _ApartmentFundInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_ApartmentFundInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _ApartmentFundInformation.AutoID);
                AddParameter(oDbCommand, "@OwnerID", DbType.String, _ApartmentFundInformation.OwnerID);
                AddParameter(oDbCommand, "@DesignationID", DbType.String, _ApartmentFundInformation.DesignationID);
                AddParameter(oDbCommand, "@ReferenceID", DbType.String, _ApartmentFundInformation.ReferenceID);
                AddParameter(oDbCommand, "@Date", DbType.DateTime, _ApartmentFundInformation.Date);
                AddParameter(oDbCommand, "@TotalAmount", DbType.String, _ApartmentFundInformation.TotalAmount);
                AddParameter(oDbCommand, "@Purpose", DbType.String, _ApartmentFundInformation.Purpose);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _ApartmentFundInformation.ChangedBy);
                
           

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(ApartmentFundInformationBOL _ApartmentFundInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_ApartmentFundInformationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _ApartmentFundInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ApartmentFundInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_ApartmentFundInformationList", CommandType.StoredProcedure);
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

        public ApartmentFundInformationBOL ApartmentFundInformation_GetById(ApartmentFundInformationBOL _ApartmentFundInformation)
        {
            try
            {
                ApartmentFundInformationBOL oDutyType = new ApartmentFundInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_ApartmentFundInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _ApartmentFundInformation.AutoID);
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
