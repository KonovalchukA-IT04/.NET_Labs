using DAL.Context;
using DAL.Models;
namespace DAL.Repositories
{
    public class State_rep: Repository<State>
    {
        public State_rep(TMContext context)
        : base(context)
        {
        }
    }
}
