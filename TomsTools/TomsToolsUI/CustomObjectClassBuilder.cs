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
    public partial class CustomObjectClassBuilder : Form
    {
        DataTools dataTools = new DataTools();
        public CustomObjectClassBuilder()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           if(dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowIndex);

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            DataTable dt = DataTools.GridViewToDataTable(dataGridView1);


            if (checkBox1.CheckState == CheckState.Unchecked)
            {
                richTextBox1.Text += $"Public Class {textBox1.Text}";
                richTextBox1.Text += "\n{";
            }
            else
            {
                richTextBox1.Text += $"Public Class {textBox1.Text} : {textBox2.Text}";
                richTextBox1.Text += "\n{";
            }
            foreach (DataRow row in dt.Rows)
            {
                string access = "";
                string type = "";
                string name = "";
                string mode = "";
                string fulloutput;
                foreach (DataColumn column in dt.Columns)
                {
                    if (column.ColumnName =="Remove Row")
                    {

                    }
                    else
                    {                    
                        (bool isValid, string msg) = DataTools.GetValuesFromRow(row, column.ColumnName);
                        if (isValid == true)
                        {
                            if (column.ColumnName == "Property Access")
                            {
                                access = msg;
                            }
                            else if (column.ColumnName == "Var Type")
                            {
                                type = msg;
                            }
                            else if (column.ColumnName == "Var Name")
                            {
                                name = msg;
                            }
                            else if (column.ColumnName == "Access Mode")
                            {
                                if (msg.Contains("get") && msg.Contains("set"))
                                {
                                    mode = "{ get; set; }";
                                }
                                else if (msg.Contains("get") && !msg.Contains("set"))
                                {
                                    mode = "{ get; }";
                                }
                                else if (msg.Contains("set") && !msg.Contains("get"))
                                {
                                    mode = "{ set; }";
                                }
                            }
                        }

                    }
                }

                richTextBox1.Text += ($"\n{access} {type} {name} {mode}");

            }

            richTextBox1.Text += ("\n }");



        }

    }
}
