using System;
using System.Collections.Generic;

namespace SportskaOpremaIT322020.Models;

public partial class TblUser
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Date { get; set; }

    public string? City { get; set; }

    public string? Adress { get; set; }

    public string? Country { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int? MoneyOnAccount { get; set; }
}
