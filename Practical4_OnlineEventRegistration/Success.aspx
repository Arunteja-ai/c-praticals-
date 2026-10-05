<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Success.aspx.cs" Inherits="Success" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Successful</title>
    <style>
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background-color: #d4edda; margin: 0; padding: 20px; display: flex; justify-content: center; align-items: center; height: 100vh; }
        .success-card { background: white; padding: 40px; border-radius: 8px; box-shadow: 0 4px 8px rgba(0,0,0,0.1); text-align: center; }
        h2 { color: #155724; }
        p { color: #333; font-size: 1.1em; }
        .btn-back { display: inline-block; margin-top: 20px; padding: 10px 20px; background-color: #28a745; color: white; text-decoration: none; border-radius: 4px; }
        .btn-back:hover { background-color: #218838; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="success-card">
            <h2>Registration Successful!</h2>
            <p>Thank you, <asp:Label ID="lblName" runat="server" Font-Bold="true"></asp:Label>, for registering for the event.</p>
            <p>We have sent a confirmation email to your registered email address.</p>
            <a href="Default.aspx" class="btn-back">Back to Home</a>
        </div>
    </form>
</body>
</html>
