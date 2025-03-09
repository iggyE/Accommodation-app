using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class GuestRating
    {
        public int Id { get; set; }

        public DateTime RatingExperationDate { get; set; }

        public int Cleanliness { get; set; }

        public int RuleCompliance { get; set; }

        public string Comment { get; set; }

        public int IdOwner { get; set; }

      //  public int GuestId { get; set; }//
        public GuestRating() { }

        public GuestRating(int id, DateTime ratingExperationDate, int cleanliness, int ruleCompliance, string comment,int idOwner)
        {
            Id = id;
            RatingExperationDate = ratingExperationDate;
            Cleanliness = cleanliness;
            RuleCompliance = ruleCompliance;
            Comment = comment;
            IdOwner = IdOwner;
          //  GuestId = guestId;

        }

        public override string ToString()
        {
            return $"Id: {Id}\n, RatingExperationDate: {RatingExperationDate}\n, CleanLiness: {Cleanliness}\n, RuleCompliance: {RuleCompliance}\n, Comment: {Comment}\n";
        }
    }
}
