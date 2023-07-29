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
    public partial class MaintenanceCostEntry : System.Web.UI.Page
    {

        MaintenanceCostInformationBLL oMaintenanceCostInformationBLL = new MaintenanceCostInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    Session["breadcrumb"] = "Settings>Maintenance Cost  Entry";
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                    BindList();
                   
                }

                
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



            MaintenanceCostInformationBOL entity = new MaintenanceCostInformationBOL();

            entity.CostTitle = txtCostTitle.Text;
            //entity.Month = ddlMontName.SelectedValue;
            //entity.Year = ddlYear.SelectedValue;

            entity.TotalAmount = txtTotalAmount.Text;
            entity.Remarks = txtRemarks.Text;


            if (txtDate.Text != "")
            {
                DateTime dtpJoiningDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
                entity.Date = JoiningDate;
            }
            else
            {
                entity.Date = Convert.ToDateTime("01/01/1991");

            }

         


            Int32 Id = 0;
            if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
            {
                entity.CreateBy = Session["UserID"].ToString();

                //Save record
                Id = oMaintenanceCostInformationBLL.MaintenanceCostInformation_Add(entity);
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


                Id = oMaintenanceCostInformationBLL.MaintenanceCostInformation_Update(entity);

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

            DataTable dt = oMaintenanceCostInformationBLL.MaintenanceCostInformation_GetDataForGV();

            gvMaintenanceCostInformationList.DataSource = dt;
            gvMaintenanceCostInformationList.DataBind();
        }
        protected void gvMaintenanceCostInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
            //tContUser.ActiveTabIndex = 1;
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            MaintenanceCostInformationBOL oMaintenanceCostInformation = new MaintenanceCostInformationBOL();
            Int32 Id = Convert.ToInt32(gvMaintenanceCostInformationList.DataKeys[e.NewEditIndex].Value);
            oMaintenanceCostInformation.AutoID = Id;

            oMaintenanceCostInformation = oMaintenanceCostInformationBLL.MaintenanceCostInformation_GetById(oMaintenanceCostInformation);
            SetDataToControls(oMaintenanceCostInformation);

        }
        private void SetDataToControls(MaintenanceCostInformationBOL oMaintenanceCostInformation)
        {

            try
            {
                txtCostTitle.Text = oMaintenanceCostInformation.CostTitle.ToString();
            }
            catch
            {
                txtCostTitle.Text = string.Empty;
            }

            try
            {

                txtDate.Text = oMaintenanceCostInformation.DateBind.ToString();
            }
            catch
            {
                txtDate.Text = string.Empty;
            }

            //try
            //{


            //    ddlMontName.SelectedValue = oMaintenanceCostInformation.Month.ToString();
            //}
            //catch
            //{
            //    ddlMontName.SelectedValue = "0";
            //}
            //try
            //{
            //    ddlYear.SelectedValue = oMaintenanceCostInformation.Year.ToString();
            //}
            //catch
            //{
            //    ddlYear.SelectedValue = "0";
            //}

            try
            {
                txtTotalAmount.Text = oMaintenanceCostInformation.TotalAmount.ToString();
            }
            catch
            {
                txtTotalAmount.Text = string.Empty;
            }


            try
            {
                txtRemarks.Text = oMaintenanceCostInformation.Remarks.ToString();
            }
            catch
            {
                txtRemarks.Text = "";
            }

          
            hfAutoId.Value = oMaintenanceCostInformation.AutoID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }
        private void Clear()
        {
        //    txtEmpName.Text = "";

            //ddlEmployeeID.SelectedValue = "0";
          
            //////txtEmailID.Text = "";
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
            btnsave.Visible = true;
            btnupdate.Visible = false;

        }
        protected void gvMaintenanceCostInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            MaintenanceCostInformationBOL entity = new MaintenanceCostInformationBOL();
            Int32 Id = Convert.ToInt32(gvMaintenanceCostInformationList.DataKeys[e.RowIndex].Value);
            entity.AutoID = Id;



            int success = oMaintenanceCostInformationBLL.MaintenanceCostInformation_Delete(entity);
            if (success > 0)
            {
                BindList();
            }
        }


        protected void gvMaintenanceCostInformationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
    }
}