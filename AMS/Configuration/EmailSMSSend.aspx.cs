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
using System.Net.Mail;


namespace AMS.Configuration
{
    public partial class EmailSMSSend : System.Web.UI.Page
    {

        EmployeeNoticeInformationBLL oEmployeeNoticeInformationBLL = new EmployeeNoticeInformationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    Session["breadcrumb"] = "Settings>Send Email / SMS";
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                    BindList();
                    LoadOwnertlist();
                    LoadEmployeelist();
                    LoadTenantlist();
                    

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



            //EmployeeNoticeInformationBOL entity = new EmployeeNoticeInformationBOL();

           
            //if (txtMassageSubject.Text != "")
            //{
            //    DateTime dtpJoiningDate = DateTime.ParseExact(txtMassageSubject.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //    DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
            //    entity.Date = JoiningDate;
            //}
            //else
            //{
            //    entity.Date = Convert.ToDateTime("01/01/1991");

            //}

            //string filePath = FileUpload1.PostedFile.FileName;
            //string filename = Path.GetFileName(filePath);
            //string ext = Path.GetExtension(filename);
            //string contenttype = String.Empty;

            ////Set the contenttype based on File Extension
            //switch (ext)
            //{
            //    case ".doc":
            //        contenttype = "application/vnd.ms-word";
            //        break;
            //    case ".docx":
            //        contenttype = "application/vnd.ms-word";
            //        break;
            //    case ".xls":
            //        contenttype = "application/vnd.ms-excel";
            //        break;
            //    case ".xlsx":
            //        contenttype = "application/vnd.ms-excel";
            //        break;
            //    case ".jpg":
            //        contenttype = "image/jpg";
            //        break;
            //    case ".png":
            //        contenttype = "image/png";
            //        break;
            //    case ".gif":
            //        contenttype = "image/gif";
            //        break;
            //    case ".pdf":
            //        contenttype = "application/pdf";
            //        break;
            //}
            //if (contenttype != String.Empty)
            //{


            //    //FileUpload img = (FileUpload)FileUpload1;
            //    //Byte[] imgByte = null;
            //    //if (img.HasFile && img.PostedFile != null)
            //    //{

            //    //    HttpPostedFile File = FileUpload1.PostedFile;

            //    //    imgByte = new Byte[File.ContentLength];

            //    //    File.InputStream.Read(imgByte, 0, File.ContentLength);


            //        string conn = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
            //        connection = new SqlConnection(conn);

            //        connection.Open();
            //        if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
            //        {

            //            //string sql = "INSERT INTO TB_AMS_EmployeeNoticeInformation (NoticeFile) VALUES(@eimg) SELECT @@IDENTITY";
            //            //SqlCommand cmd = new SqlCommand(sql, connection);

            //            //cmd.Parameters.AddWithValue("@eimg", imgByte);
            //            //int id = Convert.ToInt32(cmd.ExecuteScalar());
            //            //entity.AutoID = id;
            //            entity.CreateBy = Session["UserID"].ToString();

            //            //Save record
            //            if( id>0)
            //            {
            //                Int32  Id = oEmployeeNoticeInformationBLL.EmployeeNoticeInformation_Add(entity);
            //                string myScript123 = "";
            //                myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
            //                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);
            //                Clear();
            //                BindList();
            //            }

            //        }
            //        else
            //        {

            //            //string sql1 = " UPDATE TB_AMS_EmployeeNoticeInformation SET NoticeFile=@eimg WHERE AutoID='" + hfAutoId.Value + "'";
            //            //SqlCommand cmd1 = new SqlCommand(sql1, connection);

            //            //cmd1.Parameters.AddWithValue("@eimg", imgByte);
            //            //int id1 = Convert.ToInt32(cmd1.ExecuteScalar());
            //            //entity.AutoID = Convert.ToInt32(hfAutoId.Value);

            //            Int32 hFvAL = Convert.ToInt32(hfAutoId.Value);
            //            entity.ChangedBy = Session["UserID"].ToString();
            //            if (hFvAL > 0)
            //            {
            //                Int32 Id = oEmployeeNoticeInformationBLL.EmployeeNoticeInformation_Update(entity);
            //                string myScript123 = "";
            //                myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
            //                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

            //                Clear();
            //                BindList();
            //            }
            //      //  }


            //    }
            //}
            //else
            //{



            //}


        }
  
