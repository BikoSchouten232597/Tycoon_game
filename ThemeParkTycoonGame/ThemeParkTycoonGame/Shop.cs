using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeParkTycoonGame
{
    public abstract class Shop : BuildableObject
    {
        public abstract List<Product> ProductsForSale { get; }
        
    }
}
