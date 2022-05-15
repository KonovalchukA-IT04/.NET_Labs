using BLL.Models;
namespace BLL.Services.Interfaces
{
    public interface IEmployee_srv
    {
        public Task<Employee_dto> Create(Employee_dto e);
        public Task<Employee_dto> Get(int Id);
        public Task<IEnumerable<Employee_dto>> GetAll();
        public Task<bool> Update(Employee_dto e);
        public Task<bool> Delete(int Id);
    }
}
