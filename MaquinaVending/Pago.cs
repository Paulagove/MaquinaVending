using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class Pago {
 

        public List<Producto> Productos = new List<Producto>();
        public Pago(List<Producto> productos) {
            Productos = productos;
        }

        public void PagoEfectivo(List<Producto> listaDeLaCompra) {
            double precioTotal = 0.0;
            double[] efectivo = { 0.10, 0.20, 0.50, 1.00, 2.00, 5, 10, 20, 50, 100, 200 };

            double dineroIngresado = 0.0;
            
           
            foreach (Producto p in listaDeLaCompra) {
               precioTotal += p.PrecioUnitario;
            }

            Console.WriteLine($"Debe pagar {precioTotal} euros");
            do {
                Console.WriteLine("Introduzca de uno en uno el billete o moneda (solo se permiten de 0.10, 0.20, 0.50, 1.00, 2.00, 5, 10, 20, 50, 100) euros");
                double monedaIngresada = double.Parse(Console.ReadLine());
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


        public void PagoTarjeta(List<Producto> listaDeLaCompra) {
            double precioTotal = 0;

            foreach (Producto p in listaDeLaCompra) {
                precioTotal += (p.PrecioUnitario * p.Unidades);
            }
            Console.WriteLine($"Debe pagar {precioTotal} euros");

            Console.Write("Introduzca el número de la tarjeta: ");
            int NumeroTarjeta = int.Parse(Console.ReadLine());
            Console.Write("Introduzca la fecha de caducidad: ");
            DateTime FechaTarjeta = DateTime.Parse(Console.ReadLine());
            Console.Write("Introduzca el código de seguridad: ");
            int CVV = int.Parse(Console.ReadLine());

            Console.WriteLine($"Pago realizado de {precioTotal} euros con éxito!");
            Console.WriteLine("Gracias por su compra!");
            Console.ReadKey();
        }


    }
}
