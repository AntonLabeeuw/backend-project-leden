namespace Leden.API.Configuration;

public class DatabaseSettings
{
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
    public string? LidCollection { get; set; }
    public string? TakCollection { get; set; }
    public string? GroepCollection { get; set; }
}