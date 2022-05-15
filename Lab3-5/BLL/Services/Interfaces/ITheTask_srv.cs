using BLL.Models;
namespace BLL.Services.Interfaces
{
    public interface ITheTask_srv
    {
        public Task<TheTask_dto> Create(TheTask_dto e);
        public Task<TheTask_dto> Get(int Id);
        public Task<IEnumerable<TheTask_dto>> GetAll();
        public Task<bool> Update(TheTask_dto e);
        public Task<bool> Delete(int Id);
    }
}
