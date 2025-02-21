using Domain.BaseEntities;

namespace Domain.Entities;

public class Product:BaseEntity
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
}
