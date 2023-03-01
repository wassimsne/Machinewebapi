
using Machinewebapi.EfCore;
using Machinewebapi.IDAO;
using SharedLibrary.Models;

namespace Machinewebapi.DAOImp
{
    public class DAOImpMachine : IDAOMachine
    {
        private readonly LaverieAppDbContext _db;

        public DAOImpMachine(LaverieAppDbContext db)
        {
            _db = db;
        }
        public bool CreateMachine(Machine machine)
        {
            _db.Machines.Add(machine);
            return Save();
        }

        public bool DeleteMachine(Machine machine)
        {
            _db.Machines.Remove(machine);
            return Save();
        }

        public IQueryable<Machine> GetMachines()
        {
            return _db.Machines.AsQueryable();

        }
        public IQueryable<Machine> GetMachinesbyId(int idLaverie)
        {
            IQueryable<Machine> dataaaa = _db.Machines.Where(x => x.Laverie.IdLav == idLaverie);
            return dataaaa;

        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateMachine(Machine machine)
        {
            _db.Machines.Update(machine);
            return Save();
        }

        public bool MachineExists(int id)
        {
            return _db.Machines.Any(x => x.IdMachine == id);
        }

        public Machine GetMachine(int id)
        {
            return _db.Machines.FirstOrDefault(x => x.IdMachine == id);
        }
        public bool NumeroExists(int numerocode)
        {
            bool value = _db.Machines.Any(y => y.NumeroCode == numerocode);

            return value;
        }


    }
}
