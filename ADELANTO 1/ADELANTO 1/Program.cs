namespace ADELANTO_1
{
    internal class Program
    {
        const int MAX_VEHICULOS = 20;

        static string[] placas = new string[MAX_VEHICULOS];
        static string[] marcas = new string[MAX_VEHICULOS];
        static string[] modelos = new string[MAX_VEHICULOS];
        static int[] años = new int[MAX_VEHICULOS];
        static int vehiculosRegistrados = 0;

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
                Console.WriteLine("1. Registrar vehículo");
                Console.WriteLine("2. Mostrar vehículos");
                Console.WriteLine("3. Salir");
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
                Console.WriteLine("Límite de vehículos alcanzado.");
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
    }
}