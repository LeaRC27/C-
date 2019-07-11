using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class Producto
        {


        private int id;
        private String nombre;
        private int cantidad;
        private float precio;
        private float subtotal;

        public Producto(string nombre, int cantidad, float precio)
        {
            this.Nombre = nombre;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.subtotal = precio * cantidad;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public float Precio { get => precio; set => precio = value; }
        public float Subtotal { get => subtotal; set => subtotal = value; }

        public override string ToString()
        {
            return this.Nombre + " , " + this.Precio + " , " + this.Cantidad + " , " + this.Subtotal;
        }
    }
}
