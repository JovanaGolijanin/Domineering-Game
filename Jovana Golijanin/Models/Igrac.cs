namespace Models;
public class Igrac
{
    [Key]
    public int ID { get; set; }

    public required string Ime { get; set; }

    public int BrojIndeksa { get; set; }

    public int BrojPobeda { get; set; }

    public int BrojNeresenih { get; set; }

    public int BrojPoraza { get; set; }

    public List<Partija>? ListaPartija { get; set; }

}
