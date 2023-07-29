<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="VisitorInformationEntry.aspx.cs" Inherits="AMS.Configuration.VisitorInformationEntry" %>

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
                                <i class="icon-th"></i>&nbsp;Visitor Information Entry</h4>

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
                                   
                                       <asp:Label ID="lblName" runat="server" Text="Entry Date :"></asp:Label>
                                      </div>
                                     <div class="col-md-8">
                                  <div class="input-group">
                                                <asp:TextBox ID="txtEntryDate" placeholder="Entry Date" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                     </div>
                                    </div>
                                       <div class="space-4">
                                    </div>
                                   <div class="row">
                                      <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                   
                                       <asp:Label ID="Label1" runat="server" Text="Floor Name :"></asp:Label>
                                      </div>
                                     <div class="col-md-8">
                                         <asp:DropDownList ID="ddlFloor" runat="server" CssClass="select2" AutoPostBack="True" OnSelectedIndexChanged="ddlFloor_SelectedIndexChanged"  >
                                         
                                         </asp:DropDownList>
                                     </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="lblFundMonth" runat="server" Text="Unit No :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                            <b style="display: none;">Client ID :</b>
                                            <asp:DropDownList ID="ddlUnitName" runat="server" CssClass="select2" AutoPostBack="True"   >
                                                
                                            </asp:DropDownList>
                                        </div>
                                   </div>
                                    <div class="space-4">
                                    </div>
                                
                                  <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="Label5" runat="server" Text="Visitor Type :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                           <asp:DropDownList ID="ddlVisitorType" runat="server" CssClass="select2" AutoPostBack="True">
                                                
                                            </asp:DropDownList>
                                       
                                        </div>
                                   </div>
                                      <div class="space-4">
                                    </div>
                                
                                </div>
                                <div class="col-md-4">
                                  
                                   
                                    <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="Label4" runat="server" Text="Name :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                            <b style="display: none;">Client ID :</b>
                                            <asp:TextBox ID="txtName" runat="server" placeholder="Name " CssClass="form-control" />
                                        </div>
                                   </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="Label8" runat="server" Text="Mobile :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                            <b style="display: none;">Client ID :</b>
                                            <asp:TextBox ID="txtMobile" runat="server" placeholder="Mobile " CssClass="form-control" />
                                        </div>
                                   </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="Label9" runat="server" Text="Contact Person :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                            <b style="display: none;">Client ID :</b>
                                            <asp:TextBox ID="TxtContactPerson" runat="server" placeholder="Contact Person " CssClass="form-control" />
                                        </div>
                                   </div>
                                   <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label6" runat="server" Text="Visitor Address:"></asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                             <asp:TextBox ID="txtVisitorAddress" runat="server" placeholder="Visitor Address" Height="35px" CssClass="form-control"
                                            TextMode="MultiLine" />
                                       </div>
                                   
                                        </div>
                                  <div class="space-4">
                                    </div>
                                
                                </div>
                                <div class="col-md-4">
                                    
                                  <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="Label7" runat="server" Text="In Time :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                                <div class="input-group bootstrap-timepicker">
                                        <asp:TextBox ID="txtInTime" CssClass="form-control timepicker1" runat="server" placeholder="Time"></asp:TextBox>
                                        <span class="input-group-addon"><i class="icon-time bigger-110"></i></span>
                                    </div>
                                        </div>
                                   </div>
                                  
                                    <div class="space-4">
                                    </div>
                                   <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="Label3" runat="server" Text="Out Time :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                                  <div class="input-group bootstrap-timepicker">
                                        <asp:TextBox ID="txtOutTime" CssClass="form-control timepicker1" runat="server" placeholder="Time"></asp:TextBox>
                                        <span class="input-group-addon"><i class="icon-time bigger-110"></i></span>
                                    </div>
                                        </div>
                                   </div>
                                
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label2" runat="server" Text="Purpose:"></asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                             <asp:TextBox ID="txtPurpose" runat="server" placeholder="Purpose" Height="75px" CssClass="form-control"
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
                           <asp:GridView ID="gvVisitorInformationList" runat="server" 
                            AutoGenerateColumns="false" 
                            OnRowEditing="gvVisitorInformationList_RowEditing"
                            OnRowDeleting="gvVisitorInformationList_RowDeleting"                                               
                            CssClass="table table-striped table-hove" 
                            PagerSettings-Mode="NumericFirstLast" ShowHeader="true"
                            DataKeyNames="AutoID" EmptyDataText="No Data Show" Width="100%"
                            border="0"
                            GridLines="Horizontal">                              
                            <RowStyle ForeColor="#000" Font-Size="12px" Wrap="false">
                            </RowStyle>
                            <HeaderStyle Wrap="false" />
                            <Columns>
                               
                                <asp:TemplateField HeaderText="Entry Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                     
                                        <asp:Label ID="lblEntryDate" runat="server" Text='<%#Bind("EntryDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Floor Name " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFloorName" runat="server" Text='<%#Bind("FloorName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 
                                  <asp:TemplateField HeaderText="Unit Name " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitName" runat="server" Text='<%#Bind("UnitName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Name " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Mobile No" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMobile" runat="server" Text='<%#Bind("Mobile") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Visitor Type" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVisitorType" runat="server" Text='<%#Bind("VisitorType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Contact Person" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblContactPerson" runat="server" Text='<%#Bind("ContactPerson") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Visitor Address" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVisitorAddress" runat="server" Text='<%#Bind("VisitorAddress") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="InTime" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInTime" runat="server" Text='<%#Bind("InTime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="OutTime" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIOutTime" runat="server" Text='<%#Bind("OutTime") %>'></asp:Label>
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
    
            <asp:AsyncPostBackTrigger ControlID="gvVisitorInformationList" EventName="RowEditing" />
            <asp:AsyncPostBackTrigger ControlID="gvVisitorInformationList" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnupdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
