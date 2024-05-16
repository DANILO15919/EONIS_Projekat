using System;
using System.Collections.Generic;

namespace EONISIT32020.Models;

public partial class Proizvod
{
    public int IdProizvoda { get; set; }

    public int? IdBrenda { get; set; }

    public string? Naziv { get; set; }

    public int? Cena { get; set; }

    public string? Veličina { get; set; }

    public string? Boja { get; set; }

    public string? Opis { get; set; }

    public int? KoličinaNaStanju { get; set; }

    public string? Slika { get; set; }

    public virtual Brend? IdBrendaNavigation { get; set; }

    public virtual ICollection<PorProi> PorProis { get; set; } = new List<PorProi>();
}
