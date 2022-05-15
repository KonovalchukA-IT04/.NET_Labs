using BLL.Extensions;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories.Interfaces;
namespace BLL.Services
{
    public class State_srv: IState_srv
    {
        private readonly IUnitOfWork _unitOfWork;


        public State_srv(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<State_dto> Create(State_dto s)
        {
            var state = new State
            {
                Id = s.Id,
                Name = s.Name
            };
            await _unitOfWork.State.Create(state);


            return state?.ReturnDto();
        }


        public async Task<State_dto> Get(int id)
        {
            var state = await _unitOfWork.State.Get(id);
            return state?.ReturnDto();
        }


        public async Task<IEnumerable<State_dto>> GetAll()
        {
            var state = await _unitOfWork.State.GetAll();
            var res = state.Select(x => x?.ReturnDto());


            return res;
        }


        public async Task<bool> Update(State_dto s)
        {
            var state = await _unitOfWork.State.Get(s.Id);
            if (state == null)
            {
                return false;
            }
            state.Update(s);


            return await _unitOfWork.State.Update(state);
        }


        public async Task<bool> Delete(int id)
        {
            var state = await _unitOfWork.State.Get(id);
            if (state == null)
            {
                return false;
            }
            await _unitOfWork.State.Delete(id);


            return true;
        }
    }
}
