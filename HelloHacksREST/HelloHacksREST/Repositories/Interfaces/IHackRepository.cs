using HelloHacksREST.Models;
using System.Collections.Generic;

namespace HelloHacksREST.Repositories.Interfaces
{
    interface IHackRepository
    {
        Hack Get(int Id);

        List<Hack> GetAll();

        bool Add(Hack hack);

        bool Update(Hack hack);

        bool Delete(int Id);
    }
}
