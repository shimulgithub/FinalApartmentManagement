<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UnderConstruction.aspx.cs" Inherits="UnderConstruction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center   >
        <asp:Label ID="Label1" runat="server" Text="We are currently working on" Font-Bold="True" ForeColor="#295381" Font-Size="35px"></asp:Label>
        <br /> <asp:Label ID="Label2" runat="server" Text="something awesome. Stay tuned!" Font-Bold="True" ForeColor="#295381" Font-Size="28px"></asp:Label>
        <br />
              <img src="Images/construction.gif" />
               <br /><h1><asp:Label ID="Label3" runat="server"    Text="by FS Team" Font-Bold="True" ForeColor="#295381" Font-Size="28px" Font-Overline="True"></asp:Label></h1>
    </center>
</asp:Content>
