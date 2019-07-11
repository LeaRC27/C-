using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            Producto producto = new Producto(textBox1.Text, Int32.Parse(textBox2.Text), float.Parse(textBox3.Text));
            Console.WriteLine(producto.ToString());
            DBConnection.ExectNonQuery("INSERT INTO productos (nombre,cantidad,precio,subtotal) VALUES ('" + textBox1.Text + "','" + Int32.Parse(textBox2.Text) + "','"+ float.Parse(textBox3.Text) +"','" + Int32.Parse(textBox2.Text)*float.Parse(textBox3.Text) +"')");
            
            Form2 grid = new Form2();

            grid.Show();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 grid = new Form2();

            grid.Show();
        }
    }
}
