using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models
{
    public class Laverie
    {
        [Key]
        public int IdLav { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Adresse { get; set; }
        public int Telephone { get; set; }
        [Required]
        public string Responsable { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

