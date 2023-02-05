using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeParkTycoonGame
{
    public abstract class Ride : BuildableObject
    {
        public abstract List<Stat> StatisticBoosts { get; }
        
    }
}
