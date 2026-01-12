using static EmployeeManagement.Components.Pages.Home;
using System;
using Syncfusion.Blazor.Navigations;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Components.Pages
{
    public partial class Home
    {
        [Parameter]
        public string EmployeeCode { get; set; }
        private SfTab HeaderTab { get; set; }
        public EmployeesDetails employee { get; set; } = EmployeesDetails.GetAllEmployeeRecords()?.Where(e => e.EmployeeCode == "EMP100001").FirstOrDefault();

        private EmployeesDetails selectedEmployee { get; set; }

        private static string EmployeeIdPrefix = "EMP";
        private static string LeaveIdPrefix = "LEV";
        private static string LeaveIdSeparator = "_";

        private void UpdateChoosenEmployeeProfile(EmployeesDetails selectedEmployeeData)
        {
            selectedEmployee = selectedEmployeeData;
            StateHasChanged();
            HeaderTab.SelectedItem = 0;
        }

        protected override void OnInitialized()
        {
            if (EmployeeCode != null)
            {
                var concernEmployee = EmployeesDetails.GetAllEmployeeRecords()?.Where(e => e.EmployeeCode == EmployeeCode).FirstOrDefault();
                selectedEmployee = concernEmployee != null ? concernEmployee : selectedEmployee;
            }
        }

        public class EmployeesDetails
        {
            public static List<EmployeesDetails> employeeData = new List<EmployeesDetails>();

            public EmployeesDetails()
            {

            }

            public EmployeesDetails(string Name, string EmployeeCode, string Branch, string Team, string Designation, string TeamLead, string ManagerName, string Mail, DateTime DateOfJoining,
                string FirstName, string LastName, string FatherName, string MotherName, string Gender, string BloodGroup, string MaritalStatus, DateTime DOB, string WorkShift, string WFH, string EmploymentType, string CompanyBenefits, string ImgPath)
            {
                this.Name = Name;
                this.EmployeeCode = EmployeeCode;
                this.Designation = Designation;
                this.Branch = Branch;
                this.Team = Team;
                this.TeamLead = TeamLead;
                this.ManagerName = ManagerName;
                this.Mail = Mail;
                this.DateOfJoining = DateOfJoining;
                this.FirstName = FirstName;
                this.LastName = LastName;
                this.FatherName = FatherName;
                this.MotherName = MotherName;
                this.Gender = Gender;
                this.BloodGroup = BloodGroup;
                this.MaritalStatus = MaritalStatus;
                this.DOB = DOB;
                this.WorkShift = WorkShift;
                this.WFH = WFH;
                this.EmploymentType = EmploymentType;
                this.CompanyBenefits = CompanyBenefits;
                this.ProfileImgPath = ImgPath;
            }

            private static string GetDesignationByYearsOfService(int yearsOfService)
            {
                if (yearsOfService >= 18) return "Enterprise Architect";
                if (yearsOfService >= 16) return "Solution Architect";
                if (yearsOfService >= 14) return "Senior Software Engineer";
                if (yearsOfService >= 12) return "Lead Software Engineer";
                if (yearsOfService >= 10) return "Software Engineer";
                if (yearsOfService >= 8) return "Senior QA Engineer";
                if (yearsOfService >= 6) return "QA Engineer";
                if (yearsOfService >= 4) return "Technical Support Analyst";
                if (yearsOfService >= 2) return "Junior Software Engineer";
                return "Trainee";
            }

            private static string GetTeamByIndex(int index)
            {
                string[] teams = { "Software Development", "Quality Assurance (QA) and Testing", "Infrastructure and Operations", "Information Security", "Data Analytics", "Cloud Services", "DevOps (Development Operations)", "User Experience (UX) Design", "Technical Support", "Product Management" };
                return teams[index % teams.Length];
            }

            private static (string, string) GetParentNames(int index)
            {
                var parentPairs = new (string Father, string Mother)[]
                {
                    ("John Smith", "Mary Williams"),
                    ("Michael Johnson", "Jennifer Brown"),
                    ("David Williams", "Patricia Jones"),
                    ("James Jones", "Linda Garcia"),
                    ("Robert Brown", "Barbara Miller"),
                    ("William Davis", "Susan Wilson"),
                    ("Joseph Miller", "Jessica Moore"),
                    ("Charles Wilson", "Sarah Taylor"),
                    ("Richard Moore", "Karen Anderson"),
                    ("Thomas Taylor", "Cynthia Thomas"),
                    ("Daniel Anderson", "Amy Jackson"),
                    ("Matthew Thomas", "Margaret White"),
                    ("Anthony Jackson", "Dorothy Harris"),
                    ("Mark White", "Betty Martin"),
                    ("Steven Harris", "Helen Thompson"),
                    ("Paul Martin", "Sandra Garcia"),
                    ("Kenneth Thompson", "Ashley Martinez"),
                    ("Andrew Garcia", "Donna Robinson"),
                    ("Kevin Martinez", "Carol Clark"),
                    ("Brian Robinson", "Janet Rodriguez"),
                    ("Edward Clark", "Lisa Lewis"),
                    ("Jason Rodriguez", "Elizabeth Lee"),
                    ("Timothy Lewis", "Susan Walker"),
                    ("Eric Lee", "Kimberly Hall"),
                    ("Jeffrey Walker", "Emily Young"),
                    ("Scott Hall", "Michelle Hernandez"),
                    ("Christopher Allen", "Anna King"),
                    ("Gregory Young", "Rebecca Wright"),
                    ("Joshua Hernandez", "Carolyn Lopez"),
                    ("Ryan King", "Joyce Hill"),
                    ("Donald Wright", "Virginia Green"),
                    ("Patrick Lopez", "Martha Adams"),
                    ("Gary Hill", "Diane Nelson"),
                    ("Nicholas Green", "Julie Baker"),
                    ("Jonathan Adams", "Joyce Nelson"),
                    ("Larry Baker", "Brenda Carter"),
                    ("Stephen Gonzalez", "Gloria Roberts"),
                    ("Ronald Nelson", "Ann Turner"),
                    ("Terry Carter", "Theresa Phillips"),
                    ("Dennis Mitchell", "Sara Campbell"),
                    ("Peter Perez", "Irene Parker"),
                    ("Jerry Roberts", "Ruth Evans"),
                    ("Frank Turner", "Olive Edwards"),
                    ("Harold Phillips", "Alice Collins"),
                    ("Douglas Campbell", "Judith Stewart"),
                    ("Raymond Parker", "Rose Sanchez"),
                    ("George Evans", "Janice Morris"),
                    ("Bruce Edwards", "Gloria Rogers"),
                    ("Adam Collins", "Marian Peterson"),
                    ("Bryan Stewart", "Velma Ross"),
                    ("Russell Flores", "Sylvia Bennett"),
                    ("Randy Morris", "Evelyn Shaw"),
                    ("Roger Murphy", "Francine Simmons"),
                    ("Carl Rivera", "Ethel Flynn"),
                    ("Keith Cook", "Jean Hobbs"),
                    ("Aaron Bailey", "Tammie Hinton"),
                    ("Vincent Cooper", "Pearl Fitzpatrick"),
                    ("Phillip Reed", "Phyllis Harmon"),
                    ("Shawn Bell", "Edna Bates"),
                    ("Willie Fox", "Clara Barton"),
                    ("Todd Murphy", "Oda Beck"),
                    ("Steve Reed", "Juanita Boone")
                };

                return parentPairs[index % parentPairs.Length];
            }

            private static string GetBloodGroupByIndex(int index)
            {
                string[] bloodGroups = { "O+ve", "A+ve", "B+ve", "AB+ve", "O-ve", "A-ve", "B-ve", "AB-ve" };
                return bloodGroups[index % bloodGroups.Length];
            }

            private static string GetMaritalStatusByYearsOfService(int yearsOfService, bool isMale)
            {
                if (yearsOfService >= 10) return "Married";
                if (yearsOfService >= 5) return isMale ? "Married" : "Single";
                return "Single";
            }

            public static List<EmployeesDetails> GetAllEmployeeRecords()
            {
                if (employeeData.Count() == 0)
                {
                    DateTime currentDay = DateTime.Today.ToUniversalTime();

                    // Static list of 250 unique full names
                    string[] fullNames = {
                        "Christopher Anderson", "Michael Anderson", "James Patterson", "Robert Johnson", "William Martinez",
                        "David Williams", "Richard Taylor", "Joseph Garcia", "Thomas Brown", "Charles Davis",
                        "Matthew Wilson", "Mark Rodriguez", "Donald Lewis", "Steven Lee", "Paul Walker",
                        "Andrew Hall", "Joshua Allen", "Kenneth King", "Kevin Wright", "Brian Lopez",
                        "George Hill", "Edward Scott", "Ronald Green", "Timothy Adams", "Jason Nelson",
                        "Jeffrey Carter", "Ryan Roberts", "Jacob Phillips", "Gary Campbell", "Nicholas Parker",
                        "Eric Evans", "Jonathan Edwards", "Stephen Collins", "Larry Stewart", "Justin Sanchez",
                        "Scott Morris", "Brandon Rogers", "Benjamin Reed", "Samuel Cook", "Frank Morgan",
                        "Gregory Bell", "Alexander Murphy", "Raymond Robertson", "Patrick Hunt", "Jack Joyce",
                        "Dennis Oconnell", "Jerry Pope", "Tyler Price", "Aaron Bennett", "Jose Chavez",
                        "Emily Johnson", "Sarah Davis", "Jessica Martinez", "Jessica Wilson", "Amanda Taylor",
                        "Ashley Garcia", "Jennifer Brown", "Donna Rodriguez", "Carol Lewis", "Pamela Lee",
                        "Nancy Walker", "Linda Hall", "Kimberly Allen", "Michelle King", "Rachel Wright",
                        "Amy Lopez", "Melissa Hill", "Deborah Scott", "Amy Green", "Laura Adams",
                        "Cheryl Nelson", "Mildred Carter", "Katherine Roberts", "Andrea Phillips", "Brittany Campbell",
                        "Angela Parker", "Diane Evans", "Dorothy Edwards", "Joanne Collins", "Marie Stewart",
                        "Beverly Sanchez", "Kathryn Morris", "Deann Rogers", "Tammy Reed", "Gail Cook",
                        "Hannah Morgan", "Audrey Bell", "Theresa Murphy", "Sarah Robertson", "Frances Hunt",
                        "Ann Joyce", "Sara Pope", "Lauren Price", "Olivia Bennett", "Sophia Chavez",
                        "Isabella Rodriguez", "Mia Taylor", "Ava Wilson", "Charlotte Martinez", "Amelia Johnson",
                        "Evelyn Garcia", "Abigail Lewis", "Harper Lee", "Emily Walker", "Elizabeth Hall",
                        "Avery Allen", "Sofia King", "Ella Wright", "Scarlett Lopez", "Victoria Hill",
                        "Madison Scott", "Luna Green", "Chloe Adams", "Penelope Nelson", "Layla Carter",
                        "Riley Roberts", "Zoey Phillips", "Nora Campbell", "Lily Parker", "Eleanor Evans",
                        "Hannah Edwards", "Lillian Collins", "Grace Stewart", "Violet Sanchez", "Aurora Morris",
                        "Savannah Rogers", "Audrey Reed", "Stella Cook", "Nova Morgan", "Hazel Bell",
                        "Willow Murphy", "Ivy Robertson", "Zoe Hunt", "Paisley Joyce", "Leah Pope",
                        "Sadie Price", "Samantha Bennett", "Eden Chavez", "Maya Rodriguez", "Aaliyah Taylor",
                        "Raven Wilson", "Margaret Martinez", "Ariana Johnson", "Isla Garcia", "Aliana Lewis",
                        "Eliana Lee", "Emery Walker", "Morgan Hall", "Sienna Allen", "Leilani King",
                        "Gianna Wright", "Kenzie Lopez", "Clara Hill", "Vera Scott", "Olive Green",
                        "Lyra Adams", "Marina Nelson", "Ophelia Carter", "Octavia Roberts", "Natalia Phillips",
                        "Opal Campbell", "Paisley Parker", "Quinn Evans", "Rosa Edwards", "Ruby Collins",
                        "Sasha Stewart", "Talia Sanchez", "Uma Morris", "Valentina Rogers", "Vienna Reed",
                        "Willa Cook", "Xiomara Morgan", "Yareli Bell", "Zalena Murphy", "Zara Robertson",
                        "Aurora Hunt", "Bella Joyce", "Cora Pope", "Dahlia Price", "Esme Bennett",
                        "Faye Chavez", "Giselle Rodriguez", "Hadley Taylor", "Ivette Wilson", "Juniper Martinez",
                        "Kaida Johnson", "Liliana Garcia", "Magnolia Lewis", "Nadira Lee", "Oakley Walker",
                        "Paisley Hall", "Quinn Allen", "Raina King", "Sage Wright", "Thea Lopez",
                        "Uliana Hill", "Valentina Scott", "Winter Green", "Ximena Adams", "Yara Nelson",
                        "Zariah Carter", "Asha Roberts", "Briana Phillips", "Callie Campbell", "Darla Parker",
                        "Eloise Evans", "Frida Edwards", "Genevieve Collins", "Helena Stewart", "Imogen Sanchez",
                        "Josephine Morris", "Kinsley Rogers", "Lavender Reed", "Magnolia Cook", "Natalie Morgan",
                        "Ophelia Bell", "Paisley Murphy", "Quinley Robertson", "Ruby Hunt", "Scarlett Joyce",
                        "Tatum Pope", "Ursa Price", "Violet Bennett", "Windy Chavez", "Xylia Rodriguez",
                        "Yara Taylor", "Zelda Wilson", "Adriana Martinez", "Brynne Johnson", "Cecelia Garcia",
                        "Diana Lewis", "Emilia Lee", "Felicity Walker", "Geraldine Hall", "Hailey Allen",
                        "Iris King", "Jasmine Wright", "Kendall Lopez", "Lauren Hill", "Margot Scott",
                        "Natasha Smith", "Olivia Johnson", "Patricia Brown", "Quinn Davis", "Rachel Wilson",
                        "Samantha Miller", "Tiffany Garcia", "Unice Rodriguez", "Valerie Martinez", "Wendy Thomas"
                    };

                    // Static first and last names for splitting
                    string[] firstNames = {
                        "Christopher", "Michael", "James", "Robert", "William", "David", "Richard", "Joseph",
                        "Thomas", "Charles", "Matthew", "Mark", "Donald", "Steven", "Paul", "Andrew",
                        "Joshua", "Kenneth", "Kevin", "Brian", "George", "Edward", "Ronald", "Timothy",
                        "Jason", "Jeffrey", "Ryan", "Jacob", "Gary", "Nicholas", "Emily", "Sarah",
                        "Jessica", "Amanda", "Ashley", "Jennifer", "Donna", "Carol", "Pamela", "Nancy"
                    };

                    string[] lastNames = {
                        "Anderson", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis",
                        "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas",
                        "Taylor", "Moore", "Jackson", "Martin", "Lee", "Perez", "Thompson", "White"
                    };

                    string[] teams = { "Software Development", "Quality Assurance (QA) and Testing", "Infrastructure and Operations", "Information Security", "Data Analytics", "Cloud Services", "DevOps (Development Operations)", "User Experience (UX) Design", "Technical Support", "Product Management" };

                    // Create static joining dates: 5 employees per month spread across 20 years
                    List<DateTime> joiningDates = new List<DateTime>();
                    for (int year = currentDay.Year - 20; year <= currentDay.Year; year++)
                    {
                        for (int month = 1; month <= 12; month++)
                        {
                            // 5 joinings per month on different days
                            joiningDates.Add(new DateTime(year, month, 5).ToUniversalTime());
                            joiningDates.Add(new DateTime(year, month, 10).ToUniversalTime());
                            joiningDates.Add(new DateTime(year, month, 15).ToUniversalTime());
                            joiningDates.Add(new DateTime(year, month, 20).ToUniversalTime());
                            joiningDates.Add(new DateTime(year, month, 25).ToUniversalTime());
                        }
                    }

                    // Add CEO and General Manager
                    var ceoJoiningDate = new DateTime(currentDay.Year - 20, 1, 1).ToUniversalTime();
                    var ceoParents = GetParentNames(0);
                    employeeData.Add(new EmployeesDetails(
                        "Christopher Anderson", "EMP100000", "Tower 1", "Management", "CEO",
                        "Christopher Anderson", "Christopher Anderson", "christopher.anderson@company.com",
                        ceoJoiningDate, "Christopher", "Anderson", ceoParents.Item1, ceoParents.Item2,
                        "Male", "O-ve", "Married", new DateTime(currentDay.Year - 58, 10, 2),
                        "Regular", "Yes", "Full-Time", "Health Insurance, Stock Options, Executive Benefits", "1.png"
                    ));

                    var gmJoiningDate = new DateTime(currentDay.Year - 19, 2, 1).ToUniversalTime();
                    var gmParents = GetParentNames(1);
                    employeeData.Add(new EmployeesDetails(
                        "Michael Anderson", "EMP100001", "Tower 1", "Management", "General Manager",
                        "Christopher Anderson", "Christopher Anderson", "michael.anderson@company.com",
                        gmJoiningDate, "Michael", "Anderson", gmParents.Item1, gmParents.Item2,
                        "Male", "O+ve", "Married", new DateTime(currentDay.Year - 56, 3, 20),
                        "Regular", "Yes", "Full-Time", "Health Insurance, Stock Options", "2.png"
                    ));

                    // Add 248 regular employees
                    int dateIndex = 0;
                    for (int i = 2; i < 250; i++)
                    {
                        DateTime joiningDate = joiningDates[dateIndex % joiningDates.Count];
                        dateIndex++;

                        int yearsOfService = (currentDay.Year - joiningDate.Year);
                        if (currentDay.Month < joiningDate.Month || (currentDay.Month == joiningDate.Month && currentDay.Day < joiningDate.Day))
                        {
                            yearsOfService--;
                        }

                        string fullName = fullNames[i];
                        string[] nameParts = fullName.Split(' ');
                        string firstName = nameParts[0];
                        string lastName = nameParts.Length > 1 ? nameParts[1] : "Smith";

                        bool isMale = i % 3 != 0;
                        string gender = isMale ? "Male" : "Female";

                        string team = GetTeamByIndex(i);
                        string designation = GetDesignationByYearsOfService(yearsOfService);
                        string maritalStatus = GetMaritalStatusByYearsOfService(yearsOfService, isMale);
                        string bloodGroup = GetBloodGroupByIndex(i);

                        var parents = GetParentNames(i);
                        string mail = firstName.ToLower() + "." + lastName.ToLower() + "@company.com";

                        // Determine team lead and manager based on designation
                        string teamLead = i <= 50 ? "Michael Anderson" : "James Patterson";
                        string manager = i <= 10 ? "Michael Anderson" : "James Patterson";

                        DateTime dob = new DateTime(joiningDate.Year - yearsOfService - 25 + (i % 15), (i % 12) + 1, (i % 28) + 1).ToUniversalTime();
                        //string imgPath = (i%10).ToString() + ".png";
                        //imgPath = i%10 == 0 ? "" : imgPath;
                        string imgPath = "";
                        employeeData.Add(new EmployeesDetails(
                            fullName, EmployeeIdPrefix + (100002 + i - 2), "Tower " + ((i % 5) + 1), team, designation,
                            teamLead, manager, mail, joiningDate,
                            firstName, lastName, parents.Item1, parents.Item2,
                            gender, bloodGroup, maritalStatus, dob,
                            "Regular", "Yes", "Full-Time", "Health Insurance, Gift Cards", imgPath
                        ));
                    }
                }
                int males = 1; int females = 5;
                for(int a = 0; a < 10;a++)
                {
                    if (employeeData[a].Gender == "Male")
                    {
                        employeeData[a].ProfileImgPath = males.ToString() + ".png";
                        males++;
                    }
                    if (employeeData[a].Gender == "Female")
                    {
                        employeeData[a].ProfileImgPath = females.ToString() + ".png";
                        females++;
                    }
                }
                return employeeData;
            }
            public string Name { get; set; }
            public string EmployeeCode { get; set; }
            public string Branch { get; set; }
            public string Team { get; set; }
            public string Designation { get; set; }
            public string TeamLead { get; set; }
            public string ManagerName { get; set; }
            public string Mail { get; set; }
            public DateTime DateOfJoining { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FatherName { get; set; }
            public string MotherName { get; set; }
            public string Gender { get; set; }
            public string BloodGroup { get; set; }
            public string MaritalStatus { get; set; }
            public DateTime DOB { get; set; }
            public string WorkShift { get; set; }
            public string WFH { get; set; }
            public string EmploymentType { get; set; }
            public string CompanyBenefits { get; set; }
            public string ProfileImgPath { get; set;}
        }

        public class EmployeesLeaveDetails
        {

            public static List<EmployeesLeaveDetails> leaveDetails = new List<EmployeesLeaveDetails>();
            public static string[] NormalLeave = { "Casual", "Sick", "Earned"};
            public static string[] SpecialLeave = { "Parental", "Bereavement", "Marriage" };
            public static string[] ShiftType = { "Regular", "Night" };
            public EmployeesLeaveDetails()
            {
            }
            public static DateTime generateLeaveDate(DateTime date, int startMonth, int endMonth)
            {
                // Deterministic month selection: always choose the startMonth within the given range
                int month = startMonth;
                List<DateTime> holidays = new List<DateTime>
                {
                    new DateTime(date.Year, 1, 1).ToUniversalTime(),
                    new DateTime(date.Year, 5, 1).ToUniversalTime(),
                    new DateTime(date.Year, 12, 25).ToUniversalTime()
                };
                DateTime d = new DateTime(date.Year, month, 1, 0, 0, 0).ToUniversalTime();
                // Advance to next business day if weekend/holiday
                while (d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday || holidays.Contains(d))
                {
                    d = d.AddDays(1);
                }
                return d;
            }

            public static DateTime generateLeaveDate(DateTime date, int leaveCount)
            {
                List<DateTime> holidays = new List<DateTime>
                {
                    new DateTime(date.Year, 1, 1).ToUniversalTime(),
                    new DateTime(date.Year, 5, 1).ToUniversalTime(),
                    new DateTime(date.Year, 12, 25).ToUniversalTime()
                };
                DateTime endDate = date;
                for (int i = 1; i < leaveCount; i++)
                {
                    endDate = endDate.AddDays(1);
                    // Loop until we find a Monday, Tuesday, Wednesday, Thursday, or Friday that is not a holiday
                    while (endDate.DayOfWeek != DayOfWeek.Monday && endDate.DayOfWeek != DayOfWeek.Tuesday &&
                           endDate.DayOfWeek != DayOfWeek.Wednesday && endDate.DayOfWeek != DayOfWeek.Thursday &&
                           endDate.DayOfWeek != DayOfWeek.Friday || holidays.Contains(endDate))
                    {
                        // Move to the next day
                        endDate = endDate.AddDays(1);
                    }
                }
                return endDate;
            }
            public static EmployeesLeaveDetails generaterecord(EmployeesDetails item, DateTime startDate, DateTime endDate, int leaveDays, string leaveID, string status, string leaveType)
            {

                EmployeesLeaveDetails newItem = new EmployeesLeaveDetails
                {
                    Name = item.Name,
                    EmployeeCode = item.EmployeeCode,
                    Designation = item.Designation,
                    Branch = item.Branch,
                    Team = item.Team,
                    TeamLead = item.TeamLead,
                    ManagerName = item.ManagerName,
                    Mail = item.Mail,
                    DateOfJoining = item.DateOfJoining,
                    AttendanceID = leaveID,
                    AbsenceType = leaveType,
                    ShiftName = ShiftType[0],
                    From = startDate,
                    To = endDate,
                    Days = leaveDays,
                    Status = status,
                    CreatedBy = item.Name,
                };
                return newItem;
            }

            public EmployeesLeaveDetails(string Name, string EmployeeCode, string Branch, string Team, string Designation, string TeamLead, string ManagerName, string Image, string Mail, DateTime DateOfJoining,
                string AttendanceID, string AbsenceType, string ShiftName, DateTime From, DateTime To, double Days, string Status, string CreatedBy)
            {
                this.Name = Name;
                this.EmployeeCode = EmployeeCode;
                this.Designation = Designation;
                this.Branch = Branch;
                this.Team = Team;
                this.TeamLead = TeamLead;
                this.ManagerName = ManagerName;
                this.Image = Image;
                this.Mail = Mail;
                this.DateOfJoining = DateOfJoining;
                this.AttendanceID = AttendanceID;
                this.AbsenceType = AbsenceType;
                this.ShiftName = ShiftName;
                this.From = From;
                this.To = To;
                this.Days = Days;
                this.Status = Status;
                this.CreatedBy = CreatedBy;
            }
            public static List<EmployeesLeaveDetails> GetAllLeaveRecords()
            {
                if (leaveDetails.Count() == 0)
                {
                    IEnumerable<EmployeesDetails> DataSource = EmployeesDetails.GetAllEmployeeRecords();
                    int j = 1;
                    //DateTime currentDay = new DateTime(DateTime.Today.Year, 9, 1).ToUniversalTime();
                    DateTime currentDay = DateTime.Today;
                    int leaveDays;
                    DateTime startDate;
                    DateTime endDate;
                    string leaveID;
                    string status;
                    string leaveType;
                    EmployeesLeaveDetails newItem;
                    foreach (EmployeesDetails item in DataSource)
                    {
                        if (j % 1000 != 0)
                        {
                            for (int k = 0; k < 7; k++)
                            {
                                if (j % 3 == 0 && (k == 5 || k == 6))
                                {
                                    continue;
                                }
                                leaveDays = ((j + k) % 3) + 1;
                                startDate = generateLeaveDate(currentDay, k + 1, k == 6 ? 8 : k + 1);
                                endDate = generateLeaveDate(startDate, leaveDays);
                                leaveID = item.EmployeeCode.Replace(EmployeeIdPrefix, LeaveIdPrefix) + LeaveIdSeparator + (k + 1);
                                status = startDate > currentDay ? "Request" : "Approved";
                                leaveType = status == "Request" ? "Casual" : NormalLeave[(j + k) % NormalLeave.Length];
                                newItem = generaterecord(item, startDate, endDate, leaveDays, leaveID, status, leaveType);
                                // Deterministic shift selection
                                newItem.ShiftName = ShiftType[(j + k) % ShiftType.Length];
                                leaveDetails.Add(newItem);
                                if (j > 1100 && j % 301 == 0 && k == 6)
                                {
                                    leaveType = SpecialLeave[(j + k) % SpecialLeave.Length];
                                    leaveDays = leaveType == "Marriage" ? 10 : 3 + ((j + k) % 7);
                                    startDate = generateLeaveDate(currentDay, 8, 9);
                                    endDate = generateLeaveDate(startDate, leaveDays);
                                    leaveID = item.EmployeeCode.Replace(EmployeeIdPrefix, LeaveIdPrefix) + "_SPE_" + 1;
                                    status = startDate > currentDay ? "Request" : "Approved";
                                    newItem = generaterecord(item, startDate, endDate, leaveDays, leaveID, status, leaveType);
                                    newItem.ShiftName = ShiftType[(j + k) % ShiftType.Length];
                                    leaveDetails.Add(newItem);
                                }
                                if (j % 4 == 0 && k == 6)
                                {
                                    leaveDays = ((j + k + 1) % 3) + 1;
                                    startDate = generateLeaveDate(currentDay, 9, 12);
                                    endDate = generateLeaveDate(startDate, leaveDays);
                                    leaveID = item.EmployeeCode.Replace(EmployeeIdPrefix, LeaveIdPrefix) + LeaveIdSeparator + (k + 2);
                                    status = startDate > currentDay ? "Request" : "Approved";
                                    leaveType = status == "Request" ? "Casual" : NormalLeave[(j + k + 1) % NormalLeave.Length];
                                    newItem = generaterecord(item, startDate, endDate, leaveDays, leaveID, status, leaveType);
                                    newItem.ShiftName = ShiftType[(j + k + 1) % ShiftType.Length];
                                    leaveDetails.Add(newItem);
                                }
                                if (j > 1100 && j % 211 == 0 && k == 6)
                                {
                                    leaveType = SpecialLeave[(j + k + 2) % SpecialLeave.Length];
                                    leaveDays = leaveType == "Marriage" ? 10 : 3 + ((j + k + 2) % 7);
                                    startDate = generateLeaveDate(currentDay, 10, 11);
                                    endDate = generateLeaveDate(startDate, leaveDays);
                                    leaveID = item.EmployeeCode.Replace(EmployeeIdPrefix, LeaveIdPrefix) + "_SPE_" + 1;
                                    status = startDate > currentDay ? "Request" : "Approved";
                                    newItem = generaterecord(item, startDate, endDate, leaveDays, leaveID, status, leaveType);
                                    newItem.ShiftName = ShiftType[(j + k + 2) % ShiftType.Length];
                                    leaveDetails.Add(newItem);
                                }
                            }
                        }
                        j++;
                    }
                }
                return leaveDetails;
            }
            public string Name { get; set; }
            public string EmployeeCode { get; set; }
            public DateTime DateOfJoining { get; set; }
            public string Branch { get; set; }
            public string Team { get; set; }
            public string Designation { get; set; }
            public string TeamLead { get; set; }
            public string ManagerName { get; set; }
            public string Image { get; set; }
            public string Mail { get; set; }
            public string AttendanceID { get; set; }
            public string AbsenceType { get; set; }
            public string ShiftName { get; set; }
            public DateTime From { get; set; }
            public DateTime To { get; set; }
            public double Days { get; set; }
            public string Status { get; set; }
            public string CreatedBy { get; set; }
        }

        public class EmployeesPaySlipDetails
        {

            public static List<EmployeesPaySlipDetails> payslipDetails = new List<EmployeesPaySlipDetails>();
            // Deterministic configuration (no randomness)
            public static readonly double FederalTaxRate = 0.1425;
            public static readonly double StateTaxRate = 0.05825;
            public static readonly double SocialSecurityTaxRate = 0.05325;
            public static readonly double MedicareTaxRate = 0.01325;
            public static readonly int[] Bonuses = { 100, 200, 400, 0, 500, 800, 0, 1000, 1500, 2000, 0, 2500 };
            public static readonly int[] Commissions = { 250, 350, 0, 450, 500, 750, 0, 800, 1000, 1500, 2000, 0, 2500 };
            public EmployeesPaySlipDetails()
            {

            }
            public static double calculateExperince(DateTime startDate, DateTime endDate)
            {
                // Calculate the total number of months
                int totalMonths = (endDate.Year - startDate.Year) * 12 + (endDate.Month - startDate.Month);
                // If the end day is before the start day, subtract one month
                if (endDate.Day < startDate.Day)
                {
                    totalMonths--;
                }
                return Math.Floor(totalMonths / 12.0);
            }
            public static EmployeesPaySlipDetails generaterecord(EmployeesDetails item, List<MonthPayStub> PayStub)
            {
                EmployeesPaySlipDetails newItem = new EmployeesPaySlipDetails
                {
                    Name = item.Name,
                    EmployeeCode = item.EmployeeCode,
                    Designation = item.Designation,
                    Branch = item.Branch,
                    Team = item.Team,
                    TeamLead = item.TeamLead,
                    ManagerName = item.ManagerName,
                    Mail = item.Mail,
                    DateOfJoining = item.DateOfJoining,
                    JanPayStub = PayStub.Count > 0 ? PayStub[0] : null,
                    FebPayStub = PayStub.Count > 1 ? PayStub[1] : null,
                    MarPayStub = PayStub.Count > 2 ? PayStub[2] : null,
                    AprPayStub = PayStub.Count > 3 ? PayStub[3] : null,
                    MayPayStub = PayStub.Count > 4 ? PayStub[4] : null,
                    JunPayStub = PayStub.Count > 5 ? PayStub[5] : null,
                    JulPayStub = PayStub.Count > 6 ? PayStub[6] : null,
                    AugPayStub = PayStub.Count > 7 ? PayStub[7] : null,
                    SepPayStub = PayStub.Count > 8 ? PayStub[8] : null,
                    OctPayStub = PayStub.Count > 9 ? PayStub[9] : null,
                    NovPayStub = PayStub.Count > 10 ? PayStub[10] : null,
                    DecPayStub = PayStub.Count > 11 ? PayStub[11] : null,
                };
                return newItem;
            }

            public static MonthPayStub generatepaystubrecord(double RegularHoursWorked, double OverTimeHoursWorked, double Bonus, double Commission, double FederalIncomeTax, double StateIncomeTax, double SocialSecurityTax, double MedicareTax)
            {
                MonthPayStub newItem = new MonthPayStub
                {
                    RegularHoursWorked = RegularHoursWorked,
                    OverTimeHoursWorked = OverTimeHoursWorked,
                    Bonus = Bonus,
                    Commission = Commission,
                    FederalIncomeTax = FederalIncomeTax,
                    StateIncomeTax = StateIncomeTax,
                    SocialSecurityTax = SocialSecurityTax,
                    MedicareTax = MedicareTax,
                };
                return newItem;
            }
            public EmployeesPaySlipDetails(string Name, string EmployeeCode, string Branch, string Team, string Designation, string TeamLead, string ManagerName, string Image, string Mail, DateTime DateOfJoining,
                MonthPayStub JanPayStub)
            {
                this.Name = Name;
                this.EmployeeCode = EmployeeCode;
                this.Designation = Designation;
                this.Branch = Branch;
                this.Team = Team;
                this.TeamLead = TeamLead;
                this.ManagerName = ManagerName;
                this.Image = Image;
                this.Mail = Mail;
                this.DateOfJoining = DateOfJoining;
                this.JanPayStub = JanPayStub;
            }
            public static List<EmployeesPaySlipDetails> GetAllPaySlipRecords(int? yearOverride = null)
            {
                // Always regenerate for different years, don't use cache for year-specific calls
                if (yearOverride.HasValue)
                {
                    var tempList = new List<EmployeesPaySlipDetails>();
                    IEnumerable<EmployeesDetails> DataSource = EmployeesDetails.GetAllEmployeeRecords();
                    DateTime today = DateTime.Today.ToUniversalTime();
                    int targetYear = yearOverride.Value;
                    int maxMonth = 12; // Full year of data for past/future years
                    if (targetYear == today.Year)
                    {
                        maxMonth = today.Month - 1; // Current year: only up to previous month
                    }
                    
                    int j = 0;
                    foreach (EmployeesDetails item in DataSource)
                    {
                        List<MonthPayStub> PayStub = new List<MonthPayStub>();
                        for (int m = 1; m <= 12; m++)
                        {
                            // Check if data should be generated for this month
                            if (item.DateOfJoining.Year > targetYear || (item.DateOfJoining.Year == targetYear && m < item.DateOfJoining.Month) || m > maxMonth)
                            {
                                PayStub.Add(null);
                                continue;
                            }
                            
                            double experince = calculateExperince(item.DateOfJoining, new DateTime(targetYear, m, 15).ToUniversalTime());
                            double RegularHoursWorked;
                            double OverTimeHoursWorked;
                            double Bonus;
                            double Commission;

                            if (j < 1)
                            {
                                RegularHoursWorked = Math.Round(((m <= 6) ? 5800 : 6000) * (1 + (0.05 * experince)), 2);
                                int otFactor = ((j + m) % 6) + 6; // 6..11
                                OverTimeHoursWorked = Math.Round(((m <= 6) ? 180 : 200) * (1 + (0.05 * experince)) * otFactor, 2);
                                Bonus = Bonuses[8 + ((j + m) % 4)];
                                Commission = Commissions[9 + ((j + m) % 4)];
                            }
                            else if (j < 101)
                            {
                                RegularHoursWorked = Math.Round(((m <= 6) ? 5600 : 5800) * (1 + (0.05 * experince)), 2);
                                int otFactor = ((j + m) % 4) + 4; // 4..7
                                OverTimeHoursWorked = Math.Round(((m <= 6) ? 160 : 180) * (1 + (0.05 * experince)) * otFactor, 2);
                                Bonus = Bonuses[4 + ((j + m) % 3)];
                                Commission = Commissions[4 + ((j + m) % 5)];
                            }
                            else if (j < 1101)
                            {
                                RegularHoursWorked = Math.Round(((m <= 6) ? 5600 : 5800) * (1 + (0.05 * experince)), 2);
                                int otFactor = ((j + m) % 5) + 1; // 1..5
                                OverTimeHoursWorked = Math.Round(((m <= 6) ? 160 : 180) * (1 + (0.05 * experince)) * otFactor, 2);
                                Bonus = Bonuses[4 + ((j + m) % 3)];
                                Commission = Commissions[(j + m) % 4];
                            }
                            else
                            {
                                RegularHoursWorked = Math.Round(((m <= 6) ? 5600 : 5800) * (1 + (0.05 * experince)), 2);
                                int otFactor = ((j + m) % 6); // 0..5
                                OverTimeHoursWorked = Math.Round(((m <= 6) ? 160 : 180) * (1 + (0.05 * experince)) * otFactor, 2);
                                Bonus = Bonuses[(j + m) % 4];
                                Commission = 0;
                            }

                            double FederalIncomeTax = Math.Round(RegularHoursWorked * FederalTaxRate, 2);
                            double StateIncomeTax = Math.Round(RegularHoursWorked * StateTaxRate, 2);
                            double SocialSecurityTax = Math.Round(RegularHoursWorked * SocialSecurityTaxRate, 2);
                            double MedicareTax = Math.Round(RegularHoursWorked * MedicareTaxRate, 2);

                            PayStub.Add(generatepaystubrecord(RegularHoursWorked, OverTimeHoursWorked, Bonus, Commission, FederalIncomeTax, StateIncomeTax, SocialSecurityTax, MedicareTax));
                        }

                        EmployeesPaySlipDetails newItem = generaterecord(item, PayStub);
                        tempList.Add(newItem);
                        j++;
                    }
                    return tempList;
                }

                if (payslipDetails.Count() == 0)
                {
                    IEnumerable<EmployeesDetails> DataSource = EmployeesDetails.GetAllEmployeeRecords();
                    DateTime currentDay = DateTime.Today.ToUniversalTime();
                    int maxMonth = currentDay.Month - 1;
                    
                    
                    int j = 0;
                    foreach (EmployeesDetails item in DataSource)
                    {
                        List<MonthPayStub> PayStub = new List<MonthPayStub>();
                        for (int k = 0; k < currentDay.Month; k++)
                        {
                            double experince;
                            double RegularHoursWorked;
                            double OverTimeHoursWorked;
                            double Bonus;
                            double Commission;
                            int month = k + 1;
                            if ((item.DateOfJoining.Year == currentDay.Year && month < item.DateOfJoining.Month) || month > maxMonth)
                            {
                                PayStub.Add(null);
                                continue;
                            }
                            if (j < 1)
                            {
                                experince = calculateExperince(item.DateOfJoining, currentDay);
                                RegularHoursWorked = Math.Round(((month <= 6) ? 5800 : 6000) * (1 + (0.05 * experince)), 2);
                                int otFactor = ((j + month) % 6) + 6; // 6..11
                                OverTimeHoursWorked = Math.Round(((month <= 6) ? 180 : 200) * (1 + (0.05 * experince)) * otFactor, 2);
                                Bonus = Bonuses[8 + ((j + month) % 4)];
                                Commission = Commissions[9 + ((j + month) % 4)];
                            }
                            else if (j < 101)
                            {
                                experince = calculateExperince(item.DateOfJoining, currentDay);
                                RegularHoursWorked = Math.Round(((month <= 6) ? 5600 : 5800) * (1 + (0.05 * experince)), 2);
                                int otFactor = ((j + month) % 4) + 4; // 4..7
                                OverTimeHoursWorked = Math.Round(((month <= 6) ? 160 : 180) * (1 + (0.05 * experince)) * otFactor, 2);
                                Bonus = Bonuses[4 + ((j + month) % 3)];
                                Commission = Commissions[4 + ((j + month) % 5)];
                            }
                            else if (j < 1101)
                            {
                                experince = calculateExperince(item.DateOfJoining, currentDay);
                                RegularHoursWorked = Math.Round(((month <= 6) ? 5600 : 5800) * (1 + (0.05 * experince)), 2);
                                int otFactor = ((j + month) % 5) + 1; // 1..5
                                OverTimeHoursWorked = Math.Round(((month <= 6) ? 160 : 180) * (1 + (0.05 * experince)) * otFactor, 2);
                                Bonus = Bonuses[4 + ((j + month) % 3)];
                                Commission = Commissions[(j + month) % 4];
                            }
                            else
                            {
                                experince = calculateExperince(item.DateOfJoining, currentDay);
                                RegularHoursWorked = Math.Round(((month <= 6) ? 5600 : 5800) * (1 + (0.05 * experince)), 2);
                                int otFactor = ((j + month) % 6); // 0..5
                                OverTimeHoursWorked = Math.Round(((month <= 6) ? 160 : 180) * (1 + (0.05 * experince)) * otFactor, 2);
                                Bonus = Bonuses[(j + month) % 4];
                                Commission = 0;
                            }
                            double FederalIncomeTax = Math.Round(RegularHoursWorked * FederalTaxRate, 2);
                            double StateIncomeTax = Math.Round(RegularHoursWorked * StateTaxRate, 2);
                            double SocialSecurityTax = Math.Round(RegularHoursWorked * SocialSecurityTaxRate, 2);
                            double MedicareTax = Math.Round(RegularHoursWorked * MedicareTaxRate, 2);
                            PayStub.Add(generatepaystubrecord(RegularHoursWorked, OverTimeHoursWorked, Bonus, Commission, FederalIncomeTax, StateIncomeTax, SocialSecurityTax, MedicareTax));
                        }

                        EmployeesPaySlipDetails newItem = generaterecord(item, PayStub);
                        payslipDetails.Add(newItem);

                        j++;
                    }
                }
                return payslipDetails;
            }
            public string Name { get; set; }
            public string EmployeeCode { get; set; }
            public DateTime DateOfJoining { get; set; }
            public string Branch { get; set; }
            public string Team { get; set; }
            public string Designation { get; set; }
            public string TeamLead { get; set; }
            public string ManagerName { get; set; }
            public string Image { get; set; }
            public string Mail { get; set; }
            public int Total { get; set; }
            public MonthPayStub? JanPayStub { get; set; }
            public MonthPayStub? FebPayStub { get; set; }
            public MonthPayStub? MarPayStub { get; set; }
            public MonthPayStub? AprPayStub { get; set; }
            public MonthPayStub? MayPayStub { get; set; }
            public MonthPayStub? JunPayStub { get; set; }
            public MonthPayStub? JulPayStub { get; set; }
            public MonthPayStub? AugPayStub { get; set; }
            public MonthPayStub? SepPayStub { get; set; }
            public MonthPayStub? OctPayStub { get; set; }
            public MonthPayStub? NovPayStub { get; set; }
            public MonthPayStub? DecPayStub { get; set; }
        }

        public class MonthPayStub
        {
            public double RegularHoursWorked { get; set; }
            public double OverTimeHoursWorked { get; set; }
            public double Bonus { get; set; }
            public double Commission { get; set; }
            public double FederalIncomeTax { get; set; }
            public double StateIncomeTax { get; set; }
            public double SocialSecurityTax { get; set; }
            public double MedicareTax { get; set; }
        }
    }
}
