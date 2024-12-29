using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication20.Models
{
    public class Condition
    {
        public int Id { get; set; }
        public StudyDesk studyDesk { get; set; }
        public enum StudyDesk { Good, Bad }

        [Required(ErrorMessage = "Fridge is required")]

        public Fridge fridge { get; set; }
        public enum Fridge { Good, Bad }

        [Required(ErrorMessage = "Mattress is required")]

        public Mattress mattress { get; set; }
        public enum Mattress { Good, Bad }

        [Required(ErrorMessage = "WallSocket is required")]

        public WallSocket wallSocket { get; set; }
        public enum WallSocket { Good, Bad }

        [Required(ErrorMessage = "Chair is required")]

        public Chair chair { get; set; }
        public enum Chair { Good, Bad }

        [Required(ErrorMessage = "Stove is required")]

        public Stove stove { get; set; }
        public enum Stove { Good, Bad }

        [Required(ErrorMessage = "LightSwitches is required")]

        public LightSwitches lightSwitches { get; set; }
        public enum LightSwitches { Good, Bad }
        [Required]
        
        public string? ConditionImage { get; set; }  // stores movie image name with extension (eg, image0001.jpg)
        
        

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
       


    }
}
