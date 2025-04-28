using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_7___Polymorphism.Entities
{
    internal abstract class Machine
    {
        #region Properties
        public string Name { get; set; }
        public int LifeSpan { get; set; }
        public float Price { get; set; }
        public bool OutOfUse => this.LifeSpan <= 0;
        //public bool OutOfUse
        //{
        //    get
        //    {
        //        return this.Price <= 0;
        //    }
        //}
        protected abstract int LifeSpanCostPerMinute { get; }
        #endregion

        #region Constructors
        protected Machine(string name)
        {
            this.Name = name;
        }
        #endregion
        #region Methods
        public abstract void Use(int numberOfMinutes);
        
        public string LifeSpanInfo()
        {
            if (this.OutOfUse)
            {
                return $"OUT OF USE OF <lifespan: {this.LifeSpan}>h";
            }
            else
            {
                return $"<lifespan: {this.LifeSpan}>h";
            }
        }

        public override string ToString()
        {
            return this.LifeSpanInfo();
        }
        #endregion
    }
}
