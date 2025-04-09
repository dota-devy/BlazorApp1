# BlazorApp1

BlazorApp1 is a test sandbox project created to explore and experiment with using GitHub Copilot to scaffold a Blazor application that integrates FIDO2 authentication.

## Purpose

The purpose of this project is to:
- Test the capabilities of GitHub Copilot in generating and scaffolding Blazor applications.
- Implement and experiment with FIDO2 authentication for secure, passwordless login functionality.
- Serve as a learning tool for integrating modern authentication mechanisms into Blazor applications.

## Features

- **Blazor Framework**: Built using Blazor for interactive web applications.
- **FIDO2 Authentication**: Implements FIDO2 for secure, passwordless authentication.
- **GitHub Copilot**: Utilizes GitHub Copilot to scaffold and assist in the development process.

## Project Structure

The project follows a standard Blazor application structure:
- `Components/`: Contains reusable Blazor components.
- `Pages/`: Contains the main pages of the application, including the Account page.
- `wwwroot/`: Contains static assets such as CSS and JavaScript files.
- `Program.cs`: Configures services and middleware for the application.

## How to Run

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd BlazorApp1
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Build the solution:
   ```bash
   dotnet build
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Open your browser and navigate to:
   ```
   https://localhost:5001
   ```

## Setting Up MongoDB Connection String with Secrets Manager

To securely store the MongoDB connection string, use the .NET Secrets Manager. Follow these steps:

1. **Initialize the Secrets Manager**:
   Navigate to the project directory and initialize the secrets manager (if not already done):
   ```bash
   dotnet user-secrets init
   ```
