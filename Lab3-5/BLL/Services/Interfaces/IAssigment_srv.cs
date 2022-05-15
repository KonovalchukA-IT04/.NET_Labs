using BLL.Models;
namespace BLL.Services.Interfaces
{
    public interface IAssigment_srv
    {
        public Task<Assigment_dto> Create(Assigment_dto e);
        public Task<Assigment_dto> Get(int Id);
        public Task<IEnumerable<Assigment_dto>> GetAll();
        public Task<bool> Update(Assigment_dto e);
        public Task<bool> Delete(int Id);
    }
}
