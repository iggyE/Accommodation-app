using InitialProject.Controller;
using InitialProject.Model;
using InitialProject.Repository;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WebApi.Entities;

namespace InitialProject.Service
{
    public class AccomodationService
    {
        private readonly AccomodationRepository AccomodationRepository;
        private readonly LocationRepository LocationRepository;
        private readonly AccomodationImagesRepository accomodationImagesRepository;


        public AccomodationService() { }

        public AccomodationService(AccomodationRepository accomodationRepository, LocationRepository locationRepository)
        {
            AccomodationRepository = accomodationRepository;
            LocationRepository = locationRepository;
        }


        public List<Accomodation> GetAllAccomodations()
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            return accomodationRepository.GetAllAccomodations();
        }

        public List<Accomodation> GetAccomodationsByLocation(int locationId)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            List<Accomodation> accomodationsByLocation = accomodationRepository.GetAccomodationsByLocation(locationId);
            return accomodationsByLocation;
        }

        public Accomodation GetAccomodationById(int accId)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            return accomodationRepository.GetAccomodationById(accId);
        }

        public List<Accomodation> GetByType(string type)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            List<Accomodation> allAccomodations = accomodationRepository.GetAllAccomodations();
            List<Accomodation> accomodationsByType = new List<Accomodation>();
            foreach (Accomodation accomodation in allAccomodations)
            {
                if (accomodation.AccomodationType == (AccomodationType)Enum.Parse(typeof(AccomodationType), type))
                {
                    accomodationsByType.Add(accomodation);
                }

            }
            return accomodationsByType;
        }

        public List<Accomodation> GetByName(string name)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            List<Accomodation> allAccomodations = accomodationRepository.GetAllAccomodations();
            List<Accomodation> accomodationsByName = new List<Accomodation>();

            foreach (Accomodation accomodation in allAccomodations)
            {
                if (accomodation.Name.Equals(name))
                {
                    accomodationsByName.Add(accomodation);
                }
            }
            return accomodationsByName;
        }

        public List<Accomodation> GetByGuestsNumber(int guestsNumber)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            List<Accomodation> allAccomodations = accomodationRepository.GetAllAccomodations();
            List<Accomodation> accomodationsByGuestsNumber = new List<Accomodation>();

            foreach (Accomodation accomodation in allAccomodations)
            {
                if (accomodation.Guests != null)
                {
                    if (accomodation.MaxGuests - accomodation.Guests.Count() >= guestsNumber)
                    {
                        accomodationsByGuestsNumber.Add(accomodation);
                    }
                }
                else
                {
                    if (accomodation.MaxGuests >= guestsNumber)
                    {
                        accomodationsByGuestsNumber.Add(accomodation);
                    }
                }
            }
            return accomodationsByGuestsNumber;

        }

        public List<Accomodation> GetByReservationDays(int reservationDays)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            List<Accomodation> allAccomodations = accomodationRepository.GetAllAccomodations();
            List<Accomodation> accomodationsByReservationDays = new List<Accomodation>();

            foreach (Accomodation accomodation in allAccomodations)
            {
                if (reservationDays >= accomodation.MinReservationDays)
                {
                    accomodationsByReservationDays.Add(accomodation);
                }
            }
            return accomodationsByReservationDays;
        }


        public Location GetAccomodationLocation(int accId)
        {
            LocationRepository locationRepository = new LocationRepository();
            List<Location> allLocations = locationRepository.GetAllLocations();
            List<Accomodation> accomodationsByLocation = new List<Accomodation>();

            foreach (Location location in allLocations)
            {
                accomodationsByLocation = GetAccomodationsByLocation(location.LocationId);
                foreach (Accomodation accomodation in accomodationsByLocation)
                {
                    if (accomodation.AccId == accId)
                    {
                        return location;
                    }
                }
            }
            return null;
        }

        public void UpdateAvailability(int accId,DateTime start,DateTime end,int numberOfGuests)
        {   using (var db = new DataContext())
            {
                var accomodation = GetAccomodationById(accId);
                if (accomodation == null)
                {
                    Console.WriteLine("Accomodation not found.");
                    return;
                }
                if (accomodation.MaxGuests < numberOfGuests)
                {
                    Console.WriteLine("Not enough spots available for the given number of guests");
                    return;
                }

                accomodation.MaxGuests = numberOfGuests;
                db.SaveChanges();
            }
        }


        public List<Accomodation> FindAvailableAccomodations(DateTime startDate, DateTime endDate, int numberOfGuests)
        {

            List<Accomodation> availableAccomodations = new List<Accomodation>();
            foreach (Accomodation accomodation in GetAllAccomodations())
            {
                if ((endDate - startDate).Days + 1 > accomodation.MinReservationDays)
                {
                    if (GetFreeSpotsNumber(accomodation.AccId) >= numberOfGuests) //&& accomodation.IsAvailable
                    {
                        availableAccomodations.Add(accomodation);
                    }
                }
            }
            return availableAccomodations;
        }

        public List<Guest> GetGuests(int accId)
        {
            GuestsRepository guestsRepository = new GuestsRepository();
            return guestsRepository.GetGuests(accId);
        }

        public int GetFreeSpotsNumber(int accId)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            Accomodation accomodation = GetAccomodationById(accId);
            List<Guest> accomodationsGuests = new List<Guest>();
            accomodationsGuests = GetGuests(accId);
            int freeSpotsNumber = accomodation.MaxGuests - accomodationRepository.GetNumberOfGuestsInAccomodation(accId);
            return freeSpotsNumber;
        }

        public bool IsAvailable(DateTime start,DateTime end,Accomodation accomodation)
        {
            var reservations = accomodation.AccomodationReservations;
            return !reservations.Any(r => (start >= r.CheckInDate && start < r.CheckOutDate) || (end > r.CheckInDate && end <= r.CheckOutDate));
        }

        public void BookAcc(int accId, int guestsNumber, DateTime start, DateTime end)
        {
            AccomodationReservationRepository accomodationReservationRepository = new AccomodationReservationRepository();
            accomodationReservationRepository.BookAcc(accId, guestsNumber, start, end);
        }

        public void CancelReservation(int idRezervacije)                            //!?!?!?!?!?!??!?!?!?!?!
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            AccomodationReservationRepository accomodationReservationRepository = new AccomodationReservationRepository();

            Accomodation accomodation = GetAccomodationById(idRezervacije); //ZAMASKIRANO ID i IDACC u bazi podesavam da je isti to je GRESKA MORA SE SREDITI!!!
            AccomodationReservation accomodationReservation = accomodationReservationRepository.GetAccomodationReservationById(idRezervacije);

            //funkcija za ID dobavljanje

            using(var db = new DataContext()) {

                if (accomodation.DaysBeforeCanceling > (accomodationReservation.CheckInDate - DateTime.Now).TotalDays)
                {
                    Console.WriteLine("it is impossible to cancel the reservation because the owner has given several days before cancellation");
                    return;
                }
                else if (accomodationReservation.CheckInDate - DateTime.Now < new TimeSpan(24, 0, 0))
                {
                    Console.WriteLine("it is impossible to cancel because there are less than 24 hours until the start of the reservation");
                    return;
                }

                else
                {
                    db.AccomodationReservations.Remove(accomodationReservation);
                    db.SaveChanges();
                    Console.WriteLine("Succesfully removed accomodation reservation!");
                    return;
            }
            }

        }


        // PRAVIM FUNKCIJU ZA RESERVACIJU SKROZ TACNU 
        //Fja za VIEW MODEL
        public void ReserveAccomodation(int AccId,int NumberOfGuests,DateTime DateIn, DateTime DateOut)
        {
            Accomodation accomodation = GetAccomodationById(AccId);  //????????????
            AccomodationService accomodationService = new AccomodationService();

            if (IsAvailable(DateIn, DateOut, accomodation))
            {
                MakeReservation(AccId, NumberOfGuests, DateIn, DateOut);
                MessageBox.Show("Succesfully reserved accomodation!");
            }


        }

        // I OVDE ISTO
        // FUNKCIJA ZA REZERVACIJU
        public void MakeReservation(int accId, int numberGuests, DateTime startD, DateTime endD)
        {
            AccomodationService accomodationService = new AccomodationService();
            Accomodation izabran = accomodationService.GetAccomodationById(accId);
            List<Accomodation> availableAccommodation = accomodationService.FindAvailableAccomodations(startD, endD, numberGuests);
            if (availableAccommodation == null)
            {
                throw new Exception("Nema slobodnih.");
            }

            foreach (Accomodation accomodation in availableAccommodation)
            {
                if (accomodation == izabran)
                {
                    accomodationService.BookAcc(accId,numberGuests, startD, endD);
                }
            }
            using (var db = new DataContext())
            {
                var reservation = new AccomodationReservation
                {
                    
                    CheckInDate = startD,
                    CheckOutDate = endD,
                    NumberOfGuests = numberGuests,
                    AccomodationId = accId

                };

                //  List<AccomodationReservation> listaRezervisanihId = new List<AccomodationReservation>();
                Accomodation accomodation = accomodationService.GetAccomodationById(accId);
                accomodation.AccomodationReservations.Add(reservation);
                db.AccomodationReservations.Add(reservation);
                db.SaveChanges();
                accomodationService.UpdateAvailability(accId, startD, endD, numberGuests);
                Console.WriteLine("aaa");
            }
        }

    }
}
