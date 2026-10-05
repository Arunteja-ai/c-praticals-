<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveStatus.aspx.cs" Inherits="LeaveStatus" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Application Status</title>
    <style>
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background-color: #f0f2f5; margin: 0; padding: 20px; display: flex; justify-content: center; align-items: center; height: 100vh; }
        .status-card { background: white; padding: 40px; border-radius: 8px; box-shadow: 0 4px 8px rgba(0,0,0,0.1); max-width: 500px; width: 100%; }
        h2 { color: #17a2b8; text-align: center; border-bottom: 2px solid #17a2b8; padding-bottom: 10px; }
        .details p { font-size: 1.1em; color: #333; margin: 10px 0; }
        .details strong { color: #555; display: inline-block; width: 150px; }
        .btn-back { display: block; text-align: center; margin-top: 25px; padding: 12px; background-color: #6c757d; color: white; text-decoration: none; border-radius: 4px; }
        .btn-back:hover { background-color: #5a6268; }
        .success-msg { text-align: center; color: green; font-weight: bold; margin-bottom: 20px; font-size: 1.2em; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="status-card">
            <h2>Application Summary</h2>
            <div class="success-msg">Your leave application has been submitted successfully!</div>
            
            <div class="details">
                <p><strong>Employee Name:</strong> <asp:Label ID="lblName" runat="server"></asp:Label></p>
                <p><strong>Leave Type:</strong> <asp:Label ID="lblType" runat="server"></asp:Label></p>
                <p><strong>Leave Date:</strong> <asp:Label ID="lblDate" runat="server"></asp:Label></p>
                <p><strong>Reason:</strong> <asp:Label ID="lblReason" runat="server"></asp:Label></p>
            </div>

            <a href="Default.aspx" class="btn-back">Apply for Another Leave</a>
        </div>
    </form>
</body>
</html>
