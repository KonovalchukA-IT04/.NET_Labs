using BLL.Extensions;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories.Interfaces;
namespace BLL.Services
{
    public class Team_srv: ITeam_srv
    {
        private readonly IUnitOfWork _unitOfWork;


        public Team_srv(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Team_dto> Create(Team_dto t)
        {
            var team = new Team
            {
                Id = t.Id,
                Name = t.Name
            };
            await _unitOfWork.Team.Create(team);


            return team?.ReturnDto();
        }


        public async Task<bool> Update(Team_dto t)
        {
            var team = await _unitOfWork.Team.Get(t.Id);
            if (team == null)
            {
                return false;
            }
            team.Update(t);


            return await _unitOfWork.Team.Update(team);
        }


        public async Task<Team_dto> Get(int id)
        {
            var team = await _unitOfWork.Team.Get(id);
            return team?.ReturnDto();
        }


        public async Task<IEnumerable<Team_dto>> GetAll()
        {
            var team = await _unitOfWork.Team.GetAll();
            var res = team.Select(x => x.ReturnDto());


            return res;
        }


        public async Task<bool> Delete(int id)
        {
            var team = await _unitOfWork.Team.Get(id);
            if (team == null)
            {
                return false;
            }
            await _unitOfWork.Team.Delete(id);


            return true;
        }
    }
}
