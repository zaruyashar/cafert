# ☕ The CAFERT 

This is Project #1 of the SoftITo Backend Development program. It is a dynamic web application built for a cafe, featuring a public-facing landing page and an admin dashboard to easily manage menu items, featured dishes, and team members. The admin dashboard is secured with ASP.NET Core Identity: registration, login, and session management, an authenticated account area with in-session password change and email-inclusive profile editing, and a token-based forgot-password flow (no outbound email service — the reset token is displayed on-screen for demo purposes). The public landing page and admin dashboard stay cleanly separated: login opens the dashboard in a new tab, and all account/session actions live in a profile dropdown inside the dashboard rather than the public site.


## Tech Stack

* C# .NET Core MVC
* Entity Framework Core
* MS SQL Server
* ASP.NET Core Identity (EF Core store, cookie-based authentication, account lockout policy, token-based password reset)


## Screenshots

### Landing Page - Hero Section
<img width="3026" height="1917" alt="1" src="https://github.com/user-attachments/assets/445cd8bb-38f0-4f66-a5d3-2bb03d46a1c6" />

### Landing Page - Our Philosophy
<img width="3035" height="1917" alt="2" src="https://github.com/user-attachments/assets/a6cbbc7e-27a5-4fae-8bf7-0ea15072a0e9" />

### Landing Page - Our Specialties
<img width="3028" height="1917" alt="3" src="https://github.com/user-attachments/assets/ced8cc55-2332-4b57-9536-884f93dc15cb" />

### Landing Page - Featured Dishes
<img width="3035" height="1917" alt="4" src="https://github.com/user-attachments/assets/9ae2ab2d-6292-46e1-8b1e-4f65307394e1" />

### Landing Page - Team Members
<img width="3033" height="1917" alt="5" src="https://github.com/user-attachments/assets/78d7affc-0994-4823-b153-cc91bbfccccc" />

### Admin Dashboard - Control Panel Overview
<img width="3069" height="1917" alt="6" src="https://github.com/user-attachments/assets/3c72f6aa-fcf9-42a3-a4ef-7c6e63f5f5cd" />

### Admin Dashboard - Team Management
<img width="3069" height="1917" alt="7" src="https://github.com/user-attachments/assets/f13db561-8dcd-414d-ab95-c364a66e4f40" />

### Admin Dashboard - Add New Team Member
<img width="3028" height="1914" alt="8" src="https://github.com/user-attachments/assets/fa4278d2-4e71-4775-bc1b-194d7d4ccc01" />

### Admin Dashboard - Menu Items Management
<img width="3035" height="1917" alt="9" src="https://github.com/user-attachments/assets/d51f4b4f-402c-4615-9944-dd9ca15f6cb4" />

### Identity/Auth Integration
<img width="3069" height="1917" alt="x" src="https://github.com/user-attachments/assets/dd5116de-2dca-41fc-b353-235b2911504e" />
<img width="3069" height="1917" alt="y" src="https://github.com/user-attachments/assets/2b837809-afd3-4f52-b37d-b03549a9837e" />
<img width="3069" height="1917" alt="z" src="https://github.com/user-attachments/assets/de5c4c71-2073-4220-9920-8fe55e7d7ec4" />
