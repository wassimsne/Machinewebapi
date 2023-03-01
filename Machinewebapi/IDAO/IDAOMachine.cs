
using SharedLibrary.Models;

namespace Machinewebapi.IDAO
{
    public interface IDAOMachine
    {
        IQueryable<Machine> GetMachines();

        Machine GetMachine(int id);
        IQueryable<Machine> GetMachinesbyId(int idLaverie);
        bool MachineExists(int id);

        bool CreateMachine(Machine machine);

        bool UpdateMachine(Machine machine);

        bool DeleteMachine(Machine machine);

        bool Save();

        bool NumeroExists(int numerocode);
    }
}
