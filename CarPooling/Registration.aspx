<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="CarPoolingProject.Registration" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register - Online Car Pooling System</title>
    <link href="global.css" rel="stylesheet" />
    <link href="Registration.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <!-- Registration Box -->
        <div class="registrationbox">
            <img src="/images/login.png" alt="User Icon" class="user" />
            <h2>Register on GoMate</h2>
            <form id="form1" runat="server">
                <!-- Full Name -->
                <asp:Label Text="Full Name" CssClass="lblname" runat="server" />
                <asp:TextBox ID="txtName" runat="server" CssClass="txtname" placeholder="Enter Full Name" />
                <br />
                <!-- Email -->
                <asp:Label Text="Email" CssClass="lblemail" runat="server" />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="txtemail" placeholder="Enter Email" />
                <br />
                <!-- Password -->
                <asp:Label Text="Password" CssClass="lblpass" runat="server" />
                <asp:TextBox ID="txtPassword" runat="server" CssClass="txtpass" placeholder="********" TextMode="Password" />
                <br />
                <!-- Phone Number -->
                <asp:Label Text="Phone Number" CssClass="lblphone" runat="server" />
                <asp:TextBox ID="txtPhone" runat="server" CssClass="txtphone" placeholder="Enter Phone Number" />
                <br />
                <!-- Register Button -->
                <asp:Button ID="btnRegister" Text="Register" CssClass="btnregister" runat="server" OnClick="btnRegister_Click" />
                <br />
                <!-- Message Label -->
                <asp:Label ID="lblMessage" CssClass="lblMessage" runat="server" Visible="false"></asp:Label>
                
                <br />
                Already have an account? 
                <asp:LinkButton Text="Log In" PostBackUrl="~/Login.aspx" CssClass="btnlogin" runat="server" />
            </form>
        </div>

        <!-- Heading -->
        <div class="heading">
            <h1>Join GoMate Today</h1>
            <p>Start sharing your rides and making your travel eco-friendly.</p>
        </div>
    </div>
</body>
</html>
