using System;
using System.Collections.Generic;

namespace SeoulWEBSession3.Models;

public partial class UserType
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
