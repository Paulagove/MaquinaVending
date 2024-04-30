using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class Admin {

        private string Password { get; set; }
        public List<Producto> Productos { get; set; }
        public Admin(List<Producto> productos) {
            Password = "123456";
            Productos = productos;
        }

        public bool LoginAdmin(string password) {
            if (Password == password) {
                return true;
            }
            else {
                return false;
            }
        }
        public void CargaIndividual() {
            int opcion = 0;
            do {
                Console.WriteLine("--- Carga individual de productos ---");
                Console.WriteLine("1. Añadir existencias a productos existentes");
                Console.WriteLine("2. Añadir nuevos tipos de productos");
                Console.WriteLine("3. Salir al menú principal");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion) {
                    case 1:
                        AnadirExistencias();
                        break;
                    case 2:
                        AnadirNuevosTipos();
                        break;
                    case 3:
                        Console.WriteLine("Saliendo al menú principal...");
                        break;
                }
            } while (opcion != 3);

        }

        public void AnadirExistencias() { 
            //añadir las unidades que él quiera
         foreach(Producto p in Productos) {
                Console.WriteLine(p.MostrarDetalles());
            }
            Console.WriteLine("Indique el producto mediante su ID: ");
            int id_producto = int.Parse(Console.ReadLine());

            Producto productoTemp = BuscarProducto(id_producto);
            if (p != null) {
                Productos.Add(p); //NO ES A´SI
                Console.WriteLine("Existencias añadidas");
            }

        }

        public Producto BuscarProducto(int id) {
            Producto productoTemp = null;
            foreach (Producto p in Productos) {
                if (p.Id == id) {
                    productoTemp = p;
                }
            }
            return productoTemp;
        }

        public void AnadirNuevosTipos() {
            int opcion = 0;
            while (Productos.Count <= 12) {
                Console.WriteLine("1. Material precioso");
                Console.WriteLine("2. Producto alimenticio");
                Console.WriteLine("3. Producto electrónico");
                Console.Write("Seleccione el tipo de producto que desea añadir: ");
                opcion = int.Parse(Console.ReadLine());
                
                switch(opcion) { 
                    
                    case 1:
                     
                        MaterialesPreciosos mp = new MaterialesPreciosos();
                        mp.SolicitarDetalles();
                        Productos.Add(mp);
                        break;
                    case 2:
                        ProductosAlimenticios pa = new ProductosAlimenticios();
                        pa.SolicitarDetalles();
                        Productos.Add(pa);
                        break;
                    case 3:
                        ProductosElectronicos pe = new ProductosElectronicos();
                        pe.SolicitarDetalles();
                        Productos.Add(pe);
                        break;
                }
                Console.WriteLine("Producto añadido con éxito");

            }
            Console.WriteLine("No se pueden añadir nuevos tipos de productos. Todos los slots están ocupados");

        }



        public bool CargaCompleta() {
            //se carga el contenido de la máquina utilizando un archivo
            bool productosCargados = false;
            try {
                if (File.Exists("example_vending_file_practical_work_i.csv")) {
                    StreamReader sr = File.OpenText("example_vending_file_practical_work_i.csv");
                    string header = sr.ReadLine();
                    string linea;
                    Console.WriteLine(header);
                    while ((linea = sr.ReadLine()) != null) {
                        productosCargados = true;
                        string[] datos = linea.Split(';');
                        if (datos[0] == "1") {
                            MaterialesPreciosos mp = new MaterialesPreciosos(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), double.Parse(datos[3]), datos[4], datos[5], double.Parse(datos[6]));
                            Productos.Add(mp);
                        }
                        else if (datos[0] == "2") {
                            ProductosAlimenticios pa = new ProductosAlimenticios(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), double.Parse(datos[3]), datos[4], datos[5]);
                            Productos.Add(pa);
                        }
                        else if (datos[0] == "3") {
                            ProductosElectronicos pe = new ProductosElectronicos(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), double.Parse(datos[3]), datos[4], datos[5], bool.Parse(datos[6]), bool.Parse(datos[7]));
                            Productos.Add(pe);
                        }

                    }
                }
                else {
                    File.Create("productos.txt").Close();
                }
            }
            catch (FileNotFoundException ex) {
                Console.WriteLine("No se encuentra el archivo de contenidos: " + ex.Message);
            }
            catch (IOException ex) {
                Console.WriteLine("Error de E/S: " + ex.Message);
            }
            return productosCargados;
        }
    }

}


