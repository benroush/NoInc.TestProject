using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NoInc.TestProject.Models.Requests
{
    public class CreateInterestRequest
    {
        [Required]
        [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
        [Description("Name of the interest")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("Sport|Game", ErrorMessage = "Value must be either 'Sport' or 'Game'")]
        [Description("Is the interest a Sport or a Game")]
        public string Type { get; set; }

        [Required]
        [Description("Is the interest current?")]
        public bool IsCurrent { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Detail cannot exceed 150 characters.")]
        [Description("Description of the interest")]
        public string Detail { get; set; }
    }
}