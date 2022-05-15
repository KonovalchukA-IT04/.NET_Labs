using DAL.Context;
using DAL.Models;
namespace DAL.Repositories
{
    public class Employee_rep: Repository<Employee>
    {
        public Employee_rep(TMContext context)
        : base(context)
        {
        }
    }
}
