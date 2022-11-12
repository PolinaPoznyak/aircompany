using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> _planes;

        public Airport(IEnumerable<Plane> planes) => _planes = planes.ToList();

        public List<PassengerPlane> GetPassengersPlanes() => _planes.Where(x => x.GetType() == typeof(PassengerPlane))
                                                                    .Cast<PassengerPlane>().ToList();

        public List<MilitaryPlane> GetMilitaryPlanes() => _planes.Where(x => x.GetType() == typeof(MilitaryPlane))
                                                                 .Cast<MilitaryPlane>().ToList();

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity() => GetPassengersPlanes().Aggregate((w, x) => w.PassengersCapacityIs() > x.PassengersCapacityIs() ? w : x);

        public IEnumerable<MilitaryPlane> GetTransportMilitaryPlanes() => GetMilitaryPlanes().Where(plane => plane.GetPlaneType() == MilitaryType.Transport).ToList();

        public Airport SortByMaxDistance() => new Airport(_planes.OrderBy(w => w.GetMaxFlightDistance()));

        public Airport SortByMaxSpeed() => new Airport(_planes.OrderBy(w => w.GetMaxSpeed()));

        public Airport SortByMaxLoadCapacity() => new Airport(_planes.OrderBy(w => w.GetMaxLoadCapacity()));

        public IEnumerable<Plane> GetPlanes() => _planes;

        public override string ToString()
        {
            return "Airport{" + "planes=" + string.Join(", ", _planes.Select(x => x.GetPlaneModel())) + '}';
        }
    }
}
