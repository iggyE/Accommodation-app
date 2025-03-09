using InitialProject.DTO;
using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Repository
{
    public class ForumRepository
    {

        AccomodationRepository accomodationRepository = new AccomodationRepository();

        LocationRepository locationRepository = new LocationRepository();

        public ForumRepository() { }

        public List<Forum> GetAllForums()
        {
            using (var db = new DataContext())
            {
                return db.Forums.ToList();
            }
        }

        public Forum GetForumById(int forumId)
        {
            using (var db = new DataContext())
            {
                List<Forum> allForums = GetAllForums();
                foreach (Forum forum in allForums)
                {
                    if(forum.ForumId == forumId)
                    {
                        return forum;
                    }
                }
                return null;
            }
        }

        public ObservableCollection<ForumDTO> GetAllForumsDTO()
        {
            var locationRepository = new LocationRepository();
            var forums = GetAllForums();
            var dtos = new ObservableCollection<ForumDTO>();

            foreach (var forum in forums)
            {
                var location = locationRepository.GetLocationById(forum.LocationId);
                dtos.Add(
                    new ForumDTO(forum.Name, location, forum.IsOpen, forum.FirstComment, forum.ForumId,forum.VeryUseful));  
            }
            return dtos;
        }

        public void OpenForum(int forumId,string name, int locationId,string firstComment)
        {
            using (var db = new DataContext())
            {
                Location location = locationRepository.GetLocationById(locationId);
                if (location != null)
                {
                    Forum newForum = new Forum
                    {
                        ForumId = forumId,
                        Name = name,
                        LocationId = locationId,
                        IsOpen = true,
                        FirstComment = firstComment,
                        VeryUseful = false
                    };

                    db.Forums.Add(newForum);
                    db.SaveChanges();
                    return;
                }
            }
        }

        public void AddCommentToForum(int forumId, int commentId, string commentText) //int GuestID
        {
            using (var db = new DataContext())
            {
                Forum forum = db.Forums.FirstOrDefault(f => f.ForumId == forumId);
                if (forum != null)
                {if (forum.IsOpen == true)
                    {
                        Comment comment = new Comment
                        {
                            Id = commentId,
                            CreationTime = DateTime.Now,
                            Text = commentText,
                            ForumId = forumId
                        };
                        db.Comments.Add(comment);
                        db.SaveChanges();
                        return;
                    }
                }
                return;
            }

        }

        public void CloseForum(int forumId)
        {
            using (var db = new DataContext())
            {
                Forum forum = db.Forums.Find(forumId);
               // Forum forum = GetForumById(forumId);
                if (forum != null)
                {
                    forum.IsOpen = false;
                    db.Forums.Attach(forum);
                    db.SaveChanges();
                    return;
                }
                return;
            }
        }

        public bool IsLocationValidOwner(Comment comment, int locationId)
        {
            using (var db = new DataContext())
            {
                List<Accomodation> allAccomodations = accomodationRepository.GetAllAccomodations();
                int userId = comment.UserId;

                foreach (var accomodation in allAccomodations)
                {
                    Accomodation matchingAccomodation = allAccomodations.FirstOrDefault(a => a.LocId == locationId && a.IdOwner == userId);

                    if (matchingAccomodation != null)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        
        public bool IsLocationValidGuest(Comment comment, int userId)
        {
            using (var db = new DataContext()) {
                AccomodationReservationRepository accomodationReservationRepository = new AccomodationReservationRepository();

                List<AccomodationReservation> guestsReservation = accomodationReservationRepository.GetAllReservationsByGuest(userId);

                foreach (var reservation in guestsReservation)
                {
                    int locationId = accomodationReservationRepository.GetLocationIdByReservation(reservation);
                    Forum forum = GetForumById(comment.ForumId);

                    if (locationId == forum.LocationId)
                    {
                        return true;
                    }
                }
                return false;
            }
        }


        public int MakeForumUseful(int forumId)
        {
            using (var db = new DataContext())
            {
                CommentRepository commentRepository = new CommentRepository();
                UserRepository userRepository = new UserRepository();
                int OwnerPoints = 0;
                int GuestPoints = 0;
                int points = 0;

                List<Comment> allCommentsForForum = commentRepository.GetAllCommentsForumId(forumId);
                List<Accomodation> allAccomodations = accomodationRepository.GetAllAccomodations();

                Forum forumUseful = db.Forums.Find(forumId);
               // forumUseful.VeryUseful = true;
               // db.Forums.Attach(forumUseful);
               // db.SaveChanges();


                foreach (var comment in allCommentsForForum)
                 {
                        UserType roleForThis = userRepository.RoleForUserId(comment.UserId);
                        Forum forum = GetForumById(forumId);
                        int locationId = forum.LocationId;
                        int userId = comment.UserId;

                        if (roleForThis == UserType.Owner)
                        {
                            if (IsLocationValidOwner(comment, locationId) == true)
                            {
                                OwnerPoints += 1;
                            }
                        }
                        if (roleForThis == UserType.Guest)
                        {
                            if (IsLocationValidGuest(comment, userId) == true)
                            {
                                GuestPoints += 1;
                            }
                        }
                 }
                points = GuestPoints + OwnerPoints;
                return points; 
                    
            } 
        }

        public void ChangeUseful(int forumId)
        {
            using(var db = new DataContext())
            {
                int points = MakeForumUseful(forumId);
                Forum forum = db.Forums.Find(forumId);
                if(points >= 10)
                {
                    forum.VeryUseful = true;
                    db.Forums.Attach(forum);
                    db.SaveChanges();
                    return;
                }
            }
        }


    }
}
