<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="BuildingInformation.aspx.cs" Inherits="AMS.Configuration.BuildingInformation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
    <script type="text/javascript">

        function readURL(input) {
            //alert(input.value);
            // var vFileName = input.split('\\').pop();
            var vFileExt = input.value.split('.').pop();
            // alert(vFileName);
            // alert(vFileExt);
            document.getElementById('dvMsg').style.display = "none";
            //$('#<%=Image1.ClientID%>').prop('src','~/assets/css/img/user(3).png');

            if (vFileExt.toUpperCase() == "JPEG" || vFileExt.toUpperCase() == "JPG" || vFileExt.toUpperCase() == "PNG" || vFileExt.toUpperCase() == "GIF" || vFileExt.toUpperCase() == "BMP") {


                var uploadControl = document.getElementById('<%= fuProfilePic.ClientID %>')
                //alert(uploadControl.value);
                if (uploadControl.files[0].size > 15360) {
                    document.getElementById('dvMsg').style.display = "block";
                    //return false;
                    document.getElementById('<%= fuProfilePic.ClientID %>').value = '';
                    document.getElementById('<%= Image1.ClientID %>').src = "../assets/css/img/user(3).png";
                }
                else {
                    document.getElementById('dvMsg').style.display = "none";
                    //return true;
                    //alert(input.files[0]); 
                    var uploadControl = document.getElementById('<%= fuProfilePic.ClientID %>');
                    // alert(uploadControl.value);

                    if (input.files && input.files[0]) {
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                            // alert(e.target.result);
                        }

                        // alert(e.target.result); 
                        reader.readAsDataURL(input.files[0]);
                        // alert(e.target.result); 
                        //document.getElementById('<%= fuProfilePic.ClientID %>').value = '';
                    }

                    var uploadControl = document.getElementById('<%= fuProfilePic.ClientID %>');
                    // alert(uploadControl.value);
                }


                var uploadControl = document.getElementById('<%= fuProfilePic.ClientID %>');
                // alert(uploadControl.value);
            }
            else {
                alert("Please upload a valid image file.");
                document.getElementById('<%= fuProfilePic.ClientID %>').value = '';
                document.getElementById('<%= Image1.ClientID %>').src = "";
                document.getElementById('<%= Image1.ClientID %>').src = "../assets/css/img/user(3).png";
                //document.getElementById('fuProfilePic').value = '';
                //return true;
            }


            var uploadControl = document.getElementById('<%= fuProfilePic.ClientID %>');
            // alert(uploadControl.value);

        }

        $("#fuProfilePic").change(function () {
            readURL(this);
            //alert( readURL(this));
        });
 
            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
        <ContentTemplate>
           <%-- <script type="text/javascript">
                Sys.Application.add_load(BindEvents); </script>--%>
            <div class="widget-box">
                <div class="widget-header">
                    <div class="col-md-5">
                        <h4 class="widget-title">
                            <i class="icon-th"></i>&nbsp;Building Information</h4>
                    </div>
                    <div class="col-md-7" style="text-align: right;">
                        <asp:LinkButton ID="btnNew" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btnNew_Click"
                            Style="font-weight: bold; font-size: 16px; height: 38px;"> <i class="icon-pencil align-center bigger-100"></i>&nbsp;New </asp:LinkButton>
                        <asp:LinkButton ID="btnsave" runat="server" CssClass="btn btn-sm btn-success" OnClick="btnsave_Click"
                            ValidationGroup="UserForm" Style="font-weight: bold; font-size: 16px; height: 38px;"> 
                                    <i class="icon-save bigger-100"  ></i>&nbsp;Save </asp:LinkButton>
                        <asp:LinkButton ID="btnupdate" runat="server" CssClass="btn btn-sm btn-success" OnClick="btnsave_Click"
                            Style="font-weight: bold; font-size: 16px; height: 38px;">
                                     <i class="icon-edit bigger-100"  ></i>&nbsp;Update </asp:LinkButton>
                    </div>
                </div>
                <div class="widget-body">
                    <div class="widget-main no-padding">
                        <div class="space-4">
                        </div>
                        <!-- <legend>Form</legend> -->
                        <div class="row">
                            <div class="col-md-4" style="text-align: left;">
                               
                                <div class="space-4">
                                </div>
                                <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblName" runat="server" Text="Building Name :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBuildingName"
                                            ErrorMessage="Sorry! User Group Full name required" Text="*" ForeColor="Red"
                                            ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtBuildingName" runat="server" Text="" placeholder="Name" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                                    </div>
                                   
                                </div>
                                   <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblGroupShortName" runat="server" Text="Owner Name :"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtOwnerName" runat="server" placeholder="Owner Name"
                                            CssClass="form-control" Text="" />
                                        &nbsp;
                                    </div>
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
                                     &nbsp;<asp:Label ID="Label4" runat="server" Text="Building Images :"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                    <asp:FileUpload ID="fuProfilePic" runat="server"   onchange="readURL(this)" />
                                   </div>
                                  
                                </div>
                                 


                                   <div class="row">
                                   <div class="col-md-6" style="font-weight: bold; text-align: right;">

                                  
                                  
                                    </div>
                                     <div class="space-4">
                                    </div>
                                      <div  class="col-md-6"  style=" float:right">
                                      <asp:Image ID="Image1" ImageUrl="~/images/defalt.jpg" runat="server" Width="70px"  Height="70px"   CssClass="circle" />
                                     
                                     </div>

                                    <div id="dvMsg" style="background-color: Red; color: White; padding: 3px; display: none;">
                                        Maximum size allowed is 15 KB.
                                    </div>
                                 </div>
                                      <%--<h2>
                                    Welcome to ASP.NET!
                                   </h2>
                                   <p>
                                    Please Select an Image file: &nbsp;&nbsp; 
                                    <asp:FileUpload ID="Fupload_WatermarkImage" runat="server" />
                                   </p>
                                   <p>
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload Image" onclick="btnUpload_Click" />
                                  </p>
                                    <p>
                                    <asp:Image ID="imgUploadedImage" runat="server" Width="250" Height="250" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" />
                                  </p>--%>
                                  <%--------<div class="input-group bootstrap-timepicker">
                                        <asp:TextBox ID="TextBox1" CssClass="form-control timepicker1" runat="server" placeholder="Time"></asp:TextBox>
                                        <span class="input-group-addon"><i class="icon-time bigger-110"></i></span>
                                    </div>--------%>
                                   
                                
                            
                            </div>
                             <div class="col-md-4" style="text-align: left;">
                             <div class="row">
                                <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label1" runat="server" Text="Contact No :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContactNo"
                                            ErrorMessage="Sorry! Contact no required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtContactNo" runat="server" Text="" placeholder="Contact No" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                                    </div>
                                    </div>
                                     <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label2" runat="server" Text="Security Guard Mobile No:"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtSecurityGuardNo" runat="server" placeholder="Security Guard Mobile No"
                                            CssClass="form-control" />
                                        &nbsp;
                                    </div>
                                   
                                </div>
                                <div  class="row">
                                 <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label3" runat="server" Text="Secretary Mobile No :"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtSecretaryMobileNo" runat="server" Text="" placeholder="Secretary Mobile No"
                                            CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                                    </div>
                                </div>
                                 <div class="row">
                                   <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label8" runat="server" Text="Building Rules :"></asp:Label>
                                    </div>
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                    <asp:FileUpload ID="FileUpload1" runat="server"  ToolTip="Select Only PDF File" /> </td>  
                                  </div>
                                </div>


                              
                             </div>
                              <div class="col-md-4" style="text-align: left;">
                              
                                 <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label9" runat="server" Text="Rajuk Reference:"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtRajukRef" runat="server" placeholder="Rajuk Reference"
                                            CssClass="form-control" />
                                        &nbsp;
                                    </div>
                                    </div>

                                       <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblGroupRemarks" runat="server" Text="Address :"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtAddress" runat="server" Height="35" placeholder="Address" CssClass="form-control"
                                            TextMode="MultiLine" />
                                        &nbsp;<br />
                                    </div>
                                    </div>
                                     <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblBuildingConstructionYear" runat="server" Text="Year :"></asp:Label>
                                    </div>
                                    <div class="col-md-6" style="text-align: left;">
                                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                  
                              </div>
                        </div>
                                
                                <div class="space-4">
                                 </div>
                                <div class="row">
                                    <div class="col-md-3" style="font-weight: bold; font-style: italic; color:#579ec8; margin-left: 10px; float: left;">
                                        <h4 class="widget-title"> Builder Information</h4>
                                    </div>
                                </div>
                                    <div class="space-4">
                                 </div>
                                 <div class="row">
                                   <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label5" runat="server" Text="Company Name :"></asp:Label>
                                    </div>
                                    <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                     <asp:TextBox ID="txtCompanyName" runat="server" Text="" placeholder="Company Name"
                                            CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                                       </div>
                                       <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label6" runat="server" Text="Company Phone No :"></asp:Label>
                                    </div>
                                    <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                     <asp:TextBox ID="txtCompanyPhoneNo" runat="server" Text="" placeholder="Company Phone No"
                                            CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                                       </div>
                                </div>
                                   <div class="row">
                                   <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label7" runat="server" Text="Company Address :"></asp:Label>
                                    </div>
                                    <div class="col-md-8" style="font-weight: bold; text-align: right;">
                                     <asp:TextBox ID="txtCompanyAddress" runat="server" Text="" placeholder="Company Address"
                                            CssClass="form-control"  TextMode="MultiLine" ></asp:TextBox>&nbsp;&nbsp;
                                       </div>
                                      
                                </div>
                                <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
                                <asp:HiddenField ID="hfUserId" runat="server" />
                                <asp:ValidationSummary ID="vs" runat="server" ValidationGroup="UserForm" ShowMessageBox="true"
                                    ForeColor="Red" DisplayMode="BulletList" Font-Overline="true" ShowSummary="false" />
                        <div class="row">
                            <div class="col-md-12" style="text-align: left;">
                                <div class="page-content" style="background: #EFF3F8 none repeat scroll 0 0;">
                                    <asp:GridView ID="gvBuildingInformationList" runat="server" AutoGenerateColumns="False"
                                        CssClass="gvv table table-striped table-bordered table-hover" OnRowDeleting="gvBuildingInformationList_RowDeleting"
                                        OnRowEditing="gvBuildingInformationList_RowEditing" OnRowDataBound="gvBuildingInformationList_RowDataBound"
                                        EmptyDataText="No Data Found" Width="100%" ShowHeader="true" DataKeyNames="AutoID"
                                        AlternatingRowStyle-CssClass="gridviewaltrow">
                                        <RowStyle ForeColor="#000" Font-Size="12px" Wrap="false"></RowStyle>
                                        <HeaderStyle Wrap="false" />
                                        <Columns>
                                         <asp:TemplateField HeaderText="Building Images">
                                                <ItemTemplate>
                                                 <asp:Image  ID="Image1" runat="server"  Height="50" Width="50"  />  
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Building Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAutoID" Visible="false" runat="server" Text='<%#Eval("AutoID")%>'></asp:Label>
                                           
                                                    <asp:Label ID="lblBuildingName" runat="server" Text='<%#Eval("BuildingName")%>'></asp:Label>
                                                </ItemTemplate>
                                         
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAutoID_Auto" runat="server" Text='<%#Eval("AutoID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Owner Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOwnerName" runat="server" Text='<%#Eval("OwnerName")%>'></asp:Label>
                                                </ItemTemplate>
                                              
                                            </asp:TemplateField>
                                         <%--   <asp:TemplateField HeaderText="Email">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                               <asp:TemplateField HeaderText="Contact No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("ContactNo")%>'></asp:Label>
                                                </ItemTemplate>
                                              
                                            </asp:TemplateField>
                                        
                                          <asp:TemplateField HeaderText="Sec Gaurd No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSecGaurdNo" runat="server" Text='<%#Eval("SecGaurdNo")%>'></asp:Label>
                                                </ItemTemplate>
                                              
                                            </asp:TemplateField>

                                            
                                          <asp:TemplateField HeaderText="Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                                                </ItemTemplate>
                                              
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Building Ruls">
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




                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
            <asp:PostBackTrigger ControlID="btnsave" />
            <asp:AsyncPostBackTrigger ControlID="btnupdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="gvBuildingInformationList" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="gvBuildingInformationList" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
