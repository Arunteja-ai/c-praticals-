<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Academic Calendar & Leave Management</title>
    <style>
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background-color: #f0f2f5; margin: 0; padding: 20px; }
        .container { max-width: 700px; margin: 0 auto; background: white; padding: 30px; border-radius: 8px; box-shadow: 0 4px 8px rgba(0,0,0,0.1); }
        h2 { text-align: center; color: #333; border-bottom: 2px solid #007bff; padding-bottom: 10px; }
        .form-group { margin-bottom: 15px; }
        label { display: block; margin-bottom: 5px; font-weight: bold; color: #555; }
        input[type="text"], select, textarea { width: 100%; padding: 10px; border: 1px solid #ccc; border-radius: 4px; box-sizing: border-box; }
        .btn { width: 100%; padding: 12px; background-color: #28a745; color: white; border: none; border-radius: 4px; cursor: pointer; font-size: 16px; margin-top: 20px; }
        .btn:hover { background-color: #218838; }
        .error { color: red; font-size: 0.9em; margin-top: 5px; display: block; }
        .calendar-container { display: flex; justify-content: center; margin-top: 10px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Leave Application Form</h2>
            
            <p>Welcome back, <asp:Label ID="lblWelcome" runat="server" Font-Bold="true" ForeColor="#007bff"></asp:Label>!</p>
            
            <div class="form-group">
                <label>Employee Name:</label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" 
                    ErrorMessage="Name is required." CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label>Leave Type:</label>
                <asp:DropDownList ID="ddlLeaveType" runat="server">
                    <asp:ListItem Text="Select Leave Type" Value=""></asp:ListItem>
                    <asp:ListItem Text="Sick Leave" Value="Sick Leave"></asp:ListItem>
                    <asp:ListItem Text="Casual Leave" Value="Casual Leave"></asp:ListItem>
                    <asp:ListItem Text="Earned Leave" Value="Earned Leave"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvLeaveType" runat="server" ControlToValidate="ddlLeaveType" 
                    ErrorMessage="Please select leave type." CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label>Select Leave Date (Academic Calendar):</label>
                <div class="calendar-container">
                    <asp:Calendar ID="calLeaveDate" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="calLeaveDate_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </div>
                <p>Selected Date: <asp:Label ID="lblSelectedDate" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label></p>
            </div>
            
            <div class="form-group">
                <label>Reason for Leave:</label>
                <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>

            <asp:Button ID="btnApply" runat="server" Text="Apply Leave" CssClass="btn" OnClick="btnApply_Click" />
        </div>
    </form>
</body>
</html>
