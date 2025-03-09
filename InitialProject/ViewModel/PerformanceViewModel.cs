using InitialProject.Commands;
using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace InitialProject.ViewModel
{
    public class PerformanceViewModel : INotifyPropertyChanged
    {
        AccomodationRatingRepository accomodationRatingRepository = new AccomodationRatingRepository();
        AccomodationRepository accomodationRepository = new AccomodationRepository();
        AccomodationReviewRepository accomodationReviewRepository = new AccomodationReviewRepository();
        Random random = new Random();

        private int cleanlinessInAcc;
        private int ownerFriendliness;
        private string commentForAcc;
        private int levelUrgency;
        private string reccomendation;
        private int cleanliness;
        private int ruleCompliance;
        private string comment;
        private DateTime dateUGone;
        private GuestRating guestRating;

        private AccomodationDTO selectedAccomodation;

        public ICommand RateAccomodationCommand { get; set; }
        public ICommand ShowYourCommand { get; set; }
        public ICommand ReccommendationForRenovationCommand { get; set; }

        public ObservableCollection<AccomodationDTO> Accomodations { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public PerformanceViewModel()
        {
            RateAccomodationCommand = new DelegateCommand(RateAccomodation);
            ShowYourCommand = new DelegateCommand(RatingForYou);
            ReccommendationForRenovationCommand = new DelegateCommand(ReccomendationForRenovation);

            Accomodations = accomodationRepository.GetAllAccomodationsDTO();
        }

        public AccomodationDTO SelectedAccomodation
        {
            get { return selectedAccomodation; }
            set
            {
                selectedAccomodation = value;
                RaisePropertyChanged(nameof(SelectedAccomodation));
            }
        }
        public GuestRating GuestRating
        {
            get { return guestRating; }
            set
            {
                guestRating = value;
                RaisePropertyChanged(nameof(GuestRating));
            }
        }

        public DateTime DateUGone
        {
            get { return dateUGone; }
            set
            {
                dateUGone = value;
                RaisePropertyChanged(nameof(DateUGone));
            }
        }


        public int CleanlinessInAcc
        {
            get { return cleanlinessInAcc; }
            set
            {
                cleanlinessInAcc = value;
                RaisePropertyChanged(nameof(CleanlinessInAcc));
            }
        }

        public int Cleanliness
        {
            get { return cleanliness; }
            set
            {
                cleanliness = value;
                RaisePropertyChanged(nameof(Cleanliness));
            }
        }

        public int RuleCompliance
        {
            get { return ruleCompliance; }
            set
            {
                ruleCompliance = value;
                RaisePropertyChanged(nameof(RuleCompliance));
            }
        }

        public int OwnerFriendliness
        {
            get { return ownerFriendliness; }
            set
            {
                ownerFriendliness = value;
                RaisePropertyChanged(nameof(OwnerFriendliness));
            }
        }
        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                RaisePropertyChanged(nameof(Comment));
            }
        }

        public string CommentForAcc
        {
            get { return commentForAcc; }
            set
            {
                commentForAcc = value;
                RaisePropertyChanged(nameof(CommentForAcc));
            }
        }

        public int LevelUrgency
        {
            get { return levelUrgency; }
            set
            {
                levelUrgency = value;
                RaisePropertyChanged(nameof(LevelUrgency));
            }
        }

        public string Reccomendation
        {
            get { return reccomendation; }
            set
            {
                reccomendation = value;
                RaisePropertyChanged(nameof(Reccomendation));
            }
        }

        public void RateAccomodation()
        {

           // int idComment = random.Next(1, 1000);
            int ownerId = SelectedAccomodation.IdOwner;
            accomodationRatingRepository.AddAccomodationRating(SelectedAccomodation.AccId,ownerId, CleanlinessInAcc, OwnerFriendliness, CommentForAcc,DateUGone);
            MessageBox.Show("Succesfully added rate for accomodation!");
            return;
        }

        public void RatingForYou()
        {
            int accId = SelectedAccomodation.AccId;
            GuestRating = accomodationRatingRepository.GetGuestRatingFromAccId(accId);
            Cleanliness = GuestRating.Cleanliness;
            RuleCompliance = GuestRating.RuleCompliance;
            Comment = GuestRating.Comment;

            MessageBox.Show("This is rating for you from owner!");
            return;
        }
        public void ReccomendationForRenovation()
        {
            accomodationReviewRepository.AddAccomodationReview(SelectedAccomodation.AccId, LevelUrgency, Reccomendation);
            MessageBox.Show("Succesfully added rating for accomodation " + SelectedAccomodation.Name);

            return;
        }



        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }
    }
}
