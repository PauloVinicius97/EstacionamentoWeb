using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoCore.Models.Vehicles
{
    public class Motorbike : Vehicle
    {
        public Motorbike(string licensePlate) : base(licensePlate) {}
    }
}