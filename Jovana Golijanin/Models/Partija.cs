namespace Models;

public class Partija
{
    [Key]
    public int ID { get; set; }

    public DateTime VremePocetka { get; set; }

    public DateTime VremeKraja { get; set; }

    public DateTime DuzinaPartije {get; set; }

    //Da, Ne
    public required string PobednikCovek { get; set; }

    public Igrac? Igrac { get; set; }

}