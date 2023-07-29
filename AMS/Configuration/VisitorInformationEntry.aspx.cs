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
    public partial class VisitorInformationEntry : System.Web.UI.Page
    {

        VisitorInformationBLL oVisitorInformationBLL = new VisitorInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    Session["breadcrumb"] = "Settings> Visitor Information Entry";
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                    BindList();
                    LoadFloorID();
                    LoadUnitListID();
                    LoadVisitorTypeID();
                  
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
        private void LoadVisitorTypeID()
        {
            DataTable dt = new DataTable();
            string sql = "SP_TB_AMS_VisitorTypeDDL";
            dt = AMS.Common.Global.CreateDataTable(sql);

            ddlVisitorType.DataSource = dt;
            ddlVisitorType.DataTextField = "VisitorType";
            ddlVisitorType.DataValueField = "AutoID";
            ddlVisitorType.DataBind();


        }
     
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Clear();


        }
        private void Save()
        {



            VisitorInformationBOL entity = new VisitorInformationBOL();

            entity.FloorID = ddlFloor.SelectedValue;
            entity.UnitID = ddlUnitName.SelectedValue;
            entity.VisitorTypeID =ddlVisitorType.SelectedValue;
            entity.Name = txtName.Text;
            entity.Mobile = txtMobile.Text;
            entity.ContactPerson = TxtContactPerson.Text;
            entity.VisitorAddress = txtVisitorAddress.Text;
            entity.InTime = txtInTime.Text;
            entity.OutTime = txtOutTime.Text;
            entity.Purpose = txtPurpose.Text;

            if (txtEntryDate.Text != "")
            {
                DateTime dtpJoiningDate = DateTime.ParseExact(txtEntryDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
                entity.EntryDate = JoiningDate;
            }
            else
            {
                entity.EntryDate = Convert.ToDateTime("01/01/1991");

            }


            Int32 Id = 0;
            if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
            {
                entity.CreateBy = Session["UserID"].ToString();

                //Save record
                Id = oVisitorInformationBLL.VisitorInformation_Add(entity);
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


                Id = oVisitorInformationBLL.VisitorInformation_Update(entity);

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

            DataTable dt = oVisitorInformationBLL.VisitorInformation_GetDataForGV();

            gvVisitorInformationList.DataSource = dt;
            gvVisitorInformationList.DataBind();
        }
     
        protected void gvVisitorInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
            //tContUser.ActiveTabIndex = 1;
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            VisitorInformationBOL oVisitorInformationBOL = new VisitorInformationBOL();
            Int32 Id = Convert.ToInt32(gvVisitorInformationList.DataKeys[e.NewEditIndex].Value);
            oVisitorInformationBOL.AutoID = Id;

            oVisitorInformationBOL = oVisitorInformationBLL.VisitorInformation_GetById(oVisitorInformationBOL);
            SetDataToControls(oVisitorInformationBOL);

        }
        private void SetDataToControls(VisitorInformationBOL oVisitorInformationBOL)
        {

            try
            {

                txtEntryDate.Text = oVisitorInformationBOL.EntryDateBind.ToString();
            }
            catch
            {
                txtEntryDate.Text = "";
            }


            try
            {

                ddlFloor.SelectedValue = oVisitorInformationBOL.FloorID;
            }
            catch
            {
                ddlFloor.SelectedValue = "0";
            }
            try
            {

                ddlUnitName.SelectedValue = oVisitorInformationBOL.UnitID.ToString();
            }
            catch
            {

                ddlUnitName.SelectedValue = "0";
            }


            try
            {

                ddlVisitorType.SelectedValue = oVisitorInformationBOL.VisitorTypeID.ToString();
            }
            catch
            {
                ddlVisitorType.SelectedValue = "0";
            }

            try
            {

                txtName.Text = oVisitorInformationBOL.Name.ToString();
            }
            catch
            {
                txtName.Text = "";
            }


            try
            {
               txtMobile.Text= oVisitorInformationBOL.Mobile.ToString();
            }
            catch
            {
                txtMobile.Text = "";
            }

            try
            {
                TxtContactPerson.Text = oVisitorInformationBOL.ContactPerson.ToString();
            }
            catch
            {
                TxtContactPerson.Text = "";
            }

            try
            {
                txtVisitorAddress.Text = oVisitorInformationBOL.VisitorAddress.ToString();
            }
            catch
            {
                txtVisitorAddress.Text = "";
            }

            try
            {
                txtInTime.Text = oVisitorInformationBOL.InTime.ToString();
            }
            catch
            {
                txtInTime.Text = "";
            }
            try
            {
                txtOutTime.Text = oVisitorInformationBOL.OutTime.ToString();
            }
            catch
            {
                txtOutTime.Text = "";
            }

            try
            {
                txtPurpose.Text = oVisitorInformationBOL.Purpose.ToString();
            }
            catch
            {
                txtPurpose.Text = "";
            }

            hfAutoId.Value = oVisitorInformationBOL.AutoID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }
        private void Clear()
        {
          
            txtEntryDate.Text = "";
            ddlFloor.SelectedValue = "0";
            ddlUnitName.SelectedValue = "0";
            ddlVisitorType.SelectedValue = "0";
            txtName.Text = "";
            txtMobile.Text = "";
            TxtContactPerson.Text = "";
            txtVisitorAddress.Text = "";
            txtInTime.Text = "";
            txtOutTime.Text = "";
            txtPurpose.Text = "";
            btnsave.Visible = true;
            btnupdate.Visible = false;
            hfAutoId.Value = "0";

        }
        protected void gvVisitorInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            VisitorInformationBOL entity = new VisitorInformationBOL();
            Int32 Id = Convert.ToInt32(gvVisitorInformationList.DataKeys[e.RowIndex].Value);
            entity.AutoID = Id;
            int success = oVisitorInformationBLL.VisitorInformation_Delete(entity);
            if (success > 0)
            {
                BindList();
            }
        }

        protected void ddlFloor_SelectedIndexChanged(object sender, EventArgs e)
        {



            DataTable dt = new DataTable();
            string sql = "SP_TB_AMS_UnitInformationListByFloorID";
            dt = AMS.Common.Global.CreateDataTableParameter(sql, ddlFloor.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                ddlUnitName.DataSource = dt;
                ddlUnitName.DataTextField = "UnitNametxt";
                ddlUnitName.DataValueField = "UnitName";
                ddlUnitName.DataBind();
            }
            else
            {
                LoadUnitListID();
            }
        }
        private void LoadUnitListID()
        {
            DataTable dt = new DataTable();
            string sql = "SP_TB_AMS_UnitInformationListDDL";
            dt = AMS.Common.Global.CreateDataTable(sql);

            ddlUnitName.DataSource = dt;
            ddlUnitName.DataTextField = "UnitNametxt";
            ddlUnitName.DataValueField = "UnitName";
            ddlUnitName.DataBind();


        }
        private void LoadFloorID()
        {
            DataTable dt = new DataTable();
            string sql = "SP_TB_AMS_FloorInformationListDDL";
            dt = AMS.Common.Global.GetData(sql);
            ddlFloor.DataSource = dt;
            ddlFloor.DataTextField = "FloorName";
            ddlFloor.DataValueField = "AutoID";
            ddlFloor.DataBind();

        }
    }
}