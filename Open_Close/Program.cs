using Open_Close.Utils;
using System;
using System.Text;

namespace Open_Close
{
    class Program
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
        }

        public class EstadoDeCuenta
        {
            private CuentaBancaria _cuenta;

            public EstadoDeCuenta(CuentaBancaria cuenta)
            {
                this._cuenta = cuenta;
            }
            public string GenerarEstadoDeCuenta(IFormat formato)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(formato.getFormat());

                stringBuilder.Append("Estado de cuenta\n");
                stringBuilder.Append("\tEstado de cuenta");
                stringBuilder.AppendLine(_cuenta.Identificador.ToString());
                stringBuilder.Append("\tSaldo:");
                stringBuilder.AppendFormat("{0:f2}", _cuenta.Saldo);
                return stringBuilder.ToString();
            }
        }
        static void Main(string[] args)
        {
            CuentaBancaria cuenta = new CuentaBancaria(100);
            CuentaBancaria cuenta1 = new CuentaBancaria(150);
            cuenta1.TranseferirMonto(cuenta, 30);

            IFormat formatA = new FormatA();
            IFormat formatB = new FormatB();

            Console.WriteLine(new EstadoDeCuenta(cuenta).GenerarEstadoDeCuenta(formatA));
            Console.WriteLine(new EstadoDeCuenta(cuenta1).GenerarEstadoDeCuenta(formatA));
            Console.WriteLine();
            Console.WriteLine(new EstadoDeCuenta(cuenta).GenerarEstadoDeCuenta(formatB));
            Console.WriteLine(new EstadoDeCuenta(cuenta1).GenerarEstadoDeCuenta(formatB));
            Console.ReadLine();
        }
    }
}