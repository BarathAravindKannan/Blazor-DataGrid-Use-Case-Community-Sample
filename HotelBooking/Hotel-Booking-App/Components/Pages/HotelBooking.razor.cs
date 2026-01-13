namespace Hotel_booking_App.Components.Pages;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

public partial class HotelBooking : ComponentBase
{
    public List<HotelDataModel> Hotels { get; set; } = new List<HotelDataModel>();

    //treeview data source
    public List<AmenitiesModel> AmenitiesData = new List<AmenitiesModel>();
    public List<AmenitiesModel> RoomAmenitiesData = new List<AmenitiesModel>();
    private BookingDetails bookingModel = new BookingDetails();

    protected override void OnInitialized()
    {
        Hotels = SampleData.GetHotels();
        bookingModel.Region = SelectedCountryName;
        AllHotelCalculatedPrice();
        AmenitiesData.Add(new AmenitiesModel
        {
            Id = "1",
            Amenities = "Amenities",
            Expanded = true,
            HasChild = true
        });
        AmenitiesData.Add(new AmenitiesModel
        {
            Id = "2",
            ParentId = "1",
            Amenities = "Parking",
        });
        AmenitiesData.Add(new AmenitiesModel
        {
            Id = "3",
            ParentId = "1",
            Amenities = "Pet allowed"
        });
        AmenitiesData.Add(new AmenitiesModel
        {
            Id = "4",
            ParentId = "1",
            Amenities = "Swimming pool"
        });
        AmenitiesData.Add(new AmenitiesModel
        {
            Id = "5",
            ParentId = "1",
            Amenities = "Restaurant"
        });
        AmenitiesData.Add(new AmenitiesModel
        {
            Id = "6",
            ParentId = "1",
            Amenities = "Spa"
        });
        // Initialize RoomAmenitiesData
        RoomAmenitiesData.Add(new AmenitiesModel
        {
            Id = "7",
            Amenities = "Room Amenities",
            Expanded = true,
            HasChild = true
        });
        RoomAmenitiesData.Add(new AmenitiesModel
        {
            Id = "8",
            ParentId = "7",
            Amenities = "Television",
        });
        RoomAmenitiesData.Add(new AmenitiesModel
        {
            Id = "9",
            ParentId = "7",
            Amenities = "Projector"
        });
        RoomAmenitiesData.Add(new AmenitiesModel
        {
            Id = "10",
            ParentId = "7",
            Amenities = "Balcony"
        });
        RoomAmenitiesData.Add(new AmenitiesModel
        {
            Id = "11",
            ParentId = "7",
            Amenities = "Whiteboard"
        });
        RoomAmenitiesData.Add(new AmenitiesModel
        {
            Id = "12",
            ParentId = "7",
            Amenities = "Kitchen"
        });
        RoomAmenitiesData.Add(new AmenitiesModel
        {
            Id = "13",
            ParentId = "7",
            Amenities = "Internet"
        });
        RoomAmenitiesData.Add(new AmenitiesModel
        {
            Id = "14",
            ParentId = "7",
            Amenities = "Shower"
        });
        ApplyFilters();
    }

