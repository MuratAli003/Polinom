using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polinom
{
    public class PolinomIslem
    {

        public static Polinom PolinomOlustur(string denklem)
        {
            int toplamTerim = PolinomIslem.TerimSayisi(denklem);
            int[] katsayilar = PolinomIslem.KatsayıListele(denklem);
            int[] kuvvetler = PolinomIslem.KuvvetListele(denklem);

            Polinom polinom = new Polinom(toplamTerim, katsayilar, kuvvetler);

            return polinom;
        }
        public static bool DenklemHataliMi(string denklem)
        {
            

            if (string.IsNullOrEmpty(denklem))
            {
                return false;
            }
            else
            {
                denklem = denklem.ToLower();
                denklem = denklem.PadLeft(denklem.Length + 1);
                denklem = denklem.PadRight(denklem.Length + 1);

                char[] dizi = denklem.ToCharArray();
                int i = 0;

                while (i < dizi.Length)
                {
                    if (dizi[i].Equals('^'))
                    {
                        i++;
                        if (!char.IsDigit(dizi[i]))
                        {
                            return false;
                        }
                        i--;
                    }
                    else if (!char.IsDigit(dizi[i]) && !dizi[i].Equals(' ') && !dizi[i].Equals('+') && !dizi[i].Equals('-') && !dizi[i].Equals('x'))
                    {
                        return false;
                    }
                    i++;
                }
                return true;
            }


        }
        public static string PolinomBilgiYaz(Polinom polinom)
        {
            string bilgi = "";
            string katsayilar = "{ ";
            string kuvvetler = "{ ";
            string toplamTerim = polinom.toplam_terim_sayisi.ToString();

            for (int i = 0; i < polinom.kuvvetler.Length; i++)
            {
                if (polinom.katsayilar[i] != 0)
                {
                    katsayilar += polinom.katsayilar[i] + ",";
                    kuvvetler += polinom.kuvvetler[i] + ",";
                }
            }
            katsayilar = katsayilar.TrimEnd(',');
            kuvvetler = kuvvetler.TrimEnd(',');

            katsayilar += " }";
            kuvvetler += " }";

            bilgi += "Katsayilar: " + katsayilar + " Kuvvetler: " + kuvvetler + " Toplam Terim Sayisi: " + toplamTerim;

            return bilgi;

        }
        public static string PolinomYaz(Polinom polinom)
        {
            string denklem = " ";

            int[] kuvvetler = polinom.kuvvetler;
            int[] katsayilar = polinom.katsayilar;

            for (int i = 0; i < kuvvetler.Length; i++)
            {

                if (kuvvetler[i] == 0)
                {
                    if (katsayilar[i] != 0)
                    {
                        if (katsayilar[i] > 0)
                        {
                            denklem += "+" + katsayilar[i];
                        }
                        else
                        {
                            denklem += katsayilar[i];
                        }

                    }
                    else
                    {
                        denklem = denklem;
                    }


                }
                else if (kuvvetler[i] == 1)
                {
                    if (katsayilar[i] == 1)
                    {
                        denklem += "+x";
                    }
                    else if (katsayilar[i] == -1)
                    {
                        denklem += "-x";
                    }
                    else if (katsayilar[i] < -1)
                    {
                        denklem += katsayilar[i] + "x";
                    }
                    else if (katsayilar[i] != 0)
                    {
                        if (katsayilar[i] > 0)
                        {
                            denklem += "+" + katsayilar[i] + "x";
                        }
                        else
                        {
                            denklem += katsayilar[i] + "x";
                        }

                    }

                }
                else
                {
                    if (katsayilar[i] != 0 && katsayilar[i] != 1)
                    {
                        if (katsayilar[i] > 0)
                        {
                            denklem += "+" + katsayilar[i] + "x^" + kuvvetler[i];
                        }
                        else
                        {
                            denklem += katsayilar[i] + "x^" + kuvvetler[i];
                        }

                    }
                    else if (katsayilar[i] == 1)
                    {
                        denklem += "+x^" + kuvvetler[i];
                    }

                }


            }

            string gecici = "";
            for (int i = 0; i < denklem.Length; i++)
            {
                if (!denklem[i].Equals(' '))
                {
                    gecici += denklem[i];
                }
            }


            return denklem;
        }
        public static int TerimSayisi(string denklem)
        {
            denklem = denklem.ToLower();
            int adet = 0;
            denklem = denklem.PadLeft(denklem.Length + 1);
            denklem = denklem.PadRight(denklem.Length + 1);
            char[] terimler = denklem.ToCharArray();

            int i = 0;
            while(i < terimler.Length)
            {
                if (char.IsDigit(terimler[i]))
                {
                    if (!terimler[i].Equals('0'))
                    {
                        if (!terimler[i - 1].Equals('^'))
                        {
                            i++;

                            while (char.IsDigit(terimler[i]))
                            {
                                i++;
                            }
                            if (terimler[i].Equals('x') || terimler[i].Equals('+') || terimler[i].Equals('-') || terimler[i].Equals(' '))
                            {
                                adet++;
                            }
                            i--;
                        }
                    }  
                }
                               
                i++;
            }

            return adet;
        }

        public static int[] KatsayıListele(string denklem)
        {
            denklem = denklem.ToLower();
            denklem = denklem.PadLeft(denklem.Length + 1);
            denklem = denklem.PadRight(denklem.Length + 1);

            string gecici = "";

            char[] dizi = denklem.ToCharArray();


            int i = 0;
            while (i < dizi.Length)
            {
                if (dizi[i].Equals('^'))
                {
                    i++;
                    while (char.IsDigit(dizi[i]))
                    {
                        i++;
                    }
                    i--;
                }
                else if (char.IsDigit(dizi[i]))
                {
                    if (dizi[i - 1].Equals('-'))
                    {
                        gecici += "-" +dizi[i];
                    }
                    else
                    {
                        gecici += dizi[i];
                    }
                    
                    i++;
                    while (char.IsDigit(dizi[i]))
                    {
                        gecici += dizi[i];
                        i++;
                    }
                    gecici += ",";
                    i--;
 
                }
                else if (dizi[i].Equals('x'))
                {
                    if (dizi[i-1].Equals('-'))
                    {
                        gecici += "-1,";
                    }
                    else if (dizi[i - 1].Equals('+') || !char.IsDigit(dizi[i-1]))
                    {
                        gecici += "1,";
                    }
                }
                i++;

            }

            gecici = gecici.TrimEnd(',');

            string[] katsayilar = gecici.Split(',');

            int[] katsayi = new int[katsayilar.Length];

            for (int j = 0; j < katsayi.Length; j++)
            {
                katsayi[j] = Convert.ToInt32(katsayilar[j]);
            }

            return katsayi;

        }

        public static int[] KuvvetListele(string denklem)
        {
            
            string kuvvetler = " ";

            denklem = denklem.ToLower();
            denklem = denklem.PadLeft(denklem.Length + 1);
            denklem = denklem.PadRight(denklem.Length + 1);
            char[] dizi = denklem.ToCharArray();

            int i = 0;
            while (i < dizi.Length)
            {
                if (char.IsDigit(dizi[i]))
                {
                    i++;
                    while (char.IsDigit(dizi[i]))
                    {
                        i++;
                    }
                   
                    if (!dizi[i].Equals('x') && !dizi[i].Equals('^'))
                    {
                        kuvvetler += "0,";
                    }
                    i--;

                }
                else if (dizi[i].Equals('x'))
                {
                    i++;
                    if (!dizi[i].Equals('^'))
                    {
                        kuvvetler += "1,";
                    }
                    i--;
                    
                }
                else if (dizi[i].Equals('^'))
                {
                    i++;
                    if (!dizi[i].Equals('0'))
                    {
                        while (char.IsDigit(dizi[i]))
                        {
                            kuvvetler += dizi[i].ToString();
                            i++;
                        }
                        
                    }
                    else if (dizi[i].Equals('0'))
                    {
                        kuvvetler += "0";
                        
                    }
                    kuvvetler += ",";
                    
                }

                i++;
            }
            kuvvetler = kuvvetler.TrimEnd(',');


            string[] gecici = kuvvetler.Split(',');
            int[] kuvvet = new int[gecici.Length];

            for (int j = 0; j < gecici.Length; j++)
            {
                kuvvet[j] = Convert.ToInt32(gecici[j]);
            }

            return kuvvet;
        }

        public static bool SıfırMi(Polinom polinom)
            {

                for (int i = 0; i < polinom.kuvvetler.Length; i++)
                {
                    if (polinom.kuvvetler[i] == 0)
                    {
                        return false;
                    }

                }
                return true;

            }

        public static string PolinomArttir(Polinom polinom, int sayi)
        {
                for (int i = 0; i < polinom.katsayilar.Length; i++)
                {

                    polinom.katsayilar[i] += sayi;
                }
                string yeniDenklem = PolinomYaz(polinom);

                return yeniDenklem;
        }

        public static string PolinomAzalt(Polinom polinom, int sayi)
        {
                for (int i = 0; i < polinom.katsayilar.Length; i++)
                {
                    polinom.katsayilar[i] -= sayi;
                }
                string yeniDenklem = PolinomYaz(polinom);

                return yeniDenklem;
        }
        
        public static string SabitArttir(Polinom polinom, int sayi)
        {
                for (int i = 0; i < polinom.kuvvetler.Length; i++)
                {

                    if (polinom.kuvvetler[i] == 0)
                    {
                        polinom.katsayilar[i] += sayi;
                    }

                }
                string yeniDenklem = PolinomYaz(polinom);

                return yeniDenklem;

         }

        public static string SabitAzalt(Polinom polinom, int sayi)
        {
            for (int i = 0; i < polinom.kuvvetler.Length; i++)
            {

                if (polinom.kuvvetler[i] == 0)
                {
                    polinom.katsayilar[i] -= sayi;
                }

            }
            string yeniDenklem = PolinomYaz(polinom);

            return yeniDenklem;

        }

        public static bool EsitMi(Polinom polinom1,Polinom polinom2)
        {

            if((polinom1.katsayilar.Length == polinom2.katsayilar.Length) && (polinom1.kuvvetler.Length == polinom2.kuvvetler.Length))
            {
                for(int i = 0;i < polinom1.katsayilar.Length; i++)
                {
                    if (polinom1.katsayilar[i] == polinom2.katsayilar[i] && polinom1.kuvvetler[i] == polinom2.kuvvetler[i])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                        
                    }
                }
            }
            return false;
        }
    }
}

