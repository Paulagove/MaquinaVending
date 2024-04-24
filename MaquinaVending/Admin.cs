using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class Admin {

        private string Password { get; set; }
        public Admin() { }
        public Admin(string password) {
            Password = password;
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

                        break;
                    case 2:

                        break;
                    case 3:
                        Console.WriteLine("Saliendo al menú principal...");
                        break;
                }
            } while (opcion != 3);
        }
        public void CargaCompleta() {
            //se carga el contenido de la máqina utilizando un archivo
        }
        }
       
    }


