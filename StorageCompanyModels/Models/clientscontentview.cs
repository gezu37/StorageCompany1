using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StorageCompanyModels.Models;

[Keyless]
public partial class clientscontentview
{
    public int? id { get; set; }

    public int? item_id { get; set; }

    public int? amount_of_packages { get; set; }

    public int? storagehouse_id { get; set; }

    public int? owner { get; set; }
}
