﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class MaterialesPreciosos : Producto { //hereda de la superclase Producto

        public string TipoMaterial { get; set; }
        public double Peso { get; set; }

        public MaterialesPreciosos() { }

        public MaterialesPreciosos(int count) { //Para que se sume cada número de ID a medida que se va añadiendo un producto
            Id = count + 1;
        }

        public MaterialesPreciosos(int id, string tipoProducto, string nombre, int unidades, float precioUnitario, string descripcion, string tipoMaterial, double peso)
        : base(id, tipoProducto, nombre, unidades, precioUnitario, descripcion) {
            TipoMaterial = tipoMaterial;
            Peso = peso;
            TipoProducto = "Material Precioso";
        }
        public override string MostrarDetalles() {
            return base.MostrarDetalles() + $" | Tipo de material: {TipoMaterial} | Peso: {Peso}";
        }
        public override void SolicitarDetalles() {
            base.SolicitarDetalles();
            try {
                Console.Write("Tipo de material: ");
                TipoMaterial = Console.ReadLine();
                Console.Write("Peso: ");
                Peso = int.Parse(Console.ReadLine());
            }
            catch (FormatException) {
                Console.WriteLine("Error: Opción inválida. Por favor, ingrese un número válido");
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }
}
