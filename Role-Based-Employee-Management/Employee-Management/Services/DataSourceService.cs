using Employee_Management.Models;

namespace Employee_Management.Services;

/// <summary>
/// Service that generates mock employee data for testing
/// </summary>
public class DataSourceService
{
    private static readonly string[] FirstNames = new[]
    {
        "Ava", "Liam", "Noah", "Emma", "Oliver", "Sophia", "Elijah", "Isabella", "James", "Mia"
    };

    private static readonly string[] LastNames = new[]
    {
        "Johnson", "Smith", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez"
    };

    private static readonly string[] JobTitles = new[]
    {
        "Software Engineer",
        "Account Manager",
        "QA Specialist",
        "Product Manager",
        "Data Analyst",
        "UX Designer",
        "DevOps Engineer"
    };

    private static readonly string[] Departments = new[]
    {
        "Engineering",
        "Sales",
        "Marketing",
        "Finance",
        "Human Resources"
    };

    /// <summary>
    /// Generate a list of mock employees
    /// </summary>
    /// <param name="totalEmployees">Number of employees to generate (default: 100)</param>
    /// <returns>List of generated employees</returns>
    public static List<Employee> GenerateEmployees(int totalEmployees = 100)
    {
        var random = new Random();
        var employees = new List<Employee>();

        for (int i = 1; i <= totalEmployees; i++)
        {
            var firstName = FirstNames[random.Next(FirstNames.Length)];
            var lastName = LastNames[random.Next(LastNames.Length)];
            var fullName = $"{firstName} {lastName}";
            var email = $"{firstName.ToLower()}.{lastName.ToLower()}{i}@example.org";
            var department = Departments[random.Next(Departments.Length)];
            var title = JobTitles[random.Next(JobTitles.Length)];

            // Determine role based on index for variety
            var role = i % 3 == 0 ? RoleKey.Admin : i % 3 == 1 ? RoleKey.Manager : RoleKey.Employee;

            // Salary ranges by role
            var salary = role switch
            {
                RoleKey.Admin => random.Next(100000, 150000),
                RoleKey.Manager => random.Next(70000, 110000),
                _ => random.Next(40000, 80000)
            };

            // Random join date between 2009 and 2024
            var startDate = new DateTime(2009, 1, 1);
            var endDate = DateTime.Now;
            var range = (endDate - startDate).Days;
            var joinDate = startDate.AddDays(random.Next(range));

            // 80% chance of being active
            var active = random.NextDouble() > 0.2;

            // Random rating 1-5
            var rating = random.Next(1, 6);

            var employee = new Employee
            {
                Id = $"EMP-{i:D4}",
                FullName = fullName,
                Email = email,
                Department = department,
                Role = role,
                Title = title,
                Salary = salary,
                Active = active,
                JoinDate = joinDate,
                Rating = rating,
                Contact = BuildContactNumber(random)
            };

            employees.Add(employee);
        }

        return employees;
    }

    /// <summary>
    /// Generate a random phone number in format (XXX) XXX-XXXX
    /// </summary>
    private static string BuildContactNumber(Random random)
    {
        var areaCode = random.Next(200, 999);
        var exchange = random.Next(200, 999);
        var number = random.Next(1000, 9999);

        return $"({areaCode}) {exchange}-{number}";
    }
}
