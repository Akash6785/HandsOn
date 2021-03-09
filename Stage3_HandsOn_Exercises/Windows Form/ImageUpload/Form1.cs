using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ImageUpload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog upload = new OpenFileDialog();
            upload.Filter = "Image Files(*.jpg; *.jpeg; *.Jfif; *.png)|*.jpg; *.jpeg; *.png;*.Jfif;";
            if(upload.ShowDialog()==DialogResult.OK)
            {
                PicBox.Image = new Bitmap(upload.FileName);
            }
        }
    }
}
