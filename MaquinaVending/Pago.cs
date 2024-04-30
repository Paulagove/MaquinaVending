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
            double moneda = 0;
            double sumaMonedas = 0;
            double precioTotal = 0;

            foreach (Producto p in listaDeLaCompra) {
               precioTotal += p.PrecioUnitario;
            }
            Console.WriteLine("Introduzca las monedas una a una: ");
            do {
                for (double i = 0 ; i <= precioTotal ; i++) {
                    moneda = double.Parse(Console.ReadLine());
                    sumaMonedas += moneda;
                }
            } while (sumaMonedas >= precioTotal );

            Console.WriteLine("Pago realizado con éxito!");
            Console.WriteLine($"Su cambio es de {sumaMonedas} - {precioTotal} euros");
        }
        public void PagoTarjeta(List<Producto> listaDeLaCompra) {
            double precioTotal = 0;

            foreach (Producto p in listaDeLaCompra) {
                precioTotal += p.PrecioUnitario;
            }
            Console.Write("Introduzca el número de la tarjeta: ");
            int NumeroTarjeta = int.Parse(Console.ReadLine());
            Console.Write("Introduzca la fecha de caducidad: ");
            DateTime FechaTarjeta = DateTime.Parse(Console.ReadLine());
            Console.Write("Introduzca el código de seguridad: ");
            int CVV = int.Parse(Console.ReadLine());

            Console.WriteLine($"Pago realizado de {precioTotal} euros con éxito!");
        }

    }
}
