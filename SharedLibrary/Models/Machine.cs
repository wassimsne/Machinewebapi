
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLibrary.Models

{
    public enum EtatMachine { enMarche, arret, horsService };

    public class Machine
    {
        [Key]
        public int IdMachine { get; set; }

        [Required]
        [ForeignKey("IdLaverie")]
        /*public int IdLaverie { get; set; }*/
        public Laverie Laverie { get; set; }
        [Required]
        public EtatMachine EtatMachine { get; set; }
        public int DureeToalDeFonctionnement { get; set; }
        public int NumeroCode { get; set; }

        /*public Machine ( int idmachine,int )
            {
}*/
    }
}
