<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ChangePwd.aspx.cs" Inherits="AMS.Configuration.ChangePwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function fun_ShowPassChangeMessage() {
            alert('Password changed successfully. Please click \'ok\' and log on with your new password');
            window.top.location.href = "Logout.aspx";
        }
        function ChkPassword() {

            var txtNewPassword = document.getElementById("<%=txtNewPassword.ClientID %>");
            var txtConfNewPassword = document.getElementById("<%=txtConfNewPassword.ClientID %>");

            if (txtNewPassword.value == '' || txtConfNewPassword.value == '') {

                alert("New password or confirm password can not blank");
                return false;
            }

            if (txtNewPassword.value != txtConfNewPassword.value) {

                alert("New password and confirm password are not same");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="changePassword" class="form-horizontal" style="overflow:hidden;">
        <div class="row">
            <div class="col-sm-12 col-md-12">
                <div class="space-4">
                </div>
                <div class="form-group">
                    <label for="" class="col-sm-4 control-label no-padding-right">
                        Login ID
                    </label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtLoginID" runat="server" placeholder="Login ID" Enabled="false"   CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="" class="col-sm-4 control-label no-padding-right">
                        Old Password
                    </label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Old Password"
                          CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="" class="col-sm-4 control-label no-padding-right">
                        New Password
                    </label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" placeholder="New Password"
                          CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="" class="col-sm-4 control-label no-padding-right">
                        Conf. Password
                    </label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtConfNewPassword" runat="server" TextMode="Password" placeholder="Conf. Password"
                           CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="" class="col-sm-4 control-label no-padding-right">
                        &nbsp;</label>
                    <div class="col-sm-6">
                        <asp:Label ID="NoUser" runat="server" ForeColor="Red" Text="User does not exist"
                            Visible="False"></asp:Label>
                        <div id="msgrow">
                        </div>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <label for="" class="col-sm-4 control-label no-padding-right">
                        &nbsp;</label>
                    <div class="col-sm-6">
                        <asp:Button ID="btnLogin" runat="server" Text="Update" OnClick="btnLogin_Click" OnClientClick="javascript:return ChkPassword()"
                            CssClass="btn btn-sm btn-inverse" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="txtHidLoginID" runat="server" />
    <asp:HiddenField ID="hidMenuID" runat="server" />
</asp:Content>
