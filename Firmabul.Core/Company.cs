namespace Firmabul.Core;

public class Company: BaseEntity
{
    public string Name { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string SortDescription { get; set; }
    public string Logo { get; set; }
    public string Cover { get; set; }
    public float Rate { get; set; }
    public int TotalRateCount { get; set; }
    public string WorkTime { get; set; }
    public string WorkDay { get; set; }
    public bool Status { get; set; }
    public int SectorId { get; set; }
    public Sector Sector { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<Gallery> Galleries { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<Comment> Comments { get; set; }
}