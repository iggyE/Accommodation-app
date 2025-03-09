using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
    public class AccomodationImagesService
    {

        private readonly AccomodationImagesRepository AccomodationImagesRepository;

        public AccomodationImagesService() { }

        public AccomodationImagesService(AccomodationImagesRepository accomodationImagesRepository)
        {
            AccomodationImagesRepository = accomodationImagesRepository;
        }

        public List<AccomodationImage> GetAccomodationImages(int accId)
        {
            AccomodationImagesRepository accomodationImagesRepository = new AccomodationImagesRepository();
            return accomodationImagesRepository.GetAccomodationImages(accId);
        }

    }
}