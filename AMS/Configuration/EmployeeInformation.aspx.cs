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
    public partial class EmployeeInformation : System.Web.UI.Page
    {

        EmployeeInformationBLL oEmployeeInformationBLL = new EmployeeInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    Session["breadcrumb"] = "Settings>Employee Information";
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                    BindList();

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
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Clear();


        }
        private void Save()
        {



            EmployeeInformationBOL entity = new EmployeeInformationBOL();

            entity.Name = txtEmpName.Text;
            entity.Email = txtEmailID.Text;
            entity.Contact = txtContact.Text;

            entity.NIDNo = txtNID.Text;


            if (txtJoiningDate.Text != "")
            {
                DateTime dtpJoiningDate = DateTime.ParseExact(txtJoiningDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
                entity.JoiningDate = JoiningDate;
            }
            else
            {
                entity.JoiningDate = Convert.ToDateTime("01/01/1991");

            }
            entity.Designation = ddlDesignation.SelectedValue;
            entity.SalaryPerMonth = Convert.ToInt32(txtSalary.Text);
            entity.PresentAddress = txtPresentAdress.Text;
            entity.PermanentAddress = txtPermanentAdress.Text;



            if (chkIsActive.Checked == true)
            {
                entity.IsActive = true;
            }
            else
            {
                entity.IsActive = false;
            }


            Int32 Id = 0;
            if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
            {


                //Save record
                Id = oEmployeeInformationBLL.EmployeeInformation_Add(entity);
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

                Id = oEmployeeInformationBLL.EmployeeInformation_Update(entity);

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
            DataTable dt = oEmployeeInformationBLL.EmployeeInformation_GetDataForGV();

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
            EmployeeInformationBOL oEmployeeInformation = new EmployeeInformationBOL();
            Int32 Id = Convert.ToInt32(gvEmployeeInformationList.DataKeys[e.NewEditIndex].Value);
            oEmployeeInformation.AutoID = Id;

            oEmployeeInformation = oEmployeeInformationBLL.EmployeeInformation_GetById(oEmployeeInformation);
            SetDataToControls(oEmployeeInformation);

        }
        private void SetDataToControls(EmployeeInformationBOL oEmployeeInformation)
        {

            try
            {
                txtEmpName.Text = oEmployeeInformation.Name.ToString();
            }
            catch
            {
                txtEmpName.Text = "";
            }

            try
            {
                txtEmailID.Text = oEmployeeInformation.Email.ToString();
            }
            catch
            {
                txtEmailID.Text = "";
            }

            try
            {
                txtContact.Text = oEmployeeInformation.Contact.ToString();
            }
            catch
            {
                txtContact.Text = "";
            }

            try
            {
                txtNID.Text = oEmployeeInformation.NIDNo.ToString();
            }
            catch
            {
                txtNID.Text = "";
            }


            try
            {
                txtSalary.Text = oEmployeeInformation.SalaryPerMonth.ToString();
            }
            catch
            {
                txtSalary.Text = "";
            }

            try
            {
                txtPresentAdress.Text = oEmployeeInformation.PresentAddress.ToString();
            }
            catch
            {
                txtPresentAdress.Text = "";
            }

            try
            {
                txtPermanentAdress.Text = oEmployeeInformation.PermanentAddress.ToString();
            }
            catch
            {
                txtPermanentAdress.Text = "";
            }

            try
            {
                ddlDesignation.SelectedValue = oEmployeeInformation.Designation.ToString();
            }
            catch
            {
                ddlDesignation.SelectedValue = "0";
            }


            try
            {
                txtJoiningDate.Text = oEmployeeInformation.JoiningDateBind.ToString();
            }
            catch
            {
                txtJoiningDate.Text = "";
            }

            if (oEmployeeInformation.IsActive == true)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            hfAutoId.Value = oEmployeeInformation.AutoID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }
        private void Clear()
        {
            txtEmpName.Text = "";
            txtEmailID.Text = "";
            txtContact.Text = "";
            txtNID.Text = "";
            txtSalary.Text = "";
            txtPresentAdress.Text = "";
            txtPermanentAdress.Text = "";
            ddlDesignation.SelectedValue = "0";
            txtJoiningDate.Text = "";
            chkIsActive.Checked = false;
            hfAutoId.Value = "0";
            chkIsActive.Checked = false;
            btnsave.Visible = true;
            btnupdate.Visible = false;

        }
        protected void gvEmployeeInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            EmployeeInformationBOL entity = new EmployeeInformationBOL();
            Int32 Id = Convert.ToInt32(gvEmployeeInformationList.DataKeys[e.RowIndex].Value);
            entity.AutoID = Id;



            int success = oEmployeeInformationBLL.EmployeeInformation_Delete(entity);
            if (success > 0)
            {
                BindList();
            }
        }

      
    }
}