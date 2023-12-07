using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class DataHuis
    {
        [Required, Column(TypeName = "bit")]
        public bool actief { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int nr { get; set; }
        [MaxLength(250)]
        public string straat { get; set; }

        public string ParkId { get; set; }
        public DataPark Park { get; set; }
    }
}
