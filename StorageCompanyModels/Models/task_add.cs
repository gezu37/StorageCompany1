using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StorageCompanyModels.Models;

[Table("task_add")]
public partial class task_add
{
    [Key]
    public int task_id { get; set; }

    public int contact_id { get; set; }

    public int storagehouse_id { get; set; }

    public int item_id { get; set; }

    public int add_ammount { get; set; }

    public bool completed { get; set; }

    [ForeignKey("contact_id")]
    [InverseProperty("task_adds")]
    public virtual contact contact { get; set; } = null!;

    [ForeignKey("item_id")]
    [InverseProperty("task_adds")]
    public virtual item item { get; set; } = null!;

    [ForeignKey("storagehouse_id")]
    [InverseProperty("task_adds")]
    public virtual storagehouse storagehouse { get; set; } = null!;
}
