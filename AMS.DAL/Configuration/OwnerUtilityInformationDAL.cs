using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    OwnerUtilityInformationDAL
    {
        public OwnerUtilityInformationDAL()
		{
			DbProviderHelper.GetConnection();
		}
      
        private static void BuildEntity(DbDataReader oDbDataReader, OwnerUtilityInformationBOL oOwnerUtilityInformationBOL)
		{
            oOwnerUtilityInformationBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oOwnerUtilityInformationBOL.FloorID = Convert.ToString(oDbDataReader["FloorID"]);
            oOwnerUtilityInformationBOL.UnitName = Convert.ToString(oDbDataReader["UnitName"]);
            oOwnerUtilityInformationBOL.MonthName = Convert.ToString(oDbDataReader["MonthName"]);
            oOwnerUtilityInformationBOL.Year = Convert.ToString(oDbDataReader["Year"]);
            oOwnerUtilityInformationBOL.ReferecneNo = Convert.ToString(oDbDataReader["ReferecneNo"]);
            oOwnerUtilityInformationBOL.IssueDateBind = Convert.ToString(oDbDataReader["IssueDate"]);
            oOwnerUtilityInformationBOL.RenterID = Convert.ToString(oDbDataReader["RenterID"]);
            oOwnerUtilityInformationBOL.TenantName = Convert.ToString(oDbDataReader["TenantName"]);
            oOwnerUtilityInformationBOL.Rent = Convert.ToString(oDbDataReader["Rent"]);
            oOwnerUtilityInformationBOL.WaterBill = Convert.ToString(oDbDataReader["WaterBill"]);
            oOwnerUtilityInformationBOL.GasBill = Convert.ToString(oDbDataReader["GasBill"]);
            oOwnerUtilityInformationBOL.ElectricBill = Convert.ToString(oDbDataReader["ElectricBill"]);
            oOwnerUtilityInformationBOL.SecurityBill = Convert.ToString(oDbDataReader["SecurityBill"]);
            oOwnerUtilityInformationBOL.UtilityBill = Convert.ToString(oDbDataReader["UtilityBill"]);
            oOwnerUtilityInformationBOL.OtherBill = Convert.ToString(oDbDataReader["OtherBill"]);
            oOwnerUtilityInformationBOL.TotalBill = Convert.ToString(oDbDataReader["TotalBill"]);
            oOwnerUtilityInformationBOL.BillStatus = Convert.ToString(oDbDataReader["BillStatus"]);
            oOwnerUtilityInformationBOL.DueDateBind = Convert.ToString(oDbDataReader["DueDate"]);
            oOwnerUtilityInformationBOL.Purpose = Convert.ToString(oDbDataReader["Purpose"]);
		}
      
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(OwnerUtilityInformationBOL _OwnerUtilityInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerUtilityInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@FloorID", DbType.String, _OwnerUtilityInformation.FloorID);
                AddParameter(oDbCommand, "@UnitName", DbType.String, _OwnerUtilityInformation.UnitName);
                AddParameter(oDbCommand, "@MonthName", DbType.String, _OwnerUtilityInformation.MonthName);
                AddParameter(oDbCommand, "@Year", DbType.String, _OwnerUtilityInformation.Year);
                AddParameter(oDbCommand, "@ReferecneNo", DbType.String, _OwnerUtilityInformation.ReferecneNo);
                AddParameter(oDbCommand, "@IssueDate", DbType.DateTime, _OwnerUtilityInformation.IssueDate);
                AddParameter(oDbCommand, "@RenterID", DbType.String, _OwnerUtilityInformation.RenterID);
                AddParameter(oDbCommand, "@Rent", DbType.String, _OwnerUtilityInformation.Rent);
                AddParameter(oDbCommand, "@WaterBill", DbType.String, _OwnerUtilityInformation.WaterBill);
                AddParameter(oDbCommand, "@GasBill", DbType.String, _OwnerUtilityInformation.GasBill);
                AddParameter(oDbCommand, "@ElectricBill", DbType.String, _OwnerUtilityInformation.ElectricBill);
                AddParameter(oDbCommand, "@SecurityBill", DbType.String, _OwnerUtilityInformation.SecurityBill);
                AddParameter(oDbCommand, "@UtilityBill", DbType.String, _OwnerUtilityInformation.UtilityBill);
                AddParameter(oDbCommand, "@OtherBill", DbType.String, _OwnerUtilityInformation.OtherBill);
                AddParameter(oDbCommand, "@TotalBill", DbType.String, _OwnerUtilityInformation.TotalBill);
                AddParameter(oDbCommand, "@BillStatus", DbType.String, _OwnerUtilityInformation.BillStatus);
                AddParameter(oDbCommand, "@DueDate", DbType.DateTime, _OwnerUtilityInformation.DueDate);
                AddParameter(oDbCommand, "@Purpose", DbType.String, _OwnerUtilityInformation.Purpose);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _OwnerUtilityInformation.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(OwnerUtilityInformationBOL _OwnerUtilityInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerUtilityInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _OwnerUtilityInformation.AutoID);
                AddParameter(oDbCommand, "@FloorID", DbType.String, _OwnerUtilityInformation.FloorID);
                AddParameter(oDbCommand, "@UnitName", DbType.String, _OwnerUtilityInformation.UnitName);
                AddParameter(oDbCommand, "@MonthName", DbType.String, _OwnerUtilityInformation.MonthName);
                AddParameter(oDbCommand, "@Year", DbType.String, _OwnerUtilityInformation.Year);
                AddParameter(oDbCommand, "@ReferecneNo", DbType.String, _OwnerUtilityInformation.ReferecneNo);
                AddParameter(oDbCommand, "@IssueDate", DbType.DateTime, _OwnerUtilityInformation.IssueDate);
                AddParameter(oDbCommand, "@RenterID", DbType.String, _OwnerUtilityInformation.RenterID);
                AddParameter(oDbCommand, "@Rent", DbType.String, _OwnerUtilityInformation.Rent);
                AddParameter(oDbCommand, "@WaterBill", DbType.String, _OwnerUtilityInformation.WaterBill);
                AddParameter(oDbCommand, "@GasBill", DbType.String, _OwnerUtilityInformation.GasBill);
                AddParameter(oDbCommand, "@ElectricBill", DbType.String, _OwnerUtilityInformation.ElectricBill);
                AddParameter(oDbCommand, "@SecurityBill", DbType.String, _OwnerUtilityInformation.SecurityBill);
                AddParameter(oDbCommand, "@UtilityBill", DbType.String, _OwnerUtilityInformation.UtilityBill);
                AddParameter(oDbCommand, "@OtherBill", DbType.String, _OwnerUtilityInformation.OtherBill);
                AddParameter(oDbCommand, "@TotalBill", DbType.String, _OwnerUtilityInformation.TotalBill);
                AddParameter(oDbCommand, "@BillStatus", DbType.String, _OwnerUtilityInformation.BillStatus);
                AddParameter(oDbCommand, "@DueDate", DbType.DateTime, _OwnerUtilityInformation.DueDate);
                AddParameter(oDbCommand, "@Purpose", DbType.String, _OwnerUtilityInformation.Purpose);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _OwnerUtilityInformation.ChangedBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(OwnerUtilityInformationBOL _OwnerUtilityInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerUtilityInformationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _OwnerUtilityInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable OwnerUtilityInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerUtilityInformationList", CommandType.StoredProcedure);
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

        public OwnerUtilityInformationBOL OwnerUtilityInformation_GetById(OwnerUtilityInformationBOL _OwnerUtilityInformation)
        {
            try
            {
                OwnerUtilityInformationBOL oDutyType = new OwnerUtilityInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_OwnerUtilityInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _OwnerUtilityInformation.AutoID);
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