        private void BindList()
        {

            //DataTable dt = oEmployeeNoticeInformationBLL.EmployeeNoticeInformation_GetDataForGV();
            //gvEmployeeNoticeInformationList.DataSource = dt;
            //gvEmployeeNoticeInformationList.DataBind();
        }
     
        protected void gvEmployeeNoticeInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //EmployeeNoticeInformationBOL oEmployeeNoticeInformationBOL = new EmployeeNoticeInformationBOL();
            //Int32 Id = Convert.ToInt32(gvEmployeeNoticeInformationList.DataKeys[e.NewEditIndex].Value);
            //oEmployeeNoticeInformationBOL.AutoID = Id;

            //oEmployeeNoticeInformationBOL = oEmployeeNoticeInformationBLL.EmployeeNoticeInformation_GetById(oEmployeeNoticeInformationBOL);
            //SetDataToControls(oEmployeeNoticeInformationBOL);

        }
        private void SetDataToControls(EmployeeNoticeInformationBOL oEmployeeNoticeInformationBOL)
        {

            //try
            //{
            //    txtMassageSubject.Text = oEmployeeNoticeInformationBOL.DateBind.ToString();
            //}
            //catch
            //{
            //    txtMassageSubject.Text = "";
            //}

           

          


            hfAutoId.Value = oEmployeeNoticeInformationBOL.AutoID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }
        private void Clear()
        {
            
            txtMassageSubject.Text = "";
           
            btnsave.Visible = true;
            btnupdate.Visible = false;
            hfAutoId.Value = "0";

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
        protected void chkEmp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmp.Checked == true)
            {
                foreach (System.Web.UI.WebControls.ListItem item in chkEmpList.Items)
                {

                    item.Selected = true;


                }
            }
            else
            {
                foreach (System.Web.UI.WebControls.ListItem item in chkEmpList.Items)
                {

                    item.Selected = false;


                }
            }
        }
        protected void chkOwner_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOwner.Checked == true)
            {
                foreach (System.Web.UI.WebControls.ListItem item in chkListOwner.Items)
                {

                    item.Selected = true;


                }
            }
            else
            {
                foreach (System.Web.UI.WebControls.ListItem item in chkListOwner.Items)
                {

                    item.Selected = false;


                }
            }
        }
        protected void btnColumns_Click(object sender, EventArgs e)
        {
            int pnl1_ = 0;
            if (pnl1Columns.Visible == true)
            {
                pnl1Columns.Visible = false;
                Panel1.Visible = true;
                pnl3Module.Visible = false;
                Panel4Version.Visible = false;
                pnl1_ = 1;
            }

            if (pnl1Columns.Visible == false && pnl1_ == 0)
            {
                pnl1Columns.Visible = true;
                Panel1.Visible = false;
                pnl3Module.Visible = false;
                Panel4Version.Visible = false;
            }

        }
        protected void btnVersion_Click(object sender, EventArgs e)
        {
            int pnl4_ = 0;

            if (Panel4Version.Visible == true)
            {
                pnl1Columns.Visible = false;
                Panel1.Visible = false;
                pnl3Module.Visible = false;
                Panel4Version.Visible = false;
                pnl4_ = 1;
            }

            if (Panel4Version.Visible == false && pnl4_ == 0)
            {
                pnl1Columns.Visible = false;
                Panel1.Visible = false;
                pnl3Module.Visible = false;
                Panel4Version.Visible = true;
            }

        }
        protected void btnModule_Click(object sender, EventArgs e)
        {
            int pnl2_ = 0;

            if (pnl2Module.Visible == true)
            {
                pnl1Columns.Visible = false;
                Panel1.Visible = true  ;
                pnl3Module.Visible = false;
                Panel4Version.Visible = false;
                pnl2_ = 1;
            }

            if (pnl2Module.Visible == false && pnl2_ == 0)
            {
                pnl1Columns.Visible = false;
                Panel1.Visible = false  ;
                pnl3Module.Visible = false;
                Panel4Version.Visible = false;
            }
        }
        protected void btnDateRanges_Click(object sender, EventArgs e)
        {

            int pnl3_ = 0;

            if (pnl3Module.Visible == true)
            {
                pnl1Columns.Visible = false;
                Panel1.Visible = false;
                pnl3Module.Visible = false;
                Panel4Version.Visible = false;
                pnl3_ = 1;
            }

            if (pnl3Module.Visible == false && pnl3_ == 0)
            {
                pnl1Columns.Visible = false;
                Panel1.Visible = false;
                pnl3Module.Visible = true;
                Panel4Version.Visible = false;
            }
        }
        private void LoadOwnertlist()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["ConS2pibd"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT  [OwnerID]
	              ,F.FloorName+'--'+U.UnitName+'--'+O.OwnerName AS  OwnerName
                  FROM TB_AMS_OwnerInformationDetail OD
                  LEFT OUTER JOIN TB_AMS_OwnerInformation  O ON OD.OwnerID=O.AutoID
                  LEFT OUTER JOIN TB_AMS_UnitInformation U ON U.AutoID=OD.UnitID
                  LEFT OUTER JOIN TB_AMS_FloorInformation F ON U.FloorID=F.AutoID
                  WHERE OwnerName IS NOT NULL AND O.IsAcitive=1
                  ORDER BY OwnerID ASC";
                    chkFields.Items.Clear();
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem();
                            item.Text = sdr["OwnerName"].ToString();
                            item.Value = sdr["OwnerID"].ToString();
                            item.Selected = true; // Convert.ToBoolean(sdr["IsSelected"]);
                            if (item.Text != "")
                            {
                                chkListOwner.Items.Add(item);
                            }
                            // chkFields.Items.Add(item);


                        }
                    }
                    conn.Close();
                }
            }

        }
        private void LoadTenantlist()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["ConS2pibd"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT T.[AutoID]
      ,F.FloorName + '--' + U.UnitName + '--' +   [TenantName]  AS [TenantName]
	 FROM TB_AMS_TenantInformation  T
     LEFT OUTER JOIN  TB_AMS_FloorInformation F  ON T.FloorNo=F.AutoID
     LEFT OUTER JOIN  TB_AMS_UnitInformation U ON U.FloorID=F.AutoID     WHERE  T.IsActive=1
     ORDER BY F.AutoID ASC";
                    chkFields.Items.Clear();
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem();
                            item.Text = sdr["TenantName"].ToString();
                            item.Value = sdr["AutoID"].ToString();
                            item.Selected = true; // Convert.ToBoolean(sdr["IsSelected"]);
                            if (item.Text != "")
                            {
                                chkFields.Items.Add(item);
                            }
                            // chkFields.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }

        }
        private void LoadEmployeelist()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["ConS2pibd"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT [AutoID],[Name]
                     FROM TB_AMS_EmployeeInformation
                     WHERE IsActive=1";
                    chkFields.Items.Clear();
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem();
                            item.Text = sdr["Name"].ToString();
                            item.Value = sdr["AutoID"].ToString();
                            item.Selected = true; // Convert.ToBoolean(sdr["IsSelected"]);
                            if (item.Text != "")
                            {
                                chkEmpList.Items.Add(item);
                            }
                            // chkFields.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }

        }
        protected void gvEmployeeNoticeInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            //EmployeeNoticeInformationBOL entity = new EmployeeNoticeInformationBOL();
            //Int32 Id = Convert.ToInt32(gvEmployeeNoticeInformationList.DataKeys[e.RowIndex].Value);
            //entity.AutoID = Id;
            //int success = oEmployeeNoticeInformationBLL.EmployeeNoticeInformation_Delete(entity);
            //if (success > 0)
            //{
            //    BindList();
            //}
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
                    cmd.CommandText = "SELECT  [AutoID],NoticeFile FROM TB_AMS_EmployeeNoticeInformation where AutoID=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["NoticeFile"];

                        fileName = "EmployeeNoticeFiles.pdf";
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
        protected void btnSend_Click(object sender, EventArgs e)
        {
           
            
            
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            mail.To.Add("shimul_cseuu@yahoo.com");

            mail.From = new MailAddress("shahabuddinshimul@gmail.com", "Email head", System.Text.Encoding.UTF8);

            mail.Subject = txtMassageSubject.Text.Trim();

            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            mail.Body = txtMessage.Text;

            mail.BodyEncoding = System.Text.Encoding.UTF8;

            mail.IsBodyHtml = true;

            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();

            client.Credentials = new System.Net.NetworkCredential("shahabuddinshimul@gmail.com", "lamia2020@");

            client.Port = 587;

            client.Host = "smtp.gmail.com";

            client.EnableSsl = true;
            try
            {
                client.Send(mail);
               
                //Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='SendMail.aspx';}</script>");
           
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
               // Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
            }




        }
    }
}