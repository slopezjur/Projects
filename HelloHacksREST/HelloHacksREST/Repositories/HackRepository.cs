using HelloHacksREST.Models;
using HelloHacksREST.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HelloHacksREST.Repositories;

namespace HelloREST.Repositories
{
    public class HackRepository : IHackRepository
    {
        private HackDBContext _dbContextHack;

        public HackRepository(HackDBContext dbContext)
        {
            _dbContextHack = dbContext;
        }

        public Hack Get(int Id)
        {
            return _dbContextHack.Hacks.Find(Id);
        }

        public List<Hack> GetAll()
        {
            return _dbContextHack.Hacks.ToList<Hack>();
        }

        public bool Add(Hack hack)
        {
            if (_dbContextHack != null)
            {
            // Begin transaction
                try
                {
                    Hack hackType =  new Hack();

                    hackType.Name = hack.Name;
                    hackType.Description = hack.Description;

                    _dbContextHack.Hacks.Add(hackType);
                    _dbContextHack.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }

        public bool Update(Hack hack)
        {
            if (_dbContextHack != null)
            {
            // Begin transaction
                try
                {
                    var hackToModify = _dbContextHack.Hacks.Find(hack.Id);

                    hackToModify.Name = hack.Name;
                    hackToModify.Description = hack.Description;

                    _dbContextHack.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }

        public bool Delete(int Id)
        {
            if (_dbContextHack != null)
            {
            // Begin transaction
                try
                {
                    var hackToDelete = _dbContextHack.Hacks.Find(Id);

                    _dbContextHack.Hacks.Remove(hackToDelete);

                    _dbContextHack.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}
