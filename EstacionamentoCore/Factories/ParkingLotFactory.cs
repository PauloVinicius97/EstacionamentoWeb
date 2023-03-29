using EstacionamentoCore.Models.Constants;
using EstacionamentoCore.Models.Parking;
using System.Collections.Generic;

namespace EstacionamentoCore.Factories
{
    public static class ParkingLotFactory { 
        public static ParkingLot GetParkingLot
            (int numberOfSmallSpots, int numberOfMediumSpots, int numberOfBigSpots)
        {
            var parkingSpots = new List<ParkingSpot>();

            for (var i = 0; i < numberOfSmallSpots; i++)
            {
                parkingSpots.Add(new ParkingSpot($"Espaço pequeno {i}", Size.Small));
            }

            for (var i = 0; i < numberOfMediumSpots; i++)
            {
                parkingSpots.Add(new ParkingSpot($"Espaço médio {i}", Size.Medium));
            }

            for (var i = 0; i < numberOfBigSpots; i++)
            {
                parkingSpots.Add(new ParkingSpot($"Espaço grande {i}", Size.Big));
            }

            return new ParkingLot(parkingSpots);
        }
    }
}