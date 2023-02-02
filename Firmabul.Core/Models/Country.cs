namespace Firmabul.Core.Models;

public class Country: BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public bool Status { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<City> Cities { get; set; }
}