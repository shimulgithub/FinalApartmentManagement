using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    EmployeeInformationDAL
    {
        public EmployeeInformationDAL()
		{
			DbProviderHelper.GetConnection();
		}
        private static void BuildEntity(DbDataReader oDbDataReader, EmployeeInformationBOL oEmployeeInformationBOL)
		{
            oEmployeeInformationBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oEmployeeInformationBOL.Name = Convert.ToString(oDbDataReader["Name"]);
            oEmployeeInformationBOL.Email = Convert.ToString(oDbDataReader["Email"]);
            oEmployeeInformationBOL.Contact = Convert.ToString(oDbDataReader["Contact"]);
            oEmployeeInformationBOL.NIDNo = Convert.ToString(oDbDataReader["NIDNo"]);
            oEmployeeInformationBOL.JoiningDate = Convert.ToDateTime(oDbDataReader["JoiningDate"]);
            oEmployeeInformationBOL.JoiningDateBind = Convert.ToString(oDbDataReader["JoiningDate"]);
            oEmployeeInformationBOL.IsActive = Convert.ToBoolean(oDbDataReader["IsActive"]);
            oEmployeeInformationBOL.Designation = Convert.ToString(oDbDataReader["Designation"]);
            oEmployeeInformationBOL.SalaryPerMonth = Convert.ToInt32(oDbDataReader["SalaryPerMonth"]);
            oEmployeeInformationBOL.PresentAddress = Convert.ToString(oDbDataReader["PresentAddress"]);
            oEmployeeInformationBOL.PermanentAddress = Convert.ToString(oDbDataReader["PermanentAddress"]);					

				 
		}
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(EmployeeInformationBOL _EmployeeInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeInformationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@Name", DbType.String, _EmployeeInformation.Name);
                AddParameter(oDbCommand, "@Email", DbType.String, _EmployeeInformation.Email);
                AddParameter(oDbCommand, "@Contact", DbType.String, _EmployeeInformation.Contact);
                AddParameter(oDbCommand, "@NIDNo", DbType.String, _EmployeeInformation.NIDNo);
                AddParameter(oDbCommand, "@JoiningDate", DbType.DateTime, _EmployeeInformation.JoiningDate);
                AddParameter(oDbCommand, "@Designation", DbType.String, _EmployeeInformation.Designation);
                AddParameter(oDbCommand, "@SalaryPerMonth", DbType.String, _EmployeeInformation.SalaryPerMonth);
                AddParameter(oDbCommand, "@PresentAddress", DbType.String, _EmployeeInformation.PresentAddress);
                AddParameter(oDbCommand, "@PermanentAddress", DbType.String, _EmployeeInformation.PermanentAddress);

                if (_EmployeeInformation.IsActive.HasValue)
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, _EmployeeInformation.IsActive);
                else
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, DBNull.Value);


                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(EmployeeInformationBOL _EmployeeInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeInformation.AutoID);
                AddParameter(oDbCommand, "@Name", DbType.String, _EmployeeInformation.Name);
                AddParameter(oDbCommand, "@Email", DbType.String, _EmployeeInformation.Email);
                AddParameter(oDbCommand, "@Contact", DbType.String, _EmployeeInformation.Contact);
                AddParameter(oDbCommand, "@NIDNo", DbType.String, _EmployeeInformation.NIDNo);
                AddParameter(oDbCommand, "@JoiningDate", DbType.DateTime, _EmployeeInformation.JoiningDate);
                AddParameter(oDbCommand, "@Designation", DbType.String, _EmployeeInformation.Designation);
                AddParameter(oDbCommand, "@SalaryPerMonth", DbType.String, _EmployeeInformation.SalaryPerMonth);
                AddParameter(oDbCommand, "@PresentAddress", DbType.String, _EmployeeInformation.PresentAddress);
                AddParameter(oDbCommand, "@PermanentAddress", DbType.String, _EmployeeInformation.PermanentAddress);
                if (_EmployeeInformation.IsActive.HasValue)
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, _EmployeeInformation.IsActive);
                else
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, DBNull.Value);


                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(EmployeeInformationBOL _EmployeeInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeInformationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable EmployeeInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeInformationList", CommandType.StoredProcedure);
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

        public EmployeeInformationBOL EmployeeInformation_GetById(EmployeeInformationBOL _EmployeeInformation)
        {
            try
            {
                EmployeeInformationBOL oLeaveType = new EmployeeInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_EmployeeInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _EmployeeInformation.AutoID);
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
