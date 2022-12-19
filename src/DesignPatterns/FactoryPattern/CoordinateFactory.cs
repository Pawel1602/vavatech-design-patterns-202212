using FactoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class CoordinateFactory
    {
        public static Coordinate NewFromWkt(string wkt)
        {
            const string pattern = @"POINT \((\d*)\s(\d*)\)";

            Regex regex = new Regex(pattern);

            Match match = regex.Match(wkt);

            if (match.Success)
            {
                double lng = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                double lat = double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);

                return new Coordinate(lng, lat);
            }
            else
            {
                throw new FormatException();
            }
        }

        public static Coordinate NewFromGeoJson(string geojson)
        {
            const string pattern = @"\[(\d*), (\d*)\]";

            Regex regex = new Regex(pattern);


            Match match = regex.Match(geojson);

            if (match.Success)
            {

                double lng = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                double lat = double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);

                return new Coordinate(lng, lat);
            }
            else
            {
                throw new FormatException();
            }
        }
    }

   
}
