using EstacionamentoCore.Models.Vehicles;
using System;

namespace EstacionamentoCore.Models.Parking
{
    public class ParkingSpot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Size { get; private set; }
        public Vehicle Vehicle { get; private set; }

        public ParkingSpot(string name, string size)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Size = size;
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            this.Vehicle = vehicle;
        }

        public void UnparkVehicle()
        {
            this.Vehicle = null;
        }
    }
}