namespace Movies.EFDataAccess.Models
{
    public class Movie : IEntityBase
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description  { get; set; }

    }
}
