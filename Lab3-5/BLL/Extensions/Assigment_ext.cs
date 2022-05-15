using BLL.Models;
using DAL.Models;
namespace BLL.Extensions
{
    public static class Assigment_ext
    {
        public static Assigment_dto ReturnDto(this Assigment asg)
        {
            return new Assigment_dto()
            {
                Id = asg.Id,


                TheTaskId = asg.TheTaskId,
                EmployeeId = asg.EmployeeId
            };
        }

        public static void Update(this Assigment asg, Assigment_dto dto)
        {
            asg.TheTaskId = dto.TheTaskId;
            asg.EmployeeId = dto.EmployeeId;
        }
    }
}
