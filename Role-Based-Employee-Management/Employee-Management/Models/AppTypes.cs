namespace Employee_Management.Models;

/// <summary>
/// Enum for role types in the application
/// </summary>
public enum RoleKey
{
    Admin,
    Manager,
    Employee
}

/// <summary>
/// Represents an employee in the system
/// </summary>
public class Employee
{
    public string? Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Department { get; set; }
    public RoleKey Role { get; set; }
    public string? Title { get; set; }
    public decimal Salary { get; set; }
    public bool Active { get; set; }
    public DateTime JoinDate { get; set; }
    public int Rating { get; set; }
    public string? Contact { get; set; }
}

/// <summary>
/// Represents a user account in the system
/// </summary>
public class UserAccount
{
    public RoleKey Role { get; set; }
    public string? UserId { get; set; }
}

/// <summary>
/// Represents a demo account with password
/// </summary>
public class DemoAccount : UserAccount
{
    public string? Password { get; set; }
}

/// <summary>
/// Represents role-based permissions and column visibility
/// </summary>
public class RolePermissions
{
    public bool CanEdit { get; set; }
    public bool CanAdd { get; set; }
    public bool CanDelete { get; set; }
    public List<string> VisibleColumns { get; set; } = new();
}

/// <summary>
/// Login credentials for authentication
/// </summary>
public class LoginCredentials
{
    public string? UserId { get; set; }
    public string? Password { get; set; }
}

/// <summary>
/// Response model for login attempts
/// </summary>
public class LoginResponse
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public UserAccount? User { get; set; }
}
