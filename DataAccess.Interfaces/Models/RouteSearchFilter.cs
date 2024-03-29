﻿namespace ProviderOne.DataAccess.Interfaces.Models
{
    public class RouteSearchFilter
    {
        // Mandatory
        // Start point of route, e.g. Moscow 
        public string Origin { get; set; }

        // Mandatory
        // End point of route, e.g. Sochi
        public string Destination { get; set; }

        // Mandatory
        // Start date of route
        public DateTime OriginDate { get; set; }

        // Optional
        // End date of route
        public DateTime? DestinationDate { get; set; }

        // Optional
        // Maximum price of route
        public decimal? MaxPrice { get; set; }
    }
}
