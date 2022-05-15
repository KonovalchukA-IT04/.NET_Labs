using BLL.Extensions;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories.Interfaces;
namespace BLL.Services
{
    public class Employee_srv: IEmployee_srv
    {
        private readonly IUnitOfWork _unitOfWork;


        public Employee_srv(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Employee_dto> Create(Employee_dto e)
        {
            var employee = new Employee
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                TeamId = e.TeamId

            };
            await _unitOfWork.Employee.Create(employee);


            return employee?.ReturnDto();
        }


        public async Task<Employee_dto> Get(int id)
        {
            var employee = await _unitOfWork.Employee.Get(id);
            return employee?.ReturnDto();
        }


        public async Task<IEnumerable<Employee_dto>> GetAll()
        {
            var employee = await _unitOfWork.Employee.GetAll();
            var res = employee.Select(x => x?.ReturnDto());


            return res;
        }


        public async Task<bool> Update(Employee_dto e)
        {
            var employee = await _unitOfWork.Employee.Get(e.Id);
            if (employee == null)
            {
                return false;
            }
            employee.Update(e);


            return await _unitOfWork.Employee.Update(employee);
        }


        public async Task<bool> Delete(int id)
        {
            var employee = await _unitOfWork.Employee.Get(id);
            if (employee == null)
            {
                return false;
            }
            await _unitOfWork.Employee.Delete(id);


            return true;
        }
    }
}
