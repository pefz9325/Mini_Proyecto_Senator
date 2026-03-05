using System;
using SistemaSenator.Data;
using SistemaSenator.Reservas;

namespace SistemaSenator.interfaz
{
    public static class MenuPrincipal
    {
        public static void MostrarMenu()
        {
            string opcion = "";
            while (opcion != "5")
            {
                Console.WriteLine("\n--- SISTEMA DE RESERVAS SENATOR ---");
                Console.WriteLine("1. Realizar Reservación");
                Console.WriteLine("2. Eliminar Reserva");
                Console.WriteLine("3. Ver Disponibilidad");
                Console.WriteLine("4. Imprimir Listado");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": Reservar(); 
                    break;
                    case "2": Cancelar(); 
                    break;
                    case "3": MostrarDisponibilidad(); 
                    break;
                    case "4": Reporte(); 
                    break;
                }
            }
        }

        static void Reservar()
        {
            Console.Write("Nombre del cliente: ");
            string nombre = Negocio.LimpiarNombre(Console.ReadLine());

            Console.WriteLine("Seleccione Restaurante: 1.Ember, 2.Zao, 3.Grappa, 4.Larimar");
            int resIdx = int.Parse(Console.ReadLine())-1;

            Console.WriteLine("Seleccione Horario: 1. 6-8PM, 2. 8-10PM");
            int horIdx = int.Parse(Console.ReadLine())-1;
            string horarioSelec = Database.Horarios[horIdx];

            if (Negocio.HayCupo(resIdx, horarioSelec))
            {
                Reservacion nueva = new Reservacion();
                nueva.Cliente = nombre;
                nueva.Restaurante = Database.Restaurantes[resIdx];
                nueva.Horario = horarioSelec;
                Database.ListaReservas.Add(nueva);
                Console.WriteLine("Reservación confirmada.");
            }
            else
            {
                Console.WriteLine("¡FULL! No hay cupo en este horario.");
            }
        }

        static void Cancelar()
        {
            Console.Write("Nombre del cliente a eliminar: ");
            string nombre = Console.ReadLine();
            if (Negocio.EliminarReserva(nombre)) Console.WriteLine("Reserva eliminada.");
            else Console.WriteLine("No se encontró el cliente.");
        }

        static void MostrarDisponibilidad()
        {
            Console.WriteLine("\n--- DISPONIBILIDAD ACTUAL ---");
            for (int i = 0; i < Database.Restaurantes.Length; i++)
            {
                foreach (var h in Database.Horarios)
                {
                    int ocupados = Negocio.ContarGrupos(Database.Restaurantes[i], h);
                    int libres = Database.Capacidades[i] - ocupados;
                    Console.WriteLine($"{Database.Restaurantes[i]} ({h}): {libres} cupos libres.");
                }
            }
        }

        static void Reporte()
        {
            Console.WriteLine("\n--- LISTADO DE RESERVACIONES ---");
            foreach (var r in Database.ListaReservas)
            {
                Console.WriteLine($"Cliente: {r.Cliente} | Rest: {r.Restaurante} | Hora: {r.Horario}");
            }
        }
    }
}