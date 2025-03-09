using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Service;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class AccomodationRepository
    {

        public AccomodationRepository() { }

        public List<Accomodation> GetAllAccomodations()
        {
            using (var db = new DataContext())
            {
                return db.Accomodations.ToList();
            }
        }

        public string GetNameById(int accId)
        {
            using (var db = new DataContext())
            {
                foreach (var accomodation in GetAllAccomodations())
                {
                    if(accomodation.AccId == accId)
                    {
                        return accomodation.Name;
                    }
                }
                return "";
            }
        }
        
        public int GetIdByName(string name)
        {
            using (var db = new DataContext())
            {
                foreach (var accomodation in GetAllAccomodations())
                {
                    if(accomodation.Name == name)
                    {
                        return accomodation.AccId;
                    }
                }
                return 0;
            }
        }

        public int GetIdLocationById(int id)
        {
            using (var db = new DataContext())
            {
                foreach (var accomodation in GetAllAccomodations())
                {
                    if(accomodation.AccId == id)
                    {
                        return accomodation.LocId;
                    }
                }
                return 0;
            }
        }

        public ObservableCollection<AccomodationDTO> GetAllAccomodationsDTO() //SRKI
        {
            var locationRepository = new LocationRepository();
            var accomodations = GetAllAccomodations(); //obicna lista
            var dtos = new ObservableCollection<AccomodationDTO>();

            foreach (var accomodation in accomodations)
            {

                var location = locationRepository.GetLocationById(accomodation.LocId); //izvlaci lokaciju kao objekat
                dtos.Add(
                    new AccomodationDTO(accomodation.Name, accomodation.AccomodationType, accomodation.MaxGuests, accomodation.MinReservationDays, accomodation.DaysBeforeCanceling, location,accomodation.AccId,accomodation.IdOwner));
            }
            return dtos;

        }

        public ObservableCollection<AccomodationDTO> GetAllWithoutLocationAccomodationDTO(){
            var accomodations = GetAllAccomodations();
            var dtos = new ObservableCollection<AccomodationDTO>();

            foreach (var accomodation in accomodations)
            {
                dtos.Add(
                    new AccomodationDTO(accomodation.Name, accomodation.AccomodationType, accomodation.MaxGuests, accomodation.MinReservationDays, accomodation.DaysBeforeCanceling, accomodation.AccId));
            }
            return dtos;
        }

        public ObservableCollection<AccomodationDTO> GetAvailableAccomodationsDTO(DateTime start,DateTime end,int numberOfGuests)
        {
            var accomodationService = new AccomodationService();
            var accmodations = accomodationService.FindAvailableAccomodations(start,end,numberOfGuests);
            var dtos = new ObservableCollection<AccomodationDTO>();

            foreach (var accomodation in accmodations)
            {
                dtos.Add(new AccomodationDTO(
                    accomodation.Name, accomodation.AccomodationType, accomodation.MaxGuests,accomodation.MinReservationDays,accomodation.DaysBeforeCanceling,accomodation.AccId));
            }
            return dtos;
        }

        public ObservableCollection<AccomodationDTO> ShowByTypeDTO(string type)
        {
            var accomodationService = new AccomodationService();
            var accomodations = accomodationService.GetByType(type);
            var dtos = new ObservableCollection<AccomodationDTO>();

            foreach (var accomodation in accomodations)
            {
                dtos.Add(new AccomodationDTO(
                   accomodation.Name, accomodation.AccomodationType, accomodation.MaxGuests, accomodation.MinReservationDays, accomodation.DaysBeforeCanceling,accomodation.AccId));
            }
            return dtos;
        }

        public ObservableCollection<AccomodationDTO> ShowByNameDTO(string name)
        {
            var accomodationService = new AccomodationService();
            var accomodations = accomodationService.GetByName(name);
            var dtos = new ObservableCollection<AccomodationDTO>();

            foreach (var accomodation in accomodations)
            {
                dtos.Add(new AccomodationDTO(
                   accomodation.Name, accomodation.AccomodationType, accomodation.MaxGuests, accomodation.MinReservationDays, accomodation.DaysBeforeCanceling, accomodation.AccId));
            }
            return dtos;
        }

        public ObservableCollection<AccomodationDTO> ShowByNumOfGuestsDTO(int numberOfGuests)
        {
            var accomodationService = new AccomodationService();
            var accomodations = accomodationService.GetByGuestsNumber(numberOfGuests);
            var dtos = new ObservableCollection<AccomodationDTO>();

            foreach (var accomodation in accomodations)
            {
                dtos.Add(new AccomodationDTO(
                   accomodation.Name, accomodation.AccomodationType, accomodation.MaxGuests, accomodation.MinReservationDays, accomodation.DaysBeforeCanceling, accomodation.AccId));
            }
            return dtos;
        }

        public Accomodation GetAccomodationById(int accId)
        {
            using(var db = new DataContext())
            {
                List<Accomodation> allAccomodations = GetAllAccomodations();
                foreach(Accomodation accomodation in allAccomodations)
                {
                    if(accomodation.AccId == accId)
                    {
                        return accomodation;
                    }
                }
            }
            return null;
        }

        public List<Accomodation> GetAccomodationsByLocation(int locationId)
        {
            List<Accomodation> accomodationsByLocation = new List<Accomodation>();
            using (var db = new DataContext())
            {
                var location = db.Locations.Include(a => a.Accomodations).SingleOrDefault(a => a.LocationId == locationId);
                if (location != null)
                {
                    accomodationsByLocation.AddRange(location.Accomodations);
                }
            }
            return accomodationsByLocation;
        }

        public int GetNumberOfGuestsInAccomodation(int accId)
        {
            using(var db = new DataContext())
            {
                var acc = db.Accomodations.Include(a => a.AccomodationReservations).SingleOrDefault(a => a.AccId == accId);

                int numberOfGuestsInAccomodation = 0;
                List<AccomodationReservation> accomodationReservations = acc.AccomodationReservations.ToList();
                foreach(AccomodationReservation accomodationReservation in accomodationReservations)
                {
                    numberOfGuestsInAccomodation += accomodationReservation.NumberOfGuests;

                }
                return numberOfGuestsInAccomodation;
            }
        }

    }
}