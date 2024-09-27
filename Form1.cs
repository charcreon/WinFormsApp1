using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("WinFormsApp1.Resources.Image.bin"))
            {
                if (stream != null)
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        byte[] data = reader.ReadBytes((int)stream.Length);

                        using (MemoryStream ms = new MemoryStream(data))
                        {
                            Image image = Image.FromStream(ms);
                            pictureBox1.Image = image;
                        }
                    }
                }
            }
        }
    }
}
