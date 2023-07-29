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
    public partial class TenantInformation : System.Web.UI.Page
    {
       
         TenantInformationBLL oTenantInformationBLL = new TenantInformationBLL();
         TenantMemberInformationBLL oTenantMemberInformationBLL = new TenantMemberInformationBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                Session["breadcrumb"] = "";
                btnsave.Visible = true;
                btnupdate.Visible = false;
                Session["PageLink"] = "AMS";
                Session["breadcrumb"] = "Settings > Tenant Information";
             
                BindList();
                LoadFloorList();
                LoadUnitList("0");
              
            }
           
           //this.RegisterPostBackControl();
        }
        else
        {
            Response.Redirect("~/UserLogin_Logout.aspx");
        }
    }
    private void LoadFloorList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_FloorListDDL";
        dt = AMS.Common.Global.CreateDataTable(sql);

        ddlFloorNo.DataSource = dt;
        ddlFloorNo.DataTextField = "FloorName";
        ddlFloorNo.DataValueField = "AutoID";
        ddlFloorNo.DataBind();


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
   
    private void BindList( )
    {


        DataTable dtLeaveHolidays = oTenantInformationBLL.TenantInformation__GetDataForGV();
        gvTenantinformationList.DataSource = dtLeaveHolidays;
        gvTenantinformationList.DataBind();
    }

    protected void ExpandButtonForColumn_Click(object sender, EventArgs e)
    {

        GridViewRow myRow = ((Control)sender).NamingContainer as GridViewRow;
        ImageButton expandBtn = sender as ImageButton;
       
        Panel KeysPanel = ((Panel)myRow.FindControl("ColumnPanel"));
        Panel btnPanel = ((Panel)myRow.FindControl("btnPanel"));
        Label LeaveCode = ((Label)myRow.FindControl("lblCode"));
        Label lblTenantID = ((Label)myRow.FindControl("lblTenantID"));

     
        if (expandBtn.ImageUrl == "~/Images/plus.png")
        {
            expandBtn.ImageUrl = "~/Images/minus.png";
            KeysPanel.Visible = true;
            btnPanel.Visible = true;           
        }
        else
        {
            expandBtn.ImageUrl = "~/Images/plus.png";
            KeysPanel.Visible = false;
            btnPanel.Visible = false;
        }

        DataTable dt = oTenantMemberInformationBLL.TenantMemberInformation_GetDataForGV(lblTenantID.Text);

        if (dt.Rows.Count > 0)
        {

            ((GridView)myRow.FindControl("gvTenantMemberInformationList")).DataSource = dt;
            ((GridView)myRow.FindControl("gvTenantMemberInformationList")).DataBind();
        }
        else
        {
            dt = null;
            ((GridView)myRow.FindControl("gvTenantMemberInformationList")).DataSource = dt;
            ((GridView)myRow.FindControl("gvTenantMemberInformationList")).DataBind();
        }
  
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Image2.ImageUrl = null;
        Image2.Visible = false;
        Clear();
       
    }

  
    protected void btnsave_Click(object sender, EventArgs e)
   {
    
       Save();
       
    }
    SqlConnection connection = null;
    private void Save()
    {

        TenantInformationBOL entity = new TenantInformationBOL();
      
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

                    string sql = "INSERT INTO TB_AMS_TenantInformation (TenantImage) VALUES(@eimg) SELECT @@IDENTITY";
                    SqlCommand cmd = new SqlCommand(sql, connection);

                    cmd.Parameters.AddWithValue("@eimg", imgByte);
                    int id = Convert.ToInt32(cmd.ExecuteScalar());

                    entity.AutoID = id;
                }
                else
                {

                    string sql1 = " UPDATE TB_AMS_TenantInformation SET TenantImage=@eimg WHERE AutoID='" + hfAutoId.Value + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, connection);

                    cmd1.Parameters.AddWithValue("@eimg", imgByte);
                    int id1 = Convert.ToInt32(cmd1.ExecuteScalar());
                    entity.AutoID =Convert.ToInt32( hfAutoId.Value);
                }
                

            }
        }
        else
        {

           

        }



        entity.TenantName = txtTenant.Text;
        entity.TenantFatherName = txttenatfatherName.Text;
       


        DateTime DOB = DateTime.ParseExact(txtTenantDateDOB.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        
        entity.TenantDOB = DOB;
        entity.TenantMaritalStatus = Convert.ToInt32(ddlMaritalStatus.SelectedValue);
        entity.TenantPermanentAddress = txtPermanentAddres.Text;
        // entity.TenantImage=
        entity.Religion = Convert.ToInt32(ddlReligion.SelectedValue);
        entity.AdvancRent = Convert.ToInt32(txtAdvanceRent.Text);
        entity.TenantContactNo = txtContact.Text;
        entity.TenantNID = txtNID.Text;
        entity.Email = txtEmailID.Text;
        entity.PresentAddress = txtPresentAddress.Text;
        entity.FloorNo = Convert.ToInt32(ddlFloorNo.SelectedValue);
        entity.RentPerMonth = Convert.ToInt32(txtRentPerMonth.Text);
        entity.TenantOccupation = txtOccupation.Text;
        entity.TenantEducation = txtEducation.Text;
        entity.EmargencyContactPerson = txtEmergencyContactPerson.Text;
        entity.EmargencyContactPersonNo = txtEmergencyContactPersonNo.Text;
        entity.OccupationAddress = txtOccupationAddress.Text;
        entity.UnitNo = Convert.ToInt32(ddlUnitNo.SelectedValue);
        DateTime IssueDate = DateTime.ParseExact(txtRentStartDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        entity.IssueDate = IssueDate;
        entity.HouseWorkerName = txtHouseWorkerName.Text;
        entity.HouseWorkerContactNo = txtHouseWorkerContactNo.Text;
        entity.HouseWorkerNID = txtHouseWorkerNID.Text;
        entity.HoseWorkerAddress = txtHouseWorkerAddress.Text;
        entity.DriverName = txtDriverName.Text;
        entity.DriverContactNo = txtDriverContactNo.Text;
        entity.DriverNID = txtDriverNIDno.Text;
        entity.DriverAddress = txtDriverAddress.Text;
        entity.PreviousHouseName = txtPreviousHouseOwnerName.Text;
        entity.PreviousHouseOwnerAddress = txtPreHouseownerAddress.Text;
        entity.PreviousHouseOwnerNo = txtPreHoouseOwnerContct.Text;
        entity.IsActive = chkIsActive.Checked;

        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
        {

            Id = oTenantInformationBLL.TenantInformation_Update(entity);




            if (Id > 0)
            {

                //entity.UserId = Convert.ToInt32(Session["UserID"].ToString());

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
         
            Id = oTenantInformationBLL.TenantInformation_Update(entity);



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
    protected void btnmemberUpdate_Click(object sender, EventArgs e)
    {
        TenantMemberInformationBOL entity = new TenantMemberInformationBOL();
        GridViewRow myRow = ((Control)sender).NamingContainer as GridViewRow;




        ImageButton expandBtn = sender as ImageButton;

        TextBox txtName = ((TextBox)myRow.FindControl("txtName"));
        TextBox txtRelation = ((TextBox)myRow.FindControl("txtRelation"));
        TextBox txtMemberOccupation = ((TextBox)myRow.FindControl("txtMemberOccupation"));
        TextBox txtMemberContact = ((TextBox)myRow.FindControl("txtMemberContact"));
        TextBox txtAge = ((TextBox)myRow.FindControl("txtAge"));
        LinkButton btnmemberSave = ((LinkButton)myRow.FindControl("btnmemberSave"));
        LinkButton btnmemberUpdate = ((LinkButton)myRow.FindControl("btnmemberUpdate"));

        FileUpload ChildImagesUpload = ((FileUpload)myRow.FindControl("MemberFileUpload1"));

        Image ChildImages2 = ((Image)myRow.FindControl("ChildImage2"));

        Label lblAutoID_Auto = ((Label)myRow.FindControl("lblAutoID_Auto"));


        entity.TenantID = lblAutoID_Auto.Text;
        entity.Name = txtName.Text;
        entity.Occupation = txtMemberOccupation.Text;
        entity.Contact = txtMemberContact.Text;
        entity.Relation = txtRelation.Text;
        entity.Age = txtAge.Text;
        entity.AutoID = Convert.ToInt32(hfAutoIdDetail.Value);






        Int32 Id = 0;
        if ( hfAutoIdDetail.Value != "0")
        {


            //Save record
            Id = oTenantMemberInformationBLL.TenantMemberInformation_Update(entity);

            if (Id > 0)
            {


                string filePath = ChildImagesUpload.PostedFile.FileName;
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


                    FileUpload img = (FileUpload)ChildImagesUpload;
                    Byte[] imgByte = null;
                    if (img.HasFile && img.PostedFile != null)
                    {

                        HttpPostedFile File = ChildImagesUpload.PostedFile;

                        imgByte = new Byte[File.ContentLength];

                        File.InputStream.Read(imgByte, 0, File.ContentLength);

                        string conn = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
                        connection = new SqlConnection(conn);

                        connection.Open();

                        string sql1 = " UPDATE TB_AMS_TenantMemberInformation SET Images=@Images WHERE AutoID='" + Id + "'";
                        SqlCommand cmd1 = new SqlCommand(sql1, connection);

                        cmd1.Parameters.AddWithValue("@Images", imgByte);
                        int id1 = Convert.ToInt32(cmd1.ExecuteScalar());

                    }
                }


                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);
                lblAutoID_Auto.Text = string.Empty;
                txtName.Text = string.Empty;
                txtMemberOccupation.Text = string.Empty;
                txtMemberContact.Text = string.Empty;
                txtRelation.Text = string.Empty;
                txtAge.Text = string.Empty;
                hfAutoIdDetail.Value = "0";

                BindList();



            }
        }

    }
    protected void btnmemberSave_Click(object sender, EventArgs e)
    {
        TenantMemberInformationBOL entity = new TenantMemberInformationBOL();
        GridViewRow myRow = ((Control)sender).NamingContainer as GridViewRow;




        ImageButton expandBtn = sender as ImageButton;

        TextBox txtName = ((TextBox)myRow.FindControl("txtName"));
        TextBox txtRelation = ((TextBox)myRow.FindControl("txtRelation"));
        TextBox txtMemberOccupation = ((TextBox)myRow.FindControl("txtMemberOccupation"));
        TextBox txtMemberContact = ((TextBox)myRow.FindControl("txtMemberContact"));
        TextBox txtAge = ((TextBox)myRow.FindControl("txtAge"));
        LinkButton btnmemberSave = ((LinkButton)myRow.FindControl("btnmemberSave"));
        LinkButton btnmemberUpdate = ((LinkButton)myRow.FindControl("btnmemberUpdate"));

        FileUpload ChildImagesUpload = ((FileUpload)myRow.FindControl("MemberFileUpload1"));

        Image ChildImages2 = ((Image)myRow.FindControl("ChildImage2"));

        Label lblAutoID_Auto = ((Label)myRow.FindControl("lblAutoID_Auto"));


        entity.TenantID = lblAutoID_Auto.Text;
        entity.Name = txtName.Text;
        entity.Occupation = txtMemberOccupation.Text;
        entity.Contact = txtMemberContact.Text;
        entity.Relation = txtRelation.Text;
        entity.Age = txtAge.Text;


      
      


        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfAutoIdDetail.Value) || hfAutoIdDetail.Value == "0")
        {

       
            //Save record
            Id = oTenantMemberInformationBLL.TenantMemberInformation_Add(entity);

            if (Id > 0)
            {


                string filePath = ChildImagesUpload.PostedFile.FileName;
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


                    FileUpload img = (FileUpload)ChildImagesUpload;
                    Byte[] imgByte = null;
                    if (img.HasFile && img.PostedFile != null)
                    {

                        HttpPostedFile File = ChildImagesUpload.PostedFile;

                        imgByte = new Byte[File.ContentLength];

                        File.InputStream.Read(imgByte, 0, File.ContentLength);

                        string conn = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
                        connection = new SqlConnection(conn);

                        connection.Open();

                        string sql1 = " UPDATE TB_AMS_TenantMemberInformation SET Images=@Images WHERE AutoID='" +Id+ "'";
                            SqlCommand cmd1 = new SqlCommand(sql1, connection);

                            cmd1.Parameters.AddWithValue("@Images", imgByte);
                            int id1 = Convert.ToInt32(cmd1.ExecuteScalar());

                    }
                }


                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);
                lblAutoID_Auto.Text = string.Empty;
                txtName.Text = string.Empty;
                txtMemberOccupation.Text = string.Empty;
                txtMemberContact.Text = string.Empty;
                txtRelation.Text = string.Empty;
                txtAge.Text = string.Empty;
                hfAutoIdDetail.Value = "0";
                BindList();

          

            }
        }
    }
    protected void btnMenberDetailNew_Click(object sender, EventArgs e)
    {

        GridViewRow myRow = ((Control)sender).NamingContainer as GridViewRow;
        TextBox txtName = ((TextBox)myRow.FindControl("txtName"));
        TextBox txtRelation = ((TextBox)myRow.FindControl("txtRelation"));
        TextBox txtMemberOccupation = ((TextBox)myRow.FindControl("txtMemberOccupation"));
        TextBox txtMemberContact = ((TextBox)myRow.FindControl("txtMemberContact"));
        TextBox txtAge = ((TextBox)myRow.FindControl("txtAge"));
        LinkButton btnmemberSave = ((LinkButton)myRow.FindControl("btnmemberSave"));
        LinkButton btnmemberUpdate = ((LinkButton)myRow.FindControl("btnmemberUpdate"));

        FileUpload ChildImagesUpload = ((FileUpload)myRow.FindControl("FileUpload"));

        Image ChildImages2 = ((Image)myRow.FindControl("ChildImage2"));
        txtName.Text = string.Empty;
        txtRelation.Text = string.Empty;
        txtMemberOccupation.Text = string.Empty;
        txtMemberContact.Text = string.Empty;
        txtAge.Text = string.Empty;
        ChildImagesUpload = null;
        ChildImages2.ImageUrl = null;
        ChildImages2.Visible = false;
        btnmemberSave.Visible = true;
        btnmemberUpdate.Visible = false;
    }
   
    protected void btnModule_Click(object sender, EventArgs e)
    {
        //int pnl2_ = 0;

        //if (pnl2Module.Visible == true)
        //{
        //    pnl1Columns.Visible = false;
        //    pnl2Module.Visible = false;
        //    pnl3Module.Visible = false;
        //    Panel4Version.Visible = false;
        //    pnl2_ = 1;
        //}

        //if (pnl2Module.Visible == false && pnl2_ == 0)
        //{
        //    pnl1Columns.Visible = false;
        //    pnl2Module.Visible = true;
        //    pnl3Module.Visible = false;
        //    Panel4Version.Visible = false;
        //}
    }

    protected void btnDateRanges_Click(object sender, EventArgs e)
    {

        //int pnl3_ = 0;

        //if (pnl3Module.Visible == true)
        //{
        //    pnl1Columns.Visible = false;
        //    pnl2Module.Visible = false;
        //    pnl3Module.Visible = false;
        //    Panel4Version.Visible = false;
        //    pnl3_ = 1;
        //}

        //if (pnl3Module.Visible == false && pnl3_ == 0)
        //{
        //    pnl1Columns.Visible = false;
        //    pnl2Module.Visible = false;
        //    pnl3Module.Visible = true;
        //    Panel4Version.Visible = false;
        //}
    }

 
    protected void gvTenantinformationList_RowDataBound(object sender, GridViewRowEventArgs e)
    {

       
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["TenantImage"]);
                (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
            }

           
        }
 
       


    }

    protected void gvTenantMemberInformationList_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;

                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Images"]);
                (e.Row.FindControl("MemberImage") as Image).ImageUrl = imageUrl;
            }


        }

    }

    protected void gvTenantinformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        TenantInformationBOL TenantInformationBOL = new TenantInformationBOL();
        Int32 Id = Convert.ToInt32(gvTenantinformationList.DataKeys[e.RowIndex].Value);
        TenantInformationBOL.AutoID = Id;

        int success = oTenantInformationBLL.TenantInformation_Delete(TenantInformationBOL);
        if (success > 0)
        {
            Clear();
            BindList();
        }

    }

    protected void gvTenantinformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        //Clear();



        GetSelectedData(e);
       
    }

    protected void gvTenantMemberInformationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow myRow = ((Control)sender).NamingContainer as GridViewRow;


        //Label lblAssignmentRef = ((Label)myRow.FindControl("lblAssignmentRef"));
        Label lblTenantID = ((Label)myRow.FindControl("lblTenantID"));

        GridView gvEmployees = sender as GridView;
        GridViewRow row = gvEmployees.Rows[e.RowIndex];
        int lblColumnAutoID = Convert.ToInt32((row.Cells[0].FindControl("lblColumnAutoID") as Label).Text);

        TenantMemberInformationBOL TenantMemberInformationBOL = new TenantMemberInformationBOL();

        TenantMemberInformationBOL.AutoID = lblColumnAutoID;

        int success = oTenantMemberInformationBLL.TenantMemberInformation_Delete(TenantMemberInformationBOL);
        DataTable dt = oTenantMemberInformationBLL.TenantMemberInformation_GetDataForGV(lblTenantID.Text);

        if (dt.Rows.Count > 0)
        {

            ((GridView)myRow.FindControl("gvTenantMemberInformationList")).DataSource = dt;
            ((GridView)myRow.FindControl("gvTenantMemberInformationList")).DataBind();
        }
        else
        {
            dt = null;
            ((GridView)myRow.FindControl("gvTenantMemberInformationList")).DataSource = dt;
            ((GridView)myRow.FindControl("gvTenantMemberInformationList")).DataBind();
        }

    }

    protected void gvTenantMemberInformationList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
      
        GridView gvEmployees = sender as GridView;
        GridViewRow row = gvEmployees.Rows[e.NewEditIndex];
        int lblColumnAutoID = Convert.ToInt32((row.Cells[0].FindControl("lblColumnAutoID") as Label).Text);
        GridViewRow myRow = ((Control)sender).NamingContainer as GridViewRow;
        Panel pnl1PayrollDetails1 = ((Panel)myRow.FindControl("pnl1PayrollDetails1"));
        TextBox txtName = ((TextBox)myRow.FindControl("txtName"));
        TextBox txtRelation = ((TextBox)myRow.FindControl("txtRelation"));
        TextBox txtMemberOccupation = ((TextBox)myRow.FindControl("txtMemberOccupation"));
        TextBox txtMemberContact = ((TextBox)myRow.FindControl("txtMemberContact"));
        TextBox txtAge = ((TextBox)myRow.FindControl("txtAge"));
        LinkButton btnmemberSave = ((LinkButton)myRow.FindControl("btnmemberSave"));
        LinkButton btnmemberUpdate = ((LinkButton)myRow.FindControl("btnmemberUpdate"));

        FileUpload ChildImagesUpload = ((FileUpload)myRow.FindControl("MemberFileUpload1"));

        Image ChildImages2 = ((Image)myRow.FindControl("ChildImage2"));

        Label lblAutoID_Auto = ((Label)myRow.FindControl("lblAutoID_Auto"));
        //pnl1PayrollDetails1.Visible = true;
        btnmemberUpdate.Visible = true;
        btnmemberSave.Visible = false;
        int Id = lblColumnAutoID;
        byte[] bytes = (byte[])GetData("SELECT AutoID ,Images FROM TB_AMS_TenantMemberInformation WHERE AutoID =" + Id).Rows[0]["Images"];
        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        ChildImages2.Visible = true;
        ChildImages2.ImageUrl = "data:image/png;base64," + base64String;


       // gvEmployees.EditIndex = e.NewEditIndex;

        TenantMemberInformationBOL TenantMemberInformationBOL = new TenantMemberInformationBOL();

        TenantMemberInformationBOL.AutoID = lblColumnAutoID;


        TenantMemberInformationBOL = oTenantMemberInformationBLL.TenantMemberInformation_GetById(TenantMemberInformationBOL);
        txtName.Text = TenantMemberInformationBOL.Name.ToString();
        txtRelation.Text = TenantMemberInformationBOL.Relation.ToString();
        txtMemberOccupation.Text = TenantMemberInformationBOL.Occupation.ToString();
        txtMemberContact.Text = TenantMemberInformationBOL.Contact.ToString();
        txtAge.Text = TenantMemberInformationBOL.Age.ToString();



        hfAutoIdDetail.Value = Convert.ToString(TenantMemberInformationBOL.AutoID);


       
    }

    protected void Show_Hide_ChildGrid(object sender, EventArgs e)
    {
        ImageButton imgShowHide = (sender as ImageButton);
        GridViewRow row = (imgShowHide.NamingContainer as GridViewRow);

       
        LinkButton btnmemberSave = ((LinkButton)row.FindControl("btnmemberSave"));
        LinkButton btnmemberUpdate = ((LinkButton)row.FindControl("btnmemberUpdate"));
        
        //txtLevaeStartDate.Text = txtAllowanceStartDate.Text;
        //txtleaveEndDate.Text = lblAllowancesEndDate.Text; 

        Label lblTenantID = ((Label)row.FindControl("lblTenantID"));

        if (imgShowHide.CommandArgument == "Show")
        {
            row.FindControl("pnlOrders").Visible = true;
            imgShowHide.CommandArgument = "Hide";
            imgShowHide.ImageUrl = "~/images/minus.png";
            string customerId = gvTenantinformationList.DataKeys[row.RowIndex].Value.ToString();
            GridView gvTenantMemberInformationList = row.FindControl("gvTenantMemberInformationList") as GridView;

            gvTenantMemberInformationList.ToolTip = customerId;



            DataTable dt = oTenantMemberInformationBLL.TenantMemberInformation_GetDataForGV(lblTenantID.Text);

            if (dt.Rows.Count > 0)
            {

                ((GridView)row.FindControl("gvTenantMemberInformationList")).DataSource = dt;
                ((GridView)row.FindControl("gvTenantMemberInformationList")).DataBind();
            }
            else
            {
                dt = null;
                ((GridView)row.FindControl("gvTenantMemberInformationList")).DataSource = dt;
                ((GridView)row.FindControl("gvTenantMemberInformationList")).DataBind();
            }
        }
        else
        {
            row.FindControl("pnlOrders").Visible = false;
            imgShowHide.CommandArgument = "Show";
            imgShowHide.ImageUrl = "~/images/plus.png";
            btnmemberSave.Visible = true;
            btnmemberUpdate.Visible = false;
          
        }
    }

    private void GetSelectedData1(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        
    }

    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        TenantInformationBOL TenantInformationBOL = new TenantInformationBOL();
        Int32 Id = Convert.ToInt32(gvTenantinformationList.DataKeys[e.NewEditIndex].Value);
        TenantInformationBOL.AutoID = Id;

        byte[] bytes = (byte[])GetData("SELECT AutoID ,TenantImage FROM TB_AMS_TenantInformation WHERE AutoID =" + Id).Rows[0]["TenantImage"];
        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        Image2.Visible = true;
        Image2.ImageUrl = "data:image/png;base64," + base64String;

        TenantInformationBOL = oTenantInformationBLL.TenantInformation_GetById(TenantInformationBOL);
        SetDataToControls(TenantInformationBOL);
    }

    private void SetDataToControls(TenantInformationBOL TenantInformation)
    {

        try
        {
           txtTenant.Text = TenantInformation.TenantName.ToString(); ;
        }
        catch
        {
            txtTenant.Text = "";
        }

        try
        {
            txttenatfatherName.Text= TenantInformation.TenantFatherName.ToString(); ;
        }
        catch
        {
            txttenatfatherName.Text = "";
        }

        try
        {
            txtTenantDateDOB.Text = TenantInformation.TenantDOBBind.ToString(); ;
        }
        catch
        {
            txtTenantDateDOB.Text = "";
        }

        try
        {
            ddlMaritalStatus.SelectedValue = TenantInformation.TenantMaritalStatus.ToString();
        }
        catch
        {
            ddlMaritalStatus.SelectedValue = "0";
        }

        try
        {
            txtPermanentAddres.Text = TenantInformation.TenantPermanentAddress.ToString() ;
        }
        catch
        {
            txtPermanentAddres.Text = "";
        }

        try
        {
            ddlReligion.SelectedValue= TenantInformation.Religion.ToString();
        }
        catch
        {
            ddlReligion.SelectedValue = "0";
        }

        try
        {
            txtAdvanceRent.Text = TenantInformation.AdvancRent.ToString();
        }
        catch
        {
            txtAdvanceRent.Text = "";
        }


        try
        {
           txtContact.Text = TenantInformation.TenantContactNo.ToString();
        }
        catch
        {
            txtContact.Text = "";
        }

        try
        {
            txtNID.Text = TenantInformation.TenantNID.ToString();
        }
        catch
        {
            txtNID.Text = "";
        }

        try
        {
           txtEmailID.Text = TenantInformation.Email.ToString();
        }
        catch
        {
            txtEmailID.Text = "";
        }

        try
        {
            txtPresentAddress.Text= TenantInformation.PresentAddress.ToString();
        }
        catch
        {
            txtPresentAddress.Text = "";
        }

        try
        {
            ddlFloorNo.SelectedValue= TenantInformation.FloorNo.ToString();
        }
        catch
        {
            ddlFloorNo.SelectedValue = "0";
        }

        try
        {
            ddlUnitNo.SelectedValue= TenantInformation.UnitNo.ToString();
        }
        catch
        {
            ddlUnitNo.SelectedValue = "0";
        }

        try
        {
            txtRentPerMonth.Text = TenantInformation.RentPerMonth.ToString();
        }
        catch
        {
            txtRentPerMonth.Text = "";
        }

        try
        {
            txtOccupation.Text = TenantInformation.TenantOccupation.ToString();
        }
        catch
        {
            txtOccupation.Text = "";
        }
        try
        {
           txtOccupationAddress.Text = TenantInformation.OccupationAddress.ToString();
        }
        catch
        {
            txtOccupationAddress.Text = "";
        }


        try
        {
            txtEducation.Text = TenantInformation.TenantEducation.ToString();
        }
        catch
        {
            txtEducation.Text = "";
        }

        try
        {
            txtEmergencyContactPerson.Text = TenantInformation.EmargencyContactPerson.ToString();
        }
        catch
        {
            txtEmergencyContactPerson.Text = "";
        }

        try
        {
            txtEmergencyContactPersonNo.Text = TenantInformation.EmargencyContactPersonNo.ToString();
        }
        catch
        {
            txtEmergencyContactPersonNo.Text = "";
        }


        try
        {
           txtRentStartDate.Text = TenantInformation.IssueDateBind.ToString();
        }
        catch
        {
            txtRentStartDate.Text = "";
        }

        try
        {
          txtHouseWorkerName.Text= TenantInformation.HouseWorkerName.ToString();
        }
        catch
        {
            txtHouseWorkerName.Text = "";
        }

        try
        {
            txtHouseWorkerContactNo.Text = TenantInformation.HouseWorkerContactNo.ToString();

        }
        catch
        {
            txtHouseWorkerContactNo.Text = "";
        }

        try
        {
            txtHouseWorkerNID.Text = TenantInformation.HouseWorkerNID.ToString();

        }
        catch
        {
            txtHouseWorkerNID.Text = "";
        }

        try
        {
           txtHouseWorkerAddress.Text = TenantInformation.HoseWorkerAddress.ToString();

        }
        catch
        {
            txtHouseWorkerAddress.Text = "";
        }

        try
        {
            txtHouseWorkerAddress.Text = TenantInformation.HoseWorkerAddress.ToString();

        }
        catch
        {
            txtHouseWorkerAddress.Text = "";
        }


        try
        {
            txtDriverName.Text = TenantInformation.DriverName.ToString();

        }
        catch
        {
            txtDriverName.Text = "";
        }

        try
        {
            txtDriverContactNo.Text = TenantInformation.DriverContactNo.ToString();

        }
        catch
        {
            txtDriverContactNo.Text = "";
        }

        try
        {
            txtDriverNIDno.Text = TenantInformation.DriverNID.ToString();

        }
        catch
        {
            txtDriverNIDno.Text = "";
        }


        try
        {
            txtDriverAddress.Text = TenantInformation.DriverAddress.ToString();

        }
        catch
        {
            txtDriverAddress.Text = "";
        }



        try
        {
            txtPreviousHouseOwnerName.Text = TenantInformation.PreviousHouseName.ToString();

        }
        catch
        {
            txtPreviousHouseOwnerName.Text = "";
        }



        try
        {
           txtPreHouseownerAddress.Text= TenantInformation.PreviousHouseOwnerAddress.ToString();

        }
        catch
        {
            txtPreHouseownerAddress.Text = "";
        }


        try
        {
            txtPreHoouseOwnerContct.Text = TenantInformation.PreviousHouseOwnerNo.ToString();

        }
        catch
        {
            txtPreHoouseOwnerContct.Text = "";
        }

        if (TenantInformation.IsActive == true)
        {
            chkIsActive.Checked = true;
        }
        else
        {
            chkIsActive.Checked = false;
        }

        hfAutoId.Value = TenantInformation.AutoID.ToString();
        btnsave.Visible = false;
        btnupdate.Visible = true;
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
  
   
    protected void ddlFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadUnitList(ddlFloorNo.SelectedValue);

    }
  
    private void Clear()
    {


     
            txtTenant.Text = "";
       
            txttenatfatherName.Text = "";
      
            txtTenantDateDOB.Text = "";
      
            ddlMaritalStatus.SelectedValue = "0";
     
            txtPermanentAddres.Text = "";
      
            ddlReligion.SelectedValue = "0";
       
            txtAdvanceRent.Text = "";
      
            txtContact.Text = "";
       
            txtNID.Text = "";
       
            txtEmailID.Text = "";
      
            txtPresentAddress.Text = "";
       
            ddlFloorNo.SelectedValue = "0";
      
            ddlUnitNo.SelectedValue = "0";
      
            txtRentPerMonth.Text = "";
    
            txtOccupation.Text = "";
       
      
            txtOccupationAddress.Text = "";
       
            txtEducation.Text = "";
      
            txtEmergencyContactPerson.Text = "";
       
            txtEmergencyContactPersonNo.Text = "";
       
            txtRentStartDate.Text = "";
       
            txtHouseWorkerName.Text = "";
       
            txtHouseWorkerContactNo.Text = "";
       
            txtHouseWorkerNID.Text = "";
        
            txtHouseWorkerAddress.Text = "";
       
            txtHouseWorkerAddress.Text = "";
       
            txtDriverName.Text = "";
       
            txtDriverContactNo.Text = "";
       
            txtDriverNIDno.Text = "";
     
            txtDriverAddress.Text = "";
      
            txtPreviousHouseOwnerName.Text = "";
       
            txtPreHouseownerAddress.Text = "";
       
            txtPreHoouseOwnerContct.Text = "";
       
            chkIsActive.Checked = false;
        
        hfAutoId.Value = "0";
        hfAutoIdDetail.Value = "0";
        btnsave.Visible = true;
        btnupdate.Visible = false;

        
     
         hfLeaveHolidaysMasterComments.Value = "";
     
    }
  

    }
}