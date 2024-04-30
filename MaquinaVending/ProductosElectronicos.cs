using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class ProductosElectronicos : Producto {

        public string TipoMaterial { get; set; }
        public bool TieneBateria { get; set; }
        public bool Precargado { get; set; }

        public ProductosElectronicos() { }

        public ProductosElectronicos(int count) {
            Id = count + 1;
        }

        public ProductosElectronicos(int id, string nombre, int unidades, double precioUnitario, string descripcion, string tipoMaterial, bool tieneBateria, bool precargado)
        : base(id, nombre, unidades, precioUnitario, descripcion)
        {
            TipoMaterial = tipoMaterial;
            TieneBateria = tieneBateria;
            Precargado = precargado;
        }

        public override string MostrarDetalles()
        {
            return base.MostrarDetalles() + $"\nTipo de Material: {TipoMaterial} - ¿Tiene Bateria? (True = Sí ; False = No): {TieneBateria} - ¿Viene precargado? (True = Sí ; False = No): {Precargado}";
        }

        public override void SolicitarDetalles() {
            base.SolicitarDetalles();
            Console.Write("Tipo de material: ");
            TipoMaterial = Console.ReadLine();
            Console.Write("¿Tiene batería? (True = Sí ; False = No): ");
            TieneBateria = bool.Parse(Console.ReadLine());
            Console.Write("¿Viene precargado? (True = Sí ; False = No): ");
            Precargado = bool.Parse(Console.ReadLine());
        }

        public override void ToFile() {
            try {
                StreamWriter sw = new StreamWriter("maquinavending.txt", true);
                sw.WriteLine($"({Id})|Producto Electrónico|{Nombre}|{Unidades}|{PrecioUnitario}|{Descripcion}|{TipoMaterial}|{TieneBateria}");
                sw.Close();
            }
            catch (FileNotFoundException ex) {
                Console.WriteLine("No se encuentra el archivo de películas: " + ex.Message);
            }
        }
    }
}
