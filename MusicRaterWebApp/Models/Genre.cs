﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicRaterWebApp.Models
{
    public class Genre
    {
        [Key]
        public int id { get; set; }
        public String genre { get; set; }
    }
}