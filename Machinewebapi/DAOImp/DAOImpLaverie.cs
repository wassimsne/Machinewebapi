
using AutoMapper;
using Machinewebapi.DTO;
using Machinewebapi.EfCore;
using Machinewebapi.IDAO;
using SharedLibrary.Models;
using System.Linq;

namespace Machinewebapi.DAOImp
{
    public class DAOImpLaverie : IDAOLaverie
    {
        private readonly LaverieAppDbContext _db1;
        private readonly IMapper _mapper;

        public DAOImpLaverie(LaverieAppDbContext db)
        {
            _db1 = db;
        }
        public bool CreateLaverie(Laverie laverie)
        {
            _db1.Laveries.Add(laverie);
            return Save();
        }

        public bool DeleteLaverie(Laverie laverie)
        {
            _db1.Laveries.Remove(laverie);
            return Save();
        }

        public IQueryable<Laverie> GetLaveries()
        {
            return _db1.Laveries.AsQueryable();

        }

        public bool Save()
        {
            return _db1.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateLaverie(Laverie laverie)
        {
            /*Laverie laverie = _mapper.Map<Laverie>(laveriedto);*/
            _db1.Laveries.Update(laverie);
            return Save();
        }

        public bool LaverieExists(int id)
        {
            return _db1.Laveries.Any(x => x.IdLav == id);
        }

        public Laverie GetLaverie(int id)
        {
            return _db1.Laveries.FirstOrDefault(x => x.IdLav == id);
        }
        
        public bool NomExists(string nom)
        {
            bool value = _db1.Laveries.Any(y => y.Nom.ToLower().Trim() == nom.ToLower().Trim());
            return value;
        }

        public IQueryable<Laverie> GetLogin(string Username, string Password)
        {
            return _db1.Laveries.Where(a => a.Username == Username && a.Password == Password);
        }
        
    }
}
