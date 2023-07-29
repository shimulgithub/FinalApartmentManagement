using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    MonthlyServiceChargeDAL
    {
        public MonthlyServiceChargeDAL()
		{
			DbProviderHelper.GetConnection();
		}
      
        private static void BuildEntity(DbDataReader oDbDataReader, MonthlyServiceChargeBOL oMonthlyServiceChargeBOL)
		{
            //oMonthlyServiceChargeBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oMonthlyServiceChargeBOL.OrganizationName = Convert.ToString(oDbDataReader["OrganizationName"]);
            oMonthlyServiceChargeBOL.ChargeName = Convert.ToString(oDbDataReader["ChargeName"]);
            oMonthlyServiceChargeBOL.ReceiptNo = Convert.ToString(oDbDataReader["ReceiptNo"]);
            oMonthlyServiceChargeBOL.Year = Convert.ToString(oDbDataReader["Year"]);
            oMonthlyServiceChargeBOL.FlatNo = Convert.ToString(oDbDataReader["FlatNo"]);
            oMonthlyServiceChargeBOL.Month = Convert.ToString(oDbDataReader["Month"]);
            oMonthlyServiceChargeBOL.DateBind = Convert.ToString(oDbDataReader["Date"]);
            //oMonthlyServiceChargeBOL.ChargeListName = Convert.ToString(oDbDataReader["ChargeListName"]);
            oMonthlyServiceChargeBOL.TotalAmount = Convert.ToDouble(oDbDataReader["TotalAmount"]);
            //oMonthlyServiceChargeBOL.ChargeAmount = Convert.ToDouble(oDbDataReader["ChargeAmount"]);
				 
		}
      
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(MonthlyServiceChargeBOL _MonthlyServiceCharge)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_MonthlyServiceChargeInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@OrganizationName", DbType.String, _MonthlyServiceCharge.OrganizationName);
                AddParameter(oDbCommand, "@ChargeName", DbType.String, _MonthlyServiceCharge.ChargeName);
                AddParameter(oDbCommand, "@ReceiptNo", DbType.String, _MonthlyServiceCharge.ReceiptNo);
                AddParameter(oDbCommand, "@Year", DbType.String, _MonthlyServiceCharge.Year);
                AddParameter(oDbCommand, "@FlatNo", DbType.String, _MonthlyServiceCharge.FlatNo);
                AddParameter(oDbCommand, "@Date", DbType.DateTime, _MonthlyServiceCharge.Date);
                AddParameter(oDbCommand, "@Month", DbType.String, _MonthlyServiceCharge.Month);
                AddParameter(oDbCommand, "@ChargeListName", DbType.String, _MonthlyServiceCharge.ChargeListName);
                AddParameter(oDbCommand, "@ChargeAmount", DbType.String, _MonthlyServiceCharge.ChargeAmount);
                AddParameter(oDbCommand, "@TotalAmount", DbType.String, _MonthlyServiceCharge.TotalAmount);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _MonthlyServiceCharge.CreateBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(MonthlyServiceChargeBOL _MonthlyServiceCharge)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_MonthlyServiceChargeUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@OrganizationName", DbType.String, _MonthlyServiceCharge.OrganizationName);
                AddParameter(oDbCommand, "@ChargeName", DbType.String, _MonthlyServiceCharge.ChargeName);
                AddParameter(oDbCommand, "@ReceiptNo", DbType.String, _MonthlyServiceCharge.ReceiptNo);
                AddParameter(oDbCommand, "@Year", DbType.String, _MonthlyServiceCharge.Year);
                AddParameter(oDbCommand, "@FlatNo", DbType.String, _MonthlyServiceCharge.FlatNo);
                AddParameter(oDbCommand, "@Date", DbType.DateTime, _MonthlyServiceCharge.Date);
                AddParameter(oDbCommand, "@Month", DbType.String, _MonthlyServiceCharge.Month);
                AddParameter(oDbCommand, "@ChargeListName", DbType.String, _MonthlyServiceCharge.ChargeListName);
                AddParameter(oDbCommand, "@ChargeAmount", DbType.String, _MonthlyServiceCharge.ChargeAmount);
                AddParameter(oDbCommand, "@TotalAmount", DbType.String, _MonthlyServiceCharge.TotalAmount);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _MonthlyServiceCharge.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(MonthlyServiceChargeBOL _MonthlyServiceCharge)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_MonthlyServiceChargeDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@ReceiptNo", DbType.String, _MonthlyServiceCharge.OldReceiptNo);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable MonthlyServiceCharge_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_MonthlyServiceChargeList", CommandType.StoredProcedure);
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

        public static DataTable MonthlyServiceCharge_GetDataByReceiptNo(string ReceiptNo)
        {
           DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand("SP_TB_AMS_MonthlyServiceChargeListByreceiptNo", CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ReceiptNo", DbType.String, ReceiptNo));
              
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
        
        public MonthlyServiceChargeBOL MonthlyServiceCharge_GetById(MonthlyServiceChargeBOL _MonthlyServiceCharge)
        {
            try
            {
                MonthlyServiceChargeBOL oLeaveType = new MonthlyServiceChargeBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_MonthlyServiceChargeListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@ReceiptNo", DbType.String, _MonthlyServiceCharge.ReceiptNo);
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
