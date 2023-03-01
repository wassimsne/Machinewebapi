using SharedLibrary.Models;
using static SharedLibrary.Models.Machine;

namespace Machinewebapi.DTO
{
    public class LaverieDTO
    {


        public string Nom { get; set; }
  
        public string Adresse { get; set; }
        public int Telephone { get; set; }
     
        public string Responsable { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

}

