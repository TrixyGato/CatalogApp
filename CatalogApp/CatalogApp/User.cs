using System.ComponentModel.DataAnnotations;

namespace CatalogApp
{
  public class User
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

  }
}