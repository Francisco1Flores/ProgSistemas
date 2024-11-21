using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgSistemas.BA
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string UnidadMedida { get; set; }
        public int Cantidad { get; set; }

        public Producto() { }
        public Producto(string codigo,
                        string nombre,
                        decimal precio,
                        string unidadMedida,
                        int cantidad)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            UnidadMedida = unidadMedida;
            Cantidad = cantidad;
        }

    }
}
