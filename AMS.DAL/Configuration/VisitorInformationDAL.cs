using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.BOL.Configuration;

namespace AMS.DAL.Configuration
{
    public class    VisitorInformationDAL
    {
        public VisitorInformationDAL()
		{
			DbProviderHelper.GetConnection();
		}
      
        private static void BuildEntity(DbDataReader oDbDataReader, VisitorInformationBOL oVisitorInformationBOL)
		{
            oVisitorInformationBOL.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oVisitorInformationBOL.EntryDateBind = Convert.ToString(oDbDataReader["EntryDate"]);
            oVisitorInformationBOL.FloorID = Convert.ToString(oDbDataReader["FloorID"]);
            oVisitorInformationBOL.UnitID = Convert.ToString(oDbDataReader["UnitID"]);
            oVisitorInformationBOL.VisitorTypeID = Convert.ToString(oDbDataReader["VisitorTypeID"]);
            oVisitorInformationBOL.Name = Convert.ToString(oDbDataReader["Name"]);
            oVisitorInformationBOL.Mobile = Convert.ToString(oDbDataReader["Mobile"]);
            oVisitorInformationBOL.ContactPerson = Convert.ToString(oDbDataReader["ContactPerson"]);
            oVisitorInformationBOL.VisitorAddress = Convert.ToString(oDbDataReader["VisitorAddress"]);
            oVisitorInformationBOL.InTime = Convert.ToString(oDbDataReader["InTime"]);
            oVisitorInformationBOL.OutTime = Convert.ToString(oDbDataReader["OutTime"]);
            oVisitorInformationBOL.Purpose = Convert.ToString(oDbDataReader["Purpose"]);
		}
      
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(VisitorInformationBOL _VisitorInformation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_VisitorInformationInsertRow", CommandType.StoredProcedure);

               
                AddParameter(oDbCommand, "@EntryDate", DbType.DateTime, _VisitorInformation.EntryDate);
                AddParameter(oDbCommand, "@FloorID", DbType.String, _VisitorInformation.FloorID);
                AddParameter(oDbCommand, "@UnitID", DbType.String, _VisitorInformation.UnitID);
                AddParameter(oDbCommand, "@VisitorTypeID", DbType.String, _VisitorInformation.VisitorTypeID);
                AddParameter(oDbCommand, "@Name", DbType.String, _VisitorInformation.Name);
                AddParameter(oDbCommand, "@Mobile", DbType.String, _VisitorInformation.Mobile);
                AddParameter(oDbCommand, "@ContactPerson", DbType.String, _VisitorInformation.ContactPerson);
                AddParameter(oDbCommand, "@VisitorAddress", DbType.String, _VisitorInformation.VisitorAddress);
                AddParameter(oDbCommand, "@InTime", DbType.String, _VisitorInformation.InTime);
                AddParameter(oDbCommand, "@OutTime", DbType.String, _VisitorInformation.OutTime);
                AddParameter(oDbCommand, "@Purpose", DbType.String, _VisitorInformation.Purpose);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _VisitorInformation.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(VisitorInformationBOL _VisitorInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_VisitorInformationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _VisitorInformation.AutoID);
                AddParameter(oDbCommand, "@EntryDate", DbType.DateTime, _VisitorInformation.EntryDate);
                AddParameter(oDbCommand, "@FloorID", DbType.String, _VisitorInformation.FloorID);
                AddParameter(oDbCommand, "@UnitID", DbType.String, _VisitorInformation.UnitID);
                AddParameter(oDbCommand, "@VisitorTypeID", DbType.String, _VisitorInformation.VisitorTypeID);
                AddParameter(oDbCommand, "@Name", DbType.String, _VisitorInformation.Name);
                AddParameter(oDbCommand, "@Mobile", DbType.String, _VisitorInformation.Mobile);
                AddParameter(oDbCommand, "@ContactPerson", DbType.String, _VisitorInformation.ContactPerson);
                AddParameter(oDbCommand, "@VisitorAddress", DbType.String, _VisitorInformation.VisitorAddress);
                AddParameter(oDbCommand, "@InTime", DbType.String, _VisitorInformation.InTime);
                AddParameter(oDbCommand, "@OutTime", DbType.String, _VisitorInformation.OutTime);
                AddParameter(oDbCommand, "@Purpose", DbType.String, _VisitorInformation.Purpose);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _VisitorInformation.ChangedBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(VisitorInformationBOL _VisitorInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_VisitorInformationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _VisitorInformation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable VisitorInformation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_VisitorInformationList", CommandType.StoredProcedure);
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
        

        public VisitorInformationBOL VisitorInformation_GetById(VisitorInformationBOL _VisitorInformation)
        {
            try
            {
                VisitorInformationBOL oDutyType = new VisitorInformationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_VisitorInformationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _VisitorInformation.AutoID);
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

     
        public int VisitorInformation_PresenceUpdate(VisitorInformationBOL _VisitorInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_VisitorInformationPresenceUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _VisitorInformation.AutoID);
                AddParameter(oDbCommand, "@InTime", DbType.String, _VisitorInformation.InTime);
                AddParameter(oDbCommand, "@OutTime", DbType.String, _VisitorInformation.OutTime);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _VisitorInformation.CreateBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int VisitorInformation_AbsenceUpdate(VisitorInformationBOL _VisitorInformation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AMS_VisitorInformationAbsenceUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _VisitorInformation.AutoID);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _VisitorInformation.CreateBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
