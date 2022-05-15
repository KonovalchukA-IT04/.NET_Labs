using DAL.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
namespace DAL.Models
{
    public class Assigment: IModel
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public int TheTaskId { get; set; }
        public TheTask TheTask { get; set; }


        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
