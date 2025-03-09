using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace InitialProject.Repository
{
    public class AccomodationRatingRepository
    {
        public AccomodationRatingRepository() { }
        

        public List<AccomodationRating> GetAllAccomodationRatings()
        {
            using (var db = new DataContext())
            {
                return db.AccomodationRating.ToList();
            }
        }

        public int GetOwnderId(int accId)
        {
            using (var db = new DataContext())
            {
                List<AccomodationRating> allAccomodations = GetAllAccomodationRatings();
                foreach(AccomodationRating accomodationRating in allAccomodations)
                {
                    if (accomodationRating.AccomodationId == accId)
                    {
                        return accomodationRating.OwnerId;
                    }
                }
                return -1;
            }
        }

        public void AddAccomodationRating(int accId,int ownerId,int cleanliness,int ownerFriendliness,string commentText, DateTime timeGone)
        {
            using (var db = new DataContext())
            {
                if (DateTime.Now.Date <= timeGone.AddDays(5))
                {

                    AccomodationRating rating = new AccomodationRating(accId, ownerId, cleanliness, ownerFriendliness, commentText);
                    db.AccomodationRating.Add(rating);
                    Console.WriteLine("Succesfully added rating!");


                    db.SaveChanges();
                    return;
                }
                return;
            }
        }

       public GuestRating GetGuestRatingFromAccId(int accId)
        {
            int ownerId = GetOwnderId(accId);

            GuestRatingRepository guestRatingRepository = new GuestRatingRepository();
            GuestRating guestRating = new GuestRating();
            List<GuestRating> listGuestRatings = guestRatingRepository.GetAllGuestRatings();

            foreach (var rating in listGuestRatings)
            {
                if(ownerId == rating.IdOwner)
                {
                    return guestRatingRepository.GetRatingByOwnerId(ownerId);
                }
            }

            return null;

        }

        

    }
}
