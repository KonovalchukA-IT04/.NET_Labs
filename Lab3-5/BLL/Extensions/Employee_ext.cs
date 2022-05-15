using BLL.Models;
using DAL.Models;
namespace BLL.Extensions
{
    public static class Employee_ext
    {
        public static Employee_dto ReturnDto(this Employee emp)
        {
            return new Employee_dto()
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,


                TeamId = emp.TeamId,
            };
        }

        public static void Update(this Employee emp, Employee_dto dto)
        {
            emp.FirstName = dto.FirstName;
            emp.LastName = dto.LastName;


            emp.TeamId = dto.TeamId;
        }
    }
}
