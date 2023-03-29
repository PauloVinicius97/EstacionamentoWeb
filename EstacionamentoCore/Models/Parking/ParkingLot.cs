using EstacionamentoCore.Models.Constants;
using EstacionamentoCore.Models.Utils;
using EstacionamentoCore.Models.Vehicles;
using EstacionamentoCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EstacionamentoCore.Models.Parking
{
    public class ParkingLot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<ParkingSpot> ParkingSpots { get; private set; }

        public ParkingLot()
        {
            this.Id = Guid.NewGuid();
            this.ParkingSpots = new List<ParkingSpot>();
        }

        public Result CreateAndTryParkVehicle(string type, string licensePlate)
        {
            var vehicle = VehicleFactory.GetNewVehicle(type, licensePlate);

            return TryParkVehicle(vehicle);
        }

        public Result TryParkVehicle(Vehicle vehicle)
        {
            if (ParkingSpots.Any(p => p.Vehicle?.LicensePlate == vehicle.LicensePlate))
            {
                return new Result(false, "Veículo já está estacionado.");
            }

            var result = false;

            if (vehicle.Type == "Motorbike")
            {
                result = TryParkSmallVehicle(vehicle);
            }
            else if (vehicle.Type == "Car")
            {
                result = TryParkMediumVehicle(vehicle);
            }
            else if (vehicle.Type == "Van")
            {
                result = TryParkLargeVehicle(vehicle);
            }

            if (result)
            {
                return new Result(result, "Veículo estacionado com sucesso.");
            }

            return new Result(result, "Veículo não pôde ser estacionado.");
        }

        private bool TryParkSmallVehicle(Vehicle vehicle)
        {
            if (ParkingSpots.Any(p => p.Vehicle is null && p.Size.Equals(Size.Small)))
            {
                ParkVehicle(vehicle, Size.Small);

                return true;
            } 
            else if (ParkingSpots.Any(p => p.Vehicle is null))
            {
                ParkVehicle(vehicle);

                return true;
            }

            return false;
        }

        private bool TryParkMediumVehicle(Vehicle vehicle)
        {
            if (ParkingSpots.Any(p => p.Vehicle is null && p.Size.Equals(Size.Medium)))
            {
                ParkVehicle(vehicle, Size.Medium);

                return true;
            } 
            else if (ParkingSpots.Any(p => p.Vehicle is null && p.Size.Equals(Size.Big)))
            {
                ParkVehicle(vehicle, Size.Big);

                return true;
            }

            return false;
        }

        private bool TryParkLargeVehicle(Vehicle vehicle)
        {
            if (ParkingSpots.Any(p => p.Vehicle is null && p.Size.Equals(Size.Big)))
            {
                ParkVehicle(vehicle, Size.Big);

                return true;
            }
            else if (ParkingSpots.Where(p => p.Vehicle is null && p.Size.Equals(Size.Medium)).Count() >= 3)
            {
                for (var i = 0; i < 3; i++)
                {
                    ParkVehicle(vehicle, Size.Medium);
                }

                return true;
            }

            return false;
        }

        private void ParkVehicle(Vehicle vehicle, string size = null)
        {
            int freeParkingSpotIndex;

            if (size == null)
            {
                freeParkingSpotIndex = ParkingSpots.FindIndex(p => p.Vehicle is null);
            }
            else
            {
                freeParkingSpotIndex = ParkingSpots.FindIndex(p => p.Vehicle is null && p.Size.Equals(size));
            }

            ParkingSpots[freeParkingSpotIndex].ParkVehicle(vehicle);

            vehicle.ParkingSpotsTaken.Add(ParkingSpots[freeParkingSpotIndex]);
        }

        public Result UnparkVehicleByLicensePlate(string licensePlate)
        {
            var vehicles = GetVehicles();

            var selectedVehicle = vehicles
                .Where(v => v != null && v.LicensePlate == licensePlate)
                .FirstOrDefault();

            if (selectedVehicle != null)
            {
                foreach (var parkingSpot in selectedVehicle.ParkingSpotsTaken)
                {
                    ParkingSpots.Where(p => p.Id == parkingSpot.Id).FirstOrDefault().UnparkVehicle();
                }

                selectedVehicle.ParkingSpotsTaken.Clear();

                return new Result(true, "Carro removido do estacionamento.");
            }

            return new Result(false, "Carro não encontrado.");
        }

        public bool IsFull()
        {
            return ParkingSpots.Count() == ParkingSpots.Where(p => p.Vehicle != null).Count();
        }

        public bool IsEmpty()
        {
            if (ParkingSpots.Any(p => p.Vehicle != null))
            {
                return false;
            }

            return true;
        }

        public int NumberOfParkingSpots()
        {
            return ParkingSpots.Count();
        }

        public int RemainingParkingSpots()
        {
            return ParkingSpots.Where(p => p.Vehicle is null).Count();
        }

        public bool AllSpotsUsedBySize(string size)
        {
            if (ParkingSpots.Any(p => p.Size == size && p.Vehicle is null))
            {
                return false;
            }

            return true;
        }

        public int NumberOfVans()
        {
            var vehicles = GetVehicles();

            return vehicles.Where(v => v != null && v.Type.Equals("Van")).Count();
        }

        public List<Vehicle> GetVehicles()
        {
            return ParkingSpots
                .Select(p => p.Vehicle)
                .Where(v => v != null)
                .Distinct()
                .ToList();
        }
    }
}