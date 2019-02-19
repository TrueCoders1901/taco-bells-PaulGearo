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

            logger.LogInfo("Begin parsing");

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable farthestI = null;
            ITrackable farthestJ = null;

            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                for (int j = 0; j < locations.Length; j++)
                {
                    GeoCoordinate origin = new GeoCoordinate(locations[i].Location.Latitude, locations[i].Location.Longitude);
                    GeoCoordinate destination = new GeoCoordinate(locations[j].Location.Latitude, locations[j].Location.Longitude);
                   if(origin.GetDistanceTo(destination) > distance)
                   {
                        distance = origin.GetDistanceTo(destination);
                        farthestI = locations[i];
                        farthestJ = locations[j];
                   }
                }
            }

            Console.WriteLine(farthestI.Name + "\n" + farthestJ.Name);
        }
    }
}