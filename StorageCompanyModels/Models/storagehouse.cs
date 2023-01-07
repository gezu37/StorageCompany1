using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StorageCompanyModels.Models;

public partial class storagehouse
{
    [Key]
    public int storagehouse_id { get; set; }

    [StringLength(150)]
    public string storagehouse_address { get; set; } = null!;

    [StringLength(100)]
    public string storagehouse_manager { get; set; } = null!;

    [InverseProperty("storagehouse")]
    public virtual ICollection<storage_content> storage_contents { get; } = new List<storage_content>();

    [InverseProperty("storagehouse")]
    public virtual ICollection<task_add> task_adds { get; } = new List<task_add>();

    [InverseProperty("storagehouse")]
    public virtual ICollection<task_remove> task_removes { get; } = new List<task_remove>();
}
