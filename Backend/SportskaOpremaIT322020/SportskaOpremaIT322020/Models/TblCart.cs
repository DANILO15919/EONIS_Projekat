using System;
using System.Collections.Generic;

namespace SportskaOpremaIT322020.Models;

public partial class TblCart
{
    public int CartItemId { get; set; }

    public string? ItemBrand { get; set; }

    public string? ItemType { get; set; }

    public string? ItemName { get; set; }

    public int? ItemPrice { get; set; }

    public string? ItemSize { get; set; }

    public string? ItemImage { get; set; }

    public string? ItemDescription { get; set; }
}
