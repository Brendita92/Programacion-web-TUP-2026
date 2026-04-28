using ToDo.Datos;
using ToDo.Entidades;

namespace ToDo.Negocio
{
    public class ItemNegocio
    {
        public List<Item> ObtenerTodos()
        {
            var repo = new ItemRepository(); //quitar con inyección de dependencias
            return repo.ObtenerTodos();
        }
    }
}
