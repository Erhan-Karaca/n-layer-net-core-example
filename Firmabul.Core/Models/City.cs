namespace Firmabul.Core.Models;

public class City: BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public bool Status { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public ICollection<Town> Towns { get; set; }
}