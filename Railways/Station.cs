using System;

namespace Railways
{
    internal class Station
    {
        public String Name { get; set; }

        public Station()
        {
            Name = "";
        }
        public Station(String name)
        {
            Name = name;
        }
    }
}
