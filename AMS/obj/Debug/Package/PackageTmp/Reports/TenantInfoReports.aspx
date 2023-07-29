<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="TenantInfoReports.aspx.cs" Inherits="AMS.Reports.TenantInfoReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="table-header">
                <div class="row">
                    <div class="col-sm-8" style="text-align: left;">
                        <i class="icon-th"></i>&nbsp; Tenant Information
                    </div>
                </div>
            </div>
            <div class="page-content">
                <div>
                    <asp:HiddenField ID="hfpageid" runat="server" />
                    <!-- Panel starts -->
                    <div class="panel panel-default" style="width: auto; padding: 5px;">
                        <div id="dvTab">
                         <asp:Button ID="btnVersion" Visible="false" Text="Version Name" runat="server" OnClick="btnVersion_Click"
                                Font-Bold="true" Font-Size="14px" CssClass="btn btn-purple" Style="font-weight: bold;
                                font-size: 14px;" />
                            <asp:Button ID="btnColumns" Text="Columns View" runat="server" OnClick="btnColumns_Click"
                                Font-Bold="true" Font-Size="14px" CssClass="btn btn-purple" Style="font-weight: bold;
                                font-size: 14px;" />
                            <asp:Button ID="btnModule" Text="Filter"  runat="server" OnClick="btnModule_Click"
                                Font-Bold="true" Font-Size="14px" CssClass="btn btn-purple" Style="font-weight: bold;
                                font-size: 14px;" />
                           
                            <asp:Button ID="btnClearfilteringcriteria" Text="Clear filtering criteria" runat="server"
                                OnClick="btnClearfilteringcriteria_Click" Font-Bold="true" Font-Size="14px" CssClass="btn btn-purple"
                                Style="font-weight: bold; float: right; font-size: 14px;" />
                            <asp:HiddenField ID="hfTab" runat="server" />
                            <!-- Navigation Tabs starts -->
                            <asp:Panel ID="pnl1Columns" runat="server" Visible="false" Style="margin: 0px">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="widget-box">
                                            <div class="widget-header widget-header-flat">
                                                <h5 class="widget-title" style="color: #000000; font-weight: bold;">
                                                    <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" Checked="true" OnCheckedChanged="ChkAll_CheckedChanged" />&nbsp;Hide
                                                    and Show Columns.</h5>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <asp:CheckBoxList runat="server" ID="chkFields" DataTextField="Column_name" RepeatDirection="Vertical"
                                                        RepeatColumns="5" Style="padding: 5px; margin: 5px" DataValueField="Column_name"
                                                        RepeatLayout="Table" Width="100%" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnl2Module" runat="server" Visible="false" class="" Style="padding: 5px;
                                border: 1px solid #ddd; margin: 5px">
                                <div class="row">
                                    <div class="col-md-3">
                                        <b style="display: none;">Employee Ref/ID :</b>
                                          <asp:DropDownList ID="ddlConsEmployeeRef" runat="server" CssClass="select2">
                                        </asp:DropDownList>
                                       
                                    </div>
                                    <div class="col-md-3">
                                        <b style="display: none;">Division ID :</b>
                                        <asp:DropDownList ID="ddlDivisionID" runat="server" CssClass="select2" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <b style="display: none;">Department ID :</b>
                                        <asp:DropDownList ID="ddlDepartmentID" runat="server" CssClass="select2">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <b style="display: none;">Consultant ID :</b>
                                        <asp:DropDownList ID="ddlConsultant" runat="server" CssClass="select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="space-4">
                                </div>
                                <div class="row" style="display: none;">
                                    <div class="col-md-3">
                                        <b style="display: none;">Employee Ref/ID :</b>
                                       <asp:DropDownList ID="ddlEmployeeRef" runat="server" CssClass="select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                  <div class="row">
                                    <div class="col-md-3">
                                        <b style="display: none;">Employee Ref/ID :</b>
                                       <asp:DropDownList ID="ddlMatchingConsultantDivison" runat="server" CssClass="select2">
                                       <asp:ListItem Text="Select Matching Consultant Divison" Selected="True" Value="0" > </asp:ListItem> 
                                       <asp:ListItem Text="Yes"   > </asp:ListItem> 
                                       <asp:ListItem Text="No"   > </asp:ListItem> 
                                        </asp:DropDownList>
                                    </div>
                                     <div class="col-md-3">
                                        <b style="display: none;">Employee Ref/ID :</b>
                                       <asp:DropDownList ID="ddlMatchingConsultantDept" runat="server" CssClass="select2">
                                       <asp:ListItem Text="Select Matching Consultant Dept" Selected="True" Value="0" > </asp:ListItem> 
                                       <asp:ListItem Text="Yes"  Value="Yes" > </asp:ListItem> 
                                       <asp:ListItem Text="No"   Value="No" > </asp:ListItem> 
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="space-4">
                                </div>
                            </asp:Panel>
                             <asp:Panel ID="Panel4Version" runat="server" Visible="false" Style="margin-left: 0;
                                margin-top: 5px; padding: 5px; border: 1px solid #ddd;">
                                <div class="row">
                                    <div class="col-md-2">
                                        <b style="display: none;">Version ID :</b>
                                        <asp:DropDownList ID="ddlVersionID" runat="server" CssClass="select2" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                    <!-- Panel ends -->
                </div>
                <div class="row">
                    <div class="col-md-2">
                        <br />
                        <asp:LinkButton ID="btnprint" runat="server" CssClass="btn btn-purple btn-sm" OnClick="btnprint_Click"
                            Style="font-weight: bold; font-size: 14px;"><span class="ace-icon fa fa-search icon-on-right bigger-110"></span>&nbsp;Search</asp:LinkButton>
                    </div>
                    <div class="col-md-10" style="text-align: right;">
                        <br />
                        <asp:LinkButton ID="btnExportExcel" runat="server" CssClass="btn btn-purple btn-sm"
                            OnClick="btnExportExcel_Click" Style="font-weight: bold; font-size: 14px;"> <i class="ace-icon fa fa-reply icon-only"></i> &nbsp;Export To Excel</asp:LinkButton>
                    </div>
                    <div class="col-md-2" style="display: none;">
                        <br />
                        <asp:LinkButton ID="btnExportToPDF" runat="server" CssClass="btn btn-purple btn-sm"
                            OnClick="btnExportToPDF_Click" Style="font-weight: bold; font-size: 14px;">Export To PDF  <i class="icon-print bigger-130"></i></asp:LinkButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <br />
                        <div style="background-color: #F5F5F5; text-align: left; padding-left: 5px; border-top: 1px solid #ddd;
                            border-left: 1px solid #ddd; border-right: 1px solid #ddd;">
                            <asp:Label ID="Label7" runat="server" Text="" Font-Bold="True" Font-Size="Large"
                                ForeColor="#307ECC"></asp:Label></div>
                        <div style="width: 100%; overflow: auto;">
                            <asp:GridView ID="gvTenantInformation" runat="server" AutoGenerateColumns="false"
                                PageSize="10" AllowSorting="true" AllowPaging="true" CssClass="table table-striped table-bordered table-hover"
                                OnSorting="gvTenantInformation_Sorting" OnPageIndexChanging="gvTenantInformation_PageIndexChanging"
                                PagerSettings-Mode="NumericFirstLast" EmptyDataText="No Data Show" Width="100%"
                                AlternatingRowStyle-CssClass="gridviewaltrow" OnRowDataBound="gvDetails_RowDataBound">
                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Left" />
                                <RowStyle Wrap="false" />
                                <HeaderStyle Wrap="false" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnprint" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="gvTenantInformation" EventName="Sorting" />
            <asp:AsyncPostBackTrigger ControlID="gvTenantInformation" EventName="PageIndexChanging" />
            <asp:AsyncPostBackTrigger ControlID="gvTenantInformation" EventName="RowDataBound" />
            <asp:PostBackTrigger ControlID="btnExportExcel" />
            <asp:AsyncPostBackTrigger ControlID="btnExportToPDF" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnColumns" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnModule" EventName="Click" />
            <%--<asp:AsyncPostBackTrigger ControlID="btnDateRanges" EventName="Click" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
