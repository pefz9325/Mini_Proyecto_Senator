using System;
using SistemaSenator.Data;

namespace SistemaSenator.Business
{
    public static class Negocio
    {
        // Cuenta cuántos grupos hay registrados para un restaurante y hora específica
        public static int ContarGrupos(string restaurante, string horario)
        {
            int contador = 0;
            foreach (var r in Database.ListaReservas)
            {
                if (r.Restaurante == restaurante && r.Horario == horario)
                    contador++;
            }
            return contador;
        }

        public static bool HayCupo(int indexRestaurante, string horario)
        {
            int ocupados = ContarGrupos(Database.Restaurantes[indexRestaurante], horario);
            return ocupados < Database.Capacidades[indexRestaurante];
        }

        public static string LimpiarNombre(string nombre)
        {
            // Quita espacios y normaliza a mayúsculas
            return nombre.Trim().ToUpper();
        }

        public static bool EliminarReserva(string nombre)
        {
            string nombreLimpio = LimpiarNombre(nombre);
            Reservacion reservaEncontrada = null;

            foreach (var r in Database.ListaReservas)
            {
                if (r.Cliente == nombreLimpio)
                {
                    reservaEncontrada = r;
                    break;
                }
            }

            if (reservaEncontrada != null)
            {
                Database.ListaReservas.Remove(reservaEncontrada);
                return true;
            }
            return false;
        }
    }
}