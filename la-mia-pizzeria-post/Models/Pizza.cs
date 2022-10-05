namespace la_mia_pizzeria_post.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Img { get; set; }
        public string? Name { get; set; }
        public string? Descrition { get; set; }
        public float Amount { get; set; }

        public Pizza(int id, string? img, string? name, string? descrition, float amount)
        {
            Id = id;
            Img = img;
            Name = name;
            Descrition = descrition;
            Amount = amount;
        }
    }
}
