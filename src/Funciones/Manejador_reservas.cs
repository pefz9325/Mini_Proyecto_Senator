using SistemaSenator.Data;

namespace SistemaSenator.Reservas
{
    public static class Motor
    {
        public static int ContarOcupados(string res, string hora)
        {
            int cuenta = 0;
            for (int i = 0; i < Almacen.ResAsignados.Count; i++)
            {
                if (Almacen.ResAsignados[i] == res && Almacen.HorasAsignadas[i] == hora)
                {
                    cuenta++;
                }
            }
            return cuenta;
        }

        public static string ObtenerPrimerNombre(string nombreCompleto)
        {
            // Uso de Split para separar el nombre
            string[] partes = nombreCompleto.Trim().Split(' ');
            return partes[0].ToUpper();
        }

        public static bool Eliminar(string nombre)
        {
            string busca = nombre.Trim().ToUpper();
            for (int i = 0; i < Almacen.NombresClientes.Count; i++)
            {
                if (Almacen.NombresClientes[i] == busca)
                {
                    Almacen.NombresClientes.RemoveAt(i);
                    Almacen.ResAsignados.RemoveAt(i);
                    Almacen.HorasAsignadas.RemoveAt(i);
                    Almacen.FechasRegistro.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}