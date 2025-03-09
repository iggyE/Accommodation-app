using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class AccomodationImage
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public AccomodationImage() { }

        public AccomodationImage(int id, string name, string url)
        {
            Id = id;
            Name = name;
            URL = url;
        }

        public override string ToString()
        {
            return $"AccomdationImagesId: {Id}\n, Name: {Name}\n, URL: {URL}\n";
        }
    }
}
