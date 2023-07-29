using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;



using AMS.BLL.Configuration;
using AMS.BOL.Configuration;


namespace AMS.Configuration
{
    public partial class ChangePwd : System.Web.UI.Page
    {
        UserBLL oUserBLL = new UserBLL();
        private string userID = "";
        private string userPassword = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!Page.IsPostBack)
                {
                    Session["SortedView"] = null;
                    Session["iTotalRecords"] = 0;
                    Session["PageLink"] = "Sage Reports";
                    Session["breadcrumb"] = "Change Password";

                    txtLoginID.Text = Session["UserName"].ToString();
                }

            }
            else
            {
                Response.Redirect("~/UserLogin_Logout.aspx");
            }

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User entity = new User();
            Int32 user_ID = 0;
            Int32 Id = 0;
            user_ID = oUserBLL.User_GetUserIDByUserNamePassword(txtLoginID.Text, txtPassword.Text);

            if (user_ID != 0)
            {
                entity.Password = txtNewPassword.Text.ToString();
                entity.ConfirmPassword = txtConfNewPassword.Text.ToString();

                entity.Id = Convert.ToInt32(Session["UID"].ToString());

                Id = oUserBLL.User_UpdateChange(entity);

                if (Id > 0)
                {

                    string myScript123 = "";
                    myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);
                    Clear();
                }


            }
            else
            {
                string myScript = "alert('Old Password is not Correct');";

                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript, true);
                Clear();
            }
        }
        private void Clear()
        {
            txtPassword.Focus();

            txtPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtConfNewPassword.Text = string.Empty;
        }


    }
}
 