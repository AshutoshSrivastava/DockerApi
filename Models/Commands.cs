using System.ComponentModel.DataAnnotations;

namespace DockerApi.Models
{
    public class Commands
    {
        [Key]
        public int Id { get; set; }
        public string HowTo { get; set; }  
        [Required]
        public string Platform { get; set; }
        public string  Commandsline { get; set; }
        public string Line { get; set; }
    }
}