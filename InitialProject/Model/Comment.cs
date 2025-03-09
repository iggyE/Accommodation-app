using System;

namespace InitialProject.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string Text { get; set; }

        public int ForumId { get; set; }

        public int UserId { get; set; }

        public Comment() { }

        public Comment(int commentId, DateTime creationTime, string commentText, int forumId)
        {
            Id = commentId;
            CreationTime = creationTime;
            Text = commentText;
            ForumId = forumId;
        }

        public override string ToString()
        {
            return $"CommentID: {Id}\n, CreationTime: {CreationTime}\n, Text: {Text}\n";
        }

    }
}
