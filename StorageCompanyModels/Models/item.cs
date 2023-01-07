using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StorageCompanyModels.Models;

public partial class item
{
    [Key]
    public int item_id { get; set; }

    [StringLength(100)]
    public string item_name { get; set; } = null!;

    public int amount_inpackage { get; set; }

    [InverseProperty("item")]
    public virtual ICollection<storage_content> storage_contents { get; } = new List<storage_content>();

    [InverseProperty("item")]
    public virtual ICollection<task_add> task_adds { get; } = new List<task_add>();

    [InverseProperty("item")]
    public virtual ICollection<task_remove> task_removes { get; } = new List<task_remove>();
}
