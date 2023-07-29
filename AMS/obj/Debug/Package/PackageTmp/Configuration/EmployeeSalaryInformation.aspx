<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="EmployeeSalaryInformation.aspx.cs" Inherits="AMS.Configuration.EmployeeSalaryInformation" %>

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
                                <i class="icon-th"></i>&nbsp;Employee Salary Information</h4>

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
                                   
                                       <asp:Label ID="lblName" runat="server" Text="Employee Name :"></asp:Label>
                                      </div>
                                     <div class="col-md-6">
                                         <asp:DropDownList ID="ddlEmployeeID" runat="server" CssClass="select2" AutoPostBack="True"   OnSelectedIndexChanged="ddlEmployeeID_SelectedIndexChanged" >
                                              
                                            </asp:DropDownList>
                                     </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="lblEmailID" runat="server" Text="Designation :"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                            <b style="display: none;">Client ID :</b>
                                            <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="select2" AutoPostBack="True">
                                               
                                            </asp:DropDownList>
                                        </div>
                                   </div>
                                    <div class="space-4">
                                    </div>
                                
                              
                                   
                                </div>
                                <div class="col-md-4">
                                   <div class="row">
                                      <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                  
                                       <asp:Label ID="Label4" runat="server" Text="Salary Month :"></asp:Label>
                                     </div>
                                     <div class="col-md-6">
                                       <asp:DropDownList ID="ddSalaryMonthName" runat="server" CssClass="select2" AutoPostBack="True">
                                                 <asp:ListItem Enabled="true" Text="Select All Salary Month" Value="0"></asp:ListItem>
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
                                    </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label5" runat="server" Text="Salary Year :"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                             <asp:DropDownList ID="ddlSalaryYear" runat="server" CssClass="select2" AutoPostBack="True">
                                                 <asp:ListItem Enabled="true" Text="Select All Salary Year" Value="0"></asp:ListItem>
                                                  <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                  <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                                  <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                                                  <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                                                  <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                                                  <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                                                 

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="space-4">
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
                                            <asp:Label ID="Label1" runat="server" Text="Issue Date :"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtIssueDate" placeholder="Issue Date" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                             <%--     <div class="row">
                                       <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPermanentAdress"
                                           ErrorMessage="Sorry! Present Address required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                       <asp:Label ID="Label3" runat="server" Text="Permanent Address :"></asp:Label>
                                    </div>
                                     <div class="col-md-6">
                                     <asp:TextBox ID="txtPermanentAdress" runat="server" Text=""  Height="35" TextMode="MultiLine" placeholder="Permanent Address" CssClass="form-control"></asp:TextBox>
                                      </div>
                                    </div>--%>
                                <%--    <div class="space-4">
                                    </div>--%>
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
                           <asp:GridView ID="gvEmployeeSalaryInformationList" runat="server" 
                            AutoGenerateColumns="false" 
                            OnRowEditing="gvEmployeeSalaryInformationList_RowEditing"
                            OnRowDeleting="gvEmployeeSalaryInformationList_RowDeleting"                                               
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
                                <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Designation" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignationName" runat="server" Text='<%#Bind("DesignationName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Month Name" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalaryMonthName" runat="server" Text='<%#Bind("SalaryMonthName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Year" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblYear" runat="server" Text='<%#Bind("Year") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="Designation" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignation" runat="server" Text='<%#Bind("Designation") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                 <asp:TemplateField HeaderText="Salary Amount(TK)" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalaryAmount" runat="server" Text='<%#Bind("SalaryAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Issue Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIssueDate" runat="server" Text='<%#Bind("IssueDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                         <%--          <asp:TemplateField HeaderText="Is Active">
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkisActive" runat="server" Enabled="false" Checked='<%# Bind("IsActive") %>' />
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="5%" />
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="5%" />
                           </asp:TemplateField>--%>
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
    
            <asp:AsyncPostBackTrigger ControlID="gvEmployeeSalaryInformationList" EventName="RowEditing" />
            <asp:AsyncPostBackTrigger ControlID="gvEmployeeSalaryInformationList" EventName="RowDeleting" />
           
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnupdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
