namespace ETIGRTEC.Models
{
    //OBJETOS PARA LLAMAR LA API DE UNA MEJOR MANERA 
    //OBJETO CATEGORIA, CON ESTE OBJETO LLAMAREMOS LOS DATOS Y PODEMOS INSERTAR DATOS CON LOS GET Y SET 
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
    //OBJETO PRODUCTO, CON ESTE OBJETO LLAMAREMOS LOS DATOS Y PODEMOS INSERTAR DATOS CON LOS GET Y SET 
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<string> Images { get; set; }
    }
}
