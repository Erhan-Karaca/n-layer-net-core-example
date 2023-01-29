namespace Firmabul.Core;

public class Sector: BaseEntity
{ 
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public ICollection<Company> Companies { get; set; }
}