using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    MaintenanceCostInformationDAL
    {
        public MaintenanceCostInformationDAL()
		{
			DbProviderHelper.GetConnection();
		}
      
        private static void BuildEntity(DbDataReader oDbDataReader, MaintenanceCostInformationBOL oMaintenanceCostInformationBOL)
		{
            oMaintenanceCostInformationBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oMaintenanceCostInformationBOL.CostTitle = Convert.ToString(oDbDataReader["CostTitle"]);
            oMaintenanceCostInformationBOL.DateBind = Convert.ToString(oDbDataReader["Date"]);
            //oMaintenanceCostInformationBOL.Month = Convert.ToString(oDbDataReader["Month"]);
            //oMaintenanceCostInformationBOL.Year = Convert.ToString(oDbDataReader["Year"]);
            oMaintenanceCostInformationBOL.TotalAmount = Convert.ToString(oDbDataReader["TotalAmount"]);
            oMaintenanceCostInformationBOL.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
        		

				 
		}
      
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(MaintenanceCostInformationBOL _MaintenanceCostInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_MaintenanceCostInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@CostTitle", DbType.String, _MaintenanceCostInformation.CostTitle);
                AddParameter(oDbCommand, "@Date", DbType.DateTime, _MaintenanceCostInformation.Date);
                //AddParameter(oDbCommand, "@Month", DbType.String, _MaintenanceCostInformation.Month);
                //AddParameter(oDbCommand, "@Year", DbType.DateTime, _MaintenanceCostInformation.Year);
                AddParameter(oDbCommand, "@TotalAmount", DbType.String, _MaintenanceCostInformation.TotalAmount);
                AddParameter(oDbCommand, "@Remarks", DbType.String, _MaintenanceCostInformation.Remarks);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _MaintenanceCostInformation.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(MaintenanceCostInformationBOL _MaintenanceCostInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_MaintenanceCostInformationUpdateRow", CommandType.StoredProcedure);
               
                AddParameter(oDbCommand, "@AutoID", DbType.String, _MaintenanceCostInformation.AutoID);
                AddParameter(oDbCommand, "@CostTitle", DbType.String, _MaintenanceCostInformation.CostTitle);
                AddParameter(oDbCommand, "@Date", DbType.DateTime, _MaintenanceCostInformation.Date);
                //AddParameter(oDbCommand, "@Month", DbType.String, _MaintenanceCostInformation.Month);
                //AddParameter(oDbCommand, "@Year", DbType.DateTime, _MaintenanceCostInformation.Year);
                AddParameter(oDbCommand, "@TotalAmount", DbType.String, _MaintenanceCostInformation.TotalAmount);
                AddParameter(oDbCommand, "@Remarks", DbType.String, _MaintenanceCostInformation.Remarks);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _MaintenanceCostInformation.ChangedBy);
                
           

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(MaintenanceCostInformationBOL _MaintenanceCostInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_MaintenanceCostInformationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _MaintenanceCostInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable MaintenanceCostInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_MaintenanceCostInformationList", CommandType.StoredProcedure);
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

        public MaintenanceCostInformationBOL MaintenanceCostInformation_GetById(MaintenanceCostInformationBOL _MaintenanceCostInformation)
        {
            try
            {
                MaintenanceCostInformationBOL oLeaveType = new MaintenanceCostInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_MaintenanceCostInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _MaintenanceCostInformation.AutoID);
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
