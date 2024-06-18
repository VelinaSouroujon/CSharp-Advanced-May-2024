using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.TruckTour
{
    internal class PetrolPump
    {
        public PetrolPump(int petrolAmount, int distanceToTheNextPump)
        {
            this.PetrolAmount = petrolAmount;
            this.DistanceToTheNextPump = distanceToTheNextPump;
        }
        public int PetrolAmount { get; set; }
        public int DistanceToTheNextPump { get; set; }
    }
}
