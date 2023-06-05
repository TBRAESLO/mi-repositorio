using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConsola2
{
    public class Menu : IMenu
    {
        string tipoProducto;
        Golosinas pGolosinas = new Golosinas();
        Frutas pFrutas = new Frutas();

        public void frutas()
        {
            tipoProducto = "frutas";
            var des = "";
            var valor = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Venta de Frutas");
                if (pFrutas.getProducto("").Count.Equals(0))
                {
                    Console.WriteLine("No hay golosinas");
                    Console.WriteLine("Desea agregar frutas? presiones las teclas s/n");
                    des = Console.ReadLine();
                    if (des.Equals("s"))
                    {
                        Console.WriteLine("Cuantas frutas va a agregar?");
                        int cant = Convert.ToInt16(Console.ReadLine());

                        for(int i = 0; i < cant; i++)
                        {
                            Console.WriteLine("Nueva Fruta");
                            Console.WriteLine("Ingrese ID: ");
                            var id = Console.ReadLine();
                            Console.WriteLine("Ingrese NOmbre: "); 
                            var nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese Precio: "); 
                            var precio = Convert.ToDouble(Console.ReadLine());

                            pFrutas.addProducto(new Producto { 
                            ID = id,
                            Nombre = nombre,
                            Precio = precio
                            });
                        }

                        Console.WriteLine("Desea ir al inicio? presione s/n");
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
                        Console.WriteLine("Desea ir al inicio? presione s/n");
                        des = Console.ReadLine();
                        if (des.Equals(""))
                        {
                            Console.Clear();
                            Console.WriteLine("Venta de Frutas");
                        }
                        else
                        {
                            valor = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Lista de Frutas");
                    foreach(var item in pFrutas.getProducto(""))
                    {
                        Console.WriteLine($"Codigo: {item.ID}  Nombre: {item.Nombre}  Precio: {item.Precio.ToString()}");
                    }

                    Console.WriteLine("Desea realizar venta de frutas? Presione s/n");
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

        public void golosinas()
        {
            tipoProducto = "golosinas";
            var des = "";
            var valor = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Venta de Golosinas");
                if (pGolosinas.getProducto("").Count.Equals(0))
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

                            pGolosinas.addProducto(new Producto
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
                    foreach (var item in pGolosinas.getProducto(""))
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
            string producto = "";

            if (tipoProducto.Equals("golosinas"))
            {
                
                do
                {
                    Console.WriteLine("Ingrese el producto");
                    producto = Console.ReadLine();
                    var productos = pGolosinas.getProducto(producto);

                    while (productos.Count.Equals(0))
                    {
                        Console.WriteLine("Golosina no disponible, por favor seleccione otro.");
                        producto = Console.ReadLine();
                        productos = pGolosinas.getProducto(producto);
                    }

                    Console.WriteLine($"Su monto a pagar es: {productos[0].Precio} $Dolar.");
                    double pago = solicitarPago();
                    while (pago < productos[0].Precio)
                    {
                        Console.WriteLine("Faltan " + (productos[0].Precio - pago).ToString() + " $ Dolar");
                        pago = solicitarPago();
                    }

                    Console.WriteLine("Su cambio: " + (pago - productos[0].Precio).ToString());
                    total += productos[0].Precio;
                    Console.WriteLine("Su pago fue de: " + total.ToString() + " $ Dolar.");
                    Console.WriteLine("¿ Desea realizar otra compra? s/n");
                    des = Console.ReadLine();

                } while (des.Equals("s")) ;
            }
            else if(tipoProducto.Equals("frutas")){
                do
                {
                    Console.WriteLine("Ingrese el producto");
                    producto = Console.ReadLine();
                    var productos = pFrutas.getProducto(producto);

                    while (productos.Count.Equals(0))
                    {
                        Console.WriteLine("Fruta no disponible, por favor seleccione otro. ");
                        producto = Console.ReadLine();
                        productos = pFrutas.getProducto("");
                    }

                    Console.WriteLine($"Su monto a pagar es: {productos[0].Precio} $Dolar.");
                    double pago = solicitarPago();
                    while (pago < productos[0].Precio)
                    {
                        Console.WriteLine("Faltan " + (productos[0].Precio - pago).ToString() + " $Dolar");
                        pago = solicitarPago();
                    }

                    Console.WriteLine("Su cambio: " + (pago - productos[0].Precio).ToString());
                    total += productos[0].Precio;
                    Console.WriteLine("Su pago fue de: " + total.ToString() + " $Dolar.");
                    Console.WriteLine("¿ Desea realizar otra venta ? s/n");
                    des = Console.ReadLine();

                } while (des.Equals("s"));
            }


        }
    }
}
