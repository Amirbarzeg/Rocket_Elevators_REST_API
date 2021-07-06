using System;
using System.Collections.Generic;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class Quotes
    {
        public long Id { get; set; }
        public string BuildingType { get; set; }
        public int? NumberOfFloors { get; set; }
        public int? NumberOfBasements { get; set; }
        public int? NumberOfcompanies { get; set; }
        public int? NumberOfParkingSpots { get; set; }
        public int? NumberOfElevators { get; set; }
        public int? NumberOfApartments { get; set; }
        public int? NumberOfCorporations { get; set; }
        public int? NumberOfOccupany { get; set; }
        public int? NumberOfBusinessHours { get; set; }
        public int? ElevatorAmount { get; set; }
        public int? ColumnAmount { get; set; }
        public string ProductLine { get; set; }
        public int? ElevatorUnitCost { get; set; }
        public int? ElevatorTotalCost { get; set; }
        public int? InstallationCost { get; set; }
        public int? TotalPrice { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
    }
}
