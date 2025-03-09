using InitialProject.Model;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

public class AccomodationReservation
{
    [Key]
    public int Id { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }

    public int NumberOfGuests { get; set; }

    public List<Accomodation> Accomodations { get; set; }  //

    public int AccomodationId { get; set; }
    public int GuestId { get; set; }
    

    public AccomodationReservation()
    { 
       // Users = new List<User>();
        Accomodations = new List<Accomodation>();
    }

    public AccomodationReservation(int id, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests, int accId)
    {
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        NumberOfGuests = numberOfGuests;
      //   Users = new List<User>();
        Accomodations = new List<Accomodation>();
        AccomodationId = accId;

    }

    public override string ToString()
    {
        return $"[==========****************===========]\nID: {Id}\n, StartDate: {CheckInDate}\n, EndDate: {CheckOutDate}\n, NumberOfGuests: {NumberOfGuests}\n, AccId: {AccomodationId}\n";
    }

}

