namespace Railways
{
    internal class RailwayTrack
    {
        public Station BeginningWay { get; set; }
        public Station EndningWay { get; set; }
        public int LengthWay { get; set; }
        public RailwayTrack()
        {
            BeginningWay = new Station();
            EndningWay = new Station();
            LengthWay = 0;
        }
        public RailwayTrack(ref Station beginningWay, ref Station endningWay, int lengthWay)
        {
            BeginningWay = beginningWay;
            EndningWay = endningWay;
            LengthWay = lengthWay;
        }
    }
}
