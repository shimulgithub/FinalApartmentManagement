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
    public partial class BillEntry : System.Web.UI.Page
    {

        BillDepositInformationBLL oBillDepositInformationBLL = new BillDepositInformationBLL();
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
                    LoadMonthNameID();
                    LoadddlYearID();
                    LoadBillTypeID();
                    LoadBankNameID();
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
        private void LoadMonthNameID()
        {
            DataTable dt = new DataTable();
            string sql = "SP_TB_AMS_MonthNameListDDL";
            dt = AMS.Common.Global.CreateDataTable(sql);

            ddlMonthName.DataSource = dt;
            ddlMonthName.DataTextField = "MonthNametxt";
            ddlMonthName.DataValueField = "MonthName";
            ddlMonthName.DataBind();


        }
        private void LoadddlYearID()
        {
            DataTable dt = new DataTable();
            string sql = "SP_TB_AMS_YearListDDL";
            dt = AMS.Common.Global.CreateDataTable(sql);

            ddlYear.DataSource = dt;
            ddlYear.DataTextField = "Yeartxt";
            ddlYear.DataValueField = "Year";
            ddlYear.DataBind();


        }
        
        private void LoadBillTypeID()
        {
            DataTable dt = new DataTable();
            string sql = "SP_BillTypeDDL";
            dt = AMS.Common.Global.CreateDataTable(sql);

            ddlBillType.DataSource = dt;
            ddlBillType.DataTextField = "BillType";
            ddlBillType.DataValueField = "AutoID";
            ddlBillType.DataBind();


        }
          private void LoadBankNameID()
        {
            DataTable dt = new DataTable();
            string sql = "SP_BankNameDDL";
            dt = AMS.Common.Global.CreateDataTable(sql);
            ddlBankList.DataSource = dt;
            ddlBankList.DataTextField = "BankName";
            ddlBankList.DataValueField = "AutoID";
            ddlBankList.DataBind();


        }


        
    
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Clear();


        }
        private void Save()
        {



            BillDepositInformationBOL entity = new BillDepositInformationBOL();

            //entity.OwnerID = ddlOwnerID.SelectedValue;
            entity.BillTypeID = ddlBillType.SelectedValue;
            entity.BankID = ddlBankList.SelectedValue;
            entity.TotalAmt = txtTotalAmt.Text;
            entity.Remarks = txtPurpose.Text;
            entity.MonthName = ddlMonthName.SelectedValue;
            entity.Year = ddlYear.SelectedValue;
            entity.ReferencNo = txtReference.Text;
   

            if (txtDate.Text != "")
            {
                DateTime dtpJoiningDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
                entity.BillDate = JoiningDate;
            }
            else
            {
                entity.BillDate = Convert.ToDateTime("01/01/1991");

            }


            Int32 Id = 0;
            if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
            {
                entity.CreateBy = Session["UserID"].ToString();

                //Save record
                Id = oBillDepositInformationBLL.BillDepositInformation_Add(entity);
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


                Id = oBillDepositInformationBLL.BillDepositInformation_Update(entity);

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

            DataTable dt = oBillDepositInformationBLL.BillDepositInformation_GetDataForGV();

            gvBillDepositInformationList.DataSource = dt;
            gvBillDepositInformationList.DataBind();
        }
     
        protected void gvBillDepositInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
            //tContUser.ActiveTabIndex = 1;
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            BillDepositInformationBOL oBillDepositInformationBOL = new BillDepositInformationBOL();
            Int32 Id = Convert.ToInt32(gvBillDepositInformationList.DataKeys[e.NewEditIndex].Value);
            oBillDepositInformationBOL.AutoID = Id;

            oBillDepositInformationBOL = oBillDepositInformationBLL.BillDepositInformation_GetById(oBillDepositInformationBOL);
            SetDataToControls(oBillDepositInformationBOL);

        }
        private void SetDataToControls(BillDepositInformationBOL oBillDepositInformationBOL)
        {


            try
            {

                ddlMonthName.SelectedValue = oBillDepositInformationBOL.MonthName.ToString();
            }
            catch
            {
                ddlMonthName.SelectedValue = "0";
            }
            try
            {

                ddlYear.SelectedValue = oBillDepositInformationBOL.Year.ToString();
            }
            catch
            {
                ddlYear.SelectedValue = "0";
            }


            try
            {

                ddlBillType.SelectedValue = oBillDepositInformationBOL.BillTypeID.ToString();
            }
            catch
            {
                ddlBillType.SelectedValue = "0";
            }

            try
            {

                ddlBankList.SelectedValue = oBillDepositInformationBOL.BankID.ToString();
            }
            catch
            {
                ddlBankList.SelectedValue = "0";
            }


            try
            {
                txtDate.Text = oBillDepositInformationBOL.BillDateBind.ToString();
            }
            catch
            {
                txtDate.Text = "";
            }

            try
            {
                txtReference.Text = oBillDepositInformationBOL.ReferencNo.ToString();
            }
            catch
            {
                txtReference.Text = "";
            }

            try
            {
                txtTotalAmt.Text = oBillDepositInformationBOL.TotalAmt.ToString();
            }
            catch
            {
                txtTotalAmt.Text = "";
            }

            try
            {
                txtPurpose.Text = oBillDepositInformationBOL.Remarks.ToString();
            }
            catch
            {
                txtPurpose.Text = "";
            }

            hfAutoId.Value = oBillDepositInformationBOL.AutoID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }
        private void Clear()
        {
            ddlBillType.SelectedValue = "0";
            ddlMonthName.SelectedValue = "0";
            ddlYear.SelectedValue = "0";
            txtTotalAmt.Text = string.Empty;
            
            
            ddlBankList.SelectedValue = "0";
            ddlBankList.Enabled = true;
            hfAutoId.Value = "0";
            txtDate.Text = string.Empty;
            txtPurpose.Text = string.Empty;
            //txtTotalAmount.Text = string.Empty;
            txtReference.Text = string.Empty;
            btnsave.Visible = true;
            btnupdate.Visible = false;

        }
        protected void gvBillDepositInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            BillDepositInformationBOL entity = new BillDepositInformationBOL();
            Int32 Id = Convert.ToInt32(gvBillDepositInformationList.DataKeys[e.RowIndex].Value);
            entity.AutoID = Id;
            int success = oBillDepositInformationBLL.BillDepositInformation_Delete(entity);
            if (success > 0)
            {
                BindList();
            }
        }

      
    }
}