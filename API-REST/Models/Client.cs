namespace API_REST.Models
{
    public class Client
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Size { get; set; }
        public bool IsOverWeight { get; set; }
    }
}
