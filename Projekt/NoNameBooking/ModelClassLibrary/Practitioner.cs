﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary
{
    public class Practitioner : User
    {
        public TimeSpan Availability { get; set; }
    }
}