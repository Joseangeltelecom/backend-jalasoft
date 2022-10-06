using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversion
{
    public interface ITransferMoney
    {
     void Transferrir(ICuentaBancaria origen, ICuentaBancaria destino, double monto);
    }
}
