using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CT_NGHE_NHAC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog openFileDialog;
        string[] filePaths;
        string[] fileNames;
        private void bt_open_click_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Mp3 files mp4 files(*.mp3 , *.mp4)|*.mp*";
            openFileDialog.Title = "open";
            openFileDialog.Multiselect = true;
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePaths = openFileDialog.FileNames;
                fileNames = openFileDialog.SafeFileNames;
            }
            foreach(var item in fileNames)
            {
                this.listBox1.Items.Add(item);
            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                int choose = listBox1.SelectedIndex;
                axWindowsMediaPlayer1.URL = filePaths[choose];
                this.textBox1.Text = fileNames[choose];
            }
        }
        private void bt_thoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không ?" , "Thông báo" , MessageBoxButtons.YesNo , MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            this.Close();
        }
    }
}
