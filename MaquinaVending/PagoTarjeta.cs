using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class PagoTarjeta {
        private int NumeroTarjeta { get; set; }
        private DateTime FechaTarjeta { get; set; }
        private int CVV { get; set; }
        public PagoTarjeta() {}

        public void Pago() {
            Console.Write("Introduzca el número de la tarjeta: ");
            NumeroTarjeta = int.Parse(Console.ReadLine());
            Console.Write("Introduzca la fecha de caducidad: ");
            FechaTarjeta = DateTime.Parse(Console.ReadLine());
            Console.Write("Introduzca el código de seguridad: ");
            CVV = int.Parse(Console.ReadLine());

            Console.WriteLine("Pago realizado con éxito!");
        }
    }
}
