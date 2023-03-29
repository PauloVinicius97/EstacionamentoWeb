using EstacionamentoCore.Models.Parking;
using System;
using System.Collections.Generic;

namespace EstacionamentoCore.Models.Vehicles
{
    public class Vehicle
    {
        public Guid Id { get; protected set; }
        public string LicensePlate { get; protected set; }
        public string Type { get; protected set; }
        public List<ParkingSpot> ParkingSpotsTaken { get; protected set; }

        public Vehicle(string licensePlate)
        {
            this.LicensePlate = licensePlate;
            this.Id = Guid.NewGuid();
            ParkingSpotsTaken = new List<ParkingSpot>();
            this.Type = this.GetType().Name;
        }
    }
}