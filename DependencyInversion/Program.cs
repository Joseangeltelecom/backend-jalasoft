using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversion
{
    public interface ICuentaBancaria
    {
        ulong Identificador { get; }
        double Saldo { get; }
        void IncrementarIntereses();
        void Retirar(double monto);
        void Depositar(double monto);
    }
    public interface ICuentaConMantenimiento : ICuentaBancaria
    {
        void CalcularMatenimiento();
    }
    public abstract class CuentaBancaria : ICuentaBancaria
    {
        private static readonly double TasaDeIntereses = 0.05;
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

        public void Retirar(double monto)
        {
            if (monto > 0)
                this._saldo -= this._saldo * monto;
        }

        public void Depositar(double monto)
        {
            if (monto > 0)
                this._saldo += this._saldo * monto;
        }
    }

    public class CuentaCorriente : CuentaBancaria, ICuentaConMantenimiento
    {
        private static readonly double Mantenimiento = 0.02;
        public CuentaCorriente(double saldoInicial) : base(saldoInicial) { }
        public void CalcularMatenimiento()
        {
            this._saldo -= this._saldo * Mantenimiento;
        }
    }

    public class CuentaAhorro : CuentaBancaria
    {
        private static readonly double Mantenimiento = 0.02;
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

    public class MoneyGram: ITransferMoney
    {
        public void Transferrir(ICuentaBancaria origen, ICuentaBancaria destino, double monto)
        {
            origen.Retirar(monto + (monto * 0.01));
            destino.Depositar(monto);
        }
    }

    public class WesternUnion: ITransferMoney
    {
        public void Transferrir(ICuentaBancaria origen, ICuentaBancaria destino, double monto)
        {
            origen.Retirar(monto + (monto * 0.02));
            destino.Depositar(monto);
        }
    }

    public class Transferencia
    {
        private readonly ICuentaBancaria _origen;
        private readonly ICuentaBancaria _destino;
        private readonly double _monto;
        private bool transferido;
        private readonly ITransferMoney _transfer;
        public Transferencia(ICuentaBancaria origen, ICuentaBancaria destino, double monto, ITransferMoney transfer)
        {
           // _metodoTransferencia = new MoneyGram();
            this._origen = origen;
            this._destino = destino;
            this._monto = monto;
            this._transfer = transfer;
        }
        public void Tranferir()
        {
            if (!transferido)
            {
                _transfer.Transferrir(_origen, _destino, _monto);
                transferido = true;
            }
        }
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
            ITransferMoney transferMoney = new WesternUnion();
            ICuentaConMantenimiento cuenta1 = new CuentaCorriente(100);
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
            cuenta1.CalcularMatenimiento();
            cuenta2.IncrementarIntereses();
            Transferencia transferencia = new Transferencia(cuenta1, cuenta2, 30, transferMoney); // inyecting here
            transferencia.Tranferir();
            Imprimir(estadosDeCuentaConPie);
            Imprimir(estadosDeCuentaSinPie);
            Console.ReadLine();
        }
    }
}
