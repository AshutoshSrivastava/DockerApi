using System.ComponentModel.DataAnnotations;

namespace DockerApi.Dto
{
    public class CommandUpdateDto
    {
        [Required]
        public string HowTo { get; set; }  
        [Required]
        public string Platform { get; set; }
        [Required]
        public string Line { get; set; }
    }
}