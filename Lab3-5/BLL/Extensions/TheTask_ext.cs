using BLL.Models;
using DAL.Models;
namespace BLL.Extensions
{
    public static class TheTask_ext
    {
        public static TheTask_dto ReturnDto(this TheTask tast)
        {
            return new TheTask_dto()
            {
                Id = tast.Id,
                Description = tast.Description,
                TimeRequired = tast.TimeRequired,
                Priority = tast.Priority,


                StateId = tast.StateId
            };
        }

        public static void Update(this TheTask tast, TheTask_dto dto)
        {
            tast.Description = dto.Description;
            tast.TimeRequired = dto.TimeRequired;
            tast.Priority = dto.Priority;


            tast.StateId = dto.StateId;
        }
    }
}
