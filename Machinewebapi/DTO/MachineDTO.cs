using SharedLibrary.Models;
using static SharedLibrary.Models.Machine;

namespace Machinewebapi.DTO
{
    public class MachineDTO
    {

        
        public int IdLaverie { get; set; }
        public EtatMachine EtatMachine { get; set; }
        public int DureeToalDeFonctionnement { get; set; }
        public int NumeroCode { get; set; }

    }
}
