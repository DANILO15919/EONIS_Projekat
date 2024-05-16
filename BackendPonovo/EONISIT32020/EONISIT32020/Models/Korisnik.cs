using System;
using System.Collections.Generic;

namespace EONISIT32020.Models;

public partial class Korisnik
{
    public int IdKorisnika { get; set; }

    public string? Email { get; set; }

    public string? Lozinka { get; set; }

    public string? Uloga { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Kupac> Kupacs { get; set; } = new List<Kupac>();
}
