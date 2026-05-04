using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_parcial
{
    internal class Program
    {
        //Crear un programa que simule el funcionamiento de un cajero automatico
        //tomar en cuenta que a los 3 ingresos de su pin erroneos bloquear la tarjeta
        //Mostrar lo siguiente: Consultar saldo, deposital dinero, retirar dinero, salir
        static void Main(string[] args)
        {
            //variables
            double saldo = 1000;
            int intentos = 0;
            int pinCorrecto = 1234;
            int pin;

            //validar el pin/acceso
            while (intentos < 3)
            {
                Console.Write("Ingrese su PIN: ");
                if (int.TryParse(Console.ReadLine(), out pin))
                {
                    if (pin == pinCorrecto)
                    {
                        Console.WriteLine("Acceso Consedido!!");

                        int opcion = 0;
                        //Menú del cajero
                        while (opcion != 4)
                        {
                            Console.WriteLine("=======CAJERO AUTOMÁTICO BI======");
                            Console.WriteLine("1. Consultar Saldo");
                            Console.WriteLine("2. Depositar Dinero");
                            Console.WriteLine("3. Retirar Dinero");
                            Console.WriteLine("4. Salir");
                            Console.Write("Seleccione una opción: ");

                            int.TryParse(Console.ReadLine(), out opcion);

                            switch (opcion)
                            {
                                case 1:
                                    Console.WriteLine("CONSULTAR SALDO");
                                    Console.WriteLine("Saldo Actual: Q." + saldo);
                                    break;
                                case 2:
                                    Console.WriteLine("DEPOSITAR DINERO");
                                    Console.WriteLine("Ingresar el monto a depositar: ");
                                    double depositar;
                                    if (double.TryParse(Console.ReadLine(), out depositar) && depositar > 0)
                                    {
                                        saldo += depositar;
                                        Console.WriteLine("Deposito realizado con Exito'\nNuevo Saldo Q." + saldo);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Monto Inválido");
                                    }

                                    break;
                                case 3:
                                    Console.WriteLine("RETIRAR DINERO");
                                    Console.Write("Ingrese el monto a retirar: Q. ");
                                    double retirar;
                                    if (double.TryParse(Console.ReadLine(), out retirar) && retirar > 0)
                                    {
                                        if (retirar <= saldo)
                                        {
                                            saldo -= retirar;
                                            Console.WriteLine("Retiro Exitoso - Saldo Nuevo: Q." + saldo);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Fondos Insuficientes");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Valor Inválido");
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("Gracias por usar el cajero");
                                    break;
                                default:
                                    Console.WriteLine("Opción Inválida");
                                    break ;
                                   
                            }
                           Console.WriteLine();//salto de linea
                        }
                        return; //retornar al programa
                    }
                    else
                    {
                        intentos++;
                        Console.WriteLine("PIN Incorrecto, intentos" + intentos + " de 3\n");
                    }
                    
                }else
                {
                    Console.WriteLine("Ingrese un PIN válido\n");
                }
                
            
                
            }

            //Bloqueo de la tarjeta
            Console.WriteLine("Tarjeta Bloqueada\nDemasiados Intentos Fallidos.");
            Console.ReadKey();


        }
    }
}
