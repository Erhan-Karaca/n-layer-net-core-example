namespace Firmabul.Core;

public class Address: BaseEntity
{
    public string Name { get; set; }
    public string Value { get; set; }
    public string GoogleMaps { get; set; }
    public string PostalCode { get; set; }
    public string Email { get; set; }
    public string Email2 { get; set; }
    public string Phone { get; set; }
    public string Phone2 { get; set; }
    public string Fax { get; set; }
    public string Fax2 { get; set; }
    public bool Default { get; set; }
    public bool Status { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    public int TownId { get; set; }
    public Town Town { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
}