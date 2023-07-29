<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="MonthlyServiceChargeEntry.aspx.cs" Inherits="AMS.Configuration.MonthlyServiceChargeEntry" %>

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
            <div class="widget-box">
                <div class="widget-header">
                    <div class="row">
                        <div class="col-md-5">
                            <h4 class="widget-title">
                                <i class="icon-th"></i>&nbsp;Monthly Service Charges Entry</h4>

                        </div>

                          <asp:Button ID="btnNew"  Text="New" runat="server" Font-Bold="true" OnClick="btnNew_Click"  Font-Size="14px" CssClass="btn btn-purple" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;" />      
                          <asp:LinkButton ID="btnsave" runat="server" CssClass="btn btn-success"  OnClick="btnsave_Click" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;"> <i class="icon-save bigger-100"  ></i>&nbsp;Save</asp:LinkButton>&nbsp;&nbsp;
                          <asp:LinkButton ID="btnupdate" runat="server" CssClass="btn btn-success"   OnClick="btnsave_Click" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;"> <i class="icon-edit bigger-100"  ></i>&nbsp;Update</asp:LinkButton>&nbsp;&nbsp;
                           
                    </div>
                </div>
                <div class="widget-body">

                        <div class="widget-main no-padding">
                            <div class="space-4">
                            </div>
                            <div class="row">
                               
                                      <div class="col-md-1" style="font-weight: bold; text-align: right;">
                                   
                                       <asp:Label ID="lblName" runat="server" Text="Organization Name:"></asp:Label>
                                      </div>
                                     <div class="col-md-2">
                                           <asp:TextBox ID="txtOrganization" runat="server" placeholder="Organization" CssClass="form-control" />
                                     </div>
                                  
                                
                                  <div class="col-md-1" style="font-weight: bold; text-align: right;">
                                   
                                       <asp:Label ID="Label3" runat="server" Text="Charge Name:"></asp:Label>
                                      </div>
                                     <div class="col-md-2">
                                           <asp:TextBox ID="txtChargeName" runat="server" placeholder="Charge Name" CssClass="form-control" />
                                     </div>
                                  
                                    <div class="col-md-1" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="lblFundMonth" runat="server" Text="Date :"></asp:Label>
                                    </div>
                                    <div class="col-md-2">
                                         <div class="input-group">
                                                <asp:TextBox ID="txtDate" placeholder=" Date" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                        </div>
                                 
                                  <div class="col-md-1" style="font-weight: bold; text-align: right;">
                                   
                                       <asp:Label ID="lblReceitNo" runat="server" Text="Receipt No:"></asp:Label>
                                      </div>
                                     <div class="col-md-2">
                                           <asp:TextBox ID="txtReceitNo" runat="server" placeholder="Receipt No" CssClass="form-control" />
                                     </div>
                                  
                               
                               
                                      
                                    </div>
                                 
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                    <div class="col-md-1" style="font-weight: bold; text-align: right;">
                                  
                                       <asp:Label ID="lblFlatNo" runat="server" Text="Flat No:"></asp:Label>
                                     </div>
                                     <div class="col-md-2">
                      
                                      <asp:DropDownList ID="ddlUnitNo" runat="server" CssClass="select2">
                                              
                                            </asp:DropDownList>
                                      </div>
                                       
                                      <div class="col-md-1" style="font-weight: bold; text-align: right;">
                                  
                                       <asp:Label ID="Label4" runat="server" Text="Month :"></asp:Label>
                                     </div>
                                     <div class="col-md-2">
                                       <asp:DropDownList ID="ddlMonthName" runat="server" CssClass="select2" AutoPostBack="True">
                                                 <asp:ListItem Enabled="true" Text="Select All Month" Value="0"></asp:ListItem>
                                                  <asp:ListItem Text="January" Value="January"></asp:ListItem>
                                                  <asp:ListItem Text="February" Value="February"></asp:ListItem>
                                                  <asp:ListItem Text="March" Value="March"></asp:ListItem>
                                                  <asp:ListItem Text="April" Value="April"></asp:ListItem>
                                                  <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                                  <asp:ListItem Text="June" Value="June"></asp:ListItem>
                                                  <asp:ListItem Text="July" Value="July"></asp:ListItem>
                                                  <asp:ListItem Text="August" Value="August"></asp:ListItem>
                                                  <asp:ListItem Text="September" Value="September"></asp:ListItem>
                                                  <asp:ListItem Text="October" Value="October"></asp:ListItem>
                                                  <asp:ListItem Text="November" Value="November"></asp:ListItem>
                                                  <asp:ListItem Text="December" Value="December"></asp:ListItem>

                                      </asp:DropDownList>
                                      </div>
                                  
                                       <div class="col-md-1" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label5" runat="server" Text="Year :"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                             <asp:DropDownList ID="ddlYear" runat="server" CssClass="select2" AutoPostBack="True">

                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-1" style="font-weight: bold; text-align: right;">
                                        <asp:LinkButton ID="btnChargesList" CssClass="btn btn-xs btn-danger" runat="server" ToolTip="Add Charges List"  OnClick="btnNewAdd_Click"  Style="font-weight: bold;"> <i class="icon-plus bigger-40"  ></i>&nbsp;Add Charges List</asp:LinkButton>
                                 
                                 </div>
                                
                                        
                                    </div>
                             <div class="row" id="dvFgrid" runat="server"  visible="false" >
                                     
                            <div class="col-md-12">
                              <div class="col-md-4">
                              </div> 
                              <div class="col-md-5">
                                <div class="form-actions center"  >


                                 
                                     <asp:GridView ID="gvChargesList" runat="server" AutoGenerateColumns="false" 
                                      AllowSorting="true" 
                                PageSize="10" CssClass="table table-striped  table-hover" ShowFooter="true"
                                PagerSettings-Mode="NumericFirstLast" EmptyDataText="No Data Show" border="0" Width="300px"
                                 RowStyle-Wrap="true"  Style="border: 0; border-color: transparent" > 
                                
                            
                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Left" />
                                <RowStyle Wrap="false" />
                                <HeaderStyle Wrap="false" />
                                 <Columns >
                                      <asp:TemplateField  >
                                        <ItemTemplate>
                                          <asp:Label ID="lblSegmentsAutoID_Auto" runat="server" Visible="false" Text='<%#Eval("AutoID")%>'></asp:Label>
                                          <asp:LinkButton ID="btnRemove" runat="server" CssClass="icon-trash bigger-130 red" ToolTip="Delete" CommandName="Delete" OnClick="LinkRowDelete_OnClick"  CausesValidation="false" OnClientClick="return confirm('Are you sure you want to Delete this Record?');"  />
                                 
                                        </ItemTemplate>
                                       <ItemStyle VerticalAlign="Middle" />
                                    <HeaderStyle VerticalAlign="Middle"  />
                                    </asp:TemplateField>
                                 <asp:TemplateField   HeaderText="Charges Name" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>

                                           <asp:TextBox ID="lblChargesName"   BorderStyle="None"  runat="server" Text='<%#Eval("ChargesName") %>'></asp:TextBox>
                                       
                                        </ItemTemplate>
                                       <ItemStyle VerticalAlign="Middle" />
                                    <HeaderStyle VerticalAlign="Middle"  />
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount(Tk)" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>

                                       <asp:TextBox ID="lblAmount"  BorderStyle="None"    OnTextChanged="txtAmount_TextChanged"   runat="server" Text='<%#Eval("Amount") %>'></asp:TextBox>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                            </div>
                                      
                                        </div>
                                <div class="col-md-3">
                               </div> 
                                        </div>
                                        </div>
                                    
                                <div class="space-4">
                                        </div>

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
                                EmptyDataText="No Data Found" Width="100%" ShowHeader="true" DataKeyNames="ReceiptNo"
                                AlternatingRowStyle-CssClass="gridviewaltrow">
                                <RowStyle ForeColor="#000" Font-Size="12px" Wrap="false"></RowStyle>
                                <HeaderStyle Wrap="false" />
                              <Columns>
                                <asp:TemplateField HeaderText="Receipt No">
                                    <HeaderStyle  VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumnAutoID" runat="server" Visible="false" Text='<%#Bind("ReceiptNo") %>'></asp:Label>
                                        <asp:Label ID="lblSLNo" runat="server" Text='<%#Bind("ReceiptNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                 <asp:TemplateField  Visible="false"   >
                                        <ItemTemplate>
                                            <asp:Label ID="lblSegmentsAutoID_Auto" runat="server" Visible="false" Text='<%#Eval("ReceiptNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Organization Name" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrganizationName" runat="server" Text='<%#Bind("OrganizationName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Charge Name " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChargeName" runat="server" Text='<%#Bind("ChargeName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Flat No " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlatNo" runat="server" Text='<%#Bind("FlatNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Month " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMonth" runat="server" Text='<%#Bind("Month") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Year " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblYear" runat="server" Text='<%#Bind("Year") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Bind("Date") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                  <asp:TemplateField HeaderText="Total Amt (TK) " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Bind("TotalAmount") %>'></asp:Label>
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
    <%--        <asp:AsyncPostBackTrigger ControlID="gvMaintenanceCostInformationList" EventName="RowEditing" />
            <asp:AsyncPostBackTrigger ControlID="gvMaintenanceCostInformationList" EventName="RowDeleting" />--%>
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnupdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
