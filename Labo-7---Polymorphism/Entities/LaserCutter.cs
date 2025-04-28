using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_7___Polymorphism.Entities
{
    internal class LaserCutter : Router
    {
       
        public double Accuracy { get; set; }

        protected override int LifeSpanCostPerMinute => 1500;

        public LaserCutter(string name, double width, double length, double costPerMinute, double accuracy) : base(name, width, length, costPerMinute)
        {
            base.LifeSpan = 15000;
            this.Accuracy = accuracy;
        }

        public override void Use(int numberOfMinutes)
        {
           base.LifeSpan -= ((numberOfMinutes * LifeSpanCostPerMinute) + 100);
        }

        public override string ToString()
        {
            return $"LASER: '{base.Name}' ({base.WorkSpaceLength}x{base.WorkSpaceWidth}) [{this.Accuracy}] {base.LifeSpanInfo()}";
        }


    }
}
