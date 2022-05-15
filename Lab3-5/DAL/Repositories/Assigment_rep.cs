using DAL.Context;
using DAL.Models;
namespace DAL.Repositories
{
    public class Assigment_rep: Repository<Assigment>
    {
        public Assigment_rep(TMContext context)
        : base(context)
        {
        }
    }
}
