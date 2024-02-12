using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic2
{
    internal abstract class Teams
    {
        public abstract string Name { get; set; }
        public abstract string Sport { get; set; }


    }

    internal class BasketBall : Teams
    {
        public BasketBall(string name, string sport)
        {
            Name = name;
            Sport = sport;
        }

        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Sport { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    internal class Football : Teams
    {
        public Football(string name, string sport)
        {
            Name = name;
            Sport = sport;
        }

        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Sport { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
