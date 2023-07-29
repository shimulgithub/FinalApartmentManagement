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
    public partial class EmployeeDutyInformation : System.Web.UI.Page
    {

        EmployeeDutyInformationBLL oEmployeeDutyInformationBLL = new EmployeeDutyInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    Session["breadcrumb"] = "Settings>Employee Duty Entry";
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                    ddlDesignation.Enabled = true;
                    BindList();
                    LoadDesignationID();
                    LoadEmployeeID();
                    //LoadDutyID();
                }

                // this.RegisterPostBackControl();

            }
            else
            {
                Response.Redirect("~/UserLogin_Logout.aspx");
            }
        }
        //private void LoadDutyID()
        //{
        //    DataTable dt = new DataTable();
        //    string sql = "SP_TB_AMS_DutyTypeListDDL";
        //    dt = AMS.Common.Global.CreateDataTable(sql);

        //    ddlDutyType.DataSource = dt;
        //    ddlDutyType.DataTextField = "DutyType";
        //    ddlDutyType.DataValueField = "AutoID";
        //    ddlDutyType.DataBind();


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



            EmployeeDutyInformationBOL entity = new EmployeeDutyInformationBOL();

            entity.EmployeeID = ddlEmployeeID.SelectedValue;
            entity.DesignationID = ddlEmployeeID.SelectedValue;
            //entity.DutyTypeID = ddlDutyType.SelectedValue;

            entity.DutyStartTime = txtStartTime.Text;
            entity.DutyEndTime = txtDutyEndTime.Text;
            

            if (txtStartDate.Text != "")
            {
                DateTime dtpJoiningDate = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
                entity.DutyStartDate = JoiningDate;
            }
            else
            {
                entity.DutyStartDate = Convert.ToDateTime("01/01/1991");

            }

            if (txtDutyEndDate.Text != "")
            {
                DateTime dtpEndDate = DateTime.ParseExact(txtDutyEndDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime txtEndDate = Convert.ToDateTime(dtpEndDate.ToString("yyyy-MM-dd"));
                entity.DutyEndDate = txtEndDate;
            }
            else
            {
                entity.DutyEndDate = Convert.ToDateTime("01/01/1991");

            }


            Int32 Id = 0;
            if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
            {
                entity.CreateBy = Session["UserID"].ToString();

                //Save record
                Id = oEmployeeDutyInformationBLL.EmployeeDutyInformation_Add(entity);
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


                Id = oEmployeeDutyInformationBLL.EmployeeDutyInformation_Update(entity);

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
            DataTable dt = oEmployeeDutyInformationBLL.EmployeeDutyInformation_GetDataForGV();

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
            EmployeeDutyInformationBOL oEmployeeDutyInformation = new EmployeeDutyInformationBOL();
            Int32 Id = Convert.ToInt32(gvEmployeeInformationList.DataKeys[e.NewEditIndex].Value);
            oEmployeeDutyInformation.AutoID = Id;

            oEmployeeDutyInformation = oEmployeeDutyInformationBLL.EmployeeDutyInformation_GetById(oEmployeeDutyInformation);
            SetDataToControls(oEmployeeDutyInformation);

        }
        private void SetDataToControls(EmployeeDutyInformationBOL oEmployeeDutyInformation)
        {

            try
            {
                ddlEmployeeID.SelectedValue = oEmployeeDutyInformation.EmployeeID.ToString();
            }
            catch
            {
                ddlEmployeeID.SelectedValue = "0";
            }

            try
            {

                ddlDesignation.SelectedValue = oEmployeeDutyInformation.DesignationID.ToString();
            }
            catch
            {
                ddlDesignation.SelectedValue = "0";
            }

            //try
            //{


            //    ddlDutyType.SelectedValue = oEmployeeDutyInformation.DutyTypeID.ToString();
            //}
            //catch
            //{
            //    ddlDutyType.SelectedValue = "0";
            //}
            try
            {
                txtStartDate.Text = oEmployeeDutyInformation.DutyStartDateBind.ToString();
            }
            catch
            {
                txtStartDate.Text = "";
            }

            try
            {
                txtStartTime.Text = oEmployeeDutyInformation.DutyStartTime.ToString();
            }
            catch
            {
                txtStartTime.Text = "";
            }


            try
            {
                txtDutyEndDate.Text = oEmployeeDutyInformation.DutyEndDateBind.ToString();
            }
            catch
            {
                txtDutyEndDate.Text = "";
            }

            try
            {
                txtDutyEndTime.Text = oEmployeeDutyInformation.DutyEndTime.ToString();
            }
            catch
            {
                txtDutyEndTime.Text = "";
            }

            hfAutoId.Value = oEmployeeDutyInformation.AutoID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }
        private void Clear()
        {
        //    txtEmpName.Text = "";

            ddlEmployeeID.SelectedValue = "0";
          
            ////txtEmailID.Text = "";
            //txtContact.Text = "";
            //txtNID.Text = "";
           // txtSalary.Text = "";
            //txtPresentAdress.Text = "";
            //txtPermanentAdress.Text = "";
            ddlDesignation.SelectedValue = "0";
            ddlDesignation.Enabled = true;
            //txtJoiningDate.Text = "";
            //chkIsActive.Checked = false;
            hfAutoId.Value = "0";
            //chkIsActive.Checked = false;
            btnsave.Visible = true;
            btnupdate.Visible = false;

        }
        protected void gvEmployeeInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            EmployeeDutyInformationBOL entity = new EmployeeDutyInformationBOL();
            Int32 Id = Convert.ToInt32(gvEmployeeInformationList.DataKeys[e.RowIndex].Value);
            entity.AutoID = Id;



            int success = oEmployeeDutyInformationBLL.EmployeeDutyInformation_Delete(entity);
            if (success > 0)
            {
                BindList();
            }
        }

      
    }
}