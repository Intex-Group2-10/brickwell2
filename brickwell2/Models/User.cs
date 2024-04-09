﻿using System;
using System.Collections.Generic;

namespace brickwell2.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool TwoFactor { get; set; }

    public bool Admin { get; set; }
}
