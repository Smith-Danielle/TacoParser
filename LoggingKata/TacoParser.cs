namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        int count = 0;

        public ITrackable Parse(string line)
        {


            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                logger.LogError("Somthing went wrong", null);
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0
            var latitude = double.Parse(cells[0]);
            // grab the longitude from your array at index 1
            var longitutde = double.Parse(cells[1]);
            // grab the name from your array at index 2
            var name = cells[2];

            Point location = new Point();
            location.Latitude = latitude;
            location.Longitude = longitutde;

            if (count == 0)
            {
                logger.LogInfo("Begin parsing");
                logger.LogInfo($"Parsed line 1. Location : {name}.");
            }
            else
            {
                logger.LogInfo($"Parsed line {count + 1}. Location : {name}.");
            }

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            TacoBell taco1 = new TacoBell(name, location);

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            count++;
            return taco1;
        }
    }
}