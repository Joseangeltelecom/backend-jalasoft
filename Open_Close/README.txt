using System;
using System.Text;

namespace OpenClosedPrinciple
{
    class Program
    {
        public class CuentaBancaria
        {
            private double _saldo;
            private static ulong _numeroDeIdentificador = 1;
            private ulong _identificador;

            public ulong Identificador { get { return _identificador; } }
            public double Saldo { get { return Saldo; } }
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
            public enum FormatoDeCuenta { FormatoA, FormatoB }

            public EstadoDeCuenta(CuentaBancaria cuenta)
            {
                this._cuenta = cuenta;
            }
            public string GenerarEstadoDeCuenta(FormatoDeCuenta formato)
            {
                StringBuilder stringBuilder = new StringBuilder();
                if(formato == FormatoDeCuenta.FormatoA)
                {
                    stringBuilder.Append("----------Formato A-----------\n");
                }
                else if (formato == FormatoDeCuenta.FormatoB)
                {
                    stringBuilder.Append("----------Formato B-----------\n");
                }
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
            Console.WriteLine(new EstadoDeCuenta(cuenta).GenerarEstadoDeCuenta(EstadoDeCuenta.FormatoDeCuenta.FormatoA));
            Console.WriteLine(new EstadoDeCuenta(cuenta1).GenerarEstadoDeCuenta(EstadoDeCuenta.FormatoDeCuenta.FormatoA));
            Console.WriteLine();
            Console.WriteLine(new EstadoDeCuenta(cuenta).GenerarEstadoDeCuenta(EstadoDeCuenta.FormatoDeCuenta.FormatoB));
            Console.WriteLine(new EstadoDeCuenta(cuenta1).GenerarEstadoDeCuenta(EstadoDeCuenta.FormatoDeCuenta.FormatoB));
            Console.ReadLine();
        }
    }
}