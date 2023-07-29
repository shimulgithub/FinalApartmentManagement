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
    public partial class MeetingInformationEntry : System.Web.UI.Page
    {

        MeetingInformationBLL oMeetingInformationBLL = new MeetingInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    Session["breadcrumb"] = "Settings>Meeting Information Entry";
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



            MeetingInformationBOL entity = new MeetingInformationBOL();

            entity.Title=txtTitle.Text;
            entity.Description = txtDescription.Text;
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
                Id = oMeetingInformationBLL.MeetingInformation_Add(entity);
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

                Id = oMeetingInformationBLL.MeetingInformation_Update(entity);

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

            DataTable dt = oMeetingInformationBLL.MeetingInformation_GetDataForGV();
            gvMeetingInformationList.DataSource = dt;
            gvMeetingInformationList.DataBind();
        }
     
        protected void gvMeetingInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            MeetingInformationBOL oMeetingInformationBOL = new MeetingInformationBOL();
            Int32 Id = Convert.ToInt32(gvMeetingInformationList.DataKeys[e.NewEditIndex].Value);
            oMeetingInformationBOL.AutoID = Id;

            oMeetingInformationBOL = oMeetingInformationBLL.MeetingInformation_GetById(oMeetingInformationBOL);
            SetDataToControls(oMeetingInformationBOL);

        }
        private void SetDataToControls(MeetingInformationBOL oMeetingInformationBOL)
        {

            try
            {
                txtDate.Text = oMeetingInformationBOL.DateBind.ToString();
            }
            catch
            {
                txtDate.Text = "";
            }

            try
            {
                txtDescription.Text = oMeetingInformationBOL.Description.ToString();
            }
            catch
            {
                txtDescription.Text = "";
            }

            try
            {
                txtTitle.Text = oMeetingInformationBOL.Title.ToString();
            }
            catch
            {
                txtTitle.Text = "";
            }


            hfAutoId.Value = oMeetingInformationBOL.AutoID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }
        private void Clear()
        {
            txtTitle.Text = "";
            txtDate.Text = "";
            txtDescription.Text = "";
            btnsave.Visible = true;
            btnupdate.Visible = false;
            hfAutoId.Value = "0";

        }
        protected void gvMeetingInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            MeetingInformationBOL entity = new MeetingInformationBOL();
            Int32 Id = Convert.ToInt32(gvMeetingInformationList.DataKeys[e.RowIndex].Value);
            entity.AutoID = Id;
            int success = oMeetingInformationBLL.MeetingInformation_Delete(entity);
            if (success > 0)
            {
                BindList();
            }
        }

      
    }
}