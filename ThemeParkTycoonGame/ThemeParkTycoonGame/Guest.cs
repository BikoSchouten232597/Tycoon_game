using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeParkTycoonGame
{
    public class Guest
    {
        public string Name { get; set; }
        public Wallet Wallet { get; set; }
        public DateTime? TimeEntered { get; set; }
        
        public Guest()
        {
            // When a guest is first created, give them a random name!
            Name = NameGenerator.NextName();

            // Give this guest a wallet with 100 bucks
            Wallet = new Wallet();
            Wallet.Balance = 100;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
