using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoCore.Models.Vehicles
{
    public class Car : Vehicle
    {
        public Car(string licensePlate) : base(licensePlate) {}
    }
}