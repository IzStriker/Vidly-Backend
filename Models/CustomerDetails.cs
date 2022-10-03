namespace Backend.Models;

public class CustomerDetails
{
    public string Id { get; private set; }
    public DateOnly DateOfBirth { get; set; }
    public ApplicationUser User { get; set; } = new ApplicationUser();
    public string ApplicationUserId { get; private set; } = string.Empty;

    public AccountType AccountType { get; set; } = new AccountType();

    public CustomerDetails()
    {
        Id = Guid.NewGuid().ToString();
    }
}