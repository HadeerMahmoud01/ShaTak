using Sha_Task.Base;
using System;
using System.Collections.Generic;

namespace Sha_Task.Models;

public partial class Cashier:IBase
{
    public int Id { get; set; }

    public string CashierName { get; set; } = null!;

    public int BranchId { get; set; }

    public virtual Branch Branch { get; set; } = new Branch();

    public virtual ICollection<InvoiceHeader> InvoiceHeaders { get; set; } = new List<InvoiceHeader>();

    int IBase.Id
    {
        get => (int)Id;
        set => Id = value;
    }
}
