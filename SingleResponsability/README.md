using System;
using System.Text;

namespace SingleResponsability
{
    public class CuentaBancaria
    {
        private double _saldo;
        private static ulong _numeroDeIdentificador = 1;
        private ulong _identificador;

        public ulong Identificador { get { return _identificador; } }
        public double Saldo { get { return _saldo; } }
        public CuentaBancaria(double saldoInicial)
        {
            _identificador = _numeroDeIdentificador++;
            _saldo = saldoInicial;
        }

        public void TranseferirMonto(CuentaBancaria cuentaDestino, double monto)
        {
            this._saldo -= monto;
            cuentaDestino._saldo += monto;
        }
        public string GenerarEstadoDeCuenta()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Estado de cuenta\n");
            stringBuilder.Append("\tEstado de cuenta");
            stringBuilder.AppendLine(Identificador.ToString());
            stringBuilder.Append("\tSaldo:");
            stringBuilder.AppendFormat("{0:f2}",Saldo);
            return stringBuilder.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CuentaBancaria cuenta = new CuentaBancaria(100);
            CuentaBancaria cuenta1 = new CuentaBancaria(150);
            cuenta1.TranseferirMonto(cuenta, 30);
            Console.WriteLine(cuenta.GenerarEstadoDeCuenta());
            Console.WriteLine(cuenta1.GenerarEstadoDeCuenta());
            Console.ReadLine();
        }
    }
}