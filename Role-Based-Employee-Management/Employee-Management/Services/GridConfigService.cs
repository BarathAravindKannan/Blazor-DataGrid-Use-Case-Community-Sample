using Employee_Management.Models;

namespace Employee_Management.Services;

/// <summary>
/// Service that provides RBAC configuration, grid columns definition, and demo accounts
/// </summary>
public class GridConfigService
{
    /// <summary>
    /// Demo accounts for testing
    /// </summary>
    public static readonly List<DemoAccount> DemoAccounts = new()
    {
        new DemoAccount
        {
            Role = RoleKey.Admin,
            UserId = "lucas",
            Password = "sunset42"
        },
        new DemoAccount
        {
            Role = RoleKey.Manager,
            UserId = "mia",
            Password = "harbor78"
        },
        new DemoAccount
        {
            Role = RoleKey.Employee,
            UserId = "oliver",
            Password = "meadow25"
        }
    };

    /// <summary>
    /// Role-based configuration with permissions and visible columns
    /// </summary>
    public static readonly Dictionary<RoleKey, RolePermissions> RoleConfig = new()
    {
        {
            RoleKey.Admin,
            new RolePermissions
            {
                CanEdit = true,
                CanAdd = true,
                CanDelete = true,
                VisibleColumns = new List<string>
                {
                    "Id",
                    "FullName",
                    "Email",
                    "Department",
                    "Role",
                    "Title",
                    "Salary",
                    "Active",
                    "JoinDate",
                    "Contact"
                }
            }
        },
        {
            RoleKey.Manager,
            new RolePermissions
            {
                CanEdit = true,
                CanAdd = false,
                CanDelete = false,
                VisibleColumns = new List<string>
                {
                    "Id",
                    "FullName",
                    "Email",
                    "Department",
                    "Role",
                    "Title",
                    "Active",
                    "JoinDate",
                    "Rating",
                    "Contact"
                }
            }
        },
        {
            RoleKey.Employee,
            new RolePermissions
            {
                CanEdit = false,
                CanAdd = false,
                CanDelete = false,
                VisibleColumns = new List<string>
                {
                    "FullName",
                    "Email",
                    "Department",
                    "Title",
                    "Active",
                    "JoinDate",
                    "Contact"
                }
            }
        }
    };

    /// <summary>
    /// Get role configuration by role
    /// </summary>
    public static RolePermissions GetRoleConfig(RoleKey role)
    {
        return RoleConfig.TryGetValue(role, out var config)
            ? config
            : throw new KeyNotFoundException($"Role {role} not found in configuration");
    }

    /// <summary>
    /// Authenticate user with demo accounts
    /// </summary>
    public static LoginResponse AuthenticateUser(LoginCredentials credentials)
    {
        if (string.IsNullOrWhiteSpace(credentials.UserId) || string.IsNullOrWhiteSpace(credentials.Password))
        {
            return new LoginResponse
            {
                IsSuccess = false,
                Message = "User ID and Password are required"
            };
        }

        var account = DemoAccounts.FirstOrDefault(a =>
            a.UserId!.Equals(credentials.UserId.Trim(), StringComparison.OrdinalIgnoreCase) &&
            a.Password!.Equals(credentials.Password.Trim()));

        if (account == null)
        {
            return new LoginResponse
            {
                IsSuccess = false,
                Message = "Invalid credentials. Please try again."
            };
        }

        return new LoginResponse
        {
            IsSuccess = true,
            Message = "Login successful",
            User = new UserAccount
            {
                Role = account.Role,
                UserId = account.UserId
            }
        };
    }
}
