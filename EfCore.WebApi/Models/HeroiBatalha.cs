using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.WebApi.Models
{
    public class HeroiBatalha
    {
        public int HeroiId { get; set; }
        public int BatalhaId { get; set; }
        public Heroi Heroi { get; set; }
        public Batalha Batalha  { get; set; }
    }
}