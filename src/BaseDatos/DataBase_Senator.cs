using System;
using System.Collections.Generic;

namespace SistemaSenator.Data
{
    public class Reservacion
    {
        public string Cliente;
        public string Restaurante;
        public string Horario;
        public int CantidadPersonas;
    }

    public static class Database
    {
        // Listado global de reservaciones lista
        public static List<Reservacion> ListaReservas = new List<Reservacion>();

        // Catálogo de Restaurantes y sus capacidades máximas por array
        public static string[] Restaurantes = { "Ember", "Zao", "Grappa", "Larimar" };
        public static int[] Capacidades = { 3, 4, 2, 3 }; // Grupos por hora
        public static string[] Horarios = { "6:00 PM - 8:00 PM", "8:00 PM - 10:00 PM" };
    }
}