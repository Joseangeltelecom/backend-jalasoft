using System;
using System.Collections.Generic;
using System.Text;

namespace Liskov
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

    // parent
    public abstract class EstadoDeCuenta
    {
        protected CuentaBancaria _cuenta;
        public virtual string GenerarContenido()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Estado de cuenta\n");
            stringBuilder.Append("\tEstado de cuenta");
            stringBuilder.AppendLine(_cuenta.Identificador.ToString());
            stringBuilder.Append("\tSaldo:");
            stringBuilder.AppendFormat("{0:f2}", _cuenta.Saldo);
            return stringBuilder.ToString();
        }
        public abstract string GenerarEncabezado();
    }

    public abstract class EstadoDeCuentaConPie : EstadoDeCuenta
    {
        public abstract string GenerarPie();
    }

    // Child A:
    public class FormatoADeEstadoDeCuenta : EstadoDeCuentaConPie
    {
        public FormatoADeEstadoDeCuenta(CuentaBancaria cuenta)
        {
            this._cuenta = cuenta;
        }
        public override string GenerarEncabezado()
        {
            return "----------FORMATO A-----------\n";
        }
        public override string GenerarPie()
        {
            return "----------PIE DE FORMATO A-----------\n";
        }
    }

    // child B:
    public class FormatoBDeEstadoDeCuenta : EstadoDeCuenta
    {
        public FormatoBDeEstadoDeCuenta(CuentaBancaria cuenta)
        {
            this._cuenta = cuenta;
        }
        override public string GenerarEncabezado()
        {
            return "----------FORMATO B-----------\n";
        }
    }
    class Program
    {
        static void Imprimir(List<EstadoDeCuenta> estadosDeCuenta)
        {
            foreach (EstadoDeCuenta estadoDeCuenta in estadosDeCuenta)
            {
                Console.WriteLine(estadoDeCuenta.GenerarEncabezado());
                Console.WriteLine(estadoDeCuenta.GenerarContenido());
                if (estadoDeCuenta is EstadoDeCuentaConPie)
                {
                    FormatoADeEstadoDeCuenta formatoADeEstadoDeCuenta = (FormatoADeEstadoDeCuenta)estadoDeCuenta;
                    Console.WriteLine(formatoADeEstadoDeCuenta.GenerarPie());
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            CuentaBancaria cuenta1 = new CuentaBancaria(100);
            CuentaBancaria cuenta2 = new CuentaBancaria(150);

            cuenta2.TranseferirMonto(cuenta1, 30);
            List<EstadoDeCuenta> estadosDeCuenta = new List<EstadoDeCuenta>
            {
                new FormatoADeEstadoDeCuenta(cuenta1),
                new FormatoADeEstadoDeCuenta(cuenta2),
                new FormatoBDeEstadoDeCuenta(cuenta1),
                new FormatoBDeEstadoDeCuenta(cuenta2)
            };
            Imprimir(estadosDeCuenta);
            Console.ReadLine();
        }
    }
}