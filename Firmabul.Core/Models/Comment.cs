namespace Firmabul.Core.Models;

public class Comment: BaseEntity
{
    public string Value { get; set; }
    public string Images { get; set; }
    public float Rate { get; set; }
    public bool Status { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}