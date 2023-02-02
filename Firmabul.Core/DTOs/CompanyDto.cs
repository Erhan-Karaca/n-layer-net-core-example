namespace Firmabul.Core.DTOs;

public class CompanyDto : BaseDto
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
    public int SectorId { get; set; }
}