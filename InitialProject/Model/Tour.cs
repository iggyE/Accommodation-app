using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities;
public class Tour
{
    [Key]
    public int TourId { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public string Language { get; set; }

    public int MaxGuests { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int Duration { get; set; }

    public List<TourImages> Images { get; set; }

    public List<Checkpoint> Checkpoints { get; set; }

    public List<Tourist> Tourists { get; set; }

    public Tour() { }

    public Tour(int tourId, string name, string description, string language, int maxGuests, DateTime startTime, DateTime endTime, int duration)
    {
        TourId = tourId;
        Name = name;
        Description = description;
        Language = language;
        MaxGuests = maxGuests;
        StartTime = startTime;
        EndTime = endTime;
        Duration = duration;
    }
}

