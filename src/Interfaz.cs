using SistemaSenator.Data;
using SistemaSenator.Reservas;

namespace SistemaSenator.Visual
{
    public static class Menu
    {
        public static void Iniciar()
        {
            string opcion = "";
            do
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine($"   SENATOR SYSTEM | {DateTime.Now:D}");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Reservar\n2. Cancelar\n3. Ver Disponibilidad\n4. Reporte\n5. Salir");
                Console.Write("Seleccione: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": NuevaReserva(); break;
                    case "2": Cancelar(); break;
                    case "3": MostrarCupos(); break;
                    case "4": VerReporte(); break;
                }
            } while (opcion != "5");
        }

        static void NuevaReserva()
        {
            try
            {
                Console.Write("Nombre del Cliente: ");
                string nombre = Console.ReadLine().Trim().ToUpper();

                Console.WriteLine("Restaurante (1:Ember, 2:Zao, 3:Grappa, 4:Larimar):");
                int rPos = int.Parse(Console.ReadLine())-1;

                Console.WriteLine("Horario (1: 6-8PM, 2: 8-10PM):");
                int hPos = int.Parse(Console.ReadLine())-1;

                string res = Almacen.Restaurantes[rPos];
                string hor = Almacen.Horarios[hPos];

                if (Motor.ContarOcupados(res, hor) < Almacen.Capacidades[rPos])
                {
                    Almacen.NombresClientes.Add(nombre);
                    Almacen.ResAsignados.Add(res);
                    Almacen.HorasAsignadas.Add(hor);
                    Almacen.FechasRegistro.Add(DateTime.Now);
                    Console.WriteLine($"\nÉxito: {Motor.ObtenerPrimerNombre(nombre)} registrado a las {DateTime.Now:t}");
                }
                else Console.WriteLine("\nSin cupo.");
            }
            catch (Exception) 
            { 
                Console.WriteLine("\nError: Use números para las opciones."); 
            }
        }

        static void MostrarCupos()
        {
            Console.WriteLine("\n--- DISPONIBILIDAD ---");
            int i = 0;
            while (i < Almacen.Restaurantes.Length)
            {
                int c1 = Motor.ContarOcupados(Almacen.Restaurantes[i], Almacen.Horarios[0]);
                int c2 = Motor.ContarOcupados(Almacen.Restaurantes[i], Almacen.Horarios[1]);
                Console.WriteLine($"{Almacen.Restaurantes[i],-10} | 6PM: {Almacen.Capacidades[i]-c1} | 8PM: {Almacen.Capacidades[i]-c2}");
                i++;
            }
        }

        static void VerReporte()
        {
            Console.WriteLine("\n--- LISTADO ---");
            foreach (string n in Almacen.NombresClientes)
            {
                int idx = Almacen.NombresClientes.IndexOf(n);
                Console.WriteLine($"{idx+1}. {n,-20} | {Almacen.ResAsignados[idx]} | {Almacen.FechasRegistro[idx]:g}");
            }
        }

        static void Cancelar()
        {
            Console.Write("Nombre a borrar: ");
            if (Motor.Eliminar(Console.ReadLine())) Console.WriteLine("Borrado.");
            else Console.WriteLine("No encontrado.");
        }
    }
}