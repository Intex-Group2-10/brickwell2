using System;
using System.Collections;
using System.Collections.Generic;

namespace brickwell2.Models;

public partial class Customer : IEnumerable
{
    public int? CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? CountryOfResidence { get; set; }

    public string? Gender { get; set; }
    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
