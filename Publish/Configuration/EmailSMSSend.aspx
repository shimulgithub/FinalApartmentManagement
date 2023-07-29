<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="EmailSMSSend.aspx.cs" Inherits="AMS.Configuration.EmailSMSSend" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
   <script type="text/javascript">
          function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField ID="hftakenDayForEdit" runat="server" />
             <asp:HiddenField ID="hfAutoId" runat="server" />
            
                  <div class="widget-box">
                <div class="widget-header">
                    <div class="row">
                        <div class="col-md-5">
                            <h4 class="widget-title">
                                <i class="icon-th"></i>&nbsp;Send Email / SMS</h4>

                        </div>

                          <asp:Button ID="btnNew"  Text="New" runat="server" Font-Bold="true" OnClick="btnNew_Click"  Font-Size="14px" CssClass="btn btn-purple" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;" />      
                          <asp:LinkButton ID="btnsave" runat="server" CssClass="btn btn-success"  OnClick="btnsave_Click" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;"> <i class="icon-save bigger-100"  ></i>&nbsp;Save</asp:LinkButton>&nbsp;&nbsp;
                          <asp:LinkButton ID="btnupdate" runat="server" CssClass="btn btn-success"   OnClick="btnsave_Click" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;"> <i class="icon-edit bigger-100"  ></i>&nbsp;Update</asp:LinkButton>&nbsp;&nbsp;
                           
                      
                           
                    </div>
                </div>
                <div class="widget-body">
                <asp:Panel ID="pnl2Module" runat="server"  Style="padding: 5px;">
                        <div class="widget-main no-padding">
                            <div class="space-4">
                            </div>
                            <div class="row">
                             
                                <div class="col-md-12">
                                    
                                 <div class="row">
                                    <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblUserName" runat="server" Text="Massage Subject :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtMassageSubject"
                                            ErrorMessage="Sorry! Massage Subject required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                        <asp:Label ID="lblMsgUserNameRange" runat="server" Text="" EnableViewState="false"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtMassageSubject" runat="server" placeholder="Massage Subject"  AutoCompleteType="Disabled"
                                            CssClass="form-control"  AutoPostBack="true"   
                                            Text=""  />
                                        &nbsp;
                                    </div>
                                </div>
                                  
                                <div class="space-4">
                                    </div>
                                   <div class="row">
                                    <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label1" runat="server" Text="Massage :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMessage"
                                            ErrorMessage="Sorry! Massage  required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                        <asp:Label ID="Label2" runat="server" Text="" EnableViewState="false"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtMessage" runat="server"  AutoCompleteType="Disabled"
                                            CssClass="form-control"  AutoPostBack="true"   
                                            Text="" TextMode="MultiLine" Height="150px"  />
                                        &nbsp;
                                    </div>
                                </div>
                                         <div class="space-4">
                                    </div>
                                        <%-- <div class="row">
                                   <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label8" runat="server" Text="Notice File :"></asp:Label>
                                    </div>
                                    <div class="col-md-8" style="font-weight: bold; text-align: right;">
                                    <asp:FileUpload ID="FileUpload1" runat="server"  ToolTip="Select Only PDF File" /> </td>  
                                  </div>
                                </div>--%>
                                        <div class="space-4">
                                    </div>

                                       <div class="space-4">
                                    </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                       <div class="space-4">
                                    </div>
                        </div>
                                
                                
                            </div>
                            </asp:Panel>
                        </div>
                    
                </div>
                   <div class="panel panel-default" style="width: auto; padding: 5px;">
                        <div id="dvTab">
                          <asp:Button ID="btnVersion" Text="All" runat="server"  OnClick="btnVersion_Click"
                                Font-Bold="true" Font-Size="14px" CssClass="btn btn-xs btn-purple btn-sm" Style="font-weight: bold;
                                font-size: 14px;" />
                            <asp:Button ID="btnColumns" Text="Specific Tenant" runat="server" OnClick="btnColumns_Click"
                                Font-Bold="true" Font-Size="14px" CssClass="btn btn-xs btn-purple btn-sm" Style="font-weight: bold;
                                font-size: 14px;" />
                            <asp:Button ID="btnModule" Text="Specific Owner" runat="server" OnClick="btnModule_Click"
                                Font-Bold="true" Font-Size="14px" CssClass="btn btn-xs btn-purple btn-sm" Style="font-weight: bold;
                                font-size: 14px;" />
                            <asp:Button ID="btnDateRanges" Text="Specific Employee" runat="server" OnClick="btnDateRanges_Click"
                                Font-Bold="true" Font-Size="14px" CssClass="btn btn-xs btn-purple btn-sm"  Style="font-weight: bold;
                                font-size: 14px;" />
                          
                            <asp:Button ID="btnClearfilteringcriteria" Text="New" runat="server"
                                 Font-Bold="true" Font-Size="14px" CssClass="btn btn-xs btn-purple btn-sm" 
                                Style="font-weight: bold; float: right; font-size: 14px;" />
                            <asp:HiddenField ID="hfTab" runat="server" />
                            <!-- Navigation Tabs starts -->
                            <asp:Panel ID="pnl1Columns" runat="server" Visible="false" Style="margin-left: 0;
                                margin-top: 5px; padding: 5px; border: 1px solid #ddd;">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="widget-box">
                                            <div class="widget-header widget-header-flat">
                                                <h5 class="widget-title" style="color: #000000; font-weight: bold;">
                                                    <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" Checked="true" OnCheckedChanged="ChkAll_CheckedChanged" />&nbsp;Select
                                                    Tenant List</h5>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <asp:CheckBoxList runat="server" ID="chkFields"  RepeatDirection="Vertical"
                                                        RepeatColumns="5" Style="padding: 5px; margin: 5px" 
                                                        RepeatLayout="Table" Width="100%" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Panel1" runat="server" Visible="false" Style="margin-left: 0;
                                margin-top: 5px; padding: 5px; border: 1px solid #ddd;">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="widget-box">
                                            <div class="widget-header widget-header-flat">
                                                <h5 class="widget-title" style="color: #000000; font-weight: bold;">
                                                    <asp:CheckBox ID="chkOwner" runat="server" AutoPostBack="true" Checked="true" OnCheckedChanged="chkOwner_CheckedChanged" />&nbsp;Select
                                                    Owner List</h5>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <asp:CheckBoxList runat="server" ID="chkListOwner"  RepeatDirection="Vertical"
                                                        RepeatColumns="5" Style="padding: 5px; margin: 5px" 
                                                        RepeatLayout="Table" Width="100%" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-4">
                                </div>
                               
                            </asp:Panel>
                            <asp:Panel ID="pnl3Module" runat="server" Visible="false" Style="margin-left: 0;
                                margin-top: 5px; padding: 5px; border: 1px solid #ddd;">
                                <div class="row">
                                   <div class="col-md-12">
                                        <div class="widget-box">
                                            <div class="widget-header widget-header-flat">
                                                <h5 class="widget-title" style="color: #000000; font-weight: bold;">
                                                    <asp:CheckBox ID="chkEmp" runat="server" AutoPostBack="true" Checked="true" OnCheckedChanged="chkEmp_CheckedChanged" />&nbsp;Select
                                                    Employee List</h5>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <asp:CheckBoxList runat="server" ID="chkEmpList"  RepeatDirection="Vertical"
                                                        RepeatColumns="5" Style="padding: 5px; margin: 5px" 
                                                        RepeatLayout="Table" Width="100%" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                               <asp:Panel ID="Panel4Version" runat="server" Visible="false" Style="margin-left: 0;
                                margin-top: 5px; padding: 5px; border: 1px solid #ddd;">
                                <div class="row">
                                    <div class="col-md-6">
                                       <asp:CheckBox ID="chkAllTenant"  runat="server" /> &nbsp;All Tenant</h5>
                                       <asp:CheckBox ID="chkAllOwner"  runat="server" />  &nbsp;All Owner</h5>
                                       <asp:CheckBox ID="chkAllEmployee"  runat="server" />  &nbsp;All Employee</h5>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>

                     <div class="row">
                                   <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label3" runat="server" Text="Massage Type:"></asp:Label>
                                        </div>
                                    <div class="col-md-6">
                                       <asp:CheckBox ID="chkEmail"  runat="server" /> &nbsp;Email</h5>
                                       <asp:CheckBox ID="chkSMS"  runat="server" />  &nbsp;SMS</h5>
                                    
                                    </div>
                                    <div class="col-md-4">
                                    <asp:Button ID="btnSend" Text="Send Notification" runat="server" OnClick="btnSend_Click"
                                 Font-Bold="true" Font-Size="14px" CssClass="btn btn-xs btn-success btn-sm" 
                                Style="font-weight: bold; float: right; font-size: 14px;" />
                                    </div>
                                    
                                </div>
                                  
                                  
                                    
            <%--<div class="row">
                    <div class="col-md-12" style="text-align: left;">
                        <div class="page-content" style="background: #EFF3F8 none repeat scroll 0 0;">
                           <asp:GridView ID="gvEmployeeNoticeInformationList" runat="server" 
                            AutoGenerateColumns="false" 
                            OnRowEditing="gvEmployeeNoticeInformationList_RowEditing"
                            OnRowDeleting="gvEmployeeNoticeInformationList_RowDeleting"                                               
                            CssClass="table table-striped table-hove" 
                            PagerSettings-Mode="NumericFirstLast" ShowHeader="true"
                            DataKeyNames="AutoID" EmptyDataText="No Data Show" Width="100%"
                            border="0"
                            GridLines="Horizontal">                              
                            <RowStyle ForeColor="#000" Font-Size="12px" Wrap="false">
                            </RowStyle>
                            <HeaderStyle Wrap="false" />
                            <Columns>
                               
                                <asp:TemplateField HeaderText="Notice Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                     
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Bind("Date") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Notice Title" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitle" runat="server" Text='<%#Bind("Title") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 
                                  <asp:TemplateField HeaderText="Notice Description" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%#Bind("Description") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Notice Files">
                                                <ItemTemplate>
                                                 <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                                     <ContentTemplate>
                                                    <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="lnkDownload_Click"
                                                        CommandArgument='<%# Eval("AutoID") %>'></asp:LinkButton>
                                                     </ContentTemplate>

                                                      <Triggers>
                                                        <asp:PostBackTrigger ControlID="lnkDownload"  />
                                                        </Triggers>
                                                     </asp:UpdatePanel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="likBtnEdit" runat="server" CssClass="icon-edit bigger-130 green"
                                            CommandName="Edit" ToolTip="Edit" CausesValidation="false" />
                                        &nbsp;&nbsp;
                                        <asp:LinkButton ID="btnRemove" runat="server" CssClass="icon-trash bigger-130 red"
                                            ToolTip="Delete" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to Delete this Record?');" />
                                    </ItemTemplate>
                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        </div>
                    </div>
                </div>--%>
        
        </ContentTemplate>
        <Triggers>
    
          <%--  <asp:AsyncPostBackTrigger ControlID="gvEmployeeNoticeInformationList" EventName="RowEditing" />
            <asp:AsyncPostBackTrigger ControlID="gvEmployeeNoticeInformationList" EventName="RowDeleting" />--%>
            <asp:PostBackTrigger ControlID="btnsave" />
             <asp:PostBackTrigger ControlID="btnupdate" />
            <asp:PostBackTrigger ControlID="btnNew" />
             <asp:PostBackTrigger ControlID="btnSend"  />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
