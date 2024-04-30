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
        public List<Producto> Productos  { get; set; }
        public Admin(List<Producto> productos) {
            Password = "123456";
            Productos = productos;
        }

        /*Este método permite luego en la clase Program veríficar que es el administrador el que está cargando los productos
        Si la contraseña que se introduce coincide con la establecida en la clase, devuelve true y puede acceder a los demás métodos
        del Program. En caso contrario, devuelve un false.  */

        public bool LoginAdmin(string password) {
            if (Password == password) {
                return true;
            }
            else {
                return false;
            }
        }

        //Este método permite cargar individualmente los productos
        public void CargaIndividual() {
            int opcion = 0;
            do {
                try {
                    Console.WriteLine("+++ CARGA INDIVIDUAL DE PRODUCTOS +++");
                    Console.WriteLine("1. Añadir existencias a productos existentes");
                    Console.WriteLine("2. Añadir nuevos tipos de productos");
                    Console.WriteLine("3. Salir al menú principal");
                    Console.Write("Seleccione una opción: ");
                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion) {
                        case 1:
                            AnadirExistencias();
                            Console.Clear();
                            break;
                        case 2:
                            
                            AnadirNuevosTipos();
                            Console.Clear();
                            break;
                        case 3:
                            Console.WriteLine("Saliendo al menú principal...");
                            Console.Clear();
                            break;
                    }
                }
                catch (FormatException) {
                    Console.WriteLine("Error: Opción inválida. Por favor, ingrese un número válido");
                }
                catch (Exception ex) {
                    Console.WriteLine("Error: " + ex.Message);
                }
            } while (opcion != 3);
            Console.Clear();
        }

        //Este método permite añadir ecistencias a productos ya existentes mediante su ID
        public void AnadirExistencias() {
            Producto productoTemp = null;  //este objeto nos servirá como "contenedor" para poder almacenar el producto elegido
            //se muestran los detalles de cada producto
            foreach (Producto p in Productos) {
                Console.WriteLine(p.MostrarDetalles());
            }
            Console.Write("Indique el producto que quiera añadir mediante su ID: ");
            int id_producto = int.Parse(Console.ReadLine());
            Console.Write("Introduzca el número de unidades que desea añadir: ");
            int unidades_producto = int.Parse(Console.ReadLine());

            foreach (Producto p in Productos) {
                if (id_producto == p.Id) {
                    productoTemp = p;

                }
            }

            if (productoTemp != null) {
                productoTemp.Unidades += unidades_producto;  //se añaden las unidades que se han introducido
            }
            Console.WriteLine($"Se han añadido {unidades_producto} unidades al producto {productoTemp.Nombre}");
        }


         //Este método permite añadir nuevos productos en función del tipo seleccionado
        public void AnadirNuevosTipos() {
            int opcion = 0;
            Console.Clear();
            try {
                Console.WriteLine("+++ AÑADIR NUEVOS PRODUCTOS +++");
                Console.WriteLine("1. Material precioso");
                Console.WriteLine("2. Producto alimenticio");
                Console.WriteLine("3. Producto electrónico");
                Console.WriteLine("4. Retroceder");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion) {

                    case 1:
                        //se añade el .Count en productos para que se vaya sumando el número de ID a medida que creamos nuevos productos
                        //se crean nuevas clases de cada tipo de producto y se les solicitan los detalles. Luego, esos productos se añaden a la clase Productos
                        MaterialesPreciosos mp = new MaterialesPreciosos(Productos.Count); 
                        mp.SolicitarDetalles();
                        Productos.Add(mp);

                        Console.WriteLine("Producto  añadido con éxito");
                        Console.Clear();
                        break;
                    case 2:
                        ProductosAlimenticios pa = new ProductosAlimenticios(Productos.Count);
                        pa.SolicitarDetalles();
                        Productos.Add(pa);
                        Console.WriteLine("Producto añadido con éxito");
                        Console.Clear();
                        break;
                    case 3:
                        ProductosElectronicos pe = new ProductosElectronicos(Productos.Count);
                        pe.SolicitarDetalles();
                        Productos.Add(pe);
                        Console.WriteLine("Producto añadido con éxito");
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("Retrocediendo...");
                        break;
                }
            }
            catch (FormatException) {
                Console.WriteLine("Error: Opción inválida. Por favor, ingrese un número válido");
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


        public bool CargaCompleta() {
            //se carga el contenido de la máquina utilizando un archivo
            bool productosCargados = false;
            Console.WriteLine("+++ CARGA COMPLETA DE PRODUCTOS +++");

            try {
                if (File.Exists("productos.csv")) {
                    StreamReader sr = File.OpenText("productos.csv");
                    string linea;

                    while ((linea = sr.ReadLine()) != null) {
                        productosCargados = true;
                        string[] datos = linea.Split(';');
            
                        if (datos[1] == "Material Precioso") {
                            MaterialesPreciosos mp = new MaterialesPreciosos(int.Parse(datos[0]), datos[1], datos[2], int.Parse(datos[3]), float.Parse(datos[4]), datos[5], datos[6], double.Parse(datos[7]));
                            Productos.Add(mp);
                        }
                        else if (datos[1] == "Producto Alimenticio") {
                            ProductosAlimenticios pa = new ProductosAlimenticios(int.Parse(datos[0]), datos[1], datos[2], int.Parse(datos[3]), float.Parse(datos[4]), datos[5], datos[6]);
                            Productos.Add(pa);
                        }
                        else if (datos[1] == "Producto Alimenticio") {
                            ProductosElectronicos pe = new ProductosElectronicos(int.Parse(datos[0]), datos[1], datos[2], int.Parse(datos[3]), float.Parse(datos[4]), datos[5], datos[6], bool.Parse(datos[7]), bool.Parse(datos[7]));
                            Productos.Add(pe);
                        }

                    }

                }
                else {
                    File.Create("productos.csv").Close();
                }
                Console.WriteLine("Productos cargados correctamente");
                Console.ReadKey();
            }
            catch (FileNotFoundException ex) {
                Console.WriteLine("No se encuentra el archivo de productos: " + ex.Message);
            }
            catch (IOException ex) {
                Console.WriteLine("Error de E/S: " + ex.Message);
            }

            return productosCargados;

        }
    }

}


