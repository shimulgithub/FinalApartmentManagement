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
    public partial class VisitorPresenceEntry : System.Web.UI.Page
    {

        VisitorInformationBLL oVisitorInformationBLL = new VisitorInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    Session["breadcrumb"] = "Settings> Invited Visitor Presence Entry";
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                    LoadVisitorTypeID();
                    BindList();

                  
                }

           
            }
            else
            {
                Response.Redirect("~/UserLogin_Logout.aspx");
            }
        }
        protected void btnDone_Click(object sender, EventArgs e)
        {
            VisitorInformationBOL oVisitorInformationBOL = new VisitorInformationBOL();
            Int32 AutoID = Convert.ToInt32(hfAutoId.Value);
            oVisitorInformationBOL.AutoID = AutoID;
            oVisitorInformationBOL.InTime = txtInTime.Text;
            oVisitorInformationBOL.OutTime = txtOutTime.Text;
            oVisitorInformationBOL.CreateBy = Session["UserID"].ToString();
            AutoID = oVisitorInformationBLL.VisitorInformation_PresenceUpdate(oVisitorInformationBOL);
            if (AutoID > 0)
            {
                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);
                Clear();
                BindList();
            }

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
        public string SearchBoxValue = "0";
        public string EntryDate = "0";
        private void BindList()
        {
            DataTable dt = new DataTable();
            string sql = "SP_TB_AMS_VisitorInformationListByParamVisited";
            if (txtEntryDate.Text !="")
            {
                 EntryDate=txtEntryDate.Text;
            }
            if (txtSearchBox.Text != "")
            {
                SearchBoxValue = txtSearchBox.Text.Trim();
            }
            dt = AMS.Common.Global.CreateDataTableParameter_InvitedVisitorPresenceEntry(sql, EntryDate, ddlVisitorType.SelectedValue, SearchBoxValue);

            gvVisitorInformationList.DataSource = dt;
            gvVisitorInformationList.DataBind();



        }
        protected void gvVisitorInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //e.Cancel = true;
            //Clear();
            //GetSelectedData(e);

          //  mp1.Show();
            //return;
            //tContUser.ActiveTabIndex = 1;
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            VisitorInformationBOL oVisitorInformationBOL = new VisitorInformationBOL();
            Int32 Id = Convert.ToInt32(gvVisitorInformationList.DataKeys[e.NewEditIndex].Value);
            oVisitorInformationBOL.AutoID = Id;

            oVisitorInformationBOL = oVisitorInformationBLL.VisitorInformation_GetById(oVisitorInformationBOL);


            //SetDataToControls(oVisitorInformationBOL);

        }
        protected void btnprint1_Click(object sender, EventArgs e)
        {
            // GetProductIDByCategoryID((txtFDate.Text), (txtTDate.Text));
            LinkButton btnprintGrv = sender as LinkButton;

            GridViewRow Grow = (GridViewRow)btnprintGrv.NamingContainer;
            string lblInTime = (Grow.FindControl("lblInTime") as Label).Text;
            string lblIOutTime = (Grow.FindControl("lblIOutTime") as Label).Text;
            txtInTime.Text = lblInTime;
            txtOutTime.Text = lblIOutTime;
            string AutoID = Server.UrlEncode(btnprintGrv.CommandArgument);
            hfAutoId.Value = AutoID;

            mp1.Show();
      
        }
         protected void btnAllAbsence_Click(object sender, EventArgs e)
         {
             VisitorInformationBOL oVisitorInformationBOL = new VisitorInformationBOL();
             LinkButton btnprintGrv = sender as LinkButton;
             Int32 ID = 0;
             foreach (GridViewRow rows in gvVisitorInformationList.Rows)
             {
                 Label lblAutoID = (Label)rows.FindControl("AutoID");
                 Int32 AutoID = Convert.ToInt32(lblAutoID.Text);

                 oVisitorInformationBOL.AutoID = AutoID;



                 oVisitorInformationBOL.CreateBy = Session["UserID"].ToString();
                 ID = oVisitorInformationBLL.VisitorInformation_AbsenceUpdate(oVisitorInformationBOL);
                
             }
             if (ID > 0)
             {
                 string myScript123 = "";
                 myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                 ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);
                 Clear();
                 BindList();
             }
         }
        
        protected void btnAbsence_Click(object sender, EventArgs e)
        {

            VisitorInformationBOL oVisitorInformationBOL = new VisitorInformationBOL();
            LinkButton btnprintGrv = sender as LinkButton;

            GridViewRow Grow = (GridViewRow)btnprintGrv.NamingContainer;
            Int32 AutoID = Convert.ToInt32(Server.UrlEncode(btnprintGrv.CommandArgument));
            oVisitorInformationBOL.AutoID = AutoID;

           
         
            oVisitorInformationBOL.CreateBy = Session["UserID"].ToString();
            AutoID = oVisitorInformationBLL.VisitorInformation_AbsenceUpdate(oVisitorInformationBOL);
            if (AutoID > 0)
            {
                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);
                Clear();
                BindList();
            }

        
        }

        
        private void Clear()
        {
          
            txtEntryDate.Text = "";
            //ddlFloor.SelectedValue = "0";
            //ddlUnitName.SelectedValue = "0";
            ddlVisitorType.SelectedValue = "0";
            //txtName.Text = "";
            //txtMobile.Text = "";
            //TxtContactPerson.Text = "";
            //txtVisitorAddress.Text = "";
            //txtInTime.Text = "";
            //txtOutTime.Text = "";
            txtSearchBox.Text = "";
            btnsave.Visible = true;
            btnupdate.Visible = false;
            hfAutoId.Value = "0";

        }
        //protected void gvVisitorInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{


        //    //VisitorInformationBOL entity = new VisitorInformationBOL();
        //    //Int32 Id = Convert.ToInt32(gvVisitorInformationList.DataKeys[e.RowIndex].Value);
        //    //entity.AutoID = Id;
        //    //int success = oVisitorInformationBLL.VisitorInformation_Delete(entity);
        //    //if (success > 0)
        //    //{
        //    //    BindList();
        //    //}
       // }
        protected void btnprint_Click(object sender, EventArgs e)
        {


            this.BindList();


        }
    }
}