using System;
using System.Collections.Generic;

namespace ImSoftware.Api.Database.Model;

public partial class User
{
    public long IdUser { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Email { get; set; } = null!;

    public int RegDeleted { get; set; }
}
