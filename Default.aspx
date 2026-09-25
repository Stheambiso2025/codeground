<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyCode._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Hero Section -->
    <section class="hero-section text-white text-center">
        <div class="container py-5">
            <h1 class="display-4 fw-bold mb-3">Learn Programming. For Free.</h1>
            <p class="lead mb-4">
                Master Python and Java with simple notes, real code examples, and hands-on exercises.
                No payment. No certificate. Just pure learning.
            </p>
            <a href="Register.aspx" class="btn btn-warning btn-lg me-2">Get Started Free</a>
            <a href="Courses.aspx" class="btn btn-outline-light btn-lg">Browse Courses</a>
        </div>
    </section>

    <!-- Features -->
    <section class="py-5">
        <div class="container">
            <h2 class="text-center mb-5">Why CodeGround?</h2>
            <div class="row g-4">
                <div class="col-md-4">
                    <div class="card h-100 shadow-sm border-0">
                        <div class="card-body text-center">
                            <div class="display-6 mb-3">🐍</div>
                            <h5 class="card-title">Python Basics</h5>
                            <p class="card-text">Start from zero. Learn variables, loops, functions and build your first program.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card h-100 shadow-sm border-0">
                        <div class="card-body text-center">
                            <div class="display-6 mb-3">☕</div>
                            <h5 class="card-title">Java Fundamentals</h5>
                            <p class="card-text">Understand object-oriented programming the right way with clear, simple lessons.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card h-100 shadow-sm border-0">
                        <div class="card-body text-center">
                            <div class="display-6 mb-3">💬</div>
                            <h5 class="card-title">Learn Together</h5>
                            <p class="card-text">Comment on lessons, ask questions, and track your progress as you go.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Courses Preview -->
    <section class="bg-light py-5">
        <div class="container">
            <h2 class="text-center mb-5">Choose Your Language</h2>
            <div class="row g-4 justify-content-center">
                <div class="col-md-5">
                    <div class="card shadow-sm border-0">
                        <div class="card-body">
                            <h4>🐍 Python</h4>
                            <p>Perfect for beginners. Simple syntax, powerful results.</p>
                            <ul>
                                <li>Introduction & Setup</li>
                                <li>Variables, Loops, Functions</li>
                                <li>Mini projects</li>
                            </ul>
                            <a href="Courses.aspx" class="btn btn-primary">Start Python</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="card shadow-sm border-0">
                        <div class="card-body">
                            <h4>☕ Java</h4>
                            <p>Learn strong programming fundamentals used in real jobs.</p>
                            <ul>
                                <li>Introduction & Setup</li>
                                <li>OOP: Classes & Objects</li>
                                <li>Data structures</li>
                            </ul>
                            <a href="Courses.aspx" class="btn btn-primary">Start Java</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Call To Action -->
    <section class="py-5 text-center">
        <div class="container">
            <h3 class="mb-3">Ready to start coding?</h3>
            <p class="mb-4">Register with your email and begin your first lesson in minutes.</p>
            <a href="Register.aspx" class="btn btn-success btn-lg">Create Free Account</a>
        </div>
    </section>

</asp:Content>