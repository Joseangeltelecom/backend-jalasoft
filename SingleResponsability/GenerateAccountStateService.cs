using System;
using System.Collections.Generic;
using System.Text;

namespace SingleResponsability
{
    internal class GenerateAccountStateService
    {
        public string GenerarEstadoDeCuenta(CuentaBancaria cuenta)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Estado de cuenta\n");
            stringBuilder.Append("\tEstado de cuenta");
            stringBuilder.AppendLine(cuenta.Identificador.ToString());
            stringBuilder.Append("\tSaldo:");
            stringBuilder.AppendFormat("{0:f2}", cuenta.Saldo);
            return stringBuilder.ToString();
        }
    }
}
