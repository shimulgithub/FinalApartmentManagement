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
    public partial class BuildingInformation : System.Web.UI.Page
    {
        BuildingInformationBLL oBuildingInformationBLL = new BuildingInformationBLL();
        protected string UploadFolderPath = "~/images/defalt.jpg";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                    Session["breadcrumb"] = "Settings>Building Information";
                    LoadYearID();
                    Clear();
                    BindList();
                    // SystemUsageAuditLogInsert("1008");
                }
            }
            else
            {
                Response.Redirect("~/UserLogin_Logout.aspx");
            }

        }
        private void BindList()
        {
            DataTable dt = oBuildingInformationBLL.BuildingInforrmation__GetDataForGV();
            gvBuildingInformationList.DataSource = dt;
            gvBuildingInformationList.DataBind();

        }
        public int MaxId()
        {
            int UserGroupID = 0;
            string connStr = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX([UserGroupID]) AS UserGroupID   FROM [DB_AMS].[dbo].[TB_UserGroup]", con);

            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            if (dt.Rows.Count > 0)
            {
                UserGroupID = Convert.ToInt32(dt.Rows[0]["UserGroupID"].ToString());

            }

            return UserGroupID;

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            Save();

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
        SqlConnection connection = null;
        private void Save()
        {

            BuildingInformationBOL entity = new BuildingInformationBOL();

            entity.BuildingName = txtBuildingName.Text.Trim();
            entity.OwnerName = txtOwnerName.Text.Trim();
            entity.ContactNo =txtContactNo.Text;
            entity.SecGaurdNo = txtSecurityGuardNo.Text;
            entity.SecretaryNo = txtSecretaryMobileNo.Text;
            entity.RajukReference = txtRajukRef.Text;
            entity.Email = txtEmailID.Text;
            entity.Address = txtAddress.Text;
            entity.Year = ddlYear.SelectedValue;
            entity.CompanyName = txtCompanyName.Text;
            entity.CompanyPhoneNo = txtCompanyPhoneNo.Text;
            entity.CompanyAddress = txtCompanyAddress.Text;
            entity.CreateBy = Session["UserID"].ToString();

            string filePath = fuProfilePic.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;
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

               

                FileUpload img = (FileUpload)fuProfilePic;
                Byte[] imgByte = null;
                byte[] bytespdf = null;
                if (img.HasFile && img.PostedFile != null)
                {
                  
                    HttpPostedFile File = fuProfilePic.PostedFile;
                    imgByte = new Byte[File.ContentLength];
                    File.InputStream.Read(imgByte, 0, File.ContentLength);

                    using (Stream fs = FileUpload1.PostedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                             bytespdf = br.ReadBytes((Int32)fs.Length);
                        }
                    }
                 

                    string conn = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
                    connection = new SqlConnection(conn);
                    connection.Open();
                    string sql = "INSERT INTO TB_AMS_BuildingInformation(BuildingImage,BuildingRules) VALUES(@eimg,@eimgpdf) SELECT @@IDENTITY";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    /// cmd.Parameters.AddWithValue("@enm", txtEName.Text.Trim());
                    cmd.Parameters.AddWithValue("@eimg", imgByte);
                    cmd.Parameters.AddWithValue("@eimgpdf", bytespdf);
                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    entity.AutoID = id;
                }
             }

            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "File format not recognised. Upload Image/Word/PDF/Excel formats";
            }

          


           
            Int32 Id = 0;
            if (string.IsNullOrEmpty(hfUserId.Value) || hfUserId.Value == "0")
            {

                //Save record
                Id = oBuildingInformationBLL.BuildingInforrmation_Update(entity);
               
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

                entity.AutoID= Convert.ToInt32(hfUserId.Value);

                Id = oBuildingInformationBLL.BuildingInforrmation_Update(entity);

              
                //if (Id > 0)
                //{
                    string myScript123 = "";
                    myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                    Clear();
                    BindList();
                //}
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
            
        }
        protected void likBtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lnkUserID = sender as LinkButton;
            GridViewRow Grow = (GridViewRow)lnkUserID.NamingContainer;
            Response.Redirect(String.Format("CreateUser?UserId={0}", Server.UrlEncode(lnkUserID.CommandArgument)));

        }
        protected void gvBuildingInformationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["BuildingImage"]);
                (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
            }

        }
        protected void gvBuildingInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            BuildingInformationBOL oBuildingInformationBOL = new BuildingInformationBOL();
            Int32 Id = Convert.ToInt32(gvBuildingInformationList.DataKeys[e.RowIndex].Value);
            oBuildingInformationBOL.AutoID = Id;
            int success = oBuildingInformationBLL.BuildingInforrmation_Delete(oBuildingInformationBOL);
            //if (success > 0)
            //{
                BindList();
            //}
        }
        protected void gvBuildingInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
            //tContUser.ActiveTabIndex = 1;
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {

            DataTable dt = new DataTable();
            BuildingInformationBOL oBuildingInformationBOL = new BuildingInformationBOL();
            Int32 Id = Convert.ToInt32(gvBuildingInformationList.DataKeys[e.NewEditIndex].Value);
            oBuildingInformationBOL.AutoID = Id;
            dt = oBuildingInformationBLL.BuildingInforrmation_GetById(oBuildingInformationBOL);
            if (dt.Rows.Count > 0)
            {

                txtBuildingName.Text = dt.Rows[0]["BuildingName"].ToString();
                txtOwnerName.Text = dt.Rows[0]["OwnerName"].ToString();
                txtEmailID.Text = dt.Rows[0]["Email"].ToString();
                txtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();

                txtSecurityGuardNo.Text = dt.Rows[0]["SecGaurdNo"].ToString();
                txtSecretaryMobileNo.Text = dt.Rows[0]["SecretaryNo"].ToString();
                txtRajukRef.Text = dt.Rows[0]["RajukReference"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();


                if (dt.Rows[0]["Year"].ToString() == "")
                {
                    ddlYear.SelectedValue = "0";
                }
                else
                {
                    ddlYear.SelectedValue = dt.Rows[0]["Year"].ToString();
                }

                txtCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                txtCompanyPhoneNo.Text= dt.Rows[0]["CompanyPhoneNo"].ToString();
                txtCompanyAddress.Text = dt.Rows[0]["CompanyAddress"].ToString();
                hfUserId.Value = dt.Rows[0]["AutoID"].ToString();

                byte[] bytes = (byte[])GetData("SELECT [AutoID],[BuildingImage] FROM [DB_AMS].[dbo].[TB_AMS_BuildingInformation] WHERE AutoID =" + Id).Rows[0]["BuildingImage"];

                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                Image1.Visible = false;
                Image1.Visible = true;
                Image1.ImageUrl = "data:image/png;base64," + base64String;
              
            }
            
           /// SetDataToControls(oBuildingInformationBOL);
        }
        private DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }
        private void SetDataToControls(BuildingInformationBOL oBuildingInformationBOL)
        {

            DataTable dt = new DataTable();
            try
            {
                txtBuildingName.Text = oBuildingInformationBOL.BuildingName.ToString();
            }
            catch
            {
                txtBuildingName.Text = "";
            }
            try
            {
                txtOwnerName.Text = oBuildingInformationBOL.OwnerName;
            }
            catch
            {
                txtOwnerName.Text = "";
            }
            try
            {
                
                txtContactNo.Text= oBuildingInformationBOL.ContactNo;

            }
            catch
            {
                txtContactNo.Text = "";
            }

            try
            {
               


                Image1.ImageUrl = oBuildingInformationBOL.ContactNo;

            }
            catch
            {
                txtContactNo.Text = "";
            }

    


            hfUserId.Value = oBuildingInformationBOL.AutoID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }
        private void Clear()
        {
            hfUserId.Value = "0";
            btnsave.Visible = true;
            btnupdate.Visible = false;


            txtBuildingName.Text = string.Empty;
            txtOwnerName.Text = string.Empty;
            txtEmailID.Text = string.Empty;
            txtContactNo.Text = string.Empty;

            txtSecurityGuardNo.Text = string.Empty;
            txtSecretaryMobileNo.Text = string.Empty;
            txtRajukRef.Text = string.Empty;
            txtAddress.Text = string.Empty;
            ddlYear.SelectedValue = "0";
            txtCompanyName.Text = string.Empty;
            txtCompanyPhoneNo.Text = string.Empty;
            txtCompanyAddress.Text = string.Empty;
            Image1.ImageUrl = UploadFolderPath;


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
                    cmd.CommandText = "SELECT  [AutoID],[BuildingRules],BuildingName FROM TB_AMS_BuildingInformation where AutoID=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["BuildingRules"];

                        fileName = "BuildingRules.pdf";
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType =  "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}