<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Event Registration Portal</title>
    <style>
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background-color: #f4f7f6; margin: 0; padding: 20px; }
        .container { max-width: 600px; margin: 0 auto; background: white; padding: 30px; border-radius: 8px; box-shadow: 0 4px 8px rgba(0,0,0,0.1); }
        h2 { text-align: center; color: #333; }
        .form-group { margin-bottom: 15px; }
        label { display: block; margin-bottom: 5px; font-weight: bold; color: #555; }
        input[type="text"], input[type="password"], select { width: 100%; padding: 10px; border: 1px solid #ccc; border-radius: 4px; box-sizing: border-box; }
        .btn { width: 100%; padding: 12px; background-color: #007bff; color: white; border: none; border-radius: 4px; cursor: pointer; font-size: 16px; margin-top: 10px; }
        .btn:hover { background-color: #0056b3; }
        .error { color: red; font-size: 0.9em; margin-top: 5px; display: block; }
        .summary { color: red; margin-bottom: 15px; font-weight: bold; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Tech Conference 2026 Registration</h2>
            
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="summary" HeaderText="Please fix the following errors:" />

            <div class="form-group">
                <label>Full Name:</label>
                <asp:TextBox ID="txtName" runat="server" Placeholder="Enter your full name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" 
                    ErrorMessage="Name is required." CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label>Email Address:</label>
                <asp:TextBox ID="txtEmail" runat="server" Placeholder="Enter your email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" 
                    ErrorMessage="Email is required." CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" 
                    ErrorMessage="Invalid email format." CssClass="error" Display="Dynamic" 
                    ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <label>Age:</label>
                <asp:TextBox ID="txtAge" runat="server" Placeholder="Enter your age"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAge" runat="server" ControlToValidate="txtAge" 
                    ErrorMessage="Age is required." CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvAge" runat="server" ControlToValidate="txtAge" 
                    ErrorMessage="Age must be between 18 and 99." CssClass="error" Display="Dynamic" 
                    MinimumValue="18" MaximumValue="99" Type="Integer"></asp:RangeValidator>
            </div>

            <div class="form-group">
                <label>Event Type:</label>
                <asp:DropDownList ID="ddlEventType" runat="server">
                    <asp:ListItem Text="Select Event" Value=""></asp:ListItem>
                    <asp:ListItem Text="Web Development" Value="Web"></asp:ListItem>
                    <asp:ListItem Text="Artificial Intelligence" Value="AI"></asp:ListItem>
                    <asp:ListItem Text="Cyber Security" Value="Security"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvEventType" runat="server" ControlToValidate="ddlEventType" 
                    ErrorMessage="Please select an event type." CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <label>Password (for portal access):</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Enter password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" 
                    ErrorMessage="Password is required." CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label>Confirm Password:</label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Placeholder="Confirm password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" 
                    ErrorMessage="Confirm password is required." CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvPassword" runat="server" ControlToValidate="txtConfirmPassword" 
                    ControlToCompare="txtPassword" ErrorMessage="Passwords do not match." CssClass="error" Display="Dynamic"></asp:CompareValidator>
            </div>

            <asp:Button ID="btnRegister" runat="server" Text="Register Now" CssClass="btn" OnClick="btnRegister_Click" />
        </div>
    </form>
</body>
</html>
