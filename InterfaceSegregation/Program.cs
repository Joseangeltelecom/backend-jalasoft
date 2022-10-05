using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationPrinciple
{
    public interface ICuentaBancaria
    {
        ulong Identificador { get; }
        double Saldo { get; }
        void IncrementarIntereses();
    }

    public interface ICalcularMantenimiento
    {
        void CalcularMatenimiento();
    }

    public abstract class CuentaBancaria : ICuentaBancaria
    {
        private static readonly double TasaDeIntereses = 0.01;
        protected double _saldo;
        private static ulong _numeroDeIdentificador = 1;
        private ulong _identificador;

        public ulong Identificador { get { return _identificador; } }
        public double Saldo { get { return _saldo; } }
        public CuentaBancaria(double saldoInicial)
        {
            _identificador = _numeroDeIdentificador++;
            _saldo = saldoInicial;
        }

        public void IncrementarIntereses()
        {
            this._saldo += this._saldo * TasaDeIntereses;
        }
    }

    public class CuentaCorriente : CuentaBancaria, ICalcularMantenimiento
    {
        private static readonly double Mantenimiento = 0.02;
        public CuentaCorriente(double saldoInicial) : base(saldoInicial) { }
        public void CalcularMatenimiento()
        {
            this._saldo += this._saldo * Mantenimiento;
        }
    }

    public class CuentaAhorro : CuentaBancaria
    {
        public CuentaAhorro(double saldoInicial) : base(saldoInicial) { }
    }

    public interface IEstadoDeCuenta
    {
        public string GenerarContenido();
        public string GenerarEncabezado();
    }

    public interface IEstadoDeCuentaConPie : IEstadoDeCuenta
    {
        public string GenerarPie();
    }

    public abstract class EstadoDeCuenta
    {
        protected ICuentaBancaria _cuenta;
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

    public class FormatoADeEstadoDeCuenta : EstadoDeCuenta, IEstadoDeCuentaConPie
    {
        public FormatoADeEstadoDeCuenta(ICuentaBancaria cuenta)
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
        public FormatoBDeEstadoDeCuenta(ICuentaBancaria cuenta)
        {
            this._cuenta = cuenta;
        }
        public string GenerarEncabezado()
        {
            return "----------FORMATO B-----------\n";
        }
    }
    class Program
    {
        static void Imprimir(IList<IEstadoDeCuentaConPie> estadosDeCuenta)
        {
            foreach (IEstadoDeCuentaConPie estadoDeCuenta in estadosDeCuenta)
            {
                Console.WriteLine(estadoDeCuenta.GenerarEncabezado());
                Console.WriteLine(estadoDeCuenta.GenerarContenido());
                Console.WriteLine(estadoDeCuenta.GenerarPie());
                Console.WriteLine();
            }
        }
        static void Imprimir(IList<IEstadoDeCuenta> estadosDeCuenta)
        {
            foreach (IEstadoDeCuenta estadoDeCuenta in estadosDeCuenta)
            {
                Console.WriteLine(estadoDeCuenta.GenerarEncabezado());
                Console.WriteLine(estadoDeCuenta.GenerarContenido());
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            ICuentaBancaria cuenta1 = new CuentaCorriente(100);
            ICalcularMantenimiento cuenta3 = (CuentaCorriente)cuenta1;
            ICuentaBancaria cuenta2 = new CuentaAhorro(150);
            IList<IEstadoDeCuentaConPie> estadosDeCuentaConPie = new List<IEstadoDeCuentaConPie>
            {
                new FormatoADeEstadoDeCuenta(cuenta1),
                new FormatoADeEstadoDeCuenta(cuenta2)
            };
            IList<IEstadoDeCuenta> estadosDeCuentaSinPie = new List<IEstadoDeCuenta>
            {
                new FormatoBDeEstadoDeCuenta(cuenta1),
                new FormatoBDeEstadoDeCuenta(cuenta2)
            };
            Imprimir(estadosDeCuentaConPie);
            Imprimir(estadosDeCuentaSinPie);
            cuenta1.IncrementarIntereses();
            cuenta2.IncrementarIntereses();
            cuenta3.CalcularMatenimiento();
            Imprimir(estadosDeCuentaConPie);
            Imprimir(estadosDeCuentaSinPie);
            Console.ReadLine();
        }
    }
}