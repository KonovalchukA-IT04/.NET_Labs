using BLL.Extensions;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories.Interfaces;
namespace BLL.Services
{
    public class Assigment_srv: IAssigment_srv
    {
        private readonly IUnitOfWork _unitOfWork;


        public Assigment_srv(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Assigment_dto> Create(Assigment_dto asg)
        {
            var assigment = new Assigment
            {
                Id = asg.Id,
                TheTaskId = asg.TheTaskId,
                EmployeeId = asg.EmployeeId
            };
            await _unitOfWork.Assigment.Create(assigment);


            return assigment?.ReturnDto();
        }


        public async Task<Assigment_dto> Get(int id)
        {
            var assigment = await _unitOfWork.Assigment.Get(id);
            return assigment?.ReturnDto();
        }


        public async Task<IEnumerable<Assigment_dto>> GetAll()
        {
            var assigment = await _unitOfWork.Assigment.GetAll();
            var res = assigment.Select(x => x?.ReturnDto());


            return res;
        }


        public async Task<bool> Update(Assigment_dto asg)
        {
            var assigment = await _unitOfWork.Assigment.Get(asg.Id);
            if (assigment == null)
            {
                return false;
            }
            assigment.Update(asg);


            return await _unitOfWork.Assigment.Update(assigment);
        }


        public async Task<bool> Delete(int id)
        {
            var assigment = await _unitOfWork.Assigment.Get(id);
            if (assigment == null)
            {
                return false;
            }
            await _unitOfWork.Assigment.Delete(id);


            return true;
        }
    }
}
