﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RateEverything.Areas.Identity.Data;

// Add profile data for application users by adding properties to the RateEverythingUser class
public class RateEverythingUser : IdentityUser
{
    public string DisplayName { get; set; }

    [PersonalData]
    public DateTime DateOfBirth { get; set; }
}

