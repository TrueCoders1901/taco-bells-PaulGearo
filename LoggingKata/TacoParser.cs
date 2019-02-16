namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Do not fail if one record parsing fails, return null
            //return null; // TODO Implement

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogInfo("something went wrong :(");
                return null;
            }

            // grab the latitude from your array at index 0
             var latitudeString = cells[0];
            // grab the longitude from your array at index 1
            var longitudeString = cells[1];
            // grab the name from your array at index 2
            var locationName = cells[2];

            // Your going to need to parse your string as a `double`
            double latitude = double.Parse(latitudeString);
            double longitude = double.Parse(longitudeString);


            // which is similar to parsing a string as an `int`

            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            TacoBell tacoBell = new TacoBell();
            tacoBell.Name = locationName;
            Point point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;
            tacoBell.Location = point;

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return tacoBell;

          
        }
    }
}