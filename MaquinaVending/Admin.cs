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
         foreach(var productos in Productos) {
                Console.WriteLine(productos);
            }
            Console.WriteLine("Indique el producto: ");

        }

        public bool AnadirNuevosTipos() {


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


