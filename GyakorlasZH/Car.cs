using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyakorlasZH
{
    public class Car
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public string Full { get; set; }

        public Car(string name, int price, string type)
        {
            Name = name;
            Price = price;
            Type = type;
            Full = this.ToString();
        }

        public override string ToString()
        {
            return $"{Name}, {Price} Ft/nap ({Type})";
        }
    }
}
