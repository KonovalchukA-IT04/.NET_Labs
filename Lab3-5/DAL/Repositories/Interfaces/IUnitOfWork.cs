using DAL.Models;
namespace DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Employee> Employee { get; }
        IRepository<Team> Team { get; }
        IRepository<State> State { get; }
        IRepository<TheTask> TheTask { get; }
        IRepository<Assigment> Assigment { get; }


        Task Save();
    }
}
