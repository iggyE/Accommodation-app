using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.DTO
{
    public class AccomodationReservationDTO
    {

        public string Name { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public int NumberOfGuests { get; set; }

        public int AccomodationId { get; set; }

       public AccomodationReservationDTO(string name, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests, int accomodationId)
        {
            Name = name;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            NumberOfGuests = numberOfGuests;
            AccomodationId = accomodationId;
        }

    }
}
