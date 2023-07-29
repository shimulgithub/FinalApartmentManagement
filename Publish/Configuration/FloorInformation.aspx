<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="FloorInformation.aspx.cs" Inherits="AMS.Configuration.FloorInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
        <ContentTemplate>
           
            <div class="widget-box">
                <div class="widget-header">
                    <div class="col-md-5">
                        <h4 class="widget-title">
                            <i class="icon-th"></i>&nbsp;Floor Information</h4>
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
                            <div class="col-md-12" style="text-align: left;">
                                <div class="row">
                                    <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblName" runat="server" Text="Floor Name :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFloorName"
                                            ErrorMessage="Sorry! User Group Full name required" Text="*" ForeColor="Red"
                                            ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtFloorName" runat="server" Text="" placeholder="Floor Name" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
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
                                   
                                
                              
                                <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
                                <asp:HiddenField ID="hfUserId" runat="server" />
                                <asp:ValidationSummary ID="vs" runat="server" ValidationGroup="UserForm" ShowMessageBox="true"
                                    ForeColor="Red" DisplayMode="BulletList" Font-Overline="true" ShowSummary="false" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12" style="text-align: left;">
                                <div class="page-content" style="background: #EFF3F8 none repeat scroll 0 0;">
                                    <asp:GridView ID="gvFloorInformationList" runat="server" AutoGenerateColumns="False"
                                        CssClass="gvv table table-striped table-bordered table-hover" OnRowDeleting="gvFloorInformationList_RowDeleting"
                                        OnRowEditing="gvFloorInformationList_RowEditing" OnRowDataBound="gvFloorInformationList_RowDataBound"
                                        EmptyDataText="No Data Found" Width="100%" ShowHeader="true" DataKeyNames="AutoID"
                                        AlternatingRowStyle-CssClass="gridviewaltrow">
                                        <RowStyle ForeColor="#000" Font-Size="12px" Wrap="false"></RowStyle>
                                        <HeaderStyle Wrap="false" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Floor Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAutoID" Visible="false" runat="server" Text='<%#Eval("AutoID")%>'></asp:Label>
                                           
                                                    <asp:Label ID="lblFloorName" runat="server" Text='<%#Eval("FloorName")%>'></asp:Label>
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
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnupdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="gvFloorInformationList" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="gvFloorInformationList" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>