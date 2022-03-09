using System.Collections.Generic;

namespace Railways
{
    internal class Route
    {
        public List<RailwayTrack> RailwayTracks { get; set; }

        public Route()
        {
            RailwayTracks = new List<RailwayTrack>();
        }
    }
}
