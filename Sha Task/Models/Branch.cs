using System;
using System.Collections.Generic;

namespace Sha_Task.Models;

public partial class Branch
{
    public int Id { get; set; }

    public string BranchName { get; set; } 

    public int CityId { get; set; }

    public virtual ICollection<Cashier> Cashiers { get; set; } = new List<Cashier>();

    public virtual City City { get; set; } = new City();

    public virtual ICollection<InvoiceHeader> InvoiceHeaders { get; set; } = new List<InvoiceHeader>();
}
