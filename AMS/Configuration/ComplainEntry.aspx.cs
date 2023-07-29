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
    public partial class ComplainEntry : System.Web.UI.Page
    {

        ComplainInformationBLL oComplainInformationBLL = new ComplainInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    Session["breadcrumb"] = "Settings>Bill Deposit Entry";
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



            ComplainInformationBOL entity = new ComplainInformationBOL();

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
                Id = oComplainInformationBLL.ComplainInformation_Add(entity);
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

                Id = oComplainInformationBLL.ComplainInformation_Update(entity);

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

            DataTable dt = oComplainInformationBLL.ComplainInformation_GetDataForGV();
            gvComplainInformationList.DataSource = dt;
            gvComplainInformationList.DataBind();
        }
     
        protected void gvComplainInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            ComplainInformationBOL oComplainInformationBOL = new ComplainInformationBOL();
            Int32 Id = Convert.ToInt32(gvComplainInformationList.DataKeys[e.NewEditIndex].Value);
            oComplainInformationBOL.AutoID = Id;

            oComplainInformationBOL = oComplainInformationBLL.ComplainInformation_GetById(oComplainInformationBOL);
            SetDataToControls(oComplainInformationBOL);

        }
        private void SetDataToControls(ComplainInformationBOL oComplainInformationBOL)
        {

            try
            {
                txtDate.Text = oComplainInformationBOL.DateBind.ToString();
            }
            catch
            {
                txtDate.Text = "";
            }

            try
            {
                txtDescription.Text = oComplainInformationBOL.Description.ToString();
            }
            catch
            {
                txtDescription.Text = "";
            }

            try
            {
                txtTitle.Text = oComplainInformationBOL.Title.ToString();
            }
            catch
            {
                txtTitle.Text = "";
            }


            hfAutoId.Value = oComplainInformationBOL.AutoID.ToString();
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
        protected void gvComplainInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            ComplainInformationBOL entity = new ComplainInformationBOL();
            Int32 Id = Convert.ToInt32(gvComplainInformationList.DataKeys[e.RowIndex].Value);
            entity.AutoID = Id;
            int success = oComplainInformationBLL.ComplainInformation_Delete(entity);
            if (success > 0)
            {
                BindList();
            }
        }

      
    }
}