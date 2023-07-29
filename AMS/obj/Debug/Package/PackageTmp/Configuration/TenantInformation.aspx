<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="TenantInformation.aspx.cs" Inherits="AMS.Configuration.TenantInformation" %>


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
    <script language="javascript" type="text/javascript">
        function expandcollapse_Edit(obj, row) {
            var div = document.getElementById(obj);
            var img = document.getElementById('img' + obj);

            alert(div);
            alert(img);
            alert(row);
            alert(obj);
            alert(div.style.display);

            div.style.display = "none";
            img.src = "../Images/plus.gif";


        } 
    </script>
    <script language="javascript" type="text/javascript">
        function expandcollapse(obj, row) {
            var div = document.getElementById(obj);
            var img = document.getElementById('img' + obj);

            alert(div);
            alert(img);
            alert(row);
            alert(obj);
            alert(div.style.display);


            if (div.style.display == "none") {
                div.style.display = "block";
                //                if (row == 'alt') {
                //                    img.src = "minus.gif";
                //                }
                //                else {
                img.src = "../Images/minus.gif";
                //}
                //img.alt = "Close to view other Customers";
            }
            else {
                div.style.display = "none";
                //                if (row == 'alt') {
                //                    img.src = "plus.gif";
                //                }
                //                else {
                img.src = "../Images/plus.gif";
                //}
                //img.alt = "Expand to show Orders";
            }
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
                                <i class="icon-th"></i>&nbsp Tenant Information</h4>

                        </div>

                      
                        <div class="col-md-7" style="text-align: right;">
                         <asp:LinkButton ID="btnNew" runat="server" CssClass="btn btn-primary"  OnClick="btnNew_Click"
                                Style="font-weight: bold;"> <i class="icon-pencil align-center bigger-100"></i>&nbsp;New</asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="btnsave" runat="server" CssClass="btn btn-success" OnClick="btnsave_Click"
                                ValidationGroup="UserForm" Style="font-weight: bold;"> 
                                    <i class="icon-save bigger-100"  ></i>&nbsp;Save</asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="btnupdate" runat="server" CssClass="btn btn-success" OnClick="btnsave_Click"
                                Style="font-weight: bold;"> <i class="icon-edit bigger-100"  ></i>&nbsp;Update</asp:LinkButton>

                                 </div>  
                           
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
                                      <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblName" runat="server" Text="Tenant Name :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenant"
                                            ErrorMessage="Sorry! Tenat name required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtTenant" runat="server" Text="" placeholder="Tenant Name" CssClass="form-control"></asp:TextBox>
                                      
                                    </div>
                                </div>
                                    <div class="space-4">
                                </div>
                                   <div class="row">
                                      <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label7" runat="server" Text="Tenant Father Name :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txttenatfatherName"
                                            ErrorMessage="Sorry! Tenat name required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txttenatfatherName" runat="server" Text="" placeholder="Tenant Father Name" CssClass="form-control"></asp:TextBox>
                                      
                                    </div>
                                </div>
                                <div class="space-4">
                                </div>
                                 <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        <asp:Label ID="Label8" runat="server" Text="Tanent Date Of Birth :"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                      <div class="input-group">
                                                <asp:TextBox ID="txtTenantDateDOB" placeholder="Tanent Date Of Birth" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                    </div>
                                </div>
                                  <div class="space-4">
                                    </div>
                                     <div class="row">
                                        <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label9" runat="server" Text="Marital Status :"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="select2">
                                               <asp:ListItem Enabled="true" Text="Select All Marital Status" Value="0"></asp:ListItem>
                                                  <asp:ListItem Text="Married" Value="1"></asp:ListItem>
                                                  <asp:ListItem Text="Unmarried" Value="2"></asp:ListItem>
                                                 
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                  <div class="space-4">
                                </div>
                                 <div class="space-4">
                                </div>
                                 <div class="space-4">
                                </div>
                               <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        <asp:Label ID="Label22" runat="server" Text="Permanent Address:"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtPermanentAddres" runat="server" Text="" placeholder="Permanent Address" TextMode="MultiLine"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                 <div class="space-4">
                                </div>
                               
                                  <div class="row">
                                        <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label28" runat="server" Text="Issue Date :"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtRentStartDate" placeholder="Issue Date" runat="server"
                                                    CssClass="form-control date-picker" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                <div class="space-4">
                                </div>
                                   <div class="row">
                                      <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label32" runat="server" Text="Advance Rent :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAdvanceRent"
                                            ErrorMessage="Sorry! Advance rent required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtAdvanceRent" runat="server" Text="" placeholder="Advance Rent" CssClass="form-control"></asp:TextBox>
                                      
                                    </div>
                                </div>
                                </div>
                                <div class="col-md-4">

                                    <div class="row">
                                        <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label10" runat="server" Text="Religion :"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlReligion" runat="server" CssClass="select2">
                                               <asp:ListItem Enabled="true" Text="Select All Religion" Value="0"></asp:ListItem>
                                                  <asp:ListItem Text="Islam" Value="1"></asp:ListItem>
                                                  <asp:ListItem Text="Hindu" Value="2"></asp:ListItem>
                                                 
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                 <div class="space-4">
                                </div>
                                 <div class="row">
                                      <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label15" runat="server" Text="Contact No :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContact"
                                            ErrorMessage="Sorry! Contact No required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtContact" runat="server" Text="" placeholder="Contact No" CssClass="form-control"></asp:TextBox>
                                      
                                    </div>
                                </div>
                                 <div class="space-4">
                                </div>
                                 <div class="row">
                                      <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label16" runat="server" Text="NID(Tenant Nationl ID):"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNID"
                                            ErrorMessage="Sorry! Tanent National required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtNID" runat="server" Text="" placeholder="Tenant Nationl ID" CssClass="form-control"></asp:TextBox>
                                      
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
                                        &nbsp;
                                    </div>
                                </div>
                              
                               <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        <asp:Label ID="Label21" runat="server" Text="Present Address:"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtPresentAddress" runat="server" Text="" placeholder="Present Address" TextMode="MultiLine"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                   <div class="space-4">
                                </div>
                                 <div class="row">
                                        <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label30" runat="server" Text="Floor No :"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlFloorNo" runat="server" AutoPostBack="true" CssClass="select2" OnSelectedIndexChanged="ddlFloor_SelectedIndexChanged">
                                            
                                            </asp:DropDownList>
                                        </div>
                                    </div>


                                       <div class="space-4">
                                </div>
                                   <div class="row">
                                      <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label33" runat="server" Text="Rent Per Month :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAdvanceRent"
                                            ErrorMessage="Sorry! Rent Per Month  required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtRentPerMonth" runat="server" Text="" placeholder="Rent Per Month" CssClass="form-control"></asp:TextBox>
                                      
                                    </div>
                                </div>
                                </div>
                                <div class="col-md-4">
                               
                               <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        <asp:Label ID="Label17" runat="server" Text="Occupation:"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtOccupation" runat="server" Text="" placeholder="Occupation"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="space-4">
                                    </div>
                                     <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        <asp:Label ID="Label2" runat="server" Text="Education Qualification:"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtEducation" runat="server" Text="" placeholder="Education Qualification"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="space-4">
                                    </div>
                                       <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        <asp:Label ID="Label3" runat="server" Text="Emergency Contact Person:"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtEmergencyContactPerson" runat="server" Text="" placeholder="Emergency Contact Person"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="space-4">
                                    </div>
                                       <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        <asp:Label ID="Label19" runat="server" Text="Emergency Contact Person no:"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtEmergencyContactPersonNo" runat="server" Text="" placeholder="Emergency Contact Person no"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="space-4">
                                </div>
                                 <div class="space-4">
                                </div> <div class="space-4">
                                </div>
                               <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        <asp:Label ID="Label20" runat="server" Text="Occupation Address:"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtOccupationAddress" runat="server" Text="" placeholder="Occupation Address" TextMode="MultiLine"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                  
                                <div class="space-4">
                                </div>
                                 <div class="row">
                                        <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label31" runat="server" Text="Unit No :"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlUnitNo" runat="server" CssClass="select2">
                                               <asp:ListItem Enabled="true" Text="Select All Unit No " Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                     <div class="space-4">
                                </div>
                                      <div class="row">
                                  <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                    &nbsp;<asp:Label ID="Label29" runat="server" Text="Tenant Image:"></asp:Label>
                                    </div>
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                      <asp:FileUpload ID="FileUpload1" runat="server" />

                                       <asp:Image ID="Image2" style=" margin-right:50px; margin-top:5px ; margin-bottom:5px; " runat="server"  Width="70px" Visible="false"  Height="70px"    />
                                    </div>
                                </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <asp:HiddenField ID="hfAutoId" runat="server" />
                <asp:HiddenField ID="hfAutoIdDetail" runat="server" />
                <asp:HiddenField ID="hfLeaveHolidaysMasterComments" runat="server" />
                  <asp:HiddenField ID="hfLeaveHolidaysDetailsComments" runat="server" />
            </div>
            <div class="panel panel-default" style="width: auto; padding: 5px; background-color : lightblue">
                <div id="dvTab"  runat="server" style=" background-color :lightblue">
                    <asp:HiddenField ID="hfTab" runat="server" />
                 <%--   <div class="row"  >
                        <div class="col-md-6">
                            <asp:Button ID="btnVersion" Text="Assignment Details" runat="server" Visible="false"
                                OnClick="btnVersion_Click" Font-Bold="true" Font-Size="14px" CssClass="btn btn-purple"
                                Style="font-weight: bold; font-size: 14px;" />
                            <asp:Button ID="btnPayrollDetails" Text="Payroll Details" runat="server" ToolTip="Payrol Details Entry" OnClick="btnPayrollDetails_Click" Font-Bold="true" Font-Size="14px" CssClass="btn btn-purple" Style="font-weight: bold; font-size: 14px;" />
                            <asp:Button ID="btnModule" Text="Clients Details" runat="server" Visible="false"
                                OnClick="btnPayrollDetails_Click" Font-Bold="true" Font-Size="14px" CssClass="btn btn-purple"
                                Style="font-weight: bold; font-size: 14px;" />
                            <asp:Button ID="btnDateRanges" Text="Worker Details" runat="server" Visible="false"
                                OnClick="btnDateRanges_Click" Font-Bold="true" Font-Size="14px" CssClass="btn btn-purple"
                                Style="font-weight: bold; font-size: 14px;" />
                        </div>
                    </div>--%>
                    <div class="space-4">
                    </div>
                 
                    <!-- Navigation Tabs starts -->
                    <div id="dvLeaveDetails" runat="server" >
                        <asp:Panel ID="pnl1PayrollDetails" runat="server"  Style="margin: 0px ; background-color:lightblue">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label11" runat="server" Text="House Worker Name :"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                           
                                            <asp:TextBox ID="txtHouseWorkerName" runat="server" Text="" placeholder="Name"
                                            CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label18" runat="server" Text="House Worker Contact no :"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            
                                             <b style="display: none;">House Worker Contact no :</b>
                                            <asp:TextBox ID="txtHouseWorkerContactNo" runat="server" Text="" placeholder="Contact No"
                                            CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                      <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label25" runat="server" Text="Previous House Owner Name :"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                             <asp:TextBox ID="txtPreviousHouseOwnerName" runat="server" Text="" placeholder="House Owner Name "
                                            CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label1" runat="server" Text="House Worker NID No :"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                             <asp:TextBox ID="txtHouseWorkerNID" runat="server" Text="" placeholder="House Worker NID No"
                                            CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label4" runat="server" Text="House Worker Address :"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                          <asp:TextBox ID="txtHouseWorkerAddress" TextMode="MultiLine" Height="40"  runat="server" Text="" placeholder="House Worker Address"
                                            CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                      <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label26" runat="server" Text="Pre. House Owner Contact :"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                             <asp:TextBox ID="txtPreHoouseOwnerContct" runat="server" Text="" placeholder="Pre. House Owner Contact"
                                            CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label5" runat="server" Text="Driver Name :"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtDriverName"  placeholder="Driver Name" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                     <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label6" runat="server" Text="Driver phone No :"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                           <asp:TextBox ID="txtDriverContactNo"  placeholder="Driver phone No" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                       <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label27" runat="server" Text="Pre. House owner Address :"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                           <asp:TextBox ID="txtPreHouseownerAddress"  TextMode="MultiLine" Height="40" placeholder="Pre. House owner Address" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                </div>

                                 <div class="col-md-3">
                                    <div class="space-4">
                                    </div>
                                   <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label23" runat="server" Text="Driver NID No :"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                           <asp:TextBox ID="txtDriverNIDno"  placeholder="Driver NID No" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                   <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label24" runat="server" Text="Driver Address :"></asp:Label>
                                        </div>
                                        <div class="col-md-7"> 
                                           <asp:TextBox ID="txtDriverAddress" TextMode="MultiLine"  Height="40" placeholder="Driver Address" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>

                                 <div class="space-4">
                                </div>
                                <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label34" runat="server" Text="Is Active :"></asp:Label>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:CheckBox ID="chkIsActive" runat="server" />
                                    </div>
                                </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="dvgvTenantinformationList" runat="server"  Style="margin: 0px">
                            <div class="row">
                                <div class="space-4">
                                </div>
                                <div class="col-md-12" style="text-align: left;">
                                    <div class="page-content" style="background: #EFF3F8 none repeat scroll 0 0;">
                                        <asp:GridView ID="gvTenantinformationList"
                                          runat="server" AutoGenerateColumns="False"
                                            CssClass="table table-striped table-hover" 
                                            OnRowDeleting="gvTenantinformationList_RowDeleting"
                                            OnRowEditing="gvTenantinformationList_RowEditing"
                                             OnRowDataBound="gvTenantinformationList_RowDataBound"
                                            EmptyDataText="No Data Found" Width="100%"
                                            ShowHeader="true" DataKeyNames="AutoID"
                                            border="0"
                                            GridLines="Horizontal">
                                            <RowStyle ForeColor="#000" Font-Size="12px" Wrap="false">
                                            </RowStyle>
                                            <HeaderStyle Wrap="false" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgShow" runat="server" ToolTip="Expand or Collapse Leave Details Entry" OnClick="Show_Hide_ChildGrid" ImageUrl="~/images/plus.png"
                                                            CommandArgument="Show" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Tenant Picture">
                                                <ItemTemplate>
                                                 <asp:Image  ID="Image1" runat="server"  Height="50" Width="50"  />  
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tenant Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTenantName" runat="server" Text='<%#Eval("TenantName")%>'></asp:Label>
                                                         <asp:Label ID="lblTenantID" runat="server" Visible="false" Text='<%#Eval("AutoID")%>'></asp:Label>
                                                        <asp:Label ID="lblAutoID_Auto" runat="server" Visible="false" Text='<%#Eval("AutoID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tenant Father Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTenantFatherName" runat="server" Text='<%#Eval("TenantFatherName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                           <%--     <asp:TemplateField HeaderText="Absence Type">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTypeOfLeave" runat="server" Text='<%#Eval("LeaveType")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Absence Year">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLeaveYear" runat="server" Text='<%#Eval("LeaveYear")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Allowances Start Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAllowancesStartDate" runat="server" Text='<%#Eval("AllowancesStartDate")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Allowances End Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAllowancesEndDate" runat="server" Text='<%#Eval("AllowancesEndDate")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Holidays Entitlement">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAllowances" runat="server" Text='<%#Eval("Allowances")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Units">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnits" runat="server" Text='<%#Eval("Units")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Remaining">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRemaining" runat="server" Text='<%#Eval("Remaining")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Comments">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblComments" runat="server" Text='<%#Eval("Comments")%>'></asp:Label>
                                                    </ItemTemplate>
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
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Panel ID="pnlOrders" runat="server" Visible="false" Style="position: relative">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                                                <ContentTemplate>
                                                                    <tr style ="background-color:lightgrey">
                                                                    
                                                                        <td colspan="100%">
                                                                       
                                                                            <div id="divCh" style="margin-left: 42px; margin-right: 12px; margin-top: 0px; margin-bottom: -5px;
                                                                                background: #fff none repeat scroll 0 0; background-color:lightgrey">
                                                                                <%--<asp:Label ID="lblAutoID" Visible="false" runat="server" Text='<%#Eval("SLNo")%>'></asp:Label>
                                                                               --%>
                                                                                <div class="row">
                                                                                  <h3 style ="transform: rotate(360deg); transform-origin: left top 0; font-family:Open Sans;font-weight: bold; margin-bottom:10px ">Family Member Entry</h3>
                                                                                    <div class="col-md-12">
                                                                                        <div class="row" style="float: right;">
                                                                                            <div class="col-md-12">
                                                                                                <asp:LinkButton ID="btnMenberDetailNew" CssClass="btn  btn-xs btn-primary" runat="server" ToolTip="New Family Member details entry"  OnClick="btnMenberDetailNew_Click" Style="font-weight: bold;">
                                                                                                 <i class="icon-pencil align-center bigger-40"></i>&nbsp;New</asp:LinkButton>&nbsp;
                                                                                                <asp:LinkButton ID="btnmemberSave" CssClass="btn btn-xs btn-success" runat="server" ToolTip="Save record leave details"
                                                                                                    OnClick="btnmemberSave_Click" Style="font-weight: bold;"> <i class="icon-save bigger-40"  ></i>&nbsp;Save</asp:LinkButton>&nbsp;
                                                                                                <asp:LinkButton ID="btnmemberUpdate" CssClass="btn btn-xs btn-success" runat="server" ToolTip="Edit existing  leave details"
                                                                                                    Visible="false" OnClick="btnmemberUpdate_Click" Style="font-weight: bold;"> <i class="icon-edit bigger-40"  ></i>&nbsp;Update</asp:LinkButton>&nbsp;
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="space-4">
                                                                                        </div>
                                                                                        <div class="row">
                                                                                            <div class="space-4">
                                                                                            </div>
                                                                                            <div class="col-md-4">
                                                                                                <div class="row">
                                                                                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                                                                                        &nbsp;<asp:Label ID="Label100" runat="server" Text="Name:"></asp:Label>
                                                                                                    </div>
                                                                                                    <div class="col-md-8">
                                                                                                        
                                                                                                            <asp:TextBox ID="txtName" placeholder="Name" runat="server" CssClass="form-control"> </asp:TextBox>
                                                                                                            
                                                                                                        
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="space-4">
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                                                                                        &nbsp;<asp:Label ID="Label12" runat="server" Text="Relation:"></asp:Label>
                                                                                                    </div>
                                                                                                   
                                                                                                        <div class="col-md-8">
                                                                                                       
                                                                                                            <asp:TextBox ID="txtRelation" placeholder="Relation" runat="server" CssClass="form-control"> </asp:TextBox>
                                                                                                        
                                                                                                     </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="space-4">
                                                                                            </div>
                                                                                            <div class="col-md-4">
                                                                                                <div class="row">
                                                                                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                                                                                        <asp:Label ID="lblOccupation" runat="server" Text="Occupation:"></asp:Label>
                                                                                                    </div>
                                                                                                    <div class="col-md-8">
                                                                                                        <asp:TextBox ID="txtMemberOccupation" placeholder="Occupation" runat="server"
                                                                                                            CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="space-4">
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                                                                                        <asp:Label ID="Label13" runat="server" Text="Contact No:"></asp:Label>
                                                                                                    </div>
                                                                                                    <div class="col-md-8">
                                                                                                        <asp:TextBox ID="txtMemberContact" placeholder="Contact No" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>

                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="space-4">
                                                                                            </div>
      
                                                                                            <div class="col-md-4">
                                                                                                <div class="row">
                                                                                                   <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                                                                                   <asp:Label ID="lblAge" runat="server" Text="Age :"></asp:Label>
                                                                                                    </div>
                                                                                                    <div class="col-md-6">
                                                                                                     <asp:TextBox ID="txtAge"  Width="50" placeholder="Age" runat="server" CssClass="form-control"></asp:TextBox>

                                                                                                  </div>
                                                                                                </div>
                                                                                                 <div class="space-4">
                                                                                                </div>
                                                                                           <div class="row">
                                                                                          <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                                                                            &nbsp;<asp:Label ID="lblChild" runat="server" Text="Image:"></asp:Label>
                                                                                            </div>
                                                                                            <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                                                                              <asp:FileUpload ID="MemberFileUpload1" runat="server" />

                                                                                               <asp:Image ID="ChildImage2" style=" margin-right:50px; margin-top:5px ; margin-bottom:5px; " runat="server"  Width="70px" Visible="false"  Height="70px"    />
                                                                                            </div>
                                                                                        </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="space-4">
                                                                                 </div>
                                                                                <asp:GridView ID="gvTenantMemberInformationList" runat="server" 
                                                                                   AutoGenerateColumns="false" 
                                                                                   
                                                                                    CssClass="table table-striped table-hove" 
                                                                                    OnRowEditing="gvTenantMemberInformationList_RowEditing" 
                                                                                    OnRowDeleting="gvTenantMemberInformationList_RowDeleting"
                                                                                    OnRowDataBound="gvTenantMemberInformationList_RowDataBound"
                                                                                    PagerSettings-Mode="NumericFirstLast" ShowHeader="true"
                                                                                    DataKeyNames="AutoID" EmptyDataText="No Data Show" Width="100%"
                                                                                    border="0"
                                                                                    GridLines="Horizontal">
                                                                                     
                                                                                    <RowStyle ForeColor="#000" Font-Size="12px" Wrap="false">
                                                                                   </RowStyle>
                                                                                   <HeaderStyle Wrap="false" />

                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="SL No">
                                                                                            <HeaderStyle VerticalAlign="Middle" />
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblColumnAutoID" runat="server" Visible="false" Text='<%#Bind("AutoID") %>'></asp:Label>
                                                                                                <asp:Label ID="lblSLNo" runat="server" Text='<%#Bind("SLNo") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                          <asp:TemplateField HeaderText="Image">
                                                                                         <ItemTemplate>
                                                                                         <asp:Image  ID="MemberImage" runat="server"  Height="50" Width="50"  />  
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Name" HeaderStyle-Font-Bold="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                       
                                                                                         <asp:TemplateField HeaderText="Contact No" HeaderStyle-Font-Bold="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblContact" runat="server" Text='<%#Bind("Contact") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                       <asp:TemplateField HeaderText="Relation" HeaderStyle-Font-Bold="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblRelation" runat="server" Text='<%#Bind("Relation") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                          <asp:TemplateField HeaderText="Occupation" HeaderStyle-Font-Bold="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblOccupation" runat="server" Text='<%#Bind("Occupation") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                         <asp:TemplateField HeaderText="Age" HeaderStyle-Font-Bold="true">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblAge" runat="server" Text='<%#Bind("Age") %>'></asp:Label>
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
                                                                        </td>
                                                                    </tr>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                     <asp:PostBackTrigger ControlID="btnmemberSave" />
                                                                      <asp:PostBackTrigger ControlID="btnmemberUpdate" />
                                                                    <asp:AsyncPostBackTrigger ControlID="btnMenberDetailNew" EventName="Click" />
                                                                    
                                                                    <asp:AsyncPostBackTrigger ControlID="gvTenantMemberInformationList" EventName="RowDeleting" />
                                                                    <asp:AsyncPostBackTrigger ControlID="gvTenantMemberInformationList" EventName="RowEditing" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </asp:Panel>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnsave" />
            <asp:PostBackTrigger ControlID="btnupdate" />
            <asp:AsyncPostBackTrigger ControlID="gvTenantinformationList" EventName="RowDataBound" />

           <asp:AsyncPostBackTrigger ControlID="ddlFloorNo" EventName="SelectedIndexChanged" />
      
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
