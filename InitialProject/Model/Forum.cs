using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Model
{
    public class Forum
    {
        [Key]
        public int ForumId { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }

        public bool IsOpen { get; set; }

        public string FirstComment { get; set; }
        public bool VeryUseful { get; set; }

        public Forum() { }

        public Forum(int forumId, string name,int locationId, bool isOpen,string firstComment ,bool veryUseful)
        {   
            ForumId = forumId;
            Name = name;
            LocationId = locationId;
            IsOpen = isOpen;
            FirstComment = firstComment;
            VeryUseful = veryUseful;
        }

        public override string ToString()
        {
            return $"Location: {LocationId}\n, Opened: {IsOpen}\n, Comments:\n";
        }
    }
}
