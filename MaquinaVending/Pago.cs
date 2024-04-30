using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class Pago {


        public List<Producto> Productos = new List<Producto>();
        public Pago(List<Producto> productos) { //se le pasa la lista de objetos de Productos
            Productos = productos;
        }

        //método para pagar en efectivo introduciendo monedas o billetes de uno en uno
        public void PagoEfectivo(List<Producto> listaDeLaCompra) {  //se le pasa la lista listaDeLaCompra para obtener el precio de cada producto y las unidades seleccionadas
            float precioTotal = 0.00f;
            float[] efectivo = { 0.10f, 0.20f, 0.50f, 1.00f, 2.00f, 5.00f, 10.00f, 20.00f, 50.00f, 100.00f, 200.00f };

            float dineroIngresado = 0.00f;

            //se calcula el precio total de la compra
            foreach (Producto p in listaDeLaCompra) {
                precioTotal += p.PrecioUnitario * p.Unidades;
            }

            Console.WriteLine($"Debe pagar {precioTotal} euros");
            do {
              
                    Console.WriteLine("Introduzca de uno en uno el billete o moneda (solo se permiten de 0.10, 0.20, 0.50, 1.00, 2.00, 5, 10, 20, 50, 100) euros");
                    float monedaIngresada = float.Parse(Console.ReadLine());
                    bool monedaValida = false;
                    for (int i = 0; i < efectivo.Length; i++) {
                        if (monedaIngresada == efectivo[i]) {
                            monedaValida = true;
                        }
                    }


                    if (monedaValida) {
                        dineroIngresado += monedaIngresada;
                    }
                    else {
                        Console.WriteLine("Moneda o billete no válido. Por favor, introduzca una cantidad válida.");
                    }
 
            } while (dineroIngresado < precioTotal);


            if (dineroIngresado == precioTotal) {
                Console.WriteLine("Gracias por su compra!");
            }
            else if (dineroIngresado > precioTotal) {
                double vuelta = dineroIngresado - precioTotal;
                Console.WriteLine($"Su cambio es de {vuelta} euros");
                Console.WriteLine("Gracias por su compra!");
            }
        }

        //método para pagar con tarjeta
        public void PagoTarjeta(List<Producto> listaDeLaCompra) {  //se le pasa la lista listaDeLaCompra para obtener el precio de cada producto y las unidades seleccionadas
            float precioTotal = 0.00f;

            foreach (Producto p in listaDeLaCompra) {
                precioTotal += (p.PrecioUnitario * p.Unidades);
            }
            Console.WriteLine($"Debe pagar {precioTotal} euros");
            try {
                Console.Write("Introduzca el número de la tarjeta: ");
                int NumeroTarjeta = int.Parse(Console.ReadLine());
                Console.Write("Introduzca la fecha de caducidad: ");
                DateTime FechaTarjeta = DateTime.Parse(Console.ReadLine());
                Console.Write("Introduzca el código de seguridad: ");
                int CVV = int.Parse(Console.ReadLine());
            }
            catch (FormatException) {
                Console.WriteLine("Error: Opción inválida. Por favor, ingrese un número válido");
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.WriteLine($"Pago realizado de {precioTotal} euros con éxito!");
            Console.WriteLine("Gracias por su compra!");
            Console.ReadKey();
        }


    }
}
