using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using AMS.BOL.Configuration;
using AMS.BLL.Configuration;
using System.Data.SqlClient;
using System.IO;
using  AMS.Common;

using System.Web;

namespace AMS.Configuration
{
    public partial class EmployeeSalaryInformation : System.Web.UI.Page
    {

        EmployeeSalaryInformationBLL oEmployeeSalaryInformationBLL = new EmployeeSalaryInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    Session["breadcrumb"] = "Settings>Employee Salary Information";
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                    BindList();
                    LoadEmployeeID();
                    LoadDesignationID();

                }

                // this.RegisterPostBackControl();

            }
            else
            {
                Response.Redirect("~/UserLogin_Logout.aspx");
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            Save();


        }
        private void LoadEmployeeID()
        {
            DataTable dt = new DataTable();
            string sql = "SP_TB_AMS_EmployeeListDDL";
            dt = AMS.Common.Global.CreateDataTable(sql);

            ddlEmployeeID.DataSource = dt;
            ddlEmployeeID.DataTextField = "Name";
            ddlEmployeeID.DataValueField = "AutoID";
            ddlEmployeeID.DataBind();


        }



        private void LoadDesignationID()
        {
            DataTable dt = new DataTable();
            string sql = "SP_TB_AMS_DesignationListDDL";
            dt = AMS.Common.Global.CreateDataTable(sql);

            ddlDesignation.DataSource = dt;
            ddlDesignation.DataTextField = "DesignationName";
            ddlDesignation.DataValueField = "AutoID";
            ddlDesignation.DataBind();


        }


        protected void btnNew_Click(object sender, EventArgs e)
        {
            Clear();


        }
        private void Save()
        {



            EmployeeSalaryInformationBOL entity = new EmployeeSalaryInformationBOL();

            entity.EmployeeID = ddlEmployeeID.SelectedValue;
            entity.DesignationID = ddlEmployeeID.SelectedValue;
            entity.SalaryMonthName = ddSalaryMonthName.SelectedValue;
            entity.SalaryAmount = txtSalary.Text;
            entity.Year = ddlSalaryYear.SelectedValue;


            if (txtIssueDate.Text != "")
            {
                DateTime dtpJoiningDate = DateTime.ParseExact(txtIssueDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
                entity.IssueDate = JoiningDate;
            }
            else
            {
                entity.IssueDate = Convert.ToDateTime("01/01/1991");

            }

            Int32 Id = 0;
            if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
            {
                entity.CreateBy = Session["UserID"].ToString();

                //Save record
                Id = oEmployeeSalaryInformationBLL.EmployeeSalaryInformation_Add(entity);
                if (Id > 0)
                {
                    string myScript123 = "";
                    myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                    Clear();
                    BindList();
                }
            }
            else
            {
                //Update record          
                entity.AutoID = Convert.ToInt32(hfAutoId.Value);

                entity.ChangedBy = Session["UserID"].ToString();


                Id = oEmployeeSalaryInformationBLL.EmployeeSalaryInformation_Update(entity);

                if (Id > 0)
                {

                    string myScript123 = "";
                    myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                    Clear();
                    BindList();
                }
            }

        }
        private void BindList()
        {
            //List<User> userList = oUserBLL.User_GetAll();
            DataTable dt = oEmployeeSalaryInformationBLL.EmployeeSalaryInformation_GetDataForGV();

            gvEmployeeSalaryInformationList.DataSource = dt;
            gvEmployeeSalaryInformationList.DataBind();
        }
        protected void gvEmployeeSalaryInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
            //tContUser.ActiveTabIndex = 1;
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            EmployeeSalaryInformationBOL oEmployeeSalaryInformation = new EmployeeSalaryInformationBOL();
            Int32 Id = Convert.ToInt32(gvEmployeeSalaryInformationList.DataKeys[e.NewEditIndex].Value);
            oEmployeeSalaryInformation.AutoID = Id;

            oEmployeeSalaryInformation = oEmployeeSalaryInformationBLL.EmployeeSalaryInformation_GetById(oEmployeeSalaryInformation);
            SetDataToControls(oEmployeeSalaryInformation);

        }
        private void SetDataToControls(EmployeeSalaryInformationBOL oEmployeeSalaryInformation)
        {

            try
            {
                ddlEmployeeID.SelectedValue = oEmployeeSalaryInformation.EmployeeID.ToString();
            }
            catch
            {
                ddlEmployeeID.SelectedValue = "0";
            }

            try
            {

                ddlDesignation.SelectedValue = oEmployeeSalaryInformation.DesignationID.ToString();
            }
            catch
            {
                ddlDesignation.SelectedValue = "0";
            }


            try
            {

                ddSalaryMonthName.SelectedValue = oEmployeeSalaryInformation.SalaryMonthName.ToString();
            }
            catch
            {
                ddSalaryMonthName.SelectedValue = "0";
            }

            try
            {


                ddlSalaryYear.SelectedValue = oEmployeeSalaryInformation.Year.ToString();
            }
            catch
            {
                ddlSalaryYear.SelectedValue = "0";
            }


            try
            {
                txtSalary.Text = oEmployeeSalaryInformation.SalaryAmount.ToString();
            }
            catch
            {
                txtSalary.Text = "";
            }

            try
            {
                txtIssueDate.Text = oEmployeeSalaryInformation.IssueDateBind.ToString();
            }
            catch
            {
                txtIssueDate.Text = "";
            }

            hfAutoId.Value = oEmployeeSalaryInformation.AutoID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;



        }
        private void Clear()
        {

            ddlEmployeeID.SelectedValue = "0";
            ddlDesignation.SelectedValue = "0";
            ddlSalaryYear.SelectedValue = "0";
            ddSalaryMonthName.SelectedValue = "0";
            txtSalary.Text = "";
            txtIssueDate.Text = string.Empty;
            hfAutoId.Value = "0";
            btnsave.Visible = true;
            btnupdate.Visible = false;

        }
        protected void gvEmployeeSalaryInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            EmployeeSalaryInformationBOL entity = new EmployeeSalaryInformationBOL();
            Int32 Id = Convert.ToInt32(gvEmployeeSalaryInformationList.DataKeys[e.RowIndex].Value);
            entity.AutoID = Id;



            int success = oEmployeeSalaryInformationBLL.EmployeeSalaryInformation_Delete(entity);
            if (success > 0)
            {
                BindList();
            }
        }
        protected void ddlEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmployeeID.SelectedValue != "0")
            {
                DataTable dt = new DataTable();
                string sql = "SP_TB_AMS_EmployeeInformationListByAutoID";
                dt = Global.CreateDataTableParameter(sql, ddlEmployeeID.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    ddlDesignation.SelectedValue = dt.Rows[0]["Designation"].ToString();

                    txtSalary.Text = dt.Rows[0]["SalaryPerMonth"].ToString();
                }
            }
        }


    }
}