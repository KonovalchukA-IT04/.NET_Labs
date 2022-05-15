using DAL.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
namespace DAL.Models
{
    public class State: IModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        public ICollection<TheTask> TheTasks { get; set; }
    }
}
