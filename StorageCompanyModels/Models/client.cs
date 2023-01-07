using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StorageCompanyModels.Models;

[Table("client")]
public partial class client
{
    [Key]
    public int company_id { get; set; }

    [StringLength(150)]
    public string company_name { get; set; } = null!;

    public int contact_id { get; set; }

    public int contract_id { get; set; }

    [ForeignKey("contact_id")]
    [InverseProperty("clients")]
    public virtual contact contact { get; set; } = null!;

    [ForeignKey("contract_id")]
    [InverseProperty("clients")]
    public virtual contract contract { get; set; } = null!;

    [InverseProperty("ownerNavigation")]
    public virtual ICollection<storage_content> storage_contents { get; } = new List<storage_content>();
}
