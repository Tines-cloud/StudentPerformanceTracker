using StudentPerformanceTracker.Models;
using StudentPerformanceTracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceTracker.Model
{
    public class Prediction
    {
        public string Week { get; set; }

        public string DateRange { get; set; }

        public double StudyHours { get; set; }

        public Grade Grade { get; set; }

        public double Percentage { get; set; }

        [Display(Name = "Grade Name")]
        public string GradeDisplayName => EventService.GetEnumDisplayName(Grade);
    }
}
