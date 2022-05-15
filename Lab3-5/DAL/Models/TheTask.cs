using DAL.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
namespace DAL.Models
{
    public class TheTask: IModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Priority { get; set; }
        public double TimeRequired { get; set; }


        [Required]
        public int StateId { get; set; }
        public State State { get; set; }


        public ICollection<Assigment> Assignments { get; set; }
    }
}
