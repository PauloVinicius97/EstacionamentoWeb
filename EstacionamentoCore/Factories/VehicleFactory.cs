using EstacionamentoCore.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstacionamentoCore.Services
{
    public static class VehicleFactory
    {
        public static Vehicle GetNewVehicle(string type, string licensePlate)
        {
            Vehicle vehicle;

            if (type == "Moto")
            {
                vehicle = new Motorbike(licensePlate);
            }
            else if (type == "Carro")
            {
                vehicle = new Car(licensePlate);
            }
            else
            {
                vehicle = new Van(licensePlate);
            }

            return vehicle;
        }
    }
}
