using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class ProductosAlimenticios : Producto {  //hereda de la superclase Producto 

        public string InformacionNutricional { get; set; }
        public ProductosAlimenticios() { }

        public ProductosAlimenticios(int count) { //Para que se sume cada número de ID a medida que se va añadiendo un producto
            Id = count + 1;
        }


        public ProductosAlimenticios(int id, string tipoProducto, string nombre, int unidades, float precioUnitario, string descripcion, string informacionNutricional)
        : base(id, tipoProducto, nombre, unidades, precioUnitario, descripcion) {
            InformacionNutricional = informacionNutricional;
            TipoProducto = "Producto alimenticio";
        }

        public override string MostrarDetalles() {
            return base.MostrarDetalles() + $" | Informacion Nutricional: {InformacionNutricional}";
        }

        public override void SolicitarDetalles() {
            base.SolicitarDetalles();
            Console.Write("Información nutricional: ");
            InformacionNutricional = Console.ReadLine();
        }

    }
}
