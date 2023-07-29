<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="TenantNoticeEntry.aspx.cs" Inherits="AMS.Configuration.TenantNoticeEntry" %>

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
 <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:HiddenField ID="hftakenDayForEdit" runat="server" />
             <asp:HiddenField ID="hfAutoId" runat="server" />
            
                  <div class="widget-box">
                <div class="widget-header">
                    <div class="row">
                        <div class="col-md-5">
                            <h4 class="widget-title">
                                <i class="icon-th"></i>&nbsp;Tenant Notice Entry</h4>
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
                                  
                                       <asp:Label ID="Label4" runat="server" Text="Notice Date :"></asp:Label>
                                     </div>
                                     <div class="col-md-8">
                                         <div class="input-group">
                                                <asp:TextBox ID="txtDate" placeholder="Notice Date" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                      </div>
                                    </div>
                                <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label1" runat="server" Text=" Notice Title:"></asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                             <asp:TextBox ID="txtTitle" runat="server" placeholder="Notice Title" CssClass="form-control" />
                                       </div>
                                   
                                        </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label2" runat="server" Text="Notice Description:"></asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                             <asp:TextBox ID="txtDescription" runat="server" placeholder="Description" Height="75px" CssClass="form-control"
                                            TextMode="MultiLine" />
                                       </div>
                                   
                                        </div>
                                         <div class="space-4">
                                    </div>
                                         <div class="row">
                                   <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label8" runat="server" Text="Notice File :"></asp:Label>
                                    </div>
                                    <div class="col-md-8" style="font-weight: bold; text-align: right;">
                                    <asp:FileUpload ID="FileUpload1" runat="server"  ToolTip="Select Only PDF File" /> </td>  
                                  </div>
                                </div>
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
            <div class="row">
                    <div class="col-md-12" style="text-align: left;">
                        <div class="page-content" style="background: #EFF3F8 none repeat scroll 0 0;">
                           <asp:GridView ID="gvTenantNoticeInformationList" runat="server" 
                            AutoGenerateColumns="false" 
                            OnRowEditing="gvTenantNoticeInformationList_RowEditing"
                            OnRowDeleting="gvTenantNoticeInformationList_RowDeleting"                                               
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
                </div>
        
        </ContentTemplate>
        <Triggers>
    
            <asp:AsyncPostBackTrigger ControlID="gvTenantNoticeInformationList" EventName="RowEditing" />
            <asp:AsyncPostBackTrigger ControlID="gvTenantNoticeInformationList" EventName="RowDeleting" />
            <asp:PostBackTrigger ControlID="btnsave" />
            <asp:PostBackTrigger ControlID="btnupdate" />
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
