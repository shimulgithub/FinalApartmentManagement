using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AMS.Common;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;


namespace AMS.Reports
{
    public partial class TenantInfoReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!Page.IsPostBack)
                {
                    Session["SortedView"] = null;
                    Session["iTotalRecords"] = 0;
                    Session["PageLink"] = "Sage Reports";
                    Session["breadcrumb"] = "Reports > Tenant Information";
                    //hfpageid.Value = "1020";

                    //LoadEmployerID(Session["UserID"].ToString());
                    //LoadDivisionID(Session["UserID"].ToString(), "");
                    //LoadDepartmentID(Session["UserID"].ToString(), "");
                    ////LoadWorkerRefID();
                    ////LoadSupplierRefID();
                    ////LoadClientsRefID();
                    //LoadConsultantID();

                    //LoadVersion(hfpageid.Value, Session["UserID"].ToString());

                    BindTableColumns();

                }

            }
            else
            {
                Response.Redirect("~/UserLogin_Logout.aspx");
            }

        }

        private void LoadVersion(string pageid, string userid)
        {
            //DataTable dt = new DataTable();
            //string sql = "SP_TB_Reports_Column_VersionNameDDL";
            //string param0 = pageid;
            //string param1 = userid;
            //dt = Global.CreateDataTableParameterCONNString(sql, param0, param1);
            //ddlVersionID.DataSource = dt;
            //ddlVersionID.DataTextField = "VersoinName";
            //ddlVersionID.DataValueField = "VersoinAutoID";
            //ddlVersionID.DataBind();


        }
        protected void ddlVersionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTableColumns();
        }



        protected void btnClearfilteringcriteria_Click(object sender, EventArgs e)
        {
            ddlConsEmployeeRef.SelectedValue = "0";
            ddlEmployeeRef.SelectedValue = "0";
            ddlDivisionID.SelectedValue = "0";
            ddlDepartmentID.SelectedValue = "0";
            ddlConsultant.SelectedValue = "0";
            ddlMatchingConsultantDivison.SelectedValue = "0";
            ddlMatchingConsultantDept.SelectedValue = "0";

            LoadVersion(hfpageid.Value, Session["UserID"].ToString());
            ddlVersionID.SelectedValue = "0";
            Label7.Text = string.Empty;
            Session["SortedView"] = null;
            Session["iTotalRecords"] = 0;
            BindTableColumns();
            gvTenantInformation.DataSource = null;
            gvTenantInformation.EmptyDataText = "No Data Show";
            gvTenantInformation.DataBind();
            gvTenantInformation.Columns.Clear();
            pnl1Columns.Visible = false;
            pnl2Module.Visible = false;
            Panel4Version.Visible = false;
            //pnl3Module.Visible = false;

        }
        private void BindTableColumns()
        {

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["ConS2pibd"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.CommandText = @"SELECT [AutoID] ,[HeaderValue],[HeaderText] ,[Order_Priority]FROM [DB_AMS].[dbo].[TB_AMS_TenantInformation_Header]  order by Order_Priority asc ";

                    chkFields.Items.Clear();
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem();
                            item.Text = sdr["HeaderText"].ToString();
                            item.Value = sdr["HeaderValue"].ToString();
                            item.Selected = true; // Convert.ToBoolean(sdr["IsSelected"]);
                            chkFields.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }
        }
        protected void ShowGrid(object sender, EventArgs e)
        {

            foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
            {

                if (item.Selected)
                {

                    BoundField b = new BoundField();

                    b.DataField = item.Value;

                    b.HeaderText = item.Value;

                    gvTenantInformation.Columns.Add(b);

                }

            }

            this.TenantInformationList();

        }
        protected void btnColumns_Click(object sender, EventArgs e)
        {
            int pnl1_ = 0;
            if (pnl1Columns.Visible == true)
            {
                pnl1Columns.Visible = false;
                pnl2Module.Visible = false;
                Panel4Version.Visible = false;
                //  pnl3Module.Visible = false;
                pnl1_ = 1;
            }

            if (pnl1Columns.Visible == false && pnl1_ == 0)
            {
                pnl1Columns.Visible = true;
                pnl2Module.Visible = false;
                Panel4Version.Visible = false;
                //pnl3Module.Visible = false;
            }

        }
        protected void btnModule_Click(object sender, EventArgs e)
        {
            int pnl2_ = 0;

            if (pnl2Module.Visible == true)
            {
                pnl1Columns.Visible = false;
                pnl2Module.Visible = false;
                Panel4Version.Visible = false;
                //  pnl3Module.Visible = false;
                pnl2_ = 1;
            }

            if (pnl2Module.Visible == false && pnl2_ == 0)
            {
                pnl1Columns.Visible = false;
                pnl2Module.Visible = true;
                Panel4Version.Visible = false;
                // pnl3Module.Visible = false;
            }
        }
        protected void btnVersion_Click(object sender, EventArgs e)
        {
            int pnl4_ = 0;

            if (Panel4Version.Visible == true)
            {
                pnl1Columns.Visible = false;
                pnl2Module.Visible = false;
                //pnl3Module.Visible = false;
                Panel4Version.Visible = false;
                pnl4_ = 1;
            }

            if (Panel4Version.Visible == false && pnl4_ == 0)
            {
                pnl1Columns.Visible = false;
                pnl2Module.Visible = false;
                //pnl3Module.Visible = false;
                Panel4Version.Visible = true;
            }

        }

        protected void gvTenantInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTenantInformation.PageIndex = e.NewPageIndex;

            if (Session["SortedView"] != null)
            {
                DataTable dataTable = new DataTable();
                gvTenantInformation.DataSource = (DataView)Session["SortedView"];

                int iTotalRecords = ((DataView)(gvTenantInformation.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
                int iEndRecord = gvTenantInformation.PageSize * (gvTenantInformation.PageIndex + 1);
                int iStartsRecods = iEndRecord - gvTenantInformation.PageSize;

                if (iEndRecord > iTotalRecords)
                {
                    iEndRecord = iTotalRecords;
                }

                if (iStartsRecods == 0)
                {
                    iStartsRecods = 1;
                }

                if (iEndRecord == 0)
                {
                    iEndRecord = iTotalRecords;
                }

                Label7.Text = "Showing " + iStartsRecods + " to " + iEndRecord.ToString() + " of " + iTotalRecords.ToString() + " entries";
                if (gvTenantInformation.Rows.Count < 1)
                {
                    gvTenantInformation.EmptyDataText = "No Data Found";
                }
                gvTenantInformation.DataBind();
            }
            else
            {
                BindTenantInformationList_Selected();
                if (gvTenantInformation.Rows.Count < 1)
                {
                    gvTenantInformation.EmptyDataText = "No Data Found";
                }
                gvTenantInformation.DataBind();
            }

        }

        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gvRow = e.Row;
            if (gvRow.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);


                TableCell cell0 = new TableCell();
                cell0.Text = "Personal Information";
                cell0.Font.Bold = true;

                cell0.HorizontalAlign = HorizontalAlign.Center;
                cell0.ColumnSpan = 15;


                TableCell cell1 = new TableCell();
                cell1.Text = "Rent Information";
                //cell0.Font.Size   =  14;
                cell1.Font.Bold = true;

                cell1.HorizontalAlign = HorizontalAlign.Center;
                cell1.ColumnSpan = 5;

                TableCell cell2 = new TableCell();
                cell2.Text = "Worker Information";
                cell2.Font.Bold = true;

                cell2.HorizontalAlign = HorizontalAlign.Center;
                cell2.ColumnSpan = 4;



                TableCell cell3 = new TableCell();
                cell3.Text = "Driver Information";
                cell3.Font.Bold = true;
                cell3.HorizontalAlign = HorizontalAlign.Center;
                cell3.ColumnSpan = 4;



                TableCell cell4 = new TableCell();
                cell4.Text = "Previous House Owner Information";
                cell4.Font.Bold = true;
                cell4.HorizontalAlign = HorizontalAlign.Center;
                cell4.ColumnSpan = 4;

                TableCell cell5 = new TableCell();
                cell5.Text = "Family Member Information";
                cell5.Font.Bold = true;
                cell5.HorizontalAlign = HorizontalAlign.Center;
                cell5.ColumnSpan = 5;

                gvrow.Cells.Add(cell0);
                gvrow.Cells.Add(cell1);
                gvrow.Cells.Add(cell2);
                gvrow.Cells.Add(cell3);
                gvrow.Cells.Add(cell4);
                gvrow.Cells.Add(cell5);

                gvTenantInformation.Controls[0].Controls.AddAt(0, gvrow);
            }
        }
        private void BindTenantInformationList_Selected()
        {
            DataTable dt = new DataTable();
            dt = null;
            gvTenantInformation.DataSource = null;
            gvTenantInformation.DataBind();
            gvTenantInformation.Columns.Clear();
            try
            {

                foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
                {

                    if (item.Selected)
                    {

                        BoundField b = new BoundField();

                        b.DataField = item.Value;

                        b.HeaderText = item.Text;
                        b.SortExpression = item.Value;
                        gvTenantInformation.Columns.Add(b);

                    }
                }
                string sql = "SP_Rpt_TB_AMS_TenantInformationList";



                dt = Global.CreateDataTableParameterBuildinginformation(sql);

                gvTenantInformation.DataSource = dt;
                int iTotalRecords = ((DataTable)(gvTenantInformation.DataSource)).Rows.Count;
                Session["iTotalRecords"] = iTotalRecords;
                int iEndRecord = gvTenantInformation.PageSize * (gvTenantInformation.PageIndex + 1);

                int iStartsRecods = iEndRecord - gvTenantInformation.PageSize;

                if (iEndRecord > iTotalRecords)
                {

                    iEndRecord = iTotalRecords;

                }

                if (iStartsRecods == 0)
                {

                    iStartsRecods = 1;

                }

                if (iEndRecord == 0)
                {

                    iEndRecord = iTotalRecords;

                }

                Label7.Text = "Showing " + iStartsRecods + " to " + iEndRecord.ToString() + " of " + iTotalRecords.ToString() + " entries";
                if (gvTenantInformation.Rows.Count < 1)
                {
                    gvTenantInformation.EmptyDataText = "No Data Found";
                }

                gvTenantInformation.DataBind();

            }

            catch (Exception ex)
            {
                Response.Write("Oops! error occured:" + ex.Message.ToString());
            }
            finally
            {


            }
        }
        public SortDirection dir
        {

            get
            {
                if (ViewState["dirState"] == null)
                {

                    ViewState["dirState"] = SortDirection.Ascending;

                }

                return (SortDirection)ViewState["dirState"];

            }
            set
            {

                ViewState["dirState"] = value;

            }
        }
        protected void gvTenantInformation_Sorting(object sender, GridViewSortEventArgs e)
        {

            DataTable dataTable = new DataTable();
            string sql = "SP_Rpt_TB_AMS_TenantInformationList";


            dataTable = Global.CreateDataTableParameterBuildinginformation(sql);


            if (dataTable != null)
            {
                string SortDir = string.Empty;
                if (dir == SortDirection.Ascending)
                {
                    dir = SortDirection.Descending;
                    SortDir = "Desc";
                }
                else
                {
                    dir = SortDirection.Ascending;
                    SortDir = "Asc";
                }
                DataView sortedView = new DataView(dataTable);
                sortedView.Sort = e.SortExpression + " " + SortDir;
                Session["SortedView"] = sortedView;
                gvTenantInformation.DataSource = sortedView;
                if (gvTenantInformation.Rows.Count < 1)
                {
                    gvTenantInformation.EmptyDataText = "No Data Found";
                }
                gvTenantInformation.DataBind();
            }
        }
        private void TenantInformationList()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SP_Rpt_TB_AMS_TenantInformationList";


                dt = Global.CreateDataTableParameterBuildinginformation(sql);

                gvTenantInformation.DataSource = dt;
                int iTotalRecords = ((DataTable)(gvTenantInformation.DataSource)).Rows.Count;
                Session["iTotalRecords"] = iTotalRecords;

                int iEndRecord = gvTenantInformation.PageSize * (gvTenantInformation.PageIndex + 1);

                int iStartsRecods = iEndRecord - gvTenantInformation.PageSize;

                if (iEndRecord > iTotalRecords)
                {

                    iEndRecord = iTotalRecords;

                }

                if (iStartsRecods == 0)
                {

                    iStartsRecods = 1;

                }

                if (iEndRecord == 0)
                {

                    iEndRecord = iTotalRecords;

                }

                Label7.Text = "Showing " + iStartsRecods + " to " + iEndRecord.ToString() + " of " + iTotalRecords.ToString() + " entries";

                if (gvTenantInformation.Rows.Count < 1)
                {
                    gvTenantInformation.EmptyDataText = "No Data Found";
                }
                gvTenantInformation.DataBind();
            }

            catch (Exception ex)
            {
                Response.Write("Oops! error occured:" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        private void LoadEmployerID(string param)
        {
            DataTable dt = new DataTable();
            string sql = "SP_Employer_ReferenceByALLDDL";
            dt = Global.CreateDataTableParameter(sql, param);
            //ddlEmployeeRef.DataSource = dt;
            //ddlEmployeeRef.DataTextField = "Employer_Name";
            //ddlEmployeeRef.DataValueField = "Employer_Ref";
            //ddlEmployeeRef.DataBind();

            ddlConsEmployeeRef.DataSource = dt;
            ddlConsEmployeeRef.DataTextField = "Employer_Name";
            ddlConsEmployeeRef.DataValueField = "Employer_Ref";
            ddlConsEmployeeRef.DataBind();
        }
        private void LoadDivisionID(string param, string param1)
        {
            DataTable dt = new DataTable();
            string sql = "SP_Division_CodesByALLDDL";
            dt = Global.CreateDataTableParameter(sql, param, param1);
            ddlDivisionID.DataSource = dt;
            ddlDivisionID.DataTextField = "Division_Code_Name";
            ddlDivisionID.DataValueField = "Division_Code";
            ddlDivisionID.DataBind();


        }
        private void LoadDepartmentID(string param, string param1)
        {
            DataTable dt = new DataTable();
            string sql = "SP_Department_CodesByALLDDL";
            dt = Global.CreateDataTableParameter(sql, param, param1);
            ddlDepartmentID.DataSource = dt;
            ddlDepartmentID.DataTextField = "Dept_Description";
            ddlDepartmentID.DataValueField = "Department_Code";
            ddlDepartmentID.DataBind();


        }
        private void LoadConsultantID()
        {
            DataTable dt = new DataTable();
            string sql = "SP_ConsultantsALLDDL";
            dt = Global.CreateDataTable(sql);
            ddlConsultant.DataSource = dt;
            ddlConsultant.DataTextField = "Name";
            ddlConsultant.DataValueField = "Consultant_Code";
            ddlConsultant.DataBind();


        }

        protected void ddlEmployerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmployeeRef.SelectedValue != "0")
            {
                LoadDivisionID(Session["UserID"].ToString(), ddlEmployeeRef.SelectedValue);
            }
            else
            {
                LoadDivisionID(Session["UserID"].ToString(), "");
            }
        }

        protected void ddlDivisionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDivisionID.SelectedValue != "0")
            {
                LoadDepartmentID(Session["UserID"].ToString(), ddlDivisionID.SelectedValue);
            }
            else
            {
                LoadDepartmentID(Session["UserID"].ToString(), "");
            }

        }

        public void createPDF(DataTable dataTable)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("d://sampleJahidV.pdf", FileMode.OpenOrCreate));
            document.Open();
            PdfPTable table = new PdfPTable(dataTable.Columns.Count);
            table.WidthPercentage = 100;
            for (int k = 0; k < dataTable.Columns.Count; k++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(dataTable.Columns[k].ColumnName));

                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                //cell.BackgroundColor = new iTextSharp.text.BaseColor(51, 102, 102);

                table.AddCell(cell);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(dataTable.Rows[i][j].ToString()));
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                    table.AddCell(cell);
                }
            }

            document.Add(table);
            document.Close();
        }
        protected void btnExportToPDF_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SP_Rpt_TB_AMS_TenantInformationList";


                dt = Global.CreateDataTableParameterBuildinginformation(sql);


            }

            catch (Exception ex)
            {
                Response.Write("Oops! error occured:" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        private void ShowPdf(string strS)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader
            ("Content-Disposition", "attachment; filename=" + strS);
            Response.TransmitFile(strS);
            Response.End();
            Response.Flush();
            Response.Clear();

        }
        private static Excel.Workbook MyBook = null;

        private static Excel.Application MyApp = null;

        private static Excel.Worksheet MySheet = null;

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("TenantInformation");
            DataTable dt2 = new DataTable();

            try
            {
                GridView GridView1 = new GridView();
                dt = null;
                GridView1.DataSource = null;
                GridView1.DataBind();
                GridView1.Columns.Clear();
                string sql = "SP_Rpt_TB_AMS_TenantInformationList";


                dt = Global.CreateDataTableParameterBuildinginformation(sql);

                foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
                {
                    if (item.Selected)
                    {
                        BoundField b = new BoundField();
                        b.DataField = item.Value;
                        b.HeaderText = item.Text;
                        GridView1.Columns.Add(b);
                        dt2.Columns.Add(item.Value);
                    }
                }
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    var row = dt.Rows[k];
                    dt2.ImportRow(row);

                }
                for (int j = 0; j < chkFields.Items.Count; j++)
                {

                    for (int i = 0; i < dt2.Columns.Count; i++)
                    {
                        string cName = dt2.Columns[i].ColumnName.ToString();
                        string cnkValue = chkFields.Items[j].Value;   // item.Value;
                        string cnkName = chkFields.Items[j].Text;

                        if (cName == cnkValue)
                        {
                            dt2.Columns[i].ColumnName = cnkName;
                            break;
                        }

                    }
                }
                string FileName = "TenantInformation(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";
                try
                {
                    var wb = new ClosedXML.Excel.XLWorkbook();
                    var ws = wb.Worksheets.Add(dt2, "TenantInformation");


                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=\"" + FileName + "\"");

                    using (var ms = new System.IO.MemoryStream())
                    {
                        wb.SaveAs(ms);
                        ms.WriteTo(Response.OutputStream);
                        ms.Close();
                    }

                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
                catch (Exception Ex)
                {
                }
                finally
                {
                    dt = null;
                    dt2 = null;
                }
            }

            catch (Exception ex)
            {
                Response.Write("Oops! error occured:" + ex.Message.ToString());
            }
            finally
            {
                HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                HttpContext.Current.Response.End();

            }
        }
        protected void btnprint_Click(object sender, EventArgs e)
        {

            this.BindTenantInformationList_Selected();

        }
        protected void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAll.Checked == true)
            {
                foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
                {

                    item.Selected = true;


                }
            }
            else
            {
                foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
                {

                    item.Selected = false;


                }
            }
        }
    }
}