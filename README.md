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

To securely store your MongoDB connection string, use the .NET Secrets Manager. Follow these steps:

1. **Initialize the Secrets Manager**  
   Navigate to the project directory and initialize the secrets manager (if not already done):
   ```bash
   dotnet user-secrets init
   ```

2. **Add the MongoDB Connection String**  
   Use the following command to add your MongoDB connection string to the secrets manager:
   ```bash
   dotnet user-secrets set "MongoDB:ConnectionString" "mongodb+srv://<username>:<password>@<cluster-url>/?retryWrites=true&w=majority&appName=<app-name>"
   ```
   Replace the placeholders:
   - `<username>`: Your MongoDB username.
   - `<password>`: Your MongoDB password.
   - `<cluster-url>`: Your MongoDB cluster URL.
   - `<app-name>`: The name of your application.

   Example:
   ```bash
   dotnet user-secrets set "MongoDB:ConnectionString" "mongodb+srv://username:verysecuresecret@devlinsclusterheadache.mongodb.net/?retryWrites=true&w=majority&appName=DevlinsCluster0"
   ```

3. **Verify the Secrets**  
   To confirm that the connection string has been added, run:
   ```bash
   dotnet user-secrets list
   ```
   You should see:
   ```
   MongoDB:ConnectionString = mongodb+srv://<username>:<password>@<cluster-url>/?retryWrites=true&w=majority&appName=<app-name>
   ```

4. **Ensure Your Application Uses the Secrets Manager**  
   The application is already configured to retrieve the connection string from the secrets manager in `Program.cs`:
   ```csharp
   builder.Services.Configure<MongoDbSettings>(options =>
   {
       options.ConnectionString = builder.Configuration["MongoDB:ConnectionString"];
       options.DatabaseName = builder.Configuration["MongoDB:DatabaseName"];
   });
   ```

By following these steps, your MongoDB connection string will be securely stored and retrieved at runtime without exposing it in your source code.
