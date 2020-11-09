namespace Movies.EFDataAccess.Models
{
    public class Cart : IEntityBase
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public decimal Movieprice { get; set; }
        public int MovieQuantity { get; set; }
    }
}
