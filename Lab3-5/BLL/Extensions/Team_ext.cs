using BLL.Models;
using DAL.Models;
namespace BLL.Extensions
{
    public static class Team_ext
    {
        public static Team_dto ReturnDto(this Team team)
        {
            return new Team_dto()
            {
                Id = team.Id,
                Name = team.Name
            };
        }

        public static void Update(this Team team, Team_dto dto)
        {
            team.Name = dto.Name;
        }
    }
}
