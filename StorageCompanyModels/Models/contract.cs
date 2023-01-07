using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StorageCompanyModels.Models;

public partial class contract
{
    [Key]
    public int contract_id { get; set; }

    public string contract_text { get; set; } = null!;

    [InverseProperty("contract")]
    public virtual ICollection<client> clients { get; } = new List<client>();
}
