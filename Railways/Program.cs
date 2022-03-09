using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Railways
{
    internal class Program
    {
        static List<Train> ReadTrains(string FilePath,ref RoadMap roadMap)
        {
            bool isReadRouts = false;
            int countString = 0;

            List<Train> trains = new List<Train>();
            var splitChars = new char[] { ' ', '\n' };

            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                var s = line.Split(splitChars);
                if ((isReadRouts) && (countString != 0))
                {
                    Route rout = new Route();
                    for (int i = 0; i < s.Length - 1; i++)
                    {
                        var beginningWay = roadMap.ListStation.Find(x => x.Name == s[i]);
                        var endningWay = roadMap.ListStation.Find(x => x.Name == s[i + 1]);
                        var railwayTrack = roadMap.ListRailwayTracks.Find(x => (((x.BeginningWay == beginningWay) && (x.EndningWay == endningWay)) ||
                                                                                    ((x.BeginningWay == endningWay) && (x.EndningWay == beginningWay))));
                        rout.RailwayTracks.Add(railwayTrack);
                    }
                    trains.Add(new Train(rout));
                    countString--;
                }
                if (s[0] == "Routs:")
                {
                    isReadRouts = true;
                    countString = Int32.Parse(s[1]);
                }
            }
            return trains;
        }

        static void Main(string[] args)
        {
            RoadMap roadMap = new RoadMap(args[0]);
            List<Train> trains = ReadTrains(args[1], ref roadMap);
            bool isTrainsRaide = true;

            String messageResult = "YES";

            while(isTrainsRaide)
            {
                isTrainsRaide = false;
                List<RailwayTrack> activeRailwayTrack = new List<RailwayTrack>();
                var hashRailwayTrack = new HashSet<RailwayTrack>();
                var deleteTrains = new List<Train>();
                foreach (Train t in trains)
                {
                    if (t.Run())
                    {
                        isTrainsRaide = true;
                        activeRailwayTrack.Add(t.RailwayTrack);
                    }
                    else
                    {
                        deleteTrains.Add(t);
                    }
                }
                trains = trains.Except(deleteTrains).ToList();
                var duplicates = activeRailwayTrack.Where(item => !hashRailwayTrack.Add(item)).Distinct().ToList();
                if(duplicates.Count != 0)
                {
                    messageResult = "NO";
                    isTrainsRaide = false;
                }
            }
            Console.Write(messageResult);
            Console.ReadKey();
        }
    }
}
