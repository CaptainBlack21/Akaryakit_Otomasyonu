using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Akaryakit_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //DEPODAKİ YAKIT
        double D_benzin95=0, D_benzin97=0, D_dizel=0, D_eurodizel=0, D_lpg=0;
        //EKLENEN YAKIT
        double E_benzin95 = 0, E_benzin97 = 0, E_dizel = 0, E_eurodizel = 0, E_lpg = 0;
        //FİYAT YAKIT
        double F_benzin95 = 0, F_benzin97 = 0, F_dizel = 0, F_eurodizel = 0, F_lpg = 0;
        //SATILAN YAKIT
        double S_benzin95 = 0, S_benzin97 = 0, S_dizel = 0, S_eurodizel = 0, S_lpg = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            label30.Text=DateTime.Now.ToLongDateString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            S_benzin95 = Convert.ToDouble(numericUpDown1.Value);
            S_benzin97 = Convert.ToDouble(numericUpDown2.Value);
            S_dizel = Convert.ToDouble(numericUpDown3.Value);
            S_eurodizel = Convert.ToDouble(numericUpDown4.Value);
            S_lpg = Convert.ToDouble(numericUpDown5.Value);

            if (numericUpDown1.Enabled == true)
                label29.Text = Convert.ToString(F_benzin95 * S_benzin95);
            if (numericUpDown2.Enabled == true)
                label29.Text = Convert.ToString(F_benzin97 * S_benzin97);
            if (numericUpDown3.Enabled == true)
                label29.Text = Convert.ToString(F_dizel * S_dizel);
            if (numericUpDown4.Enabled == true)
                label29.Text = Convert.ToString(F_eurodizel * S_eurodizel);
            if (numericUpDown5.Enabled == true)
                label29.Text = Convert.ToString(F_lpg * S_lpg);
        }

        string[] depo_bilgileri;
        string[] fiyat_bilgileri;
       

        

        private void button2_Click(object sender, EventArgs e)
        {
            S_benzin95=Convert.ToDouble(numericUpDown1.Value);
            S_benzin97=Convert.ToDouble(numericUpDown2.Value);
            S_dizel = Convert.ToDouble(numericUpDown3.Value);
            S_eurodizel = Convert.ToDouble(numericUpDown4.Value);
            S_lpg = Convert.ToDouble(numericUpDown5.Value);

            if (numericUpDown1.Enabled == true)
            {
                D_benzin95 = D_benzin95 - S_benzin95;
                label29.Text = Convert.ToString(S_benzin95 * F_benzin95);
            }
            if(numericUpDown2.Enabled == true)
            {
                D_benzin97 = D_benzin97 - S_benzin97;
                label29.Text = Convert.ToString(S_benzin97 * F_benzin97);
            }
            if (numericUpDown3.Enabled == true)
            {
                D_dizel = D_dizel - S_dizel;
                label29.Text = Convert.ToString(S_dizel * F_dizel);
            }
            if (numericUpDown4.Enabled == true)
            {
                D_eurodizel = D_eurodizel - S_eurodizel;
                label29.Text = Convert.ToString(S_eurodizel * F_eurodizel);
            }
            if (numericUpDown5.Enabled == true)
            {
                D_lpg = D_lpg - S_lpg;
                label29.Text = Convert.ToString(S_lpg * F_lpg);
            }
            label29.BackColor = Color.Green;
            depo_bilgileri[0]=D_benzin95.ToString();
            depo_bilgileri[1]=D_benzin97.ToString();
            depo_bilgileri[2] = D_dizel.ToString();
            depo_bilgileri[3] = D_eurodizel.ToString();
            depo_bilgileri[4] = D_lpg.ToString();

            System.IO.File.WriteAllLines(Application.StartupPath + "//depo.txt", depo_bilgileri);
            txt_depo_oku();
            txt_depo_yaz();
            progresbar_guncelle();
            numericupdown_value();

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                F_benzin95 = F_benzin95 + (F_benzin95 * Convert.ToDouble(textBox10.Text) / 100);
                fiyat_bilgileri[0] = Convert.ToString(F_benzin95);
            }
            catch (Exception)
            {

                textBox10.Text = "Hata!";
            }

            try
            {
                F_benzin97 = F_benzin97 + (F_benzin97 * Convert.ToDouble(textBox9.Text) / 100);
                fiyat_bilgileri[1] = Convert.ToString(F_benzin97);
            }
            catch (Exception)
            {

                textBox9.Text = "Hata!";
            }

            try
            {
                F_dizel = F_dizel + (F_dizel * Convert.ToDouble(textBox8.Text) / 100);
                fiyat_bilgileri[2] = Convert.ToString(F_dizel);
            }
            catch (Exception)
            {

                textBox8.Text = "Hata!";
            }

            try
            {
                F_eurodizel = F_eurodizel + (F_eurodizel * Convert.ToDouble(textBox7.Text) / 100);
                fiyat_bilgileri[3] = Convert.ToString(F_eurodizel);
            }
            catch (Exception)
            {

                textBox7.Text = "Hata!";
            }

            try
            {
                F_lpg = F_lpg + (F_lpg * Convert.ToDouble(textBox6.Text) / 100);
                fiyat_bilgileri[4] = Convert.ToString(F_lpg);
            }
            catch (Exception)
            {

                textBox6.Text = "Hata!";

            }
            System.IO.File.WriteAllLines(Application.StartupPath + "//fiyat.txt", fiyat_bilgileri);
            txt_fiyat_oku();
            txt_fiyat_yaz();

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            if (comboBox1.Text == "Benzin(95)")
                numericUpDown1.Enabled = true;
            if(comboBox1.Text == "Benzin(97)")
                numericUpDown2.Enabled = true;
            if(comboBox1.Text=="Dizel")
                numericUpDown3.Enabled = true;
            if(comboBox1.Text=="EuroDizel")
                numericUpDown4.Enabled = true;
            if(comboBox1.Text=="Lpg")
                numericUpDown5.Enabled = true;

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            label29.Text = "________";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                E_benzin95 = Convert.ToDouble(textBox1.Text);
                if (D_benzin95 + E_benzin95 > 1000 || E_benzin95 <= 0)
                    textBox1.Text = "Hata!";
                else
                    depo_bilgileri[0] = Convert.ToString(D_benzin95 + E_benzin95);
                
            }
            catch (Exception)
            {

                textBox1.Text = "HATA!";
            }

            try
            {
                E_benzin97 = Convert.ToDouble(textBox2.Text);
                if (D_benzin97 + E_benzin97 > 1000 || E_benzin97 <= 0)
                    textBox2.Text = "Hata!";
                else
                    depo_bilgileri[1] = Convert.ToString(D_benzin97 + E_benzin97);

            }
            catch (Exception)
            {

                textBox2.Text = "HATA!";
            }

            try
            {
                E_dizel = Convert.ToDouble(textBox3.Text);
                if (D_dizel + E_dizel > 1000 || E_dizel <= 0)
                    textBox3.Text = "Hata!";
                else
                    depo_bilgileri[2] = Convert.ToString(D_dizel + E_dizel);

            }
            catch (Exception)
            {

                textBox3.Text = "HATA!";
            }

            try
            {
                E_eurodizel = Convert.ToDouble(textBox4.Text);
                if (D_eurodizel + E_eurodizel > 1000 || E_eurodizel <= 0)
                    textBox4.Text = "Hata!";
                else
                    depo_bilgileri[3] = Convert.ToString(D_eurodizel + E_eurodizel);

            }
            catch (Exception)
            {

                textBox4.Text = "HATA!";
            }

            try
            {
                E_lpg = Convert.ToDouble(textBox5.Text);
                if (D_lpg + E_lpg > 1000 || E_lpg <= 0)
                    textBox5.Text = "Hata!";
                else
                    depo_bilgileri[4] =Convert.ToString(D_lpg + E_lpg);

            }
            catch (Exception)
            {

                textBox5.Text = "HATA!";
            }

            System.IO.File.WriteAllLines(Application.StartupPath+ "//depo.txt", depo_bilgileri);
            txt_depo_oku();
            txt_depo_yaz();
            progresbar_guncelle();
            numericupdown_value();
        }
       
        //depo bilgilerini günceller
        private void txt_depo_oku()
        {
            depo_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "//depo.txt");
            D_benzin95 = Convert.ToDouble(depo_bilgileri[0]);
            D_benzin97 = Convert.ToDouble(depo_bilgileri[1]);
            D_dizel = Convert.ToDouble(depo_bilgileri[2]);
            D_eurodizel = Convert.ToDouble(depo_bilgileri[3]);
            D_lpg = Convert.ToDouble(depo_bilgileri[4]);
        }
        private void txt_depo_yaz()
        {
            label6.Text = D_benzin95.ToString("N");
            label7.Text = D_benzin97.ToString("N");
            label8.Text = D_dizel.ToString("N");
            label9.Text = D_eurodizel.ToString("N");
            label10.Text = D_lpg.ToString("N"); 
        }
        private void txt_fiyat_oku()
        {
            fiyat_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "//fiyat.txt");
            F_benzin95=Convert.ToDouble(fiyat_bilgileri[0]);
            F_benzin97 = Convert.ToDouble(fiyat_bilgileri[1]);
            F_dizel=Convert.ToDouble(fiyat_bilgileri[2]);
            F_eurodizel = Convert.ToDouble(fiyat_bilgileri[3]);
            F_lpg=Convert.ToDouble(fiyat_bilgileri[4]);
        }
        private void txt_fiyat_yaz()
        {
            label12.Text=F_benzin95.ToString("N");
            label13.Text=F_benzin97.ToString("N"); 
            label14.Text=F_dizel.ToString("N");
            label15.Text=F_eurodizel.ToString("N");
            label16.Text = F_lpg.ToString("N");
        }
        private void progresbar_guncelle()
        {
            progressBar1.Value = Convert.ToInt16(D_benzin95);
            progressBar2.Value = Convert.ToInt16(D_benzin97);
            progressBar3.Value = Convert.ToInt16(D_dizel);
            progressBar4.Value = Convert.ToInt16(D_eurodizel);
            progressBar5.Value = Convert.ToInt16(D_lpg);
        }
        private void numericupdown_value()
        {
            numericUpDown1.Maximum = decimal.Parse(D_benzin95.ToString());
            numericUpDown2.Maximum = decimal.Parse(D_benzin97.ToString());
            numericUpDown3.Maximum = decimal.Parse(D_dizel.ToString());
            numericUpDown4.Maximum = decimal.Parse(D_eurodizel.ToString());
            numericUpDown5.Maximum = decimal.Parse(D_lpg.ToString());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_depo_oku();
            txt_depo_yaz();
            txt_fiyat_oku();
            txt_fiyat_yaz();
            progresbar_guncelle();
            numericupdown_value();

            String[] yakıt_turleri = {"Benzin(95)","Benzin(97)","Dizel","EuroDizel","Lpg"};
            comboBox1.Items.AddRange(yakıt_turleri);

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            numericUpDown1.DecimalPlaces = 2;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;

            numericUpDown1.Increment = 0.1m;
            numericUpDown2.Increment = 0.1m;
            numericUpDown3.Increment = 0.1m;
            numericUpDown4.Increment = 0.1m;
            numericUpDown5.Increment = 0.1m;

            numericUpDown1.ReadOnly=true;
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;
            numericUpDown4.ReadOnly = true;
            numericUpDown5.ReadOnly = true;
           
        }
    }
}
