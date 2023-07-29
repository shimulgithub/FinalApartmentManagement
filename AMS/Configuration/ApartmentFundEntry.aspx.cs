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
    public partial class ApartmentFundEntry : System.Web.UI.Page
    {

        ApartmentFundInformationBLL oApartmentFundInformationBLL = new ApartmentFundInformationBLL();
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
                    LoadOwnerID();
                    LoadDesignationID();

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
        private void LoadOwnerID()
        {
            DataTable dt = new DataTable();
            string sql = "SP_TB_AMS_OwnerInformationDDL";
            dt = AMS.Common.Global.CreateDataTable(sql);

            ddlOwnerID.DataSource = dt;
            ddlOwnerID.DataTextField = "OwnerName";
            ddlOwnerID.DataValueField = "AutoID";
            ddlOwnerID.DataBind();


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



            ApartmentFundInformationBOL entity = new ApartmentFundInformationBOL();

            entity.OwnerID = ddlOwnerID.SelectedValue;
            entity.DesignationID = ddlDesignation.SelectedValue;
            entity.ReferenceID = txtReference.Text;
            entity.TotalAmount = txtTotalAmount.Text;
            entity.Purpose = txtPurpose.Text;

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
                Id = oApartmentFundInformationBLL.ApartmentFundInformation_Add(entity);
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


                Id = oApartmentFundInformationBLL.ApartmentFundInformation_Update(entity);

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
            //List<User> userList = oUserBLL.User_GetAll();
        private void BindList()
        {
     
            DataTable dt = oApartmentFundInformationBLL.ApartmentFundInformation_GetDataForGV();

            gvApartmentFundInformationList.DataSource = dt;
            gvApartmentFundInformationList.DataBind();
        }
     
        protected void gvApartmentFundInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
            //tContUser.ActiveTabIndex = 1;
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            ApartmentFundInformationBOL oApartmentFundInformation = new ApartmentFundInformationBOL();
            Int32 Id = Convert.ToInt32(gvApartmentFundInformationList.DataKeys[e.NewEditIndex].Value);
            oApartmentFundInformation.AutoID = Id;

            oApartmentFundInformation = oApartmentFundInformationBLL.ApartmentFundInformation_GetById(oApartmentFundInformation);
            SetDataToControls(oApartmentFundInformation);

        }
        private void SetDataToControls(ApartmentFundInformationBOL oApartmentFundInformation)
        {

            try
            {
                ddlOwnerID.SelectedValue = oApartmentFundInformation.OwnerID.ToString();
            }
            catch
            {
                ddlOwnerID.SelectedValue = "0";
            }

            try
            {

                ddlDesignation.SelectedValue = oApartmentFundInformation.DesignationID.ToString();
            }
            catch
            {
                ddlDesignation.SelectedValue = "0";
            }


            try
            {
                txtDate.Text = oApartmentFundInformation.DateBind.ToString();
            }
            catch
            {
                txtDate.Text = "";
            }

            try
            {
                txtReference.Text = oApartmentFundInformation.ReferenceID.ToString();
            }
            catch
            {
                txtReference.Text = "";
            }

            try
            {
                txtTotalAmount.Text = oApartmentFundInformation.TotalAmount.ToString();
            }
            catch
            {
                txtTotalAmount.Text = "";
            }

            try
            {
                txtPurpose.Text = oApartmentFundInformation.Purpose.ToString();
            }
            catch
            {
                txtPurpose.Text = "";
            }

            hfAutoId.Value = oApartmentFundInformation.AutoID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }
        private void Clear()
        {
            ddlOwnerID.SelectedValue = "0";
            ddlDesignation.SelectedValue = "0";
            ddlDesignation.Enabled = true;
            hfAutoId.Value = "0";
            txtDate.Text = string.Empty;
            txtPurpose.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            txtReference.Text = string.Empty;
            btnsave.Visible = true;
            btnupdate.Visible = false;

        }
        protected void gvApartmentFundInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            ApartmentFundInformationBOL entity = new ApartmentFundInformationBOL();
            Int32 Id = Convert.ToInt32(gvApartmentFundInformationList.DataKeys[e.RowIndex].Value);
            entity.AutoID = Id;



            int success = oApartmentFundInformationBLL.ApartmentFundInformation_Delete(entity);
            if (success > 0)
            {
                BindList();
            }
        }

      
    }
}