﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPI.Data.Models
{
    public class GamesPlatformMTM
    {
        public int Id { get; set; }

       
        public GamesModel GamesModel { get; set; }

      
        public PlatformModel PlatformModel { get; set; }
    }
}
