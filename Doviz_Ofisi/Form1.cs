using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace Doviz_Ofisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);

            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            LblDolaralıs.Text = dolaralis;

            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            LblDolarsatis.Text = dolarsatis;

            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            LblEuroalis.Text =euroalis;

            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            LblEurosatis.Text = eurosatis;



        }

        private void BtnDolarAl_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblDolaralıs.Text;
        }

        private void BtnDolarSat_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblDolarsatis.Text;
        }

        private void BtnEuroAl_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblEuroalis.Text;
        }

        private void BtnEuroSat_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblEurosatis.Text;
        }

        private void BtnSatisYap_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(TxtKur.Text);
            miktar = Convert.ToDouble(TxtMiktar.Text);
            tutar = miktar * kur;
            TxtTutar.Text = tutar.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(TxtKur.Text);
            int miktar = Convert.ToInt32(TxtMiktar.Text);
            int tutar =Convert.ToInt32(miktar/kur);
            TxtTutar.Text = tutar.ToString();
            double  kalan = miktar % tutar;
            TxtKalan.Text = kalan.ToString();

            // To Do:SQL de bir tabloya geçirilecek. SQL tablosunda TL,,EUR ve USD olarak. Bunlar kasadaki miktarımız olacak. Bir işlem yapıldığında tl eur ve usd miktarı değişecek. Ortalama 20 satır
        }
    }
}
