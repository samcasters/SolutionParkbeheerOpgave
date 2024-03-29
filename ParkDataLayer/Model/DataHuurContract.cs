﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class DataHuurContract
    {
        [Key, MaxLength(25)]
        public string Id { get; set; }

        public int HuurderId { get; set; }
        public DataHuurder Huurder { get; set; }
        public int HuurPeriodeId { get; set; }
        public DataHuurPeriode HuurPeriode { get; set; }
        public int HuisId { get; set; }
        public DataHuis Huis { get; set; }  
    }
}
