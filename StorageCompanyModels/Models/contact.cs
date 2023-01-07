using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StorageCompanyModels.Models;

public partial class contact
{
    [Key]
    public int contact_id { get; set; }

    [StringLength(100)]
    public string contact_name { get; set; } = null!;

    public int? contact_phone { get; set; }

    [InverseProperty("contact")]
    public virtual ICollection<client> clients { get; } = new List<client>();

    [InverseProperty("contact")]
    public virtual ICollection<task_add> task_adds { get; } = new List<task_add>();

    [InverseProperty("contact")]
    public virtual ICollection<task_remove> task_removes { get; } = new List<task_remove>();
}
