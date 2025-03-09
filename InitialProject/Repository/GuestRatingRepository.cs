using InitialProject.DTO;
using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class GuestRatingRepository
    {

        public GuestRatingRepository() { }

        public List<GuestRating> GetAllGuestRatings()
        {
            using(var db = new DataContext())
            {
                return db.GuestRatings.ToList();
            }
        }

        public GuestRating GetRatingByOwnerId(int ownerId)
        {
            using (var db = new DataContext())
            {
                List<GuestRating> allGuestRatings = GetAllGuestRatings();
                foreach (GuestRating guestRating in allGuestRatings)
                {
                    if (guestRating.IdOwner == ownerId)
                    {
                        return guestRating;
                    }
                }
            }
            return null;
        }

    }
}
