namespace BookStore.DataAccess.Entites
{
    public class Book2Entity
    {

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;

    }

}
