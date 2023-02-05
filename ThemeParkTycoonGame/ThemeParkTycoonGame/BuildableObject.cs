using System.Drawing;

namespace ThemeParkTycoonGame
{
    public abstract class BuildableObject
    {
        public abstract string Name { get; }
        public abstract Image Image { get; }
        public virtual decimal EntryFee { get; set; }
        public virtual decimal Cost { get; }
        public virtual int powerNeed { get; }
        public virtual int numberOwned { get; set; }
        public virtual bool active { get; set; }
        public virtual int reputationGet { get; set; }


        
    }
}