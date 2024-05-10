using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Requests
{
    public class JobRequest
    {
        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public string Salary { get; set; }

        [Required]
        public string Responsiblities { get; set; }

        [Required]
        public string Qualifications { get; set; }

        [Required]
        public string SelectedSkills { get; set; } = "";


        [Required]
        [Display(Name = "Job Function")]
        public string JobFunction { get; set; } = "Information Technology";


        [Required]
        public string WorkLocationType { get; set; } = "";

        [Required]
        public string WorkType { get; set; } = "";

        [Required]
        public string ContactEmail { get; set; }
    }
}
