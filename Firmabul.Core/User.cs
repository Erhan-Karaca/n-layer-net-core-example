namespace Firmabul.Core;

public class User: BaseEntity
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Image { get; set; }
    public string GoogleId { get; set; }
    public bool Verified { get; set; }
    public DateTime LastLogin { get; set; }
    public bool Status { get; set; }
    public ICollection<Company> Companies { get; set; }
    public ICollection<Comment> Comments { get; set; }
}