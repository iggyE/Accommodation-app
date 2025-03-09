using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Service;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InitialProject.Repository
{
    public class AccomodationReservationRepository
    {
        public AccomodationReservationRepository() { }

        public List<AccomodationReservation> GetAllAccomodationReservation()
        {
            using(var db = new DataContext())
            {
                return db.AccomodationReservations.ToList();
            }
        }

        public List<AccomodationReservation> GetAllReservationsByGuest(int userId)
        {
            List<AccomodationReservation> reservationsByGuest = new List<AccomodationReservation> ();
            using(var db = new DataContext())
            {
                foreach (var reservation in GetAllAccomodationReservation()) 
                {
                    if(reservation.GuestId == userId)
                    {
                        reservationsByGuest.Add(reservation);
                    }
                }
                return reservationsByGuest;
            }
        }

        public int GetLocationIdByReservation(AccomodationReservation accomodationReservation)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();

            using (var db = new DataContext())
            {
                int locationId = accomodationRepository.GetIdLocationById(accomodationReservation.AccomodationId);
                return locationId;
            }
        }
            public ObservableCollection<AccomodationReservationDTO> GetAllReservationsDTO()
        {
            var reservations = GetAllAccomodationReservation();
            var dtos = new ObservableCollection<AccomodationReservationDTO>();

            AccomodationRepository accomodationRepository = new AccomodationRepository();

            foreach (var reservation in reservations)
            {
                string Name = accomodationRepository.GetNameById(reservation.AccomodationId);
                dtos.Add(
                    new AccomodationReservationDTO(Name,reservation.CheckInDate, reservation.CheckOutDate, reservation.NumberOfGuests,reservation.AccomodationId));
            }
            return dtos;
        }

        public AccomodationReservation GetAccomodationReservationById(int accId)
        {
            using (var db = new DataContext())
            {
                List<AccomodationReservation> allAccomodationReservation = GetAllAccomodationReservation();
                foreach (AccomodationReservation accomodationReservation in allAccomodationReservation)
                {
                    if (accomodationReservation.AccomodationId == accId)
                    {
                        return accomodationReservation;
                    }
                }
            }
            return null;
        }


        public void BookAcc(int accId, int guestsNumber, DateTime start, DateTime end)
        {
            AccomodationReservation accomodationReservation = new AccomodationReservation();
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            AccomodationService accomodationService = new AccomodationService();

            using (var db = new DataContext())
            {
                Accomodation accomodation = db.Accomodations.Find(accId);

                accomodation.AccomodationReservations.Add(accomodationReservation);
                db.SaveChanges();
            }
            Console.WriteLine("Succesfully reserved accomodation");
        }


    }
}
