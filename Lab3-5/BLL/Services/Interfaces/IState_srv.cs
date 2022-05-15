using BLL.Models;
namespace BLL.Services.Interfaces
{
    public interface IState_srv
    {
        public Task<State_dto> Create(State_dto e);
        public Task<State_dto> Get(int Id);
        public Task<IEnumerable<State_dto>> GetAll();
        public Task<bool> Update(State_dto e);
        public Task<bool> Delete(int Id);
    }
}
