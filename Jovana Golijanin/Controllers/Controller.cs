namespace Controllers;

[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase
{
    public Context Context { get; set; }

    public Controller(Context context)
    {
        Context = context;
    }

    [HttpPost("DodajIgraca")]
    public async Task<ActionResult> DodajIgraca(string ime, int brojIndeksa)
    {
        try
        {
            var dohvati = await Context.Igrac.Where(p=>p.BrojIndeksa == brojIndeksa).FirstOrDefaultAsync();

            if(dohvati != null)
                return StatusCode(202, "Igrac sa datim brojem indeksa vec postoji u bazi");
        
            Igrac igrac = new Igrac
            {
                Ime = ime,
                BrojIndeksa = brojIndeksa
            };

            Context.Igrac.Add(igrac);
            await Context.SaveChangesAsync();
            return Ok($"Dodat je novi igrac sa brojem indeksa: {igrac.BrojIndeksa}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("VratiIgrace")]
    public async Task<ActionResult> VratiIgrace()
    {
         try
        {
            var igraci = await Context.Igrac.Select(p=>new{
                id = p.ID,
                ime = p.Ime,
                brojIndeksa = p.BrojIndeksa,
                brojPobeda = p.BrojPobeda
            }).ToListAsync();

            return Ok(igraci);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("VratiIgraca")]
    public async Task<ActionResult> VratiIgraca(int brojIndeksa)
    {
         try
        {
            var igrac = await Context.Igrac.Where(p=>p.BrojIndeksa == brojIndeksa).ToListAsync();

            return Ok(igrac);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("DodajPobedu")]
    public async Task<ActionResult> DodajPobedu(int brojIndeksa)
    {
         try
        {
            var igrac = await Context.Igrac.Where(p=>p.BrojIndeksa == brojIndeksa).FirstOrDefaultAsync();

            igrac!.BrojPobeda = igrac.BrojPobeda +1;
            
            Context.Igrac.Update(igrac);
            await Context.SaveChangesAsync();

            return Ok(igrac);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    
    [HttpPut("DodajPoraz")]
    public async Task<ActionResult> DodajPoraz(int brojIndeksa)
    {
         try
        {
            var igrac = await Context.Igrac.Where(p=>p.BrojIndeksa == brojIndeksa).FirstOrDefaultAsync();

            igrac!.BrojPoraza = igrac.BrojPoraza + 1;
            
            Context.Igrac.Update(igrac);
            await Context.SaveChangesAsync();
            
            return Ok(igrac);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}