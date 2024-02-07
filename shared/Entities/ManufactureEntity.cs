using System.ComponentModel.DataAnnotations;

namespace shared.Entities;

public class ManufactureEntity
{
    [Key]
    public int Id { get; set; }
    public string ManufactureName { get; set; } = null!;
    public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
