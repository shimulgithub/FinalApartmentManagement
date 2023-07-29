using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

using System.Configuration;
using AMS.DAL;
using System.Data.SqlClient;


namespace AMS.Common
{
     public class Global
    {

        public static string connStr = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;

        public static Int32 _Companyid;

        public static Int32 Companyid
        {
            get { return _Companyid; }
            set { _Companyid = value; }
        }

        public static Int32 _userID;

        public static Int32 userID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public static string _userNameID = String.Empty;

        public static string userNameID
        {
            get { return _userNameID; }
            set { _userNameID = value; }
        }

        public static string _userName = String.Empty;

        public static string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public static Int32 _userRole = 0;

        public static Int32 userRole
        {
            get { return _userRole; }
            set { _userRole = value; }
        }

        public static string _userPassword = String.Empty;

        public static string userPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }

        public static Int32 _User_Branch = 0;

        public static Int32 User_Branch
        {
            get { return _User_Branch; }
            set { _User_Branch = value; }
        }


        public Global()
        {
            DbProviderHelper.GetConnection();
        }

        public static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }

        public static DataTable CreateDataTable(string pStoreProcedure)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);
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

        public static DataTable CreateNo_Parameter(string pStoreProcedure, string ParamNo)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ParamNo", DbType.String, ParamNo));
                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter(string pStoreProcedure, string param)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@param", DbType.String, param));
                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter(string pStoreProcedure, string param0, string param1)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@param0", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@param1", DbType.String, param1));
                //command.Parameters.Add(DbProviderHelper.CreateParameter("@param2", DbType.Int32, param2));
                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter(string pStoreProcedure, string param0, string param1, string param2)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@param0", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@param1", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@param2", DbType.String, param2));
                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter8(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));

                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter9(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param8));

                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_CND(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param8));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromBIDDate", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToBIDDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param11));

                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter14(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param8));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromTDCDate", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToTDCDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromBIDDate", DbType.String, param11));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToBIDDate", DbType.String, param12));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromPIDDate", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToPIDDate", DbType.String, param14));


                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter12(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param8));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromBIDDate", DbType.String, param9));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToBIDDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromPIDDate", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToPIDDate", DbType.String, param12));


                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter6(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployeeStatus ", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@MatchingCurrencyStatus ", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Employment_Type ", DbType.String, param9));
                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameterWorkersuppliers(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param6));

                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_Perm_Placement(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param6));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromPSDDate", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToPSDDate", DbType.String, param8));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromBIDDate", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToBIDDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param11));


                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter7(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param6));


                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_Ass(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param4));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromASDDate", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToASDDate", DbType.String, param6));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromAEEDDate", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToAEEDDate", DbType.String, param8));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromAAEDDate", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToAAEDDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param11));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameterSDB(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Currency_Code", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceCreditNoteDate_From", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceCreditNoteDate_To", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Year", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Period_From", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Period_To", DbType.String, param7));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvCNType", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ContractType", DbType.String, param10));
                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameterPDB(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRef", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Currency_Code", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_From", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_To", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_created", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_From", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_To", DbType.String, param7));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Yr_Proc_By_Payroll", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_From", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_To", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param11));

                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_Margin_PS(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19, string param20, string param21, string param22, string param23, string param24, string param25, string param26, string param27)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param8));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromBIDDate", DbType.String, param9));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToBIDDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromPIDDate", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToPIDDate", DbType.String, param12));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_supplier_paid", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_From", DbType.String, param14));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_To", DbType.String, param15));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Year_Validated", DbType.String, param16));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_From", DbType.String, param17));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_To", DbType.String, param18));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_invoiced", DbType.String, param19));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_From", DbType.String, param20));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_To", DbType.String, param21));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_proc_by_payroll", DbType.String, param22));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_From", DbType.String, param23));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_To", DbType.String, param24));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@PageIndex", DbType.String, param25));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@PageSize", DbType.String, param26));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param27));

                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_Margin(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19, string param20, string param21, string param22, string param23, string param24, string param25)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param8));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromBIDDate", DbType.String, param9));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToBIDDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromPIDDate", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToPIDDate", DbType.String, param12));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_supplier_paid", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_From", DbType.String, param14));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_To", DbType.String, param15));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Year_Validated", DbType.String, param16));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_From", DbType.String, param17));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_To", DbType.String, param18));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_invoiced", DbType.String, param19));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_From", DbType.String, param20));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_To", DbType.String, param21));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_proc_by_payroll", DbType.String, param22));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_From", DbType.String, param23));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_To", DbType.String, param24));



                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param25));

                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_ValidTimeSheet(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19, string param20, string param21, string param22, string param23, string param24, int param25, int param26)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param8));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromTDCDate", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToTDCDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromBIDDate", DbType.String, param11));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToBIDDate", DbType.String, param12));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromPIDDate", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToPIDDate", DbType.String, param14));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Year_Validated", DbType.String, param15));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_From", DbType.String, param16));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_To", DbType.String, param17));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_invoiced", DbType.String, param18));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_From", DbType.String, param19));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_To", DbType.String, param20));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_proc_by_payroll", DbType.String, param21));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_From", DbType.String, param22));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_To", DbType.String, param23));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param24));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@PageNo", DbType.Int32, param25));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@PageSize", DbType.Int32, param26));

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


        public static DataTable CreateDataTable_PlacementDetails(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19, string param20, string param21, string param22, string param23, string param24)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param8));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromTDCDate", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToTDCDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromBIDDate", DbType.String, param11));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToBIDDate", DbType.String, param12));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromPIDDate", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToPIDDate", DbType.String, param14));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Year_Validated", DbType.String, param15));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_From", DbType.String, param16));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_To", DbType.String, param17));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_invoiced", DbType.String, param18));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_From", DbType.String, param19));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_To", DbType.String, param20));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_proc_by_payroll", DbType.String, param21));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_From", DbType.String, param22));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_To", DbType.String, param23));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param24));

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

        public static DataTable CreateDataTableParameter_US_Payroll_Spread_Sheet(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Validated", DbType.String, param7));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@processed_by_Payroll", DbType.String, param8));

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

        public static DataTable CreateDataTableParameter_ConsultantsListDetails(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param4));

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

        public static DataSet CreateDataSet(string pStoreProcedure)
        {
            DbProviderHelper.GetConnection();
            DataSet tableset = new DataSet();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(tableset);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tableset.Dispose();
            }
            return tableset;

            //DataTable dt = dss.Tables[0];
        }

        public static DataTable CreateDataTableParameter_SuppliersDetails(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param1));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@LegalStatus", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@SuppliersType", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SuppliersCountry", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SelfBillingTF", DbType.String, param5));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param6));

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

        public static DataTable CreateDataTableParameter_ClientsDetails(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param1));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientCurrencyID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientCountryID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@BillingCountryID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param5));


                //command.Parameters.Add(DbProviderHelper.CreateParameter("@BillingCountryID", DbType.String, param5));
                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));
                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param8));

                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@FromTDCDate", DbType.String, param9));
                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@ToTDCDate", DbType.String, param10));
                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@FromBIDDate", DbType.String, param11));

                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@ToBIDDate", DbType.String, param12));
                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@FromPIDDate", DbType.String, param13));
                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@ToPIDDate", DbType.String, param14));


                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Year_Validated", DbType.String, param15));
                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_From", DbType.String, param16));
                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_To", DbType.String, param17));

                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_invoiced", DbType.String, param18));
                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_From", DbType.String, param19));
                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_To", DbType.String, param20));

                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_proc_by_payroll", DbType.String, param21));
                //    command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_From", DbType.String, param22));
                //    // command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_To", DbType.String, param23));



                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_US_Payroll_Spread_Sheet(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Validated", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@processed_by_Payroll", DbType.String, param8));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@operator", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE_PlacementEndDt", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE_PlacementEndDt", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param12));

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

        public static DataTable CreateDataTableParameter_MissingTimesheet(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19, string param20)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerPayrollGroup", DbType.String, param5));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromASDDate", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToASDDate", DbType.String, param7));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromAEEDDate", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToAEEDDate", DbType.String, param9));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromAAEDDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToAAEDDate", DbType.String, param11));




                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromSTWD", DbType.String, param12));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToSTWD", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromETWD", DbType.String, param14));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToETWD", DbType.String, param15));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@From_TW_Year", DbType.String, param16));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@To_TW_Year", DbType.String, param17));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@From_TW_Period", DbType.String, param18));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@To_TW_Period", DbType.String, param19));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param20));



                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameterExchangeRates(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromCurrency_Code", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToCurrency_Code", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EffectiveDate_From", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EffectiveDate_To", DbType.String, param3));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EffectiveYear_From", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EffectiveYear_To", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EffectiveMonth_From", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EffectiveMonth_To", DbType.String, param7));

                //command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Yr_Proc_By_Payroll", DbType.String, param8));
                //command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_From", DbType.String, param9));
                //command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_To", DbType.String, param10));

                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameterCONNString(string pStoreProcedure, string param0, string param1)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@param0", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@param1", DbType.String, param1));
                //command.Parameters.Add(DbProviderHelper.CreateParameter("@param2", DbType.Int32, param2));
                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_SegmentsCombinationList(string pStoreProcedure)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                //command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                //command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                //command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));
                //command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param3));

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

        public static DataTable CreateDataTableParameter_GetSegmentsNmaeByStructureCode(string pStoreProcedure, string param0)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@StructureCode", DbType.String, param0));


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

        public static DataTable CreateDataTableParameter_SegmentsAllocatinSetupGVList(string pStoreProcedure, string param0, string param1)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@StructureCode", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserId", DbType.String, param1));


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

        public static DataTable CreateDataTableParameter_StructureCodeBySegmentsAutoID(string pStoreProcedure, string param0, string param1, string param2, string param3)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@SegmentsAutoID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SegmentsTableName", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SegmentsName", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SegmentsCombinatiomCode", DbType.String, param3));


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

        public static DataTable CreateDataTableParameter_StructureCodeBySegmentsAutoID(string pStoreProcedure, string param0, string param1, string param2)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@SegmentsAutoID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SegmentsTableName", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SegmentsName", DbType.String, param2));



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

        public static DataTable CreateDataTableParameter_SegmentsNameByStructureCode(string pStoreProcedure, string param0)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@StructureCode", DbType.String, param0));


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

        public static DataTable CreateDataTableParameterDivision_CodesForUserWiseAllocation(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ParentSegmentId", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ChildSegmentId", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@StructureCode", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SegmentsCombinationCode", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SegmentsSelectedValue", DbType.String, param4));
                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameterBuildinginformation(string pStoreProcedure)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);
              

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

        public static DataTable CreateDataTableParameter_AssignmentDetailsWithRates(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param6));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Operator_Start", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE_Start", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE_Start", DbType.String, param9));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Operator_End", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE_End", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE_End", DbType.String, param12));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@AssignmentRates", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param14));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@AssignmentRef", DbType.String, param15));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Operator_Expected", DbType.String, param16));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE_Expected", DbType.String, param17));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE_Expected", DbType.String, param18));

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

        public static DataTable CreateDataTableParameterPayrollCalendar(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Employer_Ref", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@PeriodStartDate_From", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@PeriodStartDate_To", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@PeriodEndDate_From", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@PeriodEndDate_To", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_Payroll_Calendar", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Payroll_Calendar_From", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Payroll_Calendar_To", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param8));

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

        public static DataTable CreateDataTableParameter_EmailLogsReport(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13) //, string param13, string param14, string param15, string param16, string param17, string param18, string param19, string param20, string param21, string param22, string param23, string param24, string param25)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Employer_Ref", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Email_Subject", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Personnel_Ref", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Email_From_Address", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Ready_To_Send_TF", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@User_ID", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Description", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Date_Sent_srcFrom", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Date_Sent_srcTo", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Date_Created_srcFrom", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Date_Created_srcTo", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmailAttachment", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param12));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TransactionType", DbType.String, param13));

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

        public static DataTable CreateDataTableParameter_SegmentCombinationSetupForUserWiseAllocation(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11) //, string param13, string param14, string param15, string param16, string param17, string param18, string param19, string param20, string param21, string param22, string param23, string param24, string param25)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@StructureCode", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SegmentsCombinationCode", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Segment1", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Segment2", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Segment3", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Segment4", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Segment5", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Segment6", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Segment7", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Segment8", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Segment9", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Segment10", DbType.String, param11));
                // command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param12));


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

        public static DataTable CreateDataTableParameterTempestAuditReport(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, int param5, int param6)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Table_Name", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Action", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@RowID", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ActionDate_From", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ActionDate_To", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@PageNo", DbType.Int32, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@PageSize", DbType.Int32, param6));
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

        public static int SystemUsageAuditLogInsert(string LoginIPAddress, string BrowserVersion, string PageId, string UserId, string MacAddress)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_SystemUsageAuditLogInsertRow", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LoginIPAddress", DbType.String, LoginIPAddress));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BrowserVersion", DbType.String, BrowserVersion));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PageId", DbType.String, PageId));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@UserId", DbType.String, UserId));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@MacAddress", DbType.String, MacAddress));

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable CreateDataTablePOWithPurchaseOrderAuditReport(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7)//, , string param5)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Employer_Ref", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Client_Ref", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Purchase_Order_Number", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EndFROMDATE", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EndTODATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param7));
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

        public static DataTable CreateDataTableParameter_AssignmentDetailsWithLeaveInformation(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param6));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Operator_Start", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE_Start", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE_Start", DbType.String, param9));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Operator_End", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE_End", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE_End", DbType.String, param12));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@LeaveInformation", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param14));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@AssignmentRef", DbType.String, param15));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Employment_Type", DbType.String, param16));

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

        public static DataTable CreateDataTableParameterAllAuditReportView(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserId", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@RefId", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TranStatus", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROM_Date", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TO_Date", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@searchText", DbType.String, param5));
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

        public static DataTable CreateDataTableParameter_PurchaseOrderReport(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7) //, string param13, string param14, string param15, string param16, string param17, string param18, string param19, string param20, string param21, string param22, string param23, string param24, string param25)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Employer_Ref", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Client_Ref", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Purchase_Order_No", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@StartDate_From", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@StartDate_To", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EndDate_From", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EndDate_To", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserId", DbType.String, param7));

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

        public static DataTable CreateDataTableParameterTempestPayments(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRef", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Currency_Code", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_From", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_To", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_created", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_From", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_To", DbType.String, param7));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Yr_Proc_By_Payroll", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_From", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_To", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param11));


                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameterTempestPayments_ConTo_Excel(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRef", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Currency_Code", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_From", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_To", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_created", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_From", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_To", DbType.String, param7));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Yr_Proc_By_Payroll", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_From", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_To", DbType.String, param10));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Param_Employer_Ref", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Param_CurrencyCode", DbType.String, param12));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param13));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tran_Status", DbType.String, param14));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameterTempestPaymentsViewToGrid(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRef", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Currency_Code", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_From", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_To", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_created", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_From", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_To", DbType.String, param7));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Yr_Proc_By_Payroll", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_From", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_To", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tran_Status", DbType.String, param12));

                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameterTempestPurchseInvoice(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRef", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Currency_Code", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_From", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_To", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_created", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_From", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_To", DbType.String, param7));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Yr_Proc_By_Payroll", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_From", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_To", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TransactionType", DbType.String, param11));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param12));

                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameterTempestPurchseInvoice_Excel(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRef", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Currency_Code", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_From", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_To", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_created", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_From", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_To", DbType.String, param7));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Yr_Proc_By_Payroll", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_From", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_To", DbType.String, param10));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Param_Employer_Ref", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Param_CurrencyCode", DbType.String, param12));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Param_TransactionType", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TransactionType", DbType.String, param14));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param15));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tran_Status", DbType.String, param16));
                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameterTempestPurchseInvoice_Employer_Ref(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRef", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Currency_Code", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_From", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_To", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_created", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_From", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_To", DbType.String, param7));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Yr_Proc_By_Payroll", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_From", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_To", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TransactionType", DbType.String, param11));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param12));

                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameterTempestPurchseInvoice_CurrencyCode(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRef", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Currency_Code", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_From", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_To", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_created", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_From", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_To", DbType.String, param7));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Yr_Proc_By_Payroll", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_From", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_To", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TransactionType", DbType.String, param11));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param12));


                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameterTempestPurchseInvoiceViewToGrid(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRef", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Currency_Code", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_From", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@InvoiceDate_To", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_created", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_From", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_Priod_created_To", DbType.String, param7));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Yr_Proc_By_Payroll", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_From", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Proc_By_Payroll_To", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TransactionType", DbType.String, param11));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param12));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tran_Status", DbType.String, param13));
                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_MarginFinanceTeamDataForAlreadyExistCheck(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19, string param20, string param21, string param22, string param23, string param24, string param25)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param8));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromBIDDate", DbType.String, param9));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToBIDDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromPIDDate", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToPIDDate", DbType.String, param12));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_supplier_paid", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_From", DbType.String, param14));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_To", DbType.String, param15));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Year_Validated", DbType.String, param16));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_From", DbType.String, param17));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_To", DbType.String, param18));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_invoiced", DbType.String, param19));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_From", DbType.String, param20));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_To", DbType.String, param21));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_proc_by_payroll", DbType.String, param22));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_From", DbType.String, param23));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_To", DbType.String, param24));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param25));
                // command.Parameters.Add(DbProviderHelper.CreateParameter("@@MultipleClientsRefID", DbType.String, param25));


                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_MarginForViewNotMatchData(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19, string param20, string param21, string param22, string param23, string param24, string param25, string param26, string param27, string param28, string param29)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Division_code", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Department_code", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Consultant_code", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Split_percentage", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Worker_Ref", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Supplier_ref", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Client_ref", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Timesheet_number", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Timesheet_date", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Line_ref", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_period", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Rate_code", DbType.String, param12));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Split_hours", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Suppliers_Currency_Code", DbType.String, param14));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Pay_rate", DbType.String, param15));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Split_pay_amount", DbType.String, param16));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Purchase_invoice_number", DbType.String, param17));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Bill_rate", DbType.String, param18));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Split_bill_amount", DbType.String, param19));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Invoice_no", DbType.String, param20));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Assignment_actual_end_date", DbType.String, param21));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Purchase_order", DbType.String, param22));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Paid", DbType.String, param23));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_supplier_paid", DbType.String, param24));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid", DbType.String, param25));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Invoiced", DbType.String, param26));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_invoiced", DbType.String, param27));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced", DbType.String, param28));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param29));
                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_Margin(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19, string param20, string param21, string param22, string param23, string param24, string param25, string param26)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param8));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromBIDDate", DbType.String, param9));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToBIDDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromPIDDate", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToPIDDate", DbType.String, param12));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_supplier_paid", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_From", DbType.String, param14));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_To", DbType.String, param15));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Year_Validated", DbType.String, param16));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_From", DbType.String, param17));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_To", DbType.String, param18));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_invoiced", DbType.String, param19));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_From", DbType.String, param20));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_To", DbType.String, param21));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_proc_by_payroll", DbType.String, param22));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_From", DbType.String, param23));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_To", DbType.String, param24));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@MultipleClientsRefID", DbType.String, param25));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param26));


                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_MarginEntry(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19, string param20, string param21, string param22, string param23, string param24, string param25, string param26)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param8));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromBIDDate", DbType.String, param9));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToBIDDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromPIDDate", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToPIDDate", DbType.String, param12));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_supplier_paid", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_From", DbType.String, param14));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_To", DbType.String, param15));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Year_Validated", DbType.String, param16));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_From", DbType.String, param17));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_To", DbType.String, param18));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_invoiced", DbType.String, param19));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_From", DbType.String, param20));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_To", DbType.String, param21));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_proc_by_payroll", DbType.String, param22));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_From", DbType.String, param23));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_To", DbType.String, param24));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param25));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.String, param26));


                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_MarginReportFinance(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19, string param20, string param21, string param22, string param23, string param24, string param25)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param8));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromBIDDate", DbType.String, param9));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToBIDDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromPIDDate", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToPIDDate", DbType.String, param12));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_supplier_paid", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_From", DbType.String, param14));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_To", DbType.String, param15));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Year_Validated", DbType.String, param16));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_From", DbType.String, param17));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_To", DbType.String, param18));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_invoiced", DbType.String, param19));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_From", DbType.String, param20));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_To", DbType.String, param21));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_proc_by_payroll", DbType.String, param22));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_From", DbType.String, param23));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_To", DbType.String, param24));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param25));
                // command.Parameters.Add(DbProviderHelper.CreateParameter("@@MultipleClientsRefID", DbType.String, param25));


                //command.Parameters.Add(DbProviderHelper.CreateParameter("@pageNumber", DbType.Int32, param6));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_AdjustmentEntryReport(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19, string param20, string param21, string param22, string param23, string param24, string param25, string param26, string param27)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param8));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromBIDDate", DbType.String, param9));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToBIDDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromPIDDate", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToPIDDate", DbType.String, param12));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_supplier_paid", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_From", DbType.String, param14));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_To", DbType.String, param15));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Year_Validated", DbType.String, param16));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_From", DbType.String, param17));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_To", DbType.String, param18));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_invoiced", DbType.String, param19));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_From", DbType.String, param20));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_To", DbType.String, param21));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_proc_by_payroll", DbType.String, param22));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_From", DbType.String, param23));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_To", DbType.String, param24));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param25));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.String, param26));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@DefaultStatus", DbType.String, param27));

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

        public static DataSet CreateDataTableParameterConnectTwoTable(string pStoreProcedure, string DBName_S, string TableName_S, string DBName_D, string TableName_D)
        {
            DbProviderHelper.GetConnection();
            DataSet DStable = new DataSet();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@DBName_S", DbType.String, DBName_S));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TableName_S", DbType.String, TableName_S));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@DBName_D", DbType.String, DBName_D));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TableName_D", DbType.String, TableName_D));

                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(DStable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DStable.Dispose();
            }
            return DStable;
        }

        public static DataTable CreateDataTableParameterManualPaymentAdjustments(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Employer_Ref", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EffectiveDate_From", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EffectiveDate_To", DbType.String, param2));
                //command.Parameters.Add(DbProviderHelper.CreateParameter("@PeriodEndDate_From", DbType.String, param3));
                //command.Parameters.Add(DbProviderHelper.CreateParameter("@PeriodEndDate_To", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_Payroll_Calendar", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Payroll_Calendar_From", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Payroll_Calendar_To", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param6));
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

        public static DataTable CreateDataTableParameterAssignment(string pStoreProcedure, string param)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@param", DbType.String, param));
                /// AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameterByParam(string pStoreProcedure, string param0, string param1, string param2)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@param0", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@param1", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@param2", DbType.Int32, param2));
                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameterByParamAll(string pStoreProcedure, string srchType, string userID, string Personnel_Ref, string Supplier_Ref, string Client_Number, string Consultant_Code, string Office, string Division, string Assignment_Ref)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@srchType", DbType.String, srchType));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@userID", DbType.String, userID));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Personnel_Ref", DbType.String, Personnel_Ref));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Supplier_Ref", DbType.String, Supplier_Ref));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Client_Number", DbType.String, Client_Number));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Consultant_Code", DbType.String, Consultant_Code));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Office", DbType.String, Office));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Division", DbType.String, Division));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Assignment_Ref", DbType.String, Assignment_Ref));

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

        public static DataTable CreateDataTableParameter_TempestSuppliersDetails(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param1));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@LegalStatus", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@SuppliersType", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SuppliersCountry", DbType.String, param4));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@SelfBillingTF", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param6));

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

        public static DataTable CreateDataTableParameter_AdjustmentEntryReportCombine(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19, string param20, string param21, string param22, string param23, string param24, string param25, string param26)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param8));


                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromBIDDate", DbType.String, param9));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToBIDDate", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromPIDDate", DbType.String, param11));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToPIDDate", DbType.String, param12));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_supplier_paid", DbType.String, param13));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_From", DbType.String, param14));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_supplier_paid_To", DbType.String, param15));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_Year_Validated", DbType.String, param16));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_From", DbType.String, param17));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_Validated_To", DbType.String, param18));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_year_invoiced", DbType.String, param19));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_From", DbType.String, param20));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_invoiced_To", DbType.String, param21));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Tax_yr_proc_by_payroll", DbType.String, param22));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_From", DbType.String, param23));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Period_proc_by_payroll_To", DbType.String, param24));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param25));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.String, param26));


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

        public static DataTable CreateDataTableParameter_BillAmountWithPurchaseOrder(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@PurchaseOrderNo", DbType.String, param1));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantID", DbType.String, param3));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param6));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRef", DbType.String, param7));

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

        public static DataTable CreateDataTableParameter_CombineConsultantsListDetails(string pStoreProcedure, string param0)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Assignment_Ref", DbType.String, param0));

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

        public static DataTable CreateDataTableParameter_PlacementTimeSheet(string pStoreProcedure, string param0, string param1, string param2)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Assignment_Ref", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Timesheet_Number", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param2));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_NominalAccountMast(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, int param10, int param11)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@CompanyCode", DbType.String, param0));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@NominalAccount", DbType.String, param1));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@CodeElement1", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@CodeElement2", DbType.String, param3));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@CodeElement3", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@SubAnalysisReq", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ProtectedAccount", DbType.String, param6));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@SubAnalCategory", DbType.String, param7));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@CurrRealignment", DbType.String, param8));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@SecondAccountCode", DbType.String, param9));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@PageNo", DbType.Int32, param10));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@PageSize", DbType.Int32, param11));

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

        public static DataTable CreateDataTableParameter_MoreSuppliersDetails(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@AssignmentRefID", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param6));

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

        public static DataTable CreateDataTableParameterWokerDetails(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployeeStatus", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@MatchingCurrencyStatus", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Employment_Type", DbType.String, param9));

                //AddParameter(command, "@param", DbType.Int32, param);
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

        public static DataTable CreateDataTableParameter_MoreClientDetails(string pStoreProcedure, string param0, string param1, string param2, string param3)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param0));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param1));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantRefID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param3));

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

        public static DataTable CreateDataTableParameter_MoreConsultantsListDetails(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param4));

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

        public static DataTable CreateDataTableParameter_NominalTransactionsView(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14, string param15, string param16, int param17, int param18, string param19, string param20)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@AccountCodeFrom", DbType.String, param1));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@AccountCodeTo", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@SubAnalysisCodeFrom", DbType.String, param3));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@SubAnalysisCodeTo", DbType.String, param4));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FROMDATE", DbType.String, param5));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@TODATE", DbType.String, param6));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@YEAR", DbType.String, param7));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@PERIOD_FROM", DbType.String, param8));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@PERIOD_TO", DbType.String, param9));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserId", DbType.String, param10));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@YEARTo", DbType.String, param11));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@OriginLedger", DbType.String, param12));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@FolioNumber", DbType.String, param13));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@TeamFrom", DbType.String, param14));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@TeamTo", DbType.String, param15));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Office", DbType.String, param16));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@PageNo", DbType.Int32, param17));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@PageSize", DbType.Int32, param18));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@OurRef", DbType.String, param19));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@TransactionCurr", DbType.String, param20));

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

        public static DataTable DataTableParameter_TempestAuditReport(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, int param5, int param6)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Table_Name", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Action", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@RowID", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ActionDate_From", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ActionDate_To", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@PageNo", DbType.Int32, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@PageSize", DbType.Int32, param6));
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

        public static DataTable CreateDataTableParameter_MoreClientDetails(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param0));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param1));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantRefID", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@AssignmentRefID", DbType.String, param3));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param4));

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

        public static DataTable CreateDataTableParameter_TPDocumentsList(string pStoreProcedure, string param0, string param1, string param2, string param3)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@CompanyCode", DbType.String, param0));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@AccountNo", DbType.String, param1));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@DocumentType", DbType.String, param2));

                command.Parameters.Add(DbProviderHelper.CreateParameter("@AttachedTo", DbType.String, param3));



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

        public static DataTable CreateDataTableParameter_RateDetails(string pStoreProcedure, string param0)
        {

            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@AssignmentRef", DbType.String, param0));

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

        public static DataTable CreateDataTable_MoreWorkerDetails(string pStoreProcedure, string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployerID", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DivisionID", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@DepartmentID", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@WorkerRefID", DbType.String, param3));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SupplierRefID", DbType.String, param4));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClientsRefID", DbType.String, param5));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ConsultantRefID", DbType.String, param6));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@AssignmentRefID", DbType.String, param7));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.String, param8));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@EmployeeStatus ", DbType.String, param9));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@MatchingCurrencyStatus  ", DbType.String, param10));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Employment_Type  ", DbType.String, param11));
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

        public static DataTable CreateDataTableParameter_InvitedVisitorPresenceEntry(string pStoreProcedure, string param0, string param1, string param2)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Date", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@VisitorType", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SearchBox", DbType.String, param2));
         

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
     
         
         public static DataTable CreateDataTableParameter_UnitInfoByOnwer(string pStoreProcedure, int param0)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@OwnerID", DbType.String, param0));
              
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

    }
}
