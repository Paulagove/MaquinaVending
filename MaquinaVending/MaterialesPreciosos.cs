using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class MaterialesPreciosos : Producto {

        public string TipoMaterial { get; set; }
        public double Peso { get; set; }

      public MaterialesPreciosos() { }

        public MaterialesPreciosos(int count) {
            Id = count + 1;
        }

        public MaterialesPreciosos(int id, string nombre, int unidades, double precioUnitario, string descripcion, string tipoMaterial, double peso)
        : base(id, nombre, unidades, precioUnitario, descripcion)
        {
            TipoMaterial = tipoMaterial;
            Peso = peso;
        }
        public override string MostrarDetalles()
        {
            return base.MostrarDetalles() + $"Tipo de material: {TipoMaterial}, Peso {Peso}";
        }
        public override void SolicitarDetalles() {
            base.SolicitarDetalles();
            Console.Write("Tipo de material: ");
            TipoMaterial = Console.ReadLine();
            Console.Write("Peso: ");
            Peso = int.Parse(Console.ReadLine());
        }
        public override void ToFile() {
            try {
                StreamWriter sw = new StreamWriter("maquinavending.txt", true);
                sw.WriteLine($"({Id})|Material Precioso|{Nombre}|{Unidades}|{PrecioUnitario}|{Descripcion}|{TipoMaterial}|{Peso}");
                sw.Close();
            }
            catch (FileNotFoundException ex) {
                Console.WriteLine("No se encuentra el archivo de películas: " + ex.Message);
            }
        }
    }
}
