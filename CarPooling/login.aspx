<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CarPoolingProject.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Online Car Pooling System</title>
    <link href="global.css" rel="stylesheet"/>
    <link href="login.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <!-- Login Box -->
        <div class="loginbox">
            <img src="/images/login.png" alt="User Icon" class="user" />
            <h2>Log in to GoMate</h2>
            <form id="form1" runat="server">
                <asp:Label Text="Email" CssClass="lblemail" runat="server" />
                <asp:TextBox ID="txtemail" runat="server" CssClass="txtemail" placeholder="Enter Email" />
                <asp:Label Text="Password" CssClass="lblpass" runat="server" />
                <asp:TextBox ID="txtpass" runat="server" CssClass="txtpass" placeholder="********" TextMode="Password" />
                <asp:LinkButton Text="Forgot Password?" CssClass="btnforget" runat="server" OnClick="btnforget_Click" />
                <br />
                <br />
                <asp:Button ID="btnsubmit" Text="Log In" CssClass="btnsubmit" runat="server" OnClick="btnsubmit_Click" />
                <br />
                <br />
                Don't have an account? 
                <asp:LinkButton Text="Click Here to Register" PostBackUrl="~/Registration.aspx" CssClass="btnregister" runat="server" />
                <br />
                <asp:Label ID="lblError" CssClass="lblError" runat="server" Visible="false" />
            </form>
        </div>

        <!-- Heading -->
        <div class="heading">
            <h1>Find Your Ride, Share Your Journey</h1>
            <p>Connect with drivers and riders to share travel costs and reduce your carbon footprint.</p>
        </div>
    </div>
</body>
</html>
