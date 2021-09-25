using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NoInc.TestProject.Models.Requests
{
    public class CreateSkillRequest
    {
        [Required]
        [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
        [Description("Name of the skill")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("Essential|Practical|Professional", ErrorMessage = "Value must be either 'Essential', 'Practical', or 'Professional'")]
        [Description("Is the skill Essential, Practical, or Professional")]
        public string Type { get; set; }

        [Required]
        [Description("When was the skill learned?")]
        public DateTime DateLearned { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Detail cannot exceed 150 characters.")]
        [Description("Description of the skill")]
        public string Detail { get; set; }
    }
}