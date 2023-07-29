<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="OwnerInformation.aspx.cs" Inherits="AMS.Configuration.OwnerInformation" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
        <ContentTemplate>
           
            <div class="widget-box">
                <div class="widget-header">
                    <div class="col-md-5">
                        <h4 class="widget-title">
                            <i class="icon-th"></i>&nbsp;Owner Information</h4>
                    </div>
                    <div class="col-md-7" style="text-align: right;">
                        <asp:LinkButton ID="btnNew" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btnNew_Click"
                            Style="font-weight: bold; font-size: 16px; height: 38px;"> <i class="icon-pencil align-center bigger-100"></i>&nbsp;New </asp:LinkButton>
                        <asp:LinkButton ID="btnsave" runat="server" OnClientClick="uploadComplete" CssClass="btn btn-sm btn-success" OnClick="btnsave_Click"
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
                           <div class="col-md-4">
                             <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblName" runat="server" Text="Owner Name :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOwnerName"
                                            ErrorMessage="Sorry! User Group Full name required" Text="*" ForeColor="Red"
                                            ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtOwnerName" runat="server" Text="" placeholder="Owner Name" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
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

                                
                                </div>
                           <div class="col-md-4">
                            <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label1" runat="server" Text="Contact No :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContactNo"
                                            ErrorMessage="Sorry! User Group Full name required" Text="*" ForeColor="Red"
                                            ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtContactNo" runat="server" Text="" placeholder="Contact No" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                                    </div>
                                    </div>
                                 
                              <div class="row">
                                   <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label2" runat="server" Text="National ID Card No :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNIDno"
                                            ErrorMessage="Sorry! User Group Full name required" Text="*" ForeColor="Red"
                                            ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtNIDno" runat="server" Text="" placeholder="National ID Card No " CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                                    </div>
                                </div>
                                  
                                 </div>
                           <div class="col-md-4">
                              <div class="row">
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label3" runat="server" Text="Present Address:"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPresentAddress"
                                            ErrorMessage="Sorry! User Group Full name required" Text="*" ForeColor="Red"
                                            ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                       <asp:TextBox ID="txtPresentAddress" runat="server" Height="30" placeholder="Present Address" CssClass="form-control"
                                            TextMode="MultiLine" />
                                    </div>
                                    </div>
                                     <div class="space-4">
                                </div>
                               <div class="row">
                                   <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label4" runat="server" Text="Permanent Address:"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPermanentAddress"
                                            ErrorMessage="Sorry! User Group Full name required" Text="*" ForeColor="Red"
                                            ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">

                                       <asp:TextBox ID="txtPermanentAddress" runat="server" Height="30" placeholder="Permanent Address" CssClass="form-control"
                                            TextMode="MultiLine" />
                                    </div>
                                </div>
                                <div class="space-4">
                                </div>
                                <div class="row">
                                  <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                    &nbsp;<asp:Label ID="Label6" runat="server" Text="Owner Picture:"></asp:Label>
                                    </div>
                                    <div class="col-md-6" style="font-weight: bold; text-align: right;">
                                      <asp:FileUpload ID="FileUpload1" runat="server" />
                                       <asp:Image ID="Image2" style=" margin-right:50px; margin-top:5px ; margin-bottom:5px; " runat="server"  Width="70px" Visible="false"  Height="70px"    />
                                    </div>
                                </div>
                        
                                 <div class="space-4">
                                </div>
                               
           
                            </div>
                        </div>
                                            <div id="dialog"  runat="server" style="display: none">
                                </div>
                                <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
                                <asp:HiddenField ID="hfUserId" runat="server" />
                                <asp:ValidationSummary ID="vs" runat="server" ValidationGroup="UserForm" ShowMessageBox="true"
                                    ForeColor="Red" DisplayMode="BulletList" Font-Overline="true" ShowSummary="false" />

                          <div class="row"  >
                                       <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label5" runat="server" Text="Unit Name :"></asp:Label>
                                   
                                    </div>
                                    <div class="col-md-10">
                                       <div class="widget-body">
                                                <div class="widget-main">
                                                    <asp:CheckBoxList runat="server" ID="chkFields" DataTextField="Column_name" RepeatDirection="Vertical"
                                                        RepeatColumns="10" Style="padding: 2px; margin: 5px" DataValueField="Column_name"
                                                        RepeatLayout="Table" Width="100%" />
                                                </div>
                                            </div>
                                    </div>
                                  <div class="space-4">
                                 </div>
                                 </div>
                        <div class="row">
                            <div class="col-md-12" style="text-align: left;">
                                <div class="page-content" style="background: #EFF3F8 none repeat scroll 0 0;">
                                        <div class="row">
                            <div class="col-md-12" style="text-align: left;">
                                <div class="page-content" style="background: #EFF3F8 none repeat scroll 0 0;">
                                    <asp:GridView ID="gvOwnerInformationList" runat="server" AutoGenerateColumns="False"
                                        CssClass="gvv table table-striped table-bordered table-hover" OnRowDeleting="gvOwnerInformationList_RowDeleting"
                                        OnRowEditing="gvOwnerInformationList_RowEditing" OnRowDataBound="gvOwnerInformationList_RowDataBound"
                                        EmptyDataText="No Data Found" Width="100%" ShowHeader="true" DataKeyNames="AutoID"
                                        AlternatingRowStyle-CssClass="gridviewaltrow">
                                        <RowStyle ForeColor="#000" Font-Size="12px" Wrap="false"></RowStyle>
                                        <HeaderStyle Wrap="false" />
                                        <Columns>
                                    
                                         <asp:TemplateField HeaderText="Owner Picture">
                                                <ItemTemplate>
                                                 <asp:Image  ID="Image1" runat="server"  Height="40px" Width="40px"  />  
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Owner Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAutoID" Visible="false" runat="server" Text='<%#Eval("AutoID")%>'></asp:Label>
                                                    <asp:Label ID="lblOwnerName" runat="server"  Text='<%#Eval("OwnerName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unit Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUnitName" runat="server"  Width="20px" Text='<%#Eval("UnitName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                          <asp:TemplateField HeaderText="Email">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server"  Text='<%#Eval("Email")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Contact No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContactNo" runat="server"   Text='<%#Eval("ContactNo")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="National ID No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNational_Id_card_No" runat="server"  Text='<%#Eval("National_Id_card_No")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Present Address" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPresent_Address" runat="server"  Text='<%#Eval("Present_Address")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Permanent Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPermanent_Address" runat="server"  Text='<%#Eval("Permanent_Address")%>'></asp:Label>
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
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
         
     
       <%--   <asp:AsyncPostBackTrigger ControlID="btnUpload" EventName="Click" />--%>
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
            <asp:PostBackTrigger ControlID="btnsave" />
            <asp:PostBackTrigger ControlID="btnupdate"/>
            <asp:AsyncPostBackTrigger ControlID="gvOwnerInformationList" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="gvOwnerInformationList" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>