using System;
using System.Text;

namespace SingleResponsability
{
    class Program
    {
        static void Main(string[] args)
        {
            CuentaBancaria cuenta = new CuentaBancaria(100);
            CuentaBancaria cuenta1 = new CuentaBancaria(150);
            MountTransferService transfer = new MountTransferService();
            GenerateAccountStateService generateAccountStateService = new GenerateAccountStateService();

            transfer.TranseferirMonto(cuenta,cuenta1, 30);
            Console.WriteLine(generateAccountStateService.GenerarEstadoDeCuenta(cuenta));
            Console.WriteLine(generateAccountStateService.GenerarEstadoDeCuenta(cuenta1));
            Console.ReadLine();
        }
    }
}