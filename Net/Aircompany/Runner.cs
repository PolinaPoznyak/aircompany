﻿using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;

namespace Aircompany
{
    public class Runner
    {
        public static void Main(string[] args)
        {
            Airport airport = new Airport(PlanesСollection.planes);
            Airport militaryAirport = new Airport(airport.GetMilitaryPlanes());
            Airport passengerAirport = new Airport(airport.GetPassengersPlanes());
            Console.WriteLine(militaryAirport
                              .SortByMaxDistance()
                              .ToString());
            Console.WriteLine(passengerAirport
                              .SortByMaxSpeed()
                              .ToString());
            Console.WriteLine(passengerAirport.GetPassengerPlaneWithMaxPassengersCapacity());           
        }
    }
}
