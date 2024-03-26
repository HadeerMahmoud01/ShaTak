using Sha_Task.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sha_Task.Models;

public partial class InvoiceDetail:IBase
{
   
    public long Id { get; set; }

    public long InvoiceHeaderId { get; set; }

    public string ItemName { get; set; } 

    public double ItemCount { get; set; }

    public double ItemPrice { get; set; }

    public virtual InvoiceHeader InvoiceHeader { get; set; } = new InvoiceHeader();

    int IBase.Id
    {
        get =>(int) Id;
        set => Id = value;
    }

   

}
