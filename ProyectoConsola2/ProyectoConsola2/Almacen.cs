using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConsola2
{
    public abstract class Almacen
    {
        public abstract List<Producto> getProducto(string producto);

        public abstract void addProducto(Producto producto);

    }
}
