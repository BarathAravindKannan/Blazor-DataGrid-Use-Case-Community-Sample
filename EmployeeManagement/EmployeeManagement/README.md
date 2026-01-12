# Employee Management Application

A comprehensive Blazor-based web application for managing employee information, organizational structure, leave management, payroll, and company announcements. The application provides employees and managers with quick access to essential HR information and resources.

---

## 📋 Application Overview

This Employee Management System is built using **ASP.NET Core Blazor** with **Syncfusion UI components**. It displays employee profiles, organizational hierarchy, leave tracking, payroll information, and company-wide announcements in an intuitive, user-friendly interface.

**Current Features:**
- ✅ Employee profile management (read-only)
- ✅ Organizational structure and team hierarchy
- ✅ Leave tracking and management
- ✅ Payroll and pay stub viewing
- ✅ Company announcements and policies
- ✅ Employee achievements and recognition
- ✅ Data export capabilities (Excel)

**Note:** Add/Edit functionalities are not yet implemented. The application currently displays data in read-only mode.

---

## 🗺️ Application Pages

### 1. **Home / Employee Profile** (`/employee/{EmployeeCode}`)
Main dashboard for viewing individual employee information with tabbed navigation.

**Tabs Available:**
- **Overview Tab**: Displays employee profile picture, name, email, designation, branch, and team lead
- **Official Tab**: Shows official employment details (designation, branch, team assignments, work shift, employment type, and benefits)
- **Personal Tab**: Displays personal information (first name, last name, parents' names, gender, blood group, marital status, date of birth)
- **Leave Report Tab**: Shows leave records and approval status (visible for team members)
- **My Team Tab**: Grid view of all direct reports for managers (only visible to managers/team leads)
- **Pay Roll Tab**: Annual and multi-year payroll data (only visible to the main employee)

**Default Employee:** EMP100001 (Michael Anderson - General Manager)

---

### 2. **Organization / All Employees** (`/organization`)
Complete grid view of all 250 employees in the system with filtering and sorting capabilities.

**Features:**
- Sortable employee grid with 10 records per page
- Filterable columns: Name, ID, Email, Designation, Branch, Team, Reporter, Manager
- Excel export functionality
- Profile image display with hover tooltips
- Click on employee ID to view their detailed profile
- Column chooser to customize visible columns
- Grouping capabilities by any field

**Displayed Information:**
- Profile image and employee ID
- Name with tooltip preview
- Email address
- Designation and branch
- Team assignment(s)
- Reporting structure (Reporter/Manager)
- Date of joining
- Column search functionality

---

### 3. **My Team** (Tab within Home for Managers)
Filtered grid view showing team members reporting directly to the logged-in manager.

**Features:**
- Same grid capabilities as Organization page (filtering, sorting, grouping)
- Pagination with customizable page size
- Excel export of team data
- Hover tooltips showing employee details
- Quick navigation to individual employee profiles
- Row height optimization for better visibility

---

### 4. **Leave Report** (Tab within Employee Profile)
Comprehensive leave management and tracking system for employees and their managers.

**Features:**
- **Leave Statistics**: Summary of casual, sick, earned, and pending leave requests
- **Leave Filtering**: Date range filters to view specific periods (last month, last 6 months, this year)
- **Leave Grid**: Displays all leave requests with:
  - Leave ID, Employee Name, Employee Code
  - From/To dates and duration (days)
  - Absence type (Casual, Sick, Earned, Parental, Bereavement, Marriage)
  - Shift information
  - Leave status (Request, Approved)
- **Leave Approval**: Only visible to designated team leads (Michael Anderson) - approve/reject leave requests
- **Excel Export**: Export leave records for reporting purposes
- **Column Chooser**: Customize displayed columns

**Leave Types:**
- **Normal Leave**: Casual, Sick, Earned
- **Special Leave**: Parental, Bereavement, Marriage

---

### 5. **Pay Roll** (`/organization/payroll`)
Year-based payroll summary with monthly breakdowns.

**Features:**
- **Year Selector**: Dropdown to view payroll for current year, previous year, or 2 years back
- **Payroll Grid**: Displays monthly breakdown of:
  - Regular hours worked
  - Overtime hours worked
  - Bonuses and commissions
  - Federal, state, social security, and Medicare taxes
  - Net pay calculations
- **Frozen Columns**: First 3 columns remain visible while scrolling horizontally
- **Column Chooser**: Hide/show specific months or salary components
- **Automatic Calculations**: Total aggregate, deductions, and net pay

**Tax Rates** (Fixed):
- Federal Income Tax: 14.25%
- State Income Tax: 5.825%
- Social Security Tax: 5.325%
- Medicare Tax: 1.325%

---

### 6. **Pay Stub** (Commented Out - Not Active)
Monthly pay stub details for specific employees (currently disabled but available for future use).

**Features** (when enabled):
- Month selector dropdown
- Individual pay stub calculations
- Gross aggregate (regular + overtime + bonus + commission)
- Deductions summary
- Final net pay display

---

### 7. **Announcements** (`/announcements`)
Company-wide announcements and important updates displayed as card layouts.

**Current Announcements:**
1. Company Expansion Announcement
2. New Product Launch
3. Employee Recognition and Appreciation
4. Upcoming Training and Development Programs
5. Company Milestone Celebration
6. Corporate Social Responsibility Initiatives
7. Important Policy Updates
8. Employee Wellness Programs Launch

**Format:** Card-based layout with titles, descriptions, and "Read More" links

---

### 8. **Policies** (`/policies`)
Company policies and guidelines for employee reference.

**Policies Included:**
- **Assets Policy**: Rules for company devices and equipment usage
- **Attendance Policy**: Punctuality and absence reporting requirements
- **Protecting Information Policy**: Data security and confidentiality protocols
- **Leave Policy**: 36 annual leave days with categories (annual, medical, family, earned)
- **Remote Work Policy**: Flexible work arrangements and availability expectations
- **Security Policy**: Asset protection and information security protocols
- **Code of Conduct Policy**: Professional behavior and ethical guidelines
- **Internet Usage Policy**: Responsible use of company internet resources
- **Expense Reimbursement Policy**: Guidelines for work-related expense claims

**Format:** Card-based layout with policy title, description, and "Read More" links

---

### 9. **Achievements** (`/achievements`)
Recognition and achievement cards highlighting employee accomplishments and milestones.

**Achievement Categories:**
- Excellence in Software Development (Innovation Award)
- Product Launch Achievements
- Team Performance and Collaboration
- Professional Development and Skills Mastery (Certifications)
- Client Impact and Customer Success
- Professional Growth Recognition

**Format:** Card-based layout with titles, subtitles, descriptions, and "Read More" links

---

## 📊 Data Models

### EmployeesDetails
Contains complete employee information including:
- Personal: Name, First/Last Name, Gender, DOB, Blood Group, Marital Status, Parents' Names
- Official: Employee Code, Designation, Branch, Team, Manager Name, Team Lead, Employment Type
- Contact: Email, Date of Joining
- Benefits: Company Benefits information, Work Shift, WFH eligibility

**Total Employees:** 250 (generated with deterministic data)
- 1 CEO (Christopher Anderson - EMP100000)
- 1 General Manager (Michael Anderson - EMP100001)
- 248 Regular employees (EMP100002 - EMP100249)

---

### EmployeesLeaveDetails
Leave tracking and management data:
- Employee reference information
- Leave ID, Absence Type, Shift information
- From/To dates and duration
- Status (Request, Approved)
- Created by reference

**Absense Types:**
- Casual, Sick, Earned (Normal Leave)
- Parental, Bereavement, Marriage (Special Leave)

---

### EmployeesPaySlipDetails
Monthly payroll and compensation data:
- Employee reference information
- 12 MonthPayStub objects (January through December)
- Automatic tax calculations based on fixed rates

### MonthPayStub
Individual month's salary breakdown:
- RegularHoursWorked
- OverTimeHoursWorked
- Bonus and Commission
- FederalIncomeTax, StateIncomeTax, SocialSecurityTax, MedicareTax

---

## 🏗️ Project Structure

```
EmployeeManagement/
├── Components/
│   ├── Pages/
│   │   ├── Home.razor                 (Employee Profile)
│   │   ├── Home.razor.cs              (Code-behind with data models)
│   │   ├── Index.razor                (Default route)
│   │   ├── Organisation.razor         (All Employees)
│   │   ├── MyTeam.razor               (Team Members Grid)
│   │   ├── LeaveReport.razor          (Leave Management)
│   │   ├── PayRoll.razor              (Payroll Summary)
│   │   ├── PayStub.razor              (Monthly Pay Stubs - Disabled)
│   │   ├── Announcements.razor        (Company Announcements)
│   │   ├── Policies.razor             (Company Policies)
│   │   ├── Achievements.razor         (Recognition & Achievements)
│   │   ├── EmployeeInfo.razor         (Alternative Employee View)
│   │   ├── Official.razor             (Official Details Component)
│   │   ├── Personal.razor             (Personal Details Component)
│   │   └── Error.razor                (Error Page)
│   ├── Layout/
│   │   ├── MainLayout.razor           (Main application layout)
│   │   ├── NavMenu.razor              (Navigation menu)
│   │   └── MainLayout.razor.css       (Layout styles)
│   ├── App.razor                      (App component)
│   ├── Routes.razor                   (Route definitions)
│   └── _Imports.razor                 (Global using statements)
├── wwwroot/
│   ├── css/                           (Stylesheet organization)
│   ├── images/                        (Employee profile images)
│   └── bootstrap/                     (Bootstrap framework)
├── appsettings.json                   (Configuration settings)
├── Program.cs                         (Application startup)
└── EmployeeManagement.csproj          (Project file)
```

---

## 🛠️ Technologies & Libraries

- **Framework:** ASP.NET Core Blazor
- **UI Components:** Syncfusion Blazor
  - Grids (SfGrid)
  - Tabs (SfTab)
  - Dropdown Lists (SfDropDownList)
  - Tooltips (SfTooltip)
  - Cards (SfCard)
  - Buttons (SfButton)
- **Styling:** Bootstrap 5, Custom CSS
- **Data Export:** Excel export functionality
- **JavaScript Interop:** JSInterop for advanced features

---

## 🔄 Navigation

**Main Navigation Menu:**
- Home (Default - Employee Profile)
- Organization (All Employees)
- Announcements
- Policies
- Achievements

**Tab Navigation (within pages):**
- Employee Profile tabs: Overview → Official → Personal → Leave Report → My Team → Pay Roll
- Organization tabs: Employees
- Leave Report includes date range filters

---

## 📝 Usage Notes

### Viewing Employee Profiles
1. From Organization page, click on employee ID or name
2. Or navigate directly to `/employee/{EmployeeCode}`
3. Use tabs to browse different information sections

### Checking Leave Information
1. Go to employee profile
2. Click "Leave Report" tab
3. Use date filters to view specific periods
4. Managers can approve/reject requests in this section

### Accessing Payroll Data
1. Go to employee profile
2. Click "Pay Roll" tab
3. Use year dropdown to select different fiscal years
4. Scroll horizontally through monthly data

### Exporting Data
- Organization, My Team, and Leave Report pages support Excel export
- Use "ExcelExport" toolbar button to download data

---

## 🔐 Current Limitations

- **No Add/Edit Functionality**: All data is read-only; no ability to create, modify, or delete employee records
- **Hardcoded Data**: All information is generated using deterministic algorithms; no database integration
- **Limited Permissions**: Leave approval is hardcoded for "Michael Anderson" only
- **No Authentication**: Application does not require login credentials
- **No Real-time Updates**: Data refreshes only on page reload
- **Pay Stub Page Disabled**: Monthly pay stub view is currently commented out and not active

---

## 🚀 Future Enhancements

- ✅ Add/Edit/Delete employee records
- ✅ Real database integration
- ✅ User authentication and role-based access control
- ✅ Leave request submission and workflow
- ✅ Advanced reporting and analytics
- ✅ Notification system
- ✅ Document management
- ✅ Performance evaluation module
- ✅ Training and development tracking
- ✅ Mobile-responsive design optimization

---

## 📞 Support

For issues, feature requests, or questions about the application, please refer to the project documentation or contact the development team.

---

**Version:** 1.0  
**Last Updated:** 2024  
**Status:** Active Development
