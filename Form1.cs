using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\
// *                By PracticalManner                 * \\
// *  https://github.com/PracticalManner/ListBox-Loader * \\
//////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

namespace ListBox_Loader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Populate(string path)
        {
            listBox1.Items.Clear();

            DirectoryInfo dinfo = new DirectoryInfo(Application.StartupPath + path);
            FileInfo[] Files = dinfo.GetFiles("*.txt");
            FileInfo[] Files1 = dinfo.GetFiles("*.lua");
            foreach (FileInfo file in Files)
            {
                listBox1.Items.Add(file.Name);
            }

            foreach (FileInfo file in Files1)
            {
                listBox1.Items.Add(file.Name);
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!Directory.Exists("scripts"))
            {
                Directory.CreateDirectory("scripts");
            }

            object item = listBox1.SelectedItem;

            if (item != null)
            {
                string path = @"\scripts\";

                richTextBox1.Text = File.ReadAllText(Application.StartupPath + @"\scripts\" + item.ToString());

                Populate(path);
            }
        }
    }
}
