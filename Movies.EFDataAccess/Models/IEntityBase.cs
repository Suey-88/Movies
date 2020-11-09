using System.ComponentModel.DataAnnotations;

namespace Movies.EFDataAccess.Models
{
    public interface IEntityBase
    {
        [Key]
        int Id { get; set; }
    }
}
