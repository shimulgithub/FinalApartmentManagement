

<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);

    }
    void Session_End(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("~/UserLogin_Logout.aspx");

    }
    static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("Home", "Home", "~/UnderConstruction.aspx");

        routes.MapPageRoute("Dashboard", "Dashboard", "~/UnderConstruction.aspx");
        
        //routes.MapPageRoute("Tempest", "Tempest", "~/SMS_MainDashboard.aspx");
        
        routes.MapPageRoute("Finance", "Finance", "~/UnderConstruction.aspx");
        
       // routes.MapPageRoute("System Admin", "System Admin", "~/SMS_MainDashboard.aspx");

        routes.MapPageRoute("Valid Timesheet (Summary)", "ValidTimesheetswithSuppliers", "~/Reports/ValidTimeSheetsWithSuppliers.aspx");

        routes.MapPageRoute("Margin Reports (Details)-Tempest", "MarginReportsbyEmployerswithdetails", "~/Reports/MarginReportsbyEmployerswithdetails.aspx");

        routes.MapPageRoute("Margin Reports (Details-old)-Tempest", "MarginReportsbyEmployerswithdetailsPrevoius", "~/Reports/MarginReportsbyEmployerswithdetailsPrevoius.aspx");
    
       
        
        
        routes.MapPageRoute("Credit Notes Details", "CreditNotesDetails", "~/Reports/CreditNotesDetails.aspx");

        routes.MapPageRoute("Assg. Details-Consultant Splits", "AssignementDetailswithconsultantsplits", "~/Reports/AssignementDetailswithconsultantsplits.aspx");
        
        routes.MapPageRoute("Worker Suppliers", "WorkerSuppliers", "~/Reports/WorkerSuppliers.aspx");
        
        routes.MapPageRoute("Perm Placement", "PermPlacementReports", "~/Reports/PermPlacementReports.aspx");
        
        routes.MapPageRoute("Worker Details", "WorkerDetails", "~/Reports/WorkerDetails.aspx");

     
        routes.MapPageRoute("Purchase Day Book", "PurchaseDayBook", "~/Reports/PurchaseDayBookReport.aspx");
        
        routes.MapPageRoute("US Payroll Spread Sheet", "USPayrollSpreadSheet", "~/Reports/USPayrollSpreadSheet.aspx");
       
        
        //routes.MapPageRoute("User's Group", "UsersGroup", "~/SMS_MainDashboard.aspx");
        
        //routes.MapPageRoute("Create User", "CreateUser", "~/SMS_MainDashboard.aspx");
        
        routes.MapPageRoute("User Wise Page Premission", "UserPagePremission", "~/Configuration/UserPagePermission.aspx");

        routes.MapPageRoute("User Action Permission", "UserActionPermission", "~/Configuration/UserActionPermission.aspx");

        routes.MapPageRoute("User's Group Entry", "UsersGroup", "~/Configuration/NewUserGroup.aspx");

        routes.MapPageRoute("User Information Entry", "CreateUser", "~/Configuration/NewUser.aspx");
        
        routes.MapPageRoute("Search User", "UserInfo", "~/Configuration/NewUser_List.aspx");
        
        routes.MapPageRoute("Segments Master", "SegmentsMaster", "~/Configuration/SegmentsMaster.aspx");

        routes.MapPageRoute("Monthly Service Charges Entry", "MonthlyServiceCharge", "~/Configuration/MonthlyServiceChargeEntry.aspx");

        routes.MapPageRoute("Duty Information", "DutyInfoReports", "~/Reports/DutyInfoReports.aspx");
        
        routes.MapPageRoute("Email /SMS Logs", "EmailLogsReports", "~/Reports/EmailLogsReports.aspx");

        routes.MapPageRoute("Salary Information", "SalaryInfoReports", "~/Reports/SalaryInfoReports.aspx");
        
        routes.MapPageRoute("Leave Information", "LeaveInfoReports", "~/Reports/LeaveInfoReports.aspx");
        
        routes.MapPageRoute("Employee Information", "EmployeeReports", "~/Reports/EmployeeReports.aspx");
        
         routes.MapPageRoute("Unit Information View", "UnitInfoReports", "~/Reports/UnitInfoReports.aspx");
       
        
        routes.MapPageRoute("Floor Information", "FloorReports", "~/Reports/FloorReports.aspx");
        
        routes.MapPageRoute("Owner Information", "OwnerInfoReports", "~/Reports/OwnerInfoReports.aspx");

        routes.MapPageRoute("Tenant Information", "TenantInfoReports", "~/Reports/TenantInfoReports.aspx");
        
        routes.MapPageRoute("Building Information", "BuildingReports", "~/Reports/BuildingReports.aspx");
        
        routes.MapPageRoute("Send Email / SMS", "EmailSMSSend", "~/Configuration/EmailSMSSend.aspx");
        
        routes.MapPageRoute("Employee Leave Acceptance", "EmployeeLeaveAcceptanceList", "~/Configuration/EmployeeLeaveAcceptanceList.aspx");
        
        routes.MapPageRoute("Visitor Presence Entry", "VisitorPresenceEntry", "~/Configuration/VisitorPresenceEntry.aspx");

        routes.MapPageRoute("MeetingInformationEntry", "MeetingInformationEntry", "~/Configuration/MeetingInformationEntry.aspx");

        routes.MapPageRoute("Owner Notice Entry", "OwnerNoticeEntry", "~/Configuration/OwnerNoticeEntry.aspx");

        routes.MapPageRoute("Employee Notice Entry", "EmployeeNoticeEntry", "~/Configuration/EmployeeNoticeEntry.aspx");

        routes.MapPageRoute("Tenant Notice Entry", "TenantNoticeEntry", "~/Configuration/TenantNoticeEntry.aspx");

        routes.MapPageRoute("Complain Information Entry", "ComplainEntry", "~/Configuration/ComplainEntry.aspx");

        routes.MapPageRoute("Visitor Information Entry", "VisitorInformationEntry", "~/Configuration/VisitorInformationEntry.aspx");

        routes.MapPageRoute("Bill Deposit Entry", "BillEntry", "~/Configuration/BillEntry.aspx");
        
        routes.MapPageRoute("Owner Utility Entry", "OwnerUtilityEntry", "~/Configuration/OwnerUtilityEntry.aspx");
        
        routes.MapPageRoute("Rent Collection Entry", "RentCollectionEntry", "~/Configuration/RentCollectionEntry.aspx");
        
        routes.MapPageRoute("FloorInformation Entry", "FloorInformation", "~/Configuration/FloorInformation.aspx");
        
        routes.MapPageRoute("Maintenance Cost Entry", "MaintenanceCostEntry", "~/Configuration/MaintenanceCostEntry.aspx");
        
        routes.MapPageRoute("Apartment Fund Entry", "ApartmentFundEntry", "~/Configuration/ApartmentFundEntry.aspx");
        
        routes.MapPageRoute("Employee Leave Entry", "EmployeeLeaveInformation", "~/Configuration/EmployeeLeaveInformation.aspx");
        
        routes.MapPageRoute("Employee Duty Information Entry", "EmployeeDutyInformation", "~/Configuration/EmployeeDutyInformation.aspx");
        
        routes.MapPageRoute("Employee Salary Information", "EmployeeSalaryInformation", "~/Configuration/EmployeeSalaryInformation.aspx");
        
        routes.MapPageRoute("Employee Information Entry", "EmployeeInformation", "~/Configuration/EmployeeInformation.aspx");

        routes.MapPageRoute("Building Information Entry", "BuildingInformation", "~/Configuration/BuildingInformation.aspx");

        routes.MapPageRoute("Tenant Information Entry", "TenantInformation", "~/Configuration/TenantInformation.aspx");
        
        routes.MapPageRoute("Unit Information", "UnitInformation", "~/Configuration/UnitInformation.aspx");

        routes.MapPageRoute("Owner Information Entry", "OwnerInformation", "~/Configuration/OwnerInformation.aspx");

      
    }
    
</script>

