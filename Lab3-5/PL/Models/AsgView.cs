namespace PL.Models
{
    public class AsgView
    {
        public int Id { get; set; }


        public int TheTaskId { get; set; }
        public string Description { get; set; }
        public double TimeRequired { get; set; }
        public int Priority { get; set; }
        public int StateId { get; set; }


        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TeamId { get; set; }
    }
}
