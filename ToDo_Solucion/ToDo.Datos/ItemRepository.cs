using ToDo.Entidades;

namespace ToDo.Datos
{
    public class ItemRepository
    {
        public List<Item> ObtenerTodos()
        {
            //ia a la base de datos y obtiene los items
            return new List<Item>
            {
                new Item { Titulo = "Comprar leche", Estado = false },
                new Item { Titulo = "Hacer ejercicio", Estado = true },
                new Item { Titulo = "Leer un libro", Estado = false },
                new Item { Titulo = "Llamar a mamá", Estado = true },
            };
        }
    }
}
