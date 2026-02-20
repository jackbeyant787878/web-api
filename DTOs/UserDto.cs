namespace asp.net_core_8._0_web_api.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreateUserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
}

public class UpdateUserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
}