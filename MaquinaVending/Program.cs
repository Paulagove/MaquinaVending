using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class Program {
      
        static void Main(string[] args) {
            List<Producto> productos = new List<Producto>(12);


            List<Producto> listaDeLaCompra = new List<Producto>();


            int opcion = 0;
            do {
                Console.WriteLine("--- MÁQUINA DE VENDING ---");
                Console.WriteLine("1. Comprar Productos");
                Console.WriteLine("2. Solictitar detalles del producto");
                Console.WriteLine("3. Carga individual de producto");
                Console.WriteLine("4.Carga Completa de los productos");
                Console.WriteLine("5.Salir");
                Console.Write("Seleccione una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcion) {
                    case 1:
                        RealizarCompra();
                        break;
                    case 2:
                        //SolicitarDetallesProducto();
                        break;
                    case 3:
                        Admin admin = new Admin(productos);
                        admin.CargaIndividual();
                        break;
                    case 4:
                        Admin admin2 = new Admin(productos);
                        admin2.CargaCompleta();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo...");
                        break;

                }
            } while (opcion != 5);


        }
        static void RealizarCompra() {

            bool continuidadCompra = 0;
            do {
                Console.WriteLine("Compra de Producto:");
                foreach (var producto in productos) {
                    Console.WriteLine($"ID: {producto.Id} - {producto.Nombre} - Precio: {producto.PrecioUnitario} - Unidades disponibles: {producto.Unidades}");
                }
                Console.Write("Ingrese el ID del producto que desea comprar: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Ingrese la cantidad que desea comprar: ");
                int unidades = int.Parse(Console.ReadLine());
                Console.WriteLine("Quiere Añadir mas productos a la cesta? (true/false)");

                Producto productoElegido = new Producto(id, unidades);

            } while (continuidadCompra = true);


            int opcionPago = 0;
            do {
                Console.WriteLine("Seleccione el método de pago: ");
                Console.WriteLine("1. Pago en efectivo");
                Console.WriteLine("2. Pago con tarjeta");
                opcionPago = int.Parse(Console.ReadLine());

                switch (opcionPago) {
                    case 1:
                        Pago pagoEf = new Pago();
                        pagoEf.PagoEfectivo();
                        break;
                    case 2:
                        Pago pagoTar = new Pago();
                        pagoTar.PagoTarjeta();
                        break;
                }
            } while (opcionPago != 2);


            Producto productoComprado = BuscarProducto();
            if (producto != null) {
                //
                Console.WriteLine("Producto Añadido a la Cesta");
                Producto producto = new Producto();
                int PrecioTotal = Producto.PrecioUnitario();

            }
            else {
                Console.WriteLine("Producto no encontrado.");
            }
            Console.Write("Ingrese el dinero: ");
            //



            Console.WriteLine("Productos Disponibles");
            foreach (var producto in productos) {
                Console.WriteLine($"ID: {producto.Id} - {producto.Nombre} - Precio: {producto.PrecioUnitario} - Unidades disponibles: {producto.Unidades}");
            }


            Producto productoBuscado = BuscarProducto();


            if (producto != null) {
                Producto producto = new Producto();
                Producto.MostarDetalles();

                var producto = // metodo que sea buscar producto por id;
            if (producto != null) {
                    Console.WriteLine();
                    producto.MostrarDetalless();
                }
                else {
                    Console.WriteLine("Producto no encontrado.");
                }
            }


            public Producto BuscarProducto() {
                Console.Write("Id del producto: ");
                string IdBuscar = Console.ReadLine();


                Producto ProductoBuscar = null;
                foreach (Prodcuto c in prodcutos) {
                    if (c.Id == Id) {
                        ProductoBuscar = c;
                    }
                }

                if (ProductoBuscar != null) {
                    Console.WriteLine("Contenido encontrado:");
                    Console.WriteLine(ProductoBuscar);
                }
                else {
                    Console.WriteLine("No se encontró el producto.");
                }
                return ProductoBuscar;
            }




        }
    }
}
