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

namespace Log_Analysis
{
    public partial class Form1 : Form
    {
        OpenFileDialog odf = new OpenFileDialog();
        String fileAdress;
        string line;
        public Form1()
        {
            InitializeComponent();
            odf.AddExtension = true;
            odf.CheckFileExists = true;
            odf.Filter = "csv檔|*.csv|純文字檔|*.txt|所有檔案|*.*";
            odf.FilterIndex = 0;
            odf.FileName = String.Empty;
            odf.InitialDirectory = @"C:\";
            odf.Multiselect = false;
            odf.RestoreDirectory = true;

            odf.ShowReadOnly = true;
            odf.Title = string.Empty;
            odf.FileOk += new CancelEventHandler(odf_FileOk);
        }

        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            //StreamReader log_file = new StreamReader("C:\\Users\\User\\Desktop\\v2k.txt");
            odf.ShowDialog();

        }

        private void odf_FileOk(object sender, CancelEventArgs e)
        {
            //MessageBox.Show(odf.FileName);
            txt_fileAdress.Text = odf.FileName;
            FileStream file = new FileStream(odf.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(file, System.Text.Encoding.GetEncoding("UTF-8"));
            line = sr.ReadLine();
            MessageBox.Show(line);

        }
    }
}
