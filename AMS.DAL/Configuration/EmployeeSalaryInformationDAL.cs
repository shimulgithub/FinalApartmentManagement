using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    EmployeeSalaryInformationDAL
    {
        public EmployeeSalaryInformationDAL()
		{
			DbProviderHelper.GetConnection();
		}
      
        private static void BuildEntity(DbDataReader oDbDataReader, EmployeeSalaryInformationBOL oEmployeeSalaryInformationBOL)
		{
            oEmployeeSalaryInformationBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oEmployeeSalaryInformationBOL.EmployeeID = Convert.ToString(oDbDataReader["EmployeeID"]);
            oEmployeeSalaryInformationBOL.DesignationID = Convert.ToString(oDbDataReader["DesignationID"]);
            oEmployeeSalaryInformationBOL.SalaryMonthName = Convert.ToString(oDbDataReader["SalaryMonthName"]);
            oEmployeeSalaryInformationBOL.Year = Convert.ToString(oDbDataReader["Year"]);
            oEmployeeSalaryInformationBOL.SalaryAmount = Convert.ToString(oDbDataReader["SalaryAmount"]);
            oEmployeeSalaryInformationBOL.IssueDateBind = Convert.ToString(oDbDataReader["IssueDate"]);
					

				 
		}
      
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(EmployeeSalaryInformationBOL _EmployeeSalaryInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeSalaryInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@EmployeeID", DbType.String, _EmployeeSalaryInformation.EmployeeID);
                AddParameter(oDbCommand, "@DesignationID", DbType.String, _EmployeeSalaryInformation.DesignationID);
                AddParameter(oDbCommand, "@SalaryMonthName", DbType.String, _EmployeeSalaryInformation.SalaryMonthName);
                AddParameter(oDbCommand, "@Year", DbType.String, _EmployeeSalaryInformation.Year);
                AddParameter(oDbCommand, "@SalaryAmount", DbType.String, _EmployeeSalaryInformation.SalaryAmount);
                AddParameter(oDbCommand, "@IssueDate", DbType.DateTime, _EmployeeSalaryInformation.IssueDate);
                AddParameter(oDbCommand, "@CreateBy", DbType.DateTime, _EmployeeSalaryInformation.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(EmployeeSalaryInformationBOL _EmployeeSalaryInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeSalaryInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeSalaryInformation.AutoID);
                AddParameter(oDbCommand, "@EmployeeID", DbType.String, _EmployeeSalaryInformation.EmployeeID);
                AddParameter(oDbCommand, "@DesignationID", DbType.String, _EmployeeSalaryInformation.DesignationID);
                AddParameter(oDbCommand, "@SalaryMonthName", DbType.String, _EmployeeSalaryInformation.SalaryMonthName);
                AddParameter(oDbCommand, "@Year", DbType.String, _EmployeeSalaryInformation.Year);
                AddParameter(oDbCommand, "@SalaryAmount", DbType.String, _EmployeeSalaryInformation.SalaryAmount);
                AddParameter(oDbCommand, "@IssueDate", DbType.DateTime, _EmployeeSalaryInformation.IssueDate);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _EmployeeSalaryInformation.ChangedBy);
                
           

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(EmployeeSalaryInformationBOL _EmployeeSalaryInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeSalaryInformationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeSalaryInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable EmployeeSalaryInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeSalaryInformationList", CommandType.StoredProcedure);
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

        public EmployeeSalaryInformationBOL EmployeeSalaryInformation_GetById(EmployeeSalaryInformationBOL _EmployeeSalaryInformation)
        {
            try
            {
                EmployeeSalaryInformationBOL oLeaveType = new EmployeeSalaryInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeSalaryInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeSalaryInformation.AutoID);
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
