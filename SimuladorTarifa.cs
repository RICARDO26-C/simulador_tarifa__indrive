public class SimuladorTarifa
{
    public static void Maint(string[] args)
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("    Indrive - Simulador de Tarifa    ");
        Console.WriteLine("==========================================");
        // Datos de entrada.
        Console.WriteLine("Npombre del pasajero: ");
        string nombre = Console.ReadLine();
        
        Console.WriteLine("Ingrese la distacia del vaaje (Km): ");
        double distacia = double.Parse(Console.ReadLine());

        Console.WriteLine("Hora de salida (0 hrs - 23 hrs): ");
        int hora = int.Parse(Console.ReadLine());

        // \n Es para salto de linea
        Console.WriteLine("\n Tipo de Vehiculo: ");
        Console.WriteLine(" 1. Economico");
        Console.WriteLine(" 2. Confort");
        Console.WriteLine(" 3. Premium");
        Console.WriteLine(" 4. Moto");
        Console.WriteLine("Ingresa la opcion: ");
        int tipoVehiculo = int.Parse(Console.ReadLine());

        // Proceso




        // Salida
        
    
    }
}