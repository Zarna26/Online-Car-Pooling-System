<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CarPoolingProject.Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet" />
    <title>GoMate - Home</title>
    <link href="global.css" rel="stylesheet" />
    <link href="home.css" rel="stylesheet" />
    <style>
        /* Popup styles */
        .popup-overlay {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.6);
            z-index: 1000;
            backdrop-filter: blur(5px); /* Adds a blur effect to the background */
        }

        .popup-content {
            position: fixed;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background: linear-gradient(135deg, #fff, #f8f9fa);
            border-radius: 12px;
            box-shadow: 0 8px 20px rgba(0, 0, 0, 0.2);
            z-index: 1001;
            width: 90%;
            max-width: 600px;
            padding: 30px;
            animation: popup-show 0.3s ease-out;
        }

        @keyframes popup-show {
            from {
                transform: translate(-50%, -60%);
                opacity: 0;
            }
            to {
                transform: translate(-50%, -50%);
                opacity: 1;
            }
        }

        .popup-header {
            font-size: 1.8rem;
            font-weight: bold;
            color: #333;
            text-align: center;
            margin-bottom: 20px;
        }

        .popup-close {
            position: absolute;
            top: 15px;
            right: 15px;
            font-size: 1.5rem;
            background: none;
            border: none;
            color: #333;
            cursor: pointer;
        }

        .popup-close:hover {
            color: #e74c3c;
        }

        .popup-content label {
            display: block;
            font-size: 1rem;
            color: #444;
            margin-bottom: 5px;
        }

        .popup-content input[type="text"],
        .popup-content input[type="date"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ddd;
            border-radius: 6px;
            font-size: 1rem;
        }

        .popup-content input[type="text"]:focus,
        .popup-content input[type="date"]:focus {
            border-color: #007bff;
            outline: none;
            box-shadow: 0 0 4px rgba(0, 123, 255, 0.6);
        }

        .popup-content .btn-search {
            display: block;
            width: 100%;
            padding: 12px 0;
            background-color: #28a745;
            color: #fff;
            font-size: 1.1rem;
            font-weight: bold;
            text-align: center;
            border: none;
            border-radius: 6px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .popup-content .btn-search:hover {
            background-color: #218838;
        }

        .popup-content .form-group {
            display: flex;
            justify-content: space-between;
            gap: 15px;
        }

        .popup-content .form-group .input-half {
            flex: 1;
        }

        /* Popup for Post Ride */
.popup-content-post {
    position: fixed;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    background: linear-gradient(135deg, #fff, #f8f9fa);
    border-radius: 12px;
    box-shadow: 0 8px 20px rgba(0, 0, 0, 0.2);
    z-index: 1001;
    width: 90%;
    max-width: 600px;
    padding: 30px;
    animation: popup-show 0.3s ease-out;
}

.popup-content-post label {
    display: block;
    font-size: 1rem;
    color: #444;
    margin-bottom: 5px;
}

.popup-content-post input[type="text"],
.popup-content-post input[type="date"],
.popup-content-post input[type="time"] {
    width: 100%;
    padding: 10px;
    margin-bottom: 15px;
    border: 1px solid #ddd;
    border-radius: 6px;
    font-size: 1rem;
}

.popup-content-post input[type="text"]:focus,
.popup-content-post input[type="date"]:focus,
.popup-content-post input[type="time"]:focus {
    border-color: #007bff;
    outline: none;
    box-shadow: 0 0 4px rgba(0, 123, 255, 0.6);
}

.popup-content-post .btn-post {
    display: block;
    width: 100%;
    padding: 12px 0;
    background-color: #007bff;
    color: #fff;
    font-size: 1.1rem;
    font-weight: bold;
    text-align: center;
    border: none;
    border-radius: 6px;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

.popup-content-post .btn-post:hover {
    background-color: #0056b3;
}

.popup-content-post .form-group {
    display: flex;
    justify-content: space-between;
    gap: 15px;
}

.popup-content-post .form-group .input-half {
    flex: 1;
}

/* Common Popup Overlay */
.popup-overlay {
    display: none;
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.6);
    z-index: 1000;
    backdrop-filter: blur(5px);
}



    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Header Section -->
        <div class="header">
            <div class="navbar">
                <div class="menu">
                    <div class="logo">
                        <img src="/images/logo.png" alt="GoMate Logo" />
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
            <asp:Button ID="btnFindRide" Text="Find a Ride" CssClass="btn-primary" OnClientClick="openPopup(); return false;" runat="server" />
            <asp:Button ID="btnPostRide" Text="Post a Ride" CssClass="btn-secondary" OnClientClick="openPostRidePopup(); return false;" runat="server" />
        </div>

        <!-- Popup -->
        <div id="findRidePopup" class="popup-overlay">
            <div class="popup-content">
                <button class="popup-close" onclick="closePopup();">&times;</button>
                <div class="popup-header">Find a Ride</div>
                <p>Enter your pickup and destination details to find a ride:</p>

                <!-- Form -->
                <div>
                    <div class="form-group">
                        <div class="input-half">
                            <label for="departureCity">City of Departure:</label>
                            <input type="text" id="departureCity" placeholder="Enter departure city" />
                        </div>
                        <div class="input-half">
                            <label for="arrivalCity">City of Arrival:</label>
                            <input type="text" id="arrivalCity" placeholder="Enter arrival city" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="input-half">
                            <label for="departureDate">Date:</label>
                            <input type="date" id="departureDate" />
                        </div>
                        <div class="input-half">
                            <label for="returnDate">Return Date:</label>
                            <input type="date" id="returnDate" />
                        </div>
                    </div>

                    <div>
                        <label for="passengers">Number of Passengers:</label>
                        <input type="text" id="passengers" placeholder="Enter number of passengers" />
                    </div>

                    <button type="button" class="btn-search">Search</button>
                </div>
            </div>
        </div>

        <!-- Popup for Post a Ride -->
<div id="postRidePopup" class="popup-overlay">
    <div class="popup-content-post">
        <button class="popup-close" onclick="closePostRidePopup();">&times;</button>
        <div class="popup-header">Post a Ride</div>
        <p>Provide the details for the ride you want to post:</p>

        <!-- Form -->
        <div>
            <div class="form-group">
                <div class="input-half">
                    <label for="departureCityPost">City of Departure:</label>
                    <input type="text" id="departureCityPost" placeholder="Enter departure city" />
                </div>
                <div class="input-half">
                    <label for="arrivalCityPost">City of Arrival:</label>
                    <input type="text" id="arrivalCityPost" placeholder="Enter arrival city" />
                </div>
            </div>

            <div class="form-group">
                <div class="input-half">
                    <label for="departureDatePost">Date:</label>
                    <input type="date" id="departureDatePost" />
                </div>
                <div class="input-half">
                    <label for="departureTime">Time:</label>
                    <input type="time" id="departureTime" />
                </div>
            </div>

            <div class="form-group">
                <div class="input-half">
                    <label for="seatsAvailable">Seats Available:</label>
                    <input type="text" id="seatsAvailable" placeholder="Enter number of seats" />
                </div>
                <div class="input-half">
                    <label for="ridePrice">Price per Seat:</label>
                    <input type="text" id="ridePrice" placeholder="Enter price in USD" />
                </div>
            </div>

            <div>
                <label for="rideDescription">Additional Information:</label>
                <input type="text" id="rideDescription" placeholder="Enter any additional details (optional)" />
            </div>

            <button type="button" class="btn-post">Post Ride</button>
        </div>
    </div>
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

    <!-- JavaScript -->
    <script>
        function openPopup() {
            document.getElementById('findRidePopup').style.display = 'block';
        }

        function closePopup() {
            document.getElementById('findRidePopup').style.display = 'none';
        }
        function openPostRidePopup() {
            document.getElementById('postRidePopup').style.display = 'block';
        }

        function closePostRidePopup() {
            document.getElementById('postRidePopup').style.display = 'none';
        }

    </script>

</body>
</html>
