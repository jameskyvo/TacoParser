using System.Collections.Generic;
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
            logger.LogInfo("Parsing line...");
            var cells = line.Split(',');
            if (cells.Length < 3)
            {
                logger.LogWarning($"Array has less than three cells: Returning Null.");
                return null;
            }
            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var names = cells[2];
            var point = new Point() { Latitude = latitude, Longitude = longitude};
            var tacoBell = new TacoBell() { Name = names, Location = point };
            return tacoBell;
        }
    }
}