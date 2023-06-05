using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConsola2
{
    public class Frutas : Almacen
    {
        private List<Producto> _Frutas;

        public Frutas()
        {
            _Frutas = new List<Producto>();
        }

        public override void addProducto(Producto producto)
        {
            _Frutas.Add(producto);
        }

        public override List<Producto> getProducto(string producto)
        {
            List<Producto> frutas = new List<Producto>();

            if (producto.Equals(""))
            {
                frutas = _Frutas;
            }
            else
            {
                frutas = _Frutas.Where(g => g.Nombre.Equals(producto)).ToList();
            }

            return frutas;
        }
    }
}