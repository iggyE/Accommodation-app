using InitialProject.DTO;
using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Repository
{
    public class LocationRepository
    {
        public LocationRepository()
        {

        }

        public List<Location> GetAllLocations()
        {
            using (var db = new DataContext())
            {
                return db.Locations.ToList();
            }
        }

        public Location GetLocationById(int id)
        {
            using (var db = new DataContext())
            {
                List<Location> allLocations = GetAllLocations();
                foreach (Location location in allLocations)
                {
                    if(location.LocationId == id)
                    {
                        return location;
                    }
                }
                return null;
            }
        }

        public ObservableCollection<LocationDTO> GetAllLocationDTO()
        {
            var locations = GetAllLocations();
            var dtos = new ObservableCollection<LocationDTO>();

            foreach (var location in locations)
            {
                dtos.Add(new LocationDTO(location.City,location.Country,location.LocationId));
            }
            return dtos;
        }


        public Location GetLocationByCityAndCountry(string city, string country)
        {
            using (var db = new DataContext())
            {
                List<Location> allLocations = GetAllLocations();
                foreach (Location location in allLocations)
                {
                    if (location.City.Equals(city) && location.Country.Equals(country))
                    {
                        return location;
                    }
                }
            }
            return null;
        }


    }
}