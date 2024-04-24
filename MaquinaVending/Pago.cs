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
        public void PagoEfectivo() {
            float moneda = 0;
            float sumaMonedas = 0;
            float PrecioTotal;
            Console.WriteLine("Introduzca las monedas una a una: ");
            do {
                for (int i = 0; i <= PrecioTotal ; i++) {
                    moneda = float.Parse(Console.ReadLine());
                    sumaMonedas += moneda;
                }
            } while (sumaMonedas >= PrecioTotal );

            Console.WriteLine("Pago realizado con éxito!");
            Console.WriteLine($"Su cambio es de {sumaMonedas} - { } euros");
        }
        public void PagoTarjeta() {
            Console.Write("Introduzca el número de la tarjeta: ");
            int NumeroTarjeta = int.Parse(Console.ReadLine());
            Console.Write("Introduzca la fecha de caducidad: ");
            DateTime FechaTarjeta = DateTime.Parse(Console.ReadLine());
            Console.Write("Introduzca el código de seguridad: ");
            int CVV = int.Parse(Console.ReadLine());

            Console.WriteLine("Pago realizado con éxito!");
        }

    }
}
