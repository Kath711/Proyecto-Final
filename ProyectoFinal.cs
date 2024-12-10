using System; // Libreria principal de Csharp
namespace Proyecto
{
    class Banco7
    {
        static decimal saldoCuentaAhorros = 10000m;         // Cuenta de ahorros con saldo inicial 10000
        static decimal saldoTarjetaCredito = (-2000m);      // Tarjeta de crédito inicialmente con -2000 saldo
        static decimal fondoInversion = 50000m;             // Fondo de inversión con 50000

        enum MenuOpciones // Uso de Enum para que el menú este organizado
        {
            Depositar = 1,
            Retirar = 2,
            Pagar = 3,
            Transferir = 4,
            Fondo = 5,
            MostrarSaldos = 6
        }

        static void Main()
        {
            // Mensaje de entrada
            Console.WriteLine("\nProyecto Final - Kathia Cortes\n");

            bool salir = false;  // Variable para controlar el flujo del programa

            do
            {
                // Estructura del Menú con Switch - Menú Principal
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("---- Funciones Bancarias ----\n");
                Console.ResetColor();
                Console.WriteLine("1. Depositar en cuenta de ahorros");
                Console.WriteLine("2. Retirar de cuenta de ahorros");
                Console.WriteLine("3. Pagar con cuenta de ahorros");
                Console.WriteLine("4. Transferir a tarjeta de crédito");
                Console.WriteLine("5. Ingresar porcentaje de utilidades en fondo de inversión");
                Console.WriteLine("6. Mostrar saldos");
                Console.WriteLine("Presiona ESC para salir");
                Console.Write("\nElija una opción: ");
                
                // Lectura de teclas para elegir la opción
                var key = Console.ReadKey(true).Key;  // `true` para que no muestre la tecla en consola

                switch (key)
                {
                    case ConsoleKey.D1:
                        RealizarAccion(MenuOpciones.Depositar);
                        break;
                    case ConsoleKey.D2:
                        RealizarAccion(MenuOpciones.Retirar);
                        break;
                    case ConsoleKey.D3:
                        RealizarAccion(MenuOpciones.Pagar);
                        break;
                    case ConsoleKey.D4:
                        RealizarAccion(MenuOpciones.Transferir);
                        break;
                    case ConsoleKey.D5:
                        RealizarAccion(MenuOpciones.Fondo);
                        break;
                    case ConsoleKey.D6:
                        RealizarAccion(MenuOpciones.MostrarSaldos);
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("\n¡Hasta Luego!");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(":)\n");
                        Console.ResetColor();
                        salir = true;  // Establecer `salir` a `true` para terminar el bucle
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                        Console.ResetColor();
                        break;
                }
                // Bucle para volver al menú
                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!salir);  // El bucle se detiene si `salir` es `true`
        }
        static void RealizarAccion(MenuOpciones opcion)
        {
            switch (opcion)
            {
                case MenuOpciones.Depositar:
                    Deposito();
                    break;
                case MenuOpciones.Retirar:
                    Retiro();
                    break;
                case MenuOpciones.Pagar:
                    Pago();
                    break;
                case MenuOpciones.Transferir:
                    Trasferencia();
                    break;
                case MenuOpciones.Fondo:
                    Fondo();
                    break;
                case MenuOpciones.MostrarSaldos:
                    Saldo();
                    break;
            }
        }
       // 1. Depositar en cuenta de ahorros (Procedimientos)
    static void Deposito()
    {
        Console.Clear();
        Console.WriteLine("Ingrese la cantidad a depositar > \n");
        if (decimal.TryParse(Console.ReadLine(), out decimal montoDeposito) && montoDeposito > 0)
        {
            saldoCuentaAhorros += montoDeposito;
            Console.WriteLine($"Depósito exitoso!\nNuevo saldo: {saldoCuentaAhorros:C2}");
        }
        else
        {
             Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cantidad inválida. El monto debe ser mayor a 0.");
                Console.ResetColor();
        }
    }
    // 2. Retirar de cuenta de ahorros (Procedimientos)
    static void Retiro()
    {
        Console.Clear();
        Console.WriteLine("Ingrese la cantidad a retirar > \n");
        if (decimal.TryParse(Console.ReadLine(), out decimal montoRetiro)&& montoRetiro > 0)
        {
            if(montoRetiro <=saldoCuentaAhorros)
            {
                saldoCuentaAhorros -= montoRetiro;
                Console.WriteLine($"Retiro exitoso!\nNuevo saldo: {saldoCuentaAhorros:C2}");
            }
        else
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Saldo insuficiente para realizar el retiro.");
            Console.ResetColor();        
         }
        }
    else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Cantidad inválida. El monto debe ser mayor a 0.");
            Console.ResetColor();    
        }
    }
    // 3. Pagar con cuenta de ahorros (Procedimientos)
    static void Pago()
    {
        Console.Clear();
        Console.WriteLine("Ingrese la cantidad a pagar > \n");
        if (decimal.TryParse(Console.ReadLine(), out decimal montoPago)&& montoPago > 0)
        {
            if(montoPago <= saldoCuentaAhorros)
            {
                saldoCuentaAhorros -= montoPago;
                Console.WriteLine($"Pago realizado!\nNuevo saldo:{saldoCuentaAhorros:C2}");
    }       else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Saldo insuficiente para realizar el pago.");
                Console.ResetColor();
            }
    }       else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cantidad inválida. El monto debe ser mayor a 0.");
                Console.ResetColor(); 
            }
    }
    // 4. Transferir a tarjeta de crédito (Procedimientos)
    static void Trasferencia()
    {
        Console.Clear();
        Console.WriteLine("Ingrese la cantidad a tranferir a la tarjeta de crédito > ");
        if (decimal.TryParse(Console.ReadLine(), out decimal montoTransferir)&& montoTransferir > 0)
        {
            if (montoTransferir <= saldoCuentaAhorros)
            {
                saldoCuentaAhorros -= montoTransferir;
                saldoTarjetaCredito += montoTransferir;
                Console.WriteLine($"Transferencia exitosa!\nSaldo de cuenta de ahorros:{saldoCuentaAhorros:C2}\nSaldo de tarjeta de crédito:{saldoTarjetaCredito:C2}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Saldo insuficiente para realizar la transferencia.");
                Console.ResetColor();
            }
        }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cantidad inválida. El monto debe ser mayor a 0.");
                Console.ResetColor();
            }
    }
    // 5. Ingresar porcentaje de utilidades en fondo de inversión (Procedimientos)
    static void Fondo()
    {
        Console.Clear();
        Console.Write("Ingrese el porcentaje de utilidades (0.01% - 25%) > ");
        if (decimal.TryParse(Console.ReadLine(), out decimal porcentaje) && porcentaje > 0.01m && porcentaje <= 25m)
        {
            decimal montoInversion = saldoCuentaAhorros * (porcentaje / 100);
            fondoInversion += montoInversion;
            saldoCuentaAhorros -= montoInversion;
            Console.WriteLine($"Se han invertido {montoInversion:C2} en el fondo de inversión. Nuevo saldo del fondo de inversión: {fondoInversion:C2}");
            Console.WriteLine($"Se han añadido {montoInversion:C2} al fondo de inversión.");
        }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Porcentaje inválido. Ingrese un valor mayor entre 0.1 y 25.");
                Console.ResetColor();
            }
    
    }
    // 6. Mostrar saldos (Procedimientos)
    static void Saldo()
    {
     Console.Clear();
            Console.WriteLine("Saldos actuales:");
            Console.WriteLine($"Cuenta de ahorros: {saldoCuentaAhorros:C2}");
            Console.WriteLine($"Tarjeta de crédito: {saldoTarjetaCredito:C2}");
            Console.WriteLine($"Fondo de inversión: {fondoInversion:C2}");
    }
  }
}
// Listo :)
   