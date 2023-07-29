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
    public partial class FloorInformation : System.Web.UI.Page
    {
        FloorInformationBLL oFloorInformationBLL = new FloorInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                    Session["breadcrumb"] = "Settings > Floor Information";
                    Clear();
                    BindList();
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
           Clear();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            Save();

        }
        private void Save()
        {

            FloorInformationBOL entity = new FloorInformationBOL();

            entity.FloorName = txtFloorName.Text.Trim();
           
            entity.CreateBy = Session["UserID"].ToString();

            

           
            Int32 Id = 0;
            if (string.IsNullOrEmpty(hfUserId.Value) || hfUserId.Value == "0")
            {

                //Save record
                Id = oFloorInformationBLL.FloorInforrmation_Add(entity);

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


                Id = oFloorInformationBLL.FloorInforrmation_Update(entity);


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


            FloorInformationBOL oFloorInformationBOL = new FloorInformationBOL();
            Int32 Id = Convert.ToInt32(gvFloorInformationList.DataKeys[e.RowIndex].Value);
            oFloorInformationBOL.AutoID = Id;
            int success = oFloorInformationBLL.FloorInforrmation_Delete(oFloorInformationBOL);
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
            FloorInformationBOL oFloorInformationBOL = new FloorInformationBOL();
            Int32 Id = Convert.ToInt32(gvFloorInformationList.DataKeys[e.NewEditIndex].Value);
            oFloorInformationBOL.AutoID = Id;
            oFloorInformationBOL = oFloorInformationBLL.FloorInforrmation_GetById(oFloorInformationBOL);
            SetDataToControls(oFloorInformationBOL);
        }

        private void SetDataToControls(FloorInformationBOL oFloorInformationBOL)
        {

            try
            {
                txtFloorName.Text = oFloorInformationBOL.FloorName.ToString();
            }
            catch
            {
                txtFloorName.Text = "";
            }


            hfUserId.Value = oFloorInformationBOL.AutoID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }
        private void Clear()
        {
            txtFloorName.Text = string.Empty;

            hfUserId.Value = "0";
        

            btnsave.Visible = true;
            btnupdate.Visible = false;

        }
        private void BindList()
        {
            //List<User> userList = oUserBLL.User_GetAll();
            DataTable dt = oFloorInformationBLL.FloorInforrmation__GetDataForGV();

            gvFloorInformationList.DataSource = dt;
            gvFloorInformationList.DataBind();
        }
    }
}