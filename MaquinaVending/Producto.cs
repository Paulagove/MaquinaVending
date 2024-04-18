using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal abstract class Producto {
    protected string Nombre {  get; set; }
    protected int Unidades { get; set; }
    protected double PrecioUnitario { get; set; }
    protected string Descripcion { get; set; }
    
    }
}
