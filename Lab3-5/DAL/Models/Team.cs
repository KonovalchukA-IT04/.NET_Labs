using DAL.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
namespace DAL.Models
{
    public class Team : IModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        public ICollection<Employee> Employees { get; set; }
    }
}