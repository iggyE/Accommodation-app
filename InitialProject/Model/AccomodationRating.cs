using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class AccomodationRating
    {
        [Key]
        public int AccomodationId { get; set; }

        public int OwnerId { get; set; }

        public int Cleanliness { get; set; }

        public int OwnerFriendliness { get; set; }

         public string Comment { get; set; }

        public List<GuestRating> guestRatings { get; set; }

        public AccomodationRating() 
        { 
           // Comments = new List<Comment>();
            //Images = new List<AccomodationImage>();
        }

        public AccomodationRating(int accomodationId, int ownerId,int cleanliness, int ownerFriendliness,string comment)
        {
            AccomodationId = accomodationId;
            OwnerId = ownerId;
            Cleanliness = cleanliness;
            OwnerFriendliness = ownerFriendliness;
            Comment = comment;
        }

        public override string ToString()
        {
            return $"AccomodationId: {AccomodationId}\n, OwnerId: {OwnerId}\n, Cleanliness {Cleanliness}\n, OwnerFriendliness: {OwnerFriendliness}\n, Comment: {Comment}\n";
        }

    }
}
