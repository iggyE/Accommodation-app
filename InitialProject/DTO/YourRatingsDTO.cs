using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.DTO
{
    public class YourRatingsDTO
    {

        public int Cleanliness { get; set; }
        public int RuleCompliance { get; set; }

        public string Comment { get; set; }

        public YourRatingsDTO(int cleanliness,int ruleCompliance,string comment) 
        {
            Cleanliness = cleanliness;
            RuleCompliance = ruleCompliance;
            Comment = comment;
        }
    }
}
