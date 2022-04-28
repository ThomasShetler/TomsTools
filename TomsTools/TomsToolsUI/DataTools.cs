using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TomsToolsUI
{
    class DataTools
    {
        public static DataTable GridViewToDataTable(DataGridView dataGrid)
        {
            DataTable dt = new DataTable();

            //Adding the Columns.
            foreach (DataGridViewColumn column in dataGrid.Columns)
            {
                if (column.ValueType == null)
                {
                    column.ValueType = typeof(string);

                }              
                dt.Columns.Add(column.HeaderText, column.ValueType);                               
            }

            //Adding the Rows.
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null) {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }

                   
                }
            }
            return dt;
        }
        public static DataTable ConvertCSVToDataTable(string fileName, char[] splitChars)
        {
            var table = new DataTable();
            try
            {

                using (StreamReader reader = new StreamReader(fileName))
                {
                    // get the first row of csv
                    string header = reader.ReadLine();
                    var fields = header.Split(splitChars);

                    foreach (string column in fields)
                    {
                        // add columns to new datatable based on first row of csv
                        table.Columns.Add(column);
                    }

                    string row = reader.ReadLine();
                    // read to end
                    while (row != null)
                    {
                        // add each row to datatable 
                        var rowDatas = row.Split(splitChars);
                        table.Rows.Add(rowDatas);
                        row = reader.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {            
                MessageBox.Show("Something went wrong try again. Execption: " + e);
                
                
            }

            return table;
        }
        public static (bool isValid, string msg) GetValuesFromRow(DataRow row, string colName)
        {
            string cellVal = "";
            bool foundCol = false;
            int col = 0;
            foreach (var item in row.ItemArray)
            {
                if (row.Table.Columns[col].ColumnName == colName)
                {
                    foundCol = true;
                    cellVal = item.ToString();
                }
                col++;
            }
            if (foundCol == true)
            {
                return (true, cellVal);
            }
            else
            {
                return (false ,"not_found");
            }


        }
    }
}
