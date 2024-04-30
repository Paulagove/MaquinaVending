using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class ProductosAlimenticios : Producto {

        public string InformacionNutricional { get; set; }
        public ProductosAlimenticios() { }

        public ProductosAlimenticios(int count) {
            Id = count + 1;
        }


        public ProductosAlimenticios(int id, string nombre, int unidades, double precioUnitario, string descripcion, string informacionNutricional)
        : base(id, nombre, unidades, precioUnitario, descripcion) {
            InformacionNutricional = informacionNutricional;
        }

        public override string MostrarDetalles() {
            return base.MostrarDetalles() + $" - Informacion Nutricional: {InformacionNutricional}";
        }

        public override void SolicitarDetalles() {
            base.SolicitarDetalles();
            Console.Write("Información nutricional: ");
            InformacionNutricional = Console.ReadLine();
        }
        public override void ToFile() {
            try {
                StreamWriter sw = new StreamWriter("maquinavending.txt", true);
                sw.WriteLine($"({Id})|Producto Alimenticio|{Nombre}|{Unidades}|{PrecioUnitario}|{Descripcion}|{InformacionNutricional}");
                sw.Close();
            }
            catch (FileNotFoundException ex) {
                Console.WriteLine("No se encuentra el archivo de películas: " + ex.Message);
            }
        }
    }
}
