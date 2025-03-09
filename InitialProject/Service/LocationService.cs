using InitialProject.DTO;
using InitialProject.Repository;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Service
{
    public class LocationService
    {
        private readonly LocationRepository LocationRepository;
        public LocationService()
        {

        }

        public LocationService(LocationRepository locationRepository)
        {
            LocationRepository = locationRepository;
        }

        public List<Location> GetAllLocations()
        {
            LocationRepository locationRepository = new LocationRepository();
            return locationRepository.GetAllLocations();
        }

        public ObservableCollection<LocationDTO> GetAllLocationDTO()
        {
            var locations = GetAllLocations();
            var dtos = new ObservableCollection<LocationDTO>();
            foreach (var location in locations)
            {
                dtos.Add(new LocationDTO(location.City, location.Country, location.LocationId));
            }
            return dtos;
        }

        public Location GetLocationByCityAndCountry(string city, string country)
        {
            LocationRepository locationRepository = new LocationRepository();
            return locationRepository.GetLocationByCityAndCountry(city, country);
        }

    }
}