    public static class SampleData
    {
        public static List<HotelDataModel> GetHotels()
        {
            DateTime startDate1 = DateTime.Now;
            DateTime endDate1 = DateTime.Now.AddDays(2);

            DateTime startDate2 = endDate1.AddDays(1);
            DateTime endDate2 = startDate2.AddDays(2);
            return new List<HotelDataModel>
            {
                new HotelDataModel
                {
                    HotelID = 102278,
                    HotelName = "Benor Hotel",
                    Address = "59 rue de l'Abbaye",
                    Description = "We are a top hotel, providing comfort and luxury. Our warm hospitality makes every stay special. Enjoy a memorable experience with us.",
                    HotelImgID = "hotel_1",
                    Rating = 5,
                    ReviewCount = 20,
                    Location = new Location
                        { Latitude = 45.322690, Longitude = -106.781689, TooltipContent = "Benor Hotel, Montana" },
                    HotelFacility = new string[] { "Parking", "Pet allowed", "Swimming pool", "Restaurant" },
                    RoomID = 1,
                    RoomImgID = "room_1",
                    RoomName = "Alpha Room",
                    Capacity = 6,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 8,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation", "Credit card accepted", "Pay at visit" },
                    RoomFacility = new string[]
                        { "Television", "Projector", "Balcony", "Whiteboard", "Kitchen", "Internet", "Shower" },
                    Price = 500,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 102279,
                    HotelName = "Benor Hotel",
                    Address = "59 rue de l'Abbaye",
                    Description = "We are a top hotel, providing comfort and luxury. Our warm hospitality makes every stay special. Enjoy a memorable experience with us.",
                    HotelImgID = "hotel_1",
                    Rating = 5,
                    ReviewCount = 20,
                    Location = new Location
                        { Latitude = 45.322690, Longitude = -106.781689, TooltipContent = "Benor Hotel, Montana" },
                    HotelFacility = new string[] { "Parking", "Pet allowed", "Swimming pool", "Restaurant" },
                    RoomID = 2,
                    RoomImgID = "room_2",
                    RoomName = "Beta Room",
                    Capacity = 4,
                    ExtraBed = 2,
                    ExtraBedCost = 300,
                    DiscountPercentage = 9,
                    TaxPercentage = 6,
                    Extras = new string[] { "Credit card accepted", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Whiteboard", "Kitchen", "Internet" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 102280,
                    HotelName = "Benor Hotel",
                    Address = "59 rue de l'Abbaye",
                    Description = "We are a top hotel, providing comfort and luxury. Our warm hospitality makes every stay special. Enjoy a memorable experience with us.",
                    HotelImgID = "hotel_1",
                    Rating = 5,
                    ReviewCount = 20,
                    Location = new Location
                        { Latitude = 45.322690, Longitude = -106.781689, TooltipContent = "Benor Hotel, Montana" },
                    HotelFacility = new string[] { "Parking", "Pet allowed", "Swimming pool", "Restaurant" },
                    RoomID = 3,
                    RoomImgID = "room_3",
                    RoomName = "Gamma Room",
                    Capacity = 2,
                    ExtraBed = 2,
                    ExtraBedCost = 150,
                    DiscountPercentage = 6,
                    TaxPercentage = 3,
                    Extras = new string[] { "Free cancellation", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Internet" },
                    Price = 150,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 117823,
                    HotelName = "Zabator Hotel",
                    Address = "Luisenstr. 48",
                    Description = "Pleasent hotel for pleasent people.",
                    HotelImgID = "hotel_2",
                    Rating = 4,
                    ReviewCount = 30,
                    Location = new Location
                        { Latitude = 40.633829, Longitude = -73.967230, TooltipContent = "Zabator Hotel, New York" },
                    HotelFacility = new string[] { "Parking", "Swimming pool", "Restaurant" },
                    RoomID = 4,
                    RoomImgID = "room_4",
                    RoomName = "Alpha Room",
                    Capacity = 7,
                    ExtraBed = 5,
                    ExtraBedCost = 100,
                    DiscountPercentage = 10,
                    TaxPercentage = 7,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Television", "Projector", "Balcony", "Kitchen", "Internet" },
                    Price = 600,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 },
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 117824,
                    HotelName = "Zabator Hotel",
                    Address = "Luisenstr. 48",
                    Description = "Pleasent hotel for pleasent people.",
                    HotelImgID = "hotel_2",
                    Rating = 4,
                    ReviewCount = 30,
                    Location = new Location
                        { Latitude = 40.633829, Longitude = -73.967230, TooltipContent = "Zabator Hotel, New York" },
                    HotelFacility = new string[] { "Parking", "Swimming pool", "Restaurant" },
                    RoomID = 5,
                    RoomImgID = "room_5",
                    RoomName = "Beta Room",
                    Capacity = 3,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 7,
                    TaxPercentage = 4,
                    Extras = new string[] { "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Kitchen", "Internet" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 117825,
                    HotelName = "Zabator Hotel",
                    Address = "Luisenstr. 48",
                    Description = "Pleasent hotel for pleasent people.",
                    HotelImgID = "hotel_2",
                    Rating = 4,
                    ReviewCount = 30,
                    Location = new Location
                        { Latitude = 40.633829, Longitude = -73.967230, TooltipContent = "Zabator Hotel, New York" },
                    HotelFacility = new string[] { "Parking", "Swimming pool", "Restaurant" },
                    RoomID = 6,
                    RoomImgID = "room_6",
                    RoomName = "Gamma Room",
                    Capacity = 2,
                    ExtraBed = 3,
                    ExtraBedCost = 300,
                    DiscountPercentage = 5,
                    TaxPercentage = 2,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Television", "Internet" },
                    Price = 100,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 322211,
                    HotelName = "Ben Swikator",
                    Address = "Rua do Paço, 67",
                    Description = "Want to explore wave silent see in marvelous hotel.",
                    HotelImgID = "hotel_3",
                    Rating = 3,
                    ReviewCount = 18,
                    Location = new Location
                        { Latitude = 37.341648, Longitude = -121.197788, TooltipContent = "Ben Swikator, California" },
                    HotelFacility = new string[] { "Parking", "Restaurant", "Spa" },
                    RoomID = 7,
                    RoomImgID = "room_7",
                    RoomName = "Alpha Room",
                    Capacity = 5,
                    ExtraBed = 1,
                    ExtraBedCost = 500,
                    DiscountPercentage = 12,
                    TaxPercentage = 9,
                    Extras = new string[] { "Free cancellation", "Credit card accepted", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Kitchen", "Internet", "Shower" },
                    Price = 600,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 322212,
                    HotelName = "Ben Swikator",
                    Address = "Rua do Paço, 67",
                    Description = "Want to explore wave silent see in marvelous hotel.",
                    HotelImgID = "hotel_3",
                    Rating = 3,
                    ReviewCount = 18,
                    Location = new Location
                        { Latitude = 37.341648, Longitude = -121.197788, TooltipContent = "Ben Swikator, California" },
                    HotelFacility = new string[] { "Parking", "Restaurant", "Spa" },
                    RoomID = 8,
                    RoomImgID = "room_8",
                    RoomName = "Beta Room",
                    Capacity = 4,
                    ExtraBed = 3,
                    ExtraBedCost = 100,
                    DiscountPercentage = 8,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Television", "Internet", "Shower" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 322213,
                    HotelName = "Ben Swikator",
                    Address = "Rua do Paço, 67",
                    Description = "Want to explore wave silent see in marvelous hotel.",
                    HotelImgID = "hotel_3",
                    Rating = 3,
                    ReviewCount = 18,
                    Location = new Location
                        { Latitude = 37.341648, Longitude = -121.197788, TooltipContent = "Ben Swikator, California" },
                    HotelFacility = new string[] { "Parking", "Restaurant", "Spa" },
                    RoomID = 9,
                    RoomImgID = "room_9",
                    RoomName = "Gamma Room",
                    Capacity = 3,
                    ExtraBed = 3,
                    ExtraBedCost = 250,
                    DiscountPercentage = 8,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Internet", "Shower" },
                    Price = 150,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 112278,
                    HotelName = "Zentor Motel",
                    Address = "2, rue du Commerce",
                    Description = "We are the queen of the hotel.",
                    HotelImgID = "hotel_4",
                    Rating = 4,
                    ReviewCount = 35,
                    Location = new Location
                        { Latitude = 45.322690, Longitude = -106.781689, TooltipContent = "Zentor Motel, Montana" },
                    HotelFacility = new string[] { "Parking", "Pet allowed", "Swimming pool" },
                    RoomID = 10,
                    RoomImgID = "room_10",
                    RoomName = "Alpha Room",
                    Capacity = 6,
                    ExtraBed = 5,
                    ExtraBedCost = 300,
                    DiscountPercentage = 10,
                    TaxPercentage = 7,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[]
                        { "Television", "Projector", "Balcony", "Whiteboard", "Kitchen", "Internet", "Shower" },
                    Price = 500,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 112300,
                    HotelName = "Zentor Motel",
                    Address = "2, rue du Commerce",
                    Description = "We are the queen of the hotel.",
                    HotelImgID = "hotel_4",
                    Rating = 4,
                    ReviewCount = 35,
                    Location = new Location
                        { Latitude = 45.322690, Longitude = -106.781689, TooltipContent = "Zentor Motel, Montana" },
                    HotelFacility = new string[] { "Parking", "Pet allowed", "Swimming pool" },
                    RoomID = 11,
                    RoomImgID = "room_11",
                    RoomName = "Beta Room",
                    Capacity = 4,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 5,
                    TaxPercentage = 2,
                    Extras = new string[] { "Free cancellation", "Credit card accepted", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Whiteboard", "Kitchen", "Internet" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 112301,
                    HotelName = "Zentor Motel",
                    Address = "2, rue du Commerce",
                    Description = "We are the queen of the hotel.",
                    HotelImgID = "hotel_4",
                    Rating = 4,
                    ReviewCount = 35,
                    Location = new Location
                        { Latitude = 45.322690, Longitude = -106.781689, TooltipContent = "Zentor Motel, Montana" },
                    HotelFacility = new string[] { "Parking", "Pet allowed", "Swimming pool" },
                    RoomID = 12,
                    RoomImgID = "room_12",
                    RoomName = "Gamma Room",
                    Capacity = 2,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 8,
                    TaxPercentage = 3,
                    Extras = new string[] { "Free cancellation", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Internet" },
                    Price = 150,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 127823,
                    HotelName = "Bakator Hotel",
                    Address = "Boulevard Tirou, 255",
                    Description = "Pleasent hotel for sweet people.",
                    HotelImgID = "hotel_5",
                    Rating = 2,
                    ReviewCount = 15,
                    Location = new Location
                        { Latitude = 40.633829, Longitude = -73.967230, TooltipContent = "Bakator Hotel, New York" },
                    HotelFacility = new string[] { "Swimming pool", "Restaurant" },
                    RoomID = 13,
                    RoomImgID = "room_13",
                    RoomName = "Alpha Room",
                    Capacity = 7,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 8,
                    TaxPercentage = 2,
                    Extras = new string[] { "Free cancellation", "Credit card accepted", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Projector", "Balcony", "Kitchen", "Internet" },
                    Price = 600,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 },
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 127824,
                    HotelName = "Bakator Hotel",
                    Address = "Boulevard Tirou, 255",
                    Description = "Pleasent hotel for sweet people.",
                    HotelImgID = "hotel_5",
                    Rating = 2,
                    ReviewCount = 15,
                    Location = new Location
                        { Latitude = 40.633829, Longitude = -73.967230, TooltipContent = "Bakator Hotel, New York" },
                    HotelFacility = new string[] { "Swimming pool", "Restaurant" },
                    RoomID = 14,
                    RoomImgID = "room_14",
                    RoomName = "Beta Room",
                    Capacity = 3,
                    ExtraBed = 3,
                    ExtraBedCost = 50,
                    DiscountPercentage = 9,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Kitchen", "Internet" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 127825,
                    HotelName = "Bakator Hotel",
                    Address = "Boulevard Tirou, 255",
                    Description = "Pleasent hotel for sweet people.",
                    HotelImgID = "hotel_5",
                    Rating = 2,
                    ReviewCount = 15,
                    Location = new Location
                        { Latitude = 40.633829, Longitude = -73.967230, TooltipContent = "Bakator Hotel, New York" },
                    HotelFacility = new string[] { "Swimming pool", "Restaurant" },
                    RoomID = 15,
                    RoomImgID = "room_15",
                    RoomName = "Gamma Room",
                    Capacity = 2,
                    ExtraBed = 2,
                    ExtraBedCost = 200,
                    DiscountPercentage = 9,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Television", "Internet" },
                    Price = 100,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 332211,
                    HotelName = "Zen Swikator",
                    Address = "Rua do Paço, GG",
                    Description = "Want to explore a stunning, silent sea in a marvelous hotel? Experience tranquility and luxury with us. Enjoy a peaceful and unforgettable stay.",
                    HotelImgID = "hotel_6",
                    Rating = 5,
                    ReviewCount = 22,
                    Location = new Location
                        { Latitude = 37.341648, Longitude = -121.197788, TooltipContent = "Zen Swikator, California" },
                    HotelFacility = new string[] { "Restaurant" },
                    RoomID = 16,
                    RoomImgID = "room_16",
                    RoomName = "Alpha Room",
                    Capacity = 5,
                    ExtraBed = 1,
                    ExtraBedCost = 100,
                    DiscountPercentage = 7,
                    TaxPercentage = 3,
                    Extras = new string[] { "Free cancellation", "Credit card accepted", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Kitchen", "Internet", "Shower" },
                    Price = 600,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 332212,
                    HotelName = "Zen Swikator",
                    Address = "Rua do Paço, GG",
                    Description = "Want to explore a stunning, silent sea in a marvelous hotel? Experience tranquility and luxury with us. Enjoy a peaceful and unforgettable stay.",
                    HotelImgID = "hotel_6",
                    Rating = 5,
                    ReviewCount = 22,
                    Location = new Location
                        { Latitude = 37.341648, Longitude = -121.197788, TooltipContent = "Zen Swikator, California" },
                    HotelFacility = new string[] { "Restaurant" },
                    RoomID = 17,
                    RoomImgID = "room_17",
                    RoomName = "Beta Room",
                    Capacity = 4,
                    ExtraBed = 3,
                    ExtraBedCost = 500,
                    DiscountPercentage = 9,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Television", "Internet", "Shower" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 332213,
                    HotelName = "Zen Swikator",
                    Address = "Rua do Paço, GG",
                    Description = "Want to explore a stunning, silent sea in a marvelous hotel? Experience tranquility and luxury with us. Enjoy a peaceful and unforgettable stay.",
                    HotelImgID = "hotel_6",
                    Rating = 5,
                    ReviewCount = 22,
                    Location = new Location
                        { Latitude = 37.341648, Longitude = -121.197788, TooltipContent = "Zen Swikator, California" },
                    HotelFacility = new string[] { "Restaurant" },
                    RoomID = 18,
                    RoomImgID = "room_18",
                    RoomName = "Gamma Room",
                    Capacity = 3,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 8,
                    TaxPercentage = 5,
                    Extras = new string[] { "Pay at visit" },
                    RoomFacility = new string[] { "Internet", "Shower" },
                    Price = 150,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 342211,
                    HotelName = "Cen Zwikator",
                    Address = "Hauptstr. 31",
                    Description = "Want to explore a marvelous hotel? Experience luxury, comfort, and exceptional service. Stay with us for an unforgettable journey.",
                    HotelImgID = "hotel_7",
                    Rating = 5,
                    ReviewCount = 25,
                    Location = new Location
                        { Latitude = 37.341648, Longitude = -121.197788, TooltipContent = "Cen Zwikator, California" },
                    HotelFacility = new string[] { "Spa" },
                    RoomID = 19,
                    RoomImgID = "room_19",
                    RoomName = "Alpha Room",
                    Capacity = 5,
                    ExtraBed = 3,
                    ExtraBedCost = 50,
                    DiscountPercentage = 8,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation", "Credit card accepted", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Kitchen", "Internet", "Shower" },
                    Price = 600,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 342212,
                    HotelName = "Cen Zwikator",
                    Address = "Hauptstr. 31",
                    Description = "Want to explore a marvelous hotel? Experience luxury, comfort, and exceptional service. Stay with us for an unforgettable journey.",
                    HotelImgID = "hotel_7",
                    Rating = 5,
                    ReviewCount = 25,
                    Location = new Location
                        { Latitude = 37.341648, Longitude = -121.197788, TooltipContent = "Cen Zwikator, California" },
                    HotelFacility = new string[] { "Spa" },
                    RoomID = 20,
                    RoomImgID = "room_20",
                    RoomName = "Beta Room",
                    Capacity = 4,
                    ExtraBed = 2,
                    ExtraBedCost = 200,
                    DiscountPercentage = 9,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation", "Credit card accepted", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Internet", "Shower" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 342213,
                    HotelName = "Cen Zwikator",
                    Address = "Hauptstr. 31",
                    Description = "Want to explore a marvelous hotel? Experience luxury, comfort, and exceptional service. Stay with us for an unforgettable journey.",
                    HotelImgID = "hotel_7",
                    Rating = 5,
                    ReviewCount = 25,
                    Location = new Location
                        { Latitude = 37.341648, Longitude = -121.197788, TooltipContent = "Cen Zwikator, California" },
                    HotelFacility = new string[] { "Spa" },
                    RoomID = 21,
                    RoomImgID = "room_5",
                    RoomName = "Gamma Room",
                    Capacity = 3,
                    ExtraBed = 2,
                    ExtraBedCost = 200,
                    DiscountPercentage = 8,
                    TaxPercentage = 3,
                    Extras = new string[] { "Free cancellation", "Credit card accepted", "Pay at visit" },
                    RoomFacility = new string[] { "Internet", "Shower" },
                    Price = 150,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 132278,
                    HotelName = "Bekaor Hotel",
                    Address = "68 rue de l'Abbaye",
                    Description = "We have a variety of themed hotels, each offering a unique experience. Enjoy a stay that matches your style and preferences. Discover comfort with a creative touch.",
                    HotelImgID = "hotel_8",
                    Rating = 3,
                    ReviewCount = 30,
                    Location = new Location
                        { Latitude = 45.322690, Longitude = -106.781689, TooltipContent = "Bekaor Hotel, Montana" },
                    HotelFacility = new string[] { "Pet allowed", "Swimming pool", "Restaurant" },
                    RoomID = 22,
                    RoomImgID = "room_6",
                    RoomName = "Alpha Room",
                    Capacity = 3,
                    ExtraBed = 2,
                    ExtraBedCost = 200,
                    DiscountPercentage = 12,
                    TaxPercentage = 5,
                    Extras = new string[] { "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Kitchen", "Internet", "Shower" },
                    Price = 600,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 132279,
                    HotelName = "Bekaor Hotel",
                    Address = "68 rue de l'Abbaye",
                    Description = "We have a variety of themed hotels, each offering a unique experience. Enjoy a stay that matches your style and preferences. Discover comfort with a creative touch.",
                    HotelImgID = "hotel_8",
                    Rating = 3,
                    ReviewCount = 30,
                    Location = new Location
                        { Latitude = 45.322690, Longitude = -106.781689, TooltipContent = "Bekaor Hotel, Montana" },
                    HotelFacility = new string[] { "Pet allowed", "Swimming pool", "Restaurant" },
                    RoomID = 23,
                    RoomImgID = "room_7",
                    RoomName = "Beta Room",
                    Capacity = 4,
                    ExtraBed = 2,
                    ExtraBedCost = 400,
                    DiscountPercentage = 9,
                    TaxPercentage = 3,
                    Extras = new string[] { "Credit card accepted", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Whiteboard", "Kitchen" },
                    Price = 200,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 }
                    }
                },
                
                new HotelDataModel
                {
                    HotelID = 132280,
                    HotelName = "Bekaor Hotel",
                    Address = "68 rue de l'Abbaye",
                    Description = "We have a variety of themed hotels, each offering a unique experience. Enjoy a stay that matches your style and preferences. Discover comfort with a creative touch.",
                    HotelImgID = "hotel_8",
                    Rating = 3,
                    ReviewCount = 30,
                    Location = new Location
                        { Latitude = 45.322690, Longitude = -106.781689, TooltipContent = "Bekaor Hotel, Montana" },
                    HotelFacility = new string[] { "Pet allowed", "Swimming pool", "Restaurant" },
                    RoomID = 24,
                    RoomImgID = "room_8",
                    RoomName = "Gamma Room",
                    Capacity = 2,
                    ExtraBed = 2,
                    ExtraBedCost = 250,
                    DiscountPercentage = 6,
                    TaxPercentage = 3,
                    Extras = new string[] { "Free cancellation", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Internet" },
                    Price = 150,
                    CheckInOut = new List<CheckInOut>()
                },
                
                new HotelDataModel
                {
                    HotelID = 137823,
                    HotelName = "Zanator Hotel",
                    Address = "Luisenstr. 56",
                    Description = "A pleasant hotel for polite people. We offer comfort, warmth, and excellent service. Enjoy a relaxing and memorable stay with us.",
                    HotelImgID = "hotel_9",
                    Rating = 5,
                    ReviewCount = 50,
                    Location = new Location
                        { Latitude = 40.633829, Longitude = -73.967230, TooltipContent = "Zanator Hotel, New York" },
                    HotelFacility = new string[] { "Parking", "Pet allowed" },
                    RoomID = 25,
                    RoomImgID = "room_9",
                    RoomName = "Alpha Room",
                    Capacity = 5,
                    ExtraBed = 1,
                    ExtraBedCost = 400,
                    DiscountPercentage = 10,
                    TaxPercentage = 6,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Television", "Projector", "Balcony" },
                    Price = 600,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 },
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 137824,
                    HotelName = "Zanator Hotel",
                    Address = "Luisenstr. 56",
                    Description = "A pleasant hotel for polite people. We offer comfort, warmth, and excellent service. Enjoy a relaxing and memorable stay with us.",
                    HotelImgID = "hotel_9",
                    Rating = 5,
                    ReviewCount = 50,
                    Location = new Location
                        { Latitude = 40.633829, Longitude = -73.967230, TooltipContent = "Zanator Hotel, New York" },
                    HotelFacility = new string[] { "Parking", "Pet allowed" },
                    RoomID = 26,
                    RoomImgID = "room_10",
                    RoomName = "Beta Room",
                    Capacity = 3,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 7,
                    TaxPercentage = 4,
                    Extras = new string[] { "Pay at visit", "Credit card accepted" },
                    RoomFacility = new string[] { "Television", "Internet" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 137825,
                    HotelName = "Zanator Hotel",
                    Address = "Luisenstr. 56",
                    Description = "A pleasant hotel for polite people. We offer comfort, warmth, and excellent service. Enjoy a relaxing and memorable stay with us.",
                    HotelImgID = "hotel_9",
                    Rating = 5,
                    ReviewCount = 50,
                    Location = new Location
                        { Latitude = 40.633829, Longitude = -73.967230, TooltipContent = "Zanator Hotel, New York" },
                    HotelFacility = new string[] { "Parking", "Pet allowed" },
                    RoomID = 27,
                    RoomImgID = "room_11",
                    RoomName = "Gamma Room",
                    Capacity = 2,
                    ExtraBed = 4,
                    ExtraBedCost = 300,
                    DiscountPercentage = 8,
                    TaxPercentage = 2,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Television", "Internet" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 343211,
                    HotelName = "Bentoo Swikator",
                    Address = "66, RuRua do Paço",
                    Description = "Want to experience the gentle, shifting waves of the silent ocean? Embrace tranquility and beauty as you explore the serene waters. Let the oceans calmness refresh your soul.",
                    HotelImgID = "hotel_10",
                    Rating = 2,
                    ReviewCount = 50,
                    Location = new Location
                    {
                        Latitude = 37.341648, Longitude = -121.197788, TooltipContent = "Bentoo Swikator, California"
                    },
                    HotelFacility = new string[] { "Parking", "Restaurant", "Spa" },
                    RoomID = 28,
                    RoomImgID = "room_12",
                    RoomName = "Alpha Room",
                    Capacity = 5,
                    ExtraBed = 2,
                    ExtraBedCost = 200,
                    DiscountPercentage = 12,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Kitchen" },
                    Price = 400,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 343212,
                    HotelName = "Bentoo Swikator",
                    Address = "66, RuRua do Paço",
                    Description = "Want to experience the gentle, shifting waves of the silent ocean? Embrace tranquility and beauty as you explore the serene waters. Let the oceans calmness refresh your soul.",
                    HotelImgID = "hotel_10",
                    Rating = 2,
                    ReviewCount = 50,
                    Location = new Location
                    {
                        Latitude = 37.341648, Longitude = -121.197788, TooltipContent = "Bentoo Swikator, California"
                    },
                    HotelFacility = new string[] { "Parking", "Restaurant", "Spa" },
                    RoomID = 29,
                    RoomImgID = "room_13",
                    RoomName = "Beta Room",
                    Capacity = 4,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 8,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Internet", "Shower" },
                    Price = 500,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 343213,
                    HotelName = "Bentoo Swikator",
                    Address = "66, RuRua do Paço",
                    Description = "Want to experience the gentle, shifting waves of the silent ocean? Embrace tranquility and beauty as you explore the serene waters. Let the oceans calmness refresh your soul.",
                    HotelImgID = "hotel_10",
                    Rating = 2,
                    ReviewCount = 50,
                    Location = new Location
                    {
                        Latitude = 37.341648, Longitude = -121.197788, TooltipContent = "Bentoo Swikator, California"
                    },
                    HotelFacility = new string[] { "Parking", "Restaurant", "Spa" },
                    RoomID = 30,
                    RoomImgID = "room_14",
                    RoomName = "Gamma Room",
                    Capacity = 3,
                    ExtraBed = 3,
                    ExtraBedCost = 250,
                    DiscountPercentage = 8,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Internet", "Shower" },
                    Price = 250,
                    CheckInOut = new List<CheckInOut> { new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 } }
                },
                new HotelDataModel
                {
                    HotelID = 142278,
                    HotelName = "ZZntor Hotel",
                    Address = "333, rue du Commerce",
                    Description = "We are an award-winning hotel, offering exceptional service and luxury. Experience the best in hospitality with us. Your perfect stay starts here.",
                    HotelImgID = "hotel_11",
                    Rating = 4,
                    ReviewCount = 35,
                    Location = new Location
                        { Latitude = 45.322690, Longitude = -106.781689, TooltipContent = "ZZntor Hotel, Montana" },
                    HotelFacility = new string[] { "Parking", "Swimming pool" },
                    RoomID = 31,
                    RoomImgID = "room_15",
                    RoomName = "Alpha Room",
                    Capacity = 6,
                    ExtraBed = 5,
                    ExtraBedCost = 300,
                    DiscountPercentage = 10,
                    TaxPercentage = 6,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Television", "Whiteboard", "Kitchen", "Internet", "Shower" },
                    Price = 220,
                    CheckInOut = new List<CheckInOut> { new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 } }
                },
                new HotelDataModel
                {
                    HotelID = 142279,
                    HotelName = "ZZntor Hotel",
                    Address = "333, rue du Commerce",
                    Description = "We are an award-winning hotel, offering exceptional service and luxury. Experience the best in hospitality with us. Your perfect stay starts here.",
                    HotelImgID = "hotel_11",
                    Rating = 4,
                    ReviewCount = 35,
                    Location = new Location
                        { Latitude = 45.322690, Longitude = -106.781689, TooltipContent = "ZZntor Hotel, Montana" },
                    HotelFacility = new string[] { "Parking", "Swimming pool" },
                    RoomID = 32,
                    RoomImgID = "room_16",
                    RoomName = "Beta Room",
                    Capacity = 4,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 5,
                    TaxPercentage = 2,
                    Extras = new string[] { "Pay at visit" },
                    RoomFacility = new string[] { "Whiteboard", "Kitchen", "Internet" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut> { new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 } }
                },
                new HotelDataModel
                {
                    HotelID = 142280,
                    HotelName = "ZZntor Hotel",
                    Address = "333, rue du Commerce",
                    Description = "We are an award-winning hotel, offering exceptional service and luxury. Experience the best in hospitality with us. Your perfect stay starts here.",
                    HotelImgID = "hotel_11",
                    Rating = 4,
                    ReviewCount = 35,
                    Location = new Location
                        { Latitude = 45.322690, Longitude = -106.781689, TooltipContent = "ZZntor Hotel, Montana" },
                    HotelFacility = new string[] { "Parking", "Swimming pool" },
                    RoomID = 33,
                    RoomImgID = "room_1",
                    RoomName = "Gamma Room",
                    Capacity = 2,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 8,
                    TaxPercentage = 3,
                    Extras = new string[] { "Free cancellation", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Internet" },
                    Price = 150,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 129823,
                    HotelName = "Oakator Hotel",
                    Address = "255, RU Boulevard Tirou",
                    Description = "Pleasent hotel for sweet people.",
                    HotelImgID = "hotel_1",
                    Rating = 5,
                    ReviewCount = 50,
                    Location = new Location
                        { Latitude = 40.633829, Longitude = -73.967230, TooltipContent = "Oakator Hotel, New York" },
                    HotelFacility = new string[] { "Swimming pool", "Restaurant" },
                    RoomID = 34,
                    RoomImgID = "room_2",
                    RoomName = "Alpha Room",
                    Capacity = 7,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 8,
                    TaxPercentage = 2,
                    Extras = new string[] { "Credit card accepted" },
                    RoomFacility = new string[] { "Projector", "Balcony", "Kitchen", "Internet" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut> { new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 } }
                },
                new HotelDataModel
                {
                    HotelID = 129824,
                    HotelName = "Oakator Hotel",
                    Address = "255, RU Boulevard Tirou",
                    Description = "Pleasent hotel for sweet people.",
                    HotelImgID = "hotel_1",
                    Rating = 5,
                    ReviewCount = 50,
                    Location = new Location
                        { Latitude = 40.633829, Longitude = -73.967230, TooltipContent = "Oakator Hotel, New York" },
                    HotelFacility = new string[] { "Swimming pool", "Restaurant" },
                    RoomID = 35,
                    RoomImgID = "room_3",
                    RoomName = "Beta Room",
                    Capacity = 3,
                    ExtraBed = 3,
                    ExtraBedCost = 50,
                    DiscountPercentage = 9,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Kitchen", "Internet" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut> { new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 } }
                },
                new HotelDataModel
                {
                    HotelID = 129825,
                    HotelName = "Oakator Hotel",
                    Address = "255, RU Boulevard Tirou",
                    Description = "Pleasent hotel for sweet people.",
                    HotelImgID = "hotel_1",
                    Rating = 5,
                    ReviewCount = 50,
                    Location = new Location
                        { Latitude = 40.633829, Longitude = -73.967230, TooltipContent = "Oakator Hotel, New York" },
                    HotelFacility = new string[] { "Swimming pool", "Restaurant" },
                    RoomID = 36,
                    RoomImgID = "room_4",
                    RoomName = "Gamma Room",
                    Capacity = 2,
                    ExtraBed = 4,
                    ExtraBedCost = 300,
                    DiscountPercentage = 8,
                    TaxPercentage = 2,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Television", "Internet" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut> { new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 } }
                },

                new HotelDataModel
                {
                    HotelID = 332221,
                    HotelName = "ZenZen Swikator",
                    Address = "66, Rua do Paço, GG",
                    Description = "Want to explore stunning silent see in a marvelous hotel.",
                    HotelImgID = "hotel_2",
                    Rating = 3,
                    ReviewCount = 22,
                    Location = new Location
                    {
                        Latitude = 37.341648,
                        Longitude = -121.197788,
                        TooltipContent = "ZenZen Swikator, California"
                    },
                    HotelFacility = new string[] { "Restaurant" },
                    RoomID = 37,
                    RoomImgID = "room_5",
                    RoomName = "Alpha Room",
                    Capacity = 5,
                    ExtraBed = 1,
                    ExtraBedCost = 200,
                    DiscountPercentage = 7,
                    TaxPercentage = 3,
                    Extras = new string[] { "Free cancellation", "Credit card accepted", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Internet", "Shower" },
                    Price = 330,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 332222,
                    HotelName = "ZenZen Swikator",
                    Address = "66, Rua do Paço, GG",
                    Description = "Want to explore stunning silent see in a marvelous hotel.",
                    HotelImgID = "hotel_2",
                    Rating = 3,
                    ReviewCount = 22,
                    Location = new Location
                    {
                        Latitude = 37.341648,
                        Longitude = -121.197788,
                        TooltipContent = "ZenZen Swikator, California"
                    },
                    HotelFacility = new string[] { "Restaurant" },
                    RoomID = 38,
                    RoomImgID = "room_6",
                    RoomName = "Beta Room",
                    Capacity = 4,
                    ExtraBed = 3,
                    ExtraBedCost = 500,
                    DiscountPercentage = 9,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Television", "Internet", "Shower" },
                    Price = 600,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 332223,
                    HotelName = "ZenZen Swikator",
                    Address = "66, Rua do Paço, GG",
                    Description = "Want to explore stunning silent see in a marvelous hotel.",
                    HotelImgID = "hotel_2",
                    Rating = 3,
                    ReviewCount = 22,
                    Location = new Location
                    {
                        Latitude = 37.341648,
                        Longitude = -121.197788,
                        TooltipContent = "ZenZen Swikator, California"
                    },
                    HotelFacility = new string[] { "Restaurant" },
                    RoomID = 39,
                    RoomImgID = "room_7",
                    RoomName = "Gamma Room",
                    Capacity = 3,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 8,
                    TaxPercentage = 5,
                    Extras = new string[] { "Pay at visit" },
                    RoomFacility = new string[] { "Internet", "Shower" },
                    Price = 150,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 342311,
                    HotelName = "CenCake Owikator",
                    Address = "Hauptstr. 31 Mt GG",
                    Description = "Want to explore a marvelous hotel in marvelous Ocean.",
                    HotelImgID = "hotel_3",
                    Rating = 3,
                    ReviewCount = 30,
                    Location = new Location
                    {
                        Latitude = 37.341648,
                        Longitude = -121.197788,
                        TooltipContent = "CenCake Owikator, California"
                    },
                    HotelFacility = new string[] { "Spa" },
                    RoomID = 40,
                    RoomImgID = "room_8",
                    RoomName = "Alpha Room",
                    Capacity = 5,
                    ExtraBed = 3,
                    ExtraBedCost = 50,
                    DiscountPercentage = 8,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation", "Credit card accepted", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Kitchen", "Internet", "Shower" },
                    Price = 600,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 342312,
                    HotelName = "CenCake Owikator",
                    Address = "Hauptstr. 31 Mt GG",
                    Description = "Want to explore a marvelous hotel in marvelous Ocean.",
                    HotelImgID = "hotel_3",
                    Rating = 3,
                    ReviewCount = 30,
                    Location = new Location
                    {
                        Latitude = 37.341648,
                        Longitude = -121.197788,
                        TooltipContent = "CenCake Owikator, California"
                    },
                    HotelFacility = new string[] { "Spa" },
                    RoomID = 41,
                    RoomImgID = "room_9",
                    RoomName = "Beta Room",
                    Capacity = 4,
                    ExtraBed = 2,
                    ExtraBedCost = 200,
                    DiscountPercentage = 9,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation", "Credit card accepted", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Internet", "Shower" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 342313,
                    HotelName = "CenCake Owikator",
                    Address = "Hauptstr. 31 Mt GG",
                    Description = "Want to explore a marvelous hotel in marvelous Ocean.",
                    HotelImgID = "hotel_3",
                    Rating = 3,
                    ReviewCount = 30,
                    Location = new Location
                    {
                        Latitude = 37.341648,
                        Longitude = -121.197788,
                        TooltipContent = "CenCake Owikator, California"
                    },
                    HotelFacility = new string[] { "Spa" },
                    RoomID = 42,
                    RoomImgID = "room_10",
                    RoomName = "Gamma Room",
                    Capacity = 3,
                    ExtraBed = 2,
                    ExtraBedCost = 200,
                    DiscountPercentage = 8,
                    TaxPercentage = 2,
                    Extras = new string[] { "Free cancellation", "Credit card accepted", "Pay at visit" },
                    RoomFacility = new string[] { "Internet" },
                    Price = 550,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 192278,
                    HotelName = "Zekaorza Hotel",
                    Address = "68 rue de l'Abbaye GG",
                    Description = "We have different theme hotel.",
                    HotelImgID = "hotel_4",
                    Rating = 1,
                    ReviewCount = 30,
                    Location = new Location
                    {
                        Latitude = 45.322690,
                        Longitude = -106.781689,
                        TooltipContent = "Zekaorza Hotel, Montana"
                    },
                    HotelFacility = new string[] { "Pet allowed", "Swimming pool", "Restaurant" },
                    RoomID = 43,
                    RoomImgID = "room_13",
                    RoomName = "Gamma Room",
                    Capacity = 2,
                    ExtraBed = 2,
                    ExtraBedCost = 250,
                    DiscountPercentage = 6,
                    TaxPercentage = 2,
                    Extras = new string[] { "Free cancellation", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Internet" },
                    Price = 250,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 192279,
                    HotelName = "Zekaorza Hotel",
                    Address = "68 rue de l'Abbaye GG",
                    Description = "We have different theme hotel.",
                    HotelImgID = "hotel_4",
                    Rating = 1,
                    ReviewCount = 30,
                    Location = new Location
                    {
                        Latitude = 45.322690,
                        Longitude = -106.781689,
                        TooltipContent = "Zekaorza Hotel, Montana"
                    },
                    HotelFacility = new string[] { "Pet allowed", "Swimming pool", "Restaurant" },
                    RoomID = 44,
                    RoomImgID = "room_11",
                    RoomName = "Alpha Room",
                    Capacity = 3,
                    ExtraBed = 2,
                    ExtraBedCost = 200,
                    DiscountPercentage = 12,
                    TaxPercentage = 5,
                    Extras = new string[] { "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Kitchen", "Internet", "Shower" },
                    Price = 100,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 192280,
                    HotelName = "Zekaorza Hotel",
                    Address = "68 rue de l'Abbaye GG",
                    Description = "We have different theme hotel.",
                    HotelImgID = "hotel_4",
                    Rating = 1,
                    ReviewCount = 30,
                    Location = new Location
                    {
                        Latitude = 45.322690,
                        Longitude = -106.781689,
                        TooltipContent = "Zekaorza Hotel, Montana"
                    },
                    HotelFacility = new string[] { "Pet allowed", "Swimming pool", "Restaurant" },
                    RoomID = 45,
                    RoomImgID = "room_12",
                    RoomName = "Beta Room",
                    Capacity = 4,
                    ExtraBed = 2,
                    ExtraBedCost = 400,
                    DiscountPercentage = 9,
                    TaxPercentage = 3,
                    Extras = new string[] { "Credit card accepted", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Whiteboard", "Kitchen" },
                    Price = 600,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 197823,
                    HotelName = "Zabatorza Hotel",
                    Address = "Luisenstr. 56 GG",
                    Description = "Pleasent hotel for polite people.",
                    HotelImgID = "hotel_5",
                    Rating = 3,
                    ReviewCount = 10,
                    Location = new Location
                    {
                        Latitude = 40.633829,
                        Longitude = -73.967230,
                        TooltipContent = "Zabatorza Hotel, New York"
                    },
                    HotelFacility = new string[] { "Parking", "Pet allowed" },
                    RoomID = 46,
                    RoomImgID = "room_14",
                    RoomName = "Alpha Room",
                    Capacity = 5,
                    ExtraBed = 1,
                    ExtraBedCost = 400,
                    DiscountPercentage = 10,
                    TaxPercentage = 6,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Television", "Projector", "Balcony" },
                    Price = 700,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 },
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 197824,
                    HotelName = "Zabatorza Hotel",
                    Address = "Luisenstr. 56 GG",
                    Description = "Pleasent hotel for polite people.",
                    HotelImgID = "hotel_5",
                    Rating = 3,
                    ReviewCount = 10,
                    Location = new Location
                    {
                        Latitude = 40.633829,
                        Longitude = -73.967230,
                        TooltipContent = "Zabatorza Hotel, New York"
                    },
                    HotelFacility = new string[] { "Parking", "Pet allowed" },
                    RoomID = 47,
                    RoomImgID = "room_15",
                    RoomName = "Beta Room",
                    Capacity = 3,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 7,
                    TaxPercentage = 2,
                    Extras = new string[] { "Pay at visit", "Credit card accepted" },
                    RoomFacility = new string[] { "Television", "Internet" },
                    Price = 500,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 197825,
                    HotelName = "Zabatorza Hotel",
                    Address = "Luisenstr. 56 GG",
                    Description = "Pleasent hotel for polite people.",
                    HotelImgID = "hotel_5",
                    Rating = 3,
                    ReviewCount = 10,
                    Location = new Location
                    {
                        Latitude = 40.633829,
                        Longitude = -73.967230,
                        TooltipContent = "Zabatorza Hotel, New York"
                    },
                    HotelFacility = new string[] { "Parking", "Pet allowed" },
                    RoomID = 48,
                    RoomImgID = "room_16",
                    RoomName = "Gamma Room",
                    Capacity = 2,
                    ExtraBed = 4,
                    ExtraBedCost = 300,
                    DiscountPercentage = 8,
                    TaxPercentage = 2,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Television" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 393211,
                    HotelName = "Saentoo Swikator",
                    Address = "66,RuRua do Paço",
                    Description = "Want to explore shift silent water wave in ocean.",
                    HotelImgID = "hotel_6",
                    Rating = 3,
                    ReviewCount = 10,
                    Location = new Location
                    {
                        Latitude = 37.341648,
                        Longitude = -121.197788,
                        TooltipContent = "Saentoo Swikator, California"
                    },
                    HotelFacility = new string[] { "Parking", "Restaurant", "Spa" },
                    RoomID = 49,
                    RoomImgID = "room_1",
                    RoomName = "Alpha Room",
                    Capacity = 5,
                    ExtraBed = 2,
                    ExtraBedCost = 200,
                    DiscountPercentage = 12,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Kitchen" },
                    Price = 700,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 393212,
                    HotelName = "Saentoo Swikator",
                    Address = "66,RuRua do Paço",
                    Description = "Want to explore shift silent water wave in ocean.",
                    HotelImgID = "hotel_6",
                    Rating = 3,
                    ReviewCount = 10,
                    Location = new Location
                    {
                        Latitude = 37.341648,
                        Longitude = -121.197788,
                        TooltipContent = "Saentoo Swikator, California"
                    },
                    HotelFacility = new string[] { "Parking", "Restaurant", "Spa" },
                    RoomID = 50,
                    RoomImgID = "room_2",
                    RoomName = "Beta Room",
                    Capacity = 4,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 8,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Internet", "Shower" },
                    Price = 300,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 393213,
                    HotelName = "Saentoo Swikator",
                    Address = "66,RuRua do Paço",
                    Description = "Want to explore shift silent water wave in ocean.",
                    HotelImgID = "hotel_6",
                    Rating = 3,
                    ReviewCount = 10,
                    Location = new Location
                    {
                        Latitude = 37.341648,
                        Longitude = -121.197788,
                        TooltipContent = "Saentoo Swikator, California"
                    },
                    HotelFacility = new string[] { "Parking", "Restaurant", "Spa" },
                    RoomID = 51,
                    RoomImgID = "room_3",
                    RoomName = "Gamma Room",
                    Capacity = 3,
                    ExtraBed = 3,
                    ExtraBedCost = 250,
                    DiscountPercentage = 8,
                    TaxPercentage = 5,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Internet", "Shower" },
                    Price = 250,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 199278,
                    HotelName = "Zoontor Hotel",
                    Address = "333, rue du Commerce",
                    Description = "We are the winner hotel.",
                    HotelImgID = "hotel_7",
                    Rating = 1,
                    ReviewCount = 35,
                    Location = new Location
                    {
                        Latitude = 45.322690,
                        Longitude = -106.781689,
                        TooltipContent = "Zoontor Hotel, Montana"
                    },
                    HotelFacility = new string[] { "Parking", "Swimming pool" },
                    RoomID = 52,
                    RoomImgID = "room_4",
                    RoomName = "Alpha Room",
                    Capacity = 6,
                    ExtraBed = 5,
                    ExtraBedCost = 300,
                    DiscountPercentage = 10,
                    TaxPercentage = 6,
                    Extras = new string[] { "Free cancellation" },
                    RoomFacility = new string[] { "Television", "Whiteboard", "Kitchen", "Internet", "Shower" },
                    Price = 290,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 199279,
                    HotelName = "Zoontor Hotel",
                    Address = "333, rue du Commerce",
                    Description = "We are the winner hotel.",
                    HotelImgID = "hotel_7",
                    Rating = 1,
                    ReviewCount = 35,
                    Location = new Location
                    {
                        Latitude = 45.322690,
                        Longitude = -106.781689,
                        TooltipContent = "Zoontor Hotel, Montana"
                    },
                    HotelFacility = new string[] { "Parking", "Swimming pool" },
                    RoomID = 53,
                    RoomImgID = "room_5",
                    RoomName = "Beta Room",
                    Capacity = 4,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 8,
                    TaxPercentage = 3,
                    Extras = new string[] { "Pay at visit" },
                    RoomFacility = new string[] { "Whiteboard", "Kitchen", "Internet" },
                    Price = 100,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate1, CheckOut = endDate1 }
                    }
                },
                new HotelDataModel
                {
                    HotelID = 199280,
                    HotelName = "Zoontor Hotel",
                    Address = "333, rue du Commerce",
                    Description = "We are the winner hotel.",
                    HotelImgID = "hotel_7",
                    Rating = 1,
                    ReviewCount = 35,
                    Location = new Location
                    {
                        Latitude = 45.322690,
                        Longitude = -106.781689,
                        TooltipContent = "Zoontor Hotel, Montana"
                    },
                    HotelFacility = new string[] { "Parking", "Swimming pool" },
                    RoomID = 54,
                    RoomImgID = "room_6",
                    RoomName = "Gamma Room",
                    Capacity = 2,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 8,
                    TaxPercentage = 3,
                    Extras = new string[] { "Free cancellation", "Pay at visit" },
                    RoomFacility = new string[] { "Television", "Internet" },
                    Price = 150,
                    CheckInOut = new List<CheckInOut>()
                },
                new HotelDataModel
                {
                    HotelID = 199923,
                    HotelName = "Sasktor Hotel",
                    Address = "255, RU Boulevard Tirou GG",
                    Description = "Pleasent hotel for sweet people.",
                    HotelImgID = "hotel_8",
                    Rating = 2,
                    ReviewCount = 50,
                    Location = new Location
                    {
                        Latitude = 40.633829,
                        Longitude = -73.967230,
                        TooltipContent = "Sasktor Hotel, New York"
                    },
                    HotelFacility = new string[] { "Swimming pool", "Restaurant" },
                    RoomID = 55,
                    RoomImgID = "room_7",
                    RoomName = "Alpha Room",
                    Capacity = 3,
                    ExtraBed = 3,
                    ExtraBedCost = 200,
                    DiscountPercentage = 8,
                    TaxPercentage = 2,
                    Extras = new string[] { "Credit card accepted" },
                    RoomFacility = new string[] { "Projector", "Balcony", "Kitchen", "Internet" },
                    Price = 290,
                    CheckInOut = new List<CheckInOut>
                    {
                        new CheckInOut { CheckIn = startDate2, CheckOut = endDate2 }
                    }
                }

            };

        }
    }
}
