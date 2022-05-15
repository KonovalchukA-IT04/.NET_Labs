using System.ComponentModel.DataAnnotations;
namespace DAL.Models.Interfaces
{
    public interface IModel
    {
        [Key]
        public int Id { get; set; }
    }
}
