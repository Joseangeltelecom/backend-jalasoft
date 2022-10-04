using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSubstitutionPrinciple
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

    public interface IEstadoDeCuenta
    {
        public string GenerarContenido();
        public string GenerarEncabezado();
        public string GenerarPie();
    }

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
    }

    public class FormatoADeEstadoDeCuenta : EstadoDeCuenta, IEstadoDeCuenta
    {
        public FormatoADeEstadoDeCuenta(CuentaBancaria cuenta)
        {
            this._cuenta = cuenta;
        }
        public string GenerarEncabezado()
        {
            return "----------FORMATO A-----------\n";
        }
        public string GenerarPie()
        {
            return "----------PIE DE FORMATO A-----------\n";
        }
    }
    public class FormatoBDeEstadoDeCuenta : EstadoDeCuenta, IEstadoDeCuenta
    {
        public FormatoBDeEstadoDeCuenta(CuentaBancaria cuenta)
        {
            this._cuenta = cuenta;
        }
        public string GenerarEncabezado()
        {
            return "----------FORMATO B-----------\n";
        }
        public string GenerarPie()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Imprimir(IList<IEstadoDeCuenta> estadosDeCuenta)
        {
            foreach(IEstadoDeCuenta estadoDeCuenta in estadosDeCuenta)
            {
                Console.WriteLine(estadoDeCuenta.GenerarEncabezado());
                Console.WriteLine(estadoDeCuenta.GenerarContenido());
                if(estadoDeCuenta is FormatoADeEstadoDeCuenta)
                {
                    Console.WriteLine(estadoDeCuenta.GenerarPie());
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            CuentaBancaria cuenta1 = new CuentaBancaria(100);
            CuentaBancaria cuenta2 = new CuentaBancaria(150);
            cuenta2.TranseferirMonto(cuenta1, 30);
            IList<IEstadoDeCuenta> estadosDeCuenta = new List<IEstadoDeCuenta>
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