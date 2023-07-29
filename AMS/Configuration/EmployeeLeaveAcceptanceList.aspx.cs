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
    public partial class EmployeeLeaveAcceptanceList : System.Web.UI.Page
    {

        EmployeeLeaveInformationBLL oEmployeeLeaveInformationBLL = new EmployeeLeaveInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    Session["breadcrumb"] = "Settings>Employee Leave Request";
                    //btnsave.Visible = true;
                    //btnupdate.Visible = false;
                    //ddlDesignation.Enabled = true;
                    BindList();
                    //LoadDesignationID();
                    LoadEmployeeID();
                    //LoadLeaveID();
                }

                // this.RegisterPostBackControl();

            }
            else
            {
                Response.Redirect("~/UserLogin_Logout.aspx");
            }
        }
        //private void LoadLeaveID()
        //{
        //    DataTable dt = new DataTable();
        //    string sql = "SP_TB_AMS_LeaveTypeListDDL";
        //    dt = AMS.Common.Global.CreateDataTable(sql);

        //    ddlLeaveType.DataSource = dt;
        //    ddlLeaveType.DataTextField = "LeaveType";
        //    ddlLeaveType.DataValueField = "AutoID";
        //    ddlLeaveType.DataBind();


        //}
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
        //private void LoadDesignationID()
        //{
        //    DataTable dt = new DataTable();
        //    string sql = "SP_TB_AMS_DesignationListDDL";
        //    dt = AMS.Common.Global.CreateDataTable(sql);

        //    //ddlDesignation.DataSource = dt;
        //    //ddlDesignation.DataTextField = "DesignationName";
        //    //ddlDesignation.DataValueField = "AutoID";
        //    //ddlDesignation.DataBind();


        //}
        protected void ddlEmployerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if ( ddlEmployeeID.SelectedValue != "0")
            //{
            //    DataTable dt = new DataTable();
            //    string sql = "SP_TB_AMS_EmployeeListByEmpID";
            //    dt = AMS.Common.Global.CreateDataTableParameter(sql, ddlEmployeeID.SelectedValue);
            //    if (dt.Rows.Count > 0)
            //    {
            //        ddlDesignation.SelectedValue = dt.Rows[0]["Designation"].ToString();
            //        ddlDesignation.Enabled = false;
            //    }
            //}
           
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            Save();


        }

        protected void btnAproved_Click(object sender, EventArgs e)
        {
            LinkButton btnprintGrv = sender as LinkButton;

            GridViewRow Grow = (GridViewRow)btnprintGrv.NamingContainer;
            string lblInTime = (Grow.FindControl("lblLeaveStartTime") as Label).Text;
            string lblIOutTime = (Grow.FindControl("lblLeaveEndTime") as Label).Text;
            string lblStartDate = (Grow.FindControl("lblLeaveStartDate") as Label).Text;
            string lblEndDate = (Grow.FindControl("lblLeaveEndDate") as Label).Text;
            txtStartTime.Text = lblInTime;
            txtEndTime.Text = lblIOutTime;
            txtLeaveStartDate.Text = lblStartDate;
            txtEndDate.Text = lblEndDate;

            string AutoID = Server.UrlEncode(btnprintGrv.CommandArgument);
            hfAutoId.Value = AutoID;

            mp1.Show();

        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            EmployeeLeaveInformationBOL entity = new EmployeeLeaveInformationBOL();

            LinkButton btnprintGrv = sender as LinkButton;

            GridViewRow Grow = (GridViewRow)btnprintGrv.NamingContainer;

            string AutoID = Server.UrlEncode(btnprintGrv.CommandArgument);
            hfAutoId.Value = AutoID;
              Int32 Id = 0;
             
                entity.AutoID = Convert.ToInt32(hfAutoId.Value);

                entity.ChangedBy = Session["UserID"].ToString();


                Id = oEmployeeLeaveInformationBLL.EmployeeLeaveInformation_UpdateForCancel(entity);

                if (Id > 0)
                {

                    string myScript123 = "";
                    myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                    Clear();
                    BindList();
                }
            

        }
        protected void btnDone_Click(object sender, EventArgs e)
        {
            EmployeeLeaveInformationBOL entity = new EmployeeLeaveInformationBOL();
            if (txtLeaveStartDate.Text != "")
            {
                DateTime dtpJoiningDate = DateTime.ParseExact(txtLeaveStartDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
                entity.LeaveStartDate = JoiningDate;
            }
            else
            {
                entity.LeaveStartDate = Convert.ToDateTime("01/01/1991");

            }

            if (txtEndDate.Text != "")
            {
                DateTime dtpEndDate = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime txtEndDate1 = Convert.ToDateTime(dtpEndDate.ToString("yyyy-MM-dd"));
                entity.LeaveEndDate = txtEndDate1;
            }
            else
            {
                entity.LeaveEndDate = Convert.ToDateTime("01/01/1991");

            }
            entity.LeaveStartTime = txtStartTime.Text;
            entity.LeaveEndTime = txtEndTime.Text;


              Int32 Id = 0;
             
                entity.AutoID = Convert.ToInt32(hfAutoId.Value);

                entity.ChangedBy = Session["UserID"].ToString();


                Id = oEmployeeLeaveInformationBLL.EmployeeLeaveInformation_UpdateByParam(entity);

                if (Id > 0)
                {

                    string myScript123 = "";
                    myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                    Clear();
                    BindList();
                }
            

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
            //entity.LeaveTypeID = ddlLeaveType.SelectedValue;

            //entity.LeaveStartTime = txtStartTime.Text;
            //entity.LeaveEndTime = txtLeaveEndTime.Text;
            

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

            //try
            //{
            //    ddlEmployeeID.SelectedValue = oEmployeeLeaveInformation.EmployeeID.ToString();
            //}
            //catch
            //{
            //    ddlEmployeeID.SelectedValue = "0";
            //}

            //try
            //{

            //    ddlDesignation.SelectedValue = oEmployeeLeaveInformation.DesignationID.ToString();
            //}
            //catch
            //{
            //    ddlDesignation.SelectedValue = "0";
            //}

            //try
            //{


            //    ddlLeaveType.SelectedValue = oEmployeeLeaveInformation.LeaveTypeID.ToString();
            //}
            //catch
            //{
            //    ddlLeaveType.SelectedValue = "0";
            //}
            //try
            //{
            //    txtStartDate.Text = oEmployeeLeaveInformation.LeaveStartDateBind.ToString();
            //}
            //catch
            //{
            //    txtStartDate.Text = "";
            //}

            //try
            //{
            //    txtStartTime.Text = oEmployeeLeaveInformation.LeaveStartTime.ToString();
            //}
            //catch
            //{
            //    txtStartTime.Text = "";
            //}


            //try
            //{
            //    txtLeaveEndDate.Text = oEmployeeLeaveInformation.LeaveEndDateBind.ToString();
            //}
            //catch
            //{
            //    txtLeaveEndDate.Text = "";
            //}

            //try
            //{
            //    txtLeaveEndTime.Text = oEmployeeLeaveInformation.LeaveEndTime.ToString();
            //}
            //catch
            //{
            //    txtLeaveEndTime.Text = "";
            //}

            hfAutoId.Value = oEmployeeLeaveInformation.AutoID.ToString();

            //btnsave.Visible = false;
            //btnupdate.Visible = true;
        }
        private void Clear()
        {
        //    txtEmpName.Text = "";

            ddlEmployeeID.SelectedValue = "0";
          
            //txtEmailID.Text = "";
            //txtContact.Text = "";
            //txtNID.Text = "";
           // txtSalary.Text = "";
            //txtPresentAdress.Text = "";
            //txtPermanentAdress.Text = "";
            //ddlDesignation.SelectedValue = "0";
            //ddlDesignation.Enabled = true;
            //txtJoiningDate.Text = "";
            //chkIsActive.Checked = false;
             hfAutoId.Value = "0";
            //chkIsActive.Checked = false;
            //btnsave.Visible = true;
            //btnupdate.Visible = false;

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