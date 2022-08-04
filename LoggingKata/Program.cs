using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";
        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
            var lines = File.ReadAllLines(csvPath);
            if (lines.Count() == 0)
            {
                logger.LogFatal($"FAILURE: No lines detected.");
            }
            else if (lines.Count() == 1)
            {
                logger.LogWarning($"WARNING: Only one line detected.");
            }
            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToArray();
            ITrackable furthestTacoBellOne = null;
            ITrackable furthestTacoBellTwo = null;
            double distance = 0;
            foreach(var location in locations)
            {
                var corA = new GeoCoordinate();
                corA.Latitude = location.Location.Latitude;
                corA.Longitude = location.Location.Longitude;
                foreach (var location2 in locations)
                {
                    var corB = new GeoCoordinate(location2.Location.Latitude, location2.Location.Longitude);
                    var distanceBetween = corA.GetDistanceTo(corB);
                    if (distanceBetween > distance)
                    {
                        distance = distanceBetween;
                        furthestTacoBellOne = location;
                        furthestTacoBellTwo = location2;
                    }
                }
            }
            logger.LogInfo($"Taco Bells Scanned: {lines.Count()}");
            logger.LogInfo($"Furthest locations: {furthestTacoBellOne.Name} and {furthestTacoBellTwo.Name}");
        }
    }
}
