using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class CommentRepository
    {
        public CommentRepository() { }  

        public List<Comment> GetAllComments()
        {
            using(var db = new DataContext())
            {
                return db.Comments.ToList();
            }
        }

        public List<Comment> GetAllCommentsForumId(int forumId)
        {
            using( var db = new DataContext())
            {
                List<Comment> allComments = GetAllComments();
                List<Comment> commentsByForumId = new List<Comment>();
                foreach (var comment in allComments)
                {
                    if(comment.ForumId == forumId)
                    {
                        commentsByForumId.Add(comment);
                    }
                }
                return commentsByForumId;
            }
        }

    }
}
