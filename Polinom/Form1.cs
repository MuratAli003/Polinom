using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polinom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        Polinom polinom;
        
        private void button7_Click(object sender, EventArgs e)
        {

            if (PolinomIslem.DenklemHataliMi(tbxPolinom.Text))
            {
                polinom = PolinomIslem.PolinomOlustur(tbxPolinom.Text);
                
                tbxBilgi.Text = "P(x) = {" + PolinomIslem.PolinomYaz(polinom) + " }";

            }
            else
            {
                tbxBilgi.Text = "Polinom Hatalı Veya Eksik";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (PolinomIslem.DenklemHataliMi(tbxPolinom.Text))
            {
                polinom = PolinomIslem.PolinomOlustur(tbxPolinom.Text);

                if (PolinomIslem.SıfırMi(polinom))
                {
                    tbxBilgi.Text = "Bu Bir Sıfır Polinomdur";
                }
                else
                {
                    tbxBilgi.Text = "Sıfır Polinom Değildir";
                }


            }
            else
            {
                tbxBilgi.Text = "Polinom Hatalı Veya Eksik";

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (PolinomIslem.DenklemHataliMi(tbxPolinom.Text))
            {
                polinom = PolinomIslem.PolinomOlustur(tbxPolinom.Text);
                tbxBilgi.Text = PolinomIslem.PolinomBilgiYaz(polinom);

                
            }
            else
            {
                tbxBilgi.Text = "Polinom Hatalı Veya Eksik";
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int[] dizi= PolinomIslem.KuvvetListele(tbxBilgi.Text);
            string text = "";
            for (int i = 0; i < dizi.Length; i++)
            {
                text += dizi[i].ToString();
            }
            tbxBilgi.Text = text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (PolinomIslem.DenklemHataliMi(tbxkarsilastir1.Text) && PolinomIslem.DenklemHataliMi(tbxKarsilastir2.Text))
            {

                Polinom polinom1 = PolinomIslem.PolinomOlustur(tbxkarsilastir1.Text);
                Polinom polinom2 = PolinomIslem.PolinomOlustur(tbxKarsilastir2.Text);

                if (PolinomIslem.EsitMi(polinom1, polinom2))
                {
                    tbxBilgi.Text = "Polinomlar Esit";
                }
                else
                {
                    tbxBilgi.Text = "Polinomlar Esit Degil";
                }
            }
            else
            {
                tbxBilgi.Text = "Polinom Bilgileri Eksik Veya Yanlış";
            }
        }

        private void btnPolinomArttir_Click(object sender, EventArgs e)
        {
            if (PolinomIslem.DenklemHataliMi(tbxPolinom.Text))
            {
                if (!string.IsNullOrEmpty(tbxArttır.Text))
                {
                    if (!tbxBilgi.Text.Equals("P(x) = {  }"))
                    {
                        polinom = PolinomIslem.PolinomOlustur(tbxPolinom.Text);
                        int sayi = Convert.ToInt32(tbxArttır.Text);

                        tbxPolinom.Text = PolinomIslem.PolinomArttir(polinom, sayi);
                        tbxBilgi.Text = "P(x) = {" + tbxPolinom.Text + " }";
                    }
                    else
                    {
                        tbxPolinom.Text = "0";
                    }


                }
                else
                {
                    tbxBilgi.Text = "Arttırılacak Değeri Girin";
                }

            }
            else
            {
                tbxBilgi.Text = "Polinom Hatalı Veya Eksik";
            }
        }

        private void btnPolinomAzalt_Click(object sender, EventArgs e)
        {
            if (PolinomIslem.DenklemHataliMi(tbxPolinom.Text))
            {
                if (!string.IsNullOrEmpty(tbxArttır.Text))
                {
                    if (!tbxBilgi.Text.Equals("P(x) = {  }"))
                    {
                        polinom = PolinomIslem.PolinomOlustur(tbxPolinom.Text);
                        int sayi = Convert.ToInt32(tbxArttır.Text);

                        tbxPolinom.Text = PolinomIslem.PolinomAzalt(polinom, sayi);
                        tbxBilgi.Text = "P(x) = {" + tbxPolinom.Text + " }";
                    }
                    else
                    {
                        tbxPolinom.Text = "0";
                        tbxBilgi.Text = "P(x) = {" + tbxPolinom.Text + " }";
                    }
                }
                else
                {
                    tbxBilgi.Text = "Aazaltılacak Değeri Girin";
                }

            }
            else
            {
                tbxBilgi.Text = "Polinom Hatalı Veya Eksik";
            }
        }

        private void btnSabitArttir_Click(object sender, EventArgs e)
        {
            if (PolinomIslem.DenklemHataliMi(tbxPolinom.Text))
            {
                if (!string.IsNullOrEmpty(tbxSabitArttır.Text))
                {
                    
                    if (!tbxBilgi.Text.Equals("P(x) = {  }"))
                    {
                        polinom = PolinomIslem.PolinomOlustur(tbxPolinom.Text);
                        int sayi = Convert.ToInt32(tbxSabitArttır.Text);


                        tbxPolinom.Text = PolinomIslem.SabitArttir(polinom, sayi);
                        tbxBilgi.Text = "P(x) = { " + tbxPolinom.Text + " }";
                    }
                    else
                    {
                        tbxPolinom.Text = "0";
                    }
                }
                else
                {
                    tbxBilgi.Text = "Arttırılacak Değeri Girin";
                }

            }
            else
            {
                tbxBilgi.Text = "Polinom Hatalı Veya Eksik";
            }
        }

        private void btnSabitAzalt_Click(object sender, EventArgs e)
        {
            if (PolinomIslem.DenklemHataliMi(tbxPolinom.Text))
            {
                if (!string.IsNullOrEmpty(tbxSabitArttır.Text))
                {
                    if (!tbxBilgi.Text.Equals("P(x) = {  }"))
                    {
                        polinom = PolinomIslem.PolinomOlustur(tbxPolinom.Text);
                        int sayi = Convert.ToInt32(tbxSabitArttır.Text);

                        tbxPolinom.Text = PolinomIslem.SabitAzalt(polinom, sayi);
                        tbxBilgi.Text = "P(x) = {" + tbxPolinom.Text + " }";
                    }
                    else
                    {
                         
                        tbxPolinom.Text = "0";
                        tbxBilgi.Text = "P(x) = {" + tbxPolinom.Text + " }";
                    }
                }
                else
                {
                    tbxBilgi.Text = "Azaltılacak Değeri Girin";
                }

            }
            else
            {
                tbxBilgi.Text = "Polinom Hatalı Veya Eksik";
            }
        }
    }
}
