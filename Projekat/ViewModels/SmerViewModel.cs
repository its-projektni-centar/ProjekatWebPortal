﻿using System;
using System.Collections.Generic;
using System.Linq;
using Projekat.Models;
using Projekat.ViewModels;

namespace Projekat.ViewModels
{
    public class SmerViewModel
    {
        public IEnumerable<SmerModel> smerovi { get; set; }
        public SmerModel smeroviModel { get; set; }
    }
}