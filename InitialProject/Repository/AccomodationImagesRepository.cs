using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class AccomodationImagesRepository
    {

        public AccomodationImagesRepository() { }

        public AccomodationImage GetImageById(int id)
        {
            using (var db = new DataContext())
            {
                return db.AccomodationImages.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<AccomodationImage> GetAccomodationImages(int accomodationId)
        {
            List<AccomodationImage> images = new List<AccomodationImage>();
            using (var db = new DataContext())
            {
                var accomodation = db.Accomodations.Include(a => a.Images).SingleOrDefault(a => a.AccId == accomodationId);
                if (accomodation != null)
                {
                    images.AddRange(accomodation.Images);
                }
            }
            return images;
        }

    }
}