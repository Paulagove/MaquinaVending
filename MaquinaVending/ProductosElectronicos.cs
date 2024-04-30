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

        public ProductosElectronicos(int id, string tipoProducto, string nombre, int unidades, double precioUnitario, string descripcion, string tipoMaterial, bool tieneBateria, bool precargado)
        : base(id, tipoProducto, nombre, unidades, precioUnitario, descripcion)
        {
            TipoMaterial = tipoMaterial;
            TieneBateria = tieneBateria;
            Precargado = precargado;
            TipoProducto = "Producto electrónico";
        }

        public override string MostrarDetalles()
        {
            return base.MostrarDetalles() + $"\n| Tipo de Material: {TipoMaterial} | ¿Tiene Bateria? (true = Sí / false = No): {TieneBateria} | ¿Viene precargado? (true = Sí / false = No): {Precargado}";
        }

        public override void SolicitarDetalles() {
            base.SolicitarDetalles();
            Console.Write("Tipo de material: ");
            TipoMaterial = Console.ReadLine();
            Console.Write("¿Tiene batería? (true = Sí / false = No): ");
            TieneBateria = bool.Parse(Console.ReadLine());
            Console.Write("¿Viene precargado? (true = Sí / false = No): ");
            Precargado = bool.Parse(Console.ReadLine());
        }

       
    }
}
