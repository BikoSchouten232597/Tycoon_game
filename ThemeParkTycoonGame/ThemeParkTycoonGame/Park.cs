using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeParkTycoonGame
{
    public class Park
    {
        public delegate void NameChangingEvent(object sender, NameChangingEventArgs e);
        public event NameChangingEvent NameChanging;

        public delegate void GuestEnteredEvent(object sender, GuestEnteredEventArgs e);
        public event GuestEnteredEvent GuestEntered;

        public delegate void WeatherChangedEvent(object sender, WeatherChangedEventArgs e);
        public event WeatherChangedEvent WeatherChanged;
        
        public List<Guest> Guests { get; set; }
        public Wallet ParkManagerWallet { get; set; }
        public List<Ride> buyableRides = new List<Ride>();
        public List<int> allPersonals = new List<int>();
        public int parkPower = 0;
        public Dictionary<Ride, bool> ridesActive = new Dictionary<Ride, bool>();
        public decimal EntryFee { get; set; }

        public ulong reputation = 300;
        public int parkUpgrades = 0;

        public int  openingTime = 6;
        public int closingTime = 21;

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                DoNameChange(value);
            }
        }

        private Weather currentWeather;
        public Weather CurrentWeather
        {
            get
            {
                return currentWeather;
            }
            set
            {
                DoChangeWeather(value);
            }
        }
        public void AddRide(Ride ride)
        {
            buyableRides.Add(ride);
        }
        public Park()
        {
            Guests = new List<Guest>();
            ParkManagerWallet = new Wallet();

            DoChangeWeather();
        }

        public void AddGuest(Guest guest)
        {
            // Set the time entered if not set already
            if(guest.TimeEntered == null)
            {
                guest.TimeEntered = DateTime.Now;

                // Charge the entry fee
                guest.Wallet.Balance -= EntryFee;

                // Add the entry fee to the park manager's wallet
                ParkManagerWallet.Balance += EntryFee;
            }

            // Add the guest to the guest list (so we can retrieve them later)
            Guests.Add(guest);

            // Check if someone is handling this event
            if(GuestEntered != null)
            {
                GuestEntered.Invoke(this, new GuestEnteredEventArgs()
                {
                    Guest = guest,
                });
            }
        }

        public void DoChangeWeather(Weather weather = null)
        {
            // If no weather is given a random weather type should be selected.
            if(weather == null)
            {
                weather = Weather.GetRandom();
            }

            // Check if someone is handling this event
            if (WeatherChanged != null)
            {
                WeatherChanged.Invoke(this, new WeatherChangedEventArgs()
                {
                    OldWeather = this.CurrentWeather,
                    Weather = weather
                });
            }

            currentWeather = weather;
        }

        public void DoNameChange(string newName)
        {
            // Create event arguments that will inform the event handlers
            NameChangingEventArgs eventArgs = new NameChangingEventArgs()
            {
                OldParkName = this.name,
                ParkName = newName,
                Handled = false,
            };

            // Check if any event handlers are set
            if (NameChanging != null)
            {
                NameChanging(this, eventArgs);
            }

            // Let event handlers override this behaviour and stop the park name change.
            if (!eventArgs.Handled)
            {
                // In this case if the event is not handled, it will default to changing the name of the park.
                // This means that if an event handler indicates the event is handled, the name will not change automatically.
                name = newName;
            }
        }
    }


    public class NameChangingEventArgs : EventArgs
    {
        public bool Handled { get; set; }
        public string OldParkName { get; set; }
        public string ParkName { get; set; }
    }

    public class GuestEnteredEventArgs : EventArgs
    {
        public Guest Guest { get; set; }
    }

    public class WeatherChangedEventArgs : EventArgs
    {
        public Weather OldWeather { get; set; }
        public Weather Weather { get; set; }
    }
}
