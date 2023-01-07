using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StorageCompanyModels.Models;

public partial class storage_content
{
    [Key]
    public int id { get; set; }

    public int item_id { get; set; }

    public int amount_of_packages { get; set; }

    public int storagehouse_id { get; set; }

    public int owner { get; set; }

    [ForeignKey("item_id")]
    [InverseProperty("storage_contents")]
    public virtual item item { get; set; } = null!;

    [ForeignKey("owner")]
    [InverseProperty("storage_contents")]
    public virtual client ownerNavigation { get; set; } = null!;

    [ForeignKey("storagehouse_id")]
    [InverseProperty("storage_contents")]
    public virtual storagehouse storagehouse { get; set; } = null!;
}
