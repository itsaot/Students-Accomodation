using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WebApplication20.Models.RoomCondition;

namespace WebApplication20.Models
{
    public class RoomCondition
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "StudyDesk is required")]

        public StudyDesk studyDesk { get; set; }
        public enum StudyDesk { Good,Bad }

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

        [Display(Name = "Discription")]
        public string Discription { get; set; }

        


    }
}
