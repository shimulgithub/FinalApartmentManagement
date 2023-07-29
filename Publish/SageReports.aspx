<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SageReports.aspx.cs" Inherits="SageReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <script type="text/javascript">
       function Popup(url) {
           window.open(url, "myWindow", "status = 1, height = 600, width = 800, resizable = 0")
       }
        
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="table-header">
                <div class="row">
                    <div class="col-sm-8" style="text-align: left;">
                        <i class="icon-th"></i>&nbsp;Spencer Tempest Reports
                    </div>
                     
                </div>
            </div>
            <div class="page-content" >
                <div class="row">
                    <div class="col-md-12">
                       
                        <div class="row">
                            <div class="col-md-12">
                                <asp:RadioButton ID="rdbValidTimesheetswithSuppliers" CssClass="radio radio-info" Text="Valid Timesheets with Suppliers"
                                    GroupName="a" runat="server" Font-Bold="True" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:RadioButton ID="rdbMarginReportsbyEmployerswithdetails" CssClass="radio radio-info" Text="Margin Reports by Employers with details"
                                    GroupName="a" runat="server" Font-Bold="True" />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-12">
                                <asp:RadioButton ID="rdbCreditNotesDetails" CssClass="radio radio-info" Text="Credit Notes Details"
                                    GroupName="a" runat="server" Font-Bold="True" />
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-12">
                                <asp:RadioButton ID="rdbAssignementDetailswithconsultantsplits" CssClass="radio radio-info" Text="Assignement Details with consultant splits"
                                    GroupName="a" runat="server" Font-Bold="True" />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-12">
                                <asp:RadioButton ID="rdbWorkersuppliers" CssClass="radio radio-info" Text="Worker Suppliers"
                                    GroupName="a" runat="server" Font-Bold="True" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:RadioButton ID="rdbPermPlacementReports" CssClass="radio radio-info" Text="Perm Placement Reports"
                                    GroupName="a" runat="server" Font-Bold="True" />
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-4">
                                <br />
                                <asp:LinkButton ID="btnprint" runat="server" CssClass="btn btn-purple btn-sm" OnClick="btnprint_Click"
                                    Style="font-weight: bold; font-size: 14px;">Print  <i class="icon-print bigger-130"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnprint" EventName="Click" />

        </Triggers>
    </asp:UpdatePanel>

</asp:Content>

