using BLL.Extensions;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories.Interfaces;
namespace BLL.Services
{
    public class TheTask_srv: ITheTask_srv
    {
        private readonly IUnitOfWork _unitOfWork;


        public TheTask_srv(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<TheTask_dto> Create(TheTask_dto t)
        {
            var task = new TheTask
            {
                Id = t.Id,
                Description = t.Description,
                Priority = t.Priority,
                StateId = t.StateId,
                TimeRequired = t.TimeRequired
            };
            await _unitOfWork.TheTask.Create(task);


            return task?.ReturnDto();
        }
        

        public async Task<TheTask_dto> Get(int id)
        {
            var t = await _unitOfWork.TheTask.Get(id);
            return t?.ReturnDto();
        }


        public async Task<IEnumerable<TheTask_dto>> GetAll()
        {
            var task = await _unitOfWork.TheTask.GetAll();
            var res = task.Select(x => x?.ReturnDto());


            return res;
        }


        public async Task<bool> Update(TheTask_dto t)
        {
            var task = await _unitOfWork.TheTask.Get(t.Id);
            if (task == null)
            {
                return false;
            }
            task.Update(t);


            return await _unitOfWork.TheTask.Update(task);
        }


        public async Task<bool> Delete(int id)
        {
            var t = await _unitOfWork.TheTask.Get(id);
            if (t == null)
            {
                return false;
            }
            await _unitOfWork.TheTask.Delete(id);


            return true;
        }
    }
}
