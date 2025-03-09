using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.DTO
{
    public class LocationDTO
    {
        public string City { get; set; }
        public string Country { get; set; }
        public int LocationId { get; set; }

        public LocationDTO(string city, string country, int locationId)
        {
            City = city;
            Country = country;
            LocationId = locationId;
        }
    }
}
