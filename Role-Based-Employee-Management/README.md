# Employee Management Portal

A role-based employee management system built with **Blazor** and **Syncfusion** components. This application provides different access levels and features based on user roles.

## 🎯 Project Overview

The **Employee Management Portal** is a web application that allows organizations to manage employee information with role-based access control. Different users (Admin, Manager, Employee) have different permissions to view and edit employee data.

### Key Features
- 🔐 **Role-Based Access Control** - Different permissions for Admin, Manager, and Employee roles
- 📊 **Interactive Data Grid** - View, search, filter, and sort employee records
- ✏️ **Role-Specific Editing** - Only authorized roles can add, edit, or delete employees
- 🎨 **Modern UI** - Built with Syncfusion components for a professional look
- 👤 **User Authentication** - Secure login with demo accounts
- 📱 **Responsive Design** - Works on desktop and tablet devices

## 🏗️ Project Structure

```
Employee-Management/
├── Components/
│   ├── Pages/
│   │   ├── Home.razor          # Main landing page with login & grid
│   │   └── Login.razor         # User login component
│   ├── EmployeeGrid.razor      # Employee data grid component
│   ├── EmployeeGrid.razor.css  # Grid styling
│   ├── Navbar.razor            # Navigation bar
│   └── _Imports.razor          # Shared namespaces
├── Models/
│   └── AppTypes.cs             # Data models (Employee, UserAccount, etc.)
├── Services/
│   ├── GridConfigService.cs    # Role configuration and authentication
│   └── DataSourceService.cs    # Mock employee data generation
├── Program.cs                  # Application startup configuration
└── Employee-Management.csproj  # Project file
```

## 👥 User Roles & Permissions

### Admin
- ✅ View all employees
- ✅ Add new employees
- ✅ Edit all employee fields
- ✅ Delete employees
- ✅ See all columns

### Manager
- ✅ View all employees
- ✅ Edit only Rating and Contact fields
- ❌ Cannot add employees
- ❌ Cannot delete employees
- ✅ See most columns

### Employee
- ✅ View own information
- ❌ Cannot add employees
- ❌ Cannot edit any fields
- ❌ Cannot delete employees
- ✅ Limited column visibility

## 🛠️ Technology Stack

| Technology | Version | Purpose |
|-----------|---------|---------|
| **ASP.NET Core** | .NET 10.0 | Backend framework |
| **Blazor** | Latest | Interactive UI rendering |
| **Syncfusion** | 100.2.1 | UI components (Grid, Buttons, Inputs) |
| **C#** | Latest | Programming language |

## 🚀 Getting Started

### Prerequisites
- .NET SDK 10.0 or higher
- Visual Studio 2022 or VS Code

### Installation

1. **Clone or extract the project:**
   ```powershell
   cd Employee-Management
   ```

2. **Restore NuGet packages:**
   ```powershell
   dotnet restore
   ```

3. **Run the application:**
   ```powershell
   dotnet run
   ```

4. **Open in browser:**
   - Navigate to `https://localhost:5001` (or the port shown in terminal)

### Demo Login Credentials

The application includes demo accounts for testing:

| User ID | Password | Role |
|---------|----------|------|
| admin | admin123 | Admin |
| manager | manager123 | Manager |
| user | user123 | Employee |

## 📋 Employee Data Fields

Each employee record contains:
- **ID** - Unique identifier (read-only)
- **Name** - Full name (read-only)
- **Email** - Email address (read-only, clickable link)
- **Contact** - Phone number
- **Title** - Job title
- **Department** - Department name
- **Role** - Employee role
- **Join Date** - Hire date (read-only)
- **Status** - Active/Inactive (shown as colored chip)
- **Rating** - Employee rating (1-5 stars, manager-editable)
- **Salary** - Compensation (formatted as currency)

## 🔑 Key Components

### EmployeeGrid.razor
The main data grid component that displays employee information. It:
- Shows different columns based on user role
- Provides toolbar actions (Add, Edit, Delete, Search)
- Allows inline editing for permitted fields
- Displays custom templates for Status, Email, and Rating

### Login.razor
Authentication component that:
- Validates user credentials
- Sets the current user session
- Redirects to main dashboard after login

### GridConfigService.cs
Service that:
- Manages role-based permissions
- Handles user authentication
- Stores demo user accounts

### DataSourceService.cs
Service that:
- Generates mock employee data (100 records by default)
- Creates realistic names, emails, and phone numbers

## 🎨 UI Components Used

- **SfGrid** - Data table with sorting, filtering, and paging
- **SfButton** - Action buttons for login and toolbar
- **SfTextBox** - Text input fields for login
- **SfChip** - Status display (Active/Inactive)
- **SfRating** - Star rating display

## 📝 How to Use

1. **Login**: Enter your demo credentials
2. **View Employees**: Browse the employee grid with search and filter
3. **Sort/Filter**: Click column headers to sort or use filter menu
4. **Edit** (if authorized):
   - Click the "Edit" button in toolbar
   - Modify the row
   - Click "Update" to save
5. **Add** (if authorized):
   - Click "Add" button in toolbar
   - Fill in the new employee details
   - Click "Add" to save
6. **Delete** (if authorized):
   - Select an employee row
   - Click "Delete" button to remove

## 🔒 Security Notes

- This is a demo application with hardcoded demo accounts
- For production, implement real authentication (Azure AD, OAuth, etc.)
- Passwords should never be hardcoded
- Use a real database instead of mock data
- Implement proper authorization checks on the server

## 📚 Code Structure

### Models (AppTypes.cs)
- `Employee` - Employee data model
- `UserAccount` - User information
- `RolePermissions` - Role-based permissions
- `LoginCredentials` - Login input
- `LoginResponse` - Authentication result

### Services
- **GridConfigService**: Configuration and authentication logic
- **DataSourceService**: Mock data generation

### Components
- **Razor Components** (.razor files) for UI
- **CSS Modules** (.razor.css files) for component styling

## 🚧 Future Enhancements

- Integrate with a real database (SQL Server, PostgreSQL)
- Implement JWT token-based authentication
- Add export to Excel/PDF functionality
- Add employee profile details page
- Implement email notifications
- Add audit logging for all changes

## 📞 Support & Troubleshooting

### Common Issues

**Port already in use:**
```powershell
dotnet run --urls "https://localhost:5002"
```

**Package restore fails:**
```powershell
dotnet nuget locals all --clear
dotnet restore
```

**Syncfusion components not displaying:**
- Ensure Syncfusion.Blazor NuGet package is installed
- Check that `AddSyncfusionBlazor()` is called in Program.cs

## 📄 License

This is a sample project for demonstration purposes.

## 👨‍💻 Development Notes

- The application uses **Interactive Server** render mode for Blazor
- Grid data is mock data, not persisted
- Changes in the grid don't persist after page refresh
- All role logic is client-side for demonstration

---
