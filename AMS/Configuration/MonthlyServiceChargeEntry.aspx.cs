using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;   
using AMS.BOL.Configuration;
using AMS.BLL.Configuration;
using System.Data.SqlClient;

using System.IO;

using System.Web;

namespace AMS.Configuration
{
    public partial class MonthlyServiceChargeEntry : System.Web.UI.Page
    {

        MonthlyServiceChargeBLL oMonthlyServiceChargeBLL = new MonthlyServiceChargeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    Session["breadcrumb"] = "Settings>Monthly Service Charges Entry";
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                    dvFgrid.Visible = false;
                    LoadYearID();
                    BindList();
                    LoadUnitList("0");
                   
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
        private void LoadUnitList(string FloorID)
        {
            DataTable dt = new DataTable();
            string sql = "SP_UnitListByFloorIDDDL";
            dt = AMS.Common.Global.CreateDataTableParameter(sql, FloorID);


            ddlUnitNo.DataSource = dt;
            ddlUnitNo.DataTextField = "UnitName";
            ddlUnitNo.DataValueField = "AutoID";
            ddlUnitNo.DataBind();


        }
        private void Save()
        {



            MonthlyServiceChargeBOL entity = new MonthlyServiceChargeBOL();

            entity.OrganizationName = txtOrganization.Text;
            entity.Month = ddlMonthName.SelectedValue;
            entity.Year = ddlYear.SelectedValue;
            entity.FlatNo =  ddlUnitNo.SelectedValue;
            entity.ReceiptNo = txtReceitNo.Text;
            entity.ChargeName = txtChargeName.Text;


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
            int TotalAmount = 0;
            for (int i = 0; i < gvChargesList.Rows.Count; i++)
            {



                TextBox lblAmount = (TextBox)gvChargesList.Rows[i].FindControl("lblAmount");

                int CellAmount = 0;

                if (lblAmount.Text == "")
                {
                    CellAmount = 0;

                }
                else
                {
                    CellAmount = Convert.ToInt32(lblAmount.Text);
                }

                TotalAmount = TotalAmount + CellAmount;




            }
            entity.TotalAmount = TotalAmount;


            Int32 Id = 0;
            if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
            {
                entity.CreateBy = Session["UserID"].ToString();

                //Save record
                foreach (GridViewRow row in gvChargesList.Rows)
                {
                    TextBox lblChargesName = row.FindControl("lblChargesName") as TextBox;
                    TextBox lblAmount = row.FindControl("lblAmount") as TextBox;
                    entity.ChargeListName = lblChargesName.Text;
                    entity.ChargeAmount = Convert.ToDouble(lblAmount.Text);
                    Id = oMonthlyServiceChargeBLL.MonthlyServiceCharge_Add(entity);

                }
               
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

                entity.OldReceiptNo = hfAutoId.Value;

                int success = oMonthlyServiceChargeBLL.MonthlyServiceCharge_Delete(entity);
                if (success > 0)
                {
                    foreach (GridViewRow row in gvChargesList.Rows)
                    {
                        TextBox lblChargesName = row.FindControl("lblChargesName") as TextBox;
                        TextBox lblAmount = row.FindControl("lblAmount") as TextBox;
                        entity.ChargeListName = lblChargesName.Text;
                        entity.ChargeAmount = Convert.ToDouble(lblAmount.Text);
                        Id = oMonthlyServiceChargeBLL.MonthlyServiceCharge_Update(entity);

                    }

               

                }
              
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

            DataTable dt = oMonthlyServiceChargeBLL.MonthlyServiceCharge_GetDataForGV();

            gvMaintenanceCostInformationList.DataSource = dt;
            gvMaintenanceCostInformationList.DataBind();
        }
        protected void gvMaintenanceCostInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
            //tContUser.ActiveTabIndex = 1;
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
           /// SP_TB_AMS_MonthlyServiceChargeListByID
            DataTable dt = new DataTable();
            MonthlyServiceChargeBOL oMonthlyServiceChargeBOL= new MonthlyServiceChargeBOL();
            string ReceiptNo = Convert.ToString(gvMaintenanceCostInformationList.DataKeys[e.NewEditIndex].Value);
            oMonthlyServiceChargeBOL.ReceiptNo = ReceiptNo;
            dt = oMonthlyServiceChargeBLL.MonthlyServiceCharge_GetDataByReceiptNo(ReceiptNo);
            dvFgrid.Visible = true;
            gvChargesList.DataSource = dt;
            gvChargesList.DataBind();
            Session["Add_DT_Column"] = dt;
            CalTotal();
            oMonthlyServiceChargeBOL = oMonthlyServiceChargeBLL.MonthlyServiceCharge_GetById(oMonthlyServiceChargeBOL);
            SetDataToControls(oMonthlyServiceChargeBOL);

        }
        private void SetDataToControls(MonthlyServiceChargeBOL oMonthlyServiceCharge)
        {

            try
            {
                txtChargeName.Text = oMonthlyServiceCharge.ChargeName.ToString();
            }
            catch
            {
                txtChargeName.Text = string.Empty;
            }

            try
            {
                txtOrganization.Text = oMonthlyServiceCharge.OrganizationName.ToString();
            }
            catch
            {
                txtOrganization.Text = string.Empty;
            }
            

            try
            {

                txtDate.Text = oMonthlyServiceCharge.DateBind.ToString();
            }
            catch
            {
                txtDate.Text = string.Empty;
            }

            try
            {


                ddlMonthName.SelectedValue = oMonthlyServiceCharge.Month.ToString();
            }
            catch
            {
                ddlMonthName.SelectedValue = "0";
            }
            try
            {
                ddlYear.SelectedValue = oMonthlyServiceCharge.Year.ToString();
            }
            catch
            {
                ddlYear.SelectedValue = "0";
            }

            try
            {
                txtReceitNo.Text = oMonthlyServiceCharge.ReceiptNo.ToString();
            }
            catch
            {
                txtReceitNo.Text = string.Empty;
            }


            try
            {
                ddlUnitNo.SelectedValue = oMonthlyServiceCharge.FlatNo.ToString();
            }
            catch
            {
                ddlUnitNo.SelectedValue = "0";
            }


            hfAutoId.Value = oMonthlyServiceCharge.ReceiptNo.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }
        private void Clear()
        {
             txtOrganization.Text = "";
             txtChargeName.Text = "";
             txtDate.Text = string.Empty;
             txtReceitNo.Text = string.Empty;
             ddlMonthName.SelectedValue = "0";
             ddlUnitNo.SelectedValue = "0";
             ddlYear.SelectedValue = "0";
             gvChargesList.DataSource = null;
             gvChargesList.DataBind();
             dvFgrid.Visible = false;
             hfAutoId.Value = "0";
             btnsave.Visible = true;
             btnupdate.Visible = false;

        }
        protected void gvMaintenanceCostInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            MonthlyServiceChargeBOL entity = new MonthlyServiceChargeBOL();
            string  Id = Convert.ToString(gvMaintenanceCostInformationList.DataKeys[e.RowIndex].Value);
            entity.OldReceiptNo = Id;

