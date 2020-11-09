using System;

namespace Movies.Api.Dto
{
    public class CartDto
    {
        public string MovieName { get; set; }
        public int MovieQty { get; set; }
        public decimal MoviePrice { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
