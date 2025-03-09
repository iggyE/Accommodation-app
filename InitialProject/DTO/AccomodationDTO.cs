using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.DTO
{
    public class AccomodationDTO
    {
        public string Name { get; set; }

        public AccomodationType AccomodationType { get; set; }

        public int MaxGuests { get; set; }

        public int MinReservationDays { get; set; }

        public int DaysBeforeCanceling { get; set; }

        public Location Location { get; set; }

        public int AccId { get; set; }

        public int IdOwner { get; set; }


        public AccomodationDTO(string name, AccomodationType accomodationType, int maxGuests, int minReservationDays, int daysBeforeCanceling, Location location,int accId,int idOwner)
        {
            Name = name;
            this.AccomodationType = accomodationType;
            MaxGuests = maxGuests;
            MinReservationDays = minReservationDays;
            DaysBeforeCanceling = daysBeforeCanceling;
            Location = location;
            AccId = accId;
            IdOwner = idOwner;
        }

        public AccomodationDTO(string name, AccomodationType accomodationType, int maxGuests, int minReservationDays, int daysBeforeCanceling, int accId)
        {
            Name = name;
            AccomodationType = accomodationType;
            MaxGuests = maxGuests;
            MinReservationDays = minReservationDays;
            DaysBeforeCanceling = daysBeforeCanceling;
            AccId = accId;
        }
    }
}
