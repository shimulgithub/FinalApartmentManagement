using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SageReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] != null)
            {

                Session["PageLink"] = "Sage Reports";
                Session["breadcrumb"] = "Sage Reports";
            }
            else
            {
                Response.Redirect("~/UserLogin_Logout.aspx");
            }
        }

    }

    protected void btnprint_Click(object sender, EventArgs e)
    {

        //string OptionSU = "0";
        //string ParamSU = "0";
        //string param = "";
        
        //if (rdbValidTimesheetswithSuppliers.Checked == true)
        //{
        //    param = "ValidTimesheetswithSuppliers";
        //    ParamSU = "0";
        //}
        //else if (rdbMarginReportsbyEmployerswithdetails.Checked == true)
        //{
        //    param = "MarginReportsbyEmployerswithdetails";
        //    ParamSU = "0";
        //}
        //else if (rdbCreditNotesDetails.Checked == true)
        //{
        //    param = "CreditNotesDetails";
        //    ParamSU = "0";
        //}

        //else if (rdbAssignementDetailswithconsultantsplits.Checked == true)
        //{
        //    param = "AssignementDetailswithconsultantsplits";
        //    ParamSU = "0";
        //}
        //else if (rdbWorkersuppliers.Checked == true)
        //{
        //    param = "Workersuppliers";
        //    ParamSU = "0";
        //}
        //else if (rdbPermPlacementReports.Checked == true)
        //{
        //    param = "PermPlacementReports";
        //    ParamSU = "0";
        //}
        
        
        
        //string redirectPage = "";
        
        //string getpath = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.ToString().LastIndexOf('/') + 1);

        //redirectPage = getpath + "RptReportsViewer.aspx?param=" + param;

        //ScriptManager.RegisterStartupScript(this, typeof(Page),"UniqueID", "Popup('" + redirectPage + "');", true);

    }
}