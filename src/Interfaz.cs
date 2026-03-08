using SistemaSenator.Data;
using tiendita.logica;

namespace SistemaSenator.Visual
{
    public static class Menu
    {
        public static void Iniciar()
        {
            string opcion = "";
            // Uso de do-while para el ciclo del menú
            do
            {
                Console.WriteLine("\n--- SISTEMA RESTAURANTES SENATOR ---");
                Console.WriteLine("1. Realizar Reservación");
                Console.WriteLine("2. Eliminar Reserva");
                Console.WriteLine("3. Ver Disponibilidad");
                Console.WriteLine("4. Imprimir Reporte");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();

                // Uso de switch case
                switch (opcion)
                {
                    case "1": NuevaReserva(); 
                    break;
                    case "2": Eliminar(); 
                    break;
                    case "3": VerDisponibilidad(); 
                    break;
                    case "4": Reporte(); 
                    break;
                }
            } 
            while (opcion != "5");
        }

        static void NuevaReserva()
        {
            try // Manejo de Excepciones
            {
                Console.Write("Nombre del cliente: ");
                string nom = Console.ReadLine();
                Console.Write("Cantidad de personas: ");
                int cant = int.Parse(Console.ReadLine());

                Console.WriteLine("Restaurantes: 1:Ember, 2:Zao, 3:Grappa, 4:Larimar");
                int r = int.Parse(Console.ReadLine());

                Console.WriteLine("Turnos: 1: 6:00 PM, 2: 8:00 PM");
                int h = int.Parse(Console.ReadLine());

                if (Gestor.IntentarRegistrar(nom, cant, r, h))
                {
                    Console.WriteLine("\n[OK] Reserva confirmada con éxito.");
                }
                else
                {
                    Console.WriteLine("\n[FULL] No hay cupo disponible en este turno.");
                }
                    
            }
            catch (Exception ex) 
            { 
                Console.WriteLine($"Error: {ex.Message}"); 
            }
        }

        static void VerDisponibilidad()
        {
            Console.WriteLine("\n--- DISPONIBILIDAD ACTUAL ---");
            int i = 0;
            while (i < Almacen.Restaurantes.Length) // Uso de while
            {
                int c1 = Gestor.ContarOcupados(Almacen.Restaurantes[i], Almacen.Horarios[0]);
                int c2 = Gestor.ContarOcupados(Almacen.Restaurantes[i], Almacen.Horarios[1]);
                
                Console.WriteLine($"{Almacen.Restaurantes[i],-10} | Turno A: {Almacen.Capacidades[i]-c1} libres | Turno B: {Almacen.Capacidades[i]-c2} libres");
                i++;
            }
        }

        static void Reporte()
        {
            Console.WriteLine("\n--- REPORTE DETALLADO ---");
            // Uso de foreach
            foreach (string nombre in Almacen.NombresClientes)
            {
                int idx = Almacen.NombresClientes.IndexOf(nombre);
                Console.WriteLine($"{idx+1}. {nombre,-15} | {Almacen.ResAsignados[idx]} | {Almacen.FechasRegistro[idx]:g}");
            }
        }

        static void Eliminar()
        {
            Console.Write("Nombre a borrar: ");
            if (Gestor.EliminarReserva(Console.ReadLine()))
            {
                Console.WriteLine("Borrado.");
            }
            else 
            {
                Console.WriteLine("No encontrado.");
            }    
        }
    }
}