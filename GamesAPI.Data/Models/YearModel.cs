﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPI.Data.Models
{
    public class YearModel
    {
        public int Id { get; set; }
        public int Year { get; set; }


        public virtual ICollection<GamesModel> GamesModels { get; set; }

    }
}
