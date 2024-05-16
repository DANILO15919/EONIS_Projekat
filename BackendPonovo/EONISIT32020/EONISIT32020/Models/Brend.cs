using System;
using System.Collections.Generic;

namespace EONISIT32020.Models;

public partial class Brend
{
    public int IdBrenda { get; set; }

    public string? NazivBrenda { get; set; }

    public virtual ICollection<Proizvod> Proizvods { get; set; } = new List<Proizvod>();
}
