<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CarPoolingProject.Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GoMate - Home</title>
    <link href="global.css" rel="stylesheet" />
    <link href="home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Header Section -->
        <div class="header">
            
            <div class="navbar">
    <div class="menu">
        <div class="logo">
    <img src="/images/logo.png" alt="GoMate Logo"/>
    
</div>
        <a href="home.aspx">Home</a>
        <a href="about.aspx">About</a>
        <a href="features.aspx">Features</a>
        <a href="contact.aspx">Contact</a>
    </div>
    <div class="auth">
        <a href="register.aspx">Register</a>
        <a href="login.aspx">Login</a>
    </div>
</div>
        </div>

        <!-- Hero Section -->
        <div class="hero">
            <h1>Find Your Ride, Share Your Journey</h1>
            <p>Save money, reduce your carbon footprint, and connect with others on the go.</p>
            <asp:Button ID="btnFindRide" Text="Find a Ride" CssClass="btn-primary" runat="server" />
            <asp:Button ID="btnPostRide" Text="Post a Ride" CssClass="btn-secondary" runat="server" />
        </div>

        <!-- Features Section -->
        <div class="features">
            <h2>Why Choose GoMate?</h2>
            <div class="feature-box">
                <div class="feature">
                    <img src="/images/eco-friendly.png" alt="Eco-Friendly" />
                    <h3>Eco-Friendly</h3>
                    <p>Reduce your carbon footprint by sharing rides.</p>
                </div>
                <div class="feature">
                    <img src="/images/cost-saving.png" alt="Cost Saving" />
                    <h3>Cost Saving</h3>
                    <p>Save money by sharing travel expenses.</p>
                </div>
                <div class="feature">
                    <img src="/images/real-time-tracking.png" alt="Real-Time Tracking" />
                    <h3>Real-Time Tracking</h3>
                    <p>Track your ride in real-time for added safety.</p>
                </div>
            </div>
        </div>

        <!-- Footer Section -->
        <div class="footer">
            <p>&copy; 2025 GoMate. All rights reserved.</p>
            <ul>
                <li><a href="PrivacyPolicy.aspx">Privacy Policy</a></li>
                <li><a href="Terms.aspx">Terms of Service</a></li>
                <li><a href="Contact.aspx">Contact Us</a></li>
            </ul>
        </div>
    </form>
</body>
</html>
