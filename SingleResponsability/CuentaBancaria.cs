using System;
using System.Collections.Generic;
using System.Text;

namespace SingleResponsability
{
    public class CuentaBancaria
    {
        private double _saldo;
        private static ulong _numeroDeIdentificador = 1;
        private ulong _identificador;

        public ulong Identificador { get { return _identificador; } }
        public double Saldo { get { return _saldo; } set { _saldo = value; } }


        public CuentaBancaria(double saldoInicial)
        {
            _identificador = _numeroDeIdentificador++;
            _saldo = saldoInicial;
        }

    }
}
