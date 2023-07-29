using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web;
using AMS.BOL.Configuration;
using AMS.BLL.Configuration;
using System.Data.SqlClient;
using System.IO;

using System.Web.UI.HtmlControls;

using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


namespace AMS.Configuration
{
    public partial class OwnerNoticeEntry : System.Web.UI.Page
    {

        OwnerNoticeInformationBLL oOwnerNoticeInformationBLL = new OwnerNoticeInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    Session["breadcrumb"] = "Settings>Owner Notice Entry";
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
        SqlConnection connection = null;
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



            OwnerNoticeInformationBOL entity = new OwnerNoticeInformationBOL();

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

            string filePath = FileUpload1.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;

            //Set the contenttype based on File Extension
            switch (ext)
            {
                case ".doc":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".docx":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".xls":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".jpg":
                    contenttype = "image/jpg";
                    break;
                case ".png":
                    contenttype = "image/png";
                    break;
                case ".gif":
                    contenttype = "image/gif";
                    break;
                case ".pdf":
                    contenttype = "application/pdf";
                    break;
            }
            if (contenttype != String.Empty)
            {


                FileUpload img = (FileUpload)FileUpload1;
                Byte[] imgByte = null;
                if (img.HasFile && img.PostedFile != null)
                {

                    HttpPostedFile File = FileUpload1.PostedFile;

                    imgByte = new Byte[File.ContentLength];

                    File.InputStream.Read(imgByte, 0, File.ContentLength);


                    string conn = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
                    connection = new SqlConnection(conn);

                    connection.Open();
                    if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
                    {

                        string sql = "INSERT INTO TB_AMS_OwnerNoticeInformation (NoticeFile) VALUES(@eimg) SELECT @@IDENTITY";
                        SqlCommand cmd = new SqlCommand(sql, connection);

                        cmd.Parameters.AddWithValue("@eimg", imgByte);
                        int id = Convert.ToInt32(cmd.ExecuteScalar());
                        entity.AutoID = id;
                        entity.CreateBy = Session["UserID"].ToString();

                        //Save record
                        if( id>0)
                        {
                            Int32  Id = oOwnerNoticeInformationBLL.OwnerNoticeInformation_Add(entity);
                            string myScript123 = "";
                            myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
                            ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);
                            Clear();
                            BindList();
                        }

                    }
                    else
                    {

                        string sql1 = " UPDATE TB_AMS_OwnerNoticeInformation SET NoticeFile=@eimg WHERE AutoID='" + hfAutoId.Value + "'";
                        SqlCommand cmd1 = new SqlCommand(sql1, connection);

                        cmd1.Parameters.AddWithValue("@eimg", imgByte);
                        int id1 = Convert.ToInt32(cmd1.ExecuteScalar());
                        entity.AutoID = Convert.ToInt32(hfAutoId.Value);

                        Int32 hFvAL = Convert.ToInt32(hfAutoId.Value);
                        entity.ChangedBy = Session["UserID"].ToString();
                        if (hFvAL > 0)
                        {
                            Int32 Id = oOwnerNoticeInformationBLL.OwnerNoticeInformation_Update(entity);
                            string myScript123 = "";
                            myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                            ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                            Clear();
                            BindList();
                        }
                    }


                }
            }
            else
            {



            }


        }
  
        private void BindList()
        {

            DataTable dt = oOwnerNoticeInformationBLL.OwnerNoticeInformation_GetDataForGV();
            gvOwnerNoticeInformationList.DataSource = dt;
            gvOwnerNoticeInformationList.DataBind();
        }
     
        protected void gvOwnerNoticeInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            OwnerNoticeInformationBOL oOwnerNoticeInformationBOL = new OwnerNoticeInformationBOL();
            Int32 Id = Convert.ToInt32(gvOwnerNoticeInformationList.DataKeys[e.NewEditIndex].Value);
            oOwnerNoticeInformationBOL.AutoID = Id;

            oOwnerNoticeInformationBOL = oOwnerNoticeInformationBLL.OwnerNoticeInformation_GetById(oOwnerNoticeInformationBOL);
            SetDataToControls(oOwnerNoticeInformationBOL);

        }
        private void SetDataToControls(OwnerNoticeInformationBOL oOwnerNoticeInformationBOL)
        {

            try
            {
                txtDate.Text = oOwnerNoticeInformationBOL.DateBind.ToString();
            }
            catch
            {
                txtDate.Text = "";
            }

            try
            {
                txtDescription.Text = oOwnerNoticeInformationBOL.Description.ToString();
            }
            catch
            {
                txtDescription.Text = "";
            }

            try
            {
                txtTitle.Text = oOwnerNoticeInformationBOL.Title.ToString();
            }
            catch
            {
                txtTitle.Text = "";
            }


            hfAutoId.Value = oOwnerNoticeInformationBOL.AutoID.ToString();
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
        protected void gvOwnerNoticeInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            OwnerNoticeInformationBOL entity = new OwnerNoticeInformationBOL();
            Int32 Id = Convert.ToInt32(gvOwnerNoticeInformationList.DataKeys[e.RowIndex].Value);
            entity.AutoID = Id;
            int success = oOwnerNoticeInformationBLL.OwnerNoticeInformation_Delete(entity);
            if (success > 0)
            {
                BindList();
            }
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName;
            string constr = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT  [AutoID],NoticeFile FROM TB_AMS_OwnerNoticeInformation where AutoID=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["NoticeFile"];

                        fileName = "OwnerNoticeFiles.pdf";
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}