using DAL.Context;
using DAL.Models;
namespace DAL.Repositories
{
    public class TheTask_rep : Repository<TheTask>
    {
        public TheTask_rep(TMContext context)
        : base(context)
        {
        }
    }
}
