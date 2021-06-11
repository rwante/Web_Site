using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Esya
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public Boolean ilanDurumu { get; set; }
        public String ilanBasligi { get; set; }
        public String ad { get; set; }
        public String soyad { get; set; }
        public String adres { get; set; }
        public String sehir { get; set; }
        public String ilce { get; set; }
        public String detay { get; set; }
        public byte[] resim { get; set; }
    }
}
