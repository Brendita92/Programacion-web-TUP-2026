namespace ToDo.Entidades
{
    public class Item
    {
        public string Titulo { get; set; }

        private bool _estado;
        
        public bool Estado
        {           //acciones antes de retornar el valor
            get { return _estado; }
                   //acciones antes de asignar el valor
            set { _estado = value; }

        }

        public override string ToString()
        {
            //return "Comprar leche (Pendiente)";
            return $"{Titulo} ({(Estado ? "Completo" : "Pendiente")})";
        }
    }


}
