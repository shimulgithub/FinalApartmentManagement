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
    public partial class UnitInformation : System.Web.UI.Page
    {
        UnitInformationBLL oUnitInformationBLL = new UnitInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                    Session["breadcrumb"] = "Settings > Unit Information";
                    Clear();
                    BindList();
                    LoadUnitID();
                    // SystemUsageAuditLogInsert("1008");
                }
            }
            else
            {
                Response.Redirect("~/UserLogin_Logout.aspx");
            }


        }


        protected void btnNew_Click(object sender, EventArgs e)
        {

            ddlFloor.SelectedValue = "0";
           Clear();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            Save();

        }

        private void LoadUnitID()
        {
            DataTable dt = new DataTable();
            string sql = "SP_TB_AMS_FloorInformationListDDL";
            dt = AMS.Common.Global.GetData(sql);
            ddlFloor.DataSource = dt;
            ddlFloor.DataTextField = "FloorName";
            ddlFloor.DataValueField = "AutoID";
            ddlFloor.DataBind();

        }
        private void Save()
        {

            UnitInformationBOL entity = new UnitInformationBOL();

            entity.UnitName = txtUnitName.Text.Trim();
            entity.FloorID = ddlFloor.SelectedValue;
           
            entity.CreateBy = Session["UserID"].ToString();

            

           
            Int32 Id = 0;
            if (string.IsNullOrEmpty(hfUserId.Value) || hfUserId.Value == "0")
            {

                //Save record
                Id = oUnitInformationBLL.UnitInforrmation_Add(entity);

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

                entity.AutoID = Convert.ToInt32(hfUserId.Value);

                entity.ChangedBy = Session["UserID"].ToString();


                Id = oUnitInformationBLL.UnitInforrmation_Update(entity);


                //if (Id > 0)
                //{
                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                Clear();
                BindList();
                //}
            }
        }


        protected void gvFloorInformationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void gvFloorInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            UnitInformationBOL oUnitInformationBOL = new UnitInformationBOL();
            Int32 Id = Convert.ToInt32(gvFloorInformationList.DataKeys[e.RowIndex].Value);
            oUnitInformationBOL.AutoID = Id;
            int success = oUnitInformationBLL.UnitInforrmation_Delete(oUnitInformationBOL);
            if (success > 0)
            {
                BindList();
            }
        }
        protected void gvFloorInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
            //tContUser.ActiveTabIndex = 1;
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            UnitInformationBOL oUnitInformationBOL = new UnitInformationBOL();
            Int32 Id = Convert.ToInt32(gvFloorInformationList.DataKeys[e.NewEditIndex].Value);
            oUnitInformationBOL.AutoID = Id;
            oUnitInformationBOL = oUnitInformationBLL.UnitInforrmation_GetById(oUnitInformationBOL);
            SetDataToControls(oUnitInformationBOL);
        }

        private void SetDataToControls(UnitInformationBOL oUnitInformationBOL)
        {

            try
            {
                txtUnitName.Text = oUnitInformationBOL.UnitName.ToString();
            }
            catch
            {
                txtUnitName.Text = "";
            }
            try { ddlFloor.SelectedValue = oUnitInformationBOL.FloorID.ToString(); }
            catch
            {
                ddlFloor.SelectedValue = "0";
            }

            hfUserId.Value = oUnitInformationBOL.AutoID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }
        private void Clear()
        {
            txtUnitName.Text = string.Empty;

            hfUserId.Value = "0";
        

            btnsave.Visible = true;
            btnupdate.Visible = false;

        }
        private void BindList()
        {
            //List<User> userList = oUserBLL.User_GetAll();
            DataTable dt = oUnitInformationBLL.UnitInforrmation__GetDataForGV();

            gvFloorInformationList.DataSource = dt;
            gvFloorInformationList.DataBind();
        }
    }
}