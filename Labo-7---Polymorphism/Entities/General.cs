using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_7___Polymorphism.Entities
{
    internal class General : Machine
    {
        protected override int LifeSpanCostPerMinute => 1;

        public General(string name) :base(name)
        {
            
        }
        public override void Use(int numberOfMinutes)
        {
            base.LifeSpan -= numberOfMinutes * LifeSpanCostPerMinute;
        }

        public override string ToString()
        {
            return $"{base.Name} {base.LifeSpanInfo()}";
        }
    }
}
