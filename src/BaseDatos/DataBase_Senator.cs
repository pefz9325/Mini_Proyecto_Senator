using System.Collections.Generic;

namespace SistemaSenator.Data
{
    public static class Almacen
    {
        // Datos de configuración de los restaurantes
        public static string[] Restaurantes = { "Ember", "Zao", "Grappa", "Larimar" };
        public static int[] Capacidades = { 3, 4, 2, 3 };
        public static string[] Horarios = { "6:00 PM a 8:00 PM", "8:00 PM a 10:00 PM" };

        // Estructuras de datos para las reservaciones (Arreglos Paralelos)
        public static List<string> NombresClientes = new List<string>();
        public static List<int> CantidadPersonas = new List<int>();
        public static List<string> ResAsignados = new List<string>();
        public static List<string> HorasAsignadas = new List<string>();
        public static List<DateTime> FechasRegistro = new List<DateTime>();
    }
}