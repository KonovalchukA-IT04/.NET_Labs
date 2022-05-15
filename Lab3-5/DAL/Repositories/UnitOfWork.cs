using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;
namespace DAL.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly TMContext _context;


        public UnitOfWork(
            TMContext context,
            IRepository<Employee> employees,
            IRepository<State> states,
            IRepository<Team> teams,
            IRepository<TheTask> tasks,
            IRepository<Assigment> assigment)
        {
            _context = context;
            Employee = employees;
            State = states;
            Team = teams;
            TheTask = tasks;
            Assigment = assigment;
        }


        public IRepository<Employee> Employee { get; }
        public IRepository<State> State { get; }
        public IRepository<Team> Team { get; }
        public IRepository<TheTask> TheTask { get; }
        public IRepository<Assigment> Assigment { get; }


        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
