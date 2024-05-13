using System;
using System.Collections.Generic;

namespace SportskaOpremaIT322020.Models;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string? BrandName { get; set; }

    public string? Type { get; set; }

    public string? ProductName { get; set; }

    public int? Price { get; set; }

    public string? Size { get; set; }

    public string? ImageSource { get; set; }

    public string? Description { get; set; }
}
