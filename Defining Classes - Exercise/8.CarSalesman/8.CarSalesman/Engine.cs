using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            Displacement = displacement;
        }
        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency) 
            : this(model, power, displacement)
        {
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"  {Model}:");
            sb.AppendLine($"    Power: {Power}");

            sb.Append("    Displacement: ");          
            if(Displacement == 0)
            {
                sb.AppendLine("n/a");
            }
            else
            {
                sb.AppendLine(Displacement.ToString());
            }

            sb.Append("    Efficiency: ");
            if(Efficiency == null)
            {
                sb.AppendLine("n/a");
            }
            else
            {
                sb.AppendLine(Efficiency);
            }

            return sb.ToString().Trim();
        }
    }
}
