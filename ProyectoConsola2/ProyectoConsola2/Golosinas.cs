using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConsola2
{
    public class Golosinas : Almacen
    {
        private List<Producto> _Golosinas;

        public Golosinas() 
        {
            _Golosinas = new List<Producto>();
        }

        public override void addProducto(Producto producto)
        {
            _Golosinas.Add(producto);
        }

        public override List<Producto> getProducto(string producto)
        {
            var golosinas = new List<Producto>();

            if (producto.Equals(""))
            {
                golosinas = _Golosinas;
            }
            else
            {
                golosinas = _Golosinas.Where(g => g.Nombre.Equals(producto)).ToList();

            }

            return golosinas;
        }
    }
}
