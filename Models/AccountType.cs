namespace Backend.Models;

public class AccountType
{
    public string Id { get; private set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int RequiredAge { get; set; }

    public AccountType()
    {
        Id = Guid.NewGuid().ToString();
    }
}