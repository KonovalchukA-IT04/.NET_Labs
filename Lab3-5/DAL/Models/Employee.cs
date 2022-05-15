using DAL.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
namespace DAL.Models
{
    public class Employee: IModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        

        [Required]
        public int TeamId { get; set; }
        public Team Team { get; set; }


        public ICollection<Assigment> Assignments { get; set; }
    }
}
