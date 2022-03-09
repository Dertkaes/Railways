namespace Railways
{
    internal class Train
    {
        public int Speed { get; set; }
        public int DistanceTraveled { get; set; }
        public RailwayTrack RailwayTrack { get; set; }
        public Route Route { get; set; }

        public Train()
        {
            Speed = 1;
            DistanceTraveled = 0;

        }

        public Train( Route route)
        {
            Speed = 1;
            DistanceTraveled = 0;
            RailwayTrack = route.RailwayTracks[0];
            Route = route;
        }

        public Train(RailwayTrack railwayTrack, Route route)
        {
            Speed = 1;
            DistanceTraveled = 0;
            RailwayTrack = railwayTrack;
            Route = route;
        }

        public Train(int speed, RailwayTrack railwayTrack, Route route)
        {
            Speed = speed;
            DistanceTraveled = 0;
            RailwayTrack = railwayTrack;
            Route = route;

        }

        public bool Run()
        {
            if(Route.RailwayTracks.Count == 0)
            {
                return false;
            }
            DistanceTraveled++;
            if(DistanceTraveled == RailwayTrack.LengthWay)
            {
                DistanceTraveled = 0;
                Route.RailwayTracks.Remove(RailwayTrack);
                if(Route.RailwayTracks.Count != 0)
                {
                    RailwayTrack = Route.RailwayTracks[0];
                }
            }
            return true;
        }
    }
}
