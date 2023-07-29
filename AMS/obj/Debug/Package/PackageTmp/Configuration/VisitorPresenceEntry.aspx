<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="VisitorPresenceEntry.aspx.cs" Inherits="AMS.Configuration.VisitorPresenceEntry" %>

   <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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

    <style type="text/css">
        .Background
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .Popup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 350px;
        }
        .lbl
        {
            font-size:16px;
            font-style:italic;
            font-weight:bold;
        }
        
      
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField ID="hftakenDayForEdit" runat="server" />
             <asp:HiddenField ID="hfAutoId" runat="server" />
            
                  <div class="widget-box">
                <div class="widget-header">
                    <div class="row">
                        <div class="col-md-5">
                            <h4 class="widget-title">
                                <i class="icon-th"></i>&nbsp;Invited Visitor Presence Entry</h4>
                                  <asp:Button ID="Button1"  Enabled="false"  runat="server"  BackColor="White" BorderStyle="None" Text="" style=" float:right; margin-right:12px"  />
                      
                        </div>

                          <asp:Button ID="btnNew"  Text="New" runat="server" Font-Bold="true" OnClick="btnNew_Click"  Font-Size="14px" CssClass="btn btn-purple" Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;" />      
                          <asp:LinkButton ID="btnsave" runat="server" CssClass="btn btn-success"  Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;"> <i class="icon-save bigger-100"  ></i>&nbsp;Save</asp:LinkButton>&nbsp;&nbsp;
                          <asp:LinkButton ID="btnupdate" runat="server" CssClass="btn btn-success"   Style="font-weight: bold; float: right; margin-right:10px; font-size: 14px;"> <i class="icon-edit bigger-100"  ></i>&nbsp;Update</asp:LinkButton>&nbsp;&nbsp;
                           
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
                                      <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                   
                                       <asp:Label ID="lblName" runat="server" Text="Entry Date :"></asp:Label>
                                      </div>
                                     <div class="col-md-8">
                                  <div class="input-group">
                                                <asp:TextBox ID="txtEntryDate" placeholder="Entry Date" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                     </div>
                                    </div>
                                   <%--    <div class="space-4">
                                    </div>
                                   <div class="row">
                                      <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                   
                                       <asp:Label ID="Label1" runat="server" Text="Floor Name :"></asp:Label>
                                      </div>
                                     <div class="col-md-8">
                                         <asp:DropDownList ID="ddlFloor" runat="server" CssClass="select2" AutoPostBack="True" OnSelectedIndexChanged="ddlFloor_SelectedIndexChanged"  >
                                         
                                         </asp:DropDownList>
                                     </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="lblFundMonth" runat="server" Text="Unit No :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                            <b style="display: none;">Client ID :</b>
                                            <asp:DropDownList ID="ddlUnitName" runat="server" CssClass="select2" AutoPostBack="True"   >
                                                
                                            </asp:DropDownList>
                                        </div>
                                   </div>
                                    <div class="space-4">
                                    </div>--%>
                                
                                
                                
                                </div>
                                <div class="col-md-4">
                                  
                                     <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           &nbsp;<asp:Label ID="Label5" runat="server" Text="Visitor Type :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                           <asp:DropDownList ID="ddlVisitorType" runat="server" CssClass="select2" AutoPostBack="True">
                                                
                                            </asp:DropDownList>
                                       
                                        </div>
                                   </div>
                                   
                                
                                </div>
                                <div class="col-md-4">
                                    
                                  
                                    <div class="row">
                                        <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label2" runat="server" Text="Search Box :"></asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                             <asp:TextBox ID="txtSearchBox" runat="server" placeholder="Search Box"  CssClass="form-control"
                                             />
                                       </div>
                                   
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                        
                                </div>

                            </div>
                            </asp:Panel>
                        </div>
                    
                </div>
                <div class="row">
                    <div class="col-md-2">

                        <asp:LinkButton ID="btnprint" runat="server" CssClass="btn btn-xs btn-purple btn-sm"  OnClick="btnprint_Click"
                            Style="font-weight: bold; font-size: 14px;"><span class="ace-icon fa fa-search icon-on-right bigger-110"></span>&nbsp;Search</asp:LinkButton>
                    </div>
                    <div class="col-md-10" style="text-align: right;">

                        <asp:LinkButton ID="btnAllAbsence" runat="server"  OnClick="btnAllAbsence_Click" CssClass="btn  btn-xs btn-purple btn-sm"
                             Style="font-weight: bold; font-size: 14px;"> <i class="glyphicon glyphicon-remove"></i> &nbsp;All Absence</asp:LinkButton>
                    </div>
                   
                </div>
         
                    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Button1" CancelControlID="Button2" BackgroundCssClass="Background"> </cc1:ModalPopupExtender>
                       <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">
                        <h2> Do you want to change  in or out time!</h2>
     
                          <br/>
                         
                             <div class="row">
                                        <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label1" runat="server" Text="In Time :"></asp:Label>
                                        </div>
                                        <div class="col-md-6" style=" margin-right: 55px">
                                             <div class="input-group bootstrap-timepicker">
                                        <asp:TextBox ID="txtInTime" CssClass="form-control timepicker1" runat="server" placeholder="In Time"></asp:TextBox>
                                        <span class="input-group-addon"><i class="icon-time bigger-110"></i></span>
                                    </div>
                                   
                                        </div>
                                    </div>
                                      <div class="space-4">
                                    </div>
       
                             <div class="row">
                                        <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label3" runat="server" Text="Out Time :"></asp:Label>
                                        </div>
                                        <div class="col-md-6" style=" margin-right: 55px ">
                                             <div class="input-group bootstrap-timepicker">
                                        <asp:TextBox ID="txtOutTime" CssClass="form-control timepicker1" runat="server" placeholder="Time"></asp:TextBox>
                                        <span class="input-group-addon"><i class="icon-time bigger-110"></i></span>
                                    </div>
                                   
                                        </div>
                                    </div>
                            <br/>
                       <asp:Button ID="Button2" runat="server" Text="Close"   CssClass="btn btn-xs btn-success btn-sm" Style="font-weight: bold; margin-left:60px;  font-size: 14px; margin-top:10px" />
                       <asp:Button ID="btnDone" runat="server" Text="Done"  OnClick="btnDone_Click"  CssClass="btn btn-xs btn-purple btn-sm" Style="font-weight: bold; margin-left:20px; font-size: 14px; margin-top:10px " />
                       </asp:Panel>
            <div class="row">
                    <div class="col-md-12" style="text-align: left;">
                        <div class="page-content" style="background: #EFF3F8 none repeat scroll 0 0;">
                           <asp:GridView ID="gvVisitorInformationList" runat="server" 
                            AutoGenerateColumns="false" 
                   
                                                                    
                            CssClass="table table-striped table-hove" 
                            PagerSettings-Mode="NumericFirstLast" ShowHeader="true"
                            DataKeyNames="AutoID" EmptyDataText="No Data Show" Width="100%"
                            border="0"
                            GridLines="Horizontal">                              
                            <RowStyle ForeColor="#000" Font-Size="12px" Wrap="false">
                            </RowStyle>
                            <HeaderStyle Wrap="false" />
                            <Columns>
                               
                                <asp:TemplateField HeaderText="Entry Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                     
                                        <asp:Label ID="lblEntryDate" runat="server" Text='<%#Bind("EntryDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Floor Name " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFloorName" runat="server" Text='<%#Bind("FloorName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 
                                  <asp:TemplateField HeaderText="Unit Name " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitName" runat="server" Text='<%#Bind("UnitName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Name " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Mobile No" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMobile" runat="server" Text='<%#Bind("Mobile") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Visitor Type" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVisitorType" runat="server" Text='<%#Bind("VisitorType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Contact Person" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblContactPerson" runat="server" Text='<%#Bind("ContactPerson") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Visitor Address" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVisitorAddress" runat="server" Text='<%#Bind("VisitorAddress") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="InTime" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInTime" runat="server" Text='<%#Bind("InTime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="OutTime" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIOutTime" runat="server" Text='<%#Bind("OutTime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                                     <ContentTemplate>
                                                     <asp:LinkButton ID="lnkDownload" runat="server" Text="P" ToolTip="Presence" CssClass="glyphicon glyphicon-ok bigger-130 green" OnClick="btnprint1_Click" CommandArgument='<%# Eval("AutoID") %>'></asp:LinkButton>
                                                       &nbsp;&nbsp;
                                                        <asp:LinkButton ID="btnAbsence" runat="server" Text="A"  CssClass="glyphicon glyphicon-remove bigger-130 red"
                                                            ToolTip="Absence" CommandName="Delete" CausesValidation="false"
                                                            CommandArgument='<%# Eval("AutoID") %>'   OnClientClick="return confirm('Are you sure you want to Delete this Record?');" OnClick= "btnAbsence_Click"/>
                                                      
                                                     </ContentTemplate>

                                                      <Triggers>
                                                       <asp:PostBackTrigger ControlID="lnkDownload"  />
                                                       <asp:PostBackTrigger ControlID="btnAbsence"  />
                                                        </Triggers>
                                                     </asp:UpdatePanel>
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
          
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnupdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDone" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
