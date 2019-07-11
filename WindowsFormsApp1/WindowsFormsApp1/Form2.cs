using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            load_dataGrid();
        }
        
        
        private void load_dataGrid() {
            try
            {
                MySqlConnection connection = DBConnection.Conn();
                MySqlCommand command = connection.CreateCommand();
                MySqlDataReader reader;
                command.CommandText = "SELECT id,nombre,cantidad,precio,subtotal FROM productos";

                connection.Open();
                reader = command.ExecuteReader();
                               
                while (reader.Read())
                {

                    this.dataGridView1.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3),reader.GetValue(4),new DataGridViewButtonCell().Value="Eliminar");
                   
                }

                connection.Close();
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
            {
                return;
            }else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Console.WriteLine(senderGrid.CurrentRow.Cells["Id"].Value);
                DialogResult res = MessageBox.Show("Desea eliminar la fila?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if ((res == DialogResult.OK) || (res == DialogResult.Yes))
                {
                    DBConnection.ExectNonQuery("DELETE FROM productos WHERE id='" + senderGrid.CurrentRow.Cells["Id"].Value + "';");
                    senderGrid.Rows.RemoveAt(e.RowIndex);
                   
                }


            }
            

        }
    }
}
