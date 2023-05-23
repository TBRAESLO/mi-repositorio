using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConsola2
{
    public class Menu : IMenu
    {
        Almacen almacen = new Golosinas();

        public void golosinas()
        {
            var des = "";
            var valor = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Venta de Golosinas");
                if (almacen.getProducto().Count.Equals(0))
                {
                    Console.WriteLine("No hay golosinas.");
                    Console.WriteLine("Desea agregar golosinas? presione las teclas s/n: ");
                    des = Console.ReadLine();
                    if(des.Equals("s"))
                    {
                        Console.WriteLine("Cuantas golosinas va agregar?");
                        int cant = Convert.ToInt16(Console.ReadLine());

                        for (int i = 0; i < cant; i++)
                        {
                            Console.WriteLine("Nueva Golosina");
                            
                            Console.WriteLine("Ingrese la ID:");
                            var id = Console.ReadLine();
                            Console.WriteLine("Ingrese el nombre");
                            var nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese el precio");
                            var precio = Convert.ToDouble(Console.ReadLine());

                            almacen.addProducto(new Producto
                            {
                                ID = id,
                                Nombre = nombre,
                                Precio = precio
                            });
                        }

                        Console.WriteLine("Desea ir al inicio s/n");
                        des = Console.ReadLine();

                        if (des.Equals("s"))
                        {
                            valor = true;
                        }
                        else
                        {
                            valor = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Desea ir al inicio s/n");
                        des = Console.ReadLine();

                        if (des.Equals("s"))
                        {
                            Console.Clear();
                            Console.WriteLine("Venta de golosinas y frutas");
                        }
                        else
                        {
                            valor = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Lista de golosinas");
                    foreach (var item in almacen.getProducto(""))
                    {
                        Console.WriteLine($"Codigo {item.ID} Golosina {item.Nombre} Precio {item.Precio}");
                    }

                    Console.WriteLine("Desea realizar venta de golosinas? s/n");
                    des = Console.ReadLine();

                    if (des.Equals("s"))
                    {
                        ventas();
                    }
                    else
                    {
                        valor = false;
                    }
                }

            } while (valor);
        }

        public double solicitarPago()
        {
            bool pagoCorrecto = false;
            double res = 0;

            while (!pagoCorrecto)
            {
                Console.WriteLine("Como desea pagar con: 10, 5");
                res = double.Parse(Console.ReadLine());

                if (res != 5 && res != 10)
                {
                    Console.WriteLine("Pago no valido.");
                }
                else
                {
                    pagoCorrecto = true;
                }

            }

            return res;
        }

        public void ventas()
        {
            double total = 0;
            string des = "";

            do
            {
                Console.WriteLine("Ingrese el producto");
                string producto = Console.ReadLine();
                var productos = almacen.getProducto(producto);

                while (productos.Count.Equals(0))
                {
                    Console.WriteLine("Golosina no disponible, por favor seleccione otro.");
                    producto = Console.ReadLine();
                }

                Console.WriteLine($"Su monto a pagar es: {productos[0].Precio} $Dolar.");
                double pago = solicitarPago();


            } while (true);
        }
    }
}
