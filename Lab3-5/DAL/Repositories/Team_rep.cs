using DAL.Context;
using DAL.Models;
namespace DAL.Repositories
{
    public class Team_rep: Repository<Team>
    {
        public Team_rep(TMContext context)
        : base(context)
        {
        }
    }
}
