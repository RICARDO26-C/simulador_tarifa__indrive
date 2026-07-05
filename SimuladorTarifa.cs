public class SimuladorTarifa
{
    public static void Main(string[] args)
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("    Indrive - Simulador de Tarifa    ");
        Console.WriteLine("==========================================");
        // Datos de entrada.
        //Declaracion de variables
        string nombre;
        double distancia;
        int hora, tipoVehiculo;
        Console.Write(" Ingrese la cantidad de viajes realizados: ");
        int N = int.Parse(Console.ReadLine());

        double[] tarifas = new double[N];
        bool[] picoHora = new bool[N];
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine("\n===============================");
            Console.WriteLine("         VIAJE " + (i + 1));
            Console.WriteLine("================================");

            do
            {
                Console.WriteLine("Nombre del pasajero: ");
                nombre = Console.ReadLine();

                Console.WriteLine("Ingrese la distacia del viaje (Km): ");
                distancia = double.Parse(Console.ReadLine());

                Console.WriteLine("Hora de salida (0 hrs - 23 hrs): ");
                hora = int.Parse(Console.ReadLine());

                // \n Es para salto de linea
                Console.WriteLine("\n Tipo de Vehiculo: ");
                Console.WriteLine(" 1. Economico");
                Console.WriteLine(" 2. Confort");
                Console.WriteLine(" 3. Premium");
                Console.WriteLine(" 4. Moto");
                Console.WriteLine("Ingrese la opcion: ");
                tipoVehiculo = int.Parse(Console.ReadLine());
                if (!EsValido(distancia, hora, tipoVehiculo))
                {
                    Console.WriteLine("\nDatos inválidos. Intente nuevamente.\n");
                }
            } while (!EsValido(distancia, hora, tipoVehiculo));

            tarifas[i] = CalcularTarifa(distancia, hora, tipoVehiculo);
            picoHora[i] = EsHoraPico(hora);

            Console.WriteLine("\nTARIFA FINAL PARA ESTE VIAJE: S/ " + tarifas[i]);
        }
        Console.WriteLine("\n======================================");
        Console.WriteLine("           CIERRE DE TURNO");
        Console.WriteLine("======================================");

        Console.WriteLine(" Número de viajes          : " + N);
        Console.WriteLine(" Total ganado              : S/ " + CalcularTotal(tarifas));
        Console.WriteLine(" Tarifa Promedio del dia   : S/ " + CalcularPromedio(tarifas));
        Console.WriteLine(" Tarifa mas alta del dia   : S/ " + EncontrarMaximo(tarifas));
        Console.WriteLine(" Tarifa mas baja del dia   : S/ " + EncontrarMinimo(tarifas));
        Console.WriteLine(" Viajes Hora Pico          : " + ContarHoraPico(picoHora));
    }
    public static double CalcularTarifa(double distancia, int hora, int tipoVehiculo)
    {
        double tarifaBase = 0;
        double costoKm = 0;
        string nombreVehiculo = "";


        // Proceso
        switch (tipoVehiculo)
        {
            case 1: //Economico
                nombreVehiculo = "Econimico";
                tarifaBase = 2.0;
                costoKm = 1.5;
                break;

            case 2: //Confort
                nombreVehiculo = "Confort";
                tarifaBase = 3.0;
                costoKm = 2.0;
                break;

            case 3: // Premium
                nombreVehiculo = "Premium";
                tarifaBase = 5.0;
                costoKm = 3.0;
                break;

            case 4: // Moto
                nombreVehiculo = "Moto";
                tarifaBase = 1.5;
                costoKm = 1.0;
                break;

        }
        // Cálculo del Subtotal Base
        double subtotal = tarifaBase + (costoKm * distancia);
        if (EsHoraPico(hora))
        {
            subtotal = subtotal * 1.30; // incremento del 30%
        }
        double descuento = 0;
        // Descuento por distancia larga (5%) 
        if (distancia > 15)
        {
            descuento = subtotal * 0.05;
            subtotal = subtotal - descuento;
        }
        // Tarifa minima y redondeo
        double tarifaFinal = Math.Max(subtotal, 5.00);
        tarifaFinal = Math.Round(tarifaFinal, 2);
        return tarifaFinal;
    }
    public static bool EsHoraPico(int hora)
    {
        // Condicional de recargo por hora pico
        return (hora >= 7 && hora <= 9) || (hora >= 17 && hora <= 20);
    }

    public static bool EsValido(double distancia, int hora, int tipoVehiculo)
    {
        return distancia > 0 &&
               hora >= 0 && hora <= 23 &&
               tipoVehiculo >= 1 && tipoVehiculo <= 4;
    }

    public static double CalcularTotal(double[] tarifas)
    {
        double total = 0;

        for (int i = 0; i < tarifas.Length; i++)
        {
            total += tarifas[i];
        }

        return Math.Round(total, 2);
    }

    public static double CalcularPromedio(double[] tarifas)
    {
        return Math.Round(CalcularTotal(tarifas) / tarifas.Length, 2);
    }

    public static double EncontrarMaximo(double[] tarifas)
    {
        double maximo = tarifas[0];

        for (int i = 1; i < tarifas.Length; i++)
        {
            if (tarifas[i] > maximo)
            {
                maximo = tarifas[i];
            }
        }

        return maximo;
    }

    public static double EncontrarMinimo(double[] tarifas)
    {
        double minimo = tarifas[0];

        for (int i = 1; i < tarifas.Length; i++)
        {
            if (tarifas[i] < minimo)
            {
                minimo = tarifas[i];
            }
        }

        return minimo;
    }

    public static int ContarHoraPico(bool[] picoHora)
    {
        int contador = 0;

        for (int i = 0; i < picoHora.Length; i++)
        {
            if (picoHora[i])
            {
                contador++;
            }
        }

        return contador;
    }
}
    
        
    
