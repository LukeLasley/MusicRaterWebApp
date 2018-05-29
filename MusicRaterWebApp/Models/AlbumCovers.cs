﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicRaterWebApp.Models
{
    public class AlbumCovers
    {
        [Key]
        public int id { get; set; }
        public int albumId { get; set; }
        public byte[] albumImage { get; set; }
    }
}