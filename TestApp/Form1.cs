using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSShellExtThumbnailHandler;
using System.IO;
using CSharpTricks.Photoshop;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OzzPdfThumbnailProvider tmp = new OzzPdfThumbnailProvider();
            FileStream strm = new FileStream(@"C:\Users\okulahci\Desktop\Resim\EzgiFeritCep\CepAlbumSablonu2.psd", FileMode.Open);
            pictureBox1.Image = tmp.ConstructBitmap(strm, 96);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CPSD psd = new CPSD();
            psd.Load(@"C:\Users\okulahci\Desktop\Resim\05.psd");
            //MessageBox.Show(psd.IsThumbnailIncluded().ToString());
            pictureBox1.Image = Bitmap.FromStream(new MemoryStream(psd.m_ThumbNail.Data));

        }
    }
}
