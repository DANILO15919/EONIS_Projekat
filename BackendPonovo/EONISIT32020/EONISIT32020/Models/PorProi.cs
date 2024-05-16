using System;
using System.Collections.Generic;

namespace EONISIT32020.Models;

public partial class PorProi
{
    public int IdPorudzbine { get; set; }

    public int IdProizvoda { get; set; }

    public int? Količina { get; set; }

    public virtual Porudzbina IdPorudzbineNavigation { get; set; } = null!;

    public virtual Proizvod IdProizvodaNavigation { get; set; } = null!;
}
