

using Machinewebapi.DTO;
using SharedLibrary.Models;

namespace Machinewebapi.IDAO
{
    public interface IDAOLaverie
    {
        
        IQueryable<Laverie> GetLaveries();
        IQueryable<Laverie> GetLogin(string Username,string Password);

        Laverie GetLaverie(int id);

        bool LaverieExists(int id);

        bool CreateLaverie(Laverie laverie);

        bool UpdateLaverie(Laverie laverie);

        bool DeleteLaverie(Laverie laverie);

        bool Save();

        bool NomExists(string nom);
        

        }
}
