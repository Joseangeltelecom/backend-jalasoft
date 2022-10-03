using System;
using System.Collections.Generic;
using System.Text;

namespace SingleResponsability
{
    internal class MountTransferService
    {
        public void TranseferirMonto( CuentaBancaria cuentaOrigen, CuentaBancaria cuentaDestino, double monto)
        {
            cuentaOrigen.Saldo -= monto;
            cuentaDestino.Saldo += monto;
        }
    }
}
