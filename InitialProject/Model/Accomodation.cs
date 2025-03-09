using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Model
{
    public class Accomodation
    {
        [Key]
        public int AccId { get; set; }

        public string Name { get; set; }

        public AccomodationType AccomodationType { get; set; }

        public int MaxGuests { get; set; }

        public int MinReservationDays { get; set; }

        public int DaysBeforeCanceling { get; set; }

        public int LocId { get; set; }

        public int IdOwner { get; set; }

      //  public bool IsAvailable { get; set; }

        public List<AccomodationImage> Images { get; set; }

        public List<Guest> Guests { get; set; }

        public List<AccomodationReservation> AccomodationReservations { get; set; } //
     

        public Accomodation() {
            Images = new List<AccomodationImage>();
            Guests = new List<Guest>();
            AccomodationReservations = new List<AccomodationReservation>();
        }

        public Accomodation(int accId, string name, Location location, AccomodationType type, int maxGuests, int minReservationDays, int daysBeforeCanceling, int locId)
        {
            AccId = accId;
            Name = name;
            AccomodationType = type;
            MaxGuests = maxGuests;
            MinReservationDays = minReservationDays;
            DaysBeforeCanceling = daysBeforeCanceling;
            LocId = locId;
            Images = new List<AccomodationImage>();
            Guests = new List<Guest>();
            AccomodationReservations = new List<AccomodationReservation>();

        }

        public override string ToString()
        {
            return $"[==========****************===========]\nAccomodationId: {AccId}\n, Name: {Name}\n, AccomodationType: {AccomodationType}\n, MaxGuests: {MaxGuests}\n, MinDaysReservation: {MinReservationDays}\n, DaysBeforeCanceling: {DaysBeforeCanceling}\n";
        }
    }
}
