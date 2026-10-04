# setup_solution.ps1
# 1. Create Directory Hierarchy
New-Item -ItemType Directory -Force -Path "src/Services"
New-Item -ItemType Directory -Force -Path "src/Web"
New-Item -ItemType Directory -Force -Path "src/Common"
New-Item -ItemType Directory -Force -Path "tests"

# 2. Create Solution
dotnet new sln -n CustomerFeedbackSystem

# 3. Create Projects

# Identity API
dotnet new webapi -n Identity.API -o src/Services/Identity/Identity.API
dotnet sln add src/Services/Identity/Identity.API/Identity.API.csproj

# Feedback API
dotnet new webapi -n Feedback.API -o src/Services/Feedback/Feedback.API
dotnet sln add src/Services/Feedback/Feedback.API/Feedback.API.csproj

# Reporting API
dotnet new webapi -n Reporting.API -o src/Services/Reporting/Reporting.API
dotnet sln add src/Services/Reporting/Reporting.API/Reporting.API.csproj

# Infrastructure Messaging (Class Library)
dotnet new classlib -n Infrastructure.Messaging -o src/Common/Infrastructure.Messaging
dotnet sln add src/Common/Infrastructure.Messaging/Infrastructure.Messaging.csproj

# Unit Tests
dotnet new xunit -n UnitTests -o tests/UnitTests
dotnet sln add tests/UnitTests/UnitTests.csproj

# 4. Add Project References (Example: Feedback references Infrastructure)
dotnet add src/Services/Feedback/Feedback.API/Feedback.API.csproj reference src/Common/Infrastructure.Messaging/Infrastructure.Messaging.csproj

# 5. Add Nuget Packages (Common ones requested)
# Note: We are running this for Feedback.API as per request specifics
dotnet add src/Services/Feedback/Feedback.API/Feedback.API.csproj package Microsoft.EntityFrameworkCore.SqlServer
dotnet add src/Services/Feedback/Feedback.API/Feedback.API.csproj package Microsoft.EntityFrameworkCore.Design
dotnet add src/Services/Feedback/Feedback.API/Feedback.API.csproj package Serilog.AspNetCore
dotnet add src/Services/Feedback/Feedback.API/Feedback.API.csproj package FluentValidation.AspNetCore
dotnet add src/Services/Feedback/Feedback.API/Feedback.API.csproj package Swashbuckle.AspNetCore
dotnet add src/Services/Feedback/Feedback.API/Feedback.API.csproj package Microsoft.AspNetCore.Authentication.JwtBearer

Write-Host "Solution scaffolding complete!"
