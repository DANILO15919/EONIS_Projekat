using System;
using System.Collections.Generic;

namespace EONISIT32020.Models;

public partial class Porudzbina
{
    public int IdPorudzbine { get; set; }

    public int? BrojStavki { get; set; }

    public int? IdKupca { get; set; }

    public DateOnly? DatumPorudzbine { get; set; }

    public int? UkupnaCena { get; set; }

    public virtual Kupac? IdKupcaNavigation { get; set; }

    public virtual ICollection<PorProi> PorProis { get; set; } = new List<PorProi>();
}
