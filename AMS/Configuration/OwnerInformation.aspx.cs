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
    public partial class OwnerInformation : System.Web.UI.Page
    {
        OwnerInformationBLL oOwnerInformationBLL = new OwnerInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                    Session["breadcrumb"] = "Settings > Owner Information";
                    Clear();
                    BindList();
                    //LoadUnitID();
                    BindFlatNameFloor();
                    // SystemUsageAuditLogInsert("1008");
                
                }
            }
            else
            {
                Response.Redirect("~/UserLogin_Logout.aspx");
            }


        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
           Clear();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            Save();

        }
        private void BindFlatNameFloor()
        {


            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["ConS2pibd"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.CommandText = @" SELECT [AutoID],[UnitName],[FloorID]  FROM [DB_AMS].[dbo].[TB_AMS_UnitInformation]";

                    chkFields.Items.Clear();
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem();
                            item.Text = sdr["UnitName"].ToString();
                            item.Value = sdr["AutoID"].ToString();
                            item.Selected = false; // Convert.ToBoolean(sdr["IsSelected"]);
                            chkFields.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }




        }
        private void Save()
        {
            SqlConnection connection = null;
            OwnerInformationBOL entity = new OwnerInformationBOL();

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
                    if (string.IsNullOrEmpty(hfUserId.Value) || hfUserId.Value == "0")
                    {

                        string sql = "INSERT INTO TB_AMS_OwnerInformation (Owner_Picture) VALUES(@eimg) SELECT @@IDENTITY";
                        SqlCommand cmd = new SqlCommand(sql, connection);

                        cmd.Parameters.AddWithValue("@eimg", imgByte);
                        int id = Convert.ToInt32(cmd.ExecuteScalar());

                        entity.AutoID = id;
                    }
                    else
                    {

                        string sql1 = " UPDATE TB_AMS_OwnerInformation SET Owner_Picture=@eimg WHERE AutoID='" + hfUserId.Value + "'";
                        SqlCommand cmd1 = new SqlCommand(sql1, connection);

                        cmd1.Parameters.AddWithValue("@eimg", imgByte);
                        int id1 = Convert.ToInt32(cmd1.ExecuteScalar());
                        //entity.AutoID = Convert.ToInt32(hfUserId.Value);
                    }


                }
            }
            else
            {



            }





            entity.OwnerName = txtOwnerName.Text.Trim();
            entity.Email = txtEmailID.Text;
            entity.ContactNo = txtContactNo.Text;
            entity.National_Id_card_No = txtNIDno.Text;
            entity.Present_Address = txtPresentAddress.Text;
            entity.Permanent_Address = txtPermanentAddress.Text;
  
            entity.CreateBy = Session["UserID"].ToString();


            

           
            
            Int32 Id = 0;
     
            if (string.IsNullOrEmpty(hfUserId.Value) || hfUserId.Value == "0")
            {

                //Save record
                Id = oOwnerInformationBLL.OwnerUnitInforrmation_Update(entity);


                entity.AutoID = Id;
                for (int i = 0; i < chkFields.Items.Count; i++)
                {
                    if (chkFields.Items[i].Selected)
                    {

                        entity.UnitId = Convert.ToInt32(chkFields.Items[i].Value);
                        Int32 Identity = oOwnerInformationBLL.OwnerUnitInforrmation_Add(entity);

                    }

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

                entity.AutoID = Convert.ToInt32(hfUserId.Value);

                entity.ChangedBy = Session["UserID"].ToString();

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

                        string sql1 = " UPDATE TB_AMS_OwnerInformation SET Owner_Picture=@Images WHERE AutoID='" + hfUserId.Value + "'";
                        SqlCommand cmd1 = new SqlCommand(sql1, connection);

                        cmd1.Parameters.AddWithValue("@Images", imgByte);
                        Int32 id1 = Convert.ToInt32(cmd1.ExecuteScalar());

                    }
                }

                Id = oOwnerInformationBLL.OwnerUnitInforrmation_Update(entity);


                string connn = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
                connection = new SqlConnection(connn);

                connection.Open();

                string sql11 = "DELETE FROM TB_AMS_OwnerInformationDetail WHERE OwnerID='" + Id + "'";
                SqlCommand cmd11 = new SqlCommand(sql11, connection);

               
                Int32 id = Convert.ToInt32(cmd11.ExecuteScalar());


                for (int i = 0; i < chkFields.Items.Count; i++)
                {
                    if (chkFields.Items[i].Selected)
                    {

                        entity.UnitId = Convert.ToInt32(chkFields.Items[i].Value);
                        Int32 Identity = oOwnerInformationBLL.OwnerUnitInforrmation_Add(entity);

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
        protected void gvOwnerInformationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Owner_Picture"]);
                (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
            }


        }
        protected void gvOwnerInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            OwnerInformationBOL oUnitInformationBOL = new OwnerInformationBOL();
            Int32 Id = Convert.ToInt32(gvOwnerInformationList.DataKeys[e.RowIndex].Value);
            oUnitInformationBOL.AutoID = Id;
            int success = oOwnerInformationBLL.OwnerInforrmation_Delete(oUnitInformationBOL);
            if (success > 0)
            {
                BindList();
            }
        }
        protected void gvOwnerInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
            //tContUser.ActiveTabIndex = 1;
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            OwnerInformationBOL oOwnerInformationBOL = new OwnerInformationBOL();
            Int32 Id = Convert.ToInt32(gvOwnerInformationList.DataKeys[e.NewEditIndex].Value);
            oOwnerInformationBOL.AutoID = Id;

            byte[] bytes = (byte[])GetData("SELECT  [AutoID],[Owner_Picture] FROM  TB_AMS_OwnerInformation WHERE AutoID =" + Id).Rows[0]["Owner_Picture"];
           
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            Image2.Visible = true;
            Image2.ImageUrl = "data:image/png;base64," + base64String;

            oOwnerInformationBOL = oOwnerInformationBLL.OwnerInformation_GetById(oOwnerInformationBOL);
            SetDataToControls(oOwnerInformationBOL);





      

            DataTable dt = new DataTable();
            dt = null;
            string sql = "SP_TB_AMS_OwnerInformationDetailByID";
            dt = AMS.Common.Global.CreateDataTableParameter_UnitInfoByOnwer(sql, Id);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < chkFields.Items.Count; j++)
                {
                    if (Convert.ToInt32(chkFields.Items[j].Value) == Convert.ToInt32(dt.Rows[i]["UnitID"].ToString()))
                    {

                        chkFields.Items[j].Selected = true;
                    }
                }
            }

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
  
        private void SetDataToControls(OwnerInformationBOL oOwnerInformationBOL)
        {

            try
            {
                txtOwnerName.Text = oOwnerInformationBOL.OwnerName.ToString();
            }
            catch
            {
                txtOwnerName.Text = "";
            }

            try
            {
                txtEmailID.Text = oOwnerInformationBOL.Email.ToString();
            }
            catch
            {
                txtEmailID.Text = "";
            }

            try
            {
               txtNIDno.Text = oOwnerInformationBOL.National_Id_card_No.ToString();
            }
            catch
            {
                txtNIDno.Text = "";
            }


            try
            {
                txtPresentAddress.Text = oOwnerInformationBOL.Present_Address.ToString();
            }
            catch
            {
                txtPresentAddress.Text = "";
            }

            try
            {
                txtPermanentAddress.Text = oOwnerInformationBOL.Permanent_Address.ToString();
            }
            catch
            {
                txtPermanentAddress.Text = "";
            }


            try
            {
                txtContactNo.Text = oOwnerInformationBOL.ContactNo.ToString();
            }
            catch
            {
                txtContactNo.Text = "";
            }




            hfUserId.Value = oOwnerInformationBOL.AutoID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }
        private void Clear()
        {
            txtOwnerName.Text = string.Empty;

            hfUserId.Value = "0";
           
            txtOwnerName.Text = "";
            txtEmailID.Text = "";
            txtNIDno.Text = "";
            txtPresentAddress.Text = "";
            txtPermanentAddress.Text = "";
            txtContactNo.Text = "";
            Image2.Visible = false;
            Image2.ImageUrl = null;

            btnsave.Visible = true;
            btnupdate.Visible = false;
            foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
            {

                item.Selected = false;


            }

        }
        private void BindList()
        {
            //List<User> userList = oUserBLL.User_GetAll();
            DataTable dt = oOwnerInformationBLL.OwnerInforrmation__GetDataForGV();
            gvOwnerInformationList.DataSource = dt;
            gvOwnerInformationList.DataBind();
        }
        private Boolean InsertUpdateData(SqlCommand cmd)
        {
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // Read the file and convert it to Byte Array
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

                Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                //insert the file into database
                string strQuery = "insert into tblFiles(Name, ContentType, Data) values (@Name, @ContentType, @Data)";
                SqlCommand cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename;
                cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype;
                cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
                InsertUpdateData(cmd);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "File Uploaded Successfully";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "File format not recognised. Upload Image/Word/PDF/Excel formats";
            }
        }
    }
}