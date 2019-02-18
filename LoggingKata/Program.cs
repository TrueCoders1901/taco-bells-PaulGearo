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

            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops

           

            /* DON'T FORGET TO LOG YOUR STEPS
             Grab the path from the name of your file

             use File.ReadAllLines(path) to grab all the lines from your csv file
             Log and error if you get 0 lines and a warning if you get 1 line

             Create a new instance of your TacoParser class
             Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);*/

            // Now, here's the new code

            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            ITrackable farthestI = null;
            ITrackable farthestJ = null;

            // Create a `double` variable to store the distance
            double distance = 0;



            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            // Create a new corA Coordinate with your locA's lat and long

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
            Console.WriteLine(farthestI.Name + farthestJ.Name);
            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
            // Create a new Coordinate with your locB's lat and long
            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.
        }

    }
    
}