namespace Firmabul.Core;

public class Gallery: BaseEntity
{
    public string Name { get; set; }
    public string Image { get; set; }
    public string SortOrder { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
}