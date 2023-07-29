<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="EmployeeInformation.aspx.cs" Inherits="AMS.Configuration.EmployeeInformation" %>

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
                                <i class="icon-th"></i>&nbsp;Employee Information</h4>

                        </div>

                          <asp:Button ID="btnNew"  Text="New" runat="server" Font-Bold="true" OnClick="btnNew_Click"  Font-Size="14px" CssClass="btn btn-purple" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;" />      
                          <asp:LinkButton ID="btnsave" runat="server" CssClass="btn btn-success"  OnClick="btnsave_Click" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;"> <i class="icon-save bigger-100"  ></i>&nbsp;Save</asp:LinkButton>&nbsp;&nbsp;
                          <asp:LinkButton ID="btnupdate" runat="server" CssClass="btn btn-success"   OnClick="btnsave_Click" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;"> <i class="icon-edit bigger-100"  ></i>&nbsp;Update</asp:LinkButton>&nbsp;&nbsp;
                           
                    </div>
                </div>
                <div class="widget-body">
                <asp:Panel ID="pnl2Module" runat="server" class="" Style="padding: 5px;">
                        <div class="widget-main no-padding">
                            <div class="space-4">
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="row">
                                      <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmpName"
                                           ErrorMessage="Sorry! name required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                       <asp:Label ID="lblName" runat="server" Text="Name :"></asp:Label>
                                      </div>
                                     <div class="col-md-6">
                                        <asp:TextBox ID="txtEmpName" runat="server" Text="" placeholder="Name" CssClass="form-control"></asp:TextBox>
                                     </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="lblEmailID" runat="server" Text="E-mail :"></asp:Label><asp:RegularExpressionValidator
                                            ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ControlToValidate="txtEmailID" ValidationGroup="UserForm" Text="*" ForeColor="red"
                                            ErrorMessage="Please Type like-'example@domain.com'"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtEmailID" runat="server" placeholder="E-mail" CssClass="form-control" />
                                    </div>
                                   </div>
                                    <div class="space-4">
                                    </div>
                                   <div class="row">
                                       <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContact"
                                           ErrorMessage="Sorry! Contact required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                       &nbsp;<asp:Label ID="Label1" runat="server" Text="Contact No :"></asp:Label>
                                    </div>
                                     <div class="col-md-6">
                                     <asp:TextBox ID="txtContact" runat="server" Text="" placeholder="Contact No" CssClass="form-control"></asp:TextBox>
                                      </div>
                                    </div>
                                    <div class="space-4">
                                    </div>

                                   <div class="row">
                                      <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblIsActive" runat="server" Text="IsActive :"></asp:Label>
                                      </div>
                                    <div class="col-md-6" style="text-align: left;">
                                     
                                        <asp:CheckBox ID="chkIsActive" runat="server" />
                                        &nbsp;
                                    </div>
                                 </div>
                                   
                                </div>
                                <div class="col-md-4">
                                   <div class="row">
                                      <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNID"
                                           ErrorMessage="Sorry! NID  required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                       <asp:Label ID="Label4" runat="server" Text="National ID :"></asp:Label>
                                     </div>
                                     <div class="col-md-6">
                                     <asp:TextBox ID="txtNID" runat="server" Text="" placeholder="National ID No" CssClass="form-control"></asp:TextBox>
                                      </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label5" runat="server" Text="Joining Date :"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtJoiningDate" placeholder="Joining Date" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="lblDesignation" runat="server" Text="Designation :"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <b style="display: none;">Client ID :</b>
                                            <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="select2" AutoPostBack="True">
                                                 <asp:ListItem Enabled="true" Text="Select All Designation" Value="0"></asp:ListItem>
                                                  <asp:ListItem Text="Moderator" Value="1"></asp:ListItem>
                                                  <asp:ListItem Text="Secretary General" Value="2"></asp:ListItem>
                                                  <asp:ListItem Text="Pion" Value="3"></asp:ListItem>
                                                   <asp:ListItem Text="Security Guard" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Caretaker" Value="4"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                     <div class="row">
                                      <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label7" runat="server" Text="Employee Image :"></asp:Label>
                                      </div>
                                    <div class="col-md-6" style="text-align: left;">
                                     
                                   <asp:FileUpload ID="ImagesUpload" runat="server" Height="40" CssClass="btn  btn-purple"  />
                                        &nbsp;
                                    </div>
                                 </div>
                                   
                                </div>
                                <div class="col-md-4">
                                   <div class="row">
                                       <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSalary"
                                           ErrorMessage="Sorry! Contact required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                       <asp:Label ID="Label6" runat="server" Text="Salary Per Month :"></asp:Label>
                                    </div>
                                     <div class="col-md-6">
                                     <asp:TextBox ID="txtSalary" runat="server" Text="" placeholder="Salary Per Month" CssClass="form-control"></asp:TextBox>
                                      </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                       <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPresentAdress"
                                           ErrorMessage="Sorry! Present Address required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                       <asp:Label ID="Label2" runat="server" Text="Present Address :"></asp:Label>
                                    </div>
                                     <div class="col-md-6">
                                     <asp:TextBox ID="txtPresentAdress" runat="server" Text=""  Height="35" TextMode="MultiLine" placeholder="Present Address" CssClass="form-control"></asp:TextBox>
                                      </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                  <div class="row">
                                       <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPermanentAdress"
                                           ErrorMessage="Sorry! Present Address required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                       <asp:Label ID="Label3" runat="server" Text="Permanent Address :"></asp:Label>
                                    </div>
                                     <div class="col-md-6">
                                     <asp:TextBox ID="txtPermanentAdress" runat="server" Text=""  Height="35" TextMode="MultiLine" placeholder="Permanent Address" CssClass="form-control"></asp:TextBox>
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
                    <div class="col-md-12" style="text-align: left;">
                        <div class="page-content" style="background: #EFF3F8 none repeat scroll 0 0;">
                           <asp:GridView ID="gvEmployeeInformationList" runat="server" 
                            AutoGenerateColumns="false" 
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
                                <asp:TemplateField HeaderText="Name" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Email" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%#Bind("Email") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Contact No" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblContactNo" runat="server" Text='<%#Bind("Contact") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Joining Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblJoiningDate" runat="server" Text='<%#Bind("JoiningDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="Designation" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignation" runat="server" Text='<%#Bind("Designation") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                 <asp:TemplateField HeaderText="Present Address" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPresentAddress" runat="server" Text='<%#Bind("PresentAddress") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Permanent Address" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPermanentAddress" runat="server" Text='<%#Bind("PermanentAddress") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Is Active">
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkisActive" runat="server" Enabled="false" Checked='<%# Bind("IsActive") %>' />
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="5%" />
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="5%" />
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
    
            <asp:AsyncPostBackTrigger ControlID="gvEmployeeInformationList" EventName="RowEditing" />
            <asp:AsyncPostBackTrigger ControlID="gvEmployeeInformationList" EventName="RowDeleting" />
           
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnupdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
