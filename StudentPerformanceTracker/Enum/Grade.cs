using System.ComponentModel.DataAnnotations;

namespace StudentPerformanceTracker.Models
{
    public enum Grade
    {
        [Display(Name = "A+")]
        A_Plus,
        [Display(Name = "A")]
        A,
        [Display(Name = "A-")]
        A_Minus,
        [Display(Name = "B+")]
        B_Plus,
        [Display(Name = "B")]
        B,
        [Display(Name = "B-")]
        B_Minus,
        [Display(Name = "C+")]
        C_Plus,
        [Display(Name = "C")]
        C,
        [Display(Name = "C-")]
        C_Minus,
        [Display(Name = "E")]
        E
    }
}
