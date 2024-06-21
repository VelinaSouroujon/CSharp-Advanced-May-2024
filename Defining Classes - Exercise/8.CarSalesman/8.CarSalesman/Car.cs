using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            Weight = weight;
        }
        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine, weight)
        {
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.AppendLine(Engine.ToString());

            sb.Append("  Weight: ");
            if(Weight == 0)
            {
                sb.AppendLine("n/a");
            }
            else
            {
                sb.AppendLine(Weight.ToString());
            }

            sb.Append("  Color: ");
            if(Color == null)
            {
                sb.AppendLine("n/a");
            }
            else
            {
                sb.AppendLine(Color);
            }
            return sb.ToString().Trim();
        }
    }
}
