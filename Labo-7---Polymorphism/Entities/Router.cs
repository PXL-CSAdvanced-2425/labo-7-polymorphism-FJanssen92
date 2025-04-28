using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_7___Polymorphism.Entities
{
    internal class Router : Machine
    {
        public double WorkSpaceWidth { get; set; }
        public double WorkSpaceLength { get; set; }
        public double CostPerMinute { get; set; }
        protected override int LifeSpanCostPerMinute => 50;

        public Router(string name, double width, double length, double costPerMinute) : base(name)
        {
            this.WorkSpaceWidth = width;
            this.WorkSpaceLength = length;
            this.CostPerMinute = costPerMinute;

            base.LifeSpan = 25000;
        }
        public override void Use(int numberOfMinutes)
        {
            base.LifeSpan -= (numberOfMinutes * LifeSpanCostPerMinute);
        }

        public override string ToString()
        {
            return $"ROUTER: '{base.Name}' ({this.WorkSpaceLength}x{this.WorkSpaceWidth}) {base.ToString()}";
        }


    }
}
