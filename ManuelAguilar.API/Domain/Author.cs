namespace ManuelAguilar.API.Domain;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
	public ICollection<Post>? Posts { get; set; }
}

