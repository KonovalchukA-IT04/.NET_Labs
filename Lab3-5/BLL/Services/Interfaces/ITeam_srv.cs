using BLL.Models;
namespace BLL.Services.Interfaces
{
    public interface ITeam_srv
    {
        public Task<Team_dto> Create(Team_dto e);
        public Task<Team_dto> Get(int Id);
        public Task<IEnumerable<Team_dto>> GetAll();
        public Task<bool> Update(Team_dto e);
        public Task<bool> Delete(int Id);
    }
}
