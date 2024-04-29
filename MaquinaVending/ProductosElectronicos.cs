using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class ProductosElectronicos : Producto {

        public string TipoMaterial { get; set; }
        public bool TieneBateria { get; set; }
        public bool Precargado { get; set; }


        public ProductosElectronicos(int id, string nombre, int unidades, double precioUnitario, string descripcion, string tipoMaterial, bool tieneBateria, bool precargado)
        : base(id, nombre, unidades, precioUnitario, descripcion)
        {
            TipoMaterial = tipoMaterial;
            TieneBateria = tieneBateria;
            Precargado = precargado;
        }

        public override string MostrarDetalles()
        {
            return base.MostrarDetalles() + $"\nTipo de Material: {TipoMaterial} - ¿Tiene Bateria? 1.Sí/0.No: {TieneBateria} - ¿Viene precargado? 1.Sí/0.No: {Precargado}";
        }

        public override void SolicitarDetalles() {
            base.SolicitarDetalles();
            Console.Write("Tipo de material: ");
            TipoMaterial = Console.ReadLine();
            Console.Write("¿Tiene batería? 1.Sí ; 0.No: ");
            TieneBateria = bool.Parse(Console.ReadLine());
            Console.Write("¿Viene precargado? 1.Sí ; 0.No: ");
            Precargado = bool.Parse(Console.ReadLine());
        }
    }
}
