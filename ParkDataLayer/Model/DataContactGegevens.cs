using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class DataContactGegevens
    {
        [Key,MaxLength(100)]
        public string telefoon { get; set; }
        [MaxLength(100)]
        public string email { get; set; }
        [MaxLength(100)]
        public string adres { get; set; }
    }
}
