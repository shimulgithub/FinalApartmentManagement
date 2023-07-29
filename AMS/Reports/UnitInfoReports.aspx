<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="UnitInfoReports.aspx.cs" Inherits="AMS.Reports.UnitInfoReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="table-header">
                <div class="row">
                    <div class="col-sm-8" style="text-align: left;">
                        <i class="icon-th"></i>&nbsp; Unit Information
                    </div>
                </div>
            </div>
            <div class="page-content">
                <div>
                    <asp:HiddenField ID="hfpageid" runat="server" />
                    <!-- Panel starts -->
                    
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
                            <asp:GridView ID="gvUnitInformation" runat="server" AutoGenerateColumns="true"
                                PageSize="10" AllowSorting="true" AllowPaging="true" CssClass="table table-striped table-bordered table-hover"
                                OnSorting="gvUnitInformation_Sorting" OnPageIndexChanging="gvUnitInformation_PageIndexChanging"
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
            <asp:AsyncPostBackTrigger ControlID="gvUnitInformation" EventName="Sorting" />
            <asp:AsyncPostBackTrigger ControlID="gvUnitInformation" EventName="PageIndexChanging" />
            <asp:AsyncPostBackTrigger ControlID="gvUnitInformation" EventName="RowDataBound" />
            <asp:PostBackTrigger ControlID="btnExportExcel" />
 
   
            <%--<asp:AsyncPostBackTrigger ControlID="btnDateRanges" EventName="Click" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
