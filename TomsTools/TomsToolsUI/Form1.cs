using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TomsToolsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomObjectClassBuilder classBuilder = new CustomObjectClassBuilder();
            classBuilder.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CSVtoDataTable csv = new CSVtoDataTable();
            csv.Show();
        }
 
        
    }
}
