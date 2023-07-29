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
    public partial class RentCollectionEntry : System.Web.UI.Page
    {

        RentCollectionInformationBLL oRentCollectionInformationBLL = new RentCollectionInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    Session["breadcrumb"] = "Settings>Rent Collection Entry";
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                    BindList();
                    LoadFloorID();
                    LoadUnitListID();
                    LoadMonthNameID();
                    LoadddlYearID();
                    LoadBillStatusID();
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
        private void LoadBillStatusID()
        {
            DataTable dt = new DataTable();
            string sql = "SP_TB_AMS_BillStatusDDL";
            dt = AMS.Common.Global.CreateDataTable(sql);

            ddlBillStatus.DataSource = dt;
            ddlBillStatus.DataTextField = "Bill_Status";
            ddlBillStatus.DataValueField = "AutoID";
            ddlBillStatus.DataBind();


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
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Clear();


        }
        private void Save()
        {
           
            
            RentCollectionInformationBOL entity = new RentCollectionInformationBOL();
            entity.FloorID = ddlFloor.SelectedValue;
            entity.UnitName = ddlUnitName.SelectedValue;
            entity.RenterID = hfRenterID.Value;
            entity.MonthName = ddlMonthName.SelectedValue;
            entity.Year=ddlYear.SelectedValue;
            entity.Rent = txtRent.Text;
            entity.WaterBill=txtWaterBill.Text;
            entity.GasBill=txtGasBill.Text;
            entity.ReferecneNo=txtReference.Text;
            entity.ElectricBill=txtElectricBill.Text;
            entity.SecurityBill=txtSecurityBill.Text;
            entity.UtilityBill=txtUtilityBill.Text;
            entity.Purpose = txtPurpose.Text;
            entity.OtherBill=txtOtherBill.Text;
            entity.TotalBill=txtTotalAmount.Text;
            entity.BillStatus=ddlBillStatus.SelectedValue;

            if (txtIssueDate.Text != "")
            {
                DateTime dtpJoiningDate = DateTime.ParseExact(txtIssueDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
                entity.IssueDate = JoiningDate;
            }
            else
            {
                entity.IssueDate = Convert.ToDateTime("01/01/1991");

            }

            if (txtDueDSate.Text != "")
            {
                DateTime dtpJoiningDate = DateTime.ParseExact(txtDueDSate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
                entity.DueDate = JoiningDate;
            }
            else
            {
                entity.DueDate = Convert.ToDateTime("01/01/1991");

            }


            Int32 Id = 0;
            if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
            {
                entity.CreateBy = Session["UserID"].ToString();

                //Save record
                Id = oRentCollectionInformationBLL.RentCollectionInformation_Add(entity);
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

                Id = oRentCollectionInformationBLL.RentCollectionInformation_Update(entity);

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

            DataTable dt = oRentCollectionInformationBLL.RentCollectionInformation_GetDataForGV();

            gvRentCollectionInformationList.DataSource = dt;
            gvRentCollectionInformationList.DataBind();
        }
     
        protected void gvRentCollectionInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
            //tContUser.ActiveTabIndex = 1;
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            RentCollectionInformationBOL oRentCollectionInformationBOL = new RentCollectionInformationBOL();
            Int32 Id = Convert.ToInt32(gvRentCollectionInformationList.DataKeys[e.NewEditIndex].Value);
            oRentCollectionInformationBOL.AutoID = Id;

            oRentCollectionInformationBOL = oRentCollectionInformationBLL.RentCollectionInformation_GetById(oRentCollectionInformationBOL);
            SetDataToControls(oRentCollectionInformationBOL);

        }
        private void SetDataToControls(RentCollectionInformationBOL oRentCollectionInformationBOL)
        {

            try
            {
                ddlFloor.SelectedValue = oRentCollectionInformationBOL.FloorID.ToString();
            }
            catch
            {
                ddlFloor.SelectedValue = "0";
            }

            try
            {

                ddlUnitName.SelectedValue = oRentCollectionInformationBOL.UnitName.ToString();
            }
            catch
            {
                ddlUnitName.SelectedValue = "0";
            }

            try
            {

               txtRenterName.Text = oRentCollectionInformationBOL.TenantName.ToString();
            }
            catch
            {
                txtRenterName.Text =string.Empty;
            }

            try
            {
                ddlYear.SelectedValue = oRentCollectionInformationBOL.Year.ToString();
            }
            catch
            {
                ddlYear.SelectedValue = "0";
            }


            try
            {
                ddlMonthName.SelectedValue = oRentCollectionInformationBOL.MonthName.ToString();
            }
            catch
            {
                ddlMonthName.SelectedValue = "0";
            }

            try
            {
                txtElectricBill.Text = oRentCollectionInformationBOL.ElectricBill.ToString();
            }
            catch
            {
                txtElectricBill.Text = "";
            }

            try
            {
                txtSecurityBill.Text = oRentCollectionInformationBOL.SecurityBill.ToString();
            }
            catch
            {
                txtSecurityBill.Text = "";
            }
            try
            {
                txtUtilityBill.Text = oRentCollectionInformationBOL.UtilityBill.ToString();
            }
            catch
            {
                txtUtilityBill.Text = "";
            }
            try
            {
                txtOtherBill.Text = oRentCollectionInformationBOL.OtherBill.ToString();
            }
            catch
            {
                txtOtherBill.Text = "";
            }
            try
            {

                txtRent.Text= oRentCollectionInformationBOL.Rent.ToString();
            }
            catch
            {
                txtRent.Text = string.Empty;
            }


            try
            {

                txtWaterBill.Text = oRentCollectionInformationBOL.WaterBill.ToString();
            }
            catch
            {
                txtWaterBill.Text = string.Empty;
            }

            try
            {

                txtGasBill.Text = oRentCollectionInformationBOL.GasBill.ToString();
            }
            catch
            {
                txtGasBill.Text = string.Empty;
            }


            try
            {

                txtRenterName.Text = oRentCollectionInformationBOL.TenantName.ToString();
            }
            catch
            {
                txtRenterName.Text = string.Empty;
            }

            try
            {
                txtIssueDate.Text = oRentCollectionInformationBOL.IssueDateBind.ToString();
            }
            catch
            {
                txtIssueDate.Text = "";
            }
            try
            {
               txtDueDSate.Text = oRentCollectionInformationBOL.DueDateBind.ToString();
            }
            catch
            {
                txtDueDSate.Text = "";
            }


            try
            {
                ddlBillStatus.SelectedValue = oRentCollectionInformationBOL.BillStatus.ToString();
            }
            catch
            {
                ddlBillStatus.SelectedValue = "";
            }

            try
            {
                txtReference.Text = oRentCollectionInformationBOL.ReferecneNo;
            }
            catch
            {
                txtReference.Text = "";
            }

            try
            {
                txtTotalAmount.Text = oRentCollectionInformationBOL.TotalBill.ToString();
            }
            catch
            {
                txtTotalAmount.Text = "";
            }
            
            try
            {
                hfRenterID.Value = oRentCollectionInformationBOL.RenterID.ToString();
            }
            catch
            {
                hfRenterID.Value = "";
            } 
            
            try
            {
                txtPurpose.Text = oRentCollectionInformationBOL.Purpose.ToString();
            }
            catch
            {
                txtPurpose.Text = "";
            }
            try
            {
                txtPurpose.Text = oRentCollectionInformationBOL.Purpose.ToString();
            }
            catch
            {
                txtPurpose.Text = "";
            }


            hfAutoId.Value = oRentCollectionInformationBOL.AutoID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }
        private void Clear()
        {
            ddlFloor.SelectedValue = "0";
            ddlUnitName.SelectedValue = "0";
            ddlUnitName.Enabled = true;
            hfAutoId.Value = "0";
            hfRenterID.Value = "0";
            txtIssueDate.Text = string.Empty;
            txtPurpose.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            txtReference.Text = string.Empty;
            txtDueDSate.Text = string.Empty;
            txtRent.Text = string.Empty;
            txtRenterName.Text = string.Empty;
            txtSecurityBill.Text = string.Empty;
            txtUtilityBill.Text = string.Empty;
            txtWaterBill.Text = string.Empty;
            txtOtherBill.Text = string.Empty;
            txtGasBill.Text = string.Empty;
            txtElectricBill.Text = string.Empty;
            txtDueDSate.Text = string.Empty;
            ddlBillStatus.SelectedValue="0";
            ddlYear.SelectedValue = "0";
            ddlMonthName.SelectedValue = "0";



            btnsave.Visible = true;
            btnupdate.Visible = false;

        }
        protected void gvRentCollectionInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            RentCollectionInformationBOL entity = new RentCollectionInformationBOL();
            Int32 Id = Convert.ToInt32(gvRentCollectionInformationList.DataKeys[e.RowIndex].Value);
            entity.AutoID = Id;
            int success = oRentCollectionInformationBLL.RentCollectionInformation_Delete(entity);
            if (success > 0)
            {
                BindList();
            }
        }

       // SP_TB_AMS_OwnerInformationListByUnitNo
        protected void ddlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            string sql = "SP_TB_AMS_OwnerInformationListByUnitNo";
            dt = AMS.Common.Global.CreateDataTableParameter(sql, ddlUnitName.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                txtRenterName.Text = dt.Rows[0]["TenantName"].ToString();
                txtRent.Text = dt.Rows[0]["RentPerMonth"].ToString();
                hfRenterID.Value = dt.Rows[0]["RenterID"].ToString();
                
            }
            else
            {
                 
            }
        }

        protected void ddlFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            

              DataTable dt = new DataTable();
             string sql = "SP_TB_AMS_UnitInformationListByFloorID";
             dt = AMS.Common.Global.CreateDataTableParameter(sql,ddlFloor.SelectedValue);
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
    }
}