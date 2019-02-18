namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        /// <summary>
        /// Parses the file ya dummy
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public ITrackable Parse(string line)
        {
            

            // Do not fail if one record parsing fails, return null
            //return null; // TODO Implement
            if (line == null)
            {
                return null;
            }

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
            if (!double.TryParse(latitudeString, out double latitude))
                return null;
            if (!double.TryParse(longitudeString, out double longitude))
                return null;


            // which is similar to parsing a string as an `int`
            if (latitude < -90 || latitude > 90)
                return null;
            if(longitude < -180 || longitude > 180)
                return null;





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