using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class Program {
        static void Main(string[] args)
        {
            static List<Producto> productos = new List<Producto>();

        

        int opcion = 0;
            do
            {
                Console.WriteLine("--- MÁQUINA DE VENDING ---");
                Console.WriteLine("1. Comprar Productos");
                Console.WriteLine("2. Solictitar detalles del producto");
                Console.WriteLine("3. Carga individual de producto");
                Console.WriteLine("4.Carga Completa de los productos");
                Console.WriteLine("5.Salir");
                Console.Write("Seleccione una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        RealizarCompra();
                       
                        break;
                    case 2:
                        SolicitarDetallesProducto();

                        break;
                    case 3:
                        Admin.CargaIndividual();
                        break;
                    case 4:
                        Admin.CargaCompleta();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo");
                        break;

              }
                Console.WriteLine("Presiona una tecla para continuar");
                Console.ReadKey();
            } while (opcion != 5);
        }

        static void RealizarCompra(List<Producto> productos)
        {

            Console.WriteLine("Compra de Producto:");

            Console.WriteLine("Productos disponibles:");
            foreach (var producto in productos)
            {
            Console.WriteLine($"ID: {producto.Id} - {producto.Nombre} - Precio: {producto.PrecioUnitario} - Unidades disponibles: {producto.Unidades}");
            }
            
            Producto productoComprado = BuscarProducto();
            if (producto != null)
            {

                Console.WriteLine("Producto Añadido a la Cesta");
                Producto producto = new Producto();
                int PrecioTotal = Producto.PrecioUnitario();

            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }






        }


        static void SolicitarDetallesProducto()
        {
            Console.WriteLine("Detalles del Producto:");
            Console.WriteLine("Productos Disponibles");
            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.Id} - {producto.Nombre} - Precio: {producto.PrecioUnitario} - Unidades disponibles: {producto.Unidades}");
            }


            Producto productoBuscado = BuscarProducto();
           
             
            if (producto != null)
            {
                Producto producto = new Producto();
                Producto.MostarDetalles();
                
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }


        public Producto BuscarProducto()
        {
            Console.Write("Id del producto: ");
            string IdBuscar = Console.ReadLine();


            Producto ProductoBuscar = null;
            foreach (Prodcuto c in prodcutos)
            {
                if (c.Id == Id)
                {
                    ProductoBuscar = c;
                }
            }

            if (ProductoBuscar != null)
            {
                Console.WriteLine("Contenido encontrado:");
                Console.WriteLine(ProductoBuscar);
            }
            else
            {
                Console.WriteLine("No se encontró el producto.");
            }
            return ProductoBuscar;
        }




    }
}
