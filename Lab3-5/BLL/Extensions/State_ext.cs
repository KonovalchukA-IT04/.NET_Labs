using BLL.Models;
using DAL.Models;
namespace BLL.Extensions
{
    public static class State_ext
    {
        public static State_dto ReturnDto(this State st)
        {
            return new State_dto()
            {
                Id = st.Id,
                Name = st.Name
            };
        }

        public static void Update(this State st, State_dto dto)
        {
            st.Name = dto.Name;
        }
    }
}
