namespace Models;

public class Context : DbContext
{

    public required DbSet<Igrac> Igrac { get; set; }
    public required DbSet<Partija> Partija { get; set; }
    public Context(DbContextOptions options) : base(options)
    {
        
    }

}
