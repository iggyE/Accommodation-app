using InitialProject.Commands;
using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WebApi.Entities;

namespace InitialProject.ViewModel
{
    public class ForumViewModel : INotifyPropertyChanged
    {
        //Repository
        ForumRepository forumRepository = new ForumRepository();
        LocationRepository locationRepository = new LocationRepository();
        LocationService locationService = new LocationService();

        Random random = new Random();

        //POLJA i COMMAND
        private string name;
        private string firstComment;
        private string commentText;

        private ForumDTO selectedForum;
        private LocationDTO selectedLocation;

        public ICommand OpenForumCommand { get; set; }
        public ICommand CloseForumCommand { get; set; }
        public ICommand AddCommentCommand { get; set; }
        public ICommand MakeForumUsefulCommand { get; set; }

        //Liste prikazivanja i PropertyChanged
        public ObservableCollection<ForumDTO> AllForums { get; set; }
        public ObservableCollection<LocationDTO> AllLocations { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        //Konstruktor
        public ForumViewModel()
        {
            OpenForumCommand = new DelegateCommand(OpenForum);
            CloseForumCommand = new DelegateCommand(CloseForum);
            AddCommentCommand = new DelegateCommand(AddComment);
            MakeForumUsefulCommand = new DelegateCommand(MakeUseful);

            AllForums = forumRepository.GetAllForumsDTO();
            AllLocations = locationService.GetAllLocationDTO();
        }

        public ForumDTO SelectedForum
        {
            get { return selectedForum; }
            set
            {
                selectedForum = value;
                RaisePropertyChanged(nameof(SelectedForum));
            }
        }

        public LocationDTO SelectedLocation
        {
            get { return selectedLocation; }
            set
            {
                selectedLocation = value;
                RaisePropertyChanged(nameof(SelectedLocation));
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string FirstComment
        {
            get { return firstComment; }
            set
            {
                firstComment = value;
                RaisePropertyChanged(nameof(FirstComment));
            }
        }

        public string CommentText
        {
            get { return commentText; }
            set
            {
                commentText = value;
                RaisePropertyChanged(nameof(CommentText));
            }
        }



        //FJE
        public void OpenForum()
        {
            int forumId = random.Next(1, 1000);;
            int locationId = SelectedLocation.LocationId;
            forumRepository.OpenForum(forumId,Name,locationId,FirstComment);
            MessageBox.Show("Succesfully opened forum!");
            return;
        }

        public void CloseForum()
        {
            int forumId = SelectedForum.ForumId;
            forumRepository.CloseForum(forumId);
            MessageBox.Show("Succesfully closed " + SelectedForum.Name + " forum!");
            return;
        }

        public void AddComment()
        {
            int forumId = SelectedForum.ForumId;
            int commentId = random.Next(1, 1000);
            if (SelectedForum.IsOpen == true)
            {
                forumRepository.AddCommentToForum(forumId, commentId, CommentText);
                MessageBox.Show("Succesfully added comment for forum " + SelectedForum.Name + "!");
            }
            else
            {
                MessageBox.Show("Cannot add comment because forum " + SelectedForum.Name + " is closed!");
            }
                return;
        }

        public void MakeUseful()
        {
            int forumId = SelectedForum.ForumId;
            forumRepository.ChangeUseful(forumId);
            return;
        }


        //Ovo sranje
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }
    }
}
