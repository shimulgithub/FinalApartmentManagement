﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="MaintenanceCostEntry.aspx.cs" Inherits="AMS.Configuration.MaintenanceCostEntry" %>

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
            <script type="text/javascript">
                Sys.Application.add_load(BindEvents); </script>
            <asp:HiddenField ID="hftakenDayForEdit" runat="server" />
            <div class="widget-box">
                <div class="widget-header">
                    <div class="row">
                        <div class="col-md-5">
                            <h4 class="widget-title">
                                <i class="icon-th"></i>&nbsp;Maintenance Cost Entry</h4>

                        </div>

                          <asp:Button ID="btnNew"  Text="New" runat="server" Font-Bold="true" OnClick="btnNew_Click"  Font-Size="14px" CssClass="btn btn-purple" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;" />      
                          <asp:LinkButton ID="btnsave" runat="server" CssClass="btn btn-success"  OnClick="btnsave_Click" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;"> <i class="icon-save bigger-100"  ></i>&nbsp;Save</asp:LinkButton>&nbsp;&nbsp;
                          <asp:LinkButton ID="btnupdate" runat="server" CssClass="btn btn-success"   OnClick="btnsave_Click" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;"> <i class="icon-edit bigger-100"  ></i>&nbsp;Update</asp:LinkButton>&nbsp;&nbsp;
                           
                    </div>
                </div>
                <div class="widget-body">
                <asp:Panel ID="pnl2Module" runat="server"  Style="padding:5px;">
                        <div class="widget-main no-padding">
                            <div class="space-4">
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="row">
                                      <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                   
                                       <asp:Label ID="lblName" runat="server" Text="Cost Title  :"></asp:Label>
                                      </div>
                                     <div class="col-md-6">
                                           <asp:TextBox ID="txtCostTitle" runat="server" placeholder="Cost Title" CssClass="form-control" />
                                     </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="lblFundMonth" runat="server" Text="Date :"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                         <div class="input-group">
                                                <asp:TextBox ID="txtDate" placeholder=" Date" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                        </div>
                                   </div>
                                    <div class="space-4">
                                    </div>
                                </div>
                             <%--   <div class="col-md-4">

                                  <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="Label5" runat="server" Text="Month :"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                            <b style="display: none;">Client ID :</b>
                                            <asp:DropDownList ID="ddlMontName" runat="server" CssClass="select2" AutoPostBack="True">
                                                
                                            </asp:DropDownList>
                                        </div>
                                   </div>
                                    <div class="space-4">
                                    </div>

                                   <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="Label3" runat="server" Text="Year :"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                            <b style="display: none;">Client ID :</b>
                                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="select2" AutoPostBack="True">   
                                            </asp:DropDownList>
                                        </div>
                                   </div>
                                     <div class="space-4">
                                    </div>
                                </div>--%>
                                <div class="col-md-4">
                                     <div class="row">
                                      <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                  
                                       <asp:Label ID="Label1" runat="server" Text="Total Amount(TK) :"></asp:Label>
                                     </div>
                                     <div class="col-md-6">
                                         <div class="input-group">
                                                <asp:TextBox ID="txtTotalAmount" placeholder="Total Amount(TK)" runat="server" CssClass="form-control"></asp:TextBox>
                                          
                                            </div>
                                      </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label2" runat="server" Text="Remarks:"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                             <asp:TextBox ID="txtRemarks" runat="server" placeholder="Remarks" Height="40px" CssClass="form-control"
                                            TextMode="MultiLine" />
                                        </div>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                        
                                </div>

                            </div>
                            </asp:Panel>
                        </div>
                   
                </div>
                <asp:HiddenField ID="hfAutoId" runat="server" />
              



                 <div class="row">
                    <div class="col-md-12" style="text-align: left;">
                        <div class="page-content" style="background: #EFF3F8 none repeat scroll 0 0;">
                            <asp:GridView ID="gvMaintenanceCostInformationList" runat="server" AutoGenerateColumns="False"
                                CssClass="gvv table table-striped table-bordered table-hover"
                                 OnRowDeleting="gvMaintenanceCostInformationList_RowDeleting"
                                OnRowEditing="gvMaintenanceCostInformationList_RowEditing" 
                                OnRowDataBound="gvMaintenanceCostInformationList_RowDataBound"
                                EmptyDataText="No Data Found" Width="100%" ShowHeader="true" DataKeyNames="AutoID"
                                AlternatingRowStyle-CssClass="gridviewaltrow">
                                <RowStyle ForeColor="#000" Font-Size="12px" Wrap="false"></RowStyle>
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
                                 <asp:TemplateField  >
                                        <ItemTemplate>
                                            <asp:Label ID="lblSegmentsAutoID_Auto" runat="server" Visible="false" Text='<%#Eval("AutoID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cost Title" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCostTitle" runat="server" Text='<%#Bind("CostTitle") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="TotalAmount " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Bind("TotalAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Bind("Date") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Remarks" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemarks" runat="server" Text='<%#Bind("Remarks") %>'></asp:Label>
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
            <asp:AsyncPostBackTrigger ControlID="gvMaintenanceCostInformationList" EventName="RowEditing" />
            <asp:AsyncPostBackTrigger ControlID="gvMaintenanceCostInformationList" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnupdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>