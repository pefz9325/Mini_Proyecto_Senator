using SistemaSenator.Data;

namespace tiendita.logica
{
    public static class Gestor
    {
        // Función para validar cupos 
        public static int ContarOcupados(string restaurante, string horario)
        {
            int cuenta = 0;
            // Uso de for para recorrer las listas paralelas
            for (int i = 0; i < Almacen.ResAsignados.Count; i++)
            {
                if (Almacen.ResAsignados[i] == restaurante && Almacen.HorasAsignadas[i] == horario)
                {
                    cuenta++;
                }
            }
            return cuenta;
        }

        public static bool IntentarRegistrar(string nombre, int personas, int rPos, int hPos)
        {
            // Métodos de String: Limpieza y normalización
            string nombreLimpio = nombre.Trim().ToUpper();
            string res = Almacen.Restaurantes[rPos];
            string hor = Almacen.Horarios[hPos];

            // Validación de capacidad
            if (ContarOcupados(res, hor) < Almacen.Capacidades[rPos])
            {
                Almacen.NombresClientes.Add(nombreLimpio);
                Almacen.CantidadPersonas.Add(personas);
                Almacen.ResAsignados.Add(res);
                Almacen.HorasAsignadas.Add(hor);
                Almacen.FechasRegistro.Add(DateTime.Now);
                return true;
            }
            return false;
        }

        public static bool EliminarReserva(string nombre)
        {
            string busca = nombre.Trim().ToUpper();
            bool borrado = false;

            for (int i = 0; i < Almacen.NombresClientes.Count; i++)
            {
                if (Almacen.NombresClientes[i] == busca)
                {
                    Almacen.NombresClientes.RemoveAt(i);
                    Almacen.ResAsignados.RemoveAt(i);
                    Almacen.HorasAsignadas.RemoveAt(i);
                    Almacen.CantidadPersonas.RemoveAt(i);
                    Almacen.FechasRegistro.RemoveAt(i);
                    borrado = true;
                    break; 
                }
            }
            return borrado;
        }
    }
}