using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    RentCollectionInformationDAL
    {
        public RentCollectionInformationDAL()
		{
			DbProviderHelper.GetConnection();
		}
      
        private static void BuildEntity(DbDataReader oDbDataReader, RentCollectionInformationBOL oRentCollectionInformationBOL)
		{
            oRentCollectionInformationBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oRentCollectionInformationBOL.FloorID = Convert.ToString(oDbDataReader["FloorID"]);
            oRentCollectionInformationBOL.UnitName = Convert.ToString(oDbDataReader["UnitName"]);
            oRentCollectionInformationBOL.MonthName = Convert.ToString(oDbDataReader["MonthName"]);
            oRentCollectionInformationBOL.Year = Convert.ToString(oDbDataReader["Year"]);
            oRentCollectionInformationBOL.ReferecneNo = Convert.ToString(oDbDataReader["ReferecneNo"]);
            oRentCollectionInformationBOL.IssueDateBind = Convert.ToString(oDbDataReader["IssueDate"]);
            oRentCollectionInformationBOL.RenterID = Convert.ToString(oDbDataReader["RenterID"]);
            oRentCollectionInformationBOL.TenantName = Convert.ToString(oDbDataReader["TenantName"]);
            oRentCollectionInformationBOL.Rent = Convert.ToString(oDbDataReader["Rent"]);
            oRentCollectionInformationBOL.WaterBill = Convert.ToString(oDbDataReader["WaterBill"]);
            oRentCollectionInformationBOL.GasBill = Convert.ToString(oDbDataReader["GasBill"]);
            oRentCollectionInformationBOL.ElectricBill = Convert.ToString(oDbDataReader["ElectricBill"]);
            oRentCollectionInformationBOL.SecurityBill = Convert.ToString(oDbDataReader["SecurityBill"]);
            oRentCollectionInformationBOL.UtilityBill = Convert.ToString(oDbDataReader["UtilityBill"]);
            oRentCollectionInformationBOL.OtherBill = Convert.ToString(oDbDataReader["OtherBill"]);
            oRentCollectionInformationBOL.TotalBill = Convert.ToString(oDbDataReader["TotalBill"]);
            oRentCollectionInformationBOL.BillStatus = Convert.ToString(oDbDataReader["BillStatus"]);
            oRentCollectionInformationBOL.DueDateBind = Convert.ToString(oDbDataReader["DueDate"]);
            oRentCollectionInformationBOL.Purpose = Convert.ToString(oDbDataReader["Purpose"]);
		}
      
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(RentCollectionInformationBOL _RentCollectionInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_RentCollectionInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@FloorID", DbType.String, _RentCollectionInformation.FloorID);
                AddParameter(oDbCommand, "@UnitName", DbType.String, _RentCollectionInformation.UnitName);
                AddParameter(oDbCommand, "@MonthName", DbType.String, _RentCollectionInformation.MonthName);
                AddParameter(oDbCommand, "@Year", DbType.String, _RentCollectionInformation.Year);
                AddParameter(oDbCommand, "@ReferecneNo", DbType.String, _RentCollectionInformation.ReferecneNo);
                AddParameter(oDbCommand, "@IssueDate", DbType.DateTime, _RentCollectionInformation.IssueDate);
                AddParameter(oDbCommand, "@RenterID", DbType.String, _RentCollectionInformation.RenterID);
                AddParameter(oDbCommand, "@Rent", DbType.String, _RentCollectionInformation.Rent);
                AddParameter(oDbCommand, "@WaterBill", DbType.String, _RentCollectionInformation.WaterBill);
                AddParameter(oDbCommand, "@GasBill", DbType.String, _RentCollectionInformation.GasBill);
                AddParameter(oDbCommand, "@ElectricBill", DbType.String, _RentCollectionInformation.ElectricBill);
                AddParameter(oDbCommand, "@SecurityBill", DbType.String, _RentCollectionInformation.SecurityBill);
                AddParameter(oDbCommand, "@UtilityBill", DbType.String, _RentCollectionInformation.UtilityBill);
                AddParameter(oDbCommand, "@OtherBill", DbType.String, _RentCollectionInformation.OtherBill);
                AddParameter(oDbCommand, "@TotalBill", DbType.String, _RentCollectionInformation.TotalBill);
                AddParameter(oDbCommand, "@BillStatus", DbType.String, _RentCollectionInformation.BillStatus);
                AddParameter(oDbCommand, "@DueDate", DbType.DateTime, _RentCollectionInformation.DueDate);
                AddParameter(oDbCommand, "@Purpose", DbType.String, _RentCollectionInformation.Purpose);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _RentCollectionInformation.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(RentCollectionInformationBOL _RentCollectionInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_RentCollectionInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _RentCollectionInformation.AutoID);
                AddParameter(oDbCommand, "@FloorID", DbType.String, _RentCollectionInformation.FloorID);
                AddParameter(oDbCommand, "@UnitName", DbType.String, _RentCollectionInformation.UnitName);
                AddParameter(oDbCommand, "@MonthName", DbType.String, _RentCollectionInformation.MonthName);
                AddParameter(oDbCommand, "@Year", DbType.String, _RentCollectionInformation.Year);
                AddParameter(oDbCommand, "@ReferecneNo", DbType.String, _RentCollectionInformation.ReferecneNo);
                AddParameter(oDbCommand, "@IssueDate", DbType.DateTime, _RentCollectionInformation.IssueDate);
                AddParameter(oDbCommand, "@RenterID", DbType.String, _RentCollectionInformation.RenterID);
                AddParameter(oDbCommand, "@Rent", DbType.String, _RentCollectionInformation.Rent);
                AddParameter(oDbCommand, "@WaterBill", DbType.String, _RentCollectionInformation.WaterBill);
                AddParameter(oDbCommand, "@GasBill", DbType.String, _RentCollectionInformation.GasBill);
                AddParameter(oDbCommand, "@ElectricBill", DbType.String, _RentCollectionInformation.ElectricBill);
                AddParameter(oDbCommand, "@SecurityBill", DbType.String, _RentCollectionInformation.SecurityBill);
                AddParameter(oDbCommand, "@UtilityBill", DbType.String, _RentCollectionInformation.UtilityBill);
                AddParameter(oDbCommand, "@OtherBill", DbType.String, _RentCollectionInformation.OtherBill);
                AddParameter(oDbCommand, "@TotalBill", DbType.String, _RentCollectionInformation.TotalBill);
                AddParameter(oDbCommand, "@BillStatus", DbType.String, _RentCollectionInformation.BillStatus);
                AddParameter(oDbCommand, "@DueDate", DbType.DateTime, _RentCollectionInformation.DueDate);
                AddParameter(oDbCommand, "@Purpose", DbType.String, _RentCollectionInformation.Purpose);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _RentCollectionInformation.ChangedBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(RentCollectionInformationBOL _RentCollectionInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_RentCollectionInformationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _RentCollectionInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RentCollectionInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_RentCollectionInformationList", CommandType.StoredProcedure);
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

        public RentCollectionInformationBOL RentCollectionInformation_GetById(RentCollectionInformationBOL _RentCollectionInformation)
        {
            try
            {
                RentCollectionInformationBOL oDutyType = new RentCollectionInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_RentCollectionInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _RentCollectionInformation.AutoID);
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
