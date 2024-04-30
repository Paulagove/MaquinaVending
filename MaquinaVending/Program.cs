using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class Program {

        //se crea una lista de productos que tenga un tamaño de 12 objetos
        static List<Producto> Productos = new List<Producto>(12);

        static void Main(string[] args) {
            //Se crea la clase admin para acceder a los apartados 3 y 4 del switch-case y se le envía la lista de Productos

            Admin admin = new Admin(Productos);



            string password;
            int opcion = 0;
            do {
                try {
                    Console.WriteLine("---- MÁQUINA DE VENDING ----");
                    Console.WriteLine("1. Comprar Productos");
                    Console.WriteLine("2. Mostrar detalles del producto");
                    Console.WriteLine("3. Carga individual de producto");
                    Console.WriteLine("4. Carga Completa de los productos");
                    Console.WriteLine("5. Salir");
                    Console.Write("Seleccione una opcion: ");
                    opcion = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (opcion) {
                        case 1:
                            RealizarCompra();
                            Console.Clear();
                            break;
                        case 2:
                            //primero se muestran todos y luego se especifican
                            MostrarDetallesDeProducto();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Write("Introduzca la contraseña: ");
                            password = Console.ReadLine();
                            //si la contraseña es correcta, se accede al método CargaIndividual
                            if (admin.LoginAdmin(password) == true) {
                                admin.CargaIndividual();
                            }
                            else {
                                Console.WriteLine("Contraseña incorrecta");
                            }
                            Console.Clear();
                            break;
                        case 4:
                            Console.Write("Introduzca la contraseña: ");
                            password = Console.ReadLine();
                            if (admin.LoginAdmin(password) == true) {
                                admin.CargaCompleta();
                            }
                            else {
                                Console.WriteLine("Contraseña incorrecta");
                            }
                            Console.Clear();
                            break;
                        case 5:
                            Console.WriteLine("Saliendo...");
                            break;

                    }
                }
                catch (FormatException) {
                    Console.WriteLine("Error: Opción inválida. Por favor, ingrese un número válido");
                }
                catch (Exception ex) {
                    Console.WriteLine("Error: " + ex.Message);
                }
            } while (opcion != 5);
            Console.ReadKey();
        }

        //se realiza la compra de los productos seleccionados
        static void RealizarCompra() {

            //Se crea una lista de la compra para poder añadir los productos que se quieren comprar
            List<Producto> listaDeLaCompra = new List<Producto>();


            Producto productoElegido = null;
            bool continuidadCompra = false;
            do {
                Console.Clear();
                Console.WriteLine(" +++ REALIZAR COMPRA +++ ");
                //se muestra una breve descripción de cada uno de los productos que hay en la lista Productos para seleccionar uno por su ID y luego, sus unidades
                foreach (Producto producto in Productos) {
                    Console.WriteLine($"({producto.Id})|Nombre: {producto.Nombre} | Precio: {producto.PrecioUnitario} | Unidades disponibles: {producto.Unidades}");
                }
                Console.Write("Ingrese el ID del producto que desea comprar: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Ingrese la cantidad que desea comprar: ");
                int unidades = int.Parse(Console.ReadLine());
            

                //Solo se podrá comprar un producto si hay suficientes unidades
                foreach (Producto p in Productos) {
                    if (p.Id == id && p.Unidades >= unidades) {
                        productoElegido = p;
  
                    }
                    else if (p.Unidades < unidades) {
                        Console.WriteLine("No quedan unidades del producto seleccionado");
                    }
                }

                if (productoElegido != null && productoElegido.Unidades >= unidades) {
                    productoElegido.Unidades -= unidades;
                    //se añade el producto elegido a la cesta
                    listaDeLaCompra.Add(productoElegido);
                    Console.WriteLine($"Producto Añadido a la Cesta");
                }
                //se vuelve a repetir el proceso anterior si ponemos True
                Console.Write("Quiere añadir más productos a la cesta? (true = Sí / false = No): ");
                continuidadCompra = bool.Parse(Console.ReadLine());

            } while (continuidadCompra == true);

            //si la lista de la compra está vacía, no se puede realizar ningún pago
            if (listaDeLaCompra.Count > 0) {
                int opcionPago = 0;
                if (listaDeLaCompra.Count > 0) {
                    try {
                        Console.WriteLine("1. Pago en efectivo");
                        Console.WriteLine("2. Pago con tarjeta");
                        Console.Write("Seleccione el método de pago: ");
                        opcionPago = int.Parse(Console.ReadLine());
                        //se crea un objeto Pago al que se le pasa el contenido de listaDeLaCompra
                        Pago pago = new Pago(listaDeLaCompra);
                        switch (opcionPago) {
                            case 1:
                                pago.PagoEfectivo(listaDeLaCompra);
                                break;
                            case 2:
                                pago.PagoTarjeta(listaDeLaCompra);
                                break;
                        }
                    }
                    catch (FormatException) {
                        Console.WriteLine("Error: Opción inválida. Por favor, ingrese un número válido");
                    }
                    catch (Exception ex) {
                        Console.WriteLine("Error: " + ex.Message);

                    }

                }
                else {
                    Console.WriteLine("No hay ningún producto en la lista de la compra.");
                }
                Console.ReadKey();
            }
        }

        static Producto BuscarProducto() {
            Console.Write("ID del producto: ");
            int idBuscar = int.Parse(Console.ReadLine());

            Producto ProductoBuscar = null;
            foreach (Producto p in Productos) {
                if (p.Id == idBuscar) {
                    ProductoBuscar = p;
                }
            }

            if (ProductoBuscar != null) {

                Console.WriteLine(ProductoBuscar);
            }
            return ProductoBuscar;
        }


        static void MostrarDetallesDeProducto() {
            Console.WriteLine("+++ MOSTRAR DETALLES DE LOS PRODUCTOS +++");
            bool continuidadsolicitud = false;
            do {
                foreach (var producto in Productos) {
                    Console.WriteLine($"({producto.Id})|Nombre: {producto.Nombre} | Descripción: {producto.Descripcion} | Unidades: {producto.Unidades}");
                }

                Producto productoSolicitado = BuscarProducto();

                if (productoSolicitado != null) {
                    Console.WriteLine(productoSolicitado.MostrarDetalles());
                }
                else {
                    Console.WriteLine("Producto no encontrado");
                }
                Console.Write("¿Desea ver detalles de otro productos? (true = Sí / false = No): ");
                continuidadsolicitud = bool.Parse(Console.ReadLine());
            } while (continuidadsolicitud == true);
        }

    }
}
