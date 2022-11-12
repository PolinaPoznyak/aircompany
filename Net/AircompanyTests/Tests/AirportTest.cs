using Aircompany;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        private List<Plane> _planes = new List<Plane>(PlanesСollection.planes);
        private PassengerPlane _planeWithMaxPassengerCapacity = new PassengerPlane("Boeing-747", 980, 16100, 70500, 242);

        [Test]
        public void CheckForMilitaryPlanes()
        {
            var transportMilitaryPlanes = new Airport(_planes).GetTransportMilitaryPlanes().ToList();
            bool hasMilitaryTransportPlane = false;
            Assert.IsTrue(transportMilitaryPlanes.Count != 0);
        }

        [Test]
        public void GetPassengerPlaneWithMaxPasengersCapacity()
        {
            var expectedPlaneWithMaxPassengersCapacity = new Airport(_planes).GetPassengerPlaneWithMaxPassengersCapacity();
            Assert.IsTrue(expectedPlaneWithMaxPassengersCapacity.Equals(_planeWithMaxPassengerCapacity));
        }

        [Test]
        public void SortingPlanesByMaxLoadCapacity()
        {
            var planesSortedByMaxLoadCapacity = new Airport(_planes).SortByMaxLoadCapacity().GetPlanes().ToList();
            Assert.That(planesSortedByMaxLoadCapacity.SequenceEqual(_planes.OrderBy(x => x.GetMaxLoadCapacity()).ToList()));
        }
    }
}
