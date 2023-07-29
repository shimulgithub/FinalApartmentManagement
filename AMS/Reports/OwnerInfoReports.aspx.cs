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
    public partial class OwnerInfoReports : System.Web.UI.Page
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
                    Session["breadcrumb"] = "Reports > Owner Information";




                }

            }
            else
            {
                Response.Redirect("~/UserLogin_Logout.aspx");
            }

        }
       
        protected void ShowGrid(object sender, EventArgs e)
        {


            this.OwnerInformationList();

        }
        protected void gvOwnerInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOwnerInformation.PageIndex = e.NewPageIndex;

            if (Session["SortedView"] != null)
            {
                DataTable dataTable = new DataTable();
                gvOwnerInformation.DataSource = (DataView)Session["SortedView"];

                int iTotalRecords = ((DataView)(gvOwnerInformation.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
                int iEndRecord = gvOwnerInformation.PageSize * (gvOwnerInformation.PageIndex + 1);
                int iStartsRecods = iEndRecord - gvOwnerInformation.PageSize;

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
                if (gvOwnerInformation.Rows.Count < 1)
                {
                    gvOwnerInformation.EmptyDataText = "No Data Found";
                }
                gvOwnerInformation.DataBind();
            }
            else
            {
                BindOwnerInformationList_Selected();
                if (gvOwnerInformation.Rows.Count < 1)
                {
                    gvOwnerInformation.EmptyDataText = "No Data Found";
                }
                gvOwnerInformation.DataBind();
            }

        }
        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gvRow = e.Row;
            if (gvRow.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);


                TableCell cell0 = new TableCell();
                cell0.Text = "Owner Information";
                cell0.Font.Bold = true;

                cell0.HorizontalAlign = HorizontalAlign.Center;
                cell0.ColumnSpan = 10;


                //TableCell cell1 = new TableCell();
                //cell1.Text = "Company Information";
                ////cell0.Font.Size   =  14;
                //cell1.Font.Bold = true;

                //cell1.HorizontalAlign = HorizontalAlign.Center;
                //cell1.ColumnSpan = 7;

                //TableCell cell2 = new TableCell();
                //cell2.Text = "Department_Nominal_Links (DNL)";
                //cell2.Font.Bold = true;

                //cell2.HorizontalAlign = HorizontalAlign.Center;
                //cell2.ColumnSpan = 3;



                //TableCell cell3 = new TableCell();
                //cell3.Text = "Calculated";
                //cell3.Font.Bold = true;
                //cell3.HorizontalAlign = HorizontalAlign.Center;
                //cell3.ColumnSpan = 2;




                gvrow.Cells.Add(cell0);
                //gvrow.Cells.Add(cell1);
                //gvrow.Cells.Add(cell2);
                //gvrow.Cells.Add(cell3);

                gvOwnerInformation.Controls[0].Controls.AddAt(0, gvrow);
            }
        }
        private void BindOwnerInformationList_Selected()
        {
            DataTable dt = new DataTable();
            dt = null;
            gvOwnerInformation.DataSource = null;
            gvOwnerInformation.DataBind();
            gvOwnerInformation.Columns.Clear();
            try
            {


                string sql = "SP_Rpt_TB_AMS_OwnerInformationList";



                dt = Global.CreateDataTableParameterBuildinginformation(sql);


                gvOwnerInformation.DataSource = dt;
                int iTotalRecords = ((DataTable)(gvOwnerInformation.DataSource)).Rows.Count;
                Session["iTotalRecords"] = iTotalRecords;
                int iEndRecord = gvOwnerInformation.PageSize * (gvOwnerInformation.PageIndex + 1);

                int iStartsRecods = iEndRecord - gvOwnerInformation.PageSize;

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
                if (gvOwnerInformation.Rows.Count < 1)
                {
                    gvOwnerInformation.EmptyDataText = "No Data Found";
                }

                gvOwnerInformation.DataBind();

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
        protected void gvOwnerInformation_Sorting(object sender, GridViewSortEventArgs e)
        {

            DataTable dataTable = new DataTable();
            string sql = "SP_Rpt_TB_AMS_OwnerInformationList";


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
                gvOwnerInformation.DataSource = sortedView;
                if (gvOwnerInformation.Rows.Count < 1)
                {
                    gvOwnerInformation.EmptyDataText = "No Data Found";
                }
                gvOwnerInformation.DataBind();
            }
        }
        private void OwnerInformationList()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SP_Rpt_TB_AMS_OwnerInformationList";


                dt = Global.CreateDataTableParameterBuildinginformation(sql);

                gvOwnerInformation.DataSource = dt;
                int iTotalRecords = ((DataTable)(gvOwnerInformation.DataSource)).Rows.Count;
                Session["iTotalRecords"] = iTotalRecords;

                int iEndRecord = gvOwnerInformation.PageSize * (gvOwnerInformation.PageIndex + 1);

                int iStartsRecods = iEndRecord - gvOwnerInformation.PageSize;

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

                if (gvOwnerInformation.Rows.Count < 1)
                {
                    gvOwnerInformation.EmptyDataText = "No Data Found";
                }
                gvOwnerInformation.DataBind();
            }

            catch (Exception ex)
            {
                Response.Write("Oops! error occured:" + ex.Message.ToString());
            }
            finally
            {

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
                string sql = "SP_Rpt_TB_AMS_OwnerInformationList";


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
            DataTable dt = new DataTable("OwnerInformation");

            try
            {
                GridView GridView1 = new GridView();
                dt = null;
                GridView1.DataSource = null;
                GridView1.DataBind();
                GridView1.Columns.Clear();
                string sql = "SP_Rpt_TB_AMS_OwnerInformationList";


                dt = Global.CreateDataTableParameterBuildinginformation(sql);



                string FileName = "OwnerInformation(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";
                try
                {
                    var wb = new ClosedXML.Excel.XLWorkbook();
                    var ws = wb.Worksheets.Add(dt, "OwnerInformation");


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

            this.BindOwnerInformationList_Selected();

        }
    }
}