<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MyCode.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8 text-center">
                
                <h1 class="mb-3">Contact Me</h1>
                <p class="text-muted mb-5 fs-5">
                    Got a question, a suggestion, or just want to say hi? Reach out below.
                </p>

                <div class="row g-4 text-start">
                    
                    <div class="col-md-12">
                        <div class="card shadow-sm border-0">
                            <div class="card-body p-4 d-flex align-items-center">
                                <div class="fs-1 me-4">📧</div>
                                <div>
                                    <h5 class="mb-1">Email</h5>
                                    <a href="mailto:Sthembisovusmuzi@gmail.com" class="fs-5">
                                        Sthembisovusmuzi@gmail.com
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="card shadow-sm border-0">
                            <div class="card-body p-4 d-flex align-items-center">
                                <div class="fs-1 me-4">🐙</div>
                                <div>
                                    <h5 class="mb-1">GitHub</h5>
                                    <a href="https://github.com/Stheambiso2025" target="_blank" class="fs-5">
                                        github.com/Stheambiso2025
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="card shadow-sm border-0">
                            <div class="card-body p-4 d-flex align-items-center">
                                <div class="fs-1 me-4">📍</div>
                                <div>
                                    <h5 class="mb-1">Location</h5>
                                    <p class="mb-0 fs-5">Durban, South Africa</p>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <!-- Live Google Map -->
                <h4 class="mt-5 mb-3">🗺️ Find Durban on the Map</h4>
                <div class="card shadow-sm border-0 overflow-hidden">
                    <iframe 
                        src="https://www.google.com/maps?q=Durban,South+Africa&output=embed"
                        width="100%" 
                        height="400" 
                        style="border:0;" 
                        allowfullscreen="" 
                        loading="lazy">
                    </iframe>
                </div>

                <div class="alert alert-info mt-5 text-start">
                    💬 Have feedback about a lesson? Feel free to leave a comment directly on the lesson page!
                </div>

            </div>
        </div>
    </div>
</asp:Content>