using System.ComponentModel.DataAnnotations;

namespace DockerApi.Dto
{
    public class CommandCreateDto
    {
        [Required]
        public string HowTo { get; set; }  
        [Required]
        public string Platform { get; set; }
        [Required]
        public string Line { get; set; }
    }
}