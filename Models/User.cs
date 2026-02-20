namespace asp.net_core_8._0_web_api.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}