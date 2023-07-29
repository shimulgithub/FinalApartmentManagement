using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    BillDepositInformationDAL
    {
        public BillDepositInformationDAL()
		{
			DbProviderHelper.GetConnection();
		}
      
        private static void BuildEntity(DbDataReader oDbDataReader, BillDepositInformationBOL oBillDepositInformationBOL)
		{
            oBillDepositInformationBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oBillDepositInformationBOL.BillTypeID = Convert.ToString(oDbDataReader["BillTypeID"]);
            oBillDepositInformationBOL.BankID = Convert.ToString(oDbDataReader["BankID"]);
            oBillDepositInformationBOL.MonthName = Convert.ToString(oDbDataReader["MonthName"]);
            oBillDepositInformationBOL.Year = Convert.ToString(oDbDataReader["Year"]);
            oBillDepositInformationBOL.ReferencNo = Convert.ToString(oDbDataReader["ReferencNo"]);
            oBillDepositInformationBOL.BillDateBind = Convert.ToString(oDbDataReader["BillDate"]);
          
            oBillDepositInformationBOL.TotalAmt = Convert.ToString(oDbDataReader["TotalAmt"]);
            oBillDepositInformationBOL.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
		}
      
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(BillDepositInformationBOL _BillDepositInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_BillDepositInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@BillTypeID", DbType.String, _BillDepositInformation.BillTypeID);
                AddParameter(oDbCommand, "@BankID", DbType.String, _BillDepositInformation.BankID);
                AddParameter(oDbCommand, "@MonthName", DbType.String, _BillDepositInformation.MonthName);
                AddParameter(oDbCommand, "@Year", DbType.String, _BillDepositInformation.Year);
                AddParameter(oDbCommand, "@ReferencNo", DbType.String, _BillDepositInformation.ReferencNo);
                AddParameter(oDbCommand, "@BillDate", DbType.DateTime, _BillDepositInformation.BillDate);
                AddParameter(oDbCommand, "@TotalAmt", DbType.String, _BillDepositInformation.TotalAmt);
                AddParameter(oDbCommand, "@Remarks", DbType.String, _BillDepositInformation.Remarks);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _BillDepositInformation.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(BillDepositInformationBOL _BillDepositInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_BillDepositInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _BillDepositInformation.AutoID);
                AddParameter(oDbCommand, "@BillTypeID", DbType.String, _BillDepositInformation.BillTypeID);
                AddParameter(oDbCommand, "@BankID", DbType.String, _BillDepositInformation.BankID);
                AddParameter(oDbCommand, "@MonthName", DbType.String, _BillDepositInformation.MonthName);
                AddParameter(oDbCommand, "@Year", DbType.String, _BillDepositInformation.Year);
                AddParameter(oDbCommand, "@ReferencNo", DbType.String, _BillDepositInformation.ReferencNo);
                AddParameter(oDbCommand, "@BillDate", DbType.DateTime, _BillDepositInformation.BillDate);
                AddParameter(oDbCommand, "@TotalAmt", DbType.String, _BillDepositInformation.TotalAmt);
                AddParameter(oDbCommand, "@Remarks", DbType.String, _BillDepositInformation.Remarks);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _BillDepositInformation.ChangedBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(BillDepositInformationBOL _BillDepositInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_BillDepositInformationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _BillDepositInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable BillDepositInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_BillDepositInformationList", CommandType.StoredProcedure);
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

        public BillDepositInformationBOL BillDepositInformation_GetById(BillDepositInformationBOL _BillDepositInformation)
        {
            try
            {
                BillDepositInformationBOL oDutyType = new BillDepositInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_BillDepositInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _BillDepositInformation.AutoID);
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
