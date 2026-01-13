# Hotel Booking App 🏨

A modern hotel room booking application built with **Blazor** and **Syncfusion components**. This app allows users to search for hotels, view room details, filter by amenities and price, and complete the booking process.

---

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [How to Use](#how-to-use)
- [Key Components](#key-components)
- [Important Files](#important-files)

---

## 📖 Overview

The Hotel Booking App is a user-friendly web application that helps customers find and book hotel rooms. Users can:
- Browse available hotels and rooms
- Filter by amenities, price range, and ratings
- View detailed hotel information and room details
- Make bookings with personal information
- Print booking confirmations

---

## ✨ Features

### 🏠 Hotel Discovery
- **Image Carousel**: Beautiful sliding banner showing scenic destinations
- **Hotel Grid View**: Browse all available hotels with room information
- **Real-time Filtering**: Filter hotels by:
  - Price range (using slider)
  - Hotel amenities (WiFi, Gym, Pool, etc.)
  - Room amenities (AC, Heating, TV, etc.)
  - Ratings (Top Rated hotels)
  - Price sorting (Low to High / High to Low)

### 🛏️ Room Details
- View detailed room information including:
  - Room images and descriptions
  - Room capacity and bed types
  - Hotel amenities and room amenities
  - Room pricing with discounts
  - Extra bed options

### 📅 Booking System
- **Date Range Selection**: Choose check-in and check-out dates
- **Availability Check**: See which rooms are available for your dates
- **Booking Form**: Fill in personal details:
  - Name, Email, Phone Number
  - Current Address, City, Country
  - Zip/Postal Code
- **Price Calculation**: Automatic calculation including:
  - Room cost
  - Extra bed charges
  - Discounts applied
  - Tax calculations

### 🗺️ Location Map
- View hotel locations on an interactive map
- Hover over markers to see hotel information
- Full-screen map view in a dialog

### 📋 Booking Confirmation
- **Bill Summary**: See complete booking details
- **Print Option**: Print your booking confirmation
- **Personal Information Display**: Summary of your booking
- **Room Details Display**: Room and pricing information

### 📱 Responsive Design
- **Sidebar Navigation**: Toggle menu for filtering and hotel selection
- **Mobile-Friendly**: Responsive layout for different screen sizes
- **Toolbar Sorting**: Quick sorting options from the header

---

## 🛠️ Technology Stack

| Technology | Purpose |
|-----------|---------|
| **Blazor Server** | Web framework for building interactive UI |
| **.NET 10.0** | Backend runtime |
| **Syncfusion Components** | Pre-built UI components (Grid, Dialog, Carousel, etc.) |
| **C#** | Programming language |
| **HTML/CSS** | Frontend markup and styling |
| **Bootstrap** | CSS framework for styling |

### Syncfusion Components Used
- **SfCarousel**: Image slider for hotel photos
- **SfGrid**: Table for displaying hotels
- **SfChip**: Display amenities as chips
- **SfDialog**: Popup dialogs for bookings and maps
- **SfSidebar**: Side navigation menu
- **SfDateRangePicker**: Date selection for check-in/check-out
- **SfSlider**: Price range filter
- **SfTreeView**: Amenities filter selection
- **SfRating**: Hotel and room ratings
- **SfMaps**: Interactive location map
- **SfToolbar**: Toolbar with sorting options
- **SfButton, SfTextBox, SfDropDownList, SfMaskedTextBox**: Form elements

---

## 📁 Project Structure

```
Hotel-Booking-App/
├── Components/
│   ├── Pages/
│   │   ├── HotelBooking.razor         # Main page with UI
│   │   ├── HotelBooking.razor.cs      # Code-behind with logic
│   │   └── HotelBooking.razor.css     # Component styles
│   ├── Layout/
│   │   ├── MainLayout.razor           # Main layout
│   │   └── MainLayout.razor.css       # Layout styles
│   ├── App.razor                      # Root component
│   ├── Routes.razor                   # Route configuration
│   └── _Imports.razor                 # Global imports
├── wwwroot/
│   ├── images/                        # Hotel and room images
│   ├── app.css                        # Global styles
│   ├── bootstrap/                     # Bootstrap CSS
│   └── interop.js                     # JavaScript interop
├── appsettings.json                   # App configuration
├── appsettings.Development.json       # Development settings
├── Program.cs                         # App startup configuration
└── Hotel-booking-App.csproj          # Project file

```

---

## 🚀 Getting Started

### Prerequisites
- **.NET 10.0** SDK or later
- **Visual Studio 2022** or **Visual Studio Code**
- A modern web browser

### Installation

1. **Clone or Extract the Project**
   ```bash
   cd Hotel-Booking-App
   ```

2. **Restore NuGet Packages**
   ```bash
   dotnet restore
   ```

3. **Run the Application**
   ```bash
   dotnet run
   ```

4. **Open in Browser**
   - The app will be available at: `https://localhost:5001` (or the URL shown in the terminal)
   - Default: `http://localhost:5000` or `https://localhost:5001`

### Development Setup
- If using **Visual Studio**, simply open the `.sln` file and press F5 to run
- If using **Visual Studio Code**, use the terminal command above

---

## 📖 How to Use

### 1. **Browse Hotels**
   - The app loads with available hotels displayed in a grid
   - Scroll through the hotel carousel at the top to see destination images

### 2. **Select Dates**
   - Use the date picker to select your check-in and check-out dates
   - The app will automatically check room availability for those dates

### 3. **Filter Hotels**
   - Click the **Menu** button (☰) to open the sidebar
   - **Price Range**: Use the slider to set your budget
   - **Amenities**: Check boxes to filter by hotel amenities
   - **Room Amenities**: Filter by room features
   - Click **Apply** to filter the results

### 4. **View Hotel Details**
   - Click on any hotel in the grid
   - See detailed information about the hotel and room
   - Review amenities, pricing, and room capacity

### 5. **Check Location**
   - Click the **Map Icon** to see the hotel location on an interactive map
   - View nearby hotels and their positions

### 6. **Sort Hotels**
   - Use the **Toolbar** at the top to sort by:
     - Top Rating
     - Price (Low to High)
     - Price (High to Low)

### 7. **Book a Room**
   - Click the **Book** button on your selected room
   - Fill in your personal information:
     - First Name, Last Name
     - Email, Phone Number
     - Address, City, Country, Zip Code
   - Click **Submit** to complete booking

### 8. **View Booking Confirmation**
   - See the booking bill with all details
   - Review pricing breakdown:
     - Room cost
     - Extra bed charges
     - Discounts
     - Taxes
   - Click **Print** to print your confirmation

---

## 🧩 Key Components

### Main Component Files

1. **HotelBooking.razor**
   - Main UI component
   - Contains all UI elements (forms, grids, dialogs, etc.)
   - References Syncfusion components

2. **HotelBooking.razor.cs**
   - Code-behind logic
   - Handles events and data processing
   - Contains `BookingDetails` class for form validation
   - Implements filtering and sorting logic

3. **HotelBooking.razor.css**
   - Component-specific styles
   - Custom styling for grid, dialogs, and layout

### Important Classes

#### `BookingDetails` Class
```csharp
public class BookingDetails
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; } // Country
    public string Postcode { get; set; }
}
```

#### `HotelDataModel` Class
- Contains hotel information (name, price, amenities)
- Includes room details (capacity, bed count)
- Tracks booking and pricing information
- Stores check-in/check-out data

---

## 📝 Important Files

| File | Purpose |
|------|---------|
| `Program.cs` | Configures services and starts the application |
| `appsettings.json` | Configuration settings (logging, etc.) |
| `HotelBooking.razor` | Main UI page |
| `HotelBooking.razor.cs` | Business logic and event handlers |
| `_Imports.razor` | Global using statements and imports |
| `App.razor` | Root component configuration |

---

## ⚙️ Configuration

### appsettings.json
- **Logging**: Set to "Information" level for detailed logs
- **AllowedHosts**: Currently allows all hosts (`*`)
- **DetailedErrors**: Enabled for development debugging

### Syncfusion License
Make sure you have a valid Syncfusion license if using this in production. You can purchase or get a free trial at [Syncfusion.com](https://www.syncfusion.com/)

---

## 🔧 Common Tasks

### Add New Hotel Images
- Add images to the `wwwroot/images/` folder
- Reference them in the `HotelDataModel` with image IDs

### Modify Filtering Logic
- Edit the `ApplyFilters()` method in `HotelBooking.razor.cs`
- Add or remove filter conditions as needed

### Change Hotel Data
- The hotel data is loaded from `SampleData.GetHotels()`
- Edit this method to add, remove, or modify hotels

### Customize Styling
- Edit `HotelBooking.razor.css` for component-specific styles
- Edit `wwwroot/app.css` for global styles
- Edit `MainLayout.razor.css` for layout styles

---

## 🐛 Troubleshooting

| Issue | Solution |
|-------|----------|
| Blank page | Check browser console for errors; ensure all Syncfusion scripts are loaded |
| Images not showing | Verify image files exist in `wwwroot/images/` folder with correct names |
| Booking not working | Check form validation; ensure all required fields are filled |
| Dates not updating | Clear browser cache; check JavaScript console for errors |
| Maps not loading | Ensure internet connection; verify Syncfusion map data URLs are accessible |

---

## 📚 Resources

- [Blazor Documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/)
- [Syncfusion Blazor Components](https://www.syncfusion.com/blazor-components)
- [.NET Documentation](https://learn.microsoft.com/en-us/dotnet/)
- [Bootstrap Documentation](https://getbootstrap.com/)

---

## 📄 License

This project is built with Syncfusion components. Please refer to the Syncfusion license for usage rights.

---

## 👨‍💻 Development Notes

- **Framework**: Blazor Server with Interactive Server rendering mode
- **State Management**: Component-level state using C# properties
- **Validation**: Data Annotations for form validation
- **Styling**: Bootstrap + Custom CSS
- **Interactivity**: Server-side event handling

---

## 🎯 Future Enhancements

Possible improvements for future versions:
- User authentication and login system
- Payment gateway integration
- Email notifications for bookings
- Booking history and cancellation
- Customer reviews and ratings
- Admin panel for hotel management
- Database integration (currently uses in-memory data)
- Booking API integration
- Multi-language support

---

## ❓ Need Help?

If you encounter any issues:
1. Check the **Troubleshooting** section above
2. Review browser console for error messages
3. Check the Syncfusion documentation
4. Review the code comments in the Razor components

---

**Happy Booking! 🎉**
