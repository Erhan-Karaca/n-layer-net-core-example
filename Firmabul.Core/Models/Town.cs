namespace Firmabul.Core.Models;

public class Town: BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public bool Status { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
}