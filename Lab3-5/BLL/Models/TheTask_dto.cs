namespace BLL.Models
{
    public class TheTask_dto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double TimeRequired { get; set; }
        public int Priority { get; set; }


        public int StateId { get; set; }
    }
}
