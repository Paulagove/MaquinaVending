using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class PagoEfectivo {
        //el usuario introduce monedas una a una (0,10-0,20-0,50-1-2 euros) hasta que se alcance o supere el precio del producto
       

        public PagoEfectivo() {
            
        }
        public void Pago() {
            float moneda = 0;
            float sumaMonedas = 0;
            Console.WriteLine("Introduzca las monedas una a una: ");
            do {
                for (int i = 0; i <= Producto.PrecioUnitario ; i++) {
                    moneda = float.Parse(Console.ReadLine());
                    sumaMonedas += moneda;
                }
             } while (sumaMonedas >= PrecioPorducto) ;

            Console.WriteLine("Pago realizado con éxito!");
            Console.WriteLine($"Su cambio es de {sumaMonedas} - {PrecioProducto} euros");
        }
    
    }
}
