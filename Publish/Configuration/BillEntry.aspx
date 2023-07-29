<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="BillEntry.aspx.cs" Inherits="AMS.Configuration.BillEntry" %>

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
                                <i class="icon-th"></i>&nbsp;Bill Deposit Entry</h4>

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
                                <div class="col-md-4">
                                    <div class="row">
                                      <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                   
                                       <asp:Label ID="lblName" runat="server" Text="Bill Type :"></asp:Label>
                                      </div>
                                     <div class="col-md-8">
                                         <asp:DropDownList ID="ddlBillType" runat="server" CssClass="select2" AutoPostBack="True"  >
                                         
                                         </asp:DropDownList>
                                     </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="lblFundMonth" runat="server" Text="Bank Name :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                            <b style="display: none;">Client ID :</b>
                                            <asp:DropDownList ID="ddlBankList" runat="server" CssClass="select2" AutoPostBack="True">
                                                
                                            </asp:DropDownList>
                                        </div>
                                   </div>
                                    <div class="space-4">
                                    </div>
                                
                                  <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="Label5" runat="server" Text="Total Amt (TK) :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                            <b style="display: none;">Client ID :</b>
                                            <asp:TextBox ID="txtTotalAmt" runat="server" placeholder="Total Amt (TK) " CssClass="form-control" />
                                        </div>
                                   </div>
                                      <div class="space-4">
                                    </div>
                                
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="Label6" runat="server" Text="Month :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                            <b style="display: none;">Client ID :</b>
                                            <asp:DropDownList ID="ddlMonthName" runat="server" CssClass="select2" AutoPostBack="True">
                                                
                                            </asp:DropDownList>
                                        </div>
                                   </div>
                                     <div class="space-4">
                                    </div>
                                    <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="Label7" runat="server" Text="Year :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                            <b style="display: none;">Client ID :</b>
                                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="select2" AutoPostBack="True">
                                                
                                            </asp:DropDownList>
                                        </div>
                                   </div>
                                  
                                    <div class="space-4">
                                    </div>
                                   <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="Label3" runat="server" Text="Reference No :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                            <b style="display: none;">Client ID :</b>
                                            <asp:TextBox ID="txtReference" runat="server" placeholder="Reference No" CssClass="form-control" />
                                        </div>
                                   </div>
                                  <div class="space-4">
                                    </div>
                                
                                </div>
                                <div class="col-md-4">
                                    
                                   <div class="row">
                                      <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                  
                                       <asp:Label ID="Label4" runat="server" Text="Bill Deposit Date :"></asp:Label>
                                     </div>
                                     <div class="col-md-8">
                                         <div class="input-group">
                                                <asp:TextBox ID="txtDate" placeholder="Bill Deposit Date" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                      </div>
                                    </div>
                                
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label2" runat="server" Text="Remarks:"></asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                             <asp:TextBox ID="txtPurpose" runat="server" placeholder="Remarks" Height="75px" CssClass="form-control"
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
            <div class="row">
                    <div class="col-md-12" style="text-align: left;">
                        <div class="page-content" style="background: #EFF3F8 none repeat scroll 0 0;">
                           <asp:GridView ID="gvBillDepositInformationList" runat="server" 
                            AutoGenerateColumns="false" 
                            OnRowEditing="gvBillDepositInformationList_RowEditing"
                            OnRowDeleting="gvBillDepositInformationList_RowDeleting"                                               
                            CssClass="table table-striped table-hove" 
                            PagerSettings-Mode="NumericFirstLast" ShowHeader="true"
                            DataKeyNames="AutoID" EmptyDataText="No Data Show" Width="100%"
                            border="0"
                            GridLines="Horizontal">                              
                            <RowStyle ForeColor="#000" Font-Size="12px" Wrap="false">
                            </RowStyle>
                            <HeaderStyle Wrap="false" />
                            <Columns>
                               
                                <asp:TemplateField HeaderText="Bill Type" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                     
                                        <asp:Label ID="lblBillType" runat="server" Text='<%#Bind("BillType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Bank Name " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBankName" runat="server" Text='<%#Bind("BankName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 
                                  <asp:TemplateField HeaderText="Month Name " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMonthName" runat="server" Text='<%#Bind("MonthName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Year " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblYear" runat="server" Text='<%#Bind("Year") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Reference No" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReferencNo" runat="server" Text='<%#Bind("ReferencNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Bill Deposit Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBillDate" runat="server" Text='<%#Bind("BillDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Total Amount (Tk)" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTTotalAmt" runat="server" Text='<%#Bind("TotalAmt") %>'></asp:Label>
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
    
            <asp:AsyncPostBackTrigger ControlID="gvBillDepositInformationList" EventName="RowEditing" />
            <asp:AsyncPostBackTrigger ControlID="gvBillDepositInformationList" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnupdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
