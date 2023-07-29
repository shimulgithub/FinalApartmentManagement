using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using AMS.BLL.Configuration;
using AMS.BOL.Configuration;
using AMS.Common;

namespace AMS
{
    public partial class UserLogin_Logout : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    //DataTable dt = new DataTable();
                    Int32 InsertId = 0;
                    UserBLL oUserBLL = new UserBLL();
                    UserLoginHistoryBOL oUserLoginHistoryBOL = new UserLoginHistoryBOL();
                    oUserLoginHistoryBOL.UserId = Convert.ToInt32(Session["UserID"].ToString());
                    InsertId = oUserBLL.UserLoginHistory_Update(oUserLoginHistoryBOL);

                }
                clearAll();
                Session["MenuLiteral1"] = null;
                Session["Menu"] = null;
                txtPassword.Attributes.Add("onKeyPress", "buttonLogin_click('" + btnLogin.ClientID + "',event)");
               
            }

         }
    void clearAll()
    {
        Session["UserFullName"] = null;

        AMS.Common.Global.Companyid = Convert.ToInt32("0");
        AMS.Common.Global.userID = Convert.ToInt32("0");
        AMS.Common.Global.userRole = Convert.ToInt32("0");

        AMS.Common.Global.User_Branch = Convert.ToInt32("0");

        AMS.Common.Global.userName = null;
        AMS.Common.Global.userPassword = null;
        Session["UserID"] = null;
        Session["Password"] = null;
        Session["userNameID"] = null;
        Session["UserRole"] = null;
        Session["UserGroupID"] = null;
        Session["UserName"] = null;
        Session["UID"] = null;
        Session.RemoveAll();

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

        //GetMacAddress();
        lblMessage.Text = "";
        Int32 user_ID = 0;


        //DateTime yourDate = new DateTime();
        //DateTime CDate = new DateTime();



        UserBLL objUserBLL = new UserBLL();
        user_ID = objUserBLL.User_GetUserIDByUserNamePassword(txtUsername.Text, txtPassword.Text);

        if (user_ID != 0)
        {
            DataTable dtForNameAndRole = objUserBLL.User_GetRoleByUserID(Convert.ToString(user_ID));

            try
            {
                Session["UID"] = dtForNameAndRole.Rows[0]["Id"].ToString();
                Session["UserFullName"] = dtForNameAndRole.Rows[0]["UserFullName"].ToString();
                AMS.Common.Global.Companyid = Convert.ToInt32(dtForNameAndRole.Rows[0]["CompanyId"].ToString());
                AMS.Common.Global.userID = Convert.ToInt32(user_ID);
                AMS.Common.Global.userNameID = dtForNameAndRole.Rows[0]["UserId"].ToString();

                Session["userNameID"] = dtForNameAndRole.Rows[0]["UserId"].ToString();
                Session["UserName"] = dtForNameAndRole.Rows[0]["UserName"].ToString();
                AMS.Common.Global.userRole = Convert.ToInt32(dtForNameAndRole.Rows[0]["UserRole"].ToString());

                AMS.Common.Global.User_Branch = Convert.ToInt32(dtForNameAndRole.Rows[0]["UserGroupID"].ToString());

                Session["UserGroupID"] = Convert.ToInt32(dtForNameAndRole.Rows[0]["UserGroupID"].ToString());

                AMS.Common.Global.userName = dtForNameAndRole.Rows[0]["UserFullName"].ToString();
                AMS.Common.Global.userPassword = txtPassword.Text;

                Session["UserRole"] = Convert.ToInt32(dtForNameAndRole.Rows[0]["UserRole"].ToString());

                Session["UserID"] = user_ID;
                Session["Password"] = txtPassword.Text;

                //Response.Redirect("Index2.aspx", false);
                Response.Redirect("MainPage.aspx", false);

            }
            catch (Exception ex)
            {

                clearAll();
                Session["UserFullName"] = null;
                AMS.Common.Global.Companyid = Convert.ToInt32("0");
                AMS.Common.Global.userID = Convert.ToInt32("0");
                AMS.Common.Global.userRole = Convert.ToInt32("0");

                AMS.Common.Global.User_Branch = Convert.ToInt32("0");

                AMS.Common.Global.userName = null;
                AMS.Common.Global.userPassword = null;
                Session["UserID"] = null;
                Session["Password"] = null;

                Session["UserRole"] = null;
                Session.RemoveAll();
            }
            txtPassword.Text = "";
            txtUsername.Text = "";


        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Sorry! Invalid user name or password.";
            lblMessage.ForeColor = Color.Red;
            return;
        }


       }

    }
}