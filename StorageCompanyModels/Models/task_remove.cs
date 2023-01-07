using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StorageCompanyModels.Models;

[Table("task_remove")]
public partial class task_remove
{
    [Key]
    public int task_id { get; set; }

    public int contact_id { get; set; }

    public int storagehouse_id { get; set; }

    public int item_id { get; set; }

    public int remove_ammount { get; set; }

    public bool completed { get; set; }

    [ForeignKey("contact_id")]
    [InverseProperty("task_removes")]
    public virtual contact contact { get; set; } = null!;

    [ForeignKey("item_id")]
    [InverseProperty("task_removes")]
    public virtual item item { get; set; } = null!;

    [ForeignKey("storagehouse_id")]
    [InverseProperty("task_removes")]
    public virtual storagehouse storagehouse { get; set; } = null!;
}
