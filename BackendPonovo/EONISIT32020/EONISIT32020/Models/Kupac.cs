using System;
using System.Collections.Generic;

namespace EONISIT32020.Models;

public partial class Kupac
{
    public int IdKupca { get; set; }

    public int? IdKorisnika { get; set; }

    public string? Ime { get; set; }

    public string? Prezime { get; set; }

    public string? Adresa { get; set; }

    public string? Telefon { get; set; }

    public DateOnly? DatumRegistracije { get; set; }

    public virtual Korisnik? IdKorisnikaNavigation { get; set; }

    public virtual ICollection<Porudzbina> Porudzbinas { get; set; } = new List<Porudzbina>();
}
