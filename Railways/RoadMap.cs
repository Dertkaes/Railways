using System;
using System.IO;
using System.Collections.Generic;

namespace Railways
{
    internal class RoadMap
    {

        public List<Station> ListStation { get; set; }
        public List<RailwayTrack> ListRailwayTracks { get; set; }

        public RoadMap()
        {
            ListStation = new List<Station>();
            ListRailwayTracks = new List<RailwayTrack>();
        }

        public RoadMap(string FilePath)
        {
            ListStation = new List<Station>();
            ListRailwayTracks = new List<RailwayTrack>();
            ReadRoadMap(FilePath);
        }

        public void ReadRoadMap(string FilePath)
        {
            bool isReadStations = false;
            bool isReadRailwayTracks = false;
            int countstring = 0;

            var splitChars = new char[] { ' ', '\n' };
            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                var s = line.Split(splitChars);
                if ((isReadStations) && (countstring != 0))
                {
                    ListStation.Add(new Station(line));
                    countstring--;
                }
                if ((isReadRailwayTracks) && (countstring != 0))
                {
                    var beginningWay = ListStation.Find(x => x.Name == s[0]);
                    var endningWay = ListStation.Find(x => x.Name == s[1]);
                    ListRailwayTracks.Add(new RailwayTrack(ref beginningWay, ref endningWay, Int32.Parse(s[2])));
                    countstring--;
                }
                if (s[0] == "Stations:")
                {
                    isReadStations = true;
                    countstring = Int32.Parse(s[1]);
                }
                if (s[0] == "RailwayTracks:")
                {
                    isReadStations = false;
                    isReadRailwayTracks = true;
                    countstring = Int32.Parse(s[1]);
                }
            }
        }
    }
}
