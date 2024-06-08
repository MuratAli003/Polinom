using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinom
{
    public class Polinom
    {
        
        public int toplam_terim_sayisi;

        public int[] katsayilar;

        public int[] kuvvetler;
            
        public Polinom(int toplam_terim_sayisi, int[] katsayılar, int[] kuvvetler)
        {
            this.toplam_terim_sayisi = toplam_terim_sayisi;

            this.katsayilar = katsayılar;

            this.kuvvetler = kuvvetler;
        }
    }
}
