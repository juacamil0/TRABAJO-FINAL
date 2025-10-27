using System;

namespace TALLER_FINAL_JC_Y_JJ
{
    internal class Program
    {
        const int MAX_VEHICULOS = 20;
        const int MAX_CLIENTES = 15;

        // Vehículos
        static string[] placas = new string[MAX_VEHICULOS];
        static string[] marcas = new string[MAX_VEHICULOS];
        static string[] modelos = new string[MAX_VEHICULOS];
        static int[] años = new int[MAX_VEHICULOS];
        static int vehiculosRegistrados = 0;

        // Clientes
        static string[] nombres = new string[MAX_CLIENTES];
        static string[] cedulas = new string[MAX_CLIENTES];
        static int clientesRegistrados = 0;

        static void Main()
        {
            MostrarMenu();
        }

        static void MostrarMenu()
        {
            int opcion = 0;
            while (opcion != 3)
            {
                Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
                Console.WriteLine("1. Vehículos");
                Console.WriteLine("2. Clientes");
                Console.WriteLine("3. Salir");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1) MenuVehiculos();
                else if (opcion == 2) MenuClientes();
            }
        }

        static void MenuVehiculos()
        {
            int opcion = 0;
            while (opcion != 3)
            {
                Console.WriteLine("\n--- VEHÍCULOS ---");
                Console.WriteLine("1. Registrar");
                Console.WriteLine("2. Mostrar");
                Console.WriteLine("3. Volver");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1) RegistrarVehiculo();
                else if (opcion == 2) MostrarVehiculos();
            }
        }

        static void RegistrarVehiculo()
        {
            if (vehiculosRegistrados >= MAX_VEHICULOS)
            {
                Console.WriteLine("Límite alcanzado");
                return;
            }

            Console.Write("Placa: ");
            placas[vehiculosRegistrados] = Console.ReadLine();

            Console.Write("Marca: ");
            marcas[vehiculosRegistrados] = Console.ReadLine();

            Console.Write("Modelo: ");
            modelos[vehiculosRegistrados] = Console.ReadLine();

            Console.Write("Año: ");
            años[vehiculosRegistrados] = int.Parse(Console.ReadLine());

            vehiculosRegistrados++;
            Console.WriteLine("Vehículo registrado correctamente.");
        }

        static void MostrarVehiculos()
        {
            if (vehiculosRegistrados == 0)
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }

            for (int i = 0; i < vehiculosRegistrados; i++)
            {
                Console.WriteLine($"{placas[i]} | {marcas[i]} | {modelos[i]} | {años[i]}");
            }
        }

        static void MenuClientes()
        {
            int opcion = 0;
            while (opcion != 3)
            {
                Console.WriteLine("\n--- CLIENTES ---");
                Console.WriteLine("1. Registrar");
                Console.WriteLine("2. Mostrar");
                Console.WriteLine("3. Volver");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1) RegistrarCliente();
                else if (opcion == 2) MostrarClientes();
            }
        }

        static void RegistrarCliente()
        {
            if (clientesRegistrados >= MAX_CLIENTES)
            {
                Console.WriteLine("Límite alcanzado");
                return;
            }

            Console.Write("Cédula: ");
            cedulas[clientesRegistrados] = Console.ReadLine();

            Console.Write("Nombre: ");
            nombres[clientesRegistrados] = Console.ReadLine();

            clientesRegistrados++;
            Console.WriteLine("Cliente registrado correctamente.");
        }

        static void MostrarClientes()
        {
            if (clientesRegistrados == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }

            for (int i = 0; i < clientesRegistrados; i++)
            {
                Console.WriteLine($"{nombres[i]} | {cedulas[i]}");
            }
        }
    }
}