            int success = oMonthlyServiceChargeBLL.MonthlyServiceCharge_Delete(entity);
            if (success > 0)
            {
                BindList();
            }

        }
        private void LoadYearID()
        {
            DataTable dt = new DataTable();
            string sql = "SP_TB_AMS_YearListDDL";
            dt = AMS.Common.Global.CreateDataTable(sql);

            ddlYear.DataSource = dt;
            ddlYear.DataTextField = "Yeartxt";
            ddlYear.DataValueField = "Year";
            ddlYear.DataBind();


        }
        private void CalTotal()
        {
            int TotalAmount = 0;

            for (int i = 0; i < gvChargesList.Rows.Count; i++)
            {



                TextBox lblAmount = (TextBox)gvChargesList.Rows[i].FindControl("lblAmount");

                int CellAmount = 0;

                if (lblAmount.Text == "")
                {
                    CellAmount = 0;

                }
                else
                {
                    CellAmount = Convert.ToInt32(lblAmount.Text);
                }

                TotalAmount = TotalAmount + CellAmount;

            }

            gvChargesList.FooterRow.Cells[1].Text = "Total= " + TotalAmount.ToString();
            gvChargesList.FooterRow.Cells[1].Font.Bold = true;

            gvChargesList.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            gvChargesList.FooterRow.BackColor = System.Drawing.Color.Beige;
        }
        private   void Add_DT_Column()
        {
        DataTable dt = new DataTable();

        dt.Columns.Add("AutoID", typeof(String));
        dt.Columns.Add("ChargesName", typeof(String));
        dt.Columns.Add("Amount", typeof(String));
        DataRow myRow = dt.NewRow();
        dt.Rows.InsertAt(myRow, dt.Rows.Count);

        Session["Add_DT_Column"] = dt;
    }
        protected void btnNewAdd_Click(object sender, EventArgs e)
        {
         
          
          
            //  SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString);
            dvFgrid.Visible = true;
            DataTable dt = new DataTable();

            if (Session["Add_DT_Column"] == null)
            {
                Add_DT_Column();
                dt = (DataTable)Session["Add_DT_Column"];
            }
            else
            {


                dt = (DataTable)Session["Add_DT_Column"];

                for (int i = 0; i < gvChargesList.Rows.Count; i++)
                {


                    TextBox lblChargesName = (TextBox)gvChargesList.Rows[i].FindControl("lblChargesName");
                    TextBox lblAmount = (TextBox)gvChargesList.Rows[i].FindControl("lblAmount");
                    Label lblSegmentsAutoID_Auto = (Label)gvChargesList.Rows[i].FindControl("lblSegmentsAutoID_Auto");

                    DataRow dr = dt.NewRow(); //Create a row of the the type dt
                    dr = dt.Rows[i];
                    dr["ChargesName"] = lblChargesName.Text;
                    dr["Amount"] = lblAmount.Text;
                    dr["AutoID"] = lblSegmentsAutoID_Auto.Text;


                }

                DataRow myRow = dt.NewRow();
                dt.Rows.InsertAt(myRow, dt.Rows.Count);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr = dt.Rows[i];
                dr["AutoID"] = i + 1;
              

            }
            gvChargesList.DataSource = dt;
            gvChargesList.DataBind();

            Session["Add_DT_Column"] = dt;
            Session["Dt"] = dt;

            CalTotal();
            

        }

            //Changing the Text for Inserting a New Record
            //((LinkButton)gvChargesList.Rows[0].Cells[0].Controls[0]).Text = "Insert";

        protected void LinkRowDelete_OnClick(object sender, EventArgs args)
        {


            LinkButton link = (LinkButton)sender;
            GridViewRow gv = (GridViewRow)(link.Parent.Parent);

            int i = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            DataTable dt = new DataTable();
            dt = (DataTable)Session["Add_DT_Column"];

            dt.Rows[i].Delete();
            gvChargesList.DataSource = dt;
            gvChargesList.DataBind();
            CalTotal();

            Session["Add_DT_Column"] = dt;
            Session["Dt"] = dt;

            if (gvChargesList.Rows.Count < 1)
            {
                dvFgrid.Visible = false;
            }

              


        }
        protected void txtAmount_TextChanged(object sender, EventArgs e)
        {
            //Int32 Id = Convert.ToInt32(ddlUserName.SelectedValue);
            CalTotal();
            //LengthCheck(Id);
        }
        protected void gvMaintenanceCostInformationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
    }
}