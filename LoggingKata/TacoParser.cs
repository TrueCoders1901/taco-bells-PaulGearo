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

            if (line == null)
                return null;

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                logger.LogInfo("something went wrong :(");
                return null;
            }

            var latitudeString = cells[0];
            var longitudeString = cells[1];
            var locationName = cells[2];


            if (!double.TryParse(latitudeString, out double latitude))
                return null;
            if (!double.TryParse(longitudeString, out double longitude))
                return null;

            if (latitude < -90 || latitude > 90)
                return null;
            if (longitude < -180 || longitude > 180)
                return null;

            TacoBell tacoBell = new TacoBell();
            tacoBell.Name = locationName;
            Point point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;
            tacoBell.Location = point;


            return tacoBell;


        }
    }
}