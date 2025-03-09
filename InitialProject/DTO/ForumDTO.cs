using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.DTO
{
    public class ForumDTO
    {
        public string Name { get; set; }
        public Location Location { get; set; }
        public bool IsOpen { get; set; }
        public string FirstComment { get; set; }
        public bool VeryUseful { get; set; }
        public int ForumId { get; set; }

        public ForumDTO(string name, Location location, bool isOpen,string firstComment, int forumId,bool veryUseful)
        {
            Name = name;
            Location = location;
            IsOpen = isOpen;   
            FirstComment = firstComment;
            ForumId = forumId;
            VeryUseful = veryUseful;
        }


    }
}
