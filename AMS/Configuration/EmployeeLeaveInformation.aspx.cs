using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using AMS.BOL.Configuration;
using AMS.BLL.Configuration;
using System.Data.SqlClient;
using System.IO;

using System.Web;

namespace AMS.Configuration
{
    public partial class EmployeeLeaveInformation : System.Web.UI.Page
    {

        EmployeeLeaveInformationBLL oEmployeeLeaveInformationBLL = new EmployeeLeaveInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    Session["breadcrumb"] = "Settings>Employee Leave Entry";
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                    ddlDesignation.Enabled = true;
                    BindList();
                    LoadDesignationID();
                    LoadEmployeeID();
                    LoadLeaveID();
                }

                // this.RegisterPostBackControl();

            }
            else
            {
                Response.Redirect("~/UserLogin_Logout.aspx");
            }
        }
        private void LoadLeaveID()
        {
            DataTable dt = new DataTable();
            string sql = "SP_TB_AMS_LeaveTypeListDDL";
            dt = AMS.Common.Global.CreateDataTable(sql);

            ddlLeaveType.DataSource = dt;
            ddlLeaveType.DataTextField = "LeaveType";
            ddlLeaveType.DataValueField = "AutoID";
            ddlLeaveType.DataBind();


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
        protected void ddlEmployerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( ddlEmployeeID.SelectedValue != "0")
            {
                DataTable dt = new DataTable();
                string sql = "SP_TB_AMS_EmployeeListByEmpID";
                dt = AMS.Common.Global.CreateDataTableParameter(sql, ddlEmployeeID.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    ddlDesignation.SelectedValue = dt.Rows[0]["Designation"].ToString();
                    ddlDesignation.Enabled = false;
                }
            }
           
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            Save();


        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Clear();


        }
        private void Save()
        {



            EmployeeLeaveInformationBOL entity = new EmployeeLeaveInformationBOL();

            entity.EmployeeID = ddlEmployeeID.SelectedValue;
            entity.DesignationID = ddlEmployeeID.SelectedValue;
            entity.LeaveTypeID = ddlLeaveType.SelectedValue;

            entity.LeaveStartTime = txtStartTime.Text;
            entity.LeaveEndTime = txtLeaveEndTime.Text;
            

            if (txtStartDate.Text != "")
            {
                DateTime dtpJoiningDate = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
                entity.LeaveStartDate = JoiningDate;
            }
            else
            {
                entity.LeaveStartDate = Convert.ToDateTime("01/01/1991");

            }

            if (txtLeaveEndDate.Text != "")
            {
                DateTime dtpEndDate = DateTime.ParseExact(txtLeaveEndDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime txtEndDate = Convert.ToDateTime(dtpEndDate.ToString("yyyy-MM-dd"));
                entity.LeaveEndDate = txtEndDate;
            }
            else
            {
                entity.LeaveEndDate = Convert.ToDateTime("01/01/1991");

            }


            Int32 Id = 0;
            if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
            {
                entity.CreateBy = Session["UserID"].ToString();

                //Save record
                Id = oEmployeeLeaveInformationBLL.EmployeeLeaveInformation_Add(entity);
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


                Id = oEmployeeLeaveInformationBLL.EmployeeLeaveInformation_Update(entity);

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
            DataTable dt = oEmployeeLeaveInformationBLL.EmployeeLeaveInformation_GetDataForGV();

            gvEmployeeInformationList.DataSource = dt;
            gvEmployeeInformationList.DataBind();
        }
        protected void gvEmployeeInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
            //tContUser.ActiveTabIndex = 1;
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            EmployeeLeaveInformationBOL oEmployeeLeaveInformation = new EmployeeLeaveInformationBOL();
            Int32 Id = Convert.ToInt32(gvEmployeeInformationList.DataKeys[e.NewEditIndex].Value);
            oEmployeeLeaveInformation.AutoID = Id;

            oEmployeeLeaveInformation = oEmployeeLeaveInformationBLL.EmployeeLeaveInformation_GetById(oEmployeeLeaveInformation);
            SetDataToControls(oEmployeeLeaveInformation);

        }
        private void SetDataToControls(EmployeeLeaveInformationBOL oEmployeeLeaveInformation)
        {

            try
            {
                ddlEmployeeID.SelectedValue = oEmployeeLeaveInformation.EmployeeID.ToString();
            }
            catch
            {
                ddlEmployeeID.SelectedValue = "0";
            }

            try
            {

                ddlDesignation.SelectedValue = oEmployeeLeaveInformation.DesignationID.ToString();
            }
            catch
            {
                ddlDesignation.SelectedValue = "0";
            }

            try
            {


                ddlLeaveType.SelectedValue = oEmployeeLeaveInformation.LeaveTypeID.ToString();
            }
            catch
            {
                ddlLeaveType.SelectedValue = "0";
            }
            try
            {
                txtStartDate.Text = oEmployeeLeaveInformation.LeaveStartDateBind.ToString();
            }
            catch
            {
                txtStartDate.Text = "";
            }

            try
            {
                txtStartTime.Text = oEmployeeLeaveInformation.LeaveStartTime.ToString();
            }
            catch
            {
                txtStartTime.Text = "";
            }


            try
            {
                txtLeaveEndDate.Text = oEmployeeLeaveInformation.LeaveEndDateBind.ToString();
            }
            catch
            {
                txtLeaveEndDate.Text = "";
            }

            try
            {
                txtLeaveEndTime.Text = oEmployeeLeaveInformation.LeaveEndTime.ToString();
            }
            catch
            {
                txtLeaveEndTime.Text = "";
            }

            hfAutoId.Value = oEmployeeLeaveInformation.AutoID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }
        private void Clear()
        {

            txtStartDate.Text = string.Empty;
            txtLeaveEndDate.Text = string.Empty;
            ddlEmployeeID.SelectedValue = "0";
            ddlDesignation.SelectedValue = "0";
            ddlDesignation.Enabled = true;
            hfAutoId.Value = "0";
            btnsave.Visible = true;
            btnupdate.Visible = false;

        }
        protected void gvEmployeeInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            EmployeeLeaveInformationBOL entity = new EmployeeLeaveInformationBOL();
            Int32 Id = Convert.ToInt32(gvEmployeeInformationList.DataKeys[e.RowIndex].Value);
            entity.AutoID = Id;



            int success = oEmployeeLeaveInformationBLL.EmployeeLeaveInformation_Delete(entity);
            if (success > 0)
            {
                BindList();
            }
        }


      
    }
}