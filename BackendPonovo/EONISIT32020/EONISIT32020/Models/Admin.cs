using System;
using System.Collections.Generic;

namespace EONISIT32020.Models;

public partial class Admin
{
    public int IdAdmina { get; set; }

    public int? IdKorisnika { get; set; }

    public string? Ime { get; set; }

    public virtual Korisnik? IdKorisnikaNavigation { get; set; }
}
