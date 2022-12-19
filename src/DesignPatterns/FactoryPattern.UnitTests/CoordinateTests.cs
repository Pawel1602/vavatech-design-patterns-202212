using FactoryPattern.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryPattern.UnitTests
{
    [TestClass]
    public class CoordinateFactoryTests
    {
        [TestMethod]
        public void Create_FromWkt_ShouldReturnsCoordinate()
        {
            // Arrange
            string wkt = "POINT (52 28)";

            // Act
            Coordinate result = Coordinate.Factory.NewFromWkt(wkt);

            // Assert
            Assert.AreEqual(52, result.Longitude);
            Assert.AreEqual(28, result.Latitude);

        }

        [TestMethod]
        public void Create_FromGeoJson_ShouldReturnsCoordinate()
        {
            // Arrange
            string geojson = @"{
	              'type': 'Feature',
	              'geometry': {
			            'type': 'Point',
	                'coordinates': [52, 28]
  	            }";

            // Act
            Coordinate result = Coordinate.Factory.NewFromGeoJson(geojson);

            // Assert
            Assert.AreEqual(52, result.Longitude);
            Assert.AreEqual(28, result.Latitude);

        }

    }
}
