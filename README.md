# CodeGround

A free learning platform for beginner programmers. I built it to teach Python and Java to students who have never coded before.

Live site: http://codeground.runasp.net

## What it does

Two courses, Python and Java. Each course has:

- Lessons with explanations and code examples
- A short quiz after each lesson (optional)
- A final project at the end
- A dashboard to track what you've completed

Users can register, leave comments, and like lessons.

## Try it

You can test it without signing up:

Email: demo@codeground.com
Password: demo1234

If you want to see the admin side, email me at Sthembisovusmuzi@gmail.com and I'll give you access.

## Built with

- ASP.NET Web Forms (.NET Framework 4.8)
- C#
- Entity Framework 6 (Code First)
- SQL Server
- Bootstrap 5
- Prism.js for code highlighting

Email sending is done through Gmail SMTP.

## How to run it locally

1. Open the solution in Visual Studio 2019 or 2022
2. Restore NuGet packages
3. Update the connection string in Web.config if needed
4. Run `Update-Database` in Package Manager Console
5. Press F5

## Project layout

- Models/ — database models
- Migrations/ — EF migrations and seed data
- Content/, Scripts/ — styles and JS
- Admin/ — admin pages
- Default.aspx, Courses.aspx, Lesson.aspx etc — main pages

## About me

I'm Sthembiso, a Computer Science student at UKZN in Durban. I built this because most beginner tutorials jump straight into syntax without explaining the why. CodeGround tries to slow that down.

- Email: Sthembisovusmuzi@gmail.com
- GitHub: https://github.com/Stheambiso2025
