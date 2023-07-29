<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="EmployeeLeaveAcceptanceList.aspx.cs" Inherits="AMS.Configuration.EmployeeLeaveAcceptanceList" %>

 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
   <style type="text/css">
  td, tr ,th
 {
  border:0; 
 }
     
     .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
    padding: 8px;
    line-height: 1.42857143;
    vertical-align: top;
    border-top: 0px solid #ddd;
}

 </style>
     <style type="text/css">
        .Background
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .Popup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
           width: 500px;
            height: 350px;
        }
        .lbl
        {
            font-size:16px;
            font-style:italic;
            font-weight:bold;
        }
        
      
    </style>



  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField ID="hftakenDayForEdit" runat="server" />
            <div class="widget-box">
                <div class="widget-header">
                    <div class="row">
                        <div class="col-md-5">
                            <h4 class="widget-title">
                                <i class="icon-th"></i>&nbsp;Employee Leave Request</h4>
                                 <asp:Button ID="Button1"  Enabled="false"  runat="server"  BackColor="White" BorderStyle="None" Text="" style=" float:right; margin-right:12px"  />
                      
                        </div>

                          <asp:Button ID="btnNew"  Text="New" runat="server" Font-Bold="true" OnClick="btnNew_Click"  Font-Size="14px" CssClass="btn btn-purple" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;" />      
                       
                       <%----<asp:LinkButton ID="btnsave" runat="server" Visible="false" CssClass="btn btn-success"  OnClick="btnsave_Click" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;"> <i class="icon-save bigger-100"  ></i>&nbsp;Save</asp:LinkButton>&nbsp;&nbsp;
                          <asp:LinkButton ID="btnupdate" runat="server" Visible="false"  CssClass="btn btn-success"   OnClick="btnsave_Click" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;"> <i class="icon-edit bigger-100"  ></i>&nbsp;Update</asp:LinkButton>&nbsp;&nbsp;
                           -----%>

                    </div>
                </div>
                <div class="widget-body">
                <asp:Panel ID="pnl2Module" runat="server"  Style="padding: 5px;">
                        <div class="widget-main no-padding">
                            <div class="space-4">
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="row">
                                      <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                   
                                       <asp:Label ID="lblName" runat="server" Text="Employee Name :"></asp:Label>
                                      </div>
                                     <div class="col-md-7">
                                         <asp:DropDownList ID="ddlEmployeeID" runat="server" CssClass="select2" AutoPostBack="True"  OnSelectedIndexChanged="ddlEmployerID_SelectedIndexChanged">
                                              
                                            </asp:DropDownList>
                                     </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                </div>
                                <div class="col-md-4">
                                   <div class="row">
                                      <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                  
                                       <asp:Label ID="Label4" runat="server" Text="From Date :"></asp:Label>
                                     </div>
                                     <div class="col-md-7">
                                         <div class="input-group">
                                                <asp:TextBox ID="txtStartDate" placeholder="From Date" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                      </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                               
                                </div>
                                <div class="col-md-4">
                                     <div class="row">
                                      <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                  
                                       <asp:Label ID="Label1" runat="server" Text="To Date :"></asp:Label>
                                     </div>
                                     <div class="col-md-7">
                                         <div class="input-group">
                                                <asp:TextBox ID="txtLeaveEndDate" placeholder="To Date" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                      </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                
                                </div>

                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <asp:HiddenField ID="hfAutoId" runat="server" />
              
            </div>
               <div class="row">
                    <div class="col-md-2">

                        <asp:LinkButton ID="btnprint" runat="server" CssClass="btn btn-xs btn-purple btn-sm"  Style="font-weight: bold; font-size: 14px;"><span class="ace-icon fa fa-search icon-on-right bigger-110"></span>&nbsp;Search</asp:LinkButton>
                    </div>
                    <div class="col-md-10" style="text-align: right;">

                        <asp:LinkButton ID="btnAllAbsence" runat="server"  CssClass="btn  btn-xs btn-success btn-sm"  Style="font-weight: bold; font-size: 14px;"> <i class="ace-icon fa fa-reply icon-only bigger-100"></i> &nbsp;Expot To Excel</asp:LinkButton>
                    </div>

               </div>


                   <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Button1" CancelControlID="Button2" BackgroundCssClass="Background"> </cc1:ModalPopupExtender>
                       <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">
                        <h2> Do you want to change  date & time!</h2>
     
                          <br/>
                           <div class="row">
                                        <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label5" runat="server" Text="Leave Start Date :"></asp:Label>
                                        </div>
                                        <div class="col-md-6" style=" margin-right: 55px">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtLeaveStartDate" placeholder="Leave Start Date" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                   
                                        </div>
                                    </div>
                                      <div class="space-4">
                                    </div>
       
                             <div class="row">
                                        <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label2" runat="server" Text="Leave Start Time :"></asp:Label>
                                        </div>
                                        <div class="col-md-6" style=" margin-right: 55px">
                                             <div class="input-group bootstrap-timepicker">
                                        <asp:TextBox ID="txtStartTime" CssClass="form-control timepicker1" runat="server" placeholder="In Time"></asp:TextBox>
                                        <span class="input-group-addon"><i class="icon-time bigger-110"></i></span>
                                    </div>
                                   
                                        </div>
                                    </div>
                                      <div class="space-4">
                                    </div>
                                     <div class="row">
                                        <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label6" runat="server" Text="Leave End Date :"></asp:Label>
                                        </div>
                                        <div class="col-md-6" style=" margin-right: 55px">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtEndDate" placeholder="Leave End Date" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                   
                                        </div>
                                    </div>
                                      <div class="space-4">
                                    </div>
       
                             <div class="row">
                                        <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label3" runat="server" Text="Leave End Time :"></asp:Label>
                                        </div>
                                        <div class="col-md-6" style=" margin-right: 55px ">
                                             <div class="input-group bootstrap-timepicker">
                                        <asp:TextBox ID="txtEndTime" CssClass="form-control timepicker1" runat="server" placeholder="Time"></asp:TextBox>
                                        <span class="input-group-addon"><i class="icon-time bigger-110"></i></span>
                                    </div>
                                   
                                        </div>
                                    </div>
                            <br/>
                       <asp:Button ID="Button2" runat="server" Text="Close"   CssClass="btn btn-xs btn-success btn-sm" Style="font-weight: bold; margin-left:60px;  font-size: 14px; margin-top:10px" />
                       <asp:Button ID="btnDone" runat="server" Text="Done"  OnClick="btnDone_Click"  CssClass="btn btn-xs btn-purple btn-sm" Style="font-weight: bold; margin-left:20px; font-size: 14px; margin-top:10px " />
                       </asp:Panel>
            <div class="row">
              <div class="col-md-12" style="text-align: left;">
                        <div class="page-content" style="background: #EFF3F8 none repeat scroll 0 0;">
                           <asp:GridView ID="gvEmployeeInformationList" runat="server" AutoGenerateColumns="false" 
                            OnRowEditing="gvEmployeeInformationList_RowEditing"
                            OnRowDeleting="gvEmployeeInformationList_RowDeleting"                                               
                            CssClass="table table-striped table-hove"
                            PagerSettings-Mode="NumericFirstLast" ShowHeader="true"
                            DataKeyNames="AutoID" EmptyDataText="No Data Show" Width="100%"
                            border="0"
                            GridLines="Horizontal">                             
                            <RowStyle ForeColor="#000" Font-Size="12px" Wrap="false">
                            </RowStyle>
                            <HeaderStyle Wrap="false" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sl No">
                                    <HeaderStyle  VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumnAutoID" runat="server" Visible="false" Text='<%#Bind("AutoID") %>'></asp:Label>
                                        <asp:Label ID="lblSLNo" runat="server" Text='<%#Bind("SLNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Emoloyee Name" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Designation " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                     <asp:Label ID="lblDesignationName" runat="server" Text='<%#Bind("DesignationName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Leave Type" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                     <asp:Label ID="lblLeaveType" runat="server" Text='<%#Bind("LeaveType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                    <asp:Label ID="lblLeaveStartDate" runat="server" Text='<%#Bind("LeaveStartDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Start Time" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                    <asp:Label ID="lblLeaveStartTime" runat="server" Text='<%#Bind("LeaveStartTime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="End Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLeaveEndDate" runat="server" Text='<%#Bind("LeaveEndDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="End Time" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLeaveEndTime" runat="server" Text='<%#Bind("LeaveEndTime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="btnAproved" runat="server" OnClick="btnAproved_Click"  ToolTip="Aproved" CssClass="glyphicon glyphicon-ok bigger-130 green" CommandArgument='<%# Eval("AutoID") %>'></asp:LinkButton>
                                                          &nbsp;&nbsp;
                                                        <asp:LinkButton ID="btnCancel" runat="server"  OnClick="btnCancel_Click"  CssClass="glyphicon glyphicon-remove bigger-130 red"
                                                            ToolTip="Cancel" CommandName="Delete" CausesValidation="false" CommandArgument='<%# Eval("AutoID") %>'   OnClientClick="return confirm('Are you sure you want to Delete this Record?');" />
                                                      
                                                    </ContentTemplate>

                                                     <Triggers>
                                                       <asp:PostBackTrigger ControlID="btnAproved"  />
                                                       <asp:PostBackTrigger ControlID="btnCancel"  />
                                                     </Triggers>
                                       </asp:UpdatePanel>
                                    </ItemTemplate>
                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        </div>
                    </div>
             </div>
        
        </ContentTemplate>
        <Triggers>
    
            <asp:AsyncPostBackTrigger ControlID="gvEmployeeInformationList" EventName="RowEditing" />
            <asp:AsyncPostBackTrigger ControlID="gvEmployeeInformationList" EventName="RowDeleting" />

            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
