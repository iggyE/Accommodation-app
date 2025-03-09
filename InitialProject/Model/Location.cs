using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities;

public class Location
{
    [Key]
    public int LocationId { get; set; }
    public string City { get; set; }

    public string Country { get; set; }

    public List<Tour> Tours { get; set; }

    public List<Accomodation> Accomodations { get; set; }
    public Location() { 
    }

    public Location(int locationId, string city, string country)
    {
        LocationId = locationId;
        City = city;
        Country = country;
    }

    public override string ToString()
    {
        return $"LocationId: {LocationId}\n, City: {City}\n, Country: {Country}\n";
    }
}