﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class IndexViewModel
    {
        public BoardBoxViewModel[] Boards { get; set; }
    }
}