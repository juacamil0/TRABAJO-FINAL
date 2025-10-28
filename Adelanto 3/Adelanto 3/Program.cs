using System;

namespace Adelanto_3
{
    internal class Program
    {
        const int MAX_VEHICULOS = 20;
        const int MAX_CLIENTES = 15;
        const int MAX_SERVICIOS = 5;

        // Vehículos
        static string[] placas = new string[MAX_VEHICULOS];
        static string[] marcas = new string[MAX_VEHICULOS];
        static string[] modelos = new string[MAX_VEHICULOS];
        static int[] años = new int[MAX_VEHICULOS];
        static string[] propietario = new string[MAX_VEHICULOS];
        static int[] contadorServicios = new int[MAX_VEHICULOS];
        static string[,] tipoServicio = new string[MAX_VEHICULOS, MAX_SERVICIOS];
        static double[,] costoServicio = new double[MAX_VEHICULOS, MAX_SERVICIOS];
        static int vehiculosRegistrados = 0;

        // Clientes
        static string[] nombres = new string[MAX_CLIENTES];
        static string[] cedulas = new string[MAX_CLIENTES];
        static int clientesRegistrados = 0;

        static void Main()
        {
            for (int i = 0; i < MAX_VEHICULOS; i++) propietario[i] = "";
            MostrarMenu();
        }

        static void MostrarMenu()
        {
            int opcion = 0;
            while (opcion != 4)
            {
                Console.WriteLine("\nMENÚ PRINCIPAL");
                Console.WriteLine("1. Vehículos");
                Console.WriteLine("2. Clientes");
                Console.WriteLine("3. Servicios");
                Console.WriteLine("4. Salir");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1) MenuVehiculos();
                else if (opcion == 2) MenuClientes();
                else if (opcion == 3) MenuServicios();
                else if (opcion == 4) Console.WriteLine("Saliendo...");
                else Console.WriteLine("Opción inválida");
            }
        }

        // --- Vehiculo ---
        static void MenuVehiculos()
        {
            int opcion = 0;
            while (opcion != 4)
            {
                Console.WriteLine("\nVEHÍCULOS");
                Console.WriteLine("1. Registrar");
                Console.WriteLine("2. Mostrar");
                Console.WriteLine("3. Asignar a cliente");
                Console.WriteLine("4. Volver");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1) RegistrarVehiculo();
                else if (opcion == 2) MostrarVehiculos();
                else if (opcion == 3) AsignarVehiculo();
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
            string nuevaPlaca = Console.ReadLine();

            // Verificar si la placa ya existe
            for (int i = 0; i < vehiculosRegistrados; i++)
            {
                if (placas[i] == nuevaPlaca)
                {
                    Console.WriteLine("Error: esa placa ya está registrada.");
                    return;
                }
            }

            placas[vehiculosRegistrados] = nuevaPlaca;

            Console.Write("Marca: ");
            marcas[vehiculosRegistrados] = Console.ReadLine();

            Console.Write("Modelo: ");
            modelos[vehiculosRegistrados] = Console.ReadLine();

            Console.Write("Año: ");
            años[vehiculosRegistrados] = int.Parse(Console.ReadLine());

            propietario[vehiculosRegistrados] = "";
            contadorServicios[vehiculosRegistrados] = 0;

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
                Console.WriteLine($"{placas[i]} | {marcas[i]} | {modelos[i]} | {años[i]} | Propietario: {propietario[i]} | Servicios: {contadorServicios[i]}");
            }
        }

        static void AsignarVehiculo()
        {
            Console.Write("Placa del vehículo: ");
            string placa = Console.ReadLine();

            bool encontrado = false;
            for (int i = 0; i < vehiculosRegistrados; i++)
            {
                if (placas[i] == placa)
                {
                    encontrado = true;
                    Console.Write("Cédula del cliente: ");
                    string ced = Console.ReadLine();

                    bool clienteEncontrado = false;
                    for (int j = 0; j < clientesRegistrados; j++)
                    {
                        if (cedulas[j] == ced)
                        {
                            propietario[i] = cedulas[j];
                            clienteEncontrado = true;
                            Console.WriteLine("Vehículo asignado a " + nombres[j]);
                            break;
                        }
                    }

                    if (!clienteEncontrado) Console.WriteLine("Cliente no encontrado");
                    break;
                }
            }

            if (!encontrado) Console.WriteLine("Vehículo no encontrado");
        }

        // --- CLientes ---
        static void MenuClientes()
        {
            int opcion = 0;
            while (opcion != 3)
            {
                Console.WriteLine("\nCLIENTES");
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
            string nuevaCedula = Console.ReadLine();

            // Verificar si la cédula ya existe
            for (int i = 0; i < clientesRegistrados; i++)
            {
                if (cedulas[i] == nuevaCedula)
                {
                    Console.WriteLine("Error: esa cédula ya está registrada.");
                    return;
                }
            }

            Console.Write("Nombre: ");
            nombres[clientesRegistrados] = Console.ReadLine();

            cedulas[clientesRegistrados] = nuevaCedula;

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

        // --- Servicios ---
        static void MenuServicios()
        {
            int opcion = 0;
            while (opcion != 3)
            {
                Console.WriteLine("\nSERVICIOS");
                Console.WriteLine("1. Registrar servicio");
                Console.WriteLine("2. Ver historial");
                Console.WriteLine("3. Volver");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1) RegistrarServicio();
                else if (opcion == 2) VerHistorial();
            }
        }

        static void RegistrarServicio()
        {
            Console.Write("Placa del vehículo: ");
            string placa = Console.ReadLine();

            for (int i = 0; i < vehiculosRegistrados; i++)
            {
                if (placas[i] == placa)
                {
                    if (contadorServicios[i] >= MAX_SERVICIOS)
                    {
                        Console.WriteLine("Máximo servicios alcanzado");
                        return;
                    }

                    Console.Write("Tipo de servicio: ");
                    tipoServicio[i, contadorServicios[i]] = Console.ReadLine();

                    Console.Write("Costo: ");
                    costoServicio[i, contadorServicios[i]] = double.Parse(Console.ReadLine());

                    contadorServicios[i]++;
                    Console.WriteLine("Servicio registrado correctamente.");
                    return;
                }
            }

            Console.WriteLine("Vehículo no encontrado.");
        }

        static void VerHistorial()
        {
            Console.Write("Placa del vehículo: ");
            string placa = Console.ReadLine();

            for (int i = 0; i < vehiculosRegistrados; i++)
            {
                if (placas[i] == placa)
                {
                    if (contadorServicios[i] == 0)
                    {
                        Console.WriteLine("No hay servicios registrados para este vehículo.");
                        return;
                    }

                    Console.WriteLine("\n--- Historial de servicios ---");
                    for (int j = 0; j < contadorServicios[i]; j++)
                    {
                        Console.WriteLine($"{tipoServicio[i, j]} | Costo: {costoServicio[i, j]}");
                    }

                    return;
                }
            }

            Console.WriteLine("Vehículo no encontrado.");
        }
    }
